using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Huge_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.15f;
		public override float WidthRatio => 1.15f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 5;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, -1),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, -3),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, -10),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, -10),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 10),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, -10),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 1.25f;
		public override float MeleeKnockback => 1.25f;
		public override float MeleeLunge => 1.10f;
		public override float MeleeSpeed => 0.90f;

		//  IModMoveSpeed
		public override float Acceleration => 1.00f;
		public override float MoveSpeedMax => 0.90f;

		//  IModOperatingActions
		public override float OperatingTime => 1.25f;

		//  IModResistances

		public override float ResistKnockback => 1.25f;
		public override float ResistMelee => 1.10f;
		public override float ResistPoison => 1.10f;

		//  IModStatScariness
		public override float ScarinessAdded => 1.00f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{

			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 1.50f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 0.80f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 0.80f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 1.25f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 1.25f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 1.25f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
            // Base value is 5%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             0),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          1),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           20),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         5),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           20),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          10),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             0),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          5),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               5),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           1),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     5),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            1),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        10),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       15),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     10),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     10),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             5),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              10),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           20),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            0),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  0),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             5),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         5),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           5),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          0),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       0),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  5),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         0),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        5),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             10),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       10),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       0),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           20),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          20),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         20),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             0),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      10),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           5),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          10),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,15),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            10),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          20),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            5),
		};

		public override string EmaciatedName => "Shambling";
		public override string FatName => "Blubbery";
		public override string FitName => "Hulking";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Huge_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Huge_Physique)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                        VanillaTraits.Diminutive,
                        nameof(Average_Physique),
						nameof(Lanky_Physique),
						nameof(Massive_Physique),
						nameof(Short_Physique),
						nameof(Stout_Physique),
						nameof(Tall_Physique),
						nameof(Thin_Physique),
						nameof(Tiny_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {
							VTraitCategory.Defense,
							VTraitCategory.Melee,
							CTraitCategory.Unarmed,
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}