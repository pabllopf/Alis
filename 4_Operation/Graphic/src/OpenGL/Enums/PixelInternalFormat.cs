// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelInternalFormat.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The pixel internal format enum
    /// </summary>
    public enum PixelInternalFormat
    {
        /// <summary>
        ///     Depth component internal format (GL_DEPTH_COMPONENT)
        /// </summary>
        DepthComponent = 0x1902,

        /// <summary>
        ///     Alpha internal format (GL_ALPHA)
        /// </summary>
        Alpha = 0x1906,

        /// <summary>
        ///     RGB internal format (GL_RGB)
        /// </summary>
        Rgb = 0x1907,

        /// <summary>
        ///     RGBA internal format (GL_RGBA)
        /// </summary>
        Rgba = 0x1908,

        /// <summary>
        ///     Luminance internal format (GL_LUMINANCE)
        /// </summary>
        Luminance = 0x1909,

        /// <summary>
        ///     Luminance-alpha internal format (GL_LUMINANCE_ALPHA)
        /// </summary>
        LuminanceAlpha = 0x190A,

        /// <summary>
        ///     Packed 3-3-2 RGB internal format (GL_R3_G3_B2)
        /// </summary>
        R3G3B2 = 0x2A10,

        /// <summary>
        ///     4-bit alpha internal format (GL_ALPHA4)
        /// </summary>
        Alpha4 = 0x803B,

        /// <summary>
        ///     8-bit alpha internal format (GL_ALPHA8)
        /// </summary>
        Alpha8 = 0x803C,

        /// <summary>
        ///     12-bit alpha internal format (GL_ALPHA12)
        /// </summary>
        Alpha12 = 0x803D,

        /// <summary>
        ///     16-bit alpha internal format (GL_ALPHA16)
        /// </summary>
        Alpha16 = 0x803E,

        /// <summary>
        ///     4-bit luminance internal format (GL_LUMINANCE4)
        /// </summary>
        Luminance4 = 0x803F,

        /// <summary>
        ///     8-bit luminance internal format (GL_LUMINANCE8)
        /// </summary>
        Luminance8 = 0x8040,

        /// <summary>
        ///     12-bit luminance internal format (GL_LUMINANCE12)
        /// </summary>
        Luminance12 = 0x8041,

        /// <summary>
        ///     16-bit luminance internal format (GL_LUMINANCE16)
        /// </summary>
        Luminance16 = 0x8042,

        /// <summary>
        ///     4-bit luminance, 4-bit alpha internal format (GL_LUMINANCE4_ALPHA4)
        /// </summary>
        Luminance4Alpha4 = 0x8043,

        /// <summary>
        ///     6-bit luminance, 2-bit alpha internal format (GL_LUMINANCE6_ALPHA2)
        /// </summary>
        Luminance6Alpha2 = 0x8044,

        /// <summary>
        ///     8-bit luminance, 8-bit alpha internal format (GL_LUMINANCE8_ALPHA8)
        /// </summary>
        Luminance8Alpha8 = 0x8045,

        /// <summary>
        ///     12-bit luminance, 4-bit alpha internal format (GL_LUMINANCE12_ALPHA4)
        /// </summary>
        Luminance12Alpha4 = 0x8046,

        /// <summary>
        ///     12-bit luminance, 12-bit alpha internal format (GL_LUMINANCE12_ALPHA12)
        /// </summary>
        Luminance12Alpha12 = 0x8047,

        /// <summary>
        ///     16-bit luminance, 16-bit alpha internal format (GL_LUMINANCE16_ALPHA16)
        /// </summary>
        Luminance16Alpha16 = 0x8048,

        /// <summary>
        ///     Intensity internal format (GL_INTENSITY)
        /// </summary>
        Intensity = 0x8049,

        /// <summary>
        ///     4-bit intensity internal format (GL_INTENSITY4)
        /// </summary>
        Intensity4 = 0x804A,

        /// <summary>
        ///     8-bit intensity internal format (GL_INTENSITY8)
        /// </summary>
        Intensity8 = 0x804B,

        /// <summary>
        ///     12-bit intensity internal format (GL_INTENSITY12)
        /// </summary>
        Intensity12 = 0x804C,

        /// <summary>
        ///     16-bit intensity internal format (GL_INTENSITY16)
        /// </summary>
        Intensity16 = 0x804D,

        /// <summary>
        ///     2-bit RGB internal format, EXT (GL_RGB2_EXT)
        /// </summary>
        Rgb2Ext = 0x804E,

        /// <summary>
        ///     4-bit RGB internal format (GL_RGB4)
        /// </summary>
        Rgb4 = 0x804F,

        /// <summary>
        ///     5-bit RGB internal format (GL_RGB5)
        /// </summary>
        Rgb5 = 0x8050,

        /// <summary>
        ///     8-bit RGB internal format (GL_RGB8)
        /// </summary>
        Rgb8 = 0x8051,

        /// <summary>
        ///     10-bit RGB internal format (GL_RGB10)
        /// </summary>
        Rgb10 = 0x8052,

        /// <summary>
        ///     12-bit RGB internal format (GL_RGB12)
        /// </summary>
        Rgb12 = 0x8053,

        /// <summary>
        ///     16-bit RGB internal format (GL_RGB16)
        /// </summary>
        Rgb16 = 0x8054,

        /// <summary>
        ///     2-bit RGBA internal format (GL_RGBA2)
        /// </summary>
        Rgba2 = 0x8055,

        /// <summary>
        ///     4-bit RGBA internal format (GL_RGBA4)
        /// </summary>
        Rgba4 = 0x8056,

        /// <summary>
        ///     5-bit RGB, 1-bit alpha internal format (GL_RGB5_A1)
        /// </summary>
        Rgb5A1 = 0x8057,

        /// <summary>
        ///     8-bit RGBA internal format (GL_RGBA8)
        /// </summary>
        Rgba8 = 0x8058,

        /// <summary>
        ///     10-bit RGB, 2-bit alpha internal format (GL_RGB10_A2)
        /// </summary>
        Rgb10A2 = 0x8059,

        /// <summary>
        ///     12-bit RGBA internal format (GL_RGBA12)
        /// </summary>
        Rgba12 = 0x805A,

        /// <summary>
        ///     16-bit RGBA internal format (GL_RGBA16)
        /// </summary>
        Rgba16 = 0x805B,

        /// <summary>
        ///     4-bit dual alpha channel, SGIS (GL_DUAL_ALPHA4_SGIS)
        /// </summary>
        DualAlpha4Sgis = 0x8110,

        /// <summary>
        ///     8-bit dual alpha channel, SGIS (GL_DUAL_ALPHA8_SGIS)
        /// </summary>
        DualAlpha8Sgis = 0x8111,

        /// <summary>
        ///     12-bit dual alpha channel, SGIS (GL_DUAL_ALPHA12_SGIS)
        /// </summary>
        DualAlpha12Sgis = 0x8112,

        /// <summary>
        ///     16-bit dual alpha channel, SGIS (GL_DUAL_ALPHA16_SGIS)
        /// </summary>
        DualAlpha16Sgis = 0x8113,

        /// <summary>
        ///     4-bit dual luminance, SGIS (GL_DUAL_LUMINANCE4_SGIS)
        /// </summary>
        DualLuminance4Sgis = 0x8114,

        /// <summary>
        ///     8-bit dual luminance, SGIS (GL_DUAL_LUMINANCE8_SGIS)
        /// </summary>
        DualLuminance8Sgis = 0x8115,

        /// <summary>
        ///     12-bit dual luminance, SGIS (GL_DUAL_LUMINANCE12_SGIS)
        /// </summary>
        DualLuminance12Sgis = 0x8116,

        /// <summary>
        ///     16-bit dual luminance, SGIS (GL_DUAL_LUMINANCE16_SGIS)
        /// </summary>
        DualLuminance16Sgis = 0x8117,

        /// <summary>
        ///     4-bit dual intensity, SGIS (GL_DUAL_INTENSITY4_SGIS)
        /// </summary>
        DualIntensity4Sgis = 0x8118,

        /// <summary>
        ///     8-bit dual intensity, SGIS (GL_DUAL_INTENSITY8_SGIS)
        /// </summary>
        DualIntensity8Sgis = 0x8119,

        /// <summary>
        ///     12-bit dual intensity, SGIS (GL_DUAL_INTENSITY12_SGIS)
        /// </summary>
        DualIntensity12Sgis = 0x811A,

        /// <summary>
        ///     16-bit dual intensity, SGIS (GL_DUAL_INTENSITY16_SGIS)
        /// </summary>
        DualIntensity16Sgis = 0x811B,

        /// <summary>
        ///     4-bit dual luminance-alpha, SGIS (GL_DUAL_LUMINANCE_ALPHA4_SGIS)
        /// </summary>
        DualLuminanceAlpha4Sgis = 0x811C,

        /// <summary>
        ///     8-bit dual luminance-alpha, SGIS (GL_DUAL_LUMINANCE_ALPHA8_SGIS)
        /// </summary>
        DualLuminanceAlpha8Sgis = 0x811D,

        /// <summary>
        ///     4-bit quad alpha, SGIS (GL_QUAD_ALPHA4_SGIS)
        /// </summary>
        QuadAlpha4Sgis = 0x811E,

        /// <summary>
        ///     8-bit quad alpha, SGIS (GL_QUAD_ALPHA8_SGIS)
        /// </summary>
        QuadAlpha8Sgis = 0x811F,

        /// <summary>
        ///     4-bit quad luminance, SGIS (GL_QUAD_LUMINANCE4_SGIS)
        /// </summary>
        QuadLuminance4Sgis = 0x8120,

        /// <summary>
        ///     8-bit quad luminance, SGIS (GL_QUAD_LUMINANCE8_SGIS)
        /// </summary>
        QuadLuminance8Sgis = 0x8121,

        /// <summary>
        ///     4-bit quad intensity, SGIS (GL_QUAD_INTENSITY4_SGIS)
        /// </summary>
        QuadIntensity4Sgis = 0x8122,

        /// <summary>
        ///     8-bit quad intensity, SGIS (GL_QUAD_INTENSITY8_SGIS)
        /// </summary>
        QuadIntensity8Sgis = 0x8123,

        /// <summary>
        ///     16-bit depth component internal format (GL_DEPTH_COMPONENT16)
        /// </summary>
        DepthComponent16 = 0x81a5,

        /// <summary>
        ///     16-bit depth component internal format, SGIX (GL_DEPTH_COMPONENT16_SGIX)
        /// </summary>
        DepthComponent16Sgix = 0x81A5,

        /// <summary>
        ///     24-bit depth component internal format (GL_DEPTH_COMPONENT24)
        /// </summary>
        DepthComponent24 = 0x81a6,

        /// <summary>
        ///     24-bit depth component internal format, SGIX (GL_DEPTH_COMPONENT24_SGIX)
        /// </summary>
        DepthComponent24Sgix = 0x81A6,

        /// <summary>
        ///     32-bit depth component internal format (GL_DEPTH_COMPONENT32)
        /// </summary>
        DepthComponent32 = 0x81a7,

        /// <summary>
        ///     32-bit depth component internal format, SGIX (GL_DEPTH_COMPONENT32_SGIX)
        /// </summary>
        DepthComponent32Sgix = 0x81A7,

        /// <summary>
        ///     Compressed red internal format (GL_COMPRESSED_RED)
        /// </summary>
        CompressedRed = 0x8225,

        /// <summary>
        ///     Compressed RG internal format (GL_COMPRESSED_RG)
        /// </summary>
        CompressedRg = 0x8226,

        /// <summary>
        ///     8-bit red channel internal format (GL_R8)
        /// </summary>
        R8 = 0x8229,

        /// <summary>
        ///     16-bit red channel internal format (GL_R16)
        /// </summary>
        R16 = 0x822A,

        /// <summary>
        ///     8-bit RG internal format (GL_RG8)
        /// </summary>
        Rg8 = 0x822B,

        /// <summary>
        ///     16-bit RG internal format (GL_RG16)
        /// </summary>
        Rg16 = 0x822C,

        /// <summary>
        ///     16-bit float red channel internal format (GL_R16F)
        /// </summary>
        R16F = 0x822D,

        /// <summary>
        ///     32-bit float red channel internal format (GL_R32F)
        /// </summary>
        R32F = 0x822E,

        /// <summary>
        ///     16-bit float RG internal format (GL_RG16F)
        /// </summary>
        Rg16F = 0x822F,

        /// <summary>
        ///     32-bit float RG internal format (GL_RG32F)
        /// </summary>
        Rg32F = 0x8230,

        /// <summary>
        ///     8-bit signed integer red internal format (GL_R8I)
        /// </summary>
        R8I = 0x8231,

        /// <summary>
        ///     8-bit unsigned integer red internal format (GL_R8UI)
        /// </summary>
        R8Ui = 0x8232,

        /// <summary>
        ///     16-bit signed integer red internal format (GL_R16I)
        /// </summary>
        R16I = 0x8233,

        /// <summary>
        ///     16-bit unsigned integer red internal format (GL_R16UI)
        /// </summary>
        R16Ui = 0x8234,

        /// <summary>
        ///     32-bit signed integer red internal format (GL_R32I)
        /// </summary>
        R32I = 0x8235,

        /// <summary>
        ///     32-bit unsigned integer red internal format (GL_R32UI)
        /// </summary>
        R32Ui = 0x8236,

        /// <summary>
        ///     8-bit signed integer RG internal format (GL_RG8I)
        /// </summary>
        Rg8I = 0x8237,

        /// <summary>
        ///     8-bit unsigned integer RG internal format (GL_RG8UI)
        /// </summary>
        Rg8Ui = 0x8238,

        /// <summary>
        ///     16-bit signed integer RG internal format (GL_RG16I)
        /// </summary>
        Rg16I = 0x8239,

        /// <summary>
        ///     16-bit unsigned integer RG internal format (GL_RG16UI)
        /// </summary>
        Rg16Ui = 0x823A,

        /// <summary>
        ///     32-bit signed integer RG internal format (GL_RG32I)
        /// </summary>
        Rg32I = 0x823B,

        /// <summary>
        ///     32-bit unsigned integer RG internal format (GL_RG32UI)
        /// </summary>
        Rg32Ui = 0x823C,

        /// <summary>
        ///     S3TC DXT1 compressed RGB, EXT (GL_COMPRESSED_RGB_S3TC_DXT1_EXT)
        /// </summary>
        CompressedRgbS3TcDxt1Ext = 0x83F0,

        /// <summary>
        ///     S3TC DXT1 compressed RGBA, EXT (GL_COMPRESSED_RGBA_S3TC_DXT1_EXT)
        /// </summary>
        CompressedRgbaS3TcDxt1Ext = 0x83F1,

        /// <summary>
        ///     S3TC DXT3 compressed RGBA, EXT (GL_COMPRESSED_RGBA_S3TC_DXT3_EXT)
        /// </summary>
        CompressedRgbaS3TcDxt3Ext = 0x83F2,

        /// <summary>
        ///     S3TC DXT5 compressed RGBA, EXT (GL_COMPRESSED_RGBA_S3TC_DXT5_EXT)
        /// </summary>
        CompressedRgbaS3TcDxt5Ext = 0x83F3,

        /// <summary>
        ///     Compressed alpha internal format (GL_COMPRESSED_ALPHA)
        /// </summary>
        CompressedAlpha = 0x84E9,

        /// <summary>
        ///     Compressed luminance internal format (GL_COMPRESSED_LUMINANCE)
        /// </summary>
        CompressedLuminance = 0x84EA,

        /// <summary>
        ///     Compressed luminance-alpha internal format (GL_COMPRESSED_LUMINANCE_ALPHA)
        /// </summary>
        CompressedLuminanceAlpha = 0x84EB,

        /// <summary>
        ///     Compressed intensity internal format (GL_COMPRESSED_INTENSITY)
        /// </summary>
        CompressedIntensity = 0x84EC,

        /// <summary>
        ///     Compressed RGB internal format (GL_COMPRESSED_RGB)
        /// </summary>
        CompressedRgb = 0x84ED,

        /// <summary>
        ///     Compressed RGBA internal format (GL_COMPRESSED_RGBA)
        /// </summary>
        CompressedRgba = 0x84EE,

        /// <summary>
        ///     The depth stencil pixel internal format
        /// </summary>
        DepthStencil = 0x84F9,

        /// <summary>
        ///     The rgba 32f pixel internal format
        /// </summary>
        Rgba32F = 0x8814,

        /// <summary>
        ///     The rgb 32f pixel internal format
        /// </summary>
        Rgb32F = 0x8815,

        /// <summary>
        ///     The rgba 16f pixel internal format
        /// </summary>
        Rgba16F = 0x881A,

        /// <summary>
        ///     The rgb 16f pixel internal format
        /// </summary>
        Rgb16F = 0x881B,

        /// <summary>
        ///     The depth 24 stencil pixel internal format
        /// </summary>
        Depth24Stencil8 = 0x88F0,

        /// <summary>
        ///     The 11f 11f 10f pixel internal format
        /// </summary>
        R11Fg11Fb10F = 0x8C3A,

        /// <summary>
        ///     The rgb pixel internal format
        /// </summary>
        Rgb9E5 = 0x8C3D,

        /// <summary>
        ///     The srgb pixel internal format
        /// </summary>
        Srgb = 0x8C40,

        /// <summary>
        ///     The srgb pixel internal format
        /// </summary>
        Srgb8 = 0x8C41,

        /// <summary>
        ///     The srgb alpha pixel internal format
        /// </summary>
        SrgbAlpha = 0x8C42,

        /// <summary>
        ///     The srgb alpha pixel internal format
        /// </summary>
        Srgb8Alpha8 = 0x8C43,

        /// <summary>
        ///     The sluminance alpha pixel internal format
        /// </summary>
        SluminanceAlpha = 0x8C44,

        /// <summary>
        ///     The sluminance alpha pixel internal format
        /// </summary>
        Sluminance8Alpha8 = 0x8C45,

        /// <summary>
        ///     The sluminance pixel internal format
        /// </summary>
        Sluminance = 0x8C46,

        /// <summary>
        ///     The sluminance pixel internal format
        /// </summary>
        Sluminance8 = 0x8C47,

        /// <summary>
        ///     The compressed srgb pixel internal format
        /// </summary>
        CompressedSrgb = 0x8C48,

        /// <summary>
        ///     The compressed srgb alpha pixel internal format
        /// </summary>
        CompressedSrgbAlpha = 0x8C49,

        /// <summary>
        ///     The compressed sluminance pixel internal format
        /// </summary>
        CompressedSluminance = 0x8C4A,

        /// <summary>
        ///     The compressed sluminance alpha pixel internal format
        /// </summary>
        CompressedSluminanceAlpha = 0x8C4B,

        /// <summary>
        ///     The compressed srgb 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbS3TcDxt1Ext = 0x8C4C,

        /// <summary>
        ///     The compressed srgb alpha 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbAlphaS3TcDxt1Ext = 0x8C4D,

        /// <summary>
        ///     The compressed srgb alpha 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbAlphaS3TcDxt3Ext = 0x8C4E,

        /// <summary>
        ///     The compressed srgb alpha 3tc dxt ext pixel internal format
        /// </summary>
        CompressedSrgbAlphaS3TcDxt5Ext = 0x8C4F,

        /// <summary>
        ///     The depth component 32f pixel internal format
        /// </summary>
        DepthComponent32F = 0x8CAC,

        /// <summary>
        ///     The depth 32f stencil pixel internal format
        /// </summary>
        Depth32FStencil8 = 0x8CAD,

        /// <summary>
        ///     The rgba 32ui pixel internal format
        /// </summary>
        Rgba32Ui = 0x8D70,

        /// <summary>
        ///     The rgb 32ui pixel internal format
        /// </summary>
        Rgb32Ui = 0x8D71,

        /// <summary>
        ///     The rgba 16ui pixel internal format
        /// </summary>
        Rgba16Ui = 0x8D76,

        /// <summary>
        ///     The rgb 16ui pixel internal format
        /// </summary>
        Rgb16Ui = 0x8D77,

        /// <summary>
        ///     The rgba 8ui pixel internal format
        /// </summary>
        Rgba8Ui = 0x8D7C,

        /// <summary>
        ///     The rgb 8ui pixel internal format
        /// </summary>
        Rgb8Ui = 0x8D7D,

        /// <summary>
        ///     The rgba 32i pixel internal format
        /// </summary>
        Rgba32I = 0x8D82,

        /// <summary>
        ///     The rgb 32i pixel internal format
        /// </summary>
        Rgb32I = 0x8D83,

        /// <summary>
        ///     The rgba 16i pixel internal format
        /// </summary>
        Rgba16I = 0x8D88,

        /// <summary>
        ///     The rgb 16i pixel internal format
        /// </summary>
        Rgb16I = 0x8D89,

        /// <summary>
        ///     The rgba 8i pixel internal format
        /// </summary>
        Rgba8I = 0x8D8E,

        /// <summary>
        ///     The rgb 8i pixel internal format
        /// </summary>
        Rgb8I = 0x8D8F,

        /// <summary>
        ///     The float 32 unsigned int 248 rev pixel internal format
        /// </summary>
        Float32UnsignedInt248Rev = 0x8DAD,

        /// <summary>
        ///     The compressed red rgtc pixel internal format
        /// </summary>
        CompressedRedRgtc1 = 0x8DBB,

        /// <summary>
        ///     The compressed signed red rgtc pixel internal format
        /// </summary>
        CompressedSignedRedRgtc1 = 0x8DBC,

        /// <summary>
        ///     The compressed rg rgtc pixel internal format
        /// </summary>
        CompressedRgRgtc2 = 0x8DBD,

        /// <summary>
        ///     The compressed signed rg rgtc pixel internal format
        /// </summary>
        CompressedSignedRgRgtc2 = 0x8DBE,

        /// <summary>
        ///     The one pixel internal format
        /// </summary>
        One = 1,

        /// <summary>
        ///     The two pixel internal format
        /// </summary>
        Two = 2,

        /// <summary>
        ///     The three pixel internal format
        /// </summary>
        Three = 3,

        /// <summary>
        ///     The four pixel internal format
        /// </summary>
        Four = 4
    }
}