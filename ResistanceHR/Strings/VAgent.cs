using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR
{
	internal class VAgent
	{
		public static List<string> SupernaturalAgents = new List<string>()
		{
			VanillaAgents.Ghost,
			VanillaAgents.ShapeShifter,
			VanillaAgents.Vampire,
			VanillaAgents.Werewolf,
			VanillaAgents.WerewolfTransformed,
			VanillaAgents.Zombie,
		};
	}
}