using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;

namespace RHR.Luck
{
	public abstract class T_Luck : T_RHR
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public T_Luck() : base() { }

		public abstract int LuckBonus { get; }
	}

	[HarmonyPatch(typeof(PlayfieldObject))]
	public static class P_PlayfieldObject_Luck
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPostfix, HarmonyPatch(nameof(PlayfieldObject.DetermineLuck))]
		public static void ModifyLuck(PlayfieldObject __instance, ref int __result)
		{
			if (__instance is Agent agent)
				foreach (T_Luck trait in agent.GetTraits<T_Luck>())
					__result += trait.LuckBonus;
		}
	}
}