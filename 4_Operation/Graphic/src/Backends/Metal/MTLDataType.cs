namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl data type enum
    /// </summary>
    public enum MTLDataType
    {
        /// <summary>
        /// The none mtl data type
        /// </summary>
        None = 0,
        /// <summary>
        /// The struct mtl data type
        /// </summary>
        Struct = 1,
        /// <summary>
        /// The array mtl data type
        /// </summary>
        Array = 2,
        /// <summary>
        /// The float mtl data type
        /// </summary>
        Float = 3,
        /// <summary>
        /// The float mtl data type
        /// </summary>
        Float2 = 4,
        /// <summary>
        /// The float mtl data type
        /// </summary>
        Float3 = 5,
        /// <summary>
        /// The float mtl data type
        /// </summary>
        Float4 = 6,
        /// <summary>
        /// The float 2x mtl data type
        /// </summary>
        Float2x2 = 7,
        /// <summary>
        /// The float 2x mtl data type
        /// </summary>
        Float2x3 = 8,
        /// <summary>
        /// The float 2x mtl data type
        /// </summary>
        Float2x4 = 9,
        /// <summary>
        /// The float 3x mtl data type
        /// </summary>
        Float3x2 = 10,
        /// <summary>
        /// The float 3x mtl data type
        /// </summary>
        Float3x3 = 11,
        /// <summary>
        /// The float 3x mtl data type
        /// </summary>
        Float3x4 = 12,
        /// <summary>
        /// The float 4x mtl data type
        /// </summary>
        Float4x2 = 13,
        /// <summary>
        /// The float 4x mtl data type
        /// </summary>
        Float4x3 = 14,
        /// <summary>
        /// The float 4x mtl data type
        /// </summary>
        Float4x4 = 15,
        /// <summary>
        /// The half mtl data type
        /// </summary>
        Half = 16,
        /// <summary>
        /// The half mtl data type
        /// </summary>
        Half2 = 17,
        /// <summary>
        /// The half mtl data type
        /// </summary>
        Half3 = 18,
        /// <summary>
        /// The half mtl data type
        /// </summary>
        Half4 = 19,
        /// <summary>
        /// The half 2x mtl data type
        /// </summary>
        Half2x2 = 20,
        /// <summary>
        /// The half 2x mtl data type
        /// </summary>
        Half2x3 = 21,
        /// <summary>
        /// The half 2x mtl data type
        /// </summary>
        Half2x4 = 22,
        /// <summary>
        /// The half 3x mtl data type
        /// </summary>
        Half3x2 = 23,
        /// <summary>
        /// The half 3x mtl data type
        /// </summary>
        Half3x3 = 24,
        /// <summary>
        /// The half 3x mtl data type
        /// </summary>
        Half3x4 = 25,
        /// <summary>
        /// The half 4x mtl data type
        /// </summary>
        Half4x2 = 26,
        /// <summary>
        /// The half 4x mtl data type
        /// </summary>
        Half4x3 = 27,
        /// <summary>
        /// The half 4x mtl data type
        /// </summary>
        Half4x4 = 28,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        Int = 29,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        Int2 = 30,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        Int3 = 31,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        Int4 = 32,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        UInt = 33,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        UInt2 = 34,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        UInt3 = 35,
        /// <summary>
        /// The int mtl data type
        /// </summary>
        UInt4 = 36,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        Short = 37,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        Short2 = 38,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        Short3 = 39,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        Short4 = 40,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        UShort = 41,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        UShort2 = 42,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        UShort3 = 43,
        /// <summary>
        /// The short mtl data type
        /// </summary>
        UShort4 = 44,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        Char = 45,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        Char2 = 46,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        Char3 = 47,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        Char4 = 48,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        UChar = 49,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        UChar2 = 50,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        UChar3 = 51,
        /// <summary>
        /// The char mtl data type
        /// </summary>
        UChar4 = 52,
        /// <summary>
        /// The bool mtl data type
        /// </summary>
        Bool = 53,
        /// <summary>
        /// The bool mtl data type
        /// </summary>
        Bool2 = 54,
        /// <summary>
        /// The bool mtl data type
        /// </summary>
        Bool3 = 55,
        /// <summary>
        /// The bool mtl data type
        /// </summary>
        Bool4 = 56,
        /// <summary>
        /// The texture mtl data type
        /// </summary>
        Texture = 58,
        /// <summary>
        /// The sampler mtl data type
        /// </summary>
        Sampler = 59,
        /// <summary>
        /// The pointer mtl data type
        /// </summary>
        Pointer = 60,
        /// <summary>
        /// The unorm mtl data type
        /// </summary>
        R8Unorm = 62,
        /// <summary>
        /// The snorm mtl data type
        /// </summary>
        R8Snorm = 63,
        /// <summary>
        /// The 16 unorm mtl data type
        /// </summary>
        R16Unorm = 64,
        /// <summary>
        /// The 16 snorm mtl data type
        /// </summary>
        R16Snorm = 65,
        /// <summary>
        /// The rg unorm mtl data type
        /// </summary>
        RG8Unorm = 66,
        /// <summary>
        /// The rg snorm mtl data type
        /// </summary>
        RG8Snorm = 67,
        /// <summary>
        /// The rg 16 unorm mtl data type
        /// </summary>
        RG16Unorm = 68,
        /// <summary>
        /// The rg 16 snorm mtl data type
        /// </summary>
        RG16Snorm = 69,
        /// <summary>
        /// The rgba unorm mtl data type
        /// </summary>
        RGBA8Unorm = 70,
        /// <summary>
        /// The rgba8unorm srgb mtl data type
        /// </summary>
        RGBA8Unorm_sRGB = 71,
        /// <summary>
        /// The rgba snorm mtl data type
        /// </summary>
        RGBA8Snorm = 72,
        /// <summary>
        /// The rgba 16 unorm mtl data type
        /// </summary>
        RGBA16Unorm = 73,
        /// <summary>
        /// The rgba 16 snorm mtl data type
        /// </summary>
        RGBA16Snorm = 74,
        /// <summary>
        /// The rgb 10 unorm mtl data type
        /// </summary>
        RGB10A2Unorm = 75,
        /// <summary>
        /// The rgb float mtl data type
        /// </summary>
        RGB9E5Float = 77,
        /// <summary>
        /// The rg 11 10 float mtl data type
        /// </summary>
        RG11B10Float = 76,
    }
}
