using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Fatass : T_ItemRestrictions
    {
        protected override List<string> Dialogue => 
            new List<string>() { CDialogue.CantUseHeadgear };

        public override bool ItemUsable(InvItem invItem) =>
            !(invItem.itemType == VItemType.Wearable && !invItem.isArmorHead);

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Fatass>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You're the first person to be medically diagnosed a Big Chunky Chungus.\n\n" + 
                        "- Can't wear body armor\n" +
                        "- Stomp damage increased\n" +
                        "- Damage from climbing through Window is doubled, makes noise\n" +
                        "- Find more food items in trashcans... god, look at yourself",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Fatass)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {  },
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
                        prerequisites = { VItem.MiniFridge },
                        recommendations = { VanillaTraits.RollerSkates, "No reason" },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
