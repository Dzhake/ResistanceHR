using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Fat_Head : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseHeadgear };

		internal override bool ItemUsable(InvItem invItem) =>
			!(invItem.itemType == VItemType.Wearable && invItem.isArmorHead);

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Fat_Head>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You have a big, fat, ugly head. Your self-esteem is pretty much in the toilet. I'm not sure why.",
					[LanguageCode.Russian] = "У вас большая, жирная и уродливая голова. Вы даже не можете носить никакие головные уборы. Никто вам не одолжит солнцезащитные очки или наушники, вы их просто сломаете своей тупой, жирной головой. Неудивительно, что ваша самооценка ниже плинтуса.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Fat_Head)),
					[LanguageCode.Russian] = "Жирная голова",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -1,
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
						recommendations = { "Head ensmallening surgery" },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
