using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Loot
{
	public class Bomb_Smuggler : T_Smuggler
	{
		public override List<string> RewardItems => new List<string>()
		{
			VanillaItems.DoorDetonator,
			// VanillaItems.Explodevice, // OP without weighting
			VanillaItems.Fireworks,
			VanillaItems.Grenade,
			VanillaItems.LandMine,
			VanillaItems.RemoteBomb,
			VanillaItems.RocketLauncher,
			VanillaItems.TimeBomb,
		};

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Bomb_Smuggler>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Each level contains a crate with a buncha fun explosives inside.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Bomb_Smuggler))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					UnlockCost = 15,
					Upgrade = null,
					Unlock =
					{
						categories = {  },
						cantLose = true,
						cantSwap = false,
						recommendations = { "Likely not compatible with Scientist Big Quest." },
					}
				});
		}
	}
}