namespace Alis.Core.Graphic.Backends.Metal
{
    /// <summary>
    /// The mtl pixel format enum
    /// </summary>
    public enum MTLPixelFormat : uint
    {
        /// <summary>
        /// The invalid mtl pixel format
        /// </summary>
        Invalid = 0,

        /* Normal 8 bit formats */

        /// <summary>
        /// The unorm mtl pixel format
        /// </summary>
        A8Unorm = 1,

        /// <summary>
        /// The unorm mtl pixel format
        /// </summary>
        R8Unorm = 10,
        /// <summary>
        /// The r8unorm srgb mtl pixel format
        /// </summary>
        R8Unorm_sRGB = 11,

        /// <summary>
        /// The snorm mtl pixel format
        /// </summary>
        R8Snorm = 12,
        /// <summary>
        /// The uint mtl pixel format
        /// </summary>
        R8Uint = 13,
        /// <summary>
        /// The sint mtl pixel format
        /// </summary>
        R8Sint = 14,

        /* Normal 16 bit formats */

        /// <summary>
        /// The 16 unorm mtl pixel format
        /// </summary>
        R16Unorm = 20,
        /// <summary>
        /// The 16 snorm mtl pixel format
        /// </summary>
        R16Snorm = 22,
        /// <summary>
        /// The 16 uint mtl pixel format
        /// </summary>
        R16Uint = 23,
        /// <summary>
        /// The 16 sint mtl pixel format
        /// </summary>
        R16Sint = 24,
        /// <summary>
        /// The 16 float mtl pixel format
        /// </summary>
        R16Float = 25,

        /// <summary>
        /// The rg unorm mtl pixel format
        /// </summary>
        RG8Unorm = 30,
        /// <summary>
        /// The rg8unorm srgb mtl pixel format
        /// </summary>
        RG8Unorm_sRGB = 31,
        /// <summary>
        /// The rg snorm mtl pixel format
        /// </summary>
        RG8Snorm = 32,
        /// <summary>
        /// The rg uint mtl pixel format
        /// </summary>
        RG8Uint = 33,
        /// <summary>
        /// The rg sint mtl pixel format
        /// </summary>
        RG8Sint = 34,

        /* Packed 16 bit formats */

        /// <summary>
        /// The unorm mtl pixel format
        /// </summary>
        B5G6R5Unorm = 40,
        /// <summary>
        /// The bgr unorm mtl pixel format
        /// </summary>
        A1BGR5Unorm = 41,
        /// <summary>
        /// The abgr unorm mtl pixel format
        /// </summary>
        ABGR4Unorm = 42,
        /// <summary>
        /// The bgr unorm mtl pixel format
        /// </summary>
        BGR5A1Unorm = 43,

        /* Normal 32 bit formats */

        /// <summary>
        /// The 32 uint mtl pixel format
        /// </summary>
        R32Uint = 53,
        /// <summary>
        /// The 32 sint mtl pixel format
        /// </summary>
        R32Sint = 54,
        /// <summary>
        /// The 32 float mtl pixel format
        /// </summary>
        R32Float = 55,

        /// <summary>
        /// The rg 16 unorm mtl pixel format
        /// </summary>
        RG16Unorm = 60,
        /// <summary>
        /// The rg 16 snorm mtl pixel format
        /// </summary>
        RG16Snorm = 62,
        /// <summary>
        /// The rg 16 uint mtl pixel format
        /// </summary>
        RG16Uint = 63,
        /// <summary>
        /// The rg 16 sint mtl pixel format
        /// </summary>
        RG16Sint = 64,
        /// <summary>
        /// The rg 16 float mtl pixel format
        /// </summary>
        RG16Float = 65,

        /// <summary>
        /// The rgba unorm mtl pixel format
        /// </summary>
        RGBA8Unorm = 70,
        /// <summary>
        /// The rgba8unorm srgb mtl pixel format
        /// </summary>
        RGBA8Unorm_sRGB = 71,
        /// <summary>
        /// The rgba snorm mtl pixel format
        /// </summary>
        RGBA8Snorm = 72,
        /// <summary>
        /// The rgba uint mtl pixel format
        /// </summary>
        RGBA8Uint = 73,
        /// <summary>
        /// The rgba sint mtl pixel format
        /// </summary>
        RGBA8Sint = 74,

        /// <summary>
        /// The bgra unorm mtl pixel format
        /// </summary>
        BGRA8Unorm = 80,
        /// <summary>
        /// The bgra8unorm srgb mtl pixel format
        /// </summary>
        BGRA8Unorm_sRGB = 81,

        /* Packed 32 bit formats */

        /// <summary>
        /// The rgb 10 unorm mtl pixel format
        /// </summary>
        RGB10A2Unorm = 90,
        /// <summary>
        /// The rgb 10 uint mtl pixel format
        /// </summary>
        RGB10A2Uint = 91,

        /// <summary>
        /// The rg 11 10 float mtl pixel format
        /// </summary>
        RG11B10Float = 92,
        /// <summary>
        /// The rgb float mtl pixel format
        /// </summary>
        RGB9E5Float = 93,

        /// <summary>
        /// The bgr10 xr mtl pixel format
        /// </summary>
        BGR10_XR = 554,
        /// <summary>
        /// The bgr10 xr srgb mtl pixel format
        /// </summary>
        BGR10_XR_sRGB = 555,

        /* Normal 64 bit formats */

        /// <summary>
        /// The rg 32 uint mtl pixel format
        /// </summary>
        RG32Uint = 103,
        /// <summary>
        /// The rg 32 sint mtl pixel format
        /// </summary>
        RG32Sint = 104,
        /// <summary>
        /// The rg 32 float mtl pixel format
        /// </summary>
        RG32Float = 105,

        /// <summary>
        /// The rgba 16 unorm mtl pixel format
        /// </summary>
        RGBA16Unorm = 110,
        /// <summary>
        /// The rgba 16 snorm mtl pixel format
        /// </summary>
        RGBA16Snorm = 112,
        /// <summary>
        /// The rgba 16 uint mtl pixel format
        /// </summary>
        RGBA16Uint = 113,
        /// <summary>
        /// The rgba 16 sint mtl pixel format
        /// </summary>
        RGBA16Sint = 114,
        /// <summary>
        /// The rgba 16 float mtl pixel format
        /// </summary>
        RGBA16Float = 115,

        /// <summary>
        /// The bgra10 xr mtl pixel format
        /// </summary>
        BGRA10_XR = 552,
        /// <summary>
        /// The bgra10 xr srgb mtl pixel format
        /// </summary>
        BGRA10_XR_sRGB = 553,

        /* Normal 128 bit formats */

        /// <summary>
        /// The rgba 32 uint mtl pixel format
        /// </summary>
        RGBA32Uint = 123,
        /// <summary>
        /// The rgba 32 sint mtl pixel format
        /// </summary>
        RGBA32Sint = 124,
        /// <summary>
        /// The rgba 32 float mtl pixel format
        /// </summary>
        RGBA32Float = 125,

        /* Compressed formats. */

        /* S3TC/DXT */
        /// <summary>
        /// The bc1 rgba mtl pixel format
        /// </summary>
        BC1_RGBA = 130,
        /// <summary>
        /// The bc1 rgba srgb mtl pixel format
        /// </summary>
        BC1_RGBA_sRGB = 131,
        /// <summary>
        /// The bc2 rgba mtl pixel format
        /// </summary>
        BC2_RGBA = 132,
        /// <summary>
        /// The bc2 rgba srgb mtl pixel format
        /// </summary>
        BC2_RGBA_sRGB = 133,
        /// <summary>
        /// The bc3 rgba mtl pixel format
        /// </summary>
        BC3_RGBA = 134,
        /// <summary>
        /// The bc3 rgba srgb mtl pixel format
        /// </summary>
        BC3_RGBA_sRGB = 135,

        /* RGTC */
        /// <summary>
        /// The bc4 runorm mtl pixel format
        /// </summary>
        BC4_RUnorm = 140,
        /// <summary>
        /// The bc4 rsnorm mtl pixel format
        /// </summary>
        BC4_RSnorm = 141,
        /// <summary>
        /// The bc5 rgunorm mtl pixel format
        /// </summary>
        BC5_RGUnorm = 142,
        /// <summary>
        /// The bc5 rgsnorm mtl pixel format
        /// </summary>
        BC5_RGSnorm = 143,

        /* BPTC */
        /// <summary>
        /// The bc6h rgbfloat mtl pixel format
        /// </summary>
        BC6H_RGBFloat = 150,
        /// <summary>
        /// The bc6h rgbufloat mtl pixel format
        /// </summary>
        BC6H_RGBUfloat = 151,
        /// <summary>
        /// The bc7 rgbaunorm mtl pixel format
        /// </summary>
        BC7_RGBAUnorm = 152,
        /// <summary>
        /// The bc7 rgbaunorm srgb mtl pixel format
        /// </summary>
        BC7_RGBAUnorm_sRGB = 153,

        /* PVRTC */
        /// <summary>
        /// The pvrtc rgb 2bpp mtl pixel format
        /// </summary>
        PVRTC_RGB_2BPP = 160,
        /// <summary>
        /// The pvrtc rgb 2bpp srgb mtl pixel format
        /// </summary>
        PVRTC_RGB_2BPP_sRGB = 161,
        /// <summary>
        /// The pvrtc rgb 4bpp mtl pixel format
        /// </summary>
        PVRTC_RGB_4BPP = 162,
        /// <summary>
        /// The pvrtc rgb 4bpp srgb mtl pixel format
        /// </summary>
        PVRTC_RGB_4BPP_sRGB = 163,
        /// <summary>
        /// The pvrtc rgba 2bpp mtl pixel format
        /// </summary>
        PVRTC_RGBA_2BPP = 164,
        /// <summary>
        /// The pvrtc rgba 2bpp srgb mtl pixel format
        /// </summary>
        PVRTC_RGBA_2BPP_sRGB = 165,
        /// <summary>
        /// The pvrtc rgba 4bpp mtl pixel format
        /// </summary>
        PVRTC_RGBA_4BPP = 166,
        /// <summary>
        /// The pvrtc rgba 4bpp srgb mtl pixel format
        /// </summary>
        PVRTC_RGBA_4BPP_sRGB = 167,

        /* ETC2 */
        /// <summary>
        /// The eac r11unorm mtl pixel format
        /// </summary>
        EAC_R11Unorm = 170,
        /// <summary>
        /// The eac r11snorm mtl pixel format
        /// </summary>
        EAC_R11Snorm = 172,
        /// <summary>
        /// The eac rg11unorm mtl pixel format
        /// </summary>
        EAC_RG11Unorm = 174,
        /// <summary>
        /// The eac rg11snorm mtl pixel format
        /// </summary>
        EAC_RG11Snorm = 176,
        /// <summary>
        /// The eac rgba8 mtl pixel format
        /// </summary>
        EAC_RGBA8 = 178,
        /// <summary>
        /// The eac rgba8 srgb mtl pixel format
        /// </summary>
        EAC_RGBA8_sRGB = 179,

        /// <summary>
        /// The etc2 rgb8 mtl pixel format
        /// </summary>
        ETC2_RGB8 = 180,
        /// <summary>
        /// The etc2 rgb8 srgb mtl pixel format
        /// </summary>
        ETC2_RGB8_sRGB = 181,
        /// <summary>
        /// The etc2 rgb8a1 mtl pixel format
        /// </summary>
        ETC2_RGB8A1 = 182,
        /// <summary>
        /// The etc2 rgb8a1 srgb mtl pixel format
        /// </summary>
        ETC2_RGB8A1_sRGB = 183,

        /* ASTC */
        /// <summary>
        /// The astc 4x4 srgb mtl pixel format
        /// </summary>
        ASTC_4x4_sRGB = 186,
        /// <summary>
        /// The astc 5x4 srgb mtl pixel format
        /// </summary>
        ASTC_5x4_sRGB = 187,
        /// <summary>
        /// The astc 5x5 srgb mtl pixel format
        /// </summary>
        ASTC_5x5_sRGB = 188,
        /// <summary>
        /// The astc 6x5 srgb mtl pixel format
        /// </summary>
        ASTC_6x5_sRGB = 189,
        /// <summary>
        /// The astc 6x6 srgb mtl pixel format
        /// </summary>
        ASTC_6x6_sRGB = 190,
        /// <summary>
        /// The astc 8x5 srgb mtl pixel format
        /// </summary>
        ASTC_8x5_sRGB = 192,
        /// <summary>
        /// The astc 8x6 srgb mtl pixel format
        /// </summary>
        ASTC_8x6_sRGB = 193,
        /// <summary>
        /// The astc 8x8 srgb mtl pixel format
        /// </summary>
        ASTC_8x8_sRGB = 194,
        /// <summary>
        /// The astc 10x5 srgb mtl pixel format
        /// </summary>
        ASTC_10x5_sRGB = 195,
        /// <summary>
        /// The astc 10x6 srgb mtl pixel format
        /// </summary>
        ASTC_10x6_sRGB = 196,
        /// <summary>
        /// The astc 10x8 srgb mtl pixel format
        /// </summary>
        ASTC_10x8_sRGB = 197,
        /// <summary>
        /// The astc 10x10 srgb mtl pixel format
        /// </summary>
        ASTC_10x10_sRGB = 198,
        /// <summary>
        /// The astc 12x10 srgb mtl pixel format
        /// </summary>
        ASTC_12x10_sRGB = 199,
        /// <summary>
        /// The astc 12x12 srgb mtl pixel format
        /// </summary>
        ASTC_12x12_sRGB = 200,

        /// <summary>
        /// The astc 4x4 ldr mtl pixel format
        /// </summary>
        ASTC_4x4_LDR = 204,
        /// <summary>
        /// The astc 5x4 ldr mtl pixel format
        /// </summary>
        ASTC_5x4_LDR = 205,
        /// <summary>
        /// The astc 5x5 ldr mtl pixel format
        /// </summary>
        ASTC_5x5_LDR = 206,
        /// <summary>
        /// The astc 6x5 ldr mtl pixel format
        /// </summary>
        ASTC_6x5_LDR = 207,
        /// <summary>
        /// The astc 6x6 ldr mtl pixel format
        /// </summary>
        ASTC_6x6_LDR = 208,
        /// <summary>
        /// The astc 8x5 ldr mtl pixel format
        /// </summary>
        ASTC_8x5_LDR = 210,
        /// <summary>
        /// The astc 8x6 ldr mtl pixel format
        /// </summary>
        ASTC_8x6_LDR = 211,
        /// <summary>
        /// The astc 8x8 ldr mtl pixel format
        /// </summary>
        ASTC_8x8_LDR = 212,
        /// <summary>
        /// The astc 10x5 ldr mtl pixel format
        /// </summary>
        ASTC_10x5_LDR = 213,
        /// <summary>
        /// The astc 10x6 ldr mtl pixel format
        /// </summary>
        ASTC_10x6_LDR = 214,
        /// <summary>
        /// The astc 10x8 ldr mtl pixel format
        /// </summary>
        ASTC_10x8_LDR = 215,
        /// <summary>
        /// The astc 10x10 ldr mtl pixel format
        /// </summary>
        ASTC_10x10_LDR = 216,
        /// <summary>
        /// The astc 12x10 ldr mtl pixel format
        /// </summary>
        ASTC_12x10_LDR = 217,
        /// <summary>
        /// The astc 12x12 ldr mtl pixel format
        /// </summary>
        ASTC_12x12_LDR = 218,

        /*!
         @constant GBGR422
         @abstract A pixel format where the red and green channels are subsampled horizontally.  Two pixels are stored in 32 bits, with shared red and blue values, and unique green values.
         @discussion This format is equivelent to YUY2, YUYV, yuvs, or GL_RGB_422_APPLE/GL_UNSIGNED_SHORT_8_8_REV_APPLE.   The component order, from lowest addressed byte to highest, is Y0, Cb, Y1, Cr.  There is no implicit colorspace conversion from YUV to RGB, the shader will receive (Cr, Y, Cb, 1).  422 textures must have a width that is a multiple of 2, and can only be used for 2D non-mipmap textures.  When sampling, ClampToEdge is the only usable wrap mode.
         */
        /// <summary>
        /// The gbgr 422 mtl pixel format
        /// </summary>
        GBGR422 = 240,

        /*!
         @constant BGRG422
         @abstract A pixel format where the red and green channels are subsampled horizontally.  Two pixels are stored in 32 bits, with shared red and blue values, and unique green values.
         @discussion This format is equivelent to UYVY, 2vuy, or GL_RGB_422_APPLE/GL_UNSIGNED_SHORT_8_8_APPLE. The component order, from lowest addressed byte to highest, is Cb, Y0, Cr, Y1.  There is no implicit colorspace conversion from YUV to RGB, the shader will receive (Cr, Y, Cb, 1).  422 textures must have a width that is a multiple of 2, and can only be used for 2D non-mipmap textures.  When sampling, ClampToEdge is the only usable wrap mode.
         */
        /// <summary>
        /// The bgrg 422 mtl pixel format
        /// </summary>
        BGRG422 = 241,

        /* Depth */

        /// <summary>
        /// The depth 16 unorm mtl pixel format
        /// </summary>
        Depth16Unorm = 250,
        /// <summary>
        /// The depth 32 float mtl pixel format
        /// </summary>
        Depth32Float = 252,

        /* Stencil */

        /// <summary>
        /// The stencil mtl pixel format
        /// </summary>
        Stencil8 = 253,

        /* Depth Stencil */

        /// <summary>
        /// The depth24unorm stencil8 mtl pixel format
        /// </summary>
        Depth24Unorm_Stencil8 = 255,
        /// <summary>
        /// The depth32float stencil8 mtl pixel format
        /// </summary>
        Depth32Float_Stencil8 = 260,

        /// <summary>
        /// The x32 stencil8 mtl pixel format
        /// </summary>
        X32_Stencil8 = 261,
        /// <summary>
        /// The x24 stencil8 mtl pixel format
        /// </summary>
        X24_Stencil8 = 262,
    }
}