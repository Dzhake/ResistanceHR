using BunnyLibs;
using RogueLibsCore;

namespace CCU.Traits.Player.Status_Effect
{
	public class LyCANthrope : T_PermanentStatusEffect, ISetupAgentStats
	{
		public override string StatusEffectName => VanillaEffects.Werewolf;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<LyCANthrope>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "There's nothing you can't do. You're a werewolf forever.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(LyCANthrope))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 32,
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