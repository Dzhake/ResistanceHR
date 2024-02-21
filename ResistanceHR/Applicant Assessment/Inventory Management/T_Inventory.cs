using BepInEx.Logging;
using BunnyLibs;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace RHR.Inventory
{
	public abstract class T_Inventory : T_RHR, IRefreshAtEndOfLevelStart
	{
		private static readonly ManualLogSource logger = BLLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		


		public static List<InvItem> FungibleItems(Agent agent) =>
			agent.inventory.InvItemList.Where(ii =>
			ii.invItemName != null
			&& ii.invItemName != ""
			).ToList();
		public static float BuyPriceMultiplier(Agent agent) =>
			agent.HasTrait(VanillaTraits.Sucker)
				? 1.25f
			: agent.HasTrait("GoodTrader")
				? 0.65f
			: agent.HasTrait("GoodTrader2")
				? 0.35f
			: 1.00f;
		public static float SalePriceMultiplier(Agent agent) =>
			agent.HasTrait(VanillaTraits.Sucker)
				? 0.75f
			: agent.HasTrait("GoodTrader")
				? 1.30f
			: agent.HasTrait("GoodTrader2")
				? 1.60f
			: 1.00f;

		public static void PutInDebt(Agent agent, int debtAmount)
		{

			GC.sessionData.debtAmount[agent.isPlayer - 1] += (debtAmount);

			if (!agent.statusEffects.hasStatusEffect(VanillaEffects.InDebt1)
					&& !agent.statusEffects.hasStatusEffect(VanillaEffects.InDebt2)
					&& !agent.statusEffects.hasStatusEffect(VanillaEffects.InDebt3))
				agent.statusEffects.AddStatusEffect(VanillaEffects.InDebt1, true, true);

			agent.statusEffects.myStatusEffectDisplay.RefreshStatusEffectText();
		}

		public static void BuyRandomShit(Agent agent, int numItems, float costFactor)
		{
			for (int i = 0; i < numItems; i++)
			{
				InvItem item = new InvItem();
				item.invItemName = gc.quests.GetRewardItem(false);
				item.SetupDetails(false);
				item.invItemCount = item.rewardCount;
				int netCost = (int)(item.itemValue * costFactor * BuyPriceMultiplier(agent));
				InvItem voucher = agent.inventory.FindItem(VanillaItems.FreeItemVoucher);

				if (voucher is null)
				{
					if (!agent.inventory.hasEmptySlotForItem(item))
						break;

					InvItem money = agent.inventory.FindItem(VanillaItems.Money);

					if (money is null)
						money = agent.inventory.AddItem(VanillaItems.Money, 0);

					if (money.invItemCount < netCost)
					{
						PutInDebt(agent, netCost - money.invItemCount);
						money.invItemCount = 0;
					}
					else
						money.invItemCount -= netCost;
				}
				else
				{
					if (!agent.inventory.hasEmptySlotForItem(item, voucher))
						break;

					agent.inventory.SubtractFromItemCount(voucher, 1);
				}

				agent.inventory.AddItem(item);
			}
		}
		public static void SellRandomShit(Agent agent, int numItems, float costFactor, bool stackablesAsOneItem)
		{
			int itemsSold = 0;

			while (itemsSold < numItems)
			{
				InvItem item = agent.agentInvDatabase.StealItem(false, false);

				if (item is null)
					return;

				float saleValue = agent.determineMoneyCostSelling(item, item.itemValue, "PawnShopMachine");
				int netValue = (int)(saleValue * SalePriceMultiplier(agent) * costFactor);
				InvItem money = agent.inventory.FindItem(VanillaItems.Money);

				if (money is null)
					money = agent.inventory.AddItem(VanillaItems.Money, 0);

				if (stackablesAsOneItem || item.isArmor || item.isArmorHead || item.hasCharges || (item.isWeapon && item.itemType != "WeaponThrown"))
				{
					agent.agentInvDatabase.DestroyItem(item);
					money.invItemCount += netValue;
					itemsSold++;
				}
				else
				{
					int numToSell = UnityEngine.Random.Range(1, item.invItemCount);
					money.invItemCount += netValue * numToSell;
					agent.agentInvDatabase.SubtractFromItemCount(item, numToSell);
					itemsSold += numToSell;
				}
			}
		}

		public bool BypassUnlockChecks => false;
		public bool RunThisLevel() =>
			GC.sessionDataBig.curLevelEndless > 1;
		public void Refresh() { }
		public abstract void Refresh(Agent agent);
	}
}