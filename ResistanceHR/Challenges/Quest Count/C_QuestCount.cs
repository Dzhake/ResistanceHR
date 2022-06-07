using RogueLibsCore;

namespace ResistanceHR.Challenges.Quest_Count
{
    public abstract class C_QuestCount : C_ResistanceHR
    {
        public C_QuestCount(string name) : base(name) { }

        public abstract int QuestCount { get; }
    }
}