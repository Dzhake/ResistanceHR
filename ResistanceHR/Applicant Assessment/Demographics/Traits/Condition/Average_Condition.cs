using System.Collections.Generic;

namespace RHR.Body
{
	public class Average_Condition : T_Condition
	{
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 1.00f;

		//	IModHealth
		public override int HealthPerEnduranceBonus => 0;

		//	IModKnockback
		public override float ResistKnockback => 1.00f;
		public override float ResistMelee => 1.00f;
		public override float ResistPoison => 1.00f;

		//	IModLuck
		public override List<KeyValuePair<string, int>> LuckBonuses => new List<KeyValuePair<string, int>> { };

		//	IModMeleeAttack
		public override float MeleeDamage => 1.00f;
		public override float MeleeKnockback => 1.00f;
		public override float MeleeLunge => 1.00f;
		public override float MeleeSpeed => 1.00f;
		public override bool? SetMobility() => null;

		//	IModMovement
		public override float Acceleration => 1.00f;
		public override float MoveSpeedMax => 1.00f;

		//	IModTransactionCosts
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>> { };
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>> { };
	}
}
