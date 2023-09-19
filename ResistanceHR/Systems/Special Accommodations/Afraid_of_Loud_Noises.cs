using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Item_Restrictions
{
	internal class Afraid_of_Loud_Noises : T_ItemRestrictions
	{
		internal override List<string> Dialogue =>
			new List<string>() { CNameDialogue.CantUseLoud };

		internal override bool ItemUsable(InvItem invItem) =>
			!invItem.Categories.Contains(CItemCategory.Loud) || invItem.contents.Contains(VItem.Silencer);

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Afraid_of_Loud_Noises>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You refuse to use guns, bombs, and boomboxes (really?!)",
					[LanguageCode.Russian] = "Отдача от оружия сильно ударяет меня в плечё. Пули пролетая мимо меня сильно дезоринтируют, а от запаха серы у меня проявляются рвотные рефлексы. " +
						"Громкие взрывы вызывают у меня приступы ПТСР.Всё это я узнал когда выстрелил одну пулю из пистолета..и это лишь одна пуля..",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Afraid_of_Loud_Noises)),
					[LanguageCode.Russian] = "Боязнь громких звуков",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.Pacifist,
						VanillaTraits.SausageFingers,
						VanillaTraits.StubbyFingers,
						nameof(Weak_Wrists)
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
						recommendations = { "Earplugs?" },
						upgrade = null,
					}
				});
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}