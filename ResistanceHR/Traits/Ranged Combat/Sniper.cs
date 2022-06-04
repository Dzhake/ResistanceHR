using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Sniper : T_CombatRanged
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Sniper>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "They can run, but they'll only die tired. But you'll be tired too, so it's best if they just die before.\n\n" +
                    "- Past a certain distance, Revolver hits deal massive damage\n" + 
                    "- Minimum range for a sniper hit is lower on unaware targets\n" +
                    "- Bullet range increased",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Sniper)),
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
                        recommendations = { nameof(Ballistician) },
                        upgrade = nameof(Sniper2),
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
