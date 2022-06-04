using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Blessed_Strikes : T_CombatMelee
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Blessed_Strikes>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Your fists are registered deadly weapons, and designated holy Relics by the Catholic Church. It's even documented on a cool scroll. Absolutely wild!\n\n" + 
                    "- Unarmed attacks can hit Ghosts\n" +
                    "- Unarmed damage to all Supernatural increased by 50%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Blessed_Strikes)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Cursed_Strikes), nameof(Cursed_Strikes2) },
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
                        upgrade = nameof(Blessed_Strikes2),
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
