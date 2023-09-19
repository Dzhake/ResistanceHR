using RogueLibsCore;

namespace ResistanceHR.Combat_Melee
{
	internal class Spectral_Palm_Plus : T_EnchantedHands
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Spectral_Palm_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed & Melee attacks can hit Ghosts, and deal 100% increased to all Supernatural beings.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Spectral_Palm_Plus)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Cursed_Fist),
						nameof(Cursed_Fist_Plus),
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
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

		internal override bool BonusDamageEligible(Agent hitter, Agent target) =>
			target.ghost ||
			VAgent.SupernaturalAgents.Contains(target.agentName);
		internal override bool CanHitGhost2(Agent hitter, Agent target) =>
			hitter.inventory.equippedWeapon == hitter.inventory.fist ||
			hitter.inventory.equippedWeapon.itemType == VItemType.WeaponMelee;
		internal override float DamageMultiplier =>
			2.00f;
		public override void OnAdded() { }
		public override void OnRemoved() { }
		internal override void OnStrike(Agent hitter, Agent target) { }
	}
}