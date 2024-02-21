using BepInEx.Logging;
using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Combat_Melee
{
	public class Spectral_Palm : T_EnchantedHands
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		//	IModMeleeAttack
		public override bool ApplyModMeleeAttack() => Owner.inventory.equippedWeapon.invItemName == VItemName.Fist;
		public override bool CanHitGhost() => Owner.inventory.equippedWeapon.invItemName == VItemName.Fist;
		public override void OnStrike(PlayfieldObject target)
		{
			Agent targetAgent = target.playfieldObjectAgent;

			// TODO: Generalized IsSupernatural
			if (targetAgent is null
				|| (!targetAgent.ghost && !SupernaturalAgents.Contains(targetAgent.agentName)))
				return;

			GC.audioHandler.Play(targetAgent, VanillaAudio.GhostGibberEnd);
			targetAgent.ChangeHealth(-10);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spectral_Palm>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed attacks can hit Ghosts, and deal bonus Spectral damage to all Supernatural beings.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spectral_Palm)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Cursed_Fist),
						nameof(Cursed_Fist_Plus),
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { 
							VTraitCategory.Melee,
							CTraitCategory.Spectral,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Spectral_Palm_Plus),
					}
				});
		}

		

	}
}