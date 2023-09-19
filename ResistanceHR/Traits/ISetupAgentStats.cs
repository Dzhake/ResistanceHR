using HarmonyLib;
using RogueLibsCore;

namespace ResistanceHR
{
	// TODO: Move to BunnyLibs
	public interface ISetupAgentStats
	{
		void SetupAgentStats(Agent agent);
	}

	[HarmonyPatch(typeof(Agent))]
	internal static class P_Agent_ISetupAgentStats
	{
		[HarmonyPostfix, HarmonyPatch(methodName: nameof(Agent.SetupAgentStats), argumentTypes: new[] { typeof(string) })]
		public static void SetupAgentStats_Postfix(string transformationType, Agent __instance)
		{
			foreach (ISetupAgentStats trait in __instance.GetTraits<ISetupAgentStats>())
				trait.SetupAgentStats(__instance);
		}
	}
}