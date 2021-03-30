//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TimeManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    
    /// <summary>Manage the time in the game.</summary>
    public class TimeManager
    {
        /// <summary>The current</summary>
        [AllowNull]
        private static TimeManager current;

        /// <summary>The time step</summary>
        [NotNull]
        private float timeStep;

        /// <summary>The time scale</summary>
        [NotNull]
        private float timeScale;

        /// <summary>The maximum frame rate</summary>
        [NotNull]
        private float frameRate;

        /// <summary>The limit frame rate</summary>
        [NotNull]
        private bool limitFrameRate;

        /// <summary>The watch</summary>
        [NotNull]
        private Stopwatch watch;

        /// <summary>The target elapsed time</summary>
        [NotNull]
        private TimeSpan targetElapsedTime;

        /// <summary>Initializes a new instance of the <see cref="TimeManager" /> class.</summary>
        /// <param name="timeStep">The time step.</param>
        public TimeManager(float timeStep)
        {
            this.timeStep = timeStep;
            this.timeScale = 1.0f;
            frameRate = 0;
            limitFrameRate = false;

            watch = new Stopwatch();
            watch.Start();

            current = this;
        }

        /// <summary>Initializes a new instance of the <see cref="TimeManager" /> class.</summary>
        /// <param name="timeStep">The time step.</param>
        /// <param name="timeScale">The time scale.</param>
        public TimeManager(float timeStep, float timeScale)
        {
            this.timeStep = timeStep;
            this.timeScale = timeScale;
            frameRate = 0;
            limitFrameRate = false;

            watch = new Stopwatch();
            watch.Start();

            current = this;
        }

        /// <summary>Initializes a new instance of the <see cref="TimeManager" /> class.</summary>
        /// <param name="timeStep">The time step.</param>
        /// <param name="timeScale">The time scale.</param>
        /// <param name="frameRate">The frame rate.</param>
        public TimeManager(float timeStep, float timeScale, float frameRate)
        {
            this.timeStep = timeStep;
            this.timeScale = timeScale;
            this.frameRate = frameRate;
            limitFrameRate = true;

            watch = new Stopwatch();
            watch.Start();

            current = this;
        }

        /// <summary>Initializes a new instance of the <see cref="TimeManager" /> class.</summary>
        /// <param name="timeStep">The time step.</param>
        /// <param name="timeScale">The time scale.</param>
        /// <param name="frameRate">The frame rate.</param>
        /// <param name="limitFrameRate">if set to <c>true</c> [limit frame rate].</param>
        [JsonConstructor]
        public TimeManager(float timeStep, float timeScale, float frameRate, bool limitFrameRate)
        {
            this.timeStep = timeStep;
            this.timeScale = timeScale;
            this.frameRate = frameRate;
            this.limitFrameRate = limitFrameRate;

            watch = new Stopwatch();
            watch.Start();

            current = this;
        }

        /// <summary>Gets or sets the time step.</summary>
        /// <value>The time step.</value>
        [NotNull]
        [JsonProperty("_TimeStep")]
        public float TimeStep { get => timeStep; set => timeStep = value; }

        /// <summary>Gets or sets the time scale.</summary>
        /// <value>The time scale.</value>
        [NotNull]
        [JsonProperty("_TimeScale")]
        public float TimeScale { get => timeScale; set => timeScale = value; }

        /// <summary>Gets or sets the frame rate.</summary>
        /// <value>The frame rate.</value>
        [NotNull]
        [JsonProperty("_FrameRate")]
        public float FrameRate { get => frameRate; set => frameRate = value; }

        /// <summary>Gets or sets a value indicating whether [limit frame rate].</summary>
        /// <value>
        /// <c>true</c> if [limit frame rate]; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_LimitFrameRate")]
        public bool LimitFrameRate { get => limitFrameRate; set => limitFrameRate = value; }

        /// <summary>Gets the time.</summary>
        /// <value>The time.</value>
        public static float Time => (float)(TimeSpan.FromSeconds(1 / current.frameRate).TotalMilliseconds - current.watch.ElapsedMilliseconds);

        /// <summary>Determines whether [is new frame].</summary>
        /// <returns>
        /// <c>true</c> if [is new frame]; otherwise, <c>false</c>.</returns>
        [return: NotNull]
        public bool IsNewFrame() 
        {
            if (limitFrameRate)
            {
                targetElapsedTime = TimeSpan.FromSeconds(1 / frameRate);

                if (watch.ElapsedMilliseconds >= targetElapsedTime.TotalMilliseconds)
                {
                    watch.Restart();
                    return true;
                }

                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}