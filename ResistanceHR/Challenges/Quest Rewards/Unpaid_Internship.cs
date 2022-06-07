using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Challenges.Quest_Rewards
{
	public class Unpaid_Internship : C_QuestRewards
	{
		public Unpaid_Internship() : base(nameof(Unpaid_Internship)) { }

		public override List<string> RewardItems => new List<string>() { VanillaItems.Money };

        [RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Unpaid_Internship()
			{
				Cancellations = {
					nameof(Double_Ply_Rewards),
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Unpaid_Internship)),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "The double-experience you're getting working for the Resistance is worth more than any reward, they say. But so far, you're mainly learning one thing: Work for people who pay you.",
				[LanguageCode.Russian] = "",
			});
		}
	}
}