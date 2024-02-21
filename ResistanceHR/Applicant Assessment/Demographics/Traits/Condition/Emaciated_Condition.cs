using System.Collections.Generic;

namespace RHR.Body
{
	public class Emaciated_Condition : T_Condition
	{
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 0.90f;

		//	IModHealth
		public override int HealthPerEnduranceBonus => -5;

		//	IModKnockback
		public override float ResistKnockback => 0.90f;
		public override float ResistMelee => 0.90f;
		public override float ResistPoison => 0.90f;

		//	IModLuck
		public override List<KeyValuePair<string, int>> LuckBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType.Intimidation, -10),
			new KeyValuePair<string, int>(VLuckType.Supernatural, 25),	// Just to have an upside
		};

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
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 0.75f),
			new KeyValuePair<string, float>(VTransactionType.NPCMugging, 0.75f),

		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 0.90f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 0.90f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 0.90f),
			new KeyValuePair<string, float>(VTransactionType.NPCMugging, 0.75f),
		};
	}
}