using RogueLibsCore;

namespace RHR.Tampering
{
	public class Spark_of_Insight_Plus : T_Tampering
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spark_of_Insight_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spark_of_Insight_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = true,
					Unlock =
					{
						categories = { },
						cancellations = {  },
						cantLose = true,
						cantSwap = false,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		

	}
}