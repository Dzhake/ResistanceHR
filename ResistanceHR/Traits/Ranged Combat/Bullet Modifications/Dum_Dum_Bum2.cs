using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Dum_Dum_Bum2 : T_BulletModification
    {
        public override float BulletDamageMultiplier => 1.30f;
        public override float BulletRangeMultiplier => 0.50f;
        public override float BulletPenetrationMultiplier => 0.80f;
        public override float BulletSpeedMultiplier => 0.20f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Dum_Dum_Bum2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "These are barely even bullets at this point, how does this even work??\n\n" +
                    "- Your bullets have lowerer speed and distance, but deal morer damage.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Dum_Dum_Bum2)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { },
                    CharacterCreationCost = 6,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = true,
                        prerequisites = { nameof(Myopic) },
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
