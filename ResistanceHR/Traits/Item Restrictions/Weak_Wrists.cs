using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Weak_Wrists : T_ItemRestrictions
    {
        protected override List<string> Dialogue => 
            new List<string>() { CDialogue.CantUseHeavy };

        public override bool ItemUsable(InvItem invItem) =>
            !invItem.Categories.Contains(CItemCategory.Heavy);

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Weak_Wrists>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Heavy weapons are not your thing. A Pistol or Knife will do you just fine.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Weak_Wrists)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {  },
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
                        recommendations = { "Farmer's Carry, Wrist Curls" },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
