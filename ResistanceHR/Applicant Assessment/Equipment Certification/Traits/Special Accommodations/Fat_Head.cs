using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Item_Restrictions
{
	public class Fat_Head : T_ItemRestrictions
	{
		public override List<string> Dialogue =>
			new List<string>() { NameDialogue.CantUseHeadgear };

		public override bool ItemUsable(InvItem invItem) =>
			!(invItem.itemType == VItemType.Wearable && invItem.isArmorHead);

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

		

	}
}
