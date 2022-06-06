using RogueLibsCore;

namespace ResistanceHR.Traits.Vision_Range
{
    public class Eagle_Eyes : T_VisionRange
    {
        public override float ZoomLevel => 0.70f;

        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomTrait<Eagle_Eyes>()
                .WithDescription(new CustomNameInfo
                {
                    [LanguageCode.English] = "You can see further than normal. Hell, you can also see further than *abnormal*.",
                    [LanguageCode.Russian] = "Вы можете видеть дальше, чем обычно. Чёрт! Это же ненормально!",
                })
                .WithName(new CustomNameInfo
                {
                    [LanguageCode.English] = DisplayName(typeof(Eagle_Eyes)),
                    [LanguageCode.Russian] = "Орлиные глаза",
                })
                .WithUnlock(new TraitUnlock
                {
                    Cancellations = { nameof(Myopic), nameof(Myopic2) },
                    CharacterCreationCost = 3,
                    IsAvailable = false,
                    IsAvailableInCC = true,
                    IsUnlocked = Core.DebugMode,
                    UnlockCost = 5,
                    Unlock =
                    {
                        cantLose = true,
                        cantSwap = false,
                        isUpgrade = false,
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
