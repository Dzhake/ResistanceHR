using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Afraid_of_Loud_Noises : T_ItemRestrictions
    {
        public override List<string> ProhibitedItemCategories => new List<string>() { CItemCategory.Loud };
        public override List<string> ProhibitedItemTypes => new List<string>() {  };
        protected override List<string> Dialogue => new List<string>() { CDialogue.CantUseLoud };

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Afraid_of_Loud_Noises>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "For a hardened infiltrator, you sure are high-strung. You refuse to use guns, bombs, and boomboxes (really?!)",
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
                    CharacterCreationCost = -4,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = false,
                        cantSwap = false,
                        isUpgrade = true,
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
