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
        public abstract bool ItemUsable(InvItem invItem);

        public string GetDialogue =>
            Dialogue[UnityEngine.Random.Range(0, Dialogue.Count - 1)];

        public static bool AgentTryUseItem(Agent agent, InvItem invItem, bool suppressDialogue)
        {
            if (!agent.GetTraits<T_ItemRestrictions>().Any())
                return true;

            logger.LogDebug("CanUseItem");
            logger.LogDebug("Item:\t" + invItem.invItemName);
            logger.LogDebug("\tType:\t" + invItem.itemType);
            foreach (string cat in invItem.Categories)
                logger.LogDebug("\tCategory:\t" + cat);

            foreach (T_ItemRestrictions trait in agent.GetTraits<T_ItemRestrictions>())
                if (!trait.ItemUsable(invItem))
                {
                    logger.LogDebug("Excluded Item:\t" + trait.TextName);

                    if (!suppressDialogue)
                    {
                        agent.SayDialogue(agent, trait.GetDialogue);
                        GC.audioHandler.Play(agent, VDialogue.CantDo);
                    }

                    return false;
                }

            return true;
        }

        public static List<InvItem> FilteredEquipmentList(InvDatabase invDatabase)
        {
            if (!invDatabase.agent.GetTraits<T_ItemRestrictions>().Any())
                return invDatabase.InvItemList;

            List<InvItem> invItemList = invDatabase.InvItemList;
            List<InvItem> removals = new List<InvItem>();

            foreach (InvItem invItem in invItemList)
                if (!AgentTryUseItem(invDatabase.agent, invItem, true))
                    removals.Add(invItem);

            foreach (InvItem invitem in removals)
                invItemList.Remove(invitem);

            return invItemList;
        }
    }
}