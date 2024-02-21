using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RHR.Item_Restrictions
{
	public abstract class T_ItemRestrictions : T_RHR
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public T_ItemRestrictions() : base() { }

		public abstract List<string> Dialogue { get; }
		public abstract bool ItemUsable(InvItem invItem);

		public string GetDialogue =>
			Dialogue[UnityEngine.Random.Range(0, Dialogue.Count - 1)];

		public static bool AgentTryUseItem(Agent agent, InvItem invItem, bool suppressDialogue)
		{
			if (!agent.GetTraits<T_ItemRestrictions>().Any())
				return true;

			foreach (T_ItemRestrictions trait in agent.GetTraits<T_ItemRestrictions>())
				if (!trait.ItemUsable(invItem))
				{
					if (!suppressDialogue)
					{
						agent.SayDialogue(agent, trait.GetDialogue);
						GC.audioHandler.Play(agent, "CantDo");
					}

					return false;
				}

			return true;
		}

		public static List<InvItem> FilteredEquipmentList(InvDatabase invDatabase)
		{
			if (!invDatabase.agent.GetTraits<T_ItemRestrictions>().Any())
				return invDatabase.InvItemList;

			List<InvItem> invItemList = invDatabase.InvItemList;
			List<InvItem> removals = new List<InvItem>();

			foreach (InvItem invItem in invItemList)
				if (!AgentTryUseItem(invDatabase.agent, invItem, true))
					removals.Add(invItem);

			foreach (InvItem invitem in removals)
				invItemList.Remove(invitem);

			return invItemList;
		}
	}

	[HarmonyPatch(typeof(InvDatabase))]
	public static class P_InvDatabase_ItemRestrictions
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		static bool log = false;

		/// <summary>
		/// ChooseWeapon used for auto-equip
		/// </summary>
		/// <param name="codeInstructions"></param>
		/// <returns></returns>
		//[HarmonyTranspiler, UsedImplicitly, HarmonyPatch(nameof(InvDatabase.ChooseWeapon), new[] { typeof(bool) })]
		private static IEnumerable<CodeInstruction> FilterChooseWeapon(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo filteredEquipmentList = AccessTools.DeclaredMethod(typeof(T_ItemRestrictions), nameof(T_ItemRestrictions.FilteredEquipmentList));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				targetInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld),
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Callvirt),
					new CodeInstruction(OpCodes.Stloc_S, 7),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),							//	this
					new CodeInstruction(OpCodes.Call, filteredEquipmentList),		//	List<string>
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.DetermineIfCanUseWeapon), new[] { typeof(InvItem) })]
		public static bool FilterCanUseItem(InvDatabase __instance, InvItem item, ref bool __result)
		{
			if (item.agent is null
				|| item.agent.employer == __instance.agent
				|| item.agent == __instance.agent.employer // Hopefully bypasses bug that limits items you give to employees
				|| T_ItemRestrictions.AgentTryUseItem(item.agent, item, true))
				return true;
			else
			{
				__result = false;
				return false;
			}
		}

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.EquipArmor), new[] { typeof(InvItem), typeof(bool) })]
		public static bool FilterEquipArmor(InvItem item, InvDatabase __instance) =>
			T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.EquipArmorHead), new[] { typeof(InvItem), typeof(bool) })]
		public static bool FilterEquipArmorHead(InvItem item, InvDatabase __instance) =>
			T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.EquipWeapon), new[] { typeof(InvItem), typeof(bool) })]
		public static bool FilterEquipWeapon(InvItem item, InvDatabase __instance) =>
			T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);
	}

	[HarmonyPatch(typeof(InvItem))]
	public static class P_InvItem_ItemRestrictions
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public static List<string> alcohol = new List<string>()
		{
			VItemName.Beer,
			VItemName.Cocktail,
			VItemName.Whiskey
		};

		public static List<string> drugs = new List<string>()
		{
			VItemName.Antidote,
			VItemName.Cigarettes,
			VItemName.Sugar,
			VItemName.CritterUpper,
			VItemName.CyanidePill,
			VItemName.ElectroPill,
			VItemName.Giantizer,
			VItemName.KillerThrower,
			VItemName.RagePoison,
			VItemName.Shrinker,
			VItemName.MusclyPill,
			VItemName.Syringe
		};

		public static List<string> nonVegetarian = new List<string>()
		{
			VItemName.BaconCheeseburger,
			VItemName.HamSandwich
		};

		public static List<string> vegetarian = new List<string>()
		{
			VItemName.Banana,
			VItemName.Fud,
			VItemName.HotFud,
		};

		public static List<string> heavy = new List<string>()
		{
			VItemName.Axe,
			VItemName.BaseballBat,
			VItemName.Beartrap,
			VItemName.BulletproofVest,
			VItemName.Crowbar,
			VItemName.FireExtinguisher,
			VItemName.FireproofSuit,
			VItemName.Flamethrower,
			VItemName.GhostGibber,
			VItemName.LandMine,
			VItemName.MachineGun,
			VItemName.Revolver,
			VItemName.RocketLauncher,
			VItemName.Shotgun,
			VItemName.Sledgehammer,
			VItemName.Wrench
		};

		public static List<string> loud = new List<string>()
		{
			VItemName.BoomBox,
			VItemName.DizzyGrenade,
			VItemName.DoorDetonator,
			VItemName.EMPGrenade,
			VItemName.Explodevice,
			VItemName.FireExtinguisher,
			VItemName.Fireworks,
			VItemName.GhostGibber,
			VItemName.Grenade,
			VItemName.EarWarpWhistle,
			VItemName.Leafblower,
			VItemName.LandMine,
			VItemName.MachineGun,
			VItemName.MolotovCocktail,
			VItemName.Pistol,
			VItemName.RemoteBomb,
			VItemName.Revolver,
			VItemName.RocketLauncher,
			VItemName.Shotgun,
			VItemName.TimeBomb,
			VItemName.WarpGrenade
		};

		public static List<string> piercing = new List<string>()
		{
			VItemName.Axe,
			VItemName.Beartrap,
			VItemName.Grenade,
			VItemName.Knife,
			VItemName.LandMine,
			VItemName.MachineGun,
			VItemName.Pistol,
			VItemName.Revolver,
			VItemName.RocketLauncher,
			VItemName.Shotgun,
			VItemName.Shuriken,
			VItemName.Sword
		};

		public static List<string> tools = new List<string>()
		{
			VItemName.Wrench,
			VItemName.Crowbar
		};

		[HarmonyPostfix, HarmonyPatch(nameof(InvItem.SetupDetails), new[] { typeof(bool) })]
		public static void CategorizeVanillaItems(InvItem __instance)
		{
			string name = __instance.invItemName;

			if (nonVegetarian.Contains(name))
				__instance.Categories.Add(ItemCategory.NonVegetarian);
			else if (vegetarian.Contains(name))
				__instance.Categories.Add(ItemCategory.Vegetarian);

			if (heavy.Contains(name))
				__instance.Categories.Add(ItemCategory.Heavy);

			if (loud.Contains(name))
				__instance.Categories.Add(ItemCategory.Loud);

			if (piercing.Contains(name))
				__instance.Categories.Add(ItemCategory.Piercing);

			if (alcohol.Contains(name))
				__instance.Categories.Add(ItemCategory.Alcohol);

			return;
		}

		[HarmonyPrefix, HarmonyPatch(nameof(InvItem.UseItem))]
		public static bool FilterUseItem(InvItem __instance)
		{
			if (!T_ItemRestrictions.AgentTryUseItem(__instance.agent, __instance, true))
				return false;

			return true;
		}
	}

	[HarmonyPatch(typeof(ItemFunctions))]
	public static class P_ItemFunctions_ItemRestrictions
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(ItemFunctions.DetermineHealthChange), new[] { typeof(InvItem), typeof(Agent) })]
		public static void BlockHealthChangeEffect(InvItem item, Agent agent, ref int __result)
		{
			if (!T_ItemRestrictions.AgentTryUseItem(agent, item, true))
				__result = 0;
		}

		[HarmonyPrefix, HarmonyPatch(nameof(ItemFunctions.UseItem), new[] { typeof(InvItem), typeof(Agent) })]
		public static bool FilterUseItem(InvItem item, Agent agent)
		{
			if (!T_ItemRestrictions.AgentTryUseItem(agent, item, true))
				return false;

			return true;
		}
	}
}