using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Challenges.Quest_Rewards
{
	public class Monkey_Rewards : C_QuestRewards
	{
		public Monkey_Rewards() : base(nameof(Monkey_Rewards)) { }

		public override List<string> RewardItems => new List<string>() { VanillaItems.Banana };
        public override int Quantity => 3;

        [RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Monkey_Rewards()
			{
				Cancellations = {
					nameof(Unpaid_Internship),
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Monkey_Rewards)),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "Someone made a typo. But we honor our promises, so we'll pay you in Bananas.",
				[LanguageCode.Russian] = "",
			});
		}
	}
}