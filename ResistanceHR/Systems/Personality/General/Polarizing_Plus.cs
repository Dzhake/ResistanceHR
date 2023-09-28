using RogueLibsCore;

namespace ResistanceHR.Reputation
{
	internal class Polarizing_Plus : T_Reputation
	{
		[RLSetup]
		internal static void Setup()
		{
			RogueLibs.CreateCustomTrait<Polarizing_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You speak the language of the \"Skreets\", as you pronounce it.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Polarizing_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 5,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.DebugMode,
					UnlockCost = 10,
					Unlock =
					{
						cancellations = {
							VanillaTraits.Antisocial,
							VanillaTraits.Charismatic,
							VanillaTraits.FairGame,
							VanillaTraits.FriendoftheCommonFolk,
							nameof(Combative),
							VanillaTraits.Malodorous,
							nameof(Combative_Plus),
							VanillaTraits.Suspicious,
						},
						categories = { VTraitCategory.Social },
						cantLose = true,
						cantSwap = true,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		internal override bool AgentIsRival(Agent otherAgent) =>
			false;

		internal override void ApplyOriginalRelationship(Agent otherAgent)
		{
			if (gc.percentChance(50))                                                       //  50%
			{
				if (gc.percentChance(40))                                                   //      20%
				{
					if (gc.percentChance(20))
						SetRelationshipTo(Owner, otherAgent, VRelationship.Aligned, true);  //          4%
					else
						SetRelationshipTo(Owner, otherAgent, VRelationship.Loyal, true);    //          16%
				}
				else
					SetRelationshipTo(Owner, otherAgent, VRelationship.Friendly, true);     //      30%
			}
			else                                                                            //  50%
			{
				if (gc.percentChance(40))                                                   //      20%
					SetRelationshipTo(Owner, otherAgent, VRelationship.Hostile, true);
				else
					SetRelationshipTo(Owner, otherAgent, VRelationship.Annoyed, true);      //      30%
			}
		}

		public override void OnAdded() { }
		public override void OnRemoved() { }
	}
}