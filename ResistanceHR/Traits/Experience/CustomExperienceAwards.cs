using System.Collections.Generic;

namespace ResistanceHR.Localization
{
	public static class CustomExperienceAwards
	{
		public const string
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
			{ AngeredMany,              -100 },		//	T
			{ ElectabilityPenalty,      -100 },		//	C?
			{ FailedBigQuestDistrict,   -500 },		//	C
			{ FailedBigQuestFloor,      -300 },		//	√
			{ FailedBigQuestGame,       -1000 },	//	C
			{ FreePrisonerFailure,      -100 },		//	T
			{ SetOffAlarms,             -100 },		//	C
			{ StoleNone,                300 },		//	C?
			{ TookLotsOfDamage,         -100 }		//	T
		};
	}
}