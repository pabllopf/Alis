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
//  This program is agreed in the hope that it will be useful,
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
    /// Defines the internal pixel storage formats for OpenGL texture objects.
    /// These values specify the number of color components and their bit depths stored internally by OpenGL.
    /// Used with glTexImage2D and related functions to define the texture's data format.
    /// </summary>
    public enum PixelInternalFormat
    {
        /// <summary>Depth component internal format (GL_DEPTH_COMPONENT = 0x1902).</summary>
        DepthComponent = 0x1902,

        /// <summary>Alpha internal format (GL_ALPHA = 0x1906).</summary>
        Alpha = 0x1906,

        /// <summary>RGB internal format (GL_RGB = 0x1907).</summary>
        Rgb = 0x1907,

        /// <summary>RGBA internal format (GL_RGBA = 0x1908).</summary>
        Rgba = 0x1908,

        /// <summary>Luminance internal format (GL_LUMINANCE = 0x1909).</summary>
        Luminance = 0x1909,

        /// <summary>Luminance alpha internal format (GL_LUMINANCE_ALPHA = 0x190A).</summary>
        LuminanceAlpha = 0x190A,

        /// <summary>3-3-2 RGB format (GL_R3_G3_B2 = 0x2A10).</summary>
        R3G3B2 = 0x2A10,

        /// <summary>4-bit alpha (GL_ALPHA4 = 0x803B).</summary>
        Alpha4 = 0x803B,

        /// <summary>8-bit alpha (GL_ALPHA8 = 0x803C).</summary>
        Alpha8 = 0x803C,

        /// <summary>12-bit alpha (GL_ALPHA12 = 0x803D).</summary>
        Alpha12 = 0x803D,

        /// <summary>16-bit alpha (GL_ALPHA16 = 0x803E).</summary>
        Alpha16 = 0x803E,

        /// <summary>4-bit luminance (GL_LUMINANCE4 = 0x803F).</summary>
        Luminance4 = 0x803F,

        /// <summary>8-bit luminance (GL_LUMINANCE8 = 0x8040).</summary>
        Luminance8 = 0x8040,

        /// <summary>12-bit luminance (GL_LUMINANCE12 = 0x8041).</summary>
        Luminance12 = 0x8041,

        /// <summary>16-bit luminance (GL_LUMINANCE16 = 0x8042).</summary>
        Luminance16 = 0x8042,

        /// <summary>4-bit luminance and 4-bit alpha (GL_LUMINANCE4_ALPHA4 = 0x8043).</summary>
        Luminance4Alpha4 = 0x8043,

        /// <summary>6-bit luminance and 2-bit alpha (GL_LUMINANCE6_ALPHA2 = 0x8044).</summary>
        Luminance6Alpha2 = 0x8044,

        /// <summary>8-bit luminance and 8-bit alpha (GL_LUMINANCE8_ALPHA8 = 0x8045).</summary>
        Luminance8Alpha8 = 0x8045,

        /// <summary>12-bit luminance and 4-bit alpha (GL_LUMINANCE12_ALPHA4 = 0x8046).</summary>
        Luminance12Alpha4 = 0x8046,

        /// <summary>12-bit luminance and 12-bit alpha (GL_LUMINANCE12_ALPHA12 = 0x8047).</summary>
        Luminance12Alpha12 = 0x8047,

        /// <summary>16-bit luminance and 16-bit alpha (GL_LUMINANCE16_ALPHA16 = 0x8048).</summary>
        Luminance16Alpha16 = 0x8048,

        /// <summary>Intensity format (GL_INTENSITY = 0x8049).</summary>
        Intensity = 0x8049,

        /// <summary>4-bit intensity (GL_INTENSITY4 = 0x804A).</summary>
        Intensity4 = 0x804A,

        /// <summary>8-bit intensity (GL_INTENSITY8 = 0x804B).</summary>
        Intensity8 = 0x804B,

        /// <summary>12-bit intensity (GL_INTENSITY12 = 0x804C).</summary>
        Intensity12 = 0x804C,

        /// <summary>16-bit intensity (GL_INTENSITY16 = 0x804D).</summary>
        Intensity16 = 0x804D,

        /// <summary>Extension alias for 2-bit RGB (GL_RGB2_EXT = 0x804E).</summary>
        Rgb2Ext = 0x804E,

        /// <summary>4-bit RGB (GL_RGB4 = 0x804F).</summary>
        Rgb4 = 0x804F,

        /// <summary>5-bit RGB (GL_RGB5 = 0x8050).</summary>
        Rgb5 = 0x8050,

        /// <summary>8-bit RGB (GL_RGB8 = 0x8051).</summary>
        Rgb8 = 0x8051,

        /// <summary>10-bit RGB (GL_RGB10 = 0x8052).</summary>
        Rgb10 = 0x8052,

        /// <summary>12-bit RGB (GL_RGB12 = 0x8053).</summary>
        Rgb12 = 0x8053,

        /// <summary>16-bit RGB (GL_RGB16 = 0x8054).</summary>
        Rgb16 = 0x8054,

        /// <summary>2-bit RGBA (GL_RGBA2 = 0x8055).</summary>
        Rgba2 = 0x8055,

        /// <summary>4-bit RGBA (GL_RGBA4 = 0x8056).</summary>
        Rgba4 = 0x8056,

        /// <summary>5-5-5-1 RGBA (GL_RGB5_A1 = 0x8057).</summary>
        Rgb5A1 = 0x8057,

        /// <summary>8-bit RGBA (GL_RGBA8 = 0x8058).</summary>
        Rgba8 = 0x8058,

        /// <summary>10-10-10-2 RGBA (GL_RGB10_A2 = 0x8059).</summary>
        Rgb10A2 = 0x8059,

        /// <summary>12-bit RGBA (GL_RGBA12 = 0x805A).</summary>
        Rgba12 = 0x805A,

        /// <summary>16-bit RGBA (GL_RGBA16 = 0x805B).</summary>
        Rgba16 = 0x805B,

        /// <summary>Extension: SGI dual alpha 4 (GL_DUAL_ALPHA4_SGIS = 0x8110).</summary>
        DualAlpha4Sgis = 0x8110,

        /// <summary>Extension: SGI dual alpha 8 (GL_DUAL_ALPHA8_SGIS = 0x8111).</summary>
        DualAlpha8Sgis = 0x8111,

        /// <summary>Extension: SGI dual alpha 12 (GL_DUAL_ALPHA12_SGIS = 0x8112).</summary>
        DualAlpha12Sgis = 0x8112,

        /// <summary>Extension: SGI dual alpha 16 (GL_DUAL_ALPHA16_SGIS = 0x8113).</summary>
        DualAlpha16Sgis = 0x8113,

        /// <summary>Extension: SGI dual luminance 4 (GL_DUAL_LUMINANCE4_SGIS = 0x8114).</summary>
        DualLuminance4Sgis = 0x8114,

        /// <summary>Extension: SGI dual luminance 8 (GL_DUAL_LUMINANCE8_SGIS = 0x8115).</summary>
        DualLuminance8Sgis = 0x8115,

        /// <summary>Extension: SGI dual luminance 12 (GL_DUAL_LUMINANCE12_SGIS = 0x8116).</summary>
        DualLuminance12Sgis = 0x8116,

        /// <summary>Extension: SGI dual luminance 16 (GL_DUAL_LUMINANCE16_SGIS = 0x8117).</summary>
        DualLuminance16Sgis = 0x8117,

        /// <summary>Extension: SGI dual intensity 4 (GL_DUAL_INTENSITY4_SGIS = 0x8118).</summary>
        DualIntensity4Sgis = 0x8118,

        /// <summary>Extension: SGI dual intensity 8 (GL_DUAL_INTENSITY8_SGIS = 0x8119).</summary>
        DualIntensity8Sgis = 0x8119,

        /// <summary>Extension: SGI dual intensity 12 (GL_DUAL_INTENSITY12_SGIS = 0x811A).</summary>
        DualIntensity12Sgis = 0x811A,

        /// <summary>Extension: SGI dual intensity 16 (GL_DUAL_INTENSITY16_SGIS = 0x811B).</summary>
        DualIntensity16Sgis = 0x811B,

        /// <summary>Extension: SGI dual luminance alpha 4 (GL_DUAL_LUMINANCE_ALPHA4_SGIS = 0x811C).</summary>
        DualLuminanceAlpha4Sgis = 0x811C,

        /// <summary>Extension: SGI dual luminance alpha 8 (GL_DUAL_LUMINANCE_ALPHA8_SGIS = 0x811D).</summary>
        DualLuminanceAlpha8Sgis = 0x811D,

        /// <summary>Extension: SGI quad alpha 4 (GL_QUAD_ALPHA4_SGIS = 0x811E).</summary>
        QuadAlpha4Sgis = 0x811E,

        /// <summary>Extension: SGI quad alpha 8 (GL_QUAD_ALPHA8_SGIS = 0x811F).</summary>
        QuadAlpha8Sgis = 0x811F,

        /// <summary>Extension: SGI quad luminance 4 (GL_QUAD_LUMINANCE4_SGIS = 0x8120).</summary>
        QuadLuminance4Sgis = 0x8120,

        /// <summary>Extension: SGI quad luminance 8 (GL_QUAD_LUMINANCE8_SGIS = 0x8121).</summary>
        QuadLuminance8Sgis = 0x8121,

        /// <summary>Extension: SGI quad intensity 4 (GL_QUAD_INTENSITY4_SGIS = 0x8122).</summary>
        QuadIntensity4Sgis = 0x8122,

        /// <summary>Extension: SGI quad intensity 8 (GL_QUAD_INTENSITY8_SGIS = 0x8123).</summary>
        QuadIntensity8Sgis = 0x8123,

        /// <summary>16-bit depth component (GL_DEPTH_COMPONENT16 = 0x81A5).</summary>
        DepthComponent16 = 0x81a5,

        /// <summary>Extension alias for 16-bit depth (GL_DEPTH_COMPONENT16_SGIX = 0x81A5).</summary>
        DepthComponent16Sgix = 0x81A5,

        /// <summary>24-bit depth component (GL_DEPTH_COMPONENT24 = 0x81A6).</summary>
        DepthComponent24 = 0x81a6,

        /// <summary>Extension alias for 24-bit depth (GL_DEPTH_COMPONENT24_SGIX = 0x81A6).</summary>
        DepthComponent24Sgix = 0x81A6,

        /// <summary>32-bit depth component (GL_DEPTH_COMPONENT32 = 0x81A7).</summary>
        DepthComponent32 = 0x81a7,

        /// <summary>Extension alias for 32-bit depth (GL_DEPTH_COMPONENT32_SGIX = 0x81A7).</summary>
        DepthComponent32Sgix = 0x81A7,

        /// <summary>Compressed red format (GL_COMPRESSED_RED = 0x8225).</summary>
        CompressedRed = 0x8225,

        /// <summary>Compressed RG format (GL_COMPRESSED_RG = 0x8226).</summary>
        CompressedRg = 0x8226,

        /// <summary>8-bit red (GL_R8 = 0x8229).</summary>
        R8 = 0x8229,

        /// <summary>16-bit red (GL_R16 = 0x822A).</summary>
        R16 = 0x822A,

        /// <summary>8-bit RG (GL_RG8 = 0x822B).</summary>
        Rg8 = 0x822B,

        /// <summary>16-bit RG (GL_RG16 = 0x822C).</summary>
        Rg16 = 0x822C,

        /// <summary>16-bit float red (GL_R16F = 0x822D).</summary>
        R16F = 0x822D,

        /// <summary>32-bit float red (GL_R32F = 0x822E).</summary>
        R32F = 0x822E,

        /// <summary>16-bit float RG (GL_RG16F = 0x822F).</summary>
        Rg16F = 0x822F,

        /// <summary>32-bit float RG (GL_RG32F = 0x8230).</summary>
        Rg32F = 0x8230,

        /// <summary>8-bit signed integer red (GL_R8I = 0x8231).</summary>
        R8I = 0x8231,

        /// <summary>8-bit unsigned integer red (GL_R8UI = 0x8232).</summary>
        R8Ui = 0x8232,

        /// <summary>16-bit signed integer red (GL_R16I = 0x8233).</summary>
        R16I = 0x8233,

        /// <summary>16-bit unsigned integer red (GL_R16UI = 0x8234).</summary>
        R16Ui = 0x8234,

        /// <summary>32-bit signed integer red (GL_R32I = 0x8235).</summary>
        R32I = 0x8235,

        /// <summary>32-bit unsigned integer red (GL_R32UI = 0x8236).</summary>
        R32Ui = 0x8236,

        /// <summary>8-bit signed integer RG (GL_RG8I = 0x8237).</summary>
        Rg8I = 0x8237,

        /// <summary>8-bit unsigned integer RG (GL_RG8UI = 0x8238).</summary>
        Rg8Ui = 0x8238,

        /// <summary>16-bit signed integer RG (GL_RG16I = 0x8239).</summary>
        Rg16I = 0x8239,

        /// <summary>16-bit unsigned integer RG (GL_RG16UI = 0x823A).</summary>
        Rg16Ui = 0x823A,

        /// <summary>32-bit signed integer RG (GL_RG32I = 0x823B).</summary>
        Rg32I = 0x823B,

        /// <summary>32-bit unsigned integer RG (GL_RG32UI = 0x823C).</summary>
        Rg32Ui = 0x823C,

        /// <summary>Compressed RGB S3TC DXT1 (GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0).</summary>
        CompressedRgbS3TcDxt1Ext = 0x83F0,

        /// <summary>Compressed RGBA S3TC DXT1 (GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1).</summary>
        CompressedRgbaS3TcDxt1Ext = 0x83F1,

        /// <summary>Compressed RGBA S3TC DXT3 (GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2).</summary>
        CompressedRgbaS3TcDxt3Ext = 0x83F2,

        /// <summary>Compressed RGBA S3TC DXT5 (GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3).</summary>
        CompressedRgbaS3TcDxt5Ext = 0x83F3,

        /// <summary>Compressed alpha (GL_COMPRESSED_ALPHA = 0x84E9).</summary>
        CompressedAlpha = 0x84E9,

        /// <summary>Compressed luminance (GL_COMPRESSED_LUMINANCE = 0x84EA).</summary>
        CompressedLuminance = 0x84EA,

        /// <summary>Compressed luminance alpha (GL_COMPRESSED_LUMINANCE_ALPHA = 0x84EB).</summary>
        CompressedLuminanceAlpha = 0x84EB,

        /// <summary>Compressed intensity (GL_COMPRESSED_INTENSITY = 0x84EC).</summary>
        CompressedIntensity = 0x84EC,

        /// <summary>Compressed RGB (GL_COMPRESSED_RGB = 0x84ED).</summary>
        CompressedRgb = 0x84ED,

        /// <summary>Compressed RGBA (GL_COMPRESSED_RGBA = 0x84EE).</summary>
        CompressedRgba = 0x84EE,

        /// <summary>Depth and stencil combined (GL_DEPTH_STENCIL = 0x84F9).</summary>
        DepthStencil = 0x84F9,

        /// <summary>32-bit float RGBA (GL_RGBA32F = 0x8814).</summary>
        Rgba32F = 0x8814,

        /// <summary>32-bit float RGB (GL_RGB32F = 0x8815).</summary>
        Rgb32F = 0x8815,

        /// <summary>16-bit float RGBA (GL_RGBA16F = 0x881A).</summary>
        Rgba16F = 0x881A,

        /// <summary>16-bit float RGB (GL_RGB16F = 0x881B).</summary>
        Rgb16F = 0x881B,

        /// <summary>24-bit depth and 8-bit stencil (GL_DEPTH24_STENCIL8 = 0x88F0).</summary>
        Depth24Stencil8 = 0x88F0,

        /// <summary>11-11-10 float RGB (GL_R11F_G11F_B10F = 0x8C3A).</summary>
        R11Fg11Fb10F = 0x8C3A,

        /// <summary>9-bit exponent RGB (GL_RGB9_E5 = 0x8C3D).</summary>
        Rgb9E5 = 0x8C3D,

        /// <summary>sRGB format (GL_SRGB = 0x8C40).</summary>
        Srgb = 0x8C40,

        /// <summary>8-bit sRGB (GL_SRGB8 = 0x8C41).</summary>
        Srgb8 = 0x8C41,

        /// <summary>sRGB with alpha (GL_SRGB_ALPHA = 0x8C42).</summary>
        SrgbAlpha = 0x8C42,

        /// <summary>8-bit sRGB with 8-bit alpha (GL_SRGB8_ALPHA8 = 0x8C43).</summary>
        Srgb8Alpha8 = 0x8C43,

        /// <summary>sLuminance with alpha (GL_SLUMINANCE_ALPHA = 0x8C44).</summary>
        SluminanceAlpha = 0x8C44,

        /// <summary>8-bit sLuminance with 8-bit alpha (GL_SLUMINANCE8_ALPHA8 = 0x8C45).</summary>
        Sluminance8Alpha8 = 0x8C45,

        /// <summary>sLuminance format (GL_SLUMINANCE = 0x8C46).</summary>
        Sluminance = 0x8C46,

        /// <summary>8-bit sLuminance (GL_SLUMINANCE8 = 0x8C47).</summary>
        Sluminance8 = 0x8C47,

        /// <summary>Compressed sRGB (GL_COMPRESSED_SRGB = 0x8C48).</summary>
        CompressedSrgb = 0x8C48,

        /// <summary>Compressed sRGB alpha (GL_COMPRESSED_SRGB_ALPHA = 0x8C49).</summary>
        CompressedSrgbAlpha = 0x8C49,

        /// <summary>Compressed sLuminance (GL_COMPRESSED_SLUMINANCE = 0x8C4A).</summary>
        CompressedSluminance = 0x8C4A,

        /// <summary>Compressed sLuminance alpha (GL_COMPRESSED_SLUMINANCE_ALPHA = 0x8C4B).</summary>
        CompressedSluminanceAlpha = 0x8C4B,

        /// <summary>Compressed sRGB S3TC DXT1 (GL_COMPRESSED_SRGB_S3TC_DXT1_EXT = 0x8C4C).</summary>
        CompressedSrgbS3TcDxt1Ext = 0x8C4C,

        /// <summary>Compressed sRGB alpha S3TC DXT1 (GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT1_EXT = 0x8C4D).</summary>
        CompressedSrgbAlphaS3TcDxt1Ext = 0x8C4D,

        /// <summary>Compressed sRGB alpha S3TC DXT3 (GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT3_EXT = 0x8C4E).</summary>
        CompressedSrgbAlphaS3TcDxt3Ext = 0x8C4E,

        /// <summary>Compressed sRGB alpha S3TC DXT5 (GL_COMPRESSED_SRGB_ALPHA_S3TC_DXT5_EXT = 0x8C4F).</summary>
        CompressedSrgbAlphaS3TcDxt5Ext = 0x8C4F,

        /// <summary>32-bit float depth (GL_DEPTH_COMPONENT32F = 0x8CAC).</summary>
        DepthComponent32F = 0x8CAC,

        /// <summary>32-bit float depth and 8-bit stencil (GL_DEPTH32F_STENCIL8 = 0x8CAD).</summary>
        Depth32FStencil8 = 0x8CAD,

        /// <summary>32-bit unsigned integer RGBA (GL_RGBA32UI = 0x8D70).</summary>
        Rgba32Ui = 0x8D70,

        /// <summary>32-bit unsigned integer RGB (GL_RGB32UI = 0x8D71).</summary>
        Rgb32Ui = 0x8D71,

        /// <summary>16-bit unsigned integer RGBA (GL_RGBA16UI = 0x8D76).</summary>
        Rgba16Ui = 0x8D76,

        /// <summary>16-bit unsigned integer RGB (GL_RGB16UI = 0x8D77).</summary>
        Rgb16Ui = 0x8D77,

        /// <summary>8-bit unsigned integer RGBA (GL_RGBA8UI = 0x8D7C).</summary>
        Rgba8Ui = 0x8D7C,

        /// <summary>8-bit unsigned integer RGB (GL_RGB8UI = 0x8D7D).</summary>
        Rgb8Ui = 0x8D7D,

        /// <summary>32-bit signed integer RGBA (GL_RGBA32I = 0x8D82).</summary>
        Rgba32I = 0x8D82,

        /// <summary>32-bit signed integer RGB (GL_RGB32I = 0x8D83).</summary>
        Rgb32I = 0x8D83,

        /// <summary>16-bit signed integer RGBA (GL_RGBA16I = 0x8D88).</summary>
        Rgba16I = 0x8D88,

        /// <summary>16-bit signed integer RGB (GL_RGB16I = 0x8D89).</summary>
        Rgb16I = 0x8D89,

        /// <summary>8-bit signed integer RGBA (GL_RGBA8I = 0x8D8E).</summary>
        Rgba8I = 0x8D8E,

        /// <summary>8-bit signed integer RGB (GL_RGB8I = 0x8D8F).</summary>
        Rgb8I = 0x8D8F,

        /// <summary>32-bit float and 24-bit unsigned int combined (GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD).</summary>
        Float32UnsignedInt248Rev = 0x8DAD,

        /// <summary>Compressed red RGTC1 (GL_COMPRESSED_RED_RGTC1 = 0x8DBB).</summary>
        CompressedRedRgtc1 = 0x8DBB,

        /// <summary>Compressed signed red RGTC1 (GL_COMPRESSED_SIGNED_RED_RGTC1 = 0x8DBC).</summary>
        CompressedSignedRedRgtc1 = 0x8DBC,

        /// <summary>Compressed RG RGTC2 (GL_COMPRESSED_RG_RGTC2 = 0x8DBD).</summary>
        CompressedRgRgtc2 = 0x8DBD,

        /// <summary>Compressed signed RG RGTC2 (GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE).</summary>
        CompressedSignedRgRgtc2 = 0x8DBE,

        /// <summary>One component format (numeric 1).</summary>
        One = 1,

        /// <summary>Two component format (numeric 2).</summary>
        Two = 2,

        /// <summary>Three component format (numeric 3).</summary>
        Three = 3,

        /// <summary>Four component format (numeric 4).</summary>
        Four = 4
    }
}
