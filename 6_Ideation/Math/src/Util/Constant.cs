

namespace Alis.Core.Aspect.Math.Util
{
    /// <summary>
    ///     Provides commonly used mathematical constants for single-precision floating-point computations,
    ///     including epsilon, Euler's number, pi, logarithmic values, and tau.
    /// </summary>
    public static class Constant
    {
        /// <summary>
        ///     A very small positive epsilon value (1.192092896e-07f) used as a tolerance threshold
        ///     for floating-point comparisons and near-zero checks.
        /// </summary>
        public const float Epsilon = 1.192092896e-07f;

        /// <summary>
        ///     Euler's number (2.71828175f) representing the base of natural logarithms,
        ///     used in exponential and logarithmic mathematical operations.
        /// </summary>
        public const float Euler = 2.7182818284590452354f;

        /// <summary>Represents the mathematical constant e(2.71828175).</summary>
        public const float E = (float) System.Math.E;

        /// <summary>Represents the log base ten of e(0.4342945).</summary>
        public const float Log10E = 0.4342945f;

        /// <summary>Represents the log base two of e(1.442695).</summary>
        public const float Log2E = 1.442695f;

        /// <summary>Represents the value of pi(3.14159274).</summary>
        public const float Pi = (float) System.Math.PI;

        /// <summary>Represents the value of pi divided by two(1.57079637).</summary>
        public const float PiOver2 = (float) (System.Math.PI / 2.0);

        /// <summary>Represents the value of pi divided by four(0.7853982).</summary>
        public const float PiOver4 = (float) (System.Math.PI / 4.0);

        /// <summary>Represents the value of pi times two(6.28318548).</summary>
        public const float TwoPi = (float) (System.Math.PI * 2.0);

        /// <summary>Represents the value of pi times two(6.28318548). This is an alias of TwoPi.</summary>
        public const float Tau = TwoPi;
    }
}