﻿using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class DAREdevil : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseDrugs };

		internal override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(VItemCategory.Drugs);

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<DAREdevil>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You have injected zero marijuanas. Crack is Whack. Smokers are Jokers. Needles are for... beetles.",
					[LanguageCode.Russian] = "За свою жизнь вы не разу не употребили марихуану. Для вас крэк - трещина, курилщики - шутники, а иголки для ежей",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(DAREdevil)),
					[LanguageCode.Russian] = "Наркотический отступник",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Addict,
						nameof(Friend_of_Bill),
						nameof(Teetotaller)},
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
						prerequisites = { VanillaTraits.Addict },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}