using BepInEx.Logging;
using Google2u;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ResistanceHR.Tampering
{
	internal abstract class T_Tampering : T_RHR
	{
		public override void OnAdded() { }
		public override void OnRemoved() { }
		public abstract float ToolCostFactor { get; }

		public static int ApplyToolCostModifiers(Agent agent, int baseCost)
		{
			float? costFactor = agent.GetTraits<T_Tampering>().FirstOrDefault()?.ToolCostFactor ?? null;

			if (!(costFactor is null))
				return Mathf.FloorToInt((float)(baseCost * costFactor));
			else
				return baseCost;
		}

		public static void AgentInteractions_AddButton_Prefix(string buttonName, ref string extraCost, Agent mostRecentInteractingAgent)
		{
			if ((WrenchTamperButtonNames.Contains(buttonName)
					|| CrowbarTamperButtonNames.Contains(buttonName)
					|| WireCutterTamperButtonNames.Contains(buttonName))//etc
				&& extraCost.EndsWith("-30"))
			{
				int baseCost = 30;

				T_Tampering trait = mostRecentInteractingAgent.GetTraits<T_Tampering>().FirstOrDefault();

				if (!(trait is null))
					baseCost = (int)(baseCost * trait.ToolCostFactor);

				extraCost = extraCost.Substring(0, extraCost.Length - 2) + baseCost.ToString();
			}
		}

		internal static readonly List<string> AxeTamperButtonNames = new List<string>()
		{
			// Weak walls: Wood, Hedge
		};
		internal static readonly List<string> CrowbarTamperButtonNames = new List<string>()
		{
			nameof(InterfaceNameDB.rowIds.UseCrowbar),
		};
		internal static readonly List<string> DrillTamperButtonNames = new List<string>()
		{
			// Drill holes to drain oil (Generators, NOT stove)

		};
		internal static readonly List<string> PowerSawTamperButtonNames = new List<string>()
		{
			// Weak walls: Wood, Hedge
			// Wooden doors
		};
		internal static readonly List<string> SledgehammerTamperButtonNames = new List<string>()
		{
			// Weak walls: Most
			// Metal doors
		};
		internal static readonly List<string> WireCutterTamperButtonNames = new List<string>()
		{
			// Security Cam
			// Barbed Wire
		};
		internal static readonly List<string> WrenchTamperButtonNames = new List<string>()
		{
			nameof(InterfaceNameDB.rowIds.RemoveHelmetWrench),
			nameof(InterfaceNameDB.rowIds.UseWrenchToAdjustSatellite),
			nameof(InterfaceNameDB.rowIds.UseWrenchToDeactivate),
			nameof(InterfaceNameDB.rowIds.UseWrenchToDetonate),
		};
	}

	[HarmonyPatch(typeof(AgentInteractions))]
	internal class P_AgentInteractions_Tampering
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(methodName: nameof(AgentInteractions.AddButton), argumentTypes: new[] { typeof(string), typeof(int), typeof(string) })]
		private static void AddButton_Prefix(string buttonName, int moneyCost, ref string extraCost, Agent ___mostRecentInteractingAgent)
		{
			T_Tampering.AgentInteractions_AddButton_Prefix(buttonName, ref extraCost, ___mostRecentInteractingAgent);
		}
	}


	[HarmonyPatch(declaringType: typeof(InvDatabase))]
	class P_InvDatabase
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.SubtractFromItemCount), new[] { typeof(int), typeof(int), typeof(bool) })]
		public static bool SubtractFromItemCount_c_Prefix(int slotNum, ref int amount, bool toolbarMove, InvDatabase __instance)
		{
			logger.LogDebug("InvDatabase_SubtractFromItemCount_c:");
			logger.LogDebug("\tslotNum = " + slotNum);
			logger.LogDebug("\tamount = " + amount);
			logger.LogDebug("\ttoolbarMove = " + toolbarMove);

			if (VItem.tools.Contains(__instance.InvItemList[slotNum].invItemName))
			{
				T_Tampering trait = __instance.agent.GetTraits<T_Tampering>().FirstOrDefault();

				if (!(trait is null))
					amount = (int)(amount * trait.ToolCostFactor);
			}

			return true;
		}

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.SubtractFromItemCount), new[] { typeof(InvItem), typeof(int), typeof(bool) })]
		public static bool SubtractFromItemCount_d_Prefix(InvItem invItem, ref int amount, bool toolbarMove, InvDatabase __instance)
		{
			logger.LogDebug("InvDatabase_SubtractFromItemCount_d:");
			logger.LogDebug("\tInvItem = " + invItem.invItemName);
			logger.LogDebug("\tamount = " + amount);
			logger.LogDebug("\ttoolbarMove = " + toolbarMove);

			if (VItem.tools.Contains(invItem.invItemName))
			{
				T_Tampering trait = __instance.agent.GetTraits<T_Tampering>().FirstOrDefault();

				if (!(trait is null))
					amount = (int)(amount * trait.ToolCostFactor);
			}

			return true;
		}
	}
}