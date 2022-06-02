using ResistanceHR.Traits.Vision_Range;
using RogueLibsCore;

namespace ResistanceHR.Traits.Combat_Ranged
{
    public class Sniper2 : T_CombatRanged
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Sniper2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "<color=blue>Credential:</color> Applicant looks and smells like garbage. Appears to be wearing a poncho made out of garbage bags. But they blend right into the City!\n" +
                    "<color=yellow>Accommodation:</color> Applicant will wear Resistance-issued high-visibility vest and car air freshener when in the office environment.\n\n" +
                    "- Using a silent ranged weapon while hidden behind a Bush or other object will not remove you from concealment.",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Sniper2)),
                    [LanguageCode.Russian] = "",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Myopic) },
                    CharacterCreationCost = 8,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = true,
                        prerequisites = { nameof(Eagle_Eyes) },
                        recommendations = { nameof(Ballistician) },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
