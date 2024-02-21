using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class Bulletproofish : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.ResistBulletsSmall;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Bulletproofish>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Bullet damage permanently reduced by 1/3.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Bulletproofish))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 8,
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