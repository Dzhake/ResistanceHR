using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Tampering
{
	public abstract class T_ToolCost : T_RHR
	{
		public abstract int NewToolCost(int vanilla);

		public static int ApplyToolCostModifiers(Agent agent, int baseCost)
		{
			T_ToolCost trait = agent.GetTraits<T_ToolCost>().FirstOrDefault();

			if (!(trait is null))
				return trait.NewToolCost(baseCost);
			else
				return baseCost;
		}
	}

	[HarmonyPatch(typeof(AgentInteractions))]
	public class P_AgentInteractions_Tampering
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyBefore(RogueLibs.GUID)]
		[HarmonyPrefix, HarmonyPatch(nameof(AgentInteractions.AddButton), new[] { typeof(string), typeof(int), typeof(string) })]
		private static void AddButton_Prefix(string buttonName, int moneyCost, ref string extraCost, Agent ___mostRecentInteractingAgent)
		{
			if (Tampering.AllTamperButtonNames.Contains(buttonName)
				&& extraCost.EndsWith("-30"))
			{
				int baseCost = 30;
				T_ToolCost trait = ___mostRecentInteractingAgent.GetTraits<T_ToolCost>().FirstOrDefault();

				if (!(trait is null))
					baseCost = trait.NewToolCost(baseCost);

				extraCost = extraCost.Substring(0, extraCost.Length - 2) + baseCost.ToString();
			}
		}
	}

	[HarmonyPatch(typeof(InvDatabase))]
	class P_InvDatabase
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		public static GameController GC => GameController.gameController;

		public static List<string> tools = new List<string>()
		{
			VItemName.Crowbar,
			VItemName.Wrench,
		};

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.SubtractFromItemCount), new[] { typeof(int), typeof(int), typeof(bool) })]
		public static bool SubtractFromItemCount_c_Prefix(int slotNum, ref int amount, InvDatabase __instance)
		{
			if (tools.Contains(__instance.InvItemList[slotNum].invItemName))
			{
				T_ToolCost trait = __instance.agent.GetTraits<T_ToolCost>().FirstOrDefault();

				if (!(trait is null))
					amount = trait.NewToolCost(amount);
			}

			return true;
		}

		[HarmonyPrefix, HarmonyPatch(nameof(InvDatabase.SubtractFromItemCount), new[] { typeof(InvItem), typeof(int), typeof(bool) })]
		public static bool SubtractFromItemCount_d_Prefix(InvItem invItem, ref int amount, InvDatabase __instance)
		{
			if (tools.Contains(invItem.invItemName))
			{
				T_ToolCost trait = __instance.agent.GetTraits<T_ToolCost>().FirstOrDefault();

				if (!(trait is null))
					amount = trait.NewToolCost(amount);
			}

			return true;
		}
	}
}