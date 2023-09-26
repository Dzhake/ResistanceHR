using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using UnityEngine;

namespace ResistanceHR.Tampering
{
	internal class Stove_GrillFud : O_TamperObject
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal override List<string> ObjectTypes => new List<string>() { "Stove" };
		internal override List<string> UsableItems => new List<string>() { VanillaItems.Fud };

		[RLSetup]
		internal static void Setup()
		{
			SetupNames();

			RogueInteractions.CreateProvider<Stove>(h =>
			{
				InvItem rawFud = h.Object.interactingAgent.inventory.FindItem(VanillaItems.Fud);
				Agent interactingAgent = h.Object.interactingAgent;

				if (!(rawFud is null) && h.Object.functional)
					h.AddButton(GrillFud, m =>
					{
						if (!m.Agent.statusEffects.hasTrait(VanillaTraits.SneakyFingers))
						{
							GC.audioHandler.Play(m.Object, VanillaAudio.GrillOperate);
							GC.spawnerMain.SpawnNoise(m.Object.tr.position, 2f, m.Agent, "Normal", m.Agent);
							GC.OwnCheck(m.Agent, m.Object.go, "Normal", 1);
						}

						m.Object.StartCoroutine(m.Object.Operating(interactingAgent, interactingAgent.inventory.FindItem(VanillaItems.Fud), 2f, true, GrillingFud));
						m.Object.StopInteraction();
					});
			});
		}

		internal static void FinishedOperating(Stove stove)
		{
			Agent interactingAgent = stove.interactingAgent;
			InvItem rawFud = stove.interactingAgent.inventory.FindItem(VanillaItems.Fud);
			int numCooked = Mathf.Min(5, rawFud.invItemCount);
			rawFud.invItemCount -= numCooked;

			if (rawFud.invItemCount <= 0)
				interactingAgent.inventory.DestroyItem(rawFud);

			InvItem hotFud = new InvItem();
			hotFud.invItemName = VanillaItems.HotFud;
			hotFud.SetupDetails(false);
			hotFud.invItemCount = numCooked;
			interactingAgent.inventory.AddItemOrDrop(hotFud);
			hotFud.ShowPickingUpText(interactingAgent);
			stove.MakeNonFunctional(interactingAgent);
			GC.audioHandler.StopOnClients(stove, VanillaAudio.GrillOperate);
		}

		public const string
			GrillFud = "GrillFud",
			GrillingFud = "GrillingFud";

		internal static void SetupNames()
		{
			RogueLibs.CreateCustomName(GrillFud, VNameType.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Grill Fud",
			});
			RogueLibs.CreateCustomName(GrillingFud, VNameType.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Grilling",
			});
		}
	}

	[HarmonyPatch(typeof(Stove))]
	internal static class P_Stove_GrillFud
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(Stove.SetVars))]
		internal static void SetVars(Stove __instance)
		{
			__instance.functional = true;
		}
	}
}