using BepInEx.Logging;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Challenges.Quest_Rewards
{
	public class Lump_Sum : C_QuestRewards
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public Lump_Sum() : base(nameof(Lump_Sum)) { }

		public override List<string> RewardItems => new List<string>() { VanillaItems.Money };

        [RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Lump_Sum()
			{
				Cancellations = {
					nameof(Unpaid_Internship),
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Lump_Sum)),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "Experience? Gratitude? The virtue of doing good deeds?\n\n" +
					"No thanks, you'll take the cash.",
				[LanguageCode.Russian] = "",
			});
		}
    }
}