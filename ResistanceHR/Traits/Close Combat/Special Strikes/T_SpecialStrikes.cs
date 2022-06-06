namespace ResistanceHR.Traits.Combat_Melee
{
    public abstract class T_SpecialStrikes : T_CombatMelee
    {
        public T_SpecialStrikes() : base() { }

        public abstract float DamageMultiplier { get; }

        public abstract bool CanHit(Agent agent);
        public abstract void OnStrike(Agent agent);
    }
}