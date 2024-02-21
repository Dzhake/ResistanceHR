using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Surgical_Striker : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseBlunt };

		public override bool ItemUsable(InvItem invItem) =>
			!(invItem.Categories.Contains(ItemCategory.Blunt) && invItem.itemType != VItemName.Fist);

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Surgical_Striker>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Something about blunt weapons just strikes you as unrefined. Dull, even!",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Surgical_Striker)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -3,
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
						recommendations = { },
						upgrade = null,
					}
				});
		}

		

	}
}