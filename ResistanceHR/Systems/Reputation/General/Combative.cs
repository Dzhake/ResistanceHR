using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Combative : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Combative>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You have a certain way with people! A very annoying way.",
					[LanguageCode.Russian] = "Вы крайне раздражительны, вы даже не умеете общатся с людьми! Это оооочень... раздражает."
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Combative)),
					[LanguageCode.Russian] = "Вообще неприятный",
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -6,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 15,
					Unlock =
					{
						cancellations = {
							VanillaTraits.Antisocial,
							VanillaTraits.Charismatic,
							VanillaTraits.FairGame,
							VanillaTraits.FriendoftheCommonFolk,
							VanillaTraits.IdeologicalClash,
							VanillaTraits.Malodorous,
							VanillaTraits.Suspicious,
							VanillaTraits.Wanted,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Smile a little more" },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (gc.percentChance(20))
			{
				if (gc.percentChance(5))
					SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
				else
					SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);
			}
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}