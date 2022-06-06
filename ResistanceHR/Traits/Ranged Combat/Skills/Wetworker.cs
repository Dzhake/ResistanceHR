using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Wetworker : T_CombatRanged
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Wetworker>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You're not some kind of monster. A quick bullet to the back of the head is more humane than the alternatives, isn't it?\n\n" +
                    "- Bullet attacks from behind within melee range do 2x damage. 10x if you're invisible or hidden.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Wetworker)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { VanillaTraits.Loud },
                    CharacterCreationCost = 8,
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
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
