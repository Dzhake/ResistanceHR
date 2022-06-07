using RogueLibsCore;
using System;

namespace ResistanceHR.Challenges
{
    public abstract class C_ResistanceHR : MutatorUnlock
    {
        public C_ResistanceHR(string name) : base(name, true) { }

        public static string DisplayName(Type type, string custom = null) =>
            "[RHR] " +
            (type.Namespace).Split('.')[2].Replace('_', ' ') +
            " - " +
            (custom ?? (type.Name).Replace('_', ' '));
    }
}