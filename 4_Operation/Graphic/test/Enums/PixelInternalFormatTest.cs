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
        /// <summary>
        /// Tests that depth component has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1902, (int)PixelInternalFormat.DepthComponent); }

        /// <summary>
        /// Tests that alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void Alpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1906, (int)PixelInternalFormat.Alpha); }

        /// <summary>
        /// Tests that rgb has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1907, (int)PixelInternalFormat.Rgb); }

        /// <summary>
        /// Tests that rgba has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1908, (int)PixelInternalFormat.Rgba); }

        /// <summary>
        /// Tests that luminance has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1909, (int)PixelInternalFormat.Luminance); }

        /// <summary>
        /// Tests that luminance alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void LuminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x190A, (int)PixelInternalFormat.LuminanceAlpha); }

        /// <summary>
        /// Tests that r 3 g 3 b 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void R3G3B2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x2A10, (int)PixelInternalFormat.R3G3B2); }

        /// <summary>
        /// Tests that alpha 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Alpha4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803B, (int)PixelInternalFormat.Alpha4); }

        /// <summary>
        /// Tests that alpha 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803C, (int)PixelInternalFormat.Alpha8); }

        /// <summary>
        /// Tests that alpha 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Alpha12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803D, (int)PixelInternalFormat.Alpha12); }

        /// <summary>
        /// Tests that alpha 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Alpha16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803E, (int)PixelInternalFormat.Alpha16); }

        /// <summary>
        /// Tests that luminance 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x803F, (int)PixelInternalFormat.Luminance4); }

        /// <summary>
        /// Tests that luminance 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8040, (int)PixelInternalFormat.Luminance8); }

        /// <summary>
        /// Tests that luminance 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8041, (int)PixelInternalFormat.Luminance12); }

        /// <summary>
        /// Tests that luminance 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8042, (int)PixelInternalFormat.Luminance16); }

        /// <summary>
        /// Tests that luminance 4 alpha 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance4Alpha4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8043, (int)PixelInternalFormat.Luminance4Alpha4); }

        /// <summary>
        /// Tests that luminance 6 alpha 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance6Alpha2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8044, (int)PixelInternalFormat.Luminance6Alpha2); }

        /// <summary>
        /// Tests that luminance 8 alpha 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance8Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8045, (int)PixelInternalFormat.Luminance8Alpha8); }

        /// <summary>
        /// Tests that luminance 12 alpha 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance12Alpha4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8046, (int)PixelInternalFormat.Luminance12Alpha4); }

        /// <summary>
        /// Tests that luminance 12 alpha 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance12Alpha12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8047, (int)PixelInternalFormat.Luminance12Alpha12); }

        /// <summary>
        /// Tests that luminance 16 alpha 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Luminance16Alpha16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8048, (int)PixelInternalFormat.Luminance16Alpha16); }

        /// <summary>
        /// Tests that intensity has correct value equals expected
        /// </summary>
        [Fact]
        public void Intensity_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8049, (int)PixelInternalFormat.Intensity); }

        /// <summary>
        /// Tests that intensity 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Intensity4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804A, (int)PixelInternalFormat.Intensity4); }

        /// <summary>
        /// Tests that intensity 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Intensity8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804B, (int)PixelInternalFormat.Intensity8); }

        /// <summary>
        /// Tests that intensity 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Intensity12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804C, (int)PixelInternalFormat.Intensity12); }

        /// <summary>
        /// Tests that intensity 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Intensity16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804D, (int)PixelInternalFormat.Intensity16); }

        /// <summary>
        /// Tests that rgb 2 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb2Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804E, (int)PixelInternalFormat.Rgb2Ext); }

        /// <summary>
        /// Tests that rgb 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x804F, (int)PixelInternalFormat.Rgb4); }

        /// <summary>
        /// Tests that rgb 5 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb5_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8050, (int)PixelInternalFormat.Rgb5); }

        /// <summary>
        /// Tests that rgb 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8051, (int)PixelInternalFormat.Rgb8); }

        /// <summary>
        /// Tests that rgb 10 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb10_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8052, (int)PixelInternalFormat.Rgb10); }

        /// <summary>
        /// Tests that rgb 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8053, (int)PixelInternalFormat.Rgb12); }

        /// <summary>
        /// Tests that rgb 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8054, (int)PixelInternalFormat.Rgb16); }

        /// <summary>
        /// Tests that rgba 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8055, (int)PixelInternalFormat.Rgba2); }

        /// <summary>
        /// Tests that rgba 4 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8056, (int)PixelInternalFormat.Rgba4); }

        /// <summary>
        /// Tests that rgb 5 a 1 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb5A1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8057, (int)PixelInternalFormat.Rgb5A1); }

        /// <summary>
        /// Tests that rgba 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8058, (int)PixelInternalFormat.Rgba8); }

        /// <summary>
        /// Tests that rgb 10 a 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb10A2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8059, (int)PixelInternalFormat.Rgb10A2); }

        /// <summary>
        /// Tests that rgba 12 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba12_HasCorrectValue_EqualsExpected() { Assert.Equal(0x805A, (int)PixelInternalFormat.Rgba12); }

        /// <summary>
        /// Tests that rgba 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x805B, (int)PixelInternalFormat.Rgba16); }

        /// <summary>
        /// Tests that dual alpha 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualAlpha4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8110, (int)PixelInternalFormat.DualAlpha4Sgis); }

        /// <summary>
        /// Tests that dual alpha 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualAlpha8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8111, (int)PixelInternalFormat.DualAlpha8Sgis); }

        /// <summary>
        /// Tests that dual alpha 12 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualAlpha12Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8112, (int)PixelInternalFormat.DualAlpha12Sgis); }

        /// <summary>
        /// Tests that dual alpha 16 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualAlpha16Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8113, (int)PixelInternalFormat.DualAlpha16Sgis); }

        /// <summary>
        /// Tests that dual luminance 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualLuminance4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8114, (int)PixelInternalFormat.DualLuminance4Sgis); }

        /// <summary>
        /// Tests that dual luminance 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualLuminance8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8115, (int)PixelInternalFormat.DualLuminance8Sgis); }

        /// <summary>
        /// Tests that dual luminance 12 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualLuminance12Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8116, (int)PixelInternalFormat.DualLuminance12Sgis); }

        /// <summary>
        /// Tests that dual luminance 16 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualLuminance16Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8117, (int)PixelInternalFormat.DualLuminance16Sgis); }

        /// <summary>
        /// Tests that dual intensity 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualIntensity4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8118, (int)PixelInternalFormat.DualIntensity4Sgis); }

        /// <summary>
        /// Tests that dual intensity 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualIntensity8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8119, (int)PixelInternalFormat.DualIntensity8Sgis); }

        /// <summary>
        /// Tests that dual intensity 12 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualIntensity12Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811A, (int)PixelInternalFormat.DualIntensity12Sgis); }

        /// <summary>
        /// Tests that dual intensity 16 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualIntensity16Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811B, (int)PixelInternalFormat.DualIntensity16Sgis); }

        /// <summary>
        /// Tests that dual luminance alpha 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualLuminanceAlpha4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811C, (int)PixelInternalFormat.DualLuminanceAlpha4Sgis); }

        /// <summary>
        /// Tests that dual luminance alpha 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void DualLuminanceAlpha8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811D, (int)PixelInternalFormat.DualLuminanceAlpha8Sgis); }

        /// <summary>
        /// Tests that quad alpha 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void QuadAlpha4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811E, (int)PixelInternalFormat.QuadAlpha4Sgis); }

        /// <summary>
        /// Tests that quad alpha 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void QuadAlpha8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x811F, (int)PixelInternalFormat.QuadAlpha8Sgis); }

        /// <summary>
        /// Tests that quad luminance 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void QuadLuminance4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8120, (int)PixelInternalFormat.QuadLuminance4Sgis); }

        /// <summary>
        /// Tests that quad luminance 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void QuadLuminance8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8121, (int)PixelInternalFormat.QuadLuminance8Sgis); }

        /// <summary>
        /// Tests that quad intensity 4 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void QuadIntensity4Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8122, (int)PixelInternalFormat.QuadIntensity4Sgis); }

        /// <summary>
        /// Tests that quad intensity 8 sgis has correct value equals expected
        /// </summary>
        [Fact]
        public void QuadIntensity8Sgis_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8123, (int)PixelInternalFormat.QuadIntensity8Sgis); }

        /// <summary>
        /// Tests that depth component 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81a5, (int)PixelInternalFormat.DepthComponent16); }

        /// <summary>
        /// Tests that depth component 16 sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent16Sgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81A5, (int)PixelInternalFormat.DepthComponent16Sgix); }

        /// <summary>
        /// Tests that depth component 24 has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent24_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81a6, (int)PixelInternalFormat.DepthComponent24); }

        /// <summary>
        /// Tests that depth component 24 sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent24Sgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81A6, (int)PixelInternalFormat.DepthComponent24Sgix); }

        /// <summary>
        /// Tests that depth component 32 has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent32_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81a7, (int)PixelInternalFormat.DepthComponent32); }

        /// <summary>
        /// Tests that depth component 32 sgix has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent32Sgix_HasCorrectValue_EqualsExpected() { Assert.Equal(0x81A7, (int)PixelInternalFormat.DepthComponent32Sgix); }

        /// <summary>
        /// Tests that compressed red has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRed_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8225, (int)PixelInternalFormat.CompressedRed); }

        /// <summary>
        /// Tests that compressed rg has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRg_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8226, (int)PixelInternalFormat.CompressedRg); }

        /// <summary>
        /// Tests that r 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void R8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8229, (int)PixelInternalFormat.R8); }

        /// <summary>
        /// Tests that r 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void R16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822A, (int)PixelInternalFormat.R16); }

        /// <summary>
        /// Tests that rg 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822B, (int)PixelInternalFormat.Rg8); }

        /// <summary>
        /// Tests that rg 16 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg16_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822C, (int)PixelInternalFormat.Rg16); }

        /// <summary>
        /// Tests that r 16 f has correct value equals expected
        /// </summary>
        [Fact]
        public void R16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822D, (int)PixelInternalFormat.R16F); }

        /// <summary>
        /// Tests that r 32 f has correct value equals expected
        /// </summary>
        [Fact]
        public void R32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822E, (int)PixelInternalFormat.R32F); }

        /// <summary>
        /// Tests that rg 16 f has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x822F, (int)PixelInternalFormat.Rg16F); }

        /// <summary>
        /// Tests that rg 32 f has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8230, (int)PixelInternalFormat.Rg32F); }

        /// <summary>
        /// Tests that r 8 i has correct value equals expected
        /// </summary>
        [Fact]
        public void R8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8231, (int)PixelInternalFormat.R8I); }

        /// <summary>
        /// Tests that r 8 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void R8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8232, (int)PixelInternalFormat.R8Ui); }

        /// <summary>
        /// Tests that r 16 i has correct value equals expected
        /// </summary>
        [Fact]
        public void R16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8233, (int)PixelInternalFormat.R16I); }

        /// <summary>
        /// Tests that r 16 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void R16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8234, (int)PixelInternalFormat.R16Ui); }

        /// <summary>
        /// Tests that r 32 i has correct value equals expected
        /// </summary>
        [Fact]
        public void R32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8235, (int)PixelInternalFormat.R32I); }

        /// <summary>
        /// Tests that r 32 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void R32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8236, (int)PixelInternalFormat.R32Ui); }

        /// <summary>
        /// Tests that rg 8 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8237, (int)PixelInternalFormat.Rg8I); }

        /// <summary>
        /// Tests that rg 8 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8238, (int)PixelInternalFormat.Rg8Ui); }

        /// <summary>
        /// Tests that rg 16 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8239, (int)PixelInternalFormat.Rg16I); }

        /// <summary>
        /// Tests that rg 16 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x823A, (int)PixelInternalFormat.Rg16Ui); }

        /// <summary>
        /// Tests that rg 32 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x823B, (int)PixelInternalFormat.Rg32I); }

        /// <summary>
        /// Tests that rg 32 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rg32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x823C, (int)PixelInternalFormat.Rg32Ui); }

        /// <summary>
        /// Tests that compressed rgb s 3 tc dxt 1 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgbS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F0, (int)PixelInternalFormat.CompressedRgbS3TcDxt1Ext); }

        /// <summary>
        /// Tests that compressed rgba s 3 tc dxt 1 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgbaS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F1, (int)PixelInternalFormat.CompressedRgbaS3TcDxt1Ext); }

        /// <summary>
        /// Tests that compressed rgba s 3 tc dxt 3 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgbaS3TcDxt3Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F2, (int)PixelInternalFormat.CompressedRgbaS3TcDxt3Ext); }

        /// <summary>
        /// Tests that compressed rgba s 3 tc dxt 5 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgbaS3TcDxt5Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x83F3, (int)PixelInternalFormat.CompressedRgbaS3TcDxt5Ext); }

        /// <summary>
        /// Tests that compressed alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84E9, (int)PixelInternalFormat.CompressedAlpha); }

        /// <summary>
        /// Tests that compressed luminance has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedLuminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EA, (int)PixelInternalFormat.CompressedLuminance); }

        /// <summary>
        /// Tests that compressed luminance alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedLuminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EB, (int)PixelInternalFormat.CompressedLuminanceAlpha); }

        /// <summary>
        /// Tests that compressed intensity has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedIntensity_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EC, (int)PixelInternalFormat.CompressedIntensity); }

        /// <summary>
        /// Tests that compressed rgb has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84ED, (int)PixelInternalFormat.CompressedRgb); }

        /// <summary>
        /// Tests that compressed rgba has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgba_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84EE, (int)PixelInternalFormat.CompressedRgba); }

        /// <summary>
        /// Tests that depth stencil has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthStencil_HasCorrectValue_EqualsExpected() { Assert.Equal(0x84F9, (int)PixelInternalFormat.DepthStencil); }

        /// <summary>
        /// Tests that rgba 32 f has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8814, (int)PixelInternalFormat.Rgba32F); }

        /// <summary>
        /// Tests that rgb 32 f has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8815, (int)PixelInternalFormat.Rgb32F); }

        /// <summary>
        /// Tests that rgba 16 f has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x881A, (int)PixelInternalFormat.Rgba16F); }

        /// <summary>
        /// Tests that rgb 16 f has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb16F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x881B, (int)PixelInternalFormat.Rgb16F); }

        /// <summary>
        /// Tests that depth 24 stencil 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Depth24Stencil8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x88F0, (int)PixelInternalFormat.Depth24Stencil8); }

        /// <summary>
        /// Tests that r 11 fg 11 fb 10 f has correct value equals expected
        /// </summary>
        [Fact]
        public void R11Fg11Fb10F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C3A, (int)PixelInternalFormat.R11Fg11Fb10F); }

        /// <summary>
        /// Tests that rgb 9 e 5 has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb9E5_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C3D, (int)PixelInternalFormat.Rgb9E5); }

        /// <summary>
        /// Tests that srgb has correct value equals expected
        /// </summary>
        [Fact]
        public void Srgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C40, (int)PixelInternalFormat.Srgb); }

        /// <summary>
        /// Tests that srgb 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Srgb8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C41, (int)PixelInternalFormat.Srgb8); }

        /// <summary>
        /// Tests that srgb alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void SrgbAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C42, (int)PixelInternalFormat.SrgbAlpha); }

        /// <summary>
        /// Tests that srgb 8 alpha 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Srgb8Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C43, (int)PixelInternalFormat.Srgb8Alpha8); }

        /// <summary>
        /// Tests that sluminance alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void SluminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C44, (int)PixelInternalFormat.SluminanceAlpha); }

        /// <summary>
        /// Tests that sluminance 8 alpha 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Sluminance8Alpha8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C45, (int)PixelInternalFormat.Sluminance8Alpha8); }

        /// <summary>
        /// Tests that sluminance has correct value equals expected
        /// </summary>
        [Fact]
        public void Sluminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C46, (int)PixelInternalFormat.Sluminance); }

        /// <summary>
        /// Tests that sluminance 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Sluminance8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C47, (int)PixelInternalFormat.Sluminance8); }

        /// <summary>
        /// Tests that compressed srgb has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSrgb_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C48, (int)PixelInternalFormat.CompressedSrgb); }

        /// <summary>
        /// Tests that compressed srgb alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSrgbAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C49, (int)PixelInternalFormat.CompressedSrgbAlpha); }

        /// <summary>
        /// Tests that compressed sluminance has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSluminance_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4A, (int)PixelInternalFormat.CompressedSluminance); }

        /// <summary>
        /// Tests that compressed sluminance alpha has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSluminanceAlpha_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4B, (int)PixelInternalFormat.CompressedSluminanceAlpha); }

        /// <summary>
        /// Tests that compressed srgb s 3 tc dxt 1 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSrgbS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4C, (int)PixelInternalFormat.CompressedSrgbS3TcDxt1Ext); }

        /// <summary>
        /// Tests that compressed srgb alpha s 3 tc dxt 1 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSrgbAlphaS3TcDxt1Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4D, (int)PixelInternalFormat.CompressedSrgbAlphaS3TcDxt1Ext); }

        /// <summary>
        /// Tests that compressed srgb alpha s 3 tc dxt 3 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSrgbAlphaS3TcDxt3Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4E, (int)PixelInternalFormat.CompressedSrgbAlphaS3TcDxt3Ext); }

        /// <summary>
        /// Tests that compressed srgb alpha s 3 tc dxt 5 ext has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSrgbAlphaS3TcDxt5Ext_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8C4F, (int)PixelInternalFormat.CompressedSrgbAlphaS3TcDxt5Ext); }

        /// <summary>
        /// Tests that depth component 32 f has correct value equals expected
        /// </summary>
        [Fact]
        public void DepthComponent32F_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8CAC, (int)PixelInternalFormat.DepthComponent32F); }

        /// <summary>
        /// Tests that depth 32 f stencil 8 has correct value equals expected
        /// </summary>
        [Fact]
        public void Depth32FStencil8_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8CAD, (int)PixelInternalFormat.Depth32FStencil8); }

        /// <summary>
        /// Tests that rgba 32 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D70, (int)PixelInternalFormat.Rgba32Ui); }

        /// <summary>
        /// Tests that rgb 32 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb32Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D71, (int)PixelInternalFormat.Rgb32Ui); }

        /// <summary>
        /// Tests that rgba 16 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D76, (int)PixelInternalFormat.Rgba16Ui); }

        /// <summary>
        /// Tests that rgb 16 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb16Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D77, (int)PixelInternalFormat.Rgb16Ui); }

        /// <summary>
        /// Tests that rgba 8 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D7C, (int)PixelInternalFormat.Rgba8Ui); }

        /// <summary>
        /// Tests that rgb 8 ui has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb8Ui_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D7D, (int)PixelInternalFormat.Rgb8Ui); }

        /// <summary>
        /// Tests that rgba 32 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D82, (int)PixelInternalFormat.Rgba32I); }

        /// <summary>
        /// Tests that rgb 32 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb32I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D83, (int)PixelInternalFormat.Rgb32I); }

        /// <summary>
        /// Tests that rgba 16 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D88, (int)PixelInternalFormat.Rgba16I); }

        /// <summary>
        /// Tests that rgb 16 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb16I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D89, (int)PixelInternalFormat.Rgb16I); }

        /// <summary>
        /// Tests that rgba 8 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgba8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D8E, (int)PixelInternalFormat.Rgba8I); }

        /// <summary>
        /// Tests that rgb 8 i has correct value equals expected
        /// </summary>
        [Fact]
        public void Rgb8I_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8D8F, (int)PixelInternalFormat.Rgb8I); }

        /// <summary>
        /// Tests that float 32 unsigned int 248 rev has correct value equals expected
        /// </summary>
        [Fact]
        public void Float32UnsignedInt248Rev_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DAD, (int)PixelInternalFormat.Float32UnsignedInt248Rev); }

        /// <summary>
        /// Tests that compressed red rgtc 1 has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRedRgtc1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBB, (int)PixelInternalFormat.CompressedRedRgtc1); }

        /// <summary>
        /// Tests that compressed signed red rgtc 1 has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSignedRedRgtc1_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBC, (int)PixelInternalFormat.CompressedSignedRedRgtc1); }

        /// <summary>
        /// Tests that compressed rg rgtc 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedRgRgtc2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBD, (int)PixelInternalFormat.CompressedRgRgtc2); }

        /// <summary>
        /// Tests that compressed signed rg rgtc 2 has correct value equals expected
        /// </summary>
        [Fact]
        public void CompressedSignedRgRgtc2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DBE, (int)PixelInternalFormat.CompressedSignedRgRgtc2); }

        /// <summary>
        /// Tests that one has correct value equals expected
        /// </summary>
        [Fact]
        public void One_HasCorrectValue_EqualsExpected() { Assert.Equal(1, (int)PixelInternalFormat.One); }

        /// <summary>
        /// Tests that two has correct value equals expected
        /// </summary>
        [Fact]
        public void Two_HasCorrectValue_EqualsExpected() { Assert.Equal(2, (int)PixelInternalFormat.Two); }

        /// <summary>
        /// Tests that three has correct value equals expected
        /// </summary>
        [Fact]
        public void Three_HasCorrectValue_EqualsExpected() { Assert.Equal(3, (int)PixelInternalFormat.Three); }

        /// <summary>
        /// Tests that four has correct value equals expected
        /// </summary>
        [Fact]
        public void Four_HasCorrectValue_EqualsExpected() { Assert.Equal(4, (int)PixelInternalFormat.Four); }

        /// <summary>
        /// Tests that pixel internal format is enum type is correct
        /// </summary>
        [Fact]
        public void PixelInternalFormat_IsEnum_TypeIsCorrect() { Assert.True(typeof(PixelInternalFormat).IsEnum); }

        /// <summary>
        /// Tests that pixel internal format is public can be accessed
        /// </summary>
        [Fact]
        public void PixelInternalFormat_IsPublic_CanBeAccessed() { Assert.True(typeof(PixelInternalFormat).IsPublic); }

        /// <summary>
        /// Tests that pixel internal format has multiple values count is not zero
        /// </summary>
        [Fact]
        public void PixelInternalFormat_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(PixelInternalFormat));
            Assert.NotEmpty(enumValues);
        }

        /// <summary>
        /// Tests that pixel internal format can cast to int conversion is valid
        /// </summary>
        [Fact]
        public void PixelInternalFormat_CanCastToInt_ConversionIsValid()
        {
            int value = (int)PixelInternalFormat.Rgba;
            Assert.IsType<int>(value);
        }

        /// <summary>
        /// Tests that pixel internal format can compare values equality works
        /// </summary>
        [Fact]
        public void PixelInternalFormat_CanCompareValues_EqualityWorks()
        {
            PixelInternalFormat format1 = PixelInternalFormat.Rgba;
            PixelInternalFormat format2 = PixelInternalFormat.Rgba;
            Assert.Equal(format1, format2);
        }

        /// <summary>
        /// Tests that pixel internal format different values are not equal
        /// </summary>
        [Fact]
        public void PixelInternalFormat_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(PixelInternalFormat.Rgb, PixelInternalFormat.Rgba);
        }

        /// <summary>
        /// Tests that depth component 16 sgix is alias equals depth component 16
        /// </summary>
        [Fact]
        public void DepthComponent16Sgix_IsAlias_EqualsDepthComponent16()
        {
            Assert.Equal((int)PixelInternalFormat.DepthComponent16, (int)PixelInternalFormat.DepthComponent16Sgix);
        }

        /// <summary>
        /// Tests that depth component 24 sgix is alias equals depth component 24
        /// </summary>
        [Fact]
        public void DepthComponent24Sgix_IsAlias_EqualsDepthComponent24()
        {
            Assert.Equal((int)PixelInternalFormat.DepthComponent24, (int)PixelInternalFormat.DepthComponent24Sgix);
        }

        /// <summary>
        /// Tests that depth component 32 sgix is alias equals depth component 32
        /// </summary>
        [Fact]
        public void DepthComponent32Sgix_IsAlias_EqualsDepthComponent32()
        {
            Assert.Equal((int)PixelInternalFormat.DepthComponent32, (int)PixelInternalFormat.DepthComponent32Sgix);
        }
    }
}
