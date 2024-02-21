using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class The_Invincibility_Gambit : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.KillerThrower;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<The_Invincibility_Gambit>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Ah, you clever strategist, you!\n\nNO NUGGETS EVER.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(The_Invincibility_Gambit))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 100,
					IsAvailable = false,
					IsAvailableInCC = true,
					
					UnlockCost = 0,
					Upgrade = null,
					Unlock =
					{
						
						categories = { VTraitCategory.Defense }
					}
				});
		}
		
		
	}
}