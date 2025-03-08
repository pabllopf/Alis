using System;

namespace Alis.Benchmark.InterfaceVsAbstract.Instancies
{
    /// <summary>
    /// The circle interface class
    /// </summary>
    /// <seealso cref="IShape"/>
    public class CircleInterface : IShape
    {
        /// <summary>
        /// The radius
        /// </summary>
        private float radius;
        /// <summary>
        /// Initializes a new instance of the <see cref="CircleInterface"/> class
        /// </summary>
        /// <param name="r">The </param>
        public CircleInterface(float r) => radius = r;
        /// <summary>
        /// Gets the area
        /// </summary>
        /// <returns>The float</returns>
        public float GetArea() => MathF.PI * radius * radius;
    }
}