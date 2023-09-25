using ResistanceHR.Conduct;
using ResistanceHR.Interaction;
using System.Collections.Generic;

namespace ResistanceHR
{
	public static class CExperienceType
	{
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
			{ Boozer_Schmoozer.DrankBooze, 50 },	//	√
			{ Pyrokinetic_Learning_Style.WatchBurn,          1 },		//	√
			{ Smoker_Schmoozer.Smoked,   100 },		//	√
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