// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelInternalFormatTest.cs
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

using System;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the PixelInternalFormat enum validating pixel internal format specifications.
    /// </summary>
    public class PixelInternalFormatTest
    {
        [Fact]
        public void DepthComponent_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1902, (int)PixelInternalFormat.DepthComponent); }

        [Fact]
        public void Alpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1906, (int)PixelInternalFormat.Alpha); }

        [Fact]
        public void Rgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1907, (int)PixelInternalFormat.Rgb); }

        [Fact]
        public void Rgba_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1908, (int)PixelInternalFormat.Rgba); }

        [Fact]
        public void Luminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1909, (int)PixelInternalFormat.Luminance); }

        [Fact]
        public void LuminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x190A, (int)PixelInternalFormat.LuminanceAlpha); }

        [Fact]
        public void R3G3B2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2A10, (int)PixelInternalFormat.R3G3B2); }

        [Fact]
        public void Alpha4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803B, (int)PixelInternalFormat.Alpha4); }

        [Fact]
        public void Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803C, (int)PixelInternalFormat.Alpha8); }

        [Fact]
        public void Alpha12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803D, (int)PixelInternalFormat.Alpha12); }

        [Fact]
        public void Alpha16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803E, (int)PixelInternalFormat.Alpha16); }

        [Fact]
        public void Luminance4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803F, (int)PixelInternalFormat.Luminance4); }

        [Fact]
        public void Luminance8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8040, (int)PixelInternalFormat.Luminance8); }

        [Fact]
        public void Luminance12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8041, (int)PixelInternalFormat.Luminance12); }

        [Fact]
        public void Luminance16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8042, (int)PixelInternalFormat.Luminance16); }

        [Fact]
        public void Luminance4Alpha4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8043, (int)PixelInternalFormat.Luminance4Alpha4); }

        [Fact]
        public void Luminance6Alpha2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8044, (int)PixelInternalFormat.Luminance6Alpha2); }

        [Fact]
        public void Luminance8Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8045, (int)PixelInternalFormat.Luminance8Alpha8); }

        [Fact]
        public void Luminance12Alpha4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8046, (int)PixelInternalFormat.Luminance12Alpha4); }

        [Fact]
        public void Luminance12Alpha12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8047, (int)PixelInternalFormat.Luminance12Alpha12); }

        [Fact]
        public void Luminance16Alpha16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8048, (int)PixelInternalFormat.Luminance16Alpha16); }

        [Fact]
        public void Intensity_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8049, (int)PixelInternalFormat.Intensity); }

        [Fact]
        public void Intensity4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804A, (int)PixelInternalFormat.Intensity4); }

        [Fact]
        public void Intensity8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804B, (int)PixelInternalFormat.Intensity8); }

        [Fact]
        public void Intensity12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804C, (int)PixelInternalFormat.Intensity12); }

        [Fact]
        public void Intensity16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804D, (int)PixelInternalFormat.Intensity16); }

        [Fact]
        public void Rgb2Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804E, (int)PixelInternalFormat.Rgb2Ext); }

        [Fact]
        public void Rgb4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804F, (int)PixelInternalFormat.Rgb4); }

        [Fact]
        public void Rgb5_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8050, (int)PixelInternalFormat.Rgb5); }

        [Fact]
        public void Rgb8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8051, (int)PixelInternalFormat.Rgb8); }

        [Fact]
        public void Rgb10_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8052, (int)PixelInternalFormat.Rgb10); }

        [Fact]
        public void Rgb12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8053, (int)PixelInternalFormat.Rgb12); }

        [Fact]
        public void Rgb16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8054, (int)PixelInternalFormat.Rgb16); }

        [Fact]
        public void Rgba2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8055, (int)PixelInternalFormat.Rgba2); }

        [Fact]
        public void Rgba4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8056, (int)PixelInternalFormat.Rgba4); }

        [Fact]
        public void Rgb5A1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8057, (int)PixelInternalFormat.Rgb5A1); }

        [Fact]
        public void Rgba8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8058, (int)PixelInternalFormat.Rgba8); }

        [Fact]
        public void Rgb10A2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8059, (int)PixelInternalFormat.Rgb10A2); }

        [Fact]
        public void Rgba12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x805A, (int)PixelInternalFormat.Rgba12); }

        [Fact]
        public void Rgba16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x805B, (int)PixelInternalFormat.Rgba16); }

        [Fact]
        public void DualAlpha4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8110, (int)PixelInternalFormat.DualAlpha4Sgis); }

        [Fact]
        public void DualAlpha8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8111, (int)PixelInternalFormat.DualAlpha8Sgis); }

        [Fact]
        public void DualAlpha12Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8112, (int)PixelInternalFormat.DualAlpha12Sgis); }

        [Fact]
        public void DualAlpha16Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8113, (int)PixelInternalFormat.DualAlpha16Sgis); }

        [Fact]
        public void DualLuminance4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8114, (int)PixelInternalFormat.DualLuminance4Sgis); }

        [Fact]
        public void DualLuminance8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8115, (int)PixelInternalFormat.DualLuminance8Sgis); }

        [Fact]
        public void DualLuminance12Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8116, (int)PixelInternalFormat.DualLuminance12Sgis); }

        [Fact]
        public void DualLuminance16Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8117, (int)PixelInternalFormat.DualLuminance16Sgis); }

        [Fact]
        public void DualIntensity4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8118, (int)PixelInternalFormat.DualIntensity4Sgis); }

        [Fact]
        public void DualIntensity8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8119, (int)PixelInternalFormat.DualIntensity8Sgis); }

        [Fact]
        public void DualIntensity12Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811A, (int)PixelInternalFormat.DualIntensity12Sgis); }

        [Fact]
        public void DualIntensity16Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811B, (int)PixelInternalFormat.DualIntensity16Sgis); }

        [Fact]
        public void DualLuminanceAlpha4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811C, (int)PixelInternalFormat.DualLuminanceAlpha4Sgis); }

        [Fact]
        public void DualLuminanceAlpha8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811D, (int)PixelInternalFormat.DualLuminanceAlpha8Sgis); }

        [Fact]
        public void QuadAlpha4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811E, (int)PixelInternalFormat.QuadAlpha4Sgis); }

        [Fact]
        public void QuadAlpha8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811F, (int)PixelInternalFormat.QuadAlpha8Sgis); }

        [Fact]
        public void QuadLuminance4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8120, (int)PixelInternalFormat.QuadLuminance4Sgis); }

        [Fact]
        public void QuadLuminance8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8121, (int)PixelInternalFormat.QuadLuminance8Sgis); }

        [Fact]
        public void QuadIntensity4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8122, (int)PixelInternalFormat.QuadIntensity4Sgis); }

        [Fact]
        public void QuadIntensity8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8123, (int)PixelInternalFormat.QuadIntensity8Sgis); }

        [Fact]
        public void DepthComponent16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81a5, (int)PixelInternalFormat.DepthComponent16); }

        [Fact]
        public void DepthComponent16Sgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81A5, (int)PixelInternalFormat.DepthComponent16Sgix); }

        [Fact]
        public void DepthComponent24_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81a6, (int)PixelInternalFormat.DepthComponent24); }

        [Fact]
        public void DepthComponent24Sgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81A6, (int)PixelInternalFormat.DepthComponent24Sgix); }

        [Fact]
        public void DepthComponent32_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81a7, (int)PixelInternalFormat.DepthComponent32); }

        [Fact]
        public void DepthComponent32Sgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81A7, (int)PixelInternalFormat.DepthComponent32Sgix); }

        [Fact]
        public void CompressedRed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8225, (int)PixelInternalFormat.CompressedRed); }

        [Fact]
        public void CompressedRg_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8226, (int)PixelInternalFormat.CompressedRg); }

        [Fact]
        public void R8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8229, (int)PixelInternalFormat.R8); }

        [Fact]
        public void R16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822A, (int)PixelInternalFormat.R16); }

        [Fact]
        public void Rg8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822B, (int)PixelInternalFormat.Rg8); }

        [Fact]
        public void Rg16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822C, (int)PixelInternalFormat.Rg16); }

        [Fact]
        public void R16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822D, (int)PixelInternalFormat.R16F); }

        [Fact]
        public void R32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822E, (int)PixelInternalFormat.R32F); }

        [Fact]
        public void Rg16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822F, (int)PixelInternalFormat.Rg16F); }

        [Fact]
        public void Rg32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8230, (int)PixelInternalFormat.Rg32F); }

        [Fact]
        public void R8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8231, (int)PixelInternalFormat.R8I); }

        [Fact]
        public void R8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8232, (int)PixelInternalFormat.R8Ui); }

        [Fact]
        public void R16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8233, (int)PixelInternalFormat.R16I); }

        [Fact]
        public void R16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8234, (int)PixelInternalFormat.R16Ui); }

        [Fact]
        public void R32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8235, (int)PixelInternalFormat.R32I); }

        [Fact]
        public void R32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8236, (int)PixelInternalFormat.R32Ui); }

        [Fact]
        public void Rg8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8237, (int)PixelInternalFormat.Rg8I); }

        [Fact]
        public void Rg8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8238, (int)PixelInternalFormat.Rg8Ui); }

        [Fact]
        public void Rg16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8239, (int)PixelInternalFormat.Rg16I); }

        [Fact]
        public void Rg16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x823A, (int)PixelInternalFormat.Rg16Ui); }

        [Fact]
        public void Rg32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x823B, (int)PixelInternalFormat.Rg32I); }

        [Fact]
        public void Rg32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x823C, (int)PixelInternalFormat.Rg32Ui); }

        [Fact]
        public void CompressedRgbS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F0, (int)PixelInternalFormat.CompressedRgbS3TcDxt1Ext); }

        [Fact]
        public void CompressedRgbaS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F1, (int)PixelInternalFormat.CompressedRgbaS3TcDxt1Ext); }

        [Fact]
        public void CompressedRgbaS3TcDxt3Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F2, (int)PixelInternalFormat.CompressedRgbaS3TcDxt3Ext); }

        [Fact]
        public void CompressedRgbaS3TcDxt5Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F3, (int)PixelInternalFormat.CompressedRgbaS3TcDxt5Ext); }

        [Fact]
        public void CompressedAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84E9, (int)PixelInternalFormat.CompressedAlpha); }

        [Fact]
        public void CompressedLuminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EA, (int)PixelInternalFormat.CompressedLuminance); }

        [Fact]
        public void CompressedLuminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EB, (int)PixelInternalFormat.CompressedLuminanceAlpha); }

        [Fact]
        public void CompressedIntensity_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EC, (int)PixelInternalFormat.CompressedIntensity); }

        [Fact]
        public void CompressedRgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84ED, (int)PixelInternalFormat.CompressedRgb); }

        [Fact]
        public void CompressedRgba_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EE, (int)PixelInternalFormat.CompressedRgba); }

        [Fact]
        public void DepthStencil_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84F9, (int)PixelInternalFormat.DepthStencil); }

        [Fact]
        public void Rgba32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8814, (int)PixelInternalFormat.Rgba32F); }

        [Fact]
        public void Rgb32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8815, (int)PixelInternalFormat.Rgb32F); }

        [Fact]
        public void Rgba16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x881A, (int)PixelInternalFormat.Rgba16F); }

        [Fact]
        public void Rgb16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x881B, (int)PixelInternalFormat.Rgb16F); }

        [Fact]
        public void Depth24Stencil8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88F0, (int)PixelInternalFormat.Depth24Stencil8); }

        [Fact]
        public void R11Fg11Fb10F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C3A, (int)PixelInternalFormat.R11Fg11Fb10F); }

        [Fact]
        public void Rgb9E5_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C3D, (int)PixelInternalFormat.Rgb9E5); }

        [Fact]
        public void Srgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C40, (int)PixelInternalFormat.Srgb); }

        [Fact]
        public void Srgb8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C41, (int)PixelInternalFormat.Srgb8); }

        [Fact]
        public void SrgbAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C42, (int)PixelInternalFormat.SrgbAlpha); }

        [Fact]
        public void Srgb8Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C43, (int)PixelInternalFormat.Srgb8Alpha8); }

        [Fact]
        public void SluminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C44, (int)PixelInternalFormat.SluminanceAlpha); }

        [Fact]
        public void Sluminance8Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C45, (int)PixelInternalFormat.Sluminance8Alpha8); }

        [Fact]
        public void Sluminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C46, (int)PixelInternalFormat.Sluminance); }

        [Fact]
        public void Sluminance8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C47, (int)PixelInternalFormat.Sluminance8); }

        [Fact]
        public void CompressedSrgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C48, (int)PixelInternalFormat.CompressedSrgb); }

        [Fact]
        public void CompressedSrgbAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C49, (int)PixelInternalFormat.CompressedSrgbAlpha); }

        [Fact]
        public void CompressedSluminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4A, (int)PixelInternalFormat.CompressedSluminance); }

        [Fact]
        public void CompressedSluminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4B, (int)PixelInternalFormat.CompressedSluminanceAlpha); }

        [Fact]
        public void CompressedSrgbS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4C, (int)PixelInternalFormat.CompressedSrgbS3TcDxt1Ext); }

        [Fact]
        public void CompressedSrgbAlphaS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4D, (int)PixelInternalFormat.CompressedSrgbAlphaS3TcDxt1Ext); }

        [Fact]
        public void CompressedSrgbAlphaS3TcDxt3Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4E, (int)PixelInternalFormat.CompressedSrgbAlphaS3TcDxt3Ext); }

        [Fact]
        public void CompressedSrgbAlphaS3TcDxt5Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4F, (int)PixelInternalFormat.CompressedSrgbAlphaS3TcDxt5Ext); }

        [Fact]
        public void DepthComponent32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8CAC, (int)PixelInternalFormat.DepthComponent32F); }

        [Fact]
        public void Depth32FStencil8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8CAD, (int)PixelInternalFormat.Depth32FStencil8); }

        [Fact]
        public void Rgba32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D70, (int)PixelInternalFormat.Rgba32Ui); }

        [Fact]
        public void Rgb32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D71, (int)PixelInternalFormat.Rgb32Ui); }

        [Fact]
        public void Rgba16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D76, (int)PixelInternalFormat.Rgba16Ui); }

        [Fact]
        public void Rgb16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D77, (int)PixelInternalFormat.Rgb16Ui); }

        [Fact]
        public void Rgba8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D7C, (int)PixelInternalFormat.Rgba8Ui); }

        [Fact]
        public void Rgb8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D7D, (int)PixelInternalFormat.Rgb8Ui); }

        [Fact]
        public void Rgba32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D82, (int)PixelInternalFormat.Rgba32I); }

        [Fact]
        public void Rgb32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D83, (int)PixelInternalFormat.Rgb32I); }

        [Fact]
        public void Rgba16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D88, (int)PixelInternalFormat.Rgba16I); }

        [Fact]
        public void Rgb16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D89, (int)PixelInternalFormat.Rgb16I); }

        [Fact]
        public void Rgba8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D8E, (int)PixelInternalFormat.Rgba8I); }

        [Fact]
        public void Rgb8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D8F, (int)PixelInternalFormat.Rgb8I); }

        [Fact]
        public void Float32UnsignedInt248Rev_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DAD, (int)PixelInternalFormat.Float32UnsignedInt248Rev); }

        [Fact]
        public void CompressedRedRgtc1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBB, (int)PixelInternalFormat.CompressedRedRgtc1); }

        [Fact]
        public void CompressedSignedRedRgtc1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBC, (int)PixelInternalFormat.CompressedSignedRedRgtc1); }

        [Fact]
        public void CompressedRgRgtc2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBD, (int)PixelInternalFormat.CompressedRgRgtc2); }

        [Fact]
        public void CompressedSignedRgRgtc2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBE, (int)PixelInternalFormat.CompressedSignedRgRgtc2); }

        [Fact]
        public void One_HasCorrectValue_EqualsExpected() { Assert.Equal(1, (int)PixelInternalFormat.One); }

        [Fact]
        public void Two_HasCorrectValue_EqualsExpected() { Assert.Equal(2, (int)PixelInternalFormat.Two); }

        [Fact]
        public void Three_HasCorrectValue_EqualsExpected() { Assert.Equal(3, (int)PixelInternalFormat.Three); }

        [Fact]
        public void Four_HasCorrectValue_EqualsExpected() { Assert.Equal(4, (int)PixelInternalFormat.Four); }

        [Fact]
        public void PixelInternalFormat_IsEnum_TypeIsCorrect() { Assert.True(typeof(PixelInternalFormat).IsEnum); }

        [Fact]
        public void PixelInternalFormat_IsPublic_CanBeAccessed() { Assert.True(typeof(PixelInternalFormat).IsPublic); }

        [Fact]
        public void PixelInternalFormat_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(PixelInternalFormat));
            Assert.NotEmpty(enumValues);
        }

        [Fact]
        public void PixelInternalFormat_CanCastToInt_ConversionIsValid()
        {
            int value = (int)PixelInternalFormat.Rgba;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void PixelInternalFormat_CanCompareValues_EqualityWorks()
        {
            PixelInternalFormat format1 = PixelInternalFormat.Rgba;
            PixelInternalFormat format2 = PixelInternalFormat.Rgba;
            Assert.Equal(format1, format2);
        }

        [Fact]
        public void PixelInternalFormat_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(PixelInternalFormat.Rgb, PixelInternalFormat.Rgba);
        }

        [Fact]
        public void DepthComponent16Sgix_IsAlias_EqualsDepthComponent16()
        {
            Assert.Equal((int)PixelInternalFormat.DepthComponent16, (int)PixelInternalFormat.DepthComponent16Sgix);
        }

        [Fact]
        public void DepthComponent24Sgix_IsAlias_EqualsDepthComponent24()
        {
            Assert.Equal((int)PixelInternalFormat.DepthComponent24, (int)PixelInternalFormat.DepthComponent24Sgix);
        }

        [Fact]
        public void DepthComponent32Sgix_IsAlias_EqualsDepthComponent32()
        {
            Assert.Equal((int)PixelInternalFormat.DepthComponent32, (int)PixelInternalFormat.DepthComponent32Sgix);
        }
    }
}
