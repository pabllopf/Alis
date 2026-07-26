// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiWindowClassTests.cs
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
    public class ImGuiWindowClassTests
    {
        [Fact]
        public void ClassId_Default_ReturnsZero()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(0u, windowClass.ClassId);
        }

        [Fact]
        public void ClassId_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const uint expected = 42;
            windowClass.ClassId = expected;
            Assert.Equal(expected, windowClass.ClassId);
        }

        [Fact]
        public void ParentViewportId_Default_ReturnsZero()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(0u, windowClass.ParentViewportId);
        }

        [Fact]
        public void ParentViewportId_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const uint expected = 7;
            windowClass.ParentViewportId = expected;
            Assert.Equal(expected, windowClass.ParentViewportId);
        }

        [Fact]
        public void ViewportFlagsOverrideSet_Default_ReturnsNone()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(ImGuiViewportFlags.None, windowClass.ViewportFlagsOverrideSet);
        }

        [Fact]
        public void ViewportFlagsOverrideSet_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const ImGuiViewportFlags expected = ImGuiViewportFlags.NoDecoration | ImGuiViewportFlags.TopMost;
            windowClass.ViewportFlagsOverrideSet = expected;
            Assert.Equal(expected, windowClass.ViewportFlagsOverrideSet);
        }

        [Fact]
        public void ViewportFlagsOverrideClear_Default_ReturnsNone()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(ImGuiViewportFlags.None, windowClass.ViewportFlagsOverrideClear);
        }

        [Fact]
        public void ViewportFlagsOverrideClear_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const ImGuiViewportFlags expected = ImGuiViewportFlags.NoTaskBarIcon | ImGuiViewportFlags.Minimized;
            windowClass.ViewportFlagsOverrideClear = expected;
            Assert.Equal(expected, windowClass.ViewportFlagsOverrideClear);
        }

        [Fact]
        public void TabItemFlagsOverrideSet_Default_ReturnsNone()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(ImGuiTabItemFlags.None, windowClass.TabItemFlagsOverrideSet);
        }

        [Fact]
        public void TabItemFlagsOverrideSet_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const ImGuiTabItemFlags expected = ImGuiTabItemFlags.SetSelected | ImGuiTabItemFlags.Leading;
            windowClass.TabItemFlagsOverrideSet = expected;
            Assert.Equal(expected, windowClass.TabItemFlagsOverrideSet);
        }

        [Fact]
        public void DockNodeFlagsOverrideSet_Default_ReturnsNone()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(ImGuiDockNodeFlags.None, windowClass.DockNodeFlagsOverrideSet);
        }

        [Fact]
        public void DockNodeFlagsOverrideSet_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const ImGuiDockNodeFlags expected = ImGuiDockNodeFlags.NoDockingInCentralNode | ImGuiDockNodeFlags.NoSplit;
            windowClass.DockNodeFlagsOverrideSet = expected;
            Assert.Equal(expected, windowClass.DockNodeFlagsOverrideSet);
        }

        [Fact]
        public void DockingAlwaysTabBar_Default_ReturnsZero()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(0, windowClass.DockingAlwaysTabBar);
        }

        [Fact]
        public void DockingAlwaysTabBar_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const byte expected = 1;
            windowClass.DockingAlwaysTabBar = expected;
            Assert.Equal(expected, windowClass.DockingAlwaysTabBar);
        }

        [Fact]
        public void DockingAllowUnclassed_Default_ReturnsZero()
        {
            ImGuiWindowClass windowClass = default;
            Assert.Equal(0, windowClass.DockingAllowUnclassed);
        }

        [Fact]
        public void DockingAllowUnclassed_SetGet_WorksCorrectly()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            const byte expected = 1;
            windowClass.DockingAllowUnclassed = expected;
            Assert.Equal(expected, windowClass.DockingAllowUnclassed);
        }

        [Fact]
        public void NewInstance_HasExpectedDefaults()
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

        [Fact]
        public void SetAllProperties_ThenReadAll_Matches()
        {
            ImGuiWindowClass windowClass = new ImGuiWindowClass
            {
                ClassId = 10,
                ParentViewportId = 20,
                ViewportFlagsOverrideSet = ImGuiViewportFlags.NoDecoration,
                ViewportFlagsOverrideClear = ImGuiViewportFlags.NoInputs,
                TabItemFlagsOverrideSet = ImGuiTabItemFlags.Trailing,
                DockNodeFlagsOverrideSet = ImGuiDockNodeFlags.NoResize,
                DockingAlwaysTabBar = 1,
                DockingAllowUnclassed = 0
            };

            Assert.Equal(10u, windowClass.ClassId);
            Assert.Equal(20u, windowClass.ParentViewportId);
            Assert.Equal(ImGuiViewportFlags.NoDecoration, windowClass.ViewportFlagsOverrideSet);
            Assert.Equal(ImGuiViewportFlags.NoInputs, windowClass.ViewportFlagsOverrideClear);
            Assert.Equal(ImGuiTabItemFlags.Trailing, windowClass.TabItemFlagsOverrideSet);
            Assert.Equal(ImGuiDockNodeFlags.NoResize, windowClass.DockNodeFlagsOverrideSet);
            Assert.Equal(1, windowClass.DockingAlwaysTabBar);
            Assert.Equal(0, windowClass.DockingAllowUnclassed);
        }

        [Fact]
        public void StructValueSemantics_CopyPreservesValues()
        {
            ImGuiWindowClass original = new ImGuiWindowClass
            {
                ClassId = 5,
                ParentViewportId = 15,
                ViewportFlagsOverrideSet = ImGuiViewportFlags.TopMost,
                ViewportFlagsOverrideClear = ImGuiViewportFlags.NoAutoMerge,
                TabItemFlagsOverrideSet = ImGuiTabItemFlags.NoTooltip,
                DockNodeFlagsOverrideSet = ImGuiDockNodeFlags.AutoHideTabBar,
                DockingAlwaysTabBar = 1,
                DockingAllowUnclassed = 1
            };

            ImGuiWindowClass copy = original;
            Assert.Equal(original.ClassId, copy.ClassId);
            Assert.Equal(original.ParentViewportId, copy.ParentViewportId);
            Assert.Equal(original.ViewportFlagsOverrideSet, copy.ViewportFlagsOverrideSet);
            Assert.Equal(original.ViewportFlagsOverrideClear, copy.ViewportFlagsOverrideClear);
            Assert.Equal(original.TabItemFlagsOverrideSet, copy.TabItemFlagsOverrideSet);
            Assert.Equal(original.DockNodeFlagsOverrideSet, copy.DockNodeFlagsOverrideSet);
            Assert.Equal(original.DockingAlwaysTabBar, copy.DockingAlwaysTabBar);
            Assert.Equal(original.DockingAllowUnclassed, copy.DockingAllowUnclassed);
        }
    }
}
