using RogueLibsCore;
using System.Collections.Generic;

namespace ResistanceHR.Challenges.Quest_Rewards
{
    public abstract class C_QuestRewards : C_ResistanceHR
    {
        public C_QuestRewards(string name) : base(name) { }

        public abstract List<string> RewardItems { get; }
        public abstract int Quantity { get; }
    }
}