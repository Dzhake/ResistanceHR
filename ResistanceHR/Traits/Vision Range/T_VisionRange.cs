using RogueLibsCore;

namespace ResistanceHR.Traits.Vision_Range
{
    public abstract class T_VisionRange : T_ResistanceHR
    {
        public static GameController GC => GameController.gameController;

        public T_VisionRange() : base() { }

        protected abstract float ZoomLevel { get; }
        protected static float PlayerZoomFactor =>
            GC.splitScreen ? 0.8f :
            GC.fourPlayerMode ? 0.6f :
            1.00f;

        public static float GetZoomLevel (Agent agent)
        {
            float zoom = PlayerZoomFactor;

            foreach (T_VisionRange trait in agent.GetTraits<T_VisionRange>())
                zoom *= trait.ZoomLevel;

            return zoom;
        }
    }
}
