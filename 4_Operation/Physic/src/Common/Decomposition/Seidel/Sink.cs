

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The sink class
    /// </summary>
    /// <seealso cref="Node" />
    internal class Sink : Node
    {
        /// <summary>
        ///     The trapezoid
        /// </summary>
        public readonly Trapezoid Trapezoid;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sink" /> class
        /// </summary>
        /// <param name="trapezoid">The trapezoid</param>
        internal Sink(Trapezoid trapezoid)
            : base(null, null)
        {
            Trapezoid = trapezoid;
            trapezoid.Sink = this;
        }

        /// <summary>
        ///     Isinks the trapezoid
        /// </summary>
        /// <param name="trapezoid">The trapezoid</param>
        /// <returns>The sink</returns>
        public static Sink Isink(Trapezoid trapezoid)
        {
            if (trapezoid.Sink == null)
            {
                return new Sink(trapezoid);
            }

            return trapezoid.Sink;
        }

        /// <summary>
        ///     Locates the edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <returns>The sink</returns>
        public override Sink Locate(Edge s) => this;
    }
}