using BunnyLibs;


using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Average_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 1.00f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 0;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>> { };

		//  IModMeleeAtack
		public override float MeleeDamage => 1.00f;
		public override float MeleeKnockback => 1.00f;
		public override float MeleeLunge => 1.00f;
		public override float MeleeSpeed => 1.00f;

		//  IModMoveSpeed
		public override float Acceleration => 1.00f;
		public override float MoveSpeedMax => 1.00f;

		//  IModOperatingActions
		public override float OperatingTime => 1.00f;

		//  IModResistances
		public override float ResistKnockback => 1.00f;
		public override float ResistMelee => 1.00f;
		public override float ResistPoison => 1.00f;

		//  IModStatScariness
		public override float ScarinessAdded => 0.00f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>> { };
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>> { };

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>() { };

		public override string EmaciatedName => "Emaciated";
		public override string FatName => "Fat";
		public override string FitName => "Fit";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Average_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Average_Physique)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                        VanillaTraits.Diminutive,
                        nameof(Huge_Physique),
						nameof(Lanky_Physique),
						nameof(Massive_Physique),
						nameof(Short_Physique),
						nameof(Stout_Physique),
						nameof(Tall_Physique),
						nameof(Thin_Physique),
						nameof(Tiny_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = 0,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = false,
					UnlockCost = 0,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}