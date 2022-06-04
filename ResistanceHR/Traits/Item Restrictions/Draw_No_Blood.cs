using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Draw_No_Blood : T_ItemRestrictions
    {
        public override List<string> ProhibitedItemCategories => new List<string>() { CItemCategory.Piercing };
        public override List<string> ProhibitedItemTypes => new List<string>() { };
        protected override List<string> Dialogue => new List<string>() { CDialogue.CantUsePiercing1, CDialogue.CantUsePiercing2 };

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Draw_No_Blood>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You have taken an oath to draw no blood. Guess you'll have to smash skulls really carefully, then.\n\n" +
                        "- Can't use bullet-based guns, sharp weapons, or most explosives.",
                    [LanguageCode.Russian] = "Вы приняли присягу не проливать ни капли крови.. Думаю вам надо будет крайней тщательно ломать черепа.\n\n" +
                        "- Вы не можете использовать огнестрельное оружие, колющее и режущее оружие, а также большинство взрывчатых веществ.",
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
                    CharacterCreationCost = -5,
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
                        recommendations = {  },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
