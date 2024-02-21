using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Carnivore : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseVegetarian };

		public override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(ItemCategory.Vegetarian);

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Carnivore>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "\"Meeeeeeat,\" you grunt enthusiastically. Everyone around you nods politely and looks for exits.",
					[LanguageCode.Russian] = "«Мясооооо!» Вы рычите эту фразу с большим энтузиазмом!",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Carnivore)),
					[LanguageCode.Russian] = "Плотоядное животное",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.BananaLover,
						nameof(Vegetarian) },
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
						recommendations = { "Fiber supplements" },
						upgrade = null,
					}
				});
		}

		

	}
}
