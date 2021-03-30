//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="TimeManager.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    
    /// <summary>Manage the time in the game.</summary>
    public class TimeManager
    {
        /// <summary>The time step</summary>
        [NotNull]
        private float timeStep = 0.01f;

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
        }

        /// <summary>Gets or sets the time step.</summary>
        /// <value>The time step.</value>
        [NotNull]
        [JsonProperty("TimeStep")]
        public float TimeStep { get => timeStep; set => timeStep = value; }

        /// <summary>Gets or sets the maximum time per frame.</summary>
        /// <value>The maximum time per frame.</value>
        [NotNull]
        [JsonProperty("MaxTimePerFrame")]
        public float MaxTimePerFrame { get => maxTimePerFrame; set => maxTimePerFrame = value; }

        /// <summary>Gets or sets the time scale.</summary>
        /// <value>The time scale.</value>
        [NotNull]
        [JsonProperty("TimeScale")]
        public float TimeScale { get => timeScale; set => timeScale = value; }

        /// <summary>Gets or sets the minimum frame rate.</summary>
        /// <value>The minimum frame rate.</value>
        [NotNull]
        [JsonProperty("MinFrameRate")]
        public float MinFrameRate { get => minFrameRate; set => minFrameRate = value; }
        
        /// <summary>Gets or sets the maximum frame rate.</summary>
        /// <value>The maximum frame rate.</value>
        [NotNull]
        [JsonProperty("MaxFrameRate")]
        public float MaxFrameRate { get => maxFrameRate; set => maxFrameRate = value; }
    }
}
