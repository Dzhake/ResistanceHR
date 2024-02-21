using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Combat_Melee
{
	public class Cursed_Fist : T_EnchantedHands
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		//	IModMeleeAttack
		public override bool ApplyModMeleeAttack() => true;
		public override bool CanHitGhost() => Owner.inventory.equippedWeapon.invItemName == VItemName.Fist;
		public override void OnStrike(PlayfieldObject target)
		{
			Agent targetAgent = target.playfieldObjectAgent;

			if (targetAgent is null 
				|| targetAgent.ghost || SupernaturalAgents.Contains(targetAgent.agentName))
				return;

			GC.audioHandler.Play(targetAgent, VanillaAudio.MeleeHitAgentCutSmall);
			targetAgent.ChangeHealth(-5);

			if (targetAgent.statusEffects.hasStatusEffect(VanillaEffects.FeelingUnlucky))
				return;

			targetAgent.statusEffects.CreateDebuffText("Cursed");
			targetAgent.statusEffects.AddStatusEffect(VanillaEffects.FeelingUnlucky, false, Owner, target.objectMult.IsFromClient(), true, 5);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Cursed_Fist>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed attacks can hit Ghosts, and deal 25% increased damage plus the Unlucky status effect to non-Supernatural beings.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Cursed_Fist)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Spectral_Palm)
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { 
							CTraitCategory.Chthonic,
							VTraitCategory.Melee,
						},
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Cursed_Fist_Plus),
					}
				});
		}

		

	}
}