using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Critter_Hitter : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.AlwaysCrit;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Critter_Hitter>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You always get critical hits.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Critter_Hitter))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { VanillaTraits.IncreasedCritChance },
					CharacterCreationCost = 24,
					IsAvailable = false,
					IsAvailableInCC = true,
					
					UnlockCost = 0,
					Upgrade = null,
					Unlock =
					{
						
						categories = { }
					}
				});
		}
		
		
	}
}