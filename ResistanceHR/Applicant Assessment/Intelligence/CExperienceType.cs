using RHR.Conduct;
using RHR.Interaction_;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR
{
	public static class CExperienceType
	{
		[RLSetup]
		public static void Setup()
		{
			// TODO: Just distribute these to their systems
			string t = NameTypes.Interface;
			RogueLibs.CreateCustomName(AngeredMany, t, new CustomNameInfo("Angered Many"));
			RogueLibs.CreateCustomName(FailedBigQuestDistrict, t, new CustomNameInfo("Failed Big Quest (District)"));
			RogueLibs.CreateCustomName(FailedBigQuestFloor, t, new CustomNameInfo("Failed Big Quest (Floor)"));
			RogueLibs.CreateCustomName(FailedBigQuestGame, t, new CustomNameInfo("Failed Big Quest (Final)"));
			RogueLibs.CreateCustomName(StoleNone, t, new CustomNameInfo("Stole Nothing"));
			RogueLibs.CreateCustomName(TookLotsOfDamage, t, new CustomNameInfo("Took Lots of Damage"));
		}

		public const string
			// Level Ends
			AngeredMany = "AngeredMany",
			FailedBigQuestDistrict = "BQMalusDowntown",
			FailedBigQuestFloor = "BQMalusFloor",
			FailedBigQuestGame = "BQMalusGame",
			ElectabilityPenalty = "ElectabilityPenalty",
			FreePrisonerFailure = "FreePrisonerFailure",
			SetOffAlarms = "SetOffAlarms",
			StoleNone = "StoleNone",
			TookLotsOfDamage = "TookLotsOfDamage";

		public static Dictionary<string, int> CustomXPValues = new Dictionary<string, int>()
		{
			{ Boozer_Schmoozer.DrankBooze, 25 },
			{ Smoker_Schmoozer.Smoked,   50 },
			{ Pyrokinetic_Learning_Style.WatchBurn,          1 },
			{ AngeredMany,              -100 },     //	T
			{ ElectabilityPenalty,      -100 },		//	C?
			{ FailedBigQuestDistrict,   -500 },		//	C
			{ FailedBigQuestFloor,      -300 },		//	√
			{ FailedBigQuestGame,       -1000 },    //	C
			{ FreePrisonerFailure,      -100 },     //	T
			{ SetOffAlarms,             -100 },		//	C
			{ StoleNone,                 300 },		//	C?
			{ TookLotsOfDamage,         -100 }		//	T
		};
	}
}