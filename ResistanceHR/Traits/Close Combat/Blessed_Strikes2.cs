using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Blessed_Strikes2 : T_CombatMelee
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Blessed_Strikes2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You've been designated Slayer Of The Unholy by the Pope. That's a thing?\n" + 
                    "- Unarmed & Melee attacks can hit Ghosts\n" +
                    "- Unarmed & Melee damage to all Supernatural increased by 100%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Blessed_Strikes2)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Cursed_Strikes), nameof(Cursed_Strikes2) },
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
                        prerequisites = { nameof(Blessed_Strikes) },
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
