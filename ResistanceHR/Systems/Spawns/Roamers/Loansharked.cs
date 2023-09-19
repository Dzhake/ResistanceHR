using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Loansharked : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Mobster };
		internal override int AgentCount =>
			CurrentLevel > 5
			? (int)((CurrentLevel) * 1.50f)
			: 0;
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 4;

		internal override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Loansharked>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "They said it was low interest - then why are they so interested in you paying it back?!",
					[LanguageCode.Russian] = "Вы нашли мешочек денег, однако его владельцы хотят его вернуть, как жаль что вы уже потратили основную часть этих денег, прийдётся возвращать с процентами. Оплатите сумму в банкомате на 10 этаже, иначе вместо вас будут платить ваши коленные чашечки."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Loansharked)),
					[LanguageCode.Russian] = "Долг мафии",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
						VanillaTraits.FriendoftheFamily,
						nameof(Mobbed_Up),
						nameof(Mobbed_Up_Plus),
					},
					CharacterCreationCost = -8,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						categories = {  },
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Remove the trait by level 5, or else. You know, kneecaps, the whole deal." },
						upgrade = null,
					}
				});
		}
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}