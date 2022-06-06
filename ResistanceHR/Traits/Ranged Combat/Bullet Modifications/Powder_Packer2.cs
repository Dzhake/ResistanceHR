using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Powder_Packer2 : T_BulletModification
    {
        public override float BulletDamageMultiplier => 0.85f;
        public override float BulletRangeMultiplier => 1.40f;
        public override float BulletPenetrationMultiplier => 2.00f;
        public override float BulletSpeedMultiplier => 1.20f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Powder_Packer2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "How much gunpowder are you going to stuff in there? How have you not exploded yet?\n\n" +
                    "- Your bullets fly fasterer, furtherer, and penetrate armorer. But they deal slightly lesser damage.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Powder_Packer2)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Myopic) },
                    CharacterCreationCost = 8,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = true,
                        prerequisites = { nameof(Eagle_Eyes), nameof(Powder_Packer) },
                        recommendations = { nameof(Eagle_Eyes) },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
