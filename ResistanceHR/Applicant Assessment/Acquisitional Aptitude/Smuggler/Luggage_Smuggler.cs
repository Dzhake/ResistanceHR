using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Loot
{
	public class Luggage_Smuggler : T_Smuggler
	{
		public override List<string> RewardItems =>
			Owner.isPlayer > 0
				? Owner.inventory.InvItemList.Select(ii => ii.invItemName).ToList()
				: new List<string>() { };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Luggage_Smuggler>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Each level, your inventory is smuggled into a crate placed somewhere in the level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Luggage_Smuggler))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = -7,
					IsAvailable = false,
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