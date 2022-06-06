using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Very_HardOn_Yourself : T_ResistanceHR
    {
        //[RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Very_HardOn_Yourself>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You were a rigid pianist for years. Any time you commited a boner or a cock-up, you would ejaculate in frustration. The frustrations in your life were seemin' saturated, so you thought you'd come to the Resistance. They appreciate your perfectionism - the hardest job for you to swallow is a wrecked one.\n\n" +
                    "- Anytime you miss an XP bonus, suffer a penalty.\n" + 
                    "- All XP penalties are doubled.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Very_HardOn_Yourself)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = {
                        VanillaTraits.Studious,
                        VanillaTraits.Studious2,
                        nameof(Brainiac),
                        nameof(Moron_the_Merrier),
                        nameof(Very_HardOn_Yourself),
                        nameof(Very_HardOn_Yourself),
                    },
                    CharacterCreationCost = -6,
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