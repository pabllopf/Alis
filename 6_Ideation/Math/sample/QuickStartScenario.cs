

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Sample
{
    /// <summary>
    ///     Math helper scenario for sample programs.
    /// </summary>
    internal static class QuickStartScenario
    {
        /// <summary>
        ///     Computes squared distance in 2D without square root cost.
        /// </summary>
        /// <param name="from">Start position.</param>
        /// <param name="to">End position.</param>
        /// <returns>The squared distance value.</returns>
        internal static float DistanceSquared(Vector2F from, Vector2F to)
        {
            Vector2F delta = to - from;
            return (delta.X * delta.X) + (delta.Y * delta.Y);
        }
    }
}
