using BunnyLibs;


using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Stout_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 0.90f;
		public override float WidthRatio => 1.10f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 1;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, -1),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, -2),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, -5),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, -5),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 10),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, -5),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 1.10f;
		public override float MeleeKnockback => 1.10f;
		public override float MeleeLunge => 0.95f;
		public override float MeleeSpeed => 1.10f;

		//  IModMoveSpeed
		public override float Acceleration => 0.90f;
		public override float MoveSpeedMax => 0.90f;

		//  IModOperatingActions
		public override float OperatingTime => 1.05f;

		//  IModResistances
		public override float ResistKnockback => 1.15f;
		public override float ResistMelee => 1.10f;
		public override float ResistPoison => 1.10f;

		//  IModStatScariness
		public override float ScarinessAdded => 0.50f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{

			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 1.10f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 0.95f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 0.95f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 1.05f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 1.05f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 1.05f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
        // base value is 5%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             0),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          5),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           10),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         10),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           10),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          0),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             5),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          15),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               15),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           0),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     5),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            10),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        5),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       5),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     10),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     10),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             5),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              10),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           15),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            15),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  10),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             10),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         5),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           10),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          5),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       15),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  15),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         10),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        5),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             15),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       20),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       15),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           10),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          0),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         0),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             10),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      15),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           0),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          15),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,15),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            15),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          20),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            5),
		};

		public override string EmaciatedName => "Deflated";
		public override string FatName => "Rotund";
		public override string FitName => "Robust";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Stout_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Stout_Physique)),
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
							VTraitCategory.Defense,
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}