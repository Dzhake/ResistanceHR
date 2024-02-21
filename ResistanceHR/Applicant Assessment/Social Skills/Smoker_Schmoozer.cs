using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RHR.Reputation;
using RogueLibsCore;

namespace RHR.Interaction_
{
	public class Smoker_Schmoozer : T_Interaction
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public const string
			AcceptedSmoke = "AcceptSmoke",
			OfferSmoke = "OfferSmoke",
			Smoked = "Smoked",

			z = "";

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Smoker_Schmoozer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Gain XP for smoking. Give cigarettes to heal followers or make neutral NPCs Friendly.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Smoker_Schmoozer)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
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

			RogueLibs.CreateCustomName(AcceptedSmoke, NameTypes.Dialogue, new CustomNameInfo
			{
				[LanguageCode.English] = "Thanks, buddy!",
			});
			RogueLibs.CreateCustomName(OfferSmoke, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Offer a smoke",
			});
			RogueLibs.CreateCustomName(Smoked, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Smoked",
			});

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				Agent recipient = h.Object;
				Agent giver = h.Agent;
				InvItem cigarettes = giver.inventory.FindItem(VanillaItems.Cigarettes);
				
				if (!recipient.oma.offeredOfficeDrone
					&&!(cigarettes is null)
					&& giver.HasTrait<Smoker_Schmoozer>()
					&& (giver.agentInvDatabase.HasItem(VanillaItems.CigaretteLighter) || recipient.agentInvDatabase.HasItem(VanillaItems.CigaretteLighter))
					&& recipient.relationships.GetRel(giver) != VRelationship.Hostile
					&& recipient.relationships.GetRel(giver) != VRelationship.Annoyed
					&& !(recipient.relationships.GetRel(giver) == VRelationship.Friendly && recipient.employer != giver)) // Only employers can give to friendly (CCU Hires), otherwise wasted
				{
					h.AddButton(OfferSmoke, m =>
					{
						giver.agentInvDatabase.GiveItem(cigarettes, recipient);
						InvItem cigarettesReceived = recipient.agentInvDatabase.FindItem(VItemName.Cigarettes);
						cigarettesReceived.itemFunctions.UseItem(cigarettes, recipient);
						recipient.SayDialogue(AcceptedSmoke);
						string relationship = recipient.relationships.GetRel(giver);

						recipient.oma.offeredOfficeDrone = true; // TODO: Set this to false on hire
						if (recipient.employer == giver)
						{
							recipient.ChangeHealth(15);
							recipient.oma.offeredOfficeDrone = false;
						}
						if (relationship == VRelationship.Neutral)
						{
							RelationshipHelper.SetRelationshipTo(recipient, giver, VRelationship.Friendly, true);
						}

						recipient.SetChangeElectionPoints(giver);
						m.StopInteraction();
					});
				}
			});
		}
	}

	[HarmonyPatch(typeof(ItemFunctions))]
	public static class P_ItemFunctions_SmokerSchmoozer
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyPrefix, HarmonyPatch(nameof(ItemFunctions.UseItem))]
		private static bool UseItem(InvItem item, Agent agent)
		{
			if (item.invItemName == VanillaItems.Cigarettes)
			{
				if (agent.isPlayer > 0 && agent.HasTrait<Smoker_Schmoozer>())
				{
					agent.skillPoints.AddPoints(Smoker_Schmoozer.Smoked);
				}
			}

			return true;
		}

		// DO NOT patch DetermineHealthChange, since it depends on traits of giver.
	}
}