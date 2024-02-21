

using RogueLibsCore;
using System;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Wide_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.00f;
		public override float WidthRatio => 1.10f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 3;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, -1),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, -5),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, -5),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 5),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 0),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, -5),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 1.15f;
		public override float MeleeKnockback => 1.10f;
		public override float MeleeLunge => 1.00f;
		public override float MeleeSpeed => 0.90f;
		public override bool? SetMobility() => null;

		//  IModMoveSpeed
		public override float Acceleration => 0.95f;
		public override float MoveSpeedMax => 1.00f;

		//  IModOperatingActions
		public override float OperatingTime => 1.05f;

		//  IModResistances
		public override float ResistKnockback => 1.10f;
		public override float ResistMelee => 1.05f;
		public override float ResistPoison => 1.00f;

		//  IModStatScariness
		public override float ScarinessAdded => 0.75f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{

			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 1.15f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 0.95f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 0.85f),
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
        // base value is 10%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             0),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          5),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           20),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         10),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           20),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          0),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             5),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          20),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               25),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           5),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     10),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            10),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        10),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       15),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     15),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     15),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             10),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              20),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           20),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            20),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  10),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             20),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         5),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           25),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          5),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       20),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  15),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         5),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        10),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             10),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       15),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       20),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           25),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          25),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         25),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             10),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      20),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           5),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          15),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,15),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            15),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          20),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            10),
		};

		public override string EmaciatedName => "Sallow";
		public override string FatName => "Portly";
		public override string FitName => "Powerful";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Wide_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Wide_Physique)),
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
						nameof(Tiny_Physique),
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