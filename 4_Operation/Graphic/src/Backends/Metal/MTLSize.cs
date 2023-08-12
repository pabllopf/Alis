using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl size
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSize
    {
        /// <summary>
        /// The width
        /// </summary>
        public UIntPtr Width;
        /// <summary>
        /// The height
        /// </summary>
        public UIntPtr Height;
        /// <summary>
        /// The depth
        /// </summary>
        public UIntPtr Depth;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLSize"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        public MTLSize(uint width, uint height, uint depth)
        {
            Width = (UIntPtr)width;
            Height = (UIntPtr)height;
            Depth = (UIntPtr)depth;
        }
    }
}