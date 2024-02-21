using BepInEx.Logging;
using BTHarmonyUtils.TranspilerUtils;
using BunnyLibs;
using HarmonyLib;
using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace RHR.Loot
{
	public class Drug_Smuggler : T_Smuggler
	{
		public override List<string> RewardItems => new List<string>()
		{
			VanillaItems.Antidote,
			VanillaItems.CritterUpper,
			VanillaItems.CyanidePill,
			VanillaItems.ElectroPill,
			VanillaItems.Giantizer,
			VanillaItems.KillerThrower,
			VanillaItems.MusclyPill,
			VanillaItems.RagePoison,
			VanillaItems.Shrinker,
			VanillaItems.Sugar,
			VanillaItems.Syringe,
		};

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Drug_Smuggler>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Each level contains a crate with a buncha fun drugs inside.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Drug_Smuggler))
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = { },
					CharacterCreationCost = 5,
					IsAvailable = true,
					IsAvailableInCC = true,
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