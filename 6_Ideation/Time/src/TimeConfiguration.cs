using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Time
    {
        /// <summary>
        ///     The time class
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TimeConfiguration(
            float fixedTimeStep,
            float maximumAllowedTimeStep,
            float timeScale)
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="TimeConfiguration"/> class
            /// </summary>
            public TimeConfiguration() : this(fixedTimeStep: 0.016f,  maximumAllowedTimeStep: 0.25f,  timeScale: 1.0f)
            {
            }
            
            /// <summary>
            /// Gets the value of the fixed time step
            /// </summary>
            public readonly float FixedTimeStep = fixedTimeStep;

            /// <summary>
            /// Gets the value of the maximum allowed time step
            /// </summary>
            public readonly float MaximumAllowedTimeStep = maximumAllowedTimeStep;

            /// <summary>
            /// Gets the value of the time scale
            /// </summary>
            public readonly float TimeScale = timeScale;
        }
    }