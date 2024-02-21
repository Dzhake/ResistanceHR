using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Combat_Melee
{
	public abstract class T_EnchantedHands : T_RHR, IModMeleeAttack
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

		public float MeleeDamage => 1.00f;
		public float MeleeKnockback => 1.00f;
		public float MeleeLunge => 1.00f;
		public float MeleeSpeed => 1.00f;

		public abstract bool ApplyModMeleeAttack();
		public abstract bool CanHitGhost();
		public abstract void OnStrike(PlayfieldObject target);
		public bool? SetMobility() => null;
	}
}
