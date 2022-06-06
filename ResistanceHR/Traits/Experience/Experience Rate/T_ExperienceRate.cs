namespace ResistanceHR.Traits.Experience
{
    public abstract class T_ExperienceRate : T_ResistanceHR
    {
        public T_ExperienceRate() : base() { }

        public abstract float ExperienceRate { get; }
    }
}