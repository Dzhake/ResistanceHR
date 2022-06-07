using RogueLibsCore;

namespace ResistanceHR.Challenges.Quest_Count
{
	public class Workhorse : C_QuestCount
	{
		public Workhorse() : base(nameof(Workhorse)) { }

		public override int QuestCount => 4;

		[RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Workhorse()
			{
				Cancellations = {
					nameof(Rushin_Revolution),
					nameof(Single_Minded)
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Workhorse)),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "You made the mistake of being reliable. Now the Resistance sends you all the work. You don't mind, because the long hours are an excuse to avoid your ugly spouse.",
				[LanguageCode.Russian] = "",
			});
		}
	}
}