using ResistanceHR.Traits.Combat_Ranged;
using RogueLibsCore;

namespace ResistanceHR.Traits.Vision_Range
{
    public class Myopic2 : T_VisionRange
    {
        public override float ZoomLevel => 2.00f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Myopic2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "<color=orange>Accommodation:</color> Applicant can't see their own hands in front of their face. I even tested this by making a non-HR-Approved gesture to them, and they didn't even react!",
                    [LanguageCode.Russian] = "Обычно вы держите людей на расстоянии вытянотой руки, жаль что вы их всё равно не видите.",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Myopic2)),
                    [LanguageCode.Russian] = "близорукость +",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Ballistician), nameof(Ballistician2), nameof(Eagle_Eyes), nameof(Eagle_Eyes2) },
                    CharacterCreationCost = -8,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = true,
                        isUpgrade = false,
                        prerequisites = { nameof(Myopic) },
                        recommendations = { "A telescope strapped to your face" },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
