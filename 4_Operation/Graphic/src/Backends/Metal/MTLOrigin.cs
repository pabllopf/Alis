using System;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl origin
    /// </summary>
    public struct MTLOrigin
    {
        /// <summary>
        /// The 
        /// </summary>
        public UIntPtr x;
        /// <summary>
        /// The 
        /// </summary>
        public UIntPtr y;
        /// <summary>
        /// The 
        /// </summary>
        public UIntPtr z;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLOrigin"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        public MTLOrigin(uint x, uint y, uint z)
        {
            this.x = (UIntPtr)x;
            this.y = (UIntPtr)y;
            this.z = (UIntPtr)z;
        }
    }
}