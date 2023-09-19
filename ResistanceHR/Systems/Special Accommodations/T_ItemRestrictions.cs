using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Item_Restrictions
{
	internal abstract class T_ItemRestrictions : T_RHR
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal T_ItemRestrictions() : base() { }

		internal abstract List<string> Dialogue { get; }
		internal abstract bool ItemUsable(InvItem invItem);

		internal string GetDialogue =>
			Dialogue[UnityEngine.Random.Range(0, Dialogue.Count - 1)];

		internal static bool AgentTryUseItem(Agent agent, InvItem invItem, bool suppressDialogue)
		{
			if (!agent.GetTraits<T_ItemRestrictions>().Any())
				return true;

			foreach (T_ItemRestrictions trait in agent.GetTraits<T_ItemRestrictions>())
				if (!trait.ItemUsable(invItem))
				{
					if (!suppressDialogue)
					{
						agent.SayDialogue(agent, trait.GetDialogue);
						GC.audioHandler.Play(agent, VDialogue.CantDo);
					}

					return false;
				}

			return true;
		}

		internal static List<InvItem> FilteredEquipmentList(InvDatabase invDatabase)
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
	internal static class P_InvDatabase_ItemRestrictions
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		static bool log = false;

		/// <summary>
		/// ChooseWeapon used for auto-equip
		/// </summary>
		/// <param name="codeInstructions"></param>
		/// <returns></returns>
		//[HarmonyTranspiler, UsedImplicitly, HarmonyPatch(methodName: nameof(InvDatabase.ChooseWeapon), argumentTypes: new[] { typeof(bool) })]
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

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.DetermineIfCanUseWeapon), argumentTypes: new[] { typeof(InvItem) })]
		internal static bool FilterCanUseItem(InvItem item, ref bool __result)
		{
			if (item.agent is null ||
				T_ItemRestrictions.AgentTryUseItem(item.agent, item, true))
				return true;
			else
			{
				__result = false;
				return false;
			}
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.EquipArmor), argumentTypes: new[] { typeof(InvItem), typeof(bool) })]
		internal static bool FilterEquipArmor(InvItem item, InvDatabase __instance) =>
			T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.EquipArmorHead), argumentTypes: new[] { typeof(InvItem), typeof(bool) })]
		internal static bool FilterEquipArmorHead(InvItem item, InvDatabase __instance) =>
			T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.EquipWeapon), argumentTypes: new[] { typeof(InvItem), typeof(bool) })]
		internal static bool FilterEquipWeapon(InvItem item, InvDatabase __instance) =>
			T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);
	}

	[HarmonyPatch(typeof(InvItem))]
	internal static class P_InvItem_ItemRestrictions
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(methodName: nameof(InvItem.SetupDetails), argumentTypes: new[] { typeof(bool) })]
		internal static void CategorizeVanillaItems(InvItem __instance)
		{
			string name = __instance.invItemName;

			if (VItem.nonVegetarian.Contains(name))
				__instance.Categories.Add(CItemCategory.NonVegetarian);
			else if (VItem.vegetarian.Contains(name))
				__instance.Categories.Add(CItemCategory.Vegetarian);

			if (VItem.heavy.Contains(name))
				__instance.Categories.Add(CItemCategory.Heavy);

			if (VItem.loud.Contains(name))
				__instance.Categories.Add(CItemCategory.Loud);

			if (VItem.piercing.Contains(name))
				__instance.Categories.Add(CItemCategory.Piercing);

			if (VItem.alcohol.Contains(name))
				__instance.Categories.Add(CItemCategory.Alcohol);

			return;
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvItem.UseItem))]
		internal static bool FilterUseItem(InvItem __instance)
		{
			if (!T_ItemRestrictions.AgentTryUseItem(__instance.agent, __instance, true))
				return false;

			return true;
		}
	}

	[HarmonyPatch(typeof(ItemFunctions))]
	internal static class P_ItemFunctions_ItemRestrictions
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		internal static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(methodName: nameof(ItemFunctions.DetermineHealthChange), argumentTypes: new[] { typeof(InvItem), typeof(Agent) })]
		internal static void BlockHealthChangeEffect(InvItem item, Agent agent, ref int __result)
		{
			if (!T_ItemRestrictions.AgentTryUseItem(agent, item, true))
				__result = 0;
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(ItemFunctions.UseItem), argumentTypes: new[] { typeof(InvItem), typeof(Agent) })]
		internal static bool FilterUseItem(InvItem item, Agent agent)
		{
			if (!T_ItemRestrictions.AgentTryUseItem(agent, item, true))
				return false;

			return true;
		}
	}
}