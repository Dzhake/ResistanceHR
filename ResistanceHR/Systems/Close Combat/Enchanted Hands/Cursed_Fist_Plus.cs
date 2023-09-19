using RogueLibsCore;

namespace ResistanceHR.Combat_Melee
{
	internal class Cursed_Fist_Plus : T_EnchantedHands
	{
		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Cursed_Fist_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed & Melee attacks can hit Ghosts, and deal 50% increased damage. Applies the Unlucky status effect to non-Supernatural beings.",
					[LanguageCode.Russian] = "",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Cursed_Fist_Plus)),
					[LanguageCode.Russian] = "",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						nameof(Spectral_Palm),
						nameof(Spectral_Palm_Plus)
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
						cantSwap = false,
						isUpgrade = true,
						prerequisites = { nameof(Cursed_Fist) },
						recommendations = { },
					}
				});
		}

		internal override bool BonusDamageEligible(Agent hitter, Agent target) =>
			!target.ghost &&
			!VAgent.SupernaturalAgents.Contains(target.agentName);
		internal override bool CanHitGhost2(Agent hitter, Agent target) =>
			hitter.inventory.equippedWeapon == hitter.inventory.fist ||
			hitter.inventory.equippedWeapon.itemType == VItemType.WeaponMelee;
		internal override float DamageMultiplier => 1.50f;
		public override void OnAdded() { }
		public override void OnRemoved() { }
		internal override void OnStrike(Agent hitter, Agent target)
		{
			if (BonusDamageEligible(hitter, target))
				target.statusEffects.AddStatusEffect(VanillaEffects.FeelingUnlucky, false, hitter, target.objectMult.IsFromClient(), true, 15);
		}
	}
}