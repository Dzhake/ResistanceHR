using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Melee
{
    public class Cursed_Strikes2 : T_SpecialStrikes
    {
        public override float DamageMultiplier => 1.50f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Cursed_Strikes2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Your hands scream that they will \"herald the Undoing of the Realm of Light.\" Nothing on Google or in the manual about that. Can you wear gloves to silence them during meetings, at least?\n\n" + 
                    "- Unarmed & Melee attacks can hit Ghosts\n" +
                    "- Unarmed & Melee damage to all Non-Supernatural increased by 50%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Cursed_Strikes2)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Blessed_Strikes), nameof(Blessed_Strikes2) },
                    CharacterCreationCost = 6,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = false,
                        isUpgrade = true,
                        prerequisites = { nameof(Cursed_Strikes) },
                        recommendations = { },
                        upgrade = nameof(Cursed_Strikes2),
                    }
                });
        }

        public override bool CanHit(Agent agent)
        {
            throw new System.NotImplementedException();
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
        public override void OnStrike(Agent agent) { }
    }
}