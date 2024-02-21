using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Strict_Alcoholic : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseNonAlcohol1, NameDialogue.CantUseNonAlcohol2 };

		public override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(VItemCategory.Food);

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

		

	}
}