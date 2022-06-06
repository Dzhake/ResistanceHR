using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Smooth_Brained : T_ExperienceRate
    {
        public override float ExperienceRate => 0.00f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Smooth_Brained>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "I'm going to say this as clearly as I can. You are stupid. Very, very, very, very, very stupid.\n\n" + 
                    "- XP gain rate set to 0%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Smooth_Brained)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {
                        VanillaTraits.Studious,
                        VanillaTraits.Studious2,
                        nameof(Brainiac),
                        nameof(Moron_the_Merrier),
                        nameof(Smooth_Brained),
                        nameof(Very_HardOn_Yourself),
                    },
                    CharacterCreationCost = -40,
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