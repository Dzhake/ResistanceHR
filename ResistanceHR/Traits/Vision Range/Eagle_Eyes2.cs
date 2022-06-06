using RogueLibsCore;

namespace ResistanceHR.Traits.Vision_Range
{
    public class Eagle_Eyes2 : T_VisionRange
    {
        protected override float ZoomLevel => 0.40f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Eagle_Eyes2>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You were kicked out of Sniper training when the military didn't believe you could see further *without* a scope.\n" +
                    "No-Scoping is still against Resistance policies.\n\n",
                    [LanguageCode.Russian] = "",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Eagle_Eyes2)),
                    [LanguageCode.Russian] = "Орлиные глаза +",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Myopic), nameof(Myopic2) },
                    CharacterCreationCost = 6,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = false,
                        isUpgrade = false,
                        prerequisites = { nameof(Eagle_Eyes) },
                        recommendations = { },
                        upgrade = null,
                    }
                });
        }
        public override void OnAdded() { }
        public override void OnRemoved() { }
    }
}
