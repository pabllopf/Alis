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
        /// <summary>The time step</summary>
        [NotNull]
        private float timeStep = 0.02f;

        /// <summary>The maximum time per frame</summary>
        [NotNull]
        private float maxTimePerFrame = 0.03f;

        /// <summary>The time scale</summary>
        [NotNull]
        private float timeScale = 1.0f;

        /// <summary>The minimum frame rate</summary>
        [NotNull]
        private float minFrameRate = 30.0f;

        /// <summary>The maximum frame rate</summary>
        [NotNull]
        private float maxFrameRate = 60.0f;

        /// <summary>The frame counter</summary>
        [NotNull]
        private int frameCounter;

        /// <summary>The watch</summary>
        [NotNull]
        private Stopwatch watch;

        /// <summary>The frame rate</summary>
        [NotNull]
        private double frameRate;

        /// <summary>The second counetr</summary>
        [NotNull]
        private double secondCounter;

        /// <summary>Initializes a new instance of the <see cref="TimeManager" /> class.</summary>
        /// <param name="timeStep">The time step.</param>
        /// <param name="maxTimePerFrame">The maximum time per frame.</param>
        /// <param name="timeScale">The time scale.</param>
        /// <param name="minFrameRate">The minimum frame rate.</param>
        /// <param name="maxFrameRate">The maximum frame rate.</param>
        [JsonConstructor]
        public TimeManager([NotNull] float timeStep, [NotNull] float maxTimePerFrame, [NotNull] float timeScale, [NotNull] float minFrameRate, [NotNull] float maxFrameRate)
        {
            this.timeStep = timeStep;
            this.maxTimePerFrame = maxTimePerFrame;
            this.timeScale = timeScale;
            this.minFrameRate = minFrameRate;
            this.maxFrameRate = maxFrameRate;

            frameRate = maxFrameRate;

            frameCounter = 0;
            watch = new Stopwatch();
            watch.Start();
        }

        /// <summary>Gets or sets the time step.</summary>
        /// <value>The time step.</value>
        [NotNull]
        [JsonProperty("TimeStep_")]
        public float TimeStep { get => timeStep; set => timeStep = value; }

        /// <summary>Gets or sets the maximum time per frame.</summary>
        /// <value>The maximum time per frame.</value>
        [NotNull]
        [JsonProperty("MaxTimePerFrame_")]
        public float MaxTimePerFrame { get => maxTimePerFrame; set => maxTimePerFrame = value; }

        /// <summary>Gets or sets the time scale.</summary>
        /// <value>The time scale.</value>
        [NotNull]
        [JsonProperty("TimeScale_")]
        public float TimeScale { get => timeScale; set => timeScale = value; }

        /// <summary>Gets or sets the minimum frame rate.</summary>
        /// <value>The minimum frame rate.</value>
        [NotNull]
        [JsonProperty("MinFrameRate_")]
        public float MinFrameRate { get => minFrameRate; set => minFrameRate = value; }
        
        /// <summary>Gets or sets the maximum frame rate.</summary>
        /// <value>The maximum frame rate.</value>
        [NotNull]
        [JsonProperty("MaxFrameRate_")]
        public float MaxFrameRate { get => maxFrameRate; set => maxFrameRate = value; }

        /// <summary>Determines whether [is new frame].</summary>
        /// <returns>
        /// <c>true</c> if [is new frame]; otherwise, <c>false</c>.</returns>
        [return: NotNull]
        public bool IsNewFrame() 
        {
            frameCounter++;
            frameRate = (frameCounter / ((double)watch.Elapsed.TotalMilliseconds)) * timeScale;

            if (frameRate >= maxFrameRate) 
            {
                frameCounter = 0;
                watch.Restart();
                
                return true;
            }

            return false;
        }

        /// <summary>Determines whether [is new second].</summary>
        /// <returns>
        /// <c>true</c> if [is new second]; otherwise, <c>false</c>.</returns>
        [return: NotNull]
        public bool IsNewSecond() 
        {
            secondCounter = (double)watch.ElapsedMilliseconds / 1000;

            if (secondCounter >= timeStep)
            {
                watch.Reset();
                secondCounter = 0;
                return true;
            }

            return false;
        }
    }
}