using RogueLibsCore;

namespace ResistanceHR.Tampering
{
	internal class Tamper_Tantrum : T_Tampering
	{
		public override float ToolCostFactor => 0.666f;

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Tamper_Tantrum>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "Your tools take less wear from use.",
					[LanguageCode.Russian] = "Ваши инструменты меньше изнашиваются от подделывания."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Tamper_Tantrum)),
					[LanguageCode.Russian] = "Вспышка Гнева",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 3,
					IsAvailable = true,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 5,
					Unlock =
					{
						categories = {  },
						cancellations = { VanillaTraits.PoorHandEyeCoordination },
						cantLose = true,
						cantSwap = false,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { },
						upgrade = nameof(Tamper_Tantrum_Plus),
					}
				});
		}

		public static void AgentInteractions_AddButton_Prefix(string buttonName, ref string extraCost, Agent mostRecentInteractingAgent)
		{
			if ((WrenchTamperButtonNames.Contains(buttonName)
					|| CrowbarTamperButtonNames.Contains(buttonName)
					|| WireCutterTamperButtonNames.Contains(buttonName))
				&& extraCost.EndsWith("-30")
				&& mostRecentInteractingAgent.HasTrait<Tamper_Tantrum>())
			{
				extraCost = extraCost.Substring(0, extraCost.Length - 2) + "15";
			}
		}

	}
}
