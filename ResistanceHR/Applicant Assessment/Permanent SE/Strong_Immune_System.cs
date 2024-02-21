using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Strong_Immune_System : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.StableSystem;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Strong_Immune_System>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You're immune to negative status effects.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Strong_Immune_System))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { VanillaTraits.LongerStatusEffects },
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					UnlockCost = 15,
					Upgrade = null,
					Unlock =
					{
						categories = { VTraitCategory.Defense }
					}
				});
		}
		
		
	}
}