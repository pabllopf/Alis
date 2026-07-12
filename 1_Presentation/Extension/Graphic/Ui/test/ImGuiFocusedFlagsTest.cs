// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiFocusedFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiFocusedFlags" /> enum values.
    /// </summary>
    public class ImGuiFocusedFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that ChildWindows has the expected value of 1.
        /// </summary>
        [Fact]
        public void ChildWindows_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.ChildWindows;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that RootWindow has the expected value of 2.
        /// </summary>
        [Fact]
        public void RootWindow_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.RootWindow;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that AnyWindow has the expected value of 4.
        /// </summary>
        [Fact]
        public void AnyWindow_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.AnyWindow;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoPopupHierarchy has the expected value of 8.
        /// </summary>
        [Fact]
        public void NoPopupHierarchy_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.NoPopupHierarchy;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that DockHierarchy has the expected value of 16.
        /// </summary>
        [Fact]
        public void DockHierarchy_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.DockHierarchy;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that RootAndChildWindows has the expected value of 3.
        /// </summary>
        [Fact]
        public void RootAndChildWindows_ShouldHaveCorrectValue()
        {
            ImGuiFocusedFlags flag = ImGuiFocusedFlags.RootAndChildWindows;
            Assert.Equal(3, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiFocusedFlags combined = ImGuiFocusedFlags.ChildWindows | ImGuiFocusedFlags.RootWindow;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
