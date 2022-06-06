using System.Collections.Generic;

public static class CustomExperienceAwards // Custom Skill Points
{
	public const string
			AngeredMany = "AngeredMany",
			BQMalusDistrict = "BQMalusDowntown",
			BQMalusFloor = "BQMalusFloor",
			BQMalusGame = "BQMalusGame",
			ElectabilityMalus = "ElectabilityMalus",
			FreePrisonerFailure = "FreePrisonerFailure",
			StoleNone = "StoleNone", // TODO
			TookLotsOfDamage = "TookLotsOfDamage";

	public static Dictionary<string, int> CustomXPValues = new Dictionary<string, int>()
	{
		{AngeredMany, -100 },
		{BQMalusDistrict, -500 },
		{BQMalusFloor, -300 },
		{BQMalusGame, -1000 },
		{ElectabilityMalus, -100 },
		{FreePrisonerFailure, 1000000 },
		{StoleNone, 1000000 },
		{TookLotsOfDamage, -100 }
	};
}
