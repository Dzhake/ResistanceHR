using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Strict_Alcoholic : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseNonAlcohol1, CNameDialogue.CantUseNonAlcohol2 };

		internal override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(VItemCategory.Food);

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Strict_Alcoholic>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You can't keep anything solid down anymore.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Strict_Alcoholic)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -2,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {  },
						cantLose = false,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Maybe drink more and it'll fix it?" },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}