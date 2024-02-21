using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Loansharked : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Mobster };
		public override int AgentCount =>
			CurrentLevel > 5
			? (int)((CurrentLevel) * 1.50f)
			: 0;
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 4;

		public override void ModifySpawnedAgent(Agent agent) { }

		[RLSetup]
		public static void Setup()
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
					IsUnlocked = Core.debugMode,
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
		

	}
}