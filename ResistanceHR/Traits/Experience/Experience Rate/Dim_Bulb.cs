using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Dim_Bulb : T_ExperienceRate
    {
        public override float ExperienceRate => 0.75f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Dim_Bulb>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You have more money than sense. And you're almost in the red.\n\n" + 
                    "- XP gain rate set to 75%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Dim_Bulb)),
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
                    CharacterCreationCost = -10,
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