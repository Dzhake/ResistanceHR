using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Conduct
{
	class Conscience_Configurator : M_ComplianceChip
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true; 

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new M_RHR(nameof(Conscience_Configurator), true))
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you refrain from killing and stealing from innocent people. Violations will result in XP demerits.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = PlayerName(typeof(Conscience_Configurator)),
				});
		}
	}
}