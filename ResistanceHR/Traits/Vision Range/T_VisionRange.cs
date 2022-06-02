namespace ResistanceHR.Traits.Vision_Range
{
    public abstract class T_VisionRange : T_ResistanceHR
    {
        public static GameController GC => GameController.gameController;

        public T_VisionRange() : base() { }

        public abstract float ZoomLevel { get; }
        public static float PlayerZoomFactor =>
            GC.splitScreen ? 0.8f :
            GC.fourPlayerMode ? 0.6f :
            1.00f;
    }
}
