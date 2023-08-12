namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl sampler address mode enum
    /// </summary>
    public enum MTLSamplerAddressMode
    {
        /// <summary>
        /// The clamp to edge mtl sampler address mode
        /// </summary>
        ClampToEdge = 0,
        /// <summary>
        /// The mirror clamp to edge mtl sampler address mode
        /// </summary>
        MirrorClampToEdge = 1,
        /// <summary>
        /// The repeat mtl sampler address mode
        /// </summary>
        Repeat = 2,
        /// <summary>
        /// The mirror repeat mtl sampler address mode
        /// </summary>
        MirrorRepeat = 3,
        /// <summary>
        /// The clamp to zero mtl sampler address mode
        /// </summary>
        ClampToZero = 4,
        /// <summary>
        /// The clamp to border color mtl sampler address mode
        /// </summary>
        ClampToBorderColor = 5,
    }
}