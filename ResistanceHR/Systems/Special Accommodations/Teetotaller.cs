using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Teetotaller : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseTeetotaller };

		internal override bool ItemUsable(InvItem invItem) =>
			!(invItem.Categories.Contains(VItemCategory.Alcohol) || invItem.Categories.Contains(VItemCategory.Drugs));

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Teetotaller>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Wow, you're really boring. You don't do drugs *or* alcohol. What do you even do?",
					[LanguageCode.Russian] = "Удивительно но вы действительно скучный. Вы не употребляете наркотики или алкоголь.. Вы вообще живой?",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Teetotaller)),
					[LanguageCode.Russian] = "Трезвенник",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Friend_of_Bill),
						nameof(DAREdevil),
						VanillaTraits.Addict },
					CharacterCreationCost = -4,
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
