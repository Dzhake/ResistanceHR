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
                    [LanguageCode.English] = "You emerged from the womb fully formed, resolving never to change. The doctor declared you a perfect adult child, and retired. Your mother of course died horribly from birthing a fully-grown human.\n\n" + 
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
                        nameof(Dim_Bulb),
                        nameof(Moron_the_Merrier),
                        nameof(Guilty_Conscience),
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
                        recommendations = { "Probably therapy" },
                        upgrade = null,
                    }
                });
        }

        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}