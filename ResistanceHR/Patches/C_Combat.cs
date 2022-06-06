using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceHR.Patches
{
	[HarmonyPatch(declaringType: typeof(Combat))]
    public static class C_Combat
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		// TODO: Refactor
		public static bool CanAgentMeleeHitGhost(Agent agent)
		{
			//if (agent.statusEffects.hasTrait(cTrait.BlessedStrikes_2) || agent.statusEffects.hasTrait(cTrait.InfernalStrikes_2))
			//	return true;
			//else if (agent.inventory.equippedWeapon.invItemName == vItem.Fist)
			//	return (agent.statusEffects.hasTrait(cTrait.BlessedStrikes) || agent.statusEffects.hasTrait(cTrait.InfernalStrikes));

			return false;
		}

	}
}
