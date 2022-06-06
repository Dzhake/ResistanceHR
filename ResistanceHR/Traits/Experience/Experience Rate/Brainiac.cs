using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Brainiac : T_ExperienceRate
    {
        protected override float ExperienceRate => 4.00f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Brainiac>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You have a ton of potential, and pretty much nothing else. Hopefully you live past level 1. We're rooting for you, buddy.\n\n" + 
                    "- XP gain rate set to 400%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Brainiac)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {
                        VanillaTraits.Studious,
                        VanillaTraits.Studious2,
                        nameof(Dim_Bulb),
                        nameof(Moron_the_Merrier),
                        nameof(Smooth_Brained),
                        nameof(Very_HardOn_Yourself),
                    },
                    CharacterCreationCost = 40,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = true,
                        prerequisites = { VanillaTraits.Studious2 },
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}