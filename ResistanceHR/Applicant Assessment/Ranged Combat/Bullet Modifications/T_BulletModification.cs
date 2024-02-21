using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace RHR.Combat_Ranged
{
	public abstract class T_BulletModification : T_CombatRanged
	{
		public T_BulletModification() : base() { }

		public abstract float BulletDamageMultiplier { get; }
		public abstract float BulletPenetrationMultiplier { get; }
		public abstract float BulletRangeMultiplier { get; }
		public abstract float BulletSpeedMultiplier { get; }

		public static float GetBulletArmorPenetration(Bullet bullet)
		{
			float penetration = 1.00f;

			if (bullet.agent is null)
				return (int)penetration;

			if (BulletTypeBullets.Contains((int)bullet.bulletType))
				foreach (T_BulletModification trait in bullet.agent.GetTraits<T_BulletModification>())
					penetration *= trait.BulletPenetrationMultiplier;

			return Mathf.Clamp(penetration, 1, 99999);
		}
		public static int GetBulletDamage(Bullet bullet)
		{
			float damage = bullet.damage;

			if (bullet.agent is null)
				return (int)damage;

			if (BulletTypeBullets.Contains((int)bullet.bulletType))
				foreach (T_BulletModification trait in bullet.agent.GetTraits<T_BulletModification>())
					damage *= trait.BulletDamageMultiplier;

			return Mathf.Clamp((int)damage, 1, 99999);
		}
		public static float GetBulletRange(Bullet bullet)
		{
			float range = 13.44f;

			if (bullet.agent is null)
				return range;

			if (BulletTypeBullets.Contains((int)bullet.bulletType))
				foreach (T_BulletModification trait in bullet.agent.GetTraits<T_BulletModification>())
					range *= trait.BulletRangeMultiplier;

			return Mathf.Clamp(range, 1.00f, 99.00f);
		}
		public static int GetBulletSpeed(Bullet bullet)
		{
			float speed = bullet.speed;

			if (bullet.agent is null)
				return (int)speed;

			if (BulletTypeBullets.Contains((int)bullet.bulletType))
				foreach (T_BulletModification trait in bullet.agent.GetTraits<T_BulletModification>())
					speed *= trait.BulletSpeedMultiplier;

			return Mathf.Clamp((int)speed, 1, 39);
			// Lowest bad number: 40? Not sure, extreme range
			// Highest good number: 39
		}

		public static readonly List<int> BulletTypeBullets = new List<int>()
		{
			1, 2, 19
		};
	}
}
