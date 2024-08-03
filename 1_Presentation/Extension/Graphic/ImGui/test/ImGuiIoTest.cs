// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIoTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im gui io test class
    /// </summary>
    public class ImGuiIoTest
    {
        /// <summary>
        /// Tests that keys data 407 should be initialized
        /// </summary>
        [Fact]
        public void KeysData407_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.True(io.KeysData407.AnalogValue >= 0);
        }

        /// <summary>
        /// Tests that keys data 408 should be initialized
        /// </summary>
        [Fact]
        public void KeysData408_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.True(io.KeysData408.AnalogValue >= 0);
        }

// Repeat similar tests for all KeysData properties

        /// <summary>
        /// Tests that want capture mouse unless popup close should be initialized
        /// </summary>
        [Fact]
        public void WantCaptureMouseUnlessPopupClose_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.WantCaptureMouseUnlessPopupClose);
        }

        /// <summary>
        /// Tests that mouse pos prev should be initialized
        /// </summary>
        [Fact]
        public void MousePosPrev_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2), io.MousePosPrev);
        }

        /// <summary>
        /// Tests that mouse clicked pos 0 should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedPos0_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2), io.MouseClickedPos0);
        }

// Repeat similar tests for all MouseClickedPos properties

        /// <summary>
        /// Tests that mouse clicked time should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedTime_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClickedTime);
        }

        /// <summary>
        /// Tests that mouse clicked should be initialized
        /// </summary>
        [Fact]
        public void MouseClicked_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClicked);
        }

        /// <summary>
        /// Tests that mouse double clicked should be initialized
        /// </summary>
        [Fact]
        public void MouseDoubleClicked_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDoubleClicked);
        }

        /// <summary>
        /// Tests that mouse clicked count should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedCount_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClickedCount);
        }

        /// <summary>
        /// Tests that mouse clicked last count should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedLastCount_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClickedLastCount);
        }

        /// <summary>
        /// Tests that mouse released should be initialized
        /// </summary>
        [Fact]
        public void MouseReleased_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseReleased);
        }

        /// <summary>
        /// Tests that mouse down owned should be initialized
        /// </summary>
        [Fact]
        public void MouseDownOwned_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownOwned);
        }

        /// <summary>
        /// Tests that mouse down owned unless popup close should be initialized
        /// </summary>
        [Fact]
        public void MouseDownOwnedUnlessPopupClose_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownOwnedUnlessPopupClose);
        }

        /// <summary>
        /// Tests that mouse down duration should be initialized
        /// </summary>
        [Fact]
        public void MouseDownDuration_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownDuration);
        }

        /// <summary>
        /// Tests that mouse down duration prev should be initialized
        /// </summary>
        [Fact]
        public void MouseDownDurationPrev_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownDurationPrev);
        }

        /// <summary>
        /// Tests that mouse drag max distance abs 0 should be initialized
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs0_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2), io.MouseDragMaxDistanceAbs0);
        }
        
        /// <summary>
        /// Tests that mouse drag max distance sqr should be initialized
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceSqr_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDragMaxDistanceSqr);
        }

        /// <summary>
        /// Tests that pen pressure should be initialized
        /// </summary>
        [Fact]
        public void PenPressure_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0f, io.PenPressure);
        }

        /// <summary>
        /// Tests that app focus lost should be initialized
        /// </summary>
        [Fact]
        public void AppFocusLost_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.AppFocusLost);
        }

        /// <summary>
        /// Tests that app accepting events should be initialized
        /// </summary>
        [Fact]
        public void AppAcceptingEvents_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.AppAcceptingEvents);
        }

        /// <summary>
        /// Tests that backend using legacy key arrays should be initialized
        /// </summary>
        [Fact]
        public void BackendUsingLegacyKeyArrays_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.BackendUsingLegacyKeyArrays);
        }

        /// <summary>
        /// Tests that backend using legacy nav input array should be initialized
        /// </summary>
        [Fact]
        public void BackendUsingLegacyNavInputArray_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.BackendUsingLegacyNavInputArray);
        }

        /// <summary>
        /// Tests that input queue surrogate should be initialized
        /// </summary>
        [Fact]
        public void InputQueueSurrogate_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.InputQueueSurrogate);
        }

        /// <summary>
        /// Tests that input queue characters should be initialized
        /// </summary>
        [Fact]
        public void InputQueueCharacters_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.True(io.InputQueueCharacters.Size >= 0);
        }
    }
}