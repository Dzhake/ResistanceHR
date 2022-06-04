using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Localization;
using ResistanceHR.Traits.Item_Restrictions;

namespace ResistanceHR.Patches.Item
{
    [HarmonyPatch(declaringType: typeof(InvItem))]
	public static class P_InvItem
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		/// <summary>
		/// Adds custom item categories to vanilla items
		/// </summary>
		/// <param name="__instance"></param>
		//[HarmonyPostfix, HarmonyPatch(methodName: nameof(InvItem.SetupDetails), argumentTypes: new[] { typeof(bool) })]
		public static void SetupDetails_Postfix(InvItem __instance)
		{
			string name = __instance.invItemName;

			if (VItem.nonVegetarian.Contains(name))
				__instance.Categories.Add(CItemCategory.NonVegetarian);
			else if (VItem.vegetarian.Contains(name))
				__instance.Categories.Add(CItemCategory.Vegetarian);

			if (VItem.heavy.Contains(name))
				__instance.Categories.Add(CItemCategory.Heavy);

			if (VItem.loud.Contains(name) && !__instance.contents.Contains(VItem.Silencer))
				__instance.Categories.Add(CItemCategory.Loud);

			if (VItem.piercing.Contains(name))
				__instance.Categories.Add(CItemCategory.Piercing);

			return;
		}

		/// <summary>
		/// Item Restrictions
		/// </summary>
		/// <param name="__instance"></param>
		/// <returns></returns>
		//[HarmonyPrefix, HarmonyPatch(methodName: nameof(InvItem.UseItem))]
		public static bool UseItem_Prefix(InvItem __instance)
		{
			if (!T_ItemRestrictions.CanUseItem(__instance.agent, __instance, true))
				return false;

			return true;
		}
	}
}
