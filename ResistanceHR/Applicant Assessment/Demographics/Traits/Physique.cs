using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using BunnyLibs;
using HarmonyLib;
using RHR.Body;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

public static class Physique
{
	private static readonly ManualLogSource logger = BLLogger.GetLogger();
	private static GameController GC => GameController.gameController;

	static readonly List<string> FatNames = new List<string>() { };
	static readonly List<string> EmaciatedNames = new List<string>() { };
	static readonly List<string> FitNames = new List<string>(){  };

	public static void NameAgent(ref Agent agent)
	{
		T_Physique physique = agent.GetTraits<T_Physique>().FirstOrDefault();

		if (agent.agentName == VanillaAgents.CustomCharacter || physique is null || physique is Average_Physique)
			return;

		string descriptor = physique.TextName.Replace(" Physique", "").ToString();
		agent.agentRealName = descriptor + " " + agent.agentRealName;
	}

	public class PhysiqueHelper // : ISetupAgentStats // Deactivated for debugging
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		public static BodySizeHelper BodySizeHelper = new BodySizeHelper();
		public bool BypassUnlockChecks => true;

		public void SetupAgent(Agent agent)
		{
			// Trying to block reroll, but you might still need to redo setup.
			if (agent.GetTraits<T_Physique>().Any())
			{
				logger.LogDebug("Aborting physique setup:");
				foreach (T_Physique trait in agent.GetTraits<T_Physique>())
				{
					logger.LogDebug("    Trait: " + trait.TextName);
				}

				return;
			}

			if (T_Physique.AgentNameExclusions.Contains(agent.agentName))
				return;

			int roll = UnityEngine.Random.Range(1, 100); // inclusive, exclusive

			if (agent.isPlayer == 0)
			{
				foreach (T_Physique physique in T_Physique.randomPool)
				{
					if (physique.VanillaAgentSpawnChance.Any(kvp => kvp.Key == agent.agentName))
					{
						KeyValuePair<string, int> rollWeight = physique.VanillaAgentSpawnChance.FirstOrDefault(kvp => kvp.Key == agent.agentName);
						roll -= rollWeight.Value;
					}
					else if (!(physique is Average_Physique))
						logger.LogDebug("\tNO DEFINED CHANCE FOR " + agent.agentName + " in " + physique.TextName);

					if (roll <= 0)
					{
						agent.AddTrait(physique.GetType());
						break;
					}
				}
			}

			T_Physique finalTrait = agent.GetTrait<T_Physique>();

			if (!(finalTrait is null))
				agent.AddTrait<Average_Physique>();

			BodySizeHelper.Refresh(agent);
			NameAgent(ref agent);
		}
	}

	// TODO: Move when mutator is ready
	[HarmonyPatch(typeof(AgentInteractions))]
	static class P_AgentInteractions_Physique
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(AgentInteractions.EnslaveAgent))]
		private static void RenameEnslaved(ref Agent agent)
		{
			if (agent.agentRealName == GC.nameDB.GetName(VanillaAgents.Slave, NameTypes.Agent))
				NameAgent(ref agent);
		}

		[HarmonyPostfix, HarmonyPatch(nameof(AgentInteractions.FreeSlave))]
		private static void RenameFreed(ref Agent agent)
		{
			if (agent.agentRealName == GC.nameDB.GetName("FormerSlave", NameTypes.Agent))
				NameAgent(ref agent);
		}
	}

	// TODO: Move when mutator is ready
	[HarmonyPatch(typeof(StatusEffects))]
	static class P_StatusEffects_Physique
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(StatusEffects.Depossess))]
		private static IEnumerable<CodeInstruction> ReapplyName(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo agentRealName = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.agentRealName));
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_StatusEffects_Physique), nameof(P_StatusEffects_Physique.RenameDepossessed));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Stfld, agentRealName),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 4),	//	agent

					new CodeInstruction(OpCodes.Call, customMethod),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		private static void RenameDepossessed(Agent agent)
		{
			//if (agent.agentRealName == GC.nameDB.GetName("FormerSlave", "Agent")) // Might not be necessary
			Physique.NameAgent(ref agent);
		}

		[HarmonyPostfix, HarmonyPatch(nameof(StatusEffects.ZombieSwitch))]
		private static void CopyPhysiqueToZombie(StatusEffects __instance, ref Agent chosenAgent)
		{
			logger.LogDebug("=== Physique Zombie Switch");

			T_Physique physique = __instance.agent.GetTrait<T_Physique>();

			if (physique is null)
				return;

			chosenAgent.AddTrait(physique.GetType());
			PhysiqueHelper.BodySizeHelper.Refresh(chosenAgent);
			NameAgent(ref chosenAgent);
		}
	}

	[HarmonyPatch(typeof(SpawnerMain))]
	static class P_SpawnerMain_Physique
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		// Mostly works. Causes issues with some abnormal shooters like fire hydrants, player mech, etc.
		//[HarmonyTranspiler, HarmonyPatch(nameof(SpawnerMain.SpawnBullet), new[] { typeof(Vector3), typeof(bulletStatus), typeof(PlayfieldObject), typeof(int) })]
		private static IEnumerable<CodeInstruction> RescaleBullet(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo PlayfieldObjectType = AccessTools.DeclaredField(typeof(PlayfieldObject), nameof(PlayfieldObject.playfieldObjectType));
			MethodInfo CustomMethod = AccessTools.DeclaredMethod(typeof(P_SpawnerMain_Physique), nameof(P_SpawnerMain_Physique.BulletScaleCorrected));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: true, // Nonstandard
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
				},
				targetInstructions: new List<CodeInstruction>
				{
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_1),			//	agent
					new CodeInstruction(OpCodes.Ldloc_S, 7),
					new CodeInstruction(OpCodes.Call, CustomMethod),
					new CodeInstruction(OpCodes.Stloc_S, 7),		//	num	(Net bullet scale)
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_3),
					new CodeInstruction(OpCodes.Ldfld, PlayfieldObjectType),
					new CodeInstruction(OpCodes.Ldstr, "Item"),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		private static float BulletScaleCorrected(Agent agent, float vanilla)
		{
			if (agent is null)
				return vanilla;

			float bulletScale = 1f;

			if (agent.HasEffect(VanillaEffects.Giant))
				bulletScale = 3f;
			else if (agent.HasEffect(VanillaEffects.Shrunk))
				bulletScale = 0.333333f;
			else if (agent.HasTrait(VanillaTraits.BigBullets))
				bulletScale = 2f;

			logger.LogDebug($"Bullet Scale {agent.agentRealName}: {bulletScale}");
			return bulletScale;
		}
	}
}