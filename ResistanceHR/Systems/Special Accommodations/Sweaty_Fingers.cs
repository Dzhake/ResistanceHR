using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Sweaty_Fingers : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseMelee };

		internal override bool ItemUsable(InvItem invItem) =>
			!(invItem.itemType == VItemType.WeaponMelee && invItem.invItemName != VItem.Fist);

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Sweaty_Fingers>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Maybe it's performance anxiety. But anytime you try to swing a weapon, it just doesn't end well. You've given up on melee weapons.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Sweaty_Fingers)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -3,
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
						recommendations = { "Don't touch me or anything I own" },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}