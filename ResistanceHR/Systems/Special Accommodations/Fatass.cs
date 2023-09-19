using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Fatass : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseHeadgear };

		internal override bool ItemUsable(InvItem invItem) =>
			!(invItem.itemType == VItemType.Wearable && !invItem.isArmorHead);

		//[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {  },
						cantLose = false,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { VItem.MiniFridge },
						recommendations = { VanillaTraits.RollerSkates, "No reason, it would just be funny" },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
