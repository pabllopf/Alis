// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDockNodeFlagsTest.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiDockNodeFlags" /> enum values.
    /// </summary>
    public class ImGuiDockNodeFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [RequireCImguiSystemFact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that KeepAliveOnly has the expected value of 1.
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeepAliveOnly_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.KeepAliveOnly;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoDockingInCentralNode has the expected value of 4.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NoDockingInCentralNode_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.NoDockingInCentralNode;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that PassthruCentralNode has the expected value of 8.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PassthruCentralNode_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.PassthruCentralNode;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoSplit has the expected value of 16.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NoSplit_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.NoSplit;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoResize has the expected value of 32.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NoResize_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.NoResize;
            Assert.Equal(32, (int)flag);
        }

        /// <summary>
        ///     Verifies that AutoHideTabBar has the expected value of 64.
        /// </summary>
        [RequireCImguiSystemFact]
        public void AutoHideTabBar_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.AutoHideTabBar;
            Assert.Equal(64, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoTabBar has the expected value of 128.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NoTabBar_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.NoTabBar;
            Assert.Equal(128, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoWindowMenuButton has the expected value of 256.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NoWindowMenuButton_ShouldHaveCorrectValue()
        {
            ImGuiDockNodeFlags flag = ImGuiDockNodeFlags.NoWindowMenuButton;
            Assert.Equal(256, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiDockNodeFlags combined = ImGuiDockNodeFlags.NoSplit | ImGuiDockNodeFlags.NoResize;
            int expected = 16 | 32;
            Assert.Equal(expected, (int)combined);
        }
    }
}
