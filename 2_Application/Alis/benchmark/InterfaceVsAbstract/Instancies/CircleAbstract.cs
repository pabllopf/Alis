using System;

namespace Alis.Benchmark.InterfaceVsAbstract.Instancies
{
    /// <summary>
    /// The circle abstract class
    /// </summary>
    /// <seealso cref="Shape"/>
    public class CircleAbstract : Shape
    {
        /// <summary>
        /// The radius
        /// </summary>
        private float radius;
        /// <summary>
        /// Initializes a new instance of the <see cref="CircleAbstract"/> class
        /// </summary>
        /// <param name="r">The </param>
        public CircleAbstract(float r) => radius = r;
        /// <summary>
        /// Gets the area
        /// </summary>
        /// <returns>The float</returns>
        public override float GetArea() => MathF.PI * radius * radius;
    }
}