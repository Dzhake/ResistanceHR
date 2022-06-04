using ResistanceHR.Traits.Combat_Ranged;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Cursed_Strikes : T_CombatMelee
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Cursed_Strikes>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You didn't call a Voodoo shaman back after a night of... magic. She didn't take it well.\n\n" + 
                    "- Unarmed attacks can hit Ghosts\n" +
                    "- Unarmed damage to all Non-Supernatural increased by 25%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Cursed_Strikes)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Blessed_Strikes), nameof(Blessed_Strikes2) },
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
                        prerequisites = { },
                        recommendations = { },
                        upgrade = nameof(Cursed_Strikes2),
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
