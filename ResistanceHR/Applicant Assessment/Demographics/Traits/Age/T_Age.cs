using BepInEx.Logging;
using BunnyLibs;
using System.Collections.Generic;

namespace RHR.Body
{
	public abstract class T_Age : T_RHR,
		IModBodySize, IModHealthPerEndurance, IModLuck, IModMeleeAttack, IModMovement, IModResistances, IModTransactionCosts
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		// IModBodySize
		public abstract float HeightRatio { get; }
		public abstract float WidthRatio { get; }

		// IModHealth
		public abstract int HealthPerEnduranceBonus { get; }

		// IModLuck
		public abstract List<KeyValuePair<string, int>> LuckBonuses { get; }

		// IModMeleeAttack
		public bool ApplyModMeleeAttack() => true;
		public bool CanHitGhost() => false;
		public abstract float MeleeDamage { get; }
		public abstract float MeleeKnockback { get; }
		public abstract float MeleeLunge { get; }
		public abstract float MeleeSpeed { get; }
		public abstract bool? SetMobility();
		public void OnStrike(PlayfieldObject target) { }

		// IModMoveSpeed
		public abstract float Acceleration { get; }
		public abstract float MoveSpeedMax { get; }
		public float MoveVolume => 1.00f;

		// IModResistances
		public float ResistBullets => 1.00f;
		public float ResistExplosion => 1.00f;
		public float ResistFire => 1.00f;
		public abstract float ResistKnockback { get; }
		public abstract float ResistMelee { get; }
		public abstract float ResistPoison { get; }

		// IModTransactionCosts
		public abstract List<KeyValuePair<string, float>> CostBonusesAsNPC { get; }
		public abstract List<KeyValuePair<string, float>> CostBonusesAsPlayer { get; }

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}
