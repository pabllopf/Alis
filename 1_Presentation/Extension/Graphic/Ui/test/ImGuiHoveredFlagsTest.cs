// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiHoveredFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiHoveredFlags" /> enum values.
    /// </summary>
    public class ImGuiHoveredFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that ChildWindows has the expected value of 1.
        /// </summary>
        [Fact]
        public void ChildWindows_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.ChildWindows;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that RootWindow has the expected value of 2.
        /// </summary>
        [Fact]
        public void RootWindow_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.RootWindow;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that AnyWindow has the expected value of 4.
        /// </summary>
        [Fact]
        public void AnyWindow_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.AnyWindow;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoPopupHierarchy has the expected value of 8.
        /// </summary>
        [Fact]
        public void NoPopupHierarchy_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.NoPopupHierarchy;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that DockHierarchy has the expected value of 16.
        /// </summary>
        [Fact]
        public void DockHierarchy_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.DockHierarchy;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that AllowWhenBlockedByPopup has the expected value of 32.
        /// </summary>
        [Fact]
        public void AllowWhenBlockedByPopup_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.AllowWhenBlockedByPopup;
            Assert.Equal(32, (int)flag);
        }

        /// <summary>
        ///     Verifies that AllowWhenBlockedByActiveItem has the expected value of 128.
        /// </summary>
        [Fact]
        public void AllowWhenBlockedByActiveItem_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.AllowWhenBlockedByActiveItem;
            Assert.Equal(128, (int)flag);
        }

        /// <summary>
        ///     Verifies that AllowWhenOverlapped has the expected value of 256.
        /// </summary>
        [Fact]
        public void AllowWhenOverlapped_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.AllowWhenOverlapped;
            Assert.Equal(256, (int)flag);
        }

        /// <summary>
        ///     Verifies that AllowWhenDisabled has the expected value of 512.
        /// </summary>
        [Fact]
        public void AllowWhenDisabled_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.AllowWhenDisabled;
            Assert.Equal(512, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoNavOverride has the expected value of 1024.
        /// </summary>
        [Fact]
        public void NoNavOverride_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.NoNavOverride;
            Assert.Equal(1024, (int)flag);
        }

        /// <summary>
        ///     Verifies that RectOnly has the expected value of 416.
        /// </summary>
        [Fact]
        public void RectOnly_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.RectOnly;
            Assert.Equal(416, (int)flag);
        }

        /// <summary>
        ///     Verifies that RootAndChildWindows has the expected value of 3.
        /// </summary>
        [Fact]
        public void RootAndChildWindows_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.RootAndChildWindows;
            Assert.Equal(3, (int)flag);
        }

        /// <summary>
        ///     Verifies that DelayNormal has the expected value of 2048.
        /// </summary>
        [Fact]
        public void DelayNormal_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.DelayNormal;
            Assert.Equal(2048, (int)flag);
        }

        /// <summary>
        ///     Verifies that DelayShort has the expected value of 4096.
        /// </summary>
        [Fact]
        public void DelayShort_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.DelayShort;
            Assert.Equal(4096, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoSharedDelay has the expected value of 8192.
        /// </summary>
        [Fact]
        public void NoSharedDelay_ShouldHaveCorrectValue()
        {
            ImGuiHoveredFlags flag = ImGuiHoveredFlags.NoSharedDelay;
            Assert.Equal(8192, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiHoveredFlags combined = ImGuiHoveredFlags.ChildWindows | ImGuiHoveredFlags.RootWindow;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
