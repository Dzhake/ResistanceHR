using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Challenges.Quest_Rewards
{
	public class Double_Ply_Rewards : C_QuestRewards
	{
		public Double_Ply_Rewards() : base(nameof(Double_Ply_Rewards)) { }

		public override List<string> RewardItems => new List<string>() { VanillaItems.FreeItemVoucher, VanillaItems.HiringVoucher };
        public override int Quantity => 1;

        [RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Double_Ply_Rewards()
			{
				Cancellations = {
					nameof(Unpaid_Internship),
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Double_Ply_Rewards), "Double-Ply Rewards"),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "The Resistance shows their appreciation with this stack of Resistance coupons! They are totally really actually valid.\n\nThe smell? That's *value*!",
				[LanguageCode.Russian] = "",
			});
		}
	}
}