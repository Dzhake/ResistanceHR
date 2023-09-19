using BepInEx.Logging;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Reflection;
using UnityEngine;

namespace ResistanceHR.Interaction
{
	internal class Snitch : T_Interaction
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		//[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Snitch>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Interact with an NPC to sic them and nearby allies on anyone they're hostile to. People who see you snitching may not approve.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Snitch)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = {
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Watch your back." },
						upgrade = nameof(Snitch_Plus),
					}
				});
		}

		internal static void CommenceSnitching(Agent informee, Agent informant, Agent targetAgent)
		{
			informee.Say("Great job snitching on someone!");
			informant.Say("Glad to snitch");
			targetAgent.Say("It feels so good to get snitched on!");
			informee.agentInteractions.Attack(informee, informant, targetAgent, true);
			return;
		}
	}

	[HarmonyPatch(typeof(PlayfieldObjectInteractions))]
	static class P_PlayfieldObjectInteractions_Snitch
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(PlayfieldObjectInteractions), nameof(PlayfieldObjectInteractions.TargetObject))]
		private static bool TargetObjectify(PlayfieldObject playfieldObject, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			Agent informee = (Agent)playfieldObject;
			Agent informant = informee.commander;
			float maxDistance = 100f; // 17f

			if (informant.target.targetType == T_Interaction.SnitchOnSomeone
				&& GC.mainGUI.targetObject is Agent targetAgent
				&& Vector2.Distance(informant.curPosition, targetAgent.curPosition) < maxDistance)
			{
				informee.Say("Great Job targeting an object!");
				Snitch.CommenceSnitching(informee, informant, targetAgent);
				__result = true;
				return false;
			}

			return true;
		}
	}

	[HarmonyPatch(typeof(Agent))]
	static class P_Agent_Snitch
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(Agent), nameof(Agent.ObjectAction))]
		private static bool ObjectActionify(Agent __instance, string myAction, string extraString, float extraFloat, Agent causerAgent, PlayfieldObject extraObject)
		{
			FieldInfo noMoreObjectActions = AccessTools.DeclaredField(typeof(Agent), "noMoreObjectActions");

			if (myAction == T_Interaction.SnitchOnSomeone
				&& !(bool)noMoreObjectActions.GetValue(__instance))
			{
				__instance.Say("Great job sending an Object Action!");

				MethodInfo objectAction_base = AccessTools.DeclaredMethod(typeof(Agent).BaseType, "ObjectAction");
				objectAction_base.GetMethodWithoutOverrides<Action<string, string, float, Agent, PlayfieldObject>>(__instance).Invoke(myAction, extraString, extraFloat, causerAgent, extraObject);

				Snitch.CommenceSnitching(__instance, causerAgent, (Agent)extraObject);

				noMoreObjectActions.SetValue(__instance, false);

				return false;
			}

			return true;
		}
	}
}