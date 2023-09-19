using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Draw_No_Blood : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUsePiercing1, CNameDialogue.CantUsePiercing2 };

		internal override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(CItemCategory.Piercing);

		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
