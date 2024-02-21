using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Draw_No_Blood : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUsePiercing1, NameDialogue.CantUsePiercing2 };

		public override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(ItemCategory.Piercing);

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Draw_No_Blood>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Can't use bullet-based guns, sharp weapons, or most explosives.",
					[LanguageCode.Russian] = "Вы не можете использовать огнестрельное оружие, колющее и режущее оружие, а также большинство взрывчатых веществ.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Draw_No_Blood)),
					[LanguageCode.Russian] = "Кровянная клятва",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Jugularious,
						VanillaTraits.FleshFeast
					},
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
						recommendations = {  },
						upgrade = null,
					}
				});
		}

		

	}
}
