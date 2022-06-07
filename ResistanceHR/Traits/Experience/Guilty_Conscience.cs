using RogueLibsCore;

namespace ResistanceHR.Traits.Experience
{
    public class Guilty_Conscience : T_ResistanceHR
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Guilty_Conscience>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "Top researchers in the City are doing their best to understand this weird 'Kon-shents' thing. They're torturing animals around the clock, but coming no closer to answers!\n\n" +
                    "- You are subject to XP penalties for hurting and stealing from innocent people",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Guilty_Conscience)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { 
                        VanillaTraits.TheLaw
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