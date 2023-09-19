using BepInEx.Logging;
using RogueLibsCore;

namespace ResistanceHR.Combat_Melee
{
	internal class Cursed_Fist : T_EnchantedHands
	{
		private static readonly ManualLogSource logger = RHRLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Cursed_Fist>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed attacks can hit Ghosts, and deal 25% increased damage plus the Unlucky status effect to non-Supernatural beings.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Cursed_Fist)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Spectral_Palm),
						nameof(Spectral_Palm_Plus)
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
						upgrade = nameof(Cursed_Fist_Plus),
					}
				});
		}

		internal override bool BonusDamageEligible(Agent hitter, Agent target) =>
			!target.ghost &&
			!VAgent.SupernaturalAgents.Contains(target.agentName);
		internal override bool CanHitGhost2(Agent hitter, Agent target) =>
			hitter.inventory.equippedWeapon == hitter.inventory.fist;
		internal override float DamageMultiplier => 1.25f;
		public override void OnAdded() { }
		public override void OnRemoved() { }
		internal override void OnStrike(Agent hitter, Agent target) { }
	}
}