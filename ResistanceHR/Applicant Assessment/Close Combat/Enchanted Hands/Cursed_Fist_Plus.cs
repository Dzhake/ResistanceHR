using BepInEx.Logging;
using BunnyLibs;
using RogueLibsCore;

namespace RHR.Combat_Melee
{
	public class Cursed_Fist_Plus : T_EnchantedHands
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		//	IModMeleeAttack
		public override bool ApplyModMeleeAttack() => true;
		public override bool CanHitGhost() => true;
		public override void OnStrike(PlayfieldObject target)
		{
			Agent targetAgent = target.playfieldObjectAgent;

			if (targetAgent is null
				|| targetAgent.ghost || SupernaturalAgents.Contains(targetAgent.agentName))
				return;

			GC.audioHandler.Play(targetAgent, VanillaAudio.MeleeHitAgentCutSmall);
			targetAgent.ChangeHealth(-10);

			if (targetAgent.statusEffects.hasStatusEffect(VanillaEffects.FeelingUnlucky))
				return;

			targetAgent.statusEffects.CreateDebuffText("Cursed");
			targetAgent.statusEffects.AddStatusEffect(VanillaEffects.FeelingUnlucky, false, Owner, target.objectMult.IsFromClient(), true, 10);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Cursed_Fist_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed & Melee attacks can hit Ghosts, and deal 50% increased damage. Applies the Unlucky status effect to non-Supernatural beings.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Cursed_Fist_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Spectral_Palm)
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {
							CTraitCategory.Chthonic,
							VTraitCategory.Melee,
						},
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { nameof(Cursed_Fist) },
						recommendations = { },
					}
				});
		}

		

	}
}