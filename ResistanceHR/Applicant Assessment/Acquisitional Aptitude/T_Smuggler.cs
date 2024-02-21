using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RHR.Loot
{
	public abstract class T_Smuggler : T_RHR
	{
		public abstract List<string> RewardItems { get; }

		

	}

	[HarmonyPatch(typeof(Crate))]
	public class P_Crate_Smuggler
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(Crate), nameof(Crate.AddSupplies))]
		private static bool CustomizeSupplies(Crate __instance)
		{
			// TODO: Key/Value Pairs with weights

			T_Smuggler trait = GC.playerAgentList.SelectMany(a => a.GetTraits<T_Smuggler>()).FirstOrDefault();

			if (trait is null)
				return true;

			List<string> lootRollList = new List<string>(trait.RewardItems);
			int valueLimit = 999999;

			while (valueLimit > 0
				&& lootRollList.Count > 0
				&& __instance.objectInvDatabase.InvItemList.Count < 5)
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

				if (item.invItemName == VanillaItems.RemoteBomb && __instance.objectInvDatabase.InvItemList.Count < 5)
					__instance.objectInvDatabase.AddItem(VanillaItems.RemoteBombTrigger, 1);
			}

			return false;
		}
	}

	[HarmonyPatch(typeof(Quests))]
	public class P_Quests_Smuggler
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(Quests.BigQuestUpdate))]
		private static IEnumerable<CodeInstruction> ScientistCrate(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_Quests_Smuggler), nameof(P_Quests_Smuggler.ScientistCrateSoftcode));

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
			GC.playerAgentList.Select(a => a.HasTrait<T_Smuggler>()).Any()
				? VanillaAgents.Scientist
				: vanilla;
	}
}
