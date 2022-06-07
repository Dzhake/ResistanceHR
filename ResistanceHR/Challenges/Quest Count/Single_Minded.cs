using RogueLibsCore;

namespace ResistanceHR.Challenges.Quest_Count
{
    public class Single_Minded : C_QuestCount
	{
		public Single_Minded() : base(nameof(Single_Minded)) { }

        public override int QuestCount => 1;

        [RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Single_Minded()
			{
				Cancellations = {
					nameof(Rushin_Revolution),
					nameof(Workhorse)
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Single_Minded), "Single-Minded"),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "Your Resistance HR profile says \"Not a good multi-tasker. Barely a competent single-tasker.\" They only give you one job per Floor.",
				[LanguageCode.Russian] = "",
			});
		}
	}
}