

using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Systems.Configuration.Time;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager.Time
{
    /// <summary>
    ///     Provides an interface to get time information.
    /// </summary>
    public class TimeManager : AManager
    {
        /// <summary>
        ///     The milliseconds in second
        /// </summary>
        public readonly int MillisecondsInSecond = 1000;

        /// <summary>
        ///     The one second
        /// </summary>
        public readonly double OneSecond = 1.0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeManager" /> class
        /// </summary>
        public TimeManager(Context context) : base(context)
        {
            Clock = new Clock();
            Clock.Start();
        }

        /// <summary>
        ///     Gets or sets the value of the configuration
        /// </summary>
        public TimeSetting Setting { get; } = new TimeSetting();

        /// <summary>
        ///     Gets the value of the clock
        /// </summary>
        public Clock Clock { get; set; }

        /// <summary>
        ///     The interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public float DeltaTime { get; set; }

        /// <summary>
        ///     The interval in seconds at which physics and other fixed frame rate updateS.
        /// </summary>
        public float FixedDeltaTime { get; set; }

        /// <summary>
        ///     The time since the last FixedUpdate started (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedTime { get; set; }

        /// <summary>
        ///     The double precision time since the last FixedUpdate started (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double FixedTimeAsDouble { get; set; }

        /// <summary>
        ///     The timeScale-independent interval in seconds from the last Runtime.FixedUpdate() phase to the current one (Read
        ///     Only).
        /// </summary>
        public float FixedUnscaledDeltaTime { get; set; }

        /// <summary>
        ///     The timeScale-independent time at the beginning of the last Runtime.FixedUpdate() phase (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedUnscaledTime { get; set; }

        /// <summary>
        ///     The double precision timeScale-independent time at the beginning of the last FixedUpdate (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double FixedUnscaledTimeAsDouble { get; set; }

        /// <summary>
        ///     The total number of frames since the start of the game (Read Only).
        /// </summary>
        public float FrameCount { get; set; }

        /// <summary>
        ///     Gets or sets the value of the total frames
        /// </summary>
        public int TotalFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the average frames
        /// </summary>
        public int AverageFrames { get; set; }

        /// <summary>
        ///     Returns true if called inside a fixed time step callback (like Runtime FixedUpdate), otherwise returns false.
        /// </summary>
        public bool InFixedTimeStep { get; set; }

        /// <summary>
        ///     The maximum value of TimeManager.DeltaTime in any given frame.
        ///     This is a time in seconds that limits the increase of TimeManager.time between two frames.
        /// </summary>
        public float MaximumDeltaTime { get; set; }

        /// <summary>
        ///     The real time in seconds since the game started (Read Only).
        /// </summary>
        public float RealtimeSinceStartup => (float) Clock.Elapsed.TotalSeconds;

        /// <summary>
        ///     The real time in seconds since the game started (Read Only).
        ///     Double precision version of realtimeSinceStartup.
        /// </summary>
        public double RealtimeSinceStartupAsDouble => Clock.Elapsed.TotalSeconds;

        /// <summary>
        ///     A smoothed out TimeManager.DeltaTime (Read Only).
        /// </summary>
        public float SmoothDeltaTime { get; set; }

        /// <summary>
        ///     The time at the beginning of this frame (Read Only).
        /// </summary>
        public float Time { get; set; }

        /// <summary>
        ///     The double precision time at the beginning of this frame (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double TimeAsDouble { get; set; }

        /// <summary>
        ///     The scale at which time passes.
        /// </summary>
        public float TimeScale { get; set; } = 1f;

        /// <summary>
        ///     The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public float UnscaledDeltaTime { get; set; }

        /// <summary>
        ///     The timeScale-independent time for this frame (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public float UnscaledTime { get; set; }

        /// <summary>
        ///     The double precision timeScale-independent time for this frame (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double UnscaledTimeAsDouble { get; set; }
    }
}