using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Ballistician2 : T_CombatRanged
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Ballistician2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "<color=blue>Credential:</color> A 6-year old reference claimed that Applicant makes really cool 'Pew Pew' noises.\n\n" +
                    "- Your bullets fly fasterer, furtherer, and harderer.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Ballistician2)),
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
                        prerequisites = { nameof(Eagle_Eyes), nameof(Ballistician) },
                        recommendations = { nameof(Eagle_Eyes) },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
