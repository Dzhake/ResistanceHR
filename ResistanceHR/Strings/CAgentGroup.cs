using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR
{
	public static class CAgentGroup
	{
		#region Shadowrun Etiquettes
		public static List<string> Academic = new List<string>()
		{
			VanillaAgents.Doctor,
			VanillaAgents.Gorilla,
			VanillaAgents.InvestmentBanker,
			VanillaAgents.Scientist,
			VanillaAgents.Robot,
			VanillaAgents.ShapeShifter,
		};
		public static List<string> Corporate = new List<string>()
		{
			VanillaAgents.Clerk,
			VanillaAgents.Courier,
			VanillaAgents.OfficeDrone,
			VanillaAgents.InvestmentBanker,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Shopkeeper,
			VanillaAgents.Slavemaster,
			VanillaAgents.UpperCruster,
			VanillaAgents.Vampire,
			VanillaAgents.Worker,
		};
		public static List<string> Gang = new List<string>()
		{
			VanillaAgents.GangsterCrepe,
			VanillaAgents.GangsterBlahd,
			VanillaAgents.Mobster,
			VanillaAgents.ShapeShifter,
		};
		public static List<string> Security = new List<string>()
		{
			VanillaAgents.Bouncer,
			VanillaAgents.Cop,
			VanillaAgents.CopBot,
			VanillaAgents.Firefighter,
			VanillaAgents.Goon,
			VanillaAgents.ShapeShifter,
			VanillaAgents.SuperCop,
			VanillaAgents.Supergoon,
			VanillaAgents.Thief,
		};
		public static List<string> Shadowrunner = new List<string>()
		{
			VanillaAgents.Demolitionist,
			VanillaAgents.Hacker,
			VanillaAgents.MechPilot,
			VanillaAgents.ResistanceLeader,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Soldier,
			VanillaAgents.Thief,
		};
		public static List<string> Socialite = new List<string>()
		{
			VanillaAgents.Athlete,
			VanillaAgents.Bartender,
			VanillaAgents.Mayor,
			VanillaAgents.Musician,
			VanillaAgents.Comedian,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Vampire,
			VanillaAgents.Wrestler,
		};
		public static List<string> Street = new List<string>()
		{
			VanillaAgents.Bouncer,
			VanillaAgents.DrugDealer,
			VanillaAgents.GangsterBlahd,
			VanillaAgents.GangsterCrepe,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Slave,
			VanillaAgents.SlumDweller,
			VanillaAgents.Thief,
		};
		#endregion

		public static List<string> Badasses = new List<string>()
		{
			VanillaAgents.Athlete,
			VanillaAgents.Bartender,
			VanillaAgents.Bouncer,
			VanillaAgents.Comedian,
			VanillaAgents.DrugDealer,
			VanillaAgents.Musician,
		};
		public static List<string> Dumbasses = new List<string>()
		{
			VanillaAgents.Athlete,
			VanillaAgents.Gorilla,
			VanillaAgents.Soldier,
			VanillaAgents.Wrestler,
		};
		public static List<string> Lameasses = new List<string>()
		{
			VanillaAgents.Hacker,
			VanillaAgents.InvestmentBanker,
			VanillaAgents.OfficeDrone,
			VanillaAgents.Scientist,
			VanillaAgents.UpperCruster,
		};
		public static List<string> Smartasses = new List<string>()
		{
			VanillaAgents.Comedian,
			VanillaAgents.Doctor,
			VanillaAgents.Hacker,
			VanillaAgents.OfficeDrone,
			VanillaAgents.Scientist,
		};
		public static List<string> PunkassAffiliated = new List<string>()
		{
			VanillaAgents.GangsterBlahd,
			VanillaAgents.GangsterCrepe,
			VanillaAgents.Mobster,
		};
		public static List<string> PunkassUnaffiliated = new List<string>()
		{
			VanillaAgents.DrugDealer,
			VanillaAgents.Thief,
		};
		public static List<string> Underclass = new List<string>()
		{
			VanillaAgents.Bouncer,
			VanillaAgents.Slave,
			VanillaAgents.SlumDweller,
			VanillaAgents.Thief,
		};
		public static List<string> Upperclass = new List<string>()
		{
			VanillaAgents.Clerk,
			VanillaAgents.Doctor,
			VanillaAgents.InvestmentBanker,
			VanillaAgents.Scientist,
			VanillaAgents.Shopkeeper,
			VanillaAgents.UpperCruster,
		};

		// NEED ASS NAMES
		public static List<string> Drones = new List<string>()
		{
			VanillaAgents.Courier,
			VanillaAgents.Clerk,
			VanillaAgents.OfficeDrone,
			VanillaAgents.Worker,
		};
		public static List<string> LawEnforcers = new List<string>()
		{
			VanillaAgents.Cop,
			VanillaAgents.CopBot,
			VanillaAgents.SuperCop,
		};
		public static List<string> Nonhumans = new List<string>()
		{
			VanillaAgents.Alien,
			"ButlerBot",
			VanillaAgents.CopBot,
			VanillaAgents.Ghost,
			VanillaAgents.Gorilla,
			VanillaAgents.Robot,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Vampire,
			VanillaAgents.WerewolfTransformed,
			VanillaAgents.Zombie,
		};
		public static List<string> Robots = new List<string>()
		{
			"ButlerBot",
			VanillaAgents.CopBot,
			VanillaAgents.KillerRobot,
			VanillaAgents.Robot,
		};
		public static List<string> Chthonic = new List<string>()
		{
			VanillaAgents.Ghost,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Vampire,
			VanillaAgents.Zombie,
		};
	}
}