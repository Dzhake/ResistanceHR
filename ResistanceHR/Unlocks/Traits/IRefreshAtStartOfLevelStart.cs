using BepInEx.Logging;
using BTHarmonyUtils;
using HarmonyLib;
using JetBrains.Annotations;
using RogueLibsCore;
using System.Linq;
using System.Reflection;

namespace ResistanceHR
{
	public interface IRefreshAtStartOfLevelStart
	{
		void RefreshAtLevelStart();
		bool RefreshThisLevel(int level);
	}

	[HarmonyPatch(typeof(LoadLevel))]
	public static class P_LoadLevel_RefreshAtStartOfLevelStart
	{
		public static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPrefix,HarmonyPatch(typeof(LoadLevel), nameof(LoadLevel.NextLevel))]
		public static bool RefreshAtStartOfLevelStart()
		{
			logger.LogDebug("RefreshAtStartOfLevelStart");

			foreach (Agent agent in GC.agentList)
				foreach (IRefreshAtEndOfLevelStart trait in agent.GetTraits<IRefreshAtStartOfLevelStart>())
					if (trait.RefreshThisLevel(GC.sessionDataBig.curLevelEndless))
					{
						logger.LogDebug("LevelRefresh Agent: " + ((TraitUnlock)trait).Name);
						trait.RefreshAtLevelStart(agent);
					}

			foreach (IRefreshAtStartOfLevelStart disaster in RogueFramework.CustomDisasters.Where(cd => cd.IsActive).OfType<IRefreshAtStartOfLevelStart>())
				if (disaster.RefreshThisLevel(GC.sessionDataBig.curLevelEndless))
				{
					logger.LogDebug("LevelRefresh disaster: " + ((CustomDisaster)disaster).ToString());
					disaster.RefreshAtLevelStart();
				}

			foreach (IRefreshAtStartOfLevelStart mutator in RogueFramework.Unlocks.Where(m => m.IsEnabled).OfType<IRefreshAtStartOfLevelStart>())
				if (mutator.RefreshThisLevel(GC.sessionDataBig.curLevelEndless))
				{
					logger.LogDebug("LevelRefresh mutator: " + ((MutatorUnlock)mutator).Name);
					mutator.RefreshAtLevelStart();
				}

			logger.LogDebug("RefreshAtStartOfLevelStart completed");
			return true;
		}
	}
}