using BepInEx.Logging;
using BunnyLibs;
using RogueLibsCore;

namespace RHR.Combat_Melee
{
	public class Spectral_Palm_Plus : T_EnchantedHands
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		//	IModMeleeAttack
		public override bool ApplyModMeleeAttack() => true;
		public override bool CanHitGhost() => true;
		public override void OnStrike(PlayfieldObject target)
		{
			Agent targetAgent = target.playfieldObjectAgent;

			// TODO: Generalized IsSupernatural
			if (targetAgent is null
				|| (!targetAgent.ghost && !SupernaturalAgents.Contains(targetAgent.agentName)))
				return;

			GC.audioHandler.Play(targetAgent, VanillaAudio.GhostGibberEnd);
			targetAgent.ChangeHealth(-20);
		}

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spectral_Palm_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed & Melee attacks can hit Ghosts, and deal 100% increased to all Supernatural beings.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spectral_Palm_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Cursed_Fist),
						nameof(Cursed_Fist_Plus),
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = Core.debugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Melee },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { nameof(Spectral_Palm) },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		

	}
}