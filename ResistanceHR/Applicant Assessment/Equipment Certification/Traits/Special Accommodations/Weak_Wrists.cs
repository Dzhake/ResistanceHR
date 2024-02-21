using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Weak_Wrists : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseHeavy };

		public override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(ItemCategory.Heavy);

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Weak_Wrists>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Heavy weapons are not your thing. A Pistol or Knife will do you just fine.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Weak_Wrists)),
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
						recommendations = { "Farmer's Carry, Wrist Curls" },
						upgrade = null,
					}
				});
		}

		

	}
}
