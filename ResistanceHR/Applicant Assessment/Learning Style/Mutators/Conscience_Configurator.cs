using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Conduct
{
	class Conscience_Configurator : M_ComplianceChip
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public Conscience_Configurator() : base(nameof(Conscience_Configurator)) { }

		public override bool RollInDailyRun => true;
		public override bool ShowInLevelMutatorList => true; 

		[RLSetup]
		static void Start()
		{
			UnlockBuilder unlockBuilder = RogueLibs.CreateCustomUnlock(new Conscience_Configurator())
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "The Resistance politely requests that you refrain from killing and stealing from innocent people. Violations will result in XP demerits.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Conscience_Configurator)),
				});
		}
	}
}