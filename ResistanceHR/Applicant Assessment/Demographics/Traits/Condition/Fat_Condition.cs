using System.Collections.Generic;

namespace RHR.Body
{
	public class Fat_Condition : T_Condition
	{
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 1.10f;

		//	IModHealth
		public override int HealthPerEnduranceBonus => 10; // Maybe the main benefit of the trait?

		//	IModKnockback
		public override float ResistKnockback => 1.25f;
		public override float ResistMelee => 1.25f;
		public override float ResistPoison => 1.25f;

		//	IModLuck
		public override List<KeyValuePair<string, int>> LuckBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType.Crit, 0),
			new KeyValuePair<string, int>(VLuckType.UnCrit, 0),
			new KeyValuePair<string, int>(VLuckType.Explosives, 0),
			new KeyValuePair<string, int>(VLuckType.Electronics, 0),
			new KeyValuePair<string, int>(VLuckType.Intimidation, 0),
			new KeyValuePair<string, int>(VLuckType.Persuasion, 0),
			new KeyValuePair<string, int>(VLuckType.Intrusion, 0),
		};

		//	IModMeleeAttack
		public override float MeleeDamage => 1.00f;
		public override float MeleeKnockback => 1.00f;
		public override float MeleeLunge => 1.10f;
		public override float MeleeSpeed => 0.90f;
		public override bool? SetMobility() => null;

		//	IModMovement
		public override float Acceleration => 0.90f;
		public override float MoveSpeedMax => 0.90f;
		
		//	IModTransactionCosts
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.HoboAssist, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.NPCMugging, 1.10f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 0.90f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 1.10f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 1.10f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 1.10f),
			new KeyValuePair<string, float>(VTransactionType.NPCMugging, 1.10f),
		};
	}
}
