using BepInEx.Logging;
using BunnyLibs;
using HarmonyLib;
using RHR.Item_Restrictions;
using RHR.Reputation;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Interaction_
{
	public class Hawker : T_Interaction, IRefreshAtEndOfLevelStart
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		public const string
			HawkItems = "HawkItems",

			z = "";

		//[RLSetup]
		public static void Setup()
		{
			// Issue: Vanilla item cats are fucked up. You'd have to fix them. E.g., fireproof suit category = Weapons...?
			//	Why not skip those entirely, and curate the sales?
			/*		Item Type				Buyer(s)
			 *	Alcohol					Drones, Slum Dwellers
			 *	Drugs					Scientist, Doctors, Slum Dwellers
			 *	Food					Cops, Workers, Drones
			 *	Guns					Soldiers, Gangsters, Cops
			 *	
			 */
			RogueLibs.CreateCustomTrait<Hawker>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You can sell almost anything to almost anyone.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Hawker)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						cancellations = {
						},
						categories = { VTraitCategory.Trade },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});

			RogueLibs.CreateCustomName(HawkItems, NameTypes.Interface, new CustomNameInfo
			{
				[LanguageCode.English] = "Hawk items",
			});

			RogueInteractions.CreateProvider<Agent>(h =>
			{
				Agent seller = h.Agent;
				Agent buyer = h.Agent.interactingAgent;

				if (seller is null || buyer is null
					|| !seller.HasTrait<Hawker>()
					|| !HasItemsToSellTo(seller, h.Agent.interactingAgent))
					return;

				h.AddButton(HawkItems, m =>
				{

					m.StopInteraction();
				});
			});
		}

		private static bool HasItemsToSellTo(Agent seller, Agent buyer)
		{
			List<string> desires = GetDesires(buyer);

			foreach (InvItem invItem in seller.agentInvDatabase.InvItemList)
				if (desires.Intersect(invItem.Categories).Any())
					return true;

			return false;
		}

		private static List<string> GetDesires(Agent agent) =>
			agent.Desires.Select(a => a.desireName).ToList();

		public bool BypassUnlockChecks => false;
		public void Refresh()
		{
			foreach (Agent agent in gc.agentList)
			{
				agent.Desires.Clear();

				foreach (KeyValuePair<string, List<string>> keyValuePair in AgentInterests)
				{
					if (keyValuePair.Key == agent.agentName)
					{
						foreach (string desire in keyValuePair.Value)
						{
							Desire desireObject = new Desire();
							desireObject.desireName = desire;
							agent.Desires.Add(desireObject);
						}
					}
				}
			}
		}
		public void Refresh(Agent agent) { }
		public bool RunThisLevel() => true;
		public void RefreshInactive() { }

		// NO DRUGS, ALCOHOL OR FOOD - THOSE SHOULD HAVE THEIR OWN TRAITS
		List<KeyValuePair<string, List<string>>> AgentInterests = new List<KeyValuePair<string, List<string>>>
		{
			new KeyValuePair<string, List<string>>(VanillaAgents.Alien, new List<string>() { VItemCategory.Technology, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Assassin, new List<string>() { VItemCategory.Melee, VItemCategory.NonUsableTool, VItemCategory.Stealth, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Bartender, new List<string>() { VItemCategory.Social, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Bouncer, new List<string>() { VItemCategory.Melee, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Cannibal, new List<string>() { VItemCategory.Defense, VItemCategory.Guns, VItemCategory.GunAccessory, VItemCategory.Melee, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Clerk, new List<string>() { }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Comedian, new List<string>() { VItemCategory.Sex, VItemCategory.Weird, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Cop, new List<string>() { VItemCategory.GunAccessory, VItemCategory.Guns, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.CopBot, new List<string>() { }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Courier, new List<string>() { VItemCategory.Movement, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.CustomCharacter, new List<string>() { }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Demolitionist, new List<string>() { VItemCategory.Bomb, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Doctor, new List<string>() { VItemCategory.Health, VItemCategory.NonViolent, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.DrugDealer, new List<string>() { VItemCategory.Guns, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Firefighter, new List<string>() { }),
			new KeyValuePair<string, List<string>>(VanillaAgents.GangsterBlahd, new List<string>() { VItemCategory.Guns, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.GangsterCrepe, new List<string>() { VItemCategory.Guns, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Ghost, new List<string>() { VItemCategory.Weird, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Goon, new List<string>() { VItemCategory.Defense, VItemCategory.Guns, VItemCategory.Melee, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Gorilla, new List<string>() { VItemCategory.Melee, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Hacker, new List<string>() { VItemCategory.Technology, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.InvestmentBanker, new List<string>() { }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Mayor, new List<string>() {  }), // Should buy EVERYTHING :DDD
			new KeyValuePair<string, List<string>>(VanillaAgents.MechPilot, new List<string>() { VItemCategory.NotRealWeapons, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Mobster, new List<string>() { VItemCategory.Guns, }),
			new KeyValuePair<string, List<string>>(VanillaAgents.Musician, new List<string>() { VItemCategory.Social, }),
			//etc.

		};
	}
}