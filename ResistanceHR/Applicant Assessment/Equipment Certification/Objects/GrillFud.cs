using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace RHR.Tampering
{
	public class GrillFud : O_TamperObject
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public override List<string> ObjectTypes => new List<string>() { /*VanillaObjects.FlamingBarrel,*/ "Stove" };
		public override List<string> UsableItems => new List<string>() { VanillaItems.Fud };

		/*	This was in BM : 
		 *	
				public static void FlamingBarrel_SetVars(FlamingBarrel __instance) // Postfix
				{
					__instance.interactable = true;
					__instance.fireDoesntDamage = true;
				}
			I think we can skip interactable, but test if fire damages it.
		*/


		[RLSetup]
		public static void Setup()
		{
			SetupNames();

			RogueInteractions.CreateProvider(h =>
			{
				InvItem rawFud = h.Object.interactingAgent.inventory.FindItem(VanillaItems.Fud);
				Agent agent = h.Object.interactingAgent;

				if (rawFud is null
					|| !h.Object.functional
					|| (!(h.Object is Stove))) // && !(h.Object is FlamingBarrel)))
				return;

				int fireDamage = Damage.HealthCost(h.Agent, 10, DamageType.burnedFingers);

				if (h.Object.playfieldObjectReal is Stove
					|| (h.Object.playfieldObjectReal is FlamingBarrel && fireDamage == 0))
				{
					h.AddButton(GrillFudAction, m =>
					{
						if (!m.Agent.statusEffects.hasTrait(VanillaTraits.SneakyFingers))
						{
							GC.audioHandler.Play(m.Object, VanillaAudio.GrillOperate);
							GC.spawnerMain.SpawnNoise(m.Object.tr.position, 1f, m.Agent, "Normal", m.Agent);
							//GC.OwnCheck(m.Agent, m.Object.go, "Normal", 1);
						}

						m.Object.StartCoroutine(m.Object.Operating(agent, agent.inventory.FindItem(VanillaItems.Fud), 2f, true, GrillingFud));
						//m.Object.StopInteraction();
					});
				}
				else if (h.Object.playfieldObjectReal is FlamingBarrel)
				{
					h.AddButton(GrillFudAction, $" (- {fireDamage} HP)", m =>
					{
						if (!m.Agent.statusEffects.hasTrait(VanillaTraits.SneakyFingers))
						{
							GC.audioHandler.Play(m.Object, VanillaAudio.GrillOperate);
							GC.spawnerMain.SpawnNoise(m.Object.tr.position, 1f, m.Agent, "Normal", m.Agent);
							//GC.OwnCheck(m.Agent, m.Object.go, "Normal", 1);
						}
						
						m.Object.StartCoroutine(m.Object.Operating(agent, agent.inventory.FindItem(VanillaItems.Fud), 2f, true, GrillingFud));
						//m.Object.StopInteraction();
					});
				}
			});
		}

		public static void FinishedOperating(ObjectReal objectReal)
		{
			Agent agent = objectReal.interactingAgent;
			InvItem rawFud = agent.inventory.FindItem(VanillaItems.Fud);
			int numCooked = Mathf.Min(5, rawFud.invItemCount);
			rawFud.invItemCount -= numCooked;

			if (rawFud.invItemCount <= 0)
				agent.inventory.DestroyItem(rawFud);

			InvItem hotFud = new InvItem();
			hotFud.invItemName = VanillaItems.HotFud;
			hotFud.SetupDetails(false);
			hotFud.invItemCount = numCooked;
			agent.inventory.AddItemOrDrop(hotFud);
			hotFud.ShowPickingUpText(agent);

			if (objectReal is FlamingBarrel flamingBarrel)
			{
				if (Damage.FireDamageMultiplier(agent) != 1.0f)
				{
					GC.audioHandler.Play(flamingBarrel, VanillaAudio.WaterBlastFire);
				}
				else
				{
					agent.statusEffects.ChangeHealth(Damage.HealthCost(agent, 10, DamageType.burnedFingers), flamingBarrel);
					GC.audioHandler.Play(flamingBarrel, VanillaAudio.FireHit);
				}

			}
			else if (objectReal is Stove stove)
			{
				stove.MakeNonFunctional(agent);
			}
			agent.StopInteraction();
			objectReal.StopInteraction();
			GC.audioHandler.StopOnClients(objectReal, VanillaAudio.GrillOperate);
		}

		public const string
			GrillFudAction = "GrillFudAction",
			GrillingFud = "GrillingFud";

		public static void SetupNames()
		{
			RogueLibs.CreateCustomName(GrillFudAction, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Grill Fud",
			});
			RogueLibs.CreateCustomName(GrillingFud, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Grilling",
			});
		}
	}

	[HarmonyPatch(typeof(Stove))]
	public static class P_Stove_GrillFud
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Stove.SetVars))]
		public static void SetVars(Stove __instance)
		{
			__instance.functional = true;
		}
	}
}