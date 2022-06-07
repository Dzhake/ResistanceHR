using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Vegetarian : T_ItemRestrictions
    {
        protected override List<string> Dialogue => 
            new List<string>() { CNameDialogue.CantUseMeat1, CNameDialogue.CantUseMeat2, CNameDialogue.CantUseMeat3 };

        public override bool ItemUsable(InvItem invItem) =>
            !invItem.Categories.Contains(CItemCategory.NonVegetarian);

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
