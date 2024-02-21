

using RogueLibsCore;
using System;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Test_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 0.67f;
		public override float WidthRatio => 0.67f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 10;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, 50),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, 50),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, 25),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, 25),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 25),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 50),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, 25),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 3f;
		public override float MeleeKnockback => 3f;
		public override float MeleeLunge => 3f;
		public override float MeleeSpeed => 3f;
		public override bool? SetMobility() => true;

		//  IModMoveSpeed
		public override float Acceleration => 3f;
		public override float MoveSpeedMax => 3f;

		//  IModOperatingActions
		public override float OperatingTime => 0.1f;

		//  IModResistances
		public override float ResistKnockback => 3f;
		public override float ResistMelee => 3f;
		public override float ResistPoison => 3f;

		//  IModStatScariness
		public override float ScarinessAdded => 3f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{

			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 3f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 3f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 3f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 3f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 3f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 3f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
        // base value is 10%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             40),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          40),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           40),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         40),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           40),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          40),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             40),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          40),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               40),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           40),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     40),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            40),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        40),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       40),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     40),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     40),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             40),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              40),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           40),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            40),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  40),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             40),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         40),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           40),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          40),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       40),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  40),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         40),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      40),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        40),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             40),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       40),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       40),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           40),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          40),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         40),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             40),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      40),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           40),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          40),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,40),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            40),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          40),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            40),
		};

		public override string EmaciatedName => "Test";
		public override string FatName => "Test";
		public override string FitName => "Test";

		[RLSetup]
		public static void Setup()
		{
			if (!Core.debugMode)
				return;

			RogueLibs.CreateCustomTrait<Test_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Test_Physique)),
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
						},
						isUpgrade = false,
						upgrade = null,
					}
				});
		}

		

	}
}