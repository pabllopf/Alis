// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIoPtrTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im gui io ptr test class
    /// </summary>
    public class ImGuiIoPtrTest
    {
        /// <summary>
        /// Tests that want text input get set returns expected
        /// </summary>
        [Fact]
        public void WantTextInput_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.WantTextInput = true;
            Assert.True(ioPtr.WantTextInput);
            ioPtr.WantTextInput = false;
            Assert.False(ioPtr.WantTextInput);
        }

        /// <summary>
        /// Tests that want set mouse pos get set returns expected
        /// </summary>
        [Fact]
        public void WantSetMousePos_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.WantSetMousePos = true;
            Assert.True(ioPtr.WantSetMousePos);
            ioPtr.WantSetMousePos = false;
            Assert.False(ioPtr.WantSetMousePos);
        }

        /// <summary>
        /// Tests that want save ini settings get set returns expected
        /// </summary>
        [Fact]
        public void WantSaveIniSettings_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.WantSaveIniSettings = true;
            Assert.True(ioPtr.WantSaveIniSettings);
            ioPtr.WantSaveIniSettings = false;
            Assert.False(ioPtr.WantSaveIniSettings);
        }

        /// <summary>
        /// Tests that nav active get set returns expected
        /// </summary>
        [Fact]
        public void NavActive_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.NavActive = true;
            Assert.True(ioPtr.NavActive);
            ioPtr.NavActive = false;
            Assert.False(ioPtr.NavActive);
        }

        /// <summary>
        /// Tests that nav visible get set returns expected
        /// </summary>
        [Fact]
        public void NavVisible_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.NavVisible = true;
            Assert.True(ioPtr.NavVisible);
            ioPtr.NavVisible = false;
            Assert.False(ioPtr.NavVisible);
        }

        /// <summary>
        /// Tests that framerate get returns expected
        /// </summary>
        [Fact]
        public void Framerate_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            float expected = 60.0f;
            ioPtr.Framerate = expected;
            Assert.Equal(expected, ioPtr.Framerate);
        }

        /// <summary>
        /// Tests that metrics render vertices get set returns expected
        /// </summary>
        [Fact]
        public void MetricsRenderVertices_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            int expected = 100;
            ioPtr.MetricsRenderVertices = expected;
            Assert.Equal(expected, ioPtr.MetricsRenderVertices);
        }

        /// <summary>
        /// Tests that metrics render indices get set returns expected
        /// </summary>
        [Fact]
        public void MetricsRenderIndices_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            int expected = 200;
            ioPtr.MetricsRenderIndices = expected;
            Assert.Equal(expected, ioPtr.MetricsRenderIndices);
        }

        /// <summary>
        /// Tests that metrics render windows get set returns expected
        /// </summary>
        [Fact]
        public void MetricsRenderWindows_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            int expected = 300;
            ioPtr.MetricsRenderWindows = expected;
            Assert.Equal(expected, ioPtr.MetricsRenderWindows);
        }

        /// <summary>
        /// Tests that metrics active windows get set returns expected
        /// </summary>
        [Fact]
        public void MetricsActiveWindows_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            int expected = 400;
            ioPtr.MetricsActiveWindows = expected;
            Assert.Equal(expected, ioPtr.MetricsActiveWindows);
        }

        /// <summary>
        /// Tests that metrics active allocations get set returns expected
        /// </summary>
        [Fact]
        public void MetricsActiveAllocations_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            int expected = 500;
            ioPtr.MetricsActiveAllocations = expected;
            Assert.Equal(expected, ioPtr.MetricsActiveAllocations);
        }

        /// <summary>
        /// Tests that mouse delta get returns expected
        /// </summary>
        [Fact]
        public void MouseDelta_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Vector2 expected = new Vector2(1.0f, 2.0f);
            ioPtr.MouseDelta = expected;
            Assert.Equal(expected, ioPtr.MouseDelta);
        }

        /// <summary>
        /// Tests that key map get set returns expected
        /// </summary>
        [Fact]
        public void KeyMap_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<int> expected = new List<int> {1, 2, 3, 4, 5};
            ioPtr.KeyMap = expected;
            Assert.NotEqual(new int[652], ioPtr.KeyMap);
        }

        /// <summary>
        /// Tests that keys down get set returns expected
        /// </summary>
        [Fact]
        public void KeysDown_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.KeysDown = expected;
            Assert.NotEqual(new List<bool>(100), ioPtr.KeysDown);
        }

        /// <summary>
        /// Tests that nav inputs get set returns expected
        /// </summary>
        [Fact]
        public void NavInputs_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<float> expected = new List<float> {0.1f, 0.2f, 0.3f, 0.4f, 0.5f};
            ioPtr.NavInputs = expected;
            Assert.NotEqual(new float[21], ioPtr.NavInputs);
        }

        /// <summary>
        /// Tests that mouse pos get set returns expected
        /// </summary>
        [Fact]
        public void MousePos_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Vector2 expected = new Vector2(3.0f, 4.0f);
            ioPtr.MousePos = expected;
            Assert.Equal(expected, ioPtr.MousePos);
        }

        /// <summary>
        /// Tests that mouse down get set returns expected
        /// </summary>
        [Fact]
        public void MouseDown_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.MouseDown = expected;
            Assert.Equal(expected, ioPtr.MouseDown);
        }

        /// <summary>
        /// Tests that mouse wheel get set returns expected
        /// </summary>
        [Fact]
        public void MouseWheel_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            float expected = 1.5f;
            ioPtr.MouseWheel = expected;
            Assert.Equal(expected, ioPtr.MouseWheel);
        }

        /// <summary>
        /// Tests that mouse wheel h get set returns expected
        /// </summary>
        [Fact]
        public void MouseWheelH_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            float expected = 2.5f;
            ioPtr.MouseWheelH = expected;
            Assert.Equal(expected, ioPtr.MouseWheelH);
        }

        /// <summary>
        /// Tests that mouse hovered viewport get set returns expected
        /// </summary>
        [Fact]
        public void MouseHoveredViewport_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            uint expected = 123;
            ioPtr.MouseHoveredViewport = expected;
            Assert.Equal(expected, ioPtr.MouseHoveredViewport);
        }

        /// <summary>
        /// Tests that key ctrl get set returns expected
        /// </summary>
        [Fact]
        public void KeyCtrl_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.KeyCtrl = true;
            Assert.True(ioPtr.KeyCtrl);
            ioPtr.KeyCtrl = false;
            Assert.False(ioPtr.KeyCtrl);
        }

        /// <summary>
        /// Tests that key shift get set returns expected
        /// </summary>
        [Fact]
        public void KeyShift_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.KeyShift = true;
            Assert.True(ioPtr.KeyShift);
            ioPtr.KeyShift = false;
            Assert.False(ioPtr.KeyShift);
        }

        /// <summary>
        /// Tests that key alt get set returns expected
        /// </summary>
        [Fact]
        public void KeyAlt_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.KeyAlt = true;
            Assert.True(ioPtr.KeyAlt);
            ioPtr.KeyAlt = false;
            Assert.False(ioPtr.KeyAlt);
        }

        /// <summary>
        /// Tests that key super get set returns expected
        /// </summary>
        [Fact]
        public void KeySuper_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.KeySuper = true;
            Assert.True(ioPtr.KeySuper);
            ioPtr.KeySuper = false;
            Assert.False(ioPtr.KeySuper);
        }

        /// <summary>
        /// Tests that key mods get set returns expected
        /// </summary>
        [Fact]
        public void KeyMods_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ImGuiKey expected = ImGuiKey.A;
            ioPtr.KeyMods = expected;
            Assert.Equal(expected, ioPtr.KeyMods);
        }

        /// <summary>
        /// Tests that want capture mouse unless popup close get set returns expected
        /// </summary>
        [Fact]
        public void WantCaptureMouseUnlessPopupClose_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ioPtr.WantCaptureMouseUnlessPopupClose = true;
            Assert.True(ioPtr.WantCaptureMouseUnlessPopupClose);
            ioPtr.WantCaptureMouseUnlessPopupClose = false;
            Assert.False(ioPtr.WantCaptureMouseUnlessPopupClose);
        }

        /// <summary>
        /// Tests that mouse pos prev get returns expected
        /// </summary>
        [Fact]
        public void MousePosPrev_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Vector2 expected = new Vector2(5.0f, 6.0f);
            ioPtr.MousePosPrev = expected;
            Assert.Equal(expected, ioPtr.MousePosPrev);
        }
        
        /// <summary>
        /// Tests that mouse clicked time get set returns expected
        /// </summary>
        [Fact]
        public void MouseClickedTime_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<double> expected = new List<double> {1.0, 2.0, 3.0, 4.0, 5.0};
            ioPtr.MouseClickedTime = expected;
            Assert.Equal(expected, ioPtr.MouseClickedTime);
        }

        /// <summary>
        /// Tests that mouse clicked get set returns expected
        /// </summary>
        [Fact]
        public void MouseClicked_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.MouseClicked = expected;
            Assert.Equal(expected, ioPtr.MouseClicked);
        }

        /// <summary>
        /// Tests that mouse double clicked get set returns expected
        /// </summary>
        [Fact]
        public void MouseDoubleClicked_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.MouseDoubleClicked = expected;
            Assert.Equal(expected, ioPtr.MouseDoubleClicked);
        }

        /// <summary>
        /// Tests that mouse clicked count get set returns expected
        /// </summary>
        [Fact]
        public void MouseClickedCount_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<ushort> expected = new List<ushort> {1, 2, 3, 4, 5};
            ioPtr.MouseClickedCount = expected;
            Assert.Equal(expected, ioPtr.MouseClickedCount);
        }

        /// <summary>
        /// Tests that mouse clicked last count get set returns expected
        /// </summary>
        [Fact]
        public void MouseClickedLastCount_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<ushort> expected = new List<ushort> {1, 2, 3, 4, 5};
            ioPtr.MouseClickedLastCount = expected;
            Assert.Equal(expected, ioPtr.MouseClickedLastCount);
        }

        /// <summary>
        /// Tests that mouse released get set returns expected
        /// </summary>
        [Fact]
        public void MouseReleased_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.MouseReleased = expected;
            Assert.Equal(expected, ioPtr.MouseReleased);
        }

        /// <summary>
        /// Tests that mouse down owned get set returns expected
        /// </summary>
        [Fact]
        public void MouseDownOwned_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.MouseDownOwned = expected;
            Assert.Equal(expected, ioPtr.MouseDownOwned);
        }

        /// <summary>
        /// Tests that mouse down owned unless popup close get set returns expected
        /// </summary>
        [Fact]
        public void MouseDownOwnedUnlessPopupClose_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<bool> expected = new List<bool> {true, false, true, false, true};
            ioPtr.MouseDownOwnedUnlessPopupClose = expected;
            Assert.Equal(expected, ioPtr.MouseDownOwnedUnlessPopupClose);
        }

        /// <summary>
        /// Tests that mouse down duration get set returns expected
        /// </summary>
        [Fact]
        public void MouseDownDuration_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<float> expected = new List<float> {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
            ioPtr.MouseDownDuration = expected;
            Assert.Equal(expected, ioPtr.MouseDownDuration);
        }

        /// <summary>
        /// Tests that mouse down duration prev get set returns expected
        /// </summary>
        [Fact]
        public void MouseDownDurationPrev_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<float> expected = new List<float> {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
            ioPtr.MouseDownDurationPrev = expected;
            Assert.Equal(expected, ioPtr.MouseDownDurationPrev);
        }
        
        /// <summary>
        /// Tests that mouse drag max distance sqr get set returns expected
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceSqr_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            List<float> expected = new List<float> {1.0f, 2.0f, 3.0f, 4.0f, 5.0f};
            ioPtr.MouseDragMaxDistanceSqr = expected;
            Assert.Equal(expected, ioPtr.MouseDragMaxDistanceSqr);
        }

        /// <summary>
        /// Tests that pen pressure get returns expected
        /// </summary>
        [Fact]
        public void PenPressure_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            float expected = 1.0f;
            ioPtr.PenPressure = expected;
            Assert.Equal(expected, ioPtr.PenPressure);
        }

        /// <summary>
        /// Tests that app focus lost get returns expected
        /// </summary>
        [Fact]
        public void AppFocusLost_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            bool expected = true;
            ioPtr.AppFocusLost = expected;
            Assert.Equal(expected, ioPtr.AppFocusLost);
        }

        /// <summary>
        /// Tests that app accepting events get returns expected
        /// </summary>
        [Fact]
        public void AppAcceptingEvents_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            bool expected = true;
            ioPtr.AppAcceptingEvents = expected;
            Assert.Equal(expected, ioPtr.AppAcceptingEvents);
        }

        /// <summary>
        /// Tests that backend using legacy key arrays get returns expected
        /// </summary>
        [Fact]
        public void BackendUsingLegacyKeyArrays_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            sbyte expected = 1;
            ioPtr.BackendUsingLegacyKeyArrays = expected;
            Assert.Equal(expected, ioPtr.BackendUsingLegacyKeyArrays);
        }

        /// <summary>
        /// Tests that backend using legacy nav input array get returns expected
        /// </summary>
        [Fact]
        public void BackendUsingLegacyNavInputArray_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            bool expected = true;
            ioPtr.BackendUsingLegacyNavInputArray = expected;
            Assert.Equal(expected, ioPtr.BackendUsingLegacyNavInputArray);
        }

        /// <summary>
        /// Tests that input queue surrogate get returns expected
        /// </summary>
        [Fact]
        public void InputQueueSurrogate_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ushort expected = 123;
            ioPtr.InputQueueSurrogate = expected;
            Assert.Equal(expected, ioPtr.InputQueueSurrogate);
        }

        /// <summary>
        /// Tests that input queue characters get returns expected
        /// </summary>
        [Fact]
        public void InputQueueCharacters_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            ImVectorG<ushort> expected = new ImVectorG<ushort>();
            ioPtr.InputQueueCharacters = expected;
            Assert.Equal(expected, ioPtr.InputQueueCharacters);
        }
    }
}