

using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Body
{
	public class Massive_Physique : T_Physique
	{
		//  IModBodySize
		public override float HeightRatio => 1.33f;
		public override float WidthRatio => 1.33f;

		//  IModHealth
		public override int HealthPerEnduranceBonus => 10;

		//  IModSkills
		public override List<KeyValuePair<string, int>> SkillBonuses => new List<KeyValuePair<string, int>>
		{
			new KeyValuePair<string, int>(VLuckType_Skills.CriticalHit, -6),
			new KeyValuePair<string, int>(VLuckType_Skills.Dodge, -20),
			new KeyValuePair<string, int>(VLuckType_Skills.Explosives, -20),
			new KeyValuePair<string, int>(VLuckType_Skills.Electronics, -20),
			new KeyValuePair<string, int>(VLuckType_Skills.Intimidation, 20),
			new KeyValuePair<string, int>(VLuckType_Skills.Persuasion, 20),
			new KeyValuePair<string, int>(VLuckType_Skills.LightTouch, -20),
		};

		//  IModMeleeAtack
		public override float MeleeDamage => 1.50f;
		public override float MeleeKnockback => 1.50f;
		public override float MeleeLunge => 1.50f;
		public override float MeleeSpeed => 0.75f;
		public override bool? SetMobility() => false;

		//  IModMoveSpeed
		public override float Acceleration => 0.75f;
		public override float MoveSpeedMax => 0.75f;

		//  IModOperatingActions
		public override float OperatingTime => 2.00f;

		//  IModResistances
		public override float ResistKnockback => 1.25f;
		public override float ResistMelee => 1.25f;
		public override float ResistPoison => 2.00f;

		//  IModStatScariness
		public override float ScarinessAdded => 2.00f;

		//  IModTransactionCost
		public override List<KeyValuePair<string, float>> CostBonusesAsNPC => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.GangbangerHire, 3.00f),
			new KeyValuePair<string, float>(VTransactionType.HackerAssist, 0.50f),
			new KeyValuePair<string, float>(VTransactionType.ThiefAssist, 0.50f),
		};
		public override List<KeyValuePair<string, float>> CostBonusesAsPlayer => new List<KeyValuePair<string, float>>
		{
			new KeyValuePair<string, float>(VTransactionType.AugmentationBooth, 2.00f),
			new KeyValuePair<string, float>(VTransactionType.CloneMachineAgent, 2.00f),
			new KeyValuePair<string, float>(VTransactionType.Heal, 2.00f),
		};

		//  Demographic
		public override List<KeyValuePair<string, int>> VanillaAgentSpawnChance => new List<KeyValuePair<string, int>>()
		{
        // Base value is 0%
            new KeyValuePair<string, int> (VanillaAgents.Alien,             0),
			new KeyValuePair<string, int> (VanillaAgents.Assassin,          0),
			new KeyValuePair<string, int> (VanillaAgents.Athlete,           0),
			new KeyValuePair<string, int> (VanillaAgents.Bartender,         0),
			new KeyValuePair<string, int> (VanillaAgents.Bouncer,           0),
			new KeyValuePair<string, int> (VanillaAgents.Cannibal,          1),
			new KeyValuePair<string, int> (VanillaAgents.Clerk,             0),
			new KeyValuePair<string, int> (VanillaAgents.Comedian,          0),
			new KeyValuePair<string, int> (VanillaAgents.Cop,               0),
			new KeyValuePair<string, int> (VanillaAgents.Courier,           0),
			new KeyValuePair<string, int> (VanillaAgents.Demolitionist,     0),
			new KeyValuePair<string, int> (VanillaAgents.Doctor,            0),
			new KeyValuePair<string, int> (VanillaAgents.DrugDealer,        0),
			new KeyValuePair<string, int> (VanillaAgents.Firefighter,       0),
			new KeyValuePair<string, int> (VanillaAgents.GangsterBlahd,     0),
			new KeyValuePair<string, int> (VanillaAgents.GangsterCrepe,     0),
			new KeyValuePair<string, int> (VanillaAgents.Ghost,             0),
			new KeyValuePair<string, int> (VanillaAgents.Goon,              0),
			new KeyValuePair<string, int> (VanillaAgents.Gorilla,           5),
			new KeyValuePair<string, int> (VanillaAgents.Hacker,            0),
			new KeyValuePair<string, int> (VanillaAgents.InvestmentBanker,  0),
			new KeyValuePair<string, int> (VanillaAgents.Mayor,             0),
			new KeyValuePair<string, int> (VanillaAgents.MechPilot,         0),
			new KeyValuePair<string, int> (VanillaAgents.Mobster,           0),
			new KeyValuePair<string, int> (VanillaAgents.Musician,          0),
			new KeyValuePair<string, int> (VanillaAgents.OfficeDrone,       0),
			new KeyValuePair<string, int> (VanillaAgents.ResistanceLeader,  0),
			new KeyValuePair<string, int> (VanillaAgents.Scientist,         0),
			new KeyValuePair<string, int> (VanillaAgents.ShapeShifter,      0),
			new KeyValuePair<string, int> (VanillaAgents.Shopkeeper,        0),
			new KeyValuePair<string, int> (VanillaAgents.Slave,             0),
			new KeyValuePair<string, int> (VanillaAgents.Slavemaster,       0),
			new KeyValuePair<string, int> (VanillaAgents.SlumDweller,       0),
			new KeyValuePair<string, int> (VanillaAgents.Soldier,           0),
			new KeyValuePair<string, int> (VanillaAgents.SuperCop,          0),
			new KeyValuePair<string, int> (VanillaAgents.Supergoon,         0),
			new KeyValuePair<string, int> (VanillaAgents.Thief,             0),
			new KeyValuePair<string, int> (VanillaAgents.UpperCruster,      0),
			new KeyValuePair<string, int> (VanillaAgents.Vampire,           0),
			new KeyValuePair<string, int> (VanillaAgents.Werewolf,          0),
			new KeyValuePair<string, int> (VanillaAgents.WerewolfTransformed,1),
			new KeyValuePair<string, int> (VanillaAgents.Worker,            0),
			new KeyValuePair<string, int> (VanillaAgents.Wrestler,          0),
			new KeyValuePair<string, int> (VanillaAgents.Zombie,            5),
		};

		public override string EmaciatedName => "Massive";
		public override string FatName => "Massive";
		public override string FitName => "Massive";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Massive_Physique>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = $"",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Massive_Physique)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                        VanillaTraits.Diminutive,
                        nameof(Average_Physique),
						nameof(Huge_Physique),
						nameof(Lanky_Physique),
						nameof(Short_Physique),
						nameof(Stout_Physique),
						nameof(Tall_Physique),
						nameof(Thin_Physique),
						nameof(Tiny_Physique),
						nameof(Wide_Physique),
					},
					CharacterCreationCost = 48,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 100,
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