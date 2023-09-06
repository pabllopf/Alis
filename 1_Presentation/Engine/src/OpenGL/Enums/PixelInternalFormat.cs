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
        ///     The depth component pixel internal format
        /// </summary>
        DepthComponent = 0x1902,

        /// <summary>
        ///     The alpha pixel internal format
        /// </summary>
        Alpha = 0x1906,

        /// <summary>
        ///     The rgb pixel internal format
        /// </summary>
        Rgb = 0x1907,

        /// <summary>
        ///     The rgba pixel internal format
        /// </summary>
        Rgba = 0x1908,

        /// <summary>
        ///     The luminance pixel internal format
        /// </summary>
        Luminance = 0x1909,

        /// <summary>
        ///     The luminance alpha pixel internal format
        /// </summary>
        LuminanceAlpha = 0x190A,

        /// <summary>
        ///     The  pixel internal format
        /// </summary>
        R3G3B2 = 0x2A10,

        /// <summary>
        ///     The alpha pixel internal format
        /// </summary>
        Alpha4 = 0x803B,

        /// <summary>
        ///     The alpha pixel internal format
        /// </summary>
        Alpha8 = 0x803C,

        /// <summary>
        ///     The alpha 12 pixel internal format
        /// </summary>
        Alpha12 = 0x803D,

        /// <summary>
        ///     The alpha 16 pixel internal format
        /// </summary>
        Alpha16 = 0x803E,

        /// <summary>
        ///     The luminance pixel internal format
        /// </summary>
        Luminance4 = 0x803F,

        /// <summary>
        ///     The luminance pixel internal format
        /// </summary>
        Luminance8 = 0x8040,

        /// <summary>
        ///     The luminance 12 pixel internal format
        /// </summary>
        Luminance12 = 0x8041,

        /// <summary>
        ///     The luminance 16 pixel internal format
        /// </summary>
        Luminance16 = 0x8042,

        /// <summary>
        ///     The luminance alpha pixel internal format
        /// </summary>
        Luminance4Alpha4 = 0x8043,

        /// <summary>
        ///     The luminance alpha pixel internal format
        /// </summary>
        Luminance6Alpha2 = 0x8044,

        /// <summary>
        ///     The luminance alpha pixel internal format
        /// </summary>
        Luminance8Alpha8 = 0x8045,

        /// <summary>
        ///     The luminance 12 alpha pixel internal format
        /// </summary>
        Luminance12Alpha4 = 0x8046,

        /// <summary>
        ///     The luminance 12 alpha 12 pixel internal format
        /// </summary>
        Luminance12Alpha12 = 0x8047,

        /// <summary>
        ///     The luminance 16 alpha 16 pixel internal format
        /// </summary>
        Luminance16Alpha16 = 0x8048,

        /// <summary>
        ///     The intensity pixel internal format
        /// </summary>
        Intensity = 0x8049,

        /// <summary>
        ///     The intensity pixel internal format
        /// </summary>
        Intensity4 = 0x804A,

        /// <summary>
        ///     The intensity pixel internal format
        /// </summary>
        Intensity8 = 0x804B,

        /// <summary>
        ///     The intensity 12 pixel internal format
        /// </summary>
        Intensity12 = 0x804C,

        /// <summary>
        ///     The intensity 16 pixel internal format
        /// </summary>
        Intensity16 = 0x804D,

        /// <summary>
        ///     The rgb ext pixel internal format
        /// </summary>
        Rgb2Ext = 0x804E,

        /// <summary>
        ///     The rgb pixel internal format
        /// </summary>
        Rgb4 = 0x804F,

        /// <summary>
        ///     The rgb pixel internal format
        /// </summary>
        Rgb5 = 0x8050,

        /// <summary>
        ///     The rgb pixel internal format
        /// </summary>
        Rgb8 = 0x8051,

        /// <summary>
        ///     The rgb 10 pixel internal format
        /// </summary>
        Rgb10 = 0x8052,

        /// <summary>
        ///     The rgb 12 pixel internal format
        /// </summary>
        Rgb12 = 0x8053,

        /// <summary>
        ///     The rgb 16 pixel internal format
        /// </summary>
        Rgb16 = 0x8054,

        /// <summary>
        ///     The rgba pixel internal format
        /// </summary>
        Rgba2 = 0x8055,

        /// <summary>
        ///     The rgba pixel internal format
        /// </summary>
        Rgba4 = 0x8056,

        /// <summary>
        ///     The rgb pixel internal format
        /// </summary>
        Rgb5A1 = 0x8057,

        /// <summary>
        ///     The rgba pixel internal format
        /// </summary>
        Rgba8 = 0x8058,

        /// <summary>
        ///     The rgb 10 pixel internal format
        /// </summary>
        Rgb10A2 = 0x8059,

        /// <summary>
        ///     The rgba 12 pixel internal format
        /// </summary>
        Rgba12 = 0x805A,

        /// <summary>
        ///     The rgba 16 pixel internal format
        /// </summary>
        Rgba16 = 0x805B,

        /// <summary>
        ///     The dual alpha sgis pixel internal format
        /// </summary>
        DualAlpha4Sgis = 0x8110,

        /// <summary>
        ///     The dual alpha sgis pixel internal format
        /// </summary>
        DualAlpha8Sgis = 0x8111,

        /// <summary>
        ///     The dual alpha 12 sgis pixel internal format
        /// </summary>
        DualAlpha12Sgis = 0x8112,

        /// <summary>
        ///     The dual alpha 16 sgis pixel internal format
        /// </summary>
        DualAlpha16Sgis = 0x8113,

        /// <summary>
        ///     The dual luminance sgis pixel internal format
        /// </summary>
        DualLuminance4Sgis = 0x8114,

        /// <summary>
        ///     The dual luminance sgis pixel internal format
        /// </summary>
        DualLuminance8Sgis = 0x8115,

        /// <summary>
        ///     The dual luminance 12 sgis pixel internal format
        /// </summary>
        DualLuminance12Sgis = 0x8116,

        /// <summary>
        ///     The dual luminance 16 sgis pixel internal format
        /// </summary>
        DualLuminance16Sgis = 0x8117,

        /// <summary>
        ///     The dual intensity sgis pixel internal format
        /// </summary>
        DualIntensity4Sgis = 0x8118,

        /// <summary>
        ///     The dual intensity sgis pixel internal format
        /// </summary>
        DualIntensity8Sgis = 0x8119,

        /// <summary>
        ///     The dual intensity 12 sgis pixel internal format
        /// </summary>
        DualIntensity12Sgis = 0x811A,

        /// <summary>
        ///     The dual intensity 16 sgis pixel internal format
        /// </summary>
        DualIntensity16Sgis = 0x811B,

        /// <summary>
        ///     The dual luminance alpha sgis pixel internal format
        /// </summary>
        DualLuminanceAlpha4Sgis = 0x811C,

        /// <summary>
        ///     The dual luminance alpha sgis pixel internal format
        /// </summary>
        DualLuminanceAlpha8Sgis = 0x811D,

        /// <summary>
        ///     The quad alpha sgis pixel internal format
        /// </summary>
        QuadAlpha4Sgis = 0x811E,

        /// <summary>
        ///     The quad alpha sgis pixel internal format
        /// </summary>
        QuadAlpha8Sgis = 0x811F,

        /// <summary>
        ///     The quad luminance sgis pixel internal format
        /// </summary>
        QuadLuminance4Sgis = 0x8120,

        /// <summary>
        ///     The quad luminance sgis pixel internal format
        /// </summary>
        QuadLuminance8Sgis = 0x8121,

        /// <summary>
        ///     The quad intensity sgis pixel internal format
        /// </summary>
        QuadIntensity4Sgis = 0x8122,

        /// <summary>
        ///     The quad intensity sgis pixel internal format
        /// </summary>
        QuadIntensity8Sgis = 0x8123,

        /// <summary>
        ///     The depth component 16 pixel internal format
        /// </summary>
        DepthComponent16 = 0x81a5,

        /// <summary>
        ///     The depth component 16 sgix pixel internal format
        /// </summary>
        DepthComponent16Sgix = 0x81A5,

        /// <summary>
        ///     The depth component 24 pixel internal format
        /// </summary>
        DepthComponent24 = 0x81a6,

        /// <summary>
        ///     The depth component 24 sgix pixel internal format
        /// </summary>
        DepthComponent24Sgix = 0x81A6,

        /// <summary>
        ///     The depth component 32 pixel internal format
        /// </summary>
        DepthComponent32 = 0x81a7,

        /// <summary>
        ///     The depth component 32 sgix pixel internal format
        /// </summary>
        DepthComponent32Sgix = 0x81A7,

        /// <summary>
        ///     The compressed red pixel internal format
        /// </summary>
        CompressedRed = 0x8225,

        /// <summary>
        ///     The compressed rg pixel internal format
        /// </summary>
        CompressedRg = 0x8226,

        /// <summary>
        ///     The  pixel internal format
        /// </summary>
        R8 = 0x8229,

        /// <summary>
        ///     The 16 pixel internal format
        /// </summary>
        R16 = 0x822A,

        /// <summary>
        ///     The rg pixel internal format
        /// </summary>
        Rg8 = 0x822B,

        /// <summary>
        ///     The rg 16 pixel internal format
        /// </summary>
        Rg16 = 0x822C,

        /// <summary>
        ///     The 16f pixel internal format
        /// </summary>
        R16F = 0x822D,

        /// <summary>
        ///     The 32f pixel internal format
        /// </summary>
        R32F = 0x822E,

        /// <summary>
        ///     The rg 16f pixel internal format
        /// </summary>
        Rg16F = 0x822F,

        /// <summary>
        ///     The rg 32f pixel internal format
        /// </summary>
        Rg32F = 0x8230,

        /// <summary>
        ///     The 8i pixel internal format
        /// </summary>
        R8I = 0x8231,

        /// <summary>
        ///     The 8ui pixel internal format
        /// </summary>
        R8Ui = 0x8232,

        /// <summary>
        ///     The 16i pixel internal format
        /// </summary>
        R16I = 0x8233,

        /// <summary>
        ///     The 16ui pixel internal format
        /// </summary>
        R16Ui = 0x8234,

        /// <summary>
        ///     The 32i pixel internal format
        /// </summary>
        R32I = 0x8235,

        /// <summary>
        ///     The 32ui pixel internal format
        /// </summary>
        R32Ui = 0x8236,

        /// <summary>
        ///     The rg 8i pixel internal format
        /// </summary>
        Rg8I = 0x8237,

        /// <summary>
        ///     The rg 8ui pixel internal format
        /// </summary>
        Rg8Ui = 0x8238,

        /// <summary>
        ///     The rg 16i pixel internal format
        /// </summary>
        Rg16I = 0x8239,

        /// <summary>
        ///     The rg 16ui pixel internal format
        /// </summary>
        Rg16Ui = 0x823A,

        /// <summary>
        ///     The rg 32i pixel internal format
        /// </summary>
        Rg32I = 0x823B,

        /// <summary>
        ///     The rg 32ui pixel internal format
        /// </summary>
        Rg32Ui = 0x823C,

        /// <summary>
        ///     The compressed rgb 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbS3TcDxt1Ext = 0x83F0,

        /// <summary>
        ///     The compressed rgba 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbaS3TcDxt1Ext = 0x83F1,

        /// <summary>
        ///     The compressed rgba 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbaS3TcDxt3Ext = 0x83F2,

        /// <summary>
        ///     The compressed rgba 3tc dxt ext pixel internal format
        /// </summary>
        CompressedRgbaS3TcDxt5Ext = 0x83F3,

        /// <summary>
        ///     The compressed alpha pixel internal format
        /// </summary>
        CompressedAlpha = 0x84E9,

        /// <summary>
        ///     The compressed luminance pixel internal format
        /// </summary>
        CompressedLuminance = 0x84EA,

        /// <summary>
        ///     The compressed luminance alpha pixel internal format
        /// </summary>
        CompressedLuminanceAlpha = 0x84EB,

        /// <summary>
        ///     The compressed intensity pixel internal format
        /// </summary>
        CompressedIntensity = 0x84EC,

        /// <summary>
        ///     The compressed rgb pixel internal format
        /// </summary>
        CompressedRgb = 0x84ED,

        /// <summary>
        ///     The compressed rgba pixel internal format
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