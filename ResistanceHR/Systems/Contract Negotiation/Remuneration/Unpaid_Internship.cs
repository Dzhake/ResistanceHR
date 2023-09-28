using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Quest_Modifiers
{
	internal class Unpaid_Internship : T_QuestRewards
	{
		public override int? RewardItemBaseQty => 0;
		public override List<string> RewardItems => new List<string>() { VanillaItems.Money };
		public override float RewardMoneyMultiplier => 0f;
		public override float RewardXPMultiplier => 2f;

		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Unpaid_Internship>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "No money or reward, but extra XP.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Unpaid_Internship), "Smoke up, Johnny!"),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Just keep at it, this is great experience! There's decorative fruit in the break room if you want a snack." },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}