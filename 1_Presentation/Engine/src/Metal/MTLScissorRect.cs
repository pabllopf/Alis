using System;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl scissor rect
    /// </summary>
    public struct MTLScissorRect
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
        /// The width
        /// </summary>
        public UIntPtr width;
        /// <summary>
        /// The height
        /// </summary>
        public UIntPtr height;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLScissorRect"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public MTLScissorRect(uint x, uint y, uint width, uint height)
        {
            this.x = (UIntPtr)x;
            this.y = (UIntPtr)y;
            this.width = (UIntPtr)width;
            this.height = (UIntPtr)height;
        }
    }
}