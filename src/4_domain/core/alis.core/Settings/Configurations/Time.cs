using System.Diagnostics;

namespace Alis.Core.Settings.Configurations
{
    public class Time
    {
        public Time()
        {
            Timer = new Stopwatch();
            Timer.Start();
        }

        private Stopwatch Timer { get; } = new();

        public double FixedTime { get; set; }

        public double TimeScale { get; set; } = 1.0f;

        public double FrameCount { get; set; }

        public double CurrentFrame { get; set; }

        public double FixedDeltaTime { get; set; }

        public double MaximumFramesPerSecond { get; set; } = 60.0f;

        public double TimeStep { get; set; }

        public double MaximunAllowedTimeStep { get; set; } = 30.0f;

        internal void SyncFixedDeltaTime()
        {
            FixedDeltaTime = 1_000.0f / MaximumFramesPerSecond;
        }

        internal bool IsNewFrame()
        {
            return FixedTime * TimeScale / FrameCount > FixedDeltaTime;
        }

        internal void UpdateTimeStep()
        {
            TimeStep = MaximunAllowedTimeStep <= 0 ? 1 : 1 / MaximunAllowedTimeStep;
        }

        internal void CounterFrames()
        {
            CurrentFrame = (FrameCount < MaximumFramesPerSecond ? FrameCount : FrameCount % MaximumFramesPerSecond) + 1;
            FrameCount += 1.0f;
        }

        internal void UpdateFixedTime()
        {
            FixedTime = Timer.Elapsed.TotalMilliseconds;
        }
    }
}