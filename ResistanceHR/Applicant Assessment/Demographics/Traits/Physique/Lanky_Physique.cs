using BunnyLibs;


using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Lanky_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.10f;
		public override float WidthRatio => 0.90f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 0;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, -1),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, -2),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 3),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, 0),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 1.00f;
		public override float MeleeKnockback => 1.00f;
		public override float MeleeLunge => 1.25f;
		public override float MeleeSpeed => 0.90f;

		//  IModMoveSpeed
		public override float Acceleration => 0.95f;
		public override float MoveSpeedMax => 1.20f;

		//  IModOperatingActions
		public override float OperatingTime => 1.00f;

		//  IModResistances
		public override float ResistKnockback => 0.85f;
		public override float ResistMelee => 1.00f;
		public override float ResistPoison => 1.00f;

		//  IModStatScariness
		public override float ScarinessAdded => 0.00f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 0.95f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 1.05f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 0.95f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 0.95f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 0.95f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
        // base value is 5%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             0),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          4),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           15),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         5),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           0),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          15),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             5),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          15),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               5),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           10),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     5),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            10),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        5),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       5),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     5),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     5),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             5),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              10),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           5),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            15),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  10),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             10),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         0),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           5),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          10),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       10),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  10),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         10),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        5),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             10),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       5),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       10),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           10),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          5),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         5),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             10),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      15),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           15),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          5),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,5),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            5),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          0),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            5),
		};

		public override string EmaciatedName => "Skeletal";
		public override string FatName => "Gangly";
		public override string FitName => "Graceful";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lanky_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lanky_Physique)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                        VanillaTraits.Diminutive,
                        nameof(Average_Physique),
						nameof(Huge_Physique),
						nameof(Massive_Physique),
						nameof(Short_Physique),
						nameof(Stout_Physique),
						nameof(Tall_Physique),
						nameof(Thin_Physique),
						nameof(Tiny_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = 3,
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
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}