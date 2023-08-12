namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl stencil operation enum
    /// </summary>
    public enum MTLStencilOperation
    {
        /// <summary>
        /// The keep mtl stencil operation
        /// </summary>
        Keep = 0,
        /// <summary>
        /// The zero mtl stencil operation
        /// </summary>
        Zero = 1,
        /// <summary>
        /// The replace mtl stencil operation
        /// </summary>
        Replace = 2,
        /// <summary>
        /// The increment clamp mtl stencil operation
        /// </summary>
        IncrementClamp = 3,
        /// <summary>
        /// The decrement clamp mtl stencil operation
        /// </summary>
        DecrementClamp = 4,
        /// <summary>
        /// The invert mtl stencil operation
        /// </summary>
        Invert = 5,
        /// <summary>
        /// The increment wrap mtl stencil operation
        /// </summary>
        IncrementWrap = 6,
        /// <summary>
        /// The decrement wrap mtl stencil operation
        /// </summary>
        DecrementWrap = 7,
    }
}