using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Powder_Packer : T_BulletModification
    {
        public override float BulletDamageMultiplier => 0.90f;
        public override float BulletRangeMultiplier => 1.20f;
        public override float BulletPenetrationMultiplier => 1.50f;
        public override float BulletSpeedMultiplier => 1.10f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Powder_Packer>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Your +P ammunition trades physical trauma for velocity and armor penetration.\n\n" +
                    "- Your bullets fly faster, further, and penetrate armor. But they deal slightly less damage.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Powder_Packer)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Myopic) },
                    CharacterCreationCost = 4,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = false,
                        isUpgrade = false,
                        prerequisites = { nameof(Eagle_Eyes) },
                        recommendations = { nameof(Eagle_Eyes) },
                        upgrade = nameof(Powder_Packer2),
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
