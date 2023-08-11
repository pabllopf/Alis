namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl vertex step function enum
    /// </summary>
    public enum MTLVertexStepFunction
    {
        /// <summary>
        /// The constant mtl vertex step function
        /// </summary>
        Constant = 0,
        /// <summary>
        /// The per vertex mtl vertex step function
        /// </summary>
        PerVertex = 1,
        /// <summary>
        /// The per instance mtl vertex step function
        /// </summary>
        PerInstance = 2,
        /// <summary>
        /// The per patch mtl vertex step function
        /// </summary>
        PerPatch = 3,
        /// <summary>
        /// The per patch control point mtl vertex step function
        /// </summary>
        PerPatchControlPoint = 4,
    }
}