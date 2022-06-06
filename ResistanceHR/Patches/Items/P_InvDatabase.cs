using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using JetBrains.Annotations;
using ResistanceHR.Localization;
using ResistanceHR.Traits.Item_Restrictions;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace ResistanceHR.Patches.Items
{
    [HarmonyPatch(declaringType: typeof(InvDatabase))]
	public static class P_InvDatabase
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

        /// <summary>
        /// Item Restrictions
        /// ChooseWeapon is how the game determines what weapon to auto-equip
        /// </summary>
        /// <param name="codeInstructions"></param>
        /// <returns></returns>
        [HarmonyTranspiler, UsedImplicitly, HarmonyPatch(methodName: nameof(InvDatabase.ChooseWeapon), argumentTypes: new[] { typeof(bool) })]
		private static IEnumerable<CodeInstruction> ChooseWeapon_FilterItemList(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo filteredEquipmentList = AccessTools.DeclaredMethod(typeof(T_ItemRestrictions), nameof(T_ItemRestrictions.FilteredEquipmentList));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				expectedMatches: 1,
				targetInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld),
				},
				postfixInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Callvirt),
					new CodeInstruction(OpCodes.Stloc_S, 7),
				},
				insertInstructionSequence: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),							//	this
					new CodeInstruction(OpCodes.Call, filteredEquipmentList),		//	List<string>
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.DetermineIfCanUseWeapon), argumentTypes: new[] { typeof(InvItem) })]
		public static bool DetermineIfCanUseWeapon_Prefix(InvItem item, ref bool __result)
		{
			if (item.agent is null || 
				T_ItemRestrictions.AgentTryUseItem(item.agent, item, true))
				return true; // NOT returning result here
            else
            {
				__result = false;
				return false;
            }
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.EquipArmor), argumentTypes: new[] { typeof(InvItem), typeof(bool) })]
		public static bool EquipArmor_Prefix(InvItem item, InvDatabase __instance)
		{
			logger.LogDebug("EquipArmor");
			bool result = T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);
			logger.LogDebug("Result:\t" + result);
			return result;
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.EquipArmorHead), argumentTypes: new[] { typeof(InvItem), typeof(bool) })]
		public static bool EquipArmorHead_Prefix(InvItem item, InvDatabase __instance)
		{
			logger.LogDebug("EquipArmorHead");
			bool result = T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);
			logger.LogDebug("Result:\t" + result);
			return result;
		}

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvDatabase.EquipWeapon), argumentTypes: new[] { typeof(InvItem), typeof(bool) })] 
		public static bool EquipWeapon_Prefix(InvItem item, InvDatabase __instance)
		{
			logger.LogDebug("EquipWeapon");
			bool result = T_ItemRestrictions.AgentTryUseItem(__instance.agent, item, true);
			logger.LogDebug("Result:\t" + result);
			return result;
		}
	}
}
