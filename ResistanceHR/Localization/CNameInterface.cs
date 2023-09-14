using RogueLibsCore;

namespace ResistanceHR.Localization
{
    public static class CNameInterface
    {
        [RLSetup]
        public static void Setup()
        {
            string t = VNameType.Interface;
            RogueLibs.CreateCustomName(CustomExperienceAwards.AngeredMany, t, new CustomNameInfo("Angered Many"));
            RogueLibs.CreateCustomName(CustomExperienceAwards.FailedBigQuestDistrict, t, new CustomNameInfo("Failed Big Quest (District)"));
            RogueLibs.CreateCustomName(CustomExperienceAwards.FailedBigQuestFloor, t, new CustomNameInfo("Failed Big Quest (Floor)"));
            RogueLibs.CreateCustomName(CustomExperienceAwards.FailedBigQuestGame, t, new CustomNameInfo("Failed Big Quest (Final)"));
            RogueLibs.CreateCustomName(CustomExperienceAwards.StoleNone, t, new CustomNameInfo("Stole Nothing"));
            RogueLibs.CreateCustomName(CustomExperienceAwards.TookLotsOfDamage, t, new CustomNameInfo("Took Lots of Damage"));
        }

        public const string

            NoMoreSemicolon = "";
    }
}