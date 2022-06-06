using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Carnivore : T_ItemRestrictions
    {
        protected override List<string> Dialogue => 
            new List<string>() { CDialogue.CantUseVegetarian };

        public override bool ItemUsable(InvItem invItem) =>
            !invItem.Categories.Contains(CItemCategory.Vegetarian);

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Carnivore>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "\"Meeeeeeat,\" you grunt enthusiastically. Everyone around you nods politely and looks for exits.",
                    [LanguageCode.Russian] = "«Мясооооо!» Вы рычите эту фразу с большим энтузиазмом!",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Carnivore)),
                    [LanguageCode.Russian] = "Плотоядное животное",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { VanillaTraits.BananaLover, nameof(Vegetarian) },
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
                        recommendations = { "Fiber supplements" },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
