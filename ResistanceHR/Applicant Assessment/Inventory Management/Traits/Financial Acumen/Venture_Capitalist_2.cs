using BepInEx.Logging;
using RogueLibsCore;
using UnityEngine;

namespace RHR.Inventory
{
	public class Venture_Capitalist_Plus : T_Inventory
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[RLSetup]
		public static void Setup()
		{
			RogueLibs.CreateCustomTrait<Venture_Capitalist_Plus>()
				.WithDescription(new CustomNameInfo
				{
					[LanguageCode.English] = "You've got a sun-hot tip. Your money is modified by anywhere from -300% to 300% each level.",
				})
				.WithName(new CustomNameInfo
				{
					[LanguageCode.English] = DisplayName(typeof(Venture_Capitalist_Plus)),
				})
				.WithUnlock(new TraitUnlock
				{
					Cancellations = {
					},
					CharacterCreationCost = 12,
					IsAvailable = false,
					IsAvailableInCC = false,
					IsUnlocked = true,
					UnlockCost = 25,
					Unlock =
					{
						cantLose = false,
						cantSwap = false,
						isUpgrade = true,
						prerequisites = { },
						recommendations = { },
						upgrade = null,
					}
				});
		}

		public override void Refresh(Agent agent)
		{
			InvItem money = agent.inventory.FindItem(VanillaItems.Money);

			if (money is null)
				return;

			float mean = 0.5f;
			float stdDev = 0.75f;

			float u1 = Random.Range(0.0f, 1.0f);
			float u2 = Random.Range(0.0f, 1.0f);
			float z0 = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);
			float result = Mathf.Clamp(mean + stdDev * z0, -2.0f, 3.0f);
			int net = (int)(money.invItemCount * result);

			if (net < 0)
			{
				money.invItemCount = 0;
				PutInDebt(agent, net - money.invItemCount);
			}
			else
				money.invItemCount = net;
		}
	}
}