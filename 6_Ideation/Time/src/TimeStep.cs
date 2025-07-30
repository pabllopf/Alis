using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Time
{
    /// <summary>
    /// The time step
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct TimeStep(
        float deltaTime = 0.016f,
        float deltaTimeRatio = 1.0f,
        float invertedDeltaTime = 62.5f,
        float invertedDeltaTimeZero = 62.5f,
        int positionIterations = 8,
        int velocityIterations = 3, 
        bool warmStarting = true)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeStep"/> class
        /// </summary>
        public TimeStep() : this(deltaTime: 0.016f, deltaTimeRatio: 1.0f, invertedDeltaTime: 62.5f, invertedDeltaTimeZero: 62.5f, positionIterations: 8, velocityIterations: 3, warmStarting: true)
        {
        }

        /// <summary>
        /// The delta time
        /// </summary>
        public readonly float DeltaTime  = deltaTime;
        
        /// <summary>
        /// The delta time ratio
        /// </summary>
        public readonly float DeltaTimeRatio = deltaTimeRatio;
        
        /// <summary>
        /// The inverted delta time
        /// </summary>
        public readonly float InvertedDeltaTime = invertedDeltaTime;
        
        /// <summary>
        /// The inverted delta time zero
        /// </summary>
        public readonly float InvertedDeltaTimeZero = invertedDeltaTimeZero;
        
        /// <summary>
        /// The position iterations
        /// </summary>
        public readonly int PositionIterations = positionIterations;
        
        /// <summary>
        /// The velocity iterations
        /// </summary>
        public readonly int VelocityIterations  = velocityIterations;
        
        /// <summary>
        /// The warm starting
        /// </summary>
        public readonly bool WarmStarting  = warmStarting;
    }
}