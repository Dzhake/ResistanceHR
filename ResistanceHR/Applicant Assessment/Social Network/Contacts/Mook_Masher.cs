using RogueLibsCore;
using System.Collections.Generic;

namespace RHR.Spawns
{
	public class Mook_Masher : T_Roamers
	{
		public override List<string> AgentClasses => new List<string> { VanillaAgents.Goon };
		public override int AgentCount => (CurrentLevel) * 2;
		public override string AgentRelationship => nameof(relStatus.Hostile);
		public override bool AgentsAlwaysRun => false;
		public override bool AgentsArmed => true;
		public override int GroupSize => 4;

		public override void ModifySpawnedAgent(Agent agent) { }


		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Mook_Masher>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "What plot is complete without a gradually increasing swarm of easily dispatched henchmen?",
					[LanguageCode.Russian] = "Когда вы пришли к Мэру, он знал что вы угроза. Он мог бы просто вас убить, но как любой злодей, он предпочтёл отправляться волны приспешников, волны постоянно растут, но они управляемые."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Mook_Masher)),
					[LanguageCode.Russian] = "Разрушитель сердец",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
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
						recommendations = { },
						upgrade = null,
					}
				});
		}
		

	}
}