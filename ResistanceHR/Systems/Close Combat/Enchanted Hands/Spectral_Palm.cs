using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Combat_Melee
{
	internal class Spectral_Palm : T_EnchantedHands
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spectral_Palm>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed attacks can hit Ghosts, and deal 50% increased to all Supernatural beings.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spectral_Palm)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Cursed_Fist),
						nameof(Cursed_Fist_Plus),
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = { VTraitCategory.Melee },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Spectral_Palm_Plus),
					}
				});
		}

		internal override bool BonusDamageEligible(Agent hitter, Agent target) =>
			target.ghost ||
			VAgent.SupernaturalAgents.Contains(target.agentName);
		internal override bool CanHitGhost2(Agent hitter, Agent target) =>
			hitter.inventory.equippedWeapon == hitter.inventory.fist;
		internal override float DamageMultiplier =>
			1.50f;
		public override void OnAdded() { }
		public override void OnRemoved() { }
		internal override void OnStrike(Agent hitter, Agent target) { }
	}
}