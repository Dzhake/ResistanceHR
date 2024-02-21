using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Above_the_Laws : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.AbovetheLaw;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Above_the_Laws>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Permanently Above the Law... s.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Above_the_Laws))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.CorruptionCosts,
						VanillaTraits.TheLaw,
						VanillaTraits.Wanted
					},
					CharacterCreationCost = 7,
					IsAvailable = false,
					IsAvailableInCC = true,
					
					UnlockCost = 15,
					Upgrade = null,
					Unlock =
					{
						
						categories = { }
					}
				});
		}
		
		
	}
}