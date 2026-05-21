

using System;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Provides mathematical constants used throughout the physics engine.
    /// </summary>
    /// <remarks>
    ///     These constants are pre-computed as float values for performance in hot paths.
    ///     The names follow common mathematical conventions: Pi (π) and Tau (τ = 2π).
    /// </remarks>
    internal static class Constant
    {
        /// <summary>
        ///     The ratio of a circle's circumference to its diameter (π ≈ 3.14159).
        /// </summary>
        public const float Pi = (float) Math.PI;

        /// <summary>
        ///     The ratio of a circle's circumference to its radius (τ = 2π ≈ 6.28318).
        ///     Also known as "tau", this constant is useful for angle calculations in full circles.
        /// </summary>
        public const float Tau = (float) (Math.PI * 2.0);
    }
}