using RogueLibsCore;

namespace ResistanceHR
{
	public static class CNameInterface
	{
		[RLSetup]
		public static void Setup()
		{
			// TODO: Just distribute these to their systems
			string t = VNameType.Interface;
			RogueLibs.CreateCustomName(CExperienceType.AngeredMany, t, new CustomNameInfo("Angered Many"));
			RogueLibs.CreateCustomName(CExperienceType.FailedBigQuestDistrict, t, new CustomNameInfo("Failed Big Quest (District)"));
			RogueLibs.CreateCustomName(CExperienceType.FailedBigQuestFloor, t, new CustomNameInfo("Failed Big Quest (Floor)"));
			RogueLibs.CreateCustomName(CExperienceType.FailedBigQuestGame, t, new CustomNameInfo("Failed Big Quest (Final)"));
			RogueLibs.CreateCustomName(CExperienceType.StoleNone, t, new CustomNameInfo("Stole Nothing"));
			RogueLibs.CreateCustomName(CExperienceType.TookLotsOfDamage, t, new CustomNameInfo("Took Lots of Damage"));
		}

		public const string

			NoMoreSemicolon = "";
	}
}