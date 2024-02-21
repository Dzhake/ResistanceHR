using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

internal static class CTraitCategory
{
	internal const string
		Chthonic = "Chthonic",
		Leadership = "Leadership",
		Spectral = "Spectral",
		Tampering = "Tampering",
		Throwing = "Throwing",
		Trapping = "Trapping",
		Unarmed = "Unarmed";

	[HarmonyPatch(typeof(Unlocks))]
	internal static class P_Unlocks_CTraitCategory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		//	The values below should include vanilla values you want to keep.
		static readonly List<KeyValuePair<string, List<string>>> VanillaTraitCustomCategories = new List<KeyValuePair<string, List<string>>>()
		{
			new KeyValuePair<string, List<string>>(VanillaTraits.TeamBuildingExpert, new List<string>(){ Leadership })	//	Removes Social
		};

		[HarmonyPostfix, HarmonyPatch(typeof(Unlocks), nameof(Unlocks.LoadInitialUnlocks))]
		internal static void Debug()
		{
			//	Assessing original trait categories
			foreach(TraitUnlock trait in GC.sessionDataBig.unlocks.OfType<TraitUnlock>())
			{
				string log = "";
				log += $"{trait.Unlock.unlockName}): ";

				foreach (string str in trait.Unlock.categories)
					log += $"{str}, ";

				log.TrimEnd(',');
				logger.LogDebug(log);
			}

			foreach (KeyValuePair<string, List<string>> kvp in VanillaTraitCustomCategories)
			{
				Unlock trait = GC.sessionDataBig.unlocks.First(tu => tu.unlockName == kvp.Key);
				List<string> finalCategoryList = kvp.Value;
				finalCategoryList.AddRange(trait.categories);
				trait.categories = finalCategoryList.Distinct().ToList();
			}
		}
	}
} 