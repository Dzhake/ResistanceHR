using ResistanceHR.Traits.Combat_Ranged;
using RogueLibsCore;

namespace ResistanceHR.Traits.Vision_Range
{
    public class Myopic2 : T_VisionRange
    {
        protected override float ZoomLevel => 2.00f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Myopic2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You can't see your own hands in front of your face. I'm giving you the finger, right now!",
                    [LanguageCode.Russian] = "Обычно вы держите людей на расстоянии вытянотой руки, жаль что вы их всё равно не видите.",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Myopic2)),
                    [LanguageCode.Russian] = "близорукость +",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Powder_Packer), nameof(Powder_Packer2), nameof(Eagle_Eyes), nameof(Eagle_Eyes2) },
                    CharacterCreationCost = -12,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = false,
                        prerequisites = { nameof(Myopic) },
                        recommendations = { "A telescope strapped to your face" },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
