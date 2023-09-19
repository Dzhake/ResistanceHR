using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace ResistanceHR.Combat_Ranged
{
	internal abstract class T_BulletModification : T_CombatRanged
	{
		internal T_BulletModification() : base() { }

		internal abstract float BulletDamageMultiplier { get; }
		internal abstract float BulletPenetrationMultiplier { get; }
		internal abstract float BulletRangeMultiplier { get; }
		internal abstract float BulletSpeedMultiplier { get; }

		internal static int GetBulletDamage(Bullet bullet)
		{
			float damage = bullet.damage;

			if (bullet.agent is null)
				return (int)damage;

			if (BulletTypeBullets.Contains((int)bullet.bulletType))
				foreach (T_BulletModification trait in bullet.agent.GetTraits<T_BulletModification>())
					damage *= trait.BulletDamageMultiplier;

			return Mathf.Clamp((int)damage, 1, 99999);
		}

		internal static float GetBulletRange(Bullet bullet)
		{
			float range = 13.44f;

			if (bullet.agent is null)
				return range;

			if (BulletTypeBullets.Contains((int)bullet.bulletType))
				foreach (T_BulletModification trait in bullet.agent.GetTraits<T_BulletModification>())
					range *= trait.BulletRangeMultiplier;

			return Mathf.Clamp(range, 1.00f, 99.00f);
		}

		internal static int GetBulletSpeed(Bullet bullet)
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

		internal static readonly List<int> BulletTypeBullets = new List<int>()
		{
			1, 2, 19
		};
	}
}
