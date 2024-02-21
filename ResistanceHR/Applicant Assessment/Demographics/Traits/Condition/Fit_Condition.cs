using System.Collections.Generic;

namespace RHR.Body
{
	public class Fit_Condition : T_Condition
	{
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 1.10f;

		//	IModHealth
		public override int HealthPerEnduranceBonus => 5;

		//	IModKnockback
		public override float ResistKnockback => 1.00f;
		public override float ResistMelee => 1.00f;
		public override float ResistPoison => 1.10f;

		//	IModLuck
		public override List<KeyValuePair<string, int>> LuckBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType.UnCrit, 3),
			new KeyValuePair<string, int>(VLuckType.Intimidation, 10),

		};

		//	IModMeleeAttack
		public override float MeleeDamage => 1.10f;
		public override float MeleeKnockback => 1.10f;
		public override float MeleeLunge => 1.10f;
		public override float MeleeSpeed => 1.10f;
		public override bool? SetMobility() => null;

		//	IModMovement
		public override float Acceleration => 1.10f;
		public override float MoveSpeedMax => 1.10f;

		//	IModTransactionCosts
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 1.15f),
			new KeyValuePair<string, float>(VTransactionType.NPCMugging, 1.15f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.NPCMugging, 1.15f),
		};
	}
}
