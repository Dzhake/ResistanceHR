using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Loot
{
	internal class Supply_Smuggler : T_Loot
	{
		public override List<string> RewardItems =>
			Owner.isPlayer > 0
				? (List<string>)AccessTools.DeclaredField(typeof(SessionDataBig), "characterStartingItems" + Owner.isPlayer.ToString()).GetValue(gc.sessionDataBig)
				: new List<string>() { };

		// BUG: Spawns loadout in every crate on the level.
		// Also spawned E_Sunglasses

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Supply_Smuggler>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Each level contains a crate with some items from your character loadout.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Supply_Smuggler))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					UnlockCost = 10,
					Upgrade = null,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = true,
						removal = false,
						recommendations = { "Likely not compatible with Scientist Big Quest." },
					}
				});
		}
	}

	[HarmonyPatch(typeof(Crate))]
	internal class P_Crate_SupplySmuggler
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(Crate), nameof(Crate.AddSupplies))]
		private static bool CustomizeSupplies(Crate __instance)
		{
			T_Loot trait = GC.playerAgentList.SelectMany(a => a.GetTraits<T_Loot>()).FirstOrDefault();

			if (trait is null)
				return true;

			List<string> lootRollList = new List<string>(trait.RewardItems);
			int valueLimit = 999999;

			while (valueLimit > 0 && lootRollList.Count > 0 && __instance.objectInvDatabase.InvItemList.Count < 5)
			{
				int itemIndex = UnityEngine.Random.Range(0, lootRollList.Count);
				InvItem item = new InvItem();
				string itemName = lootRollList[itemIndex];
				item.invItemName = itemName;
				lootRollList.Remove(itemName);
				item.SetupDetails(false);
				item.invItemCount = item.initCount;
				__instance.objectInvDatabase.AddItem(item);
				valueLimit -= item.itemValue;
			}

			return false;
		}
	}

	[HarmonyPatch(typeof(Quests))]
	internal class P_Quests_SupplySmuggler
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(Quests.BigQuestUpdate))]
		private static IEnumerable<CodeInstruction> ScientistCrate(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_Quests_SupplySmuggler), nameof(P_Quests_SupplySmuggler.ScientistCrateSoftcode));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 10),
					new CodeInstruction(OpCodes.Ldstr, VanillaAgents.Scientist),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, customMethod),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		private static string ScientistCrateSoftcode(string vanilla) =>
			GC.playerAgentList.Select(a => a.HasTrait<Supply_Smuggler>()).Any()
				? VanillaAgents.Scientist
				: vanilla;
	}
}
