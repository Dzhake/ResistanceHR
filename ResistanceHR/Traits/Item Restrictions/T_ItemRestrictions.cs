using BepInEx.Logging;
using ResistanceHR.Localization;
using RogueLibsCore;
using System.Collections.Generic;
using System.Linq;

namespace ResistanceHR.Traits.Item_Restrictions
{
    public abstract class T_ItemRestrictions : T_ResistanceHR
    {
        private static readonly ManualLogSource logger = RHRLogger.GetLogger();
        public static GameController GC => GameController.gameController;

        public T_ItemRestrictions() : base() { }

        protected abstract List<string> Dialogue { get; }
        public abstract List<string> ProhibitedItemCategories { get; }
        public abstract List<string> ProhibitedItemTypes { get; }

        public string GetDialogue =>
            Dialogue[UnityEngine.Random.Range(0, Dialogue.Count - 1)];

        public static bool CanUseItem(Agent agent, InvItem invItem, bool suppressDialogue)
        {
            if (!agent.GetTraits<T_ItemRestrictions>().Any())
                return true;

            logger.LogDebug("CanUseItem");
            string dialogue = "";

            foreach (T_ItemRestrictions trait in agent.GetTraits<T_ItemRestrictions>())
            {
                if (trait.ProhibitedItemCategories.Intersect(invItem.Categories).ToList().Any() ||
                    trait.ProhibitedItemTypes.Contains(invItem.itemType) ||
                    (trait is Fat_Head && invItem.itemType == VItemType.Wearable && invItem.isArmorHead) ||
                    (trait is Fatass && invItem.itemType == VItemType.Wearable && !invItem.isArmorHead))
                {
                    dialogue = trait.GetDialogue;

                    logger.LogDebug("Excluded Item:");
                    logger.LogDebug("Item:\t" + invItem.invItemName);
                    logger.LogDebug("Trait Dialogue:\t" + dialogue);
                }
            }

            if (dialogue == "" ||
                (dialogue is CDialogue.CantUseLoud && invItem.contents.Contains(VItem.Silencer)))
                return true;

            if (!suppressDialogue)
            {
                agent.SayDialogue(agent, dialogue);
                GC.audioHandler.Play(agent, VDialogue.CantDo);
            }

            return false;
        }

        public static List<InvItem> FilteredEquipmentList(InvDatabase invDatabase)
        {
            if (!invDatabase.agent.GetTraits<T_ItemRestrictions>().Any())
                return invDatabase.InvItemList;

            List<InvItem> invItemList = invDatabase.InvItemList;
            List<InvItem> removals = new List<InvItem>();

            foreach (InvItem invItem in invItemList)
                if (!CanUseItem(invDatabase.agent, invItem, true))
                    removals.Add(invItem);

            foreach (InvItem invitem in removals)
                invItemList.Remove(invitem);

            return invItemList;
        }
    }
}