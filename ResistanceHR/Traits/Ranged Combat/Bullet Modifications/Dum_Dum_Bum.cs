using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Dum_Dum_Bum : T_BulletModification
    {
        public override float BulletDamageMultiplier => 1.15f;
        public override float BulletRangeMultiplier => 0.75f;
        public override float BulletPenetrationMultiplier => 0.90f;
        public override float BulletSpeedMultiplier => 0.90f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Dum_Dum_Bum>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Just a little war crime, as a treat. If you file down the tip of a bullet, it won't go as far but its faster tumble will cause more trauma.\n\n" +
                    "- Your bullets have lower speed and distance, but deal more damage.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Dum_Dum_Bum)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { },
                    CharacterCreationCost = 3,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = false,
                        isUpgrade = false,
                        prerequisites = { nameof(Myopic) },
                        recommendations = { },
                        upgrade = nameof(Dum_Dum_Bum2),
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
