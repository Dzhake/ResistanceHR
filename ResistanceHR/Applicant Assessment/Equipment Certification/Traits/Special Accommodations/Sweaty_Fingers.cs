using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Sweaty_Fingers : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseMelee };

		public override bool ItemUsable(InvItem invItem) =>
			!(invItem.itemType == VItemType.WeaponMelee && invItem.invItemName != VItemName.Fist);

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

		

	}
}