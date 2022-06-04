using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Vegetarian : T_ItemRestrictions
    {
        public override List<string> ProhibitedItemCategories => new List<string>() { CItemCategory.NonVegetarian };
        public override List<string> ProhibitedItemTypes => new List<string>() { };
        protected override List<string> Dialogue => new List<string>() { CDialogue.CantUseMeat1, CDialogue.CantUseMeat2, CDialogue.CantUseMeat3 };

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Vegetarian>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You are one of those people.",
                    [LanguageCode.Russian] = "Вы один из этих людей. Ну вы поняли.. вы.. веган!",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Vegetarian)),
                    [LanguageCode.Russian] = "Веган",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Carnivore), VanillaTraits.Electronic, VanillaTraits.Zombiism },
                    CharacterCreationCost = -1,
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
                        recommendations = { "Protein & B12 Supplements" },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
