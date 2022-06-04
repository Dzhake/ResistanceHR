using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Traits.Item_Restrictions;

namespace ResistanceHR.Patches.Item
{
    [HarmonyPatch(declaringType: typeof(ItemFunctions))]
	public static class P_ItemFunctions
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		/// <summary>
		/// Item Restrictions - Interrupt gaining health even when item consumption blocked
		/// </summary>
		/// <param name="item"></param>
		/// <param name="agent"></param>
		/// <param name="__result"></param>
		[HarmonyPostfix, HarmonyPatch(methodName: nameof(ItemFunctions.DetermineHealthChange), argumentTypes: new[] { typeof(InvItem), typeof(Agent) })]
		public static void DetermineHealthChange_Postfix(InvItem item, Agent agent, ref int __result)
		{
			if (!T_ItemRestrictions.CanUseItem(agent, item, true))
				__result = 0;
		}

		/// <summary>
		/// Item Restrictions
		/// </summary>
		/// <param name="item"></param>
		/// <param name="agent"></param>
		/// <param name="__instance"></param>
		/// <returns></returns>
		[HarmonyPrefix, HarmonyPatch(methodName: nameof(ItemFunctions.UseItem), argumentTypes: new[] { typeof(InvItem), typeof(Agent) })]
		public static bool UseItem_Prefix(InvItem item, Agent agent)
		{
			if (!T_ItemRestrictions.CanUseItem(agent, item, true))
				return false;

			return true;
		}
	} 
}
