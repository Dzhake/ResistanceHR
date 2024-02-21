using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Lucky_Duck : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.FeelingLucky;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Lucky_Duck>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You are lucky.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Lucky_Duck))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 7,
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