using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Reflection;
using UnityEngine;

namespace RHR.Interaction
{
	public class Snitch : T_Interaction
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public const string SnitchOnSomeone = "SnitchOnSomeone";
		public static Agent informee;

		//[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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

			RogueLibs.CreateCustomName(SnitchOnSomeone, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Snitch",
			});

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				informee = h.Object;
				Agent interactingAgent = h.Agent;

				if (interactingAgent.HasTrait<Snitch>() || interactingAgent.HasTrait<Snitch_Plus>())
				{
					h.AddButton(SnitchOnSomeone, m =>
					{
						informee.Say("Great job pressing a button!");
						informee.commander = interactingAgent;
						informee.commander.target.targetType = SnitchOnSomeone;
						interactingAgent.mainGUI.invInterface.ShowTarget(informee, SnitchOnSomeone);
					});
				}
			});
		}

		public static void CommenceSnitching(Agent informee, Agent informant, Agent targetAgent)
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
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(PlayfieldObjectInteractions), nameof(PlayfieldObjectInteractions.TargetObject))]
		private static bool TargetObjectify(PlayfieldObject playfieldObject, PlayfieldObject otherObject, string combineType, ref bool __result)
		{
			Agent informee = (Agent)playfieldObject;
			Agent informant = informee.commander;
			float maxDistance = 100f; // 17f

			if (informant.target.targetType == Snitch.SnitchOnSomeone
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
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(typeof(Agent), nameof(Agent.ObjectAction))]
		private static bool ObjectActionify(Agent __instance, string myAction, string extraString, float extraFloat, Agent causerAgent, PlayfieldObject extraObject)
		{
			FieldInfo noMoreObjectActions = AccessTools.DeclaredField(typeof(Agent), "noMoreObjectActions");

			if (myAction == Snitch.SnitchOnSomeone
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