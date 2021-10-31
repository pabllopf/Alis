namespace Alis.Core.Settings.Configurations
{
    using System.Diagnostics;

    public class Time
    {
        public Time() 
        {
            Timer = new Stopwatch();
            Timer.Start();
        }

        private Stopwatch Timer { get; set; } = new Stopwatch();

        public double FixedTime { get; set; } = 0.0f;

        public double TimeScale { get; set; } = 1.0f;

        public double FrameCount { get; set; } = 0.0f;

        public double CurrentFrame { get; set; } = 0.0f;

        public double FixedDeltaTime { get; set; } = 0.0f;

        public double MaximumFramesPerSecond { get; set; } = 60.0f;

        public double TimeStep { get; set; } = 0.0f;

        public double MaximunAllowedTimeStep { get; set; } = 30.0f;

        internal void SyncFixedDeltaTime() => FixedDeltaTime = 1_000.0f / MaximumFramesPerSecond;

        internal bool IsNewFrame() => ((FixedTime * TimeScale) / FrameCount) > FixedDeltaTime;

        internal void UpdateTimeStep() => TimeStep = MaximunAllowedTimeStep <= 0 ? 1 : 1 / MaximunAllowedTimeStep;

        internal void CounterFrames()
        {
            CurrentFrame = (FrameCount < MaximumFramesPerSecond ? FrameCount : (FrameCount % MaximumFramesPerSecond)) + 1;
            FrameCount += 1.0f;
        }

        internal void UpdateFixedTime() => FixedTime = Timer.Elapsed.TotalMilliseconds;
    }
}