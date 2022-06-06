using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Surgical_Striker : T_ItemRestrictions
    {
        protected override List<string> Dialogue => 
            new List<string>() { CDialogue.CantUseBlunt };

        public override bool ItemUsable(InvItem invItem) =>
            !(invItem.Categories.Contains(CItemCategory.Blunt) && invItem.itemType != VItem.Fist);

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Surgical_Striker>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Something about blunt weapons just strikes you as unrefined. Dull, even!",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Surgical_Striker)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {  },
                    CharacterCreationCost = -3,
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
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}