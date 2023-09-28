using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Spawns
{
	internal class Mook_Masher : T_Roamers
	{
		internal override List<string> AgentClasses => new List<string> { VanillaAgents.Goon };
		internal override int AgentCount => (CurrentLevel) * 2;
		internal override string AgentRelationship => nameof(relStatus.Hostile);
		internal override bool AgentsAlwaysRun => false;
		internal override bool AgentsArmed => true;
		internal override int GroupSize => 4;

		internal override void ModifySpawnedAgent(Agent agent) { }


		[RLSetup]
		internal static void Setup()
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
					IsUnlocked = Core.DebugMode,
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
		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}