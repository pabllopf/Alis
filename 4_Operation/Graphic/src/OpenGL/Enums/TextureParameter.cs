namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The texture parameter enum
    /// </summary>
    public enum TextureParameter
    {
        /// <summary>
        ///     The nearest texture parameter
        /// </summary>
        Nearest = 0x2600,

        /// <summary>
        ///     The linear texture parameter
        /// </summary>
        Linear = 0x2601,

        /// <summary>
        ///     The nearest mip map nearest texture parameter
        /// </summary>
        NearestMipMapNearest = 0x2700,

        /// <summary>
        ///     The linear mip map nearest texture parameter
        /// </summary>
        LinearMipMapNearest = 0x2701,

        /// <summary>
        ///     The nearest mip map linear texture parameter
        /// </summary>
        NearestMipMapLinear = 0x2702,

        /// <summary>
        ///     The linear mip map linear texture parameter
        /// </summary>
        LinearMipMapLinear = 0x2703,

        /// <summary>
        ///     The clamp to edge texture parameter
        /// </summary>
        ClampToEdge = 0x812F,

        /// <summary>
        ///     The clamp to border texture parameter
        /// </summary>
        ClampToBorder = 0x812D,

        /// <summary>
        ///     The mirror clamp to edge texture parameter
        /// </summary>
        MirrorClampToEdge = 0x8743,

        /// <summary>
        ///     The mirrored repeat texture parameter
        /// </summary>
        MirroredRepeat = 0x8370,

        /// <summary>
        ///     The repeat texture parameter
        /// </summary>
        Repeat = 0x2901,

        /// <summary>
        ///     The red texture parameter
        /// </summary>
        Red = 0x1903,

        /// <summary>
        ///     The green texture parameter
        /// </summary>
        Green = 0x1904,

        /// <summary>
        ///     The blue texture parameter
        /// </summary>
        Blue = 0x1905,

        /// <summary>
        ///     The alpha texture parameter
        /// </summary>
        Alpha = 0x1906,

        /// <summary>
        ///     The zero texture parameter
        /// </summary>
        Zero = 0,

        /// <summary>
        ///     The one texture parameter
        /// </summary>
        One = 1,

        /// <summary>
        ///     The compare ref to texture texture parameter
        /// </summary>
        CompareRefToTexture = 0x884E,

        /// <summary>
        ///     The none texture parameter
        /// </summary>
        None = 0,

        /// <summary>
        ///     The stencil index texture parameter
        /// </summary>
        StencilIndex = 0x1901,

        /// <summary>
        ///     The depth component texture parameter
        /// </summary>
        DepthComponent = 0x1902,

        /// <summary>
        ///     The max anisotropy ext texture parameter
        /// </summary>
        MaxAnisotropyExt = 0x84FE
    }
}