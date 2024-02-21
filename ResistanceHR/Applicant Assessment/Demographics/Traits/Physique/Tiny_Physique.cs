using BunnyLibs;


using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Tiny_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 0.85f;
		public override float WidthRatio => 0.85f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => -2;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, 2),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, 10),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, 10),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, -15),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, 10),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 0.75f;
		public override float MeleeKnockback => 0.75f;
		public override float MeleeLunge => 0.80f;
		public override float MeleeSpeed => 1.00f;

		//  IModMoveSpeed
		public override float Acceleration => 1.10f;
		public override float MoveSpeedMax => 1.00f;

		//  IModOperatingActions
		public override float OperatingTime => 0.85f;

		//  IModResistances
		public override float ResistKnockback => 0.75f;
		public override float ResistMelee => 0.75f;
		public override float ResistPoison => 0.75f;

		//  IModStatScariness
		public override float ScarinessAdded => -0.75f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{

			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 0.50f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 1.15f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 1.20f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 0.90f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 0.90f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 0.90f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
        // base value is 5%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             15),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          15),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           10),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         5),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           0),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          10),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             5),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          10),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               0),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           5),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     5),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            5),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        5),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       0),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     5),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     5),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             5),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              0),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           0),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            10),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  5),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             5),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         15),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           5),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          5),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       5),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  5),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         10),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        5),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             5),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       0),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       15),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           0),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          0),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         0),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             15),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      5),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           5),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          5),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,5),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            5),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          5),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            5),
		};

		public override string EmaciatedName => "Fragile";
		public override string FatName => "Round";
		public override string FitName => "Wiry";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Tiny_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Tiny_Physique)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                        VanillaTraits.Diminutive,
                        nameof(Average_Physique),
						nameof(Huge_Physique),
						nameof(Lanky_Physique),
						nameof(Massive_Physique),
						nameof(Short_Physique),
						nameof(Stout_Physique),
						nameof(Tall_Physique),
						nameof(Thin_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = -3,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {
							VTraitCategory.Movement,
							VTraitCategory.Stealth,
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}