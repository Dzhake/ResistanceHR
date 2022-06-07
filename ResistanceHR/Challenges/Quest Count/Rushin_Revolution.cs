using RogueLibsCore;

namespace ResistanceHR.Challenges.Quest_Count
{
	public class Rushin_Revolution : C_QuestCount
	{
		public Rushin_Revolution() : base(nameof(Rushin_Revolution)) { }

		public override int QuestCount => 0;

		[RLSetup]
		static void Start()
		{
			RogueLibs.CreateCustomUnlock(new Rushin_Revolution()
			{
				Cancellations = {
					nameof(Single_Minded),
					nameof(Workhorse)
				}
			})
			.WithName(new CustomNameInfo
			{
				[LanguageCode.English] = DisplayName(typeof(Rushin_Revolution), "Rushin' Revolution"),
				[LanguageCode.Russian] = "",
			})
			.WithDescription(new CustomNameInfo
			{
				[LanguageCode.English] = "There are decades where nothing happens, and there are weeks where decades happen. And then there are days where you just don't have time for this shit.\n\nNo quests. Bum rush the Mayor. Take a long weekend.",
				[LanguageCode.Russian] = "",
			});
		}
	}
}