using BunnyLibs;
using RogueLibsCore;

namespace RHR.Combat_Melee
{
	public class Punch_Drunk : T_RHR, IModMeleeAttack
	{
		public float MeleeDamage => 1.00f;
		public float MeleeKnockback => 1.00f;
		public float MeleeLunge => 1.00f;
		public float MeleeSpeed => 1.20f;
		public bool ApplyModMeleeAttack() => Owner.agentInvDatabase.equippedWeapon.invItemName == VItemName.Fist;
		public bool CanHitGhost() => false;
		public bool MobilityMandatory() => false;
		public bool MobilityProhibited() => false;
		public void OnStrike(PlayfieldObject target) { }
		public bool? SetMobility() => null;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Punch_Drunk>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Unarmed attack speed increased by 20%.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Punch_Drunk)),
				})
				.WithUnlock(new TraitUnlock
				{
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					UnlockCost = 5,
					Upgrade = nameof(Punch_Drunk_Plus),
					Unlock =
					{
						categories = { CTraitCategory.Unarmed },
					}
				});
		}
	}
}