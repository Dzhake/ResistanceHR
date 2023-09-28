using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using Pathfinding;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace ResistanceHR.Conduct
{
	internal class Pyrokinetic_Learning_Style : T_XPModifier
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal static List<string> IgniteableObjects => new List<string>()
		{
			VanillaObjects.Altar,
			VanillaObjects.Bed,
			VanillaObjects.Bush,
			VanillaObjects.Chair,
			VanillaObjects.Chair2,
			VanillaObjects.Crate,
			VanillaObjects.Desk,
			VanillaObjects.ExplodingBarrel,
			VanillaObjects.PoolTable,
			"Shelf",
			"Sign",
			"Table",
			"TableBig",
			"TrashCan",
			"VendorCart",
			"WasteBasket",
		};
		internal static List<string> SpecialFireParticleObjects => new List<string>()
		{
			VanillaObjects.Barbecue,
			VanillaObjects.Fireplace,
			VanillaObjects.FlamingBarrel,
		};

		internal const string
			Ignite = "Ignite",
			WatchBurn = "WatchBurn",

			z = "";

		[RLSetup]
		internal static void Setup()
		{
			//	South-facing bookshelves don't ignite wall
			RogueLibs.CreateCustomTrait<Pyrokinetic_Learning_Style>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Enables XP penalties for destroying objects with fire.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Pyrokinetic_Learning_Style)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
                    },
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						cantLose = true,
						cantSwap = true,
						categories = { },
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});

			RogueLibs.CreateCustomName(WatchBurn, VNameType.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "BUUURN!!!",
			});
			RogueLibs.CreateCustomName(Ignite, VNameType.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Ignite",
			});

			RogueInteractions.CreateProvider<ObjectReal>(h => // testing Type argument
			{
				if (/*!(h.Object is ObjectReal)
					||*/ h.Agent is null)
					return;

				InvItem cigaretteLighter = h.Agent.inventory.FindItem(VanillaItems.CigaretteLighter);

				if (cigaretteLighter is null
						|| h.Helper.interactingFar
						|| h.Object.playfieldObjectReal.fireProof || !(h.Object.fire is null) || !IgniteableObjects.Contains(h.Object.objectName)
						|| (SpecialFireParticleObjects.Contains(h.Object.objectName) && h.Object.ora.hasParticleEffect)) // These aren't implemented here
					return;

				h.AddButton(Ignite, m =>
				{
					if (!m.Agent.statusEffects.hasTrait(VanillaTraits.SneakyFingers))
					{
						GC.spawnerMain.SpawnNoise(m.Object.tr.position, 1f, m.Agent, null, m.Agent);
						GC.OwnCheck(m.Agent, m.Object.go, "Fire", 3);
					}

					GC.audioHandler.Play(m.Object, VanillaAudio.UseCigaretteLighter);
					Fire fire = GC.spawnerMain.SpawnFire(m.Agent, m.Object.gameObject);
					Danger danger = GC.spawnerMain.SpawnDanger(fire, "Major", "Normal");
					fire.pathingHelper.gameObject.SetActive(true);
					fire.pathingHelper.GetComponent<GraphUpdateScene>().setTag = 1;
					fire.pathingHelper.go.layer = 21;
					fire.pathingHelper.GetComponent<GraphUpdateScene>().Apply();

					foreach (Agent agent in GC.agentList)
					{
						if (agent.pathing == 1)
							agent.pathfindingAI.rePath = true;
					}

					m.StopInteraction();
				});
			}); 
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}

	[HarmonyPatch(typeof(Fire))]
	internal static class P_Fire_PyrokineticLearner
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTranspiler, HarmonyPatch(nameof(Fire.DestroyMe))]
		private static IEnumerable<CodeInstruction> AddFirebugXP(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			MethodInfo customMethod = AccessTools.DeclaredMethod(typeof(P_Fire_PyrokineticLearner), nameof(P_Fire_PyrokineticLearner.FirebugXP));
			FieldInfo objectAgent = AccessTools.DeclaredField(typeof(ObjectReal), nameof(ObjectReal.objectAgent));
			FieldInfo onFireServer = AccessTools.DeclaredField(typeof(Agent), nameof(Agent.onFireServer));
			FieldInfo puttingOutFire = AccessTools.DeclaredField(typeof(Fire), nameof(Fire.puttingOutFire));
			MethodInfo setOnFire = AccessTools.Method(typeof(ObjectMultObject), "set_onFire");
			FieldInfo ora = AccessTools.DeclaredField(typeof(PlayfieldObject), nameof(PlayfieldObject.ora));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 5),
					new CodeInstruction(OpCodes.Ldfld, ora),
					new CodeInstruction(OpCodes.Ldc_I4_0),
					new CodeInstruction(OpCodes.Callvirt, setOnFire)
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldloc_S, 5),
					new CodeInstruction(OpCodes.Ldfld, objectAgent),
					new CodeInstruction(OpCodes.Call, customMethod),
				},
				postfixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldarg_0),
					new CodeInstruction(OpCodes.Ldfld, puttingOutFire),
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		private static void FirebugXP(Agent agent)
		{
			logger.LogDebug("FirebugXP");
			if (agent is null || !agent.HasTrait<Pyrokinetic_Learning_Style>())
				return;
			
			agent.skillPoints.AddPoints(Pyrokinetic_Learning_Style.WatchBurn);
		}
	}
}