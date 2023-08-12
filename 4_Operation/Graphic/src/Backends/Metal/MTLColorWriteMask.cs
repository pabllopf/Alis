using System;

namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl color write mask enum
    /// </summary>
    [Flags]
    public enum MTLColorWriteMask
    {
        /// <summary>
        /// The none mtl color write mask
        /// </summary>
        None = 0,
        /// <summary>
        /// The red mtl color write mask
        /// </summary>
        Red = 1 << 3,
        /// <summary>
        /// The green mtl color write mask
        /// </summary>
        Green = 1 << 2,
        /// <summary>
        /// The blue mtl color write mask
        /// </summary>
        Blue = 1 << 1,
        /// <summary>
        /// The alpha mtl color write mask
        /// </summary>
        Alpha = 1 << 0,
        /// <summary>
        /// The all mtl color write mask
        /// </summary>
        All = Red | Green | Blue | Alpha,
    }
}