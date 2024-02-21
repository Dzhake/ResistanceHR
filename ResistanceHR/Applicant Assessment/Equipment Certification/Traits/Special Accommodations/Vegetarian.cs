using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Vegetarian : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseMeat1, NameDialogue.CantUseMeat2, NameDialogue.CantUseMeat3 };

		public override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(ItemCategory.NonVegetarian);

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Vegetarian>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You are one of those people.",
					[LanguageCode.Russian] = "Вы один из этих людей. Ну вы поняли.. вы.. веган!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Vegetarian)),
					[LanguageCode.Russian] = "Веган",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Carnivore),
						VanillaTraits.Electronic,
						VanillaTraits.Zombiism },
					CharacterCreationCost = -1,
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
						recommendations = { "Protein & B12 Supplements" },
						upgrade = null,
					}
				});
		}

		

	}
}
