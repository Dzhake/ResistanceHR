using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public class Fat_Head : T_ItemRestrictions
    {
        protected override List<string> Dialogue => 
            new List<string>() { CDialogue.CantUseHeadgear };

        public override bool ItemUsable(InvItem invItem) =>
            !(invItem.itemType == VItemType.Wearable && invItem.isArmorHead);

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Fat_Head>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You have a big, fat, ugly head. You can't wear hats of any kind. No one will lend you their headphones or sunglasses, because your big, fat, dumb, ugly head will break them. Your self-esteem is pretty much in the toilet. I'm not sure why.",
                    [LanguageCode.Russian] = "У вас большая, жирная и уродливая голова. Вы даже не можете носить никакие головные уборы. Никто вам не одолжит солнцезащитные очки или наушники, вы их просто сломаете своей тупой, жирной головой. Неудивительно, что ваша самооценка ниже плинтуса.",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Fat_Head)),
                    [LanguageCode.Russian] = "Жирная голова",
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
