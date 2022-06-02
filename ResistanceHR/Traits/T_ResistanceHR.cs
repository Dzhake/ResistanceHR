using RogueLibsCore;
using System;

namespace ResistanceHR.Traits
{
    public abstract class T_ResistanceHR : CustomTrait
    {
        public static string DisplayName(Type type, string custom = null) =>
            (custom ?? (type.Name).Replace('_', ' ').Replace("2", " +"));

        public string TextName => DisplayName(GetType());
    }
}
