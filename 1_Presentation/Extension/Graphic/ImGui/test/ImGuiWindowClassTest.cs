// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiWindowClassTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui window class test class
    /// </summary>
    	  
	 public class ImGuiWindowClassTest 
    {
        /// <summary>
        ///     Tests that im gui window class should initialize with default values
        /// </summary>
        [Fact]
        public void ImGuiWindowClass_ShouldInitializeWithDefaultValues()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();

            Assert.Equal(0u, windowClass.ClassId);
            Assert.Equal(0u, windowClass.ParentViewportId);
            Assert.Equal(ImGuiViewportFlags.None, windowClass.ViewportFlagsOverrideSet);
            Assert.Equal(ImGuiViewportFlags.None, windowClass.ViewportFlagsOverrideClear);
            Assert.Equal(ImGuiTabItemFlags.None, windowClass.TabItemFlagsOverrideSet);
            Assert.Equal(ImGuiDockNodeFlags.None, windowClass.DockNodeFlagsOverrideSet);
            Assert.Equal(0, windowClass.DockingAlwaysTabBar);
            Assert.Equal(0, windowClass.DockingAllowUnclassed);
        }

        /// <summary>
        ///     Tests that im gui window class should set and get properties
        /// </summary>
        [Fact]
        public void ImGuiWindowClass_ShouldSetAndGetProperties()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass
            {
                ClassId = 1,
                ParentViewportId = 2,
                ViewportFlagsOverrideSet = ImGuiViewportFlags.NoDecoration,
                ViewportFlagsOverrideClear = ImGuiViewportFlags.NoTaskBarIcon,
                TabItemFlagsOverrideSet = ImGuiTabItemFlags.SetSelected,
                DockNodeFlagsOverrideSet = ImGuiDockNodeFlags.NoDockingInCentralNode,
                DockingAlwaysTabBar = 1,
                DockingAllowUnclassed = 1
            };

            Assert.Equal(1u, windowClass.ClassId);
            Assert.Equal(2u, windowClass.ParentViewportId);
            Assert.Equal(ImGuiViewportFlags.NoDecoration, windowClass.ViewportFlagsOverrideSet);
            Assert.Equal(ImGuiViewportFlags.NoTaskBarIcon, windowClass.ViewportFlagsOverrideClear);
            Assert.Equal(ImGuiTabItemFlags.SetSelected, windowClass.TabItemFlagsOverrideSet);
            Assert.Equal(ImGuiDockNodeFlags.NoDockingInCentralNode, windowClass.DockNodeFlagsOverrideSet);
            Assert.Equal(1, windowClass.DockingAlwaysTabBar);
            Assert.Equal(1, windowClass.DockingAllowUnclassed);
        }
    }
}