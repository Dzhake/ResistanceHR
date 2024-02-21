using BunnyLibs;


using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Tall_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.10f;
		public override float WidthRatio => 1.00f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 1;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, -1),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 10),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, 0),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 1.05f;
		public override float MeleeKnockback => 1.05f;
		public override float MeleeLunge => 1.10f;
		public override float MeleeSpeed => 1.00f;

		//  IModMoveSpeed
		public override float Acceleration => 1.05f;
		public override float MoveSpeedMax => 1.05f;

		//  IModOperatingActions
		public override float OperatingTime => 1.00f;

		//  IModResistances
		public override float ResistKnockback => 1.00f;
		public override float ResistMelee => 1.00f;
		public override float ResistPoison => 1.00f;

		//  IModStatScariness
		public override float ScarinessAdded => 0.25f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 1.15f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 1.00f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 1.00f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 1.00f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
        // base value is 10%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             0),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          5),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           20),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         10),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           20),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          10),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             10),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          20),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               5),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           10),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     10),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            15),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        5),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       15),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     5),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     5),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             10),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              20),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           20),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            10),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  15),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             20),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         10),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           5),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          10),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       10),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  15),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         10),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        10),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             10),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       15),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       5),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           20),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          20),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         20),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             5),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      20),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           10),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          15),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,15),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            15),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          20),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            10),
		};

		public override string EmaciatedName => "Bony";
		public override string FatName => "Burly";
		public override string FitName => "Athletic";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Tall_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Tall_Physique)),
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
						nameof(Thin_Physique),
						nameof(Tiny_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = 2,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = {
							VTraitCategory.Social,
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}