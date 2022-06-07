using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Flagellant : T_ResistanceHR
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Flagellant>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You're really hard on yourself whenever you mess up. But the hair shirt looks good! Smells bad, but looks good!\n\n" +
                    "- All XP penalties are doubled\n" + 
                    "- Additional XP penalties enabled",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Flagellant)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { 
                        VanillaTraits.TheLaw
                    },
                    CharacterCreationCost = -12,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = true,
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