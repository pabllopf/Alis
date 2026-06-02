// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiColorEditFlagsTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiColorEditFlags" /> enum values.
    /// </summary>
    public class ImGuiColorEditFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoAlpha has the expected value of 2.
        /// </summary>
        [Fact]
        public void NoAlpha_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoAlpha;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoPicker has the expected value of 4.
        /// </summary>
        [Fact]
        public void NoPicker_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoPicker;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoOptions has the expected value of 8.
        /// </summary>
        [Fact]
        public void NoOptions_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoOptions;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoSmallPreview has the expected value of 16.
        /// </summary>
        [Fact]
        public void NoSmallPreview_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoSmallPreview;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoInputs has the expected value of 32.
        /// </summary>
        [Fact]
        public void NoInputs_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoInputs;
            Assert.Equal(32, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoTooltip has the expected value of 64.
        /// </summary>
        [Fact]
        public void NoTooltip_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoTooltip;
            Assert.Equal(64, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoLabel has the expected value of 128.
        /// </summary>
        [Fact]
        public void NoLabel_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoLabel;
            Assert.Equal(128, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoSidePreview has the expected value of 256.
        /// </summary>
        [Fact]
        public void NoSidePreview_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoSidePreview;
            Assert.Equal(256, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoDragDrop has the expected value of 512.
        /// </summary>
        [Fact]
        public void NoDragDrop_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoDragDrop;
            Assert.Equal(512, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoBorder has the expected value of 1024.
        /// </summary>
        [Fact]
        public void NoBorder_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.NoBorder;
            Assert.Equal(1024, (int)flag);
        }

        /// <summary>
        ///     Verifies that AlphaBar has the expected value of 65536.
        /// </summary>
        [Fact]
        public void AlphaBar_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.AlphaBar;
            Assert.Equal(65536, (int)flag);
        }

        /// <summary>
        ///     Verifies that AlphaPreview has the expected value of 131072.
        /// </summary>
        [Fact]
        public void AlphaPreview_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.AlphaPreview;
            Assert.Equal(131072, (int)flag);
        }

        /// <summary>
        ///     Verifies that AlphaPreviewHalf has the expected value of 262144.
        /// </summary>
        [Fact]
        public void AlphaPreviewHalf_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.AlphaPreviewHalf;
            Assert.Equal(262144, (int)flag);
        }

        /// <summary>
        ///     Verifies that Hdr has the expected value of 524288.
        /// </summary>
        [Fact]
        public void Hdr_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.Hdr;
            Assert.Equal(524288, (int)flag);
        }

        /// <summary>
        ///     Verifies that DisplayRgb has the expected value of 1048576.
        /// </summary>
        [Fact]
        public void DisplayRgb_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.DisplayRgb;
            Assert.Equal(1048576, (int)flag);
        }

        /// <summary>
        ///     Verifies that DisplayHsv has the expected value of 2097152.
        /// </summary>
        [Fact]
        public void DisplayHsv_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.DisplayHsv;
            Assert.Equal(2097152, (int)flag);
        }

        /// <summary>
        ///     Verifies that DisplayHex has the expected value of 4194304.
        /// </summary>
        [Fact]
        public void DisplayHex_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.DisplayHex;
            Assert.Equal(4194304, (int)flag);
        }

        /// <summary>
        ///     Verifies that Uint8 has the expected value of 8388608.
        /// </summary>
        [Fact]
        public void Uint8_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.Uint8;
            Assert.Equal(8388608, (int)flag);
        }

        /// <summary>
        ///     Verifies that Float has the expected value of 16777216.
        /// </summary>
        [Fact]
        public void Float_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.Float;
            Assert.Equal(16777216, (int)flag);
        }

        /// <summary>
        ///     Verifies that PickerHueBar has the expected value of 33554432.
        /// </summary>
        [Fact]
        public void PickerHueBar_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.PickerHueBar;
            Assert.Equal(33554432, (int)flag);
        }

        /// <summary>
        ///     Verifies that PickerHueWheel has the expected value of 67108864.
        /// </summary>
        [Fact]
        public void PickerHueWheel_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.PickerHueWheel;
            Assert.Equal(67108864, (int)flag);
        }

        /// <summary>
        ///     Verifies that InputRgb has the expected value of 134217728.
        /// </summary>
        [Fact]
        public void InputRgb_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.InputRgb;
            Assert.Equal(134217728, (int)flag);
        }

        /// <summary>
        ///     Verifies that InputHsv has the expected value of 268435456.
        /// </summary>
        [Fact]
        public void InputHsv_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.InputHsv;
            Assert.Equal(268435456, (int)flag);
        }

        /// <summary>
        ///     Verifies that DefaultOptions has the expected value of 177209344.
        /// </summary>
        [Fact]
        public void DefaultOptions_ShouldHaveCorrectValue()
        {
            ImGuiColorEditFlags flag = ImGuiColorEditFlags.DefaultOptions;
            Assert.Equal(177209344, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiColorEditFlags combined = ImGuiColorEditFlags.NoAlpha | ImGuiColorEditFlags.NoPicker;
            int expected = 2 | 4;
            Assert.Equal(expected, (int)combined);
        }
    }
}
