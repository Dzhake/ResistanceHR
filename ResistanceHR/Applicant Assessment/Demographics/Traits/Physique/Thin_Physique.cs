using BunnyLibs;


using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Thin_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 0.90f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => -1;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, 1),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, 2),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, -5),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, 5),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 0.85f;
		public override float MeleeKnockback => 0.90f;
		public override float MeleeLunge => 1.00f;
		public override float MeleeSpeed => 1.00f;

		//  IModMoveSpeed
		public override float Acceleration => 1.05f;
		public override float MoveSpeedMax => 1.00f;

		//  IModOperatingActions
		public override float OperatingTime => 0.90f;

		//  IModResistances
		public override float ResistKnockback => 0.90f;
		public override float ResistMelee => 0.90f;
		public override float ResistPoison => 0.90f;

		//  IModStatScariness
		public override float ScarinessAdded => -0.50f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{

			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 0.90f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 1.10f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 1.10f),
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
        // base value is 10%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             25),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          20),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           20),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         10),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           5),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          15),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             10),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          20),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               0),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           15),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     10),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            10),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        10),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       5),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     10),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     10),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             10),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              10),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           0),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            20),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  15),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             5),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         15),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           5),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          15),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       5),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  10),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         20),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        10),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             25),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       5),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       25),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           5),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          5),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         5),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             20),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      15),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           20),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          5),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,5),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            5),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          0),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            10),
		};

		public override string EmaciatedName => "Skeletal";
		public override string FatName => "Skinnyfat";
		public override string FitName => "Lithe";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Thin_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Thin_Physique)),
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
						nameof(Tiny_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = -2,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {
							VTraitCategory.Guns,
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}