using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using Pathfinding;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Tampering
{
	public class Spark_of_Insight : T_Tampering
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spark_of_Insight>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You have an uncanny sense for, uh... setting things on fire with a lighter.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spark_of_Insight)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { },
						cancellations = { },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Spark_of_Insight_Plus),
					}
				});


			RogueLibs.CreateCustomName(Ignite, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Ignite",
			});

			RogueInteractions.CreateProvider(h =>
			{
				if (!(h.Object is ObjectReal)
					|| h.Agent is null)
					return;

				InvItem cigaretteLighter = h.Agent.inventory.FindItem(VanillaItems.CigaretteLighter);
				InvItem oilContainer = h.Agent.agentInvDatabase.FindItem(VanillaItems.OilContainer);

				if (cigaretteLighter is null
						|| (!h.Agent.HasTrait<Spark_of_Insight>() && !h.Agent.HasTrait<Spark_of_Insight_Plus>())
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

					if (m.Agent.HasTrait<Spark_of_Insight_Plus>() && !(oilContainer is null))
					{
						m.Agent.agentInvDatabase.SubtractFromItemCount(oilContainer.slotNum, 5);
						fire.timesDamaged = -5;
						fire.timeLeft = 5f;
						fire.generation = -2;
					}

					m.StopInteraction();
				});
			});
		}

		public const string
			Ignite = "Ignite",

			z = "";

		public static List<string> IgniteableObjects => new List<string>()
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
		public static List<string> SpecialFireParticleObjects => new List<string>()
		{
			VanillaObjects.Barbecue,
			VanillaObjects.Fireplace,
			VanillaObjects.FlamingBarrel,
		};

		

	}

	[HarmonyPatch(typeof(Fire))]
	public static class P_Fire_SparkOfInsight
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		// TimesDamaged cap to destroy fire in Fire.AddTimesDamaged (Transpiler)
		// TimeLeft <= 5f cross-object spread time threshold in Fire.UpdateFire (Transpiler)
		// Generation cap < 6 in Fire.UpdateFire (Transpiler)
	}
}