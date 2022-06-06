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
		{AngeredMany, 1000000 },
		{BQMalusDistrict, 1000000 },
		{BQMalusFloor, 1000000 },
		{BQMalusGame, 1000000 },
		{ElectabilityMalus, 1000000 },
		{FreePrisonerFailure, 1000000 },
		{StoleNone, 1000000 },
		{TookLotsOfDamage, 1000000 }
	};
}
