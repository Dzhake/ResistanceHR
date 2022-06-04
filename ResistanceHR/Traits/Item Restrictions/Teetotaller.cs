using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Teetotaller : T_ItemRestrictions
    {
        public override List<string> ProhibitedItemCategories => new List<string>() { VItemCategory.Drugs, VItemCategory.Alcohol };
        public override List<string> ProhibitedItemTypes => new List<string>() { };
        protected override List<string> Dialogue => new List<string>() { CDialogue.CantUseTeetotaller };
     
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Teetotaller>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Wow, you're really boring. You don't do drugs *or* alcohol. What do you even do?",
                    [LanguageCode.Russian] = "Удивительно но вы действительно скучный. Вы не употребляете наркотики или алкоголь.. Вы вообще живой?",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Teetotaller)),
                    [LanguageCode.Russian] = "Трезвенник",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Friend_of_Bill), nameof(DAREdevil), VanillaTraits.Addict },
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
                        prerequisites = { VanillaTraits.Addict },
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
