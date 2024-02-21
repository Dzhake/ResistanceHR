using BepInEx.Logging;
using RogueLibsCore;

namespace RHR.Inventory
{
	public class Pocket_Changer : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Pocket_Changer>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You spend $100 between levels on, I dunno, some crap. You're even willing to accrue debt for this crap.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Pocket_Changer)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = -4,
					IsAvailable = false,
					IsAvailableInCC = true,
					IsUnlocked = Core.debugMode,
					UnlockCost = 10,
					Unlock =
					{
						cantLose = false,
						cantSwap = true,
						isUpgrade = false,
						prerequisites = { },
						recommendations = { "Pick up an affordable hobby, like working overtime for free." },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);

			if (money.invItemCount >= 100)
				money.invItemCount -= 100;
			else
			{
				GC.sessionData.debtAmount[agent.isPlayer - 1] += (100 - money.invItemCount);
				money.invItemCount = 0;

				if (!agent.statusEffects.hasStatusEffect(VanillaEffects.InDebt1)
						&& !agent.statusEffects.hasStatusEffect(VanillaEffects.InDebt2)
						&& !agent.statusEffects.hasStatusEffect(VanillaEffects.InDebt3))
					agent.statusEffects.AddStatusEffect(VanillaEffects.InDebt1, true, true);

				agent.statusEffects.myStatusEffectDisplay.RefreshStatusEffectText();
			}
		}

		

	}
}