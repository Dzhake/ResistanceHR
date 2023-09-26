using BepInEx.Logging;
using HarmonyLib;
using ResistanceHR.Reputation;
using RogueLibsCore;

namespace ResistanceHR.Interaction
{
	internal class Burning_Aspirations : T_Interaction
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		internal const string
			AcceptedSmoke = "AcceptSmoke",
			OfferSmoke = "OfferSmoke",
			Smoked = "Smoked",

			z = "";

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Burning_Aspirations>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Gain XP for smoking. Give cigarettes to heal followers or make neutral NPCs Friendly.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Burning_Aspirations)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						cancellations = {
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});

			RogueLibs.CreateCustomName(AcceptedSmoke, VNameType.Dialogue, new CustomNameInfo
			{
				[LanguageCode.English] = "Thanks, buddy!",
			});
			RogueLibs.CreateCustomName(OfferSmoke, VNameType.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Offer a smoke",
			});
			RogueLibs.CreateCustomName(Smoked, VNameType.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Smoked",
			});

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				Agent recipient = h.Object;
				Agent giver = h.Agent;
				InvItem cigarettes = giver.inventory.FindItem(VanillaItems.Cigarettes);
				
				if (!(cigarettes is null)
					&& giver.HasTrait<Burning_Aspirations>()
					&& (giver.agentInvDatabase.HasItem(VanillaItems.CigaretteLighter) || recipient.agentInvDatabase.HasItem(VanillaItems.CigaretteLighter))
					&& recipient.relationships.GetRel(giver) != VRelationship.Hostile
					&& recipient.relationships.GetRel(giver) != VRelationship.Annoyed
					&& !(recipient.relationships.GetRel(giver) == VRelationship.Friendly && recipient.employer != giver)) // Only employers can give to friendly (CCU Hires), otherwise wasted
				{
					h.AddButton(OfferSmoke, m =>
					{
						giver.agentInvDatabase.GiveItem(cigarettes, recipient);
						InvItem cigarettesReceived = recipient.agentInvDatabase.FindItem(VItem.Cigarettes);

						// Cannot be a patch of DetermineHealthChange, since it lacks access to giver trait list
						if (recipient.employer == giver)
							recipient.ChangeHealth(15);
							recipient.ChangeHealth(15);

						cigarettesReceived.itemFunctions.UseItem(cigarettes, recipient);
						recipient.SayDialogue(AcceptedSmoke);
						recipient.oma.offeredOfficeDrone = true;

						switch (recipient.relationships.GetRel(giver))
						{
							case VRelationship.Neutral:
								T_Reputation.SetRelationshipTo(recipient, giver, VRelationship.Friendly, true);
								break;

							case VRelationship.Friendly:
								if (recipient.employer)
									T_Reputation.SetRelationshipTo(recipient, giver, VRelationship.Loyal, true);
								break;
						}

						recipient.SetChangeElectionPoints(giver);
						m.StopInteraction();
					});
				}
			});
		}
	}

	[HarmonyPatch(typeof(ItemFunctions))]
	internal static class P_ItemFunctions_SmokerSchmoozer
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(ItemFunctions.UseItem))]
		private static bool UseItem(InvItem item, Agent agent)
		{
			if (item.invItemName == VanillaItems.Cigarettes)
			{
				if (agent.isPlayer > 0 && agent.HasTrait<Burning_Aspirations>())
				{
					agent.skillPoints.AddPoints(Burning_Aspirations.Smoked);
				}
			}

			return true;
		}

		// DO NOT patch DetermineHealthChange, since it depends on traits of giver.
	}
}