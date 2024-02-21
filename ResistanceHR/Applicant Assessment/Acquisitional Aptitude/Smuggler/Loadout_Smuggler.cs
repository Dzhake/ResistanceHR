using HarmonyLib;
using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Loot
{
	public class Loadout_Smuggler : T_Smuggler
	{
		public override List<string> RewardItems =>
			Owner.isPlayer > 0
				? (List<string>)AccessTools.DeclaredField(typeof(SessionDataBig), "characterStartingItems" + Owner.isPlayer.ToString()).GetValue(gc.sessionDataBig)
				: new List<string>() { };

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Loadout_Smuggler>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Each level contains a crate with some items from your character loadout.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Loadout_Smuggler))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 7,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
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