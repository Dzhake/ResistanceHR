using BepInEx.Logging;
using BTHarmonyUtils;
using BTHarmonyUtils.TranspilerUtils;
using BunnyLibs;

using HarmonyLib;
using JetBrains.Annotations;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace RHR.Body
{
	public abstract class T_Physique : T_RHR,
		IModBodySize, IModHealthPerEndurance, IModMeleeAttack, IModMovement, IModOperatingActions, IModResistances, IModSkills, IModStatScariness, IModTransactionCosts
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		#region Interfaces
		//	IModBodySize
		public abstract float HeightRatio { get; }
		public abstract float WidthRatio { get; }

		//	IModHealth
		public abstract int HealthPerEnduranceBonus { get; }

		//	IModSkills
		public abstract List<KeyValuePair<string, int>> SkillBonuses { get; }

		//	IModMeleeAttack
		public bool ApplyModMeleeAttack() => true;
		public bool CanHitGhost() => false;
		public abstract float MeleeDamage { get; }
		public abstract float MeleeKnockback { get; }
		public abstract float MeleeLunge { get; }
		public abstract float MeleeSpeed { get; }
		public virtual bool? SetMobility() => null;
		public void OnStrike(PlayfieldObject target) { }

		//	IModMoveSpeed
		public abstract float Acceleration { get; }
		public abstract float MoveSpeedMax { get; }
		public float MoveVolume => 1.00f; 

		//	IModOperatingActions
		public int NetToolCost(InvItem tool, int vanillaCost) => vanillaCost;
		public abstract float OperatingTime { get; }
		public float OperatingVolume { get; }

		//	IModResistances
		public float ResistBullets => 1.00f;
		public float ResistExplosion => 1.00f;
		public float ResistFire => 1.00f;
		public abstract float ResistKnockback { get; }
		public abstract float ResistMelee { get; }
		public abstract float ResistPoison { get; }

		//	IModStatScariness
		public abstract float ScarinessAdded { get; }

		//	IModTransactionCosts
		public abstract List<KeyValuePair<string, float>> CostBonusesAsPlayer { get; }
		public abstract List<KeyValuePair<string, float>> CostBonusesAsNPC { get; }
		#endregion

		public abstract string EmaciatedName { get; }
		public abstract string FatName { get; }
		public abstract string FitName { get; }

		//	TODO: IApplyVanillaDemographic
		public abstract List<KeyValuePair<string, int>> VanillaAgentSpawnChance { get; }

		public static List<Type> derivedTypes = Assembly.GetExecutingAssembly().GetTypes()
			.Where(type => 
				type.IsSubclassOf(typeof(T_Physique)) 
				&& !type.IsAbstract
				&& type != typeof(Test_Physique))
			.ToList();
		public static readonly List<T_Physique> randomPool = derivedTypes.Select(dt => (T_Physique)Activator.CreateInstance(dt)).ToList();

		public static readonly List<string> AgentNameExclusions = new List<string>()
		{
			VanillaAgents.CustomCharacter,
			VanillaAgents.MechEmpty,
			VanillaAgents.MechFilled,
			VanillaAgents.ShapeShifter,
			"Playerr", // Debug string
		};

		#region TODO: move to ISetupAgentStats Mutator after testing
		// TODO: Restore hardcode since you rightly removed the IRefreshAgents/StartOfLevel from the trait interfaces
		public void Refresh(Agent agent)
		{
			logger.LogDebug($"{TextName}.Refresh: SET ENDURANCE FOR PHYSIQUE");

			agent.SetEndurance(agent.enduranceStatMod);

			if (GC.sessionDataBig.curLevelEndless == 1)
				agent.health = agent.healthMax;

			agent.SetSpeed(agent.speedStatMod); // Test
		}
		#endregion

		

	}
}