using RogueLibsCore;

namespace RHR
{
	public enum DamageType
	{
		burnedFingers,

	}
	public static class Damage
	{
		public static float FireDamageMultiplier(Agent agent) =>
			agent.statusEffects.hasTrait(VanillaTraits.FireproofSkin2) ? 0.000f
			: agent.statusEffects.hasTrait(VanillaTraits.FireproofSkin) || agent.statusEffects.hasStatusEffect(VanillaEffects.ResistFire) ? 0.666f
			: 1.00f;

		public static int HealthCost(Agent agent, float baseDamage, DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.burnedFingers:
						return (int)(FireDamageMultiplier(agent) * baseDamage);
			}

			return (int)baseDamage;
		}
	}
}