using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Fatass : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseHeadgear };

		public override bool ItemUsable(InvItem invItem) =>
			!(invItem.itemType == VItemType.Wearable && !invItem.isArmorHead);

		//[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Fatass>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Can't wear body armor. Stomp damage increased. Damage from climbing through Window is doubled, makes noise. Find more food items in trashcans... god, look at yourself",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Fatass)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 0,
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
						prerequisites = { VItemName.MiniFridge },
						recommendations = { VanillaTraits.RollerSkates, "No reason, it would just be funny" },
						upgrade = null,
					}
				});
		}

		

	}
}
