

using System;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The point on edge exception class
    /// </summary>
    /// <seealso cref="NotImplementedException" />
    internal class PointOnEdgeException : NotImplementedException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PointOnEdgeException" /> class
        /// </summary>
        /// <param name="message">The message</param>
        public PointOnEdgeException(string message)
            : base(message)
        {
        }
    }
}