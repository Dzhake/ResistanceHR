using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Moron_the_Merrier : T_ExperienceRate
    {
        protected override float ExperienceRate => 0.50f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Moron_the_Merrier>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You are not playing with a full set of brain cells. You are not the sharpest tool in the dumb-person storage shed. The lights are on, but someone is dumb, and it's you. Are you understanding any of this?\n\n" + 
                    "- XP gain rate set to 50%",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Moron_the_Merrier)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {
                        VanillaTraits.Studious,
                        VanillaTraits.Studious2,
                        nameof(Brainiac),
                        nameof(Dim_Bulb),
                        nameof(Smooth_Brained),
                        nameof(Very_HardOn_Yourself),
                    },
                    CharacterCreationCost = -20,
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