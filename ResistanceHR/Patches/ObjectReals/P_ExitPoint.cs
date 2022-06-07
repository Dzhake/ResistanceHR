using HarmonyLib;
using ResistanceHR.Challenges.Quest_Count;

namespace ResistanceHR.Patches.ObjectReals
{
    [HarmonyPatch(declaringType: typeof(ExitPoint))]
	public static class P_ExitPoint
	{
		/// <summary>
		/// Special exception for Rushin' Revolution to allow level exit
		/// </summary>
		/// <param name="__result"></param>
		/// <returns></returns>
		[HarmonyPrefix, HarmonyPatch(methodName: nameof(ExitPoint.DetermineIfCanExit))]
		private static bool DetermineIfCanExit_Prefix(ref bool __result)
		{
			if (GameController.gameController.challenges.Contains(nameof(Rushin_Revolution)))
			{
				__result = true;
				return false;
			}

			return true;
		}
	}
}