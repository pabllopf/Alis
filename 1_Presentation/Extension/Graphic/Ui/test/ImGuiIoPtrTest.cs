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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui io ptr test class
    /// </summary>
    public class ImGuiIoPtrTest
    {
        /// <summary>
        ///     Tests that want text input get set returns expected
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
        ///     Tests that want set mouse pos get set returns expected
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
        ///     Tests that want save ini settings get set returns expected
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
        ///     Tests that nav active get set returns expected
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
        ///     Tests that nav visible get set returns expected
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
        ///     Tests that framerate get returns expected
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
        ///     Tests that metrics render vertices get set returns expected
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
        ///     Tests that metrics render indices get set returns expected
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
        ///     Tests that metrics render windows get set returns expected
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
        ///     Tests that metrics active windows get set returns expected
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
        ///     Tests that metrics active allocations get set returns expected
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
        ///     Tests that mouse delta get returns expected
        /// </summary>
        [Fact]
        public void MouseDelta_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Vector2F expected = new Vector2F(1.0f, 2.0f);
            ioPtr.MouseDelta = expected;
            Assert.Equal(expected, ioPtr.MouseDelta);
        }

        /// <summary>
        ///     Tests that key map get set returns expected
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
        ///     Tests that keys down get set returns expected
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
        ///     Tests that nav inputs get set returns expected
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
        ///     Tests that mouse pos get set returns expected
        /// </summary>
        [Fact]
        public void MousePos_GetSet_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Vector2F expected = new Vector2F(3.0f, 4.0f);
            ioPtr.MousePos = expected;
            Assert.Equal(expected, ioPtr.MousePos);
        }

        /// <summary>
        ///     Tests that mouse down get set returns expected
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
        ///     Tests that mouse wheel get set returns expected
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
        ///     Tests that mouse wheel h get set returns expected
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
        ///     Tests that mouse hovered viewport get set returns expected
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
        ///     Tests that key ctrl get set returns expected
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
        ///     Tests that key shift get set returns expected
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
        ///     Tests that key alt get set returns expected
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
        ///     Tests that key super get set returns expected
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
        ///     Tests that key mods get set returns expected
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
        ///     Tests that want capture mouse unless popup close get set returns expected
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
        ///     Tests that mouse pos prev get returns expected
        /// </summary>
        [Fact]
        public void MousePosPrev_Get_ReturnsExpected()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Vector2F expected = new Vector2F(5.0f, 6.0f);
            ioPtr.MousePosPrev = expected;
            Assert.Equal(expected, ioPtr.MousePosPrev);
        }

        /// <summary>
        ///     Tests that mouse clicked time get set returns expected
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
        ///     Tests that mouse clicked get set returns expected
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
        ///     Tests that mouse double clicked get set returns expected
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
        ///     Tests that mouse clicked count get set returns expected
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
        ///     Tests that mouse clicked last count get set returns expected
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
        ///     Tests that mouse released get set returns expected
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
        ///     Tests that mouse down owned get set returns expected
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
        ///     Tests that mouse down owned unless popup close get set returns expected
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
        ///     Tests that mouse down duration get set returns expected
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
        ///     Tests that mouse down duration prev get set returns expected
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
        ///     Tests that mouse drag max distance sqr get set returns expected
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
        ///     Tests that pen pressure get returns expected
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
        ///     Tests that app focus lost get returns expected
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
        ///     Tests that app accepting events get returns expected
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
        ///     Tests that backend using legacy key arrays get returns expected
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
        ///     Tests that backend using legacy nav input array get returns expected
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
        ///     Tests that input queue surrogate get returns expected
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
        ///     Tests that input queue characters get returns expected
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

        /// <summary>
        ///     Tests that add focus event should add focus event
        /// </summary>
        [Fact]
        public void AddFocusEvent_ShouldAddFocusEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddFocusEvent(true));
            // Assuming ImGuiNative.ImGuiIO_AddFocusEvent modifies some internal state
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add input character should add input character
        /// </summary>
        [Fact]
        public void AddInputCharacter_ShouldAddInputCharacter()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddInputCharacter(65)); // 'A'
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add input characters utf 8 should add input characters utf 8
        /// </summary>
        [Fact]
        public void AddInputCharactersUtf8_ShouldAddInputCharactersUtf8()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddInputCharactersUtf8("Test"));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add input character utf 16 should add input character utf 16
        /// </summary>
        [Fact]
        public void AddInputCharacterUtf16_ShouldAddInputCharacterUtf16()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddInputCharacterUtf16(65)); // 'A'
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add key analog event should add key analog event
        /// </summary>
        [Fact]
        public void AddKeyAnalogEvent_ShouldAddKeyAnalogEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddKeyAnalogEvent(ImGuiKey.Tab, true, 1.0f));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add key event should add key event
        /// </summary>
        [Fact]
        public void AddKeyEvent_ShouldAddKeyEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddKeyEvent(ImGuiKey.Tab, true));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add mouse button event should add mouse button event
        /// </summary>
        [Fact]
        public void AddMouseButtonEvent_ShouldAddMouseButtonEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddMouseButtonEvent(0, true));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add mouse pos event should add mouse pos event
        /// </summary>
        [Fact]
        public void AddMousePosEvent_ShouldAddMousePosEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddMousePosEvent(100.0f, 200.0f));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add mouse viewport event should add mouse viewport event
        /// </summary>
        [Fact]
        public void AddMouseViewportEvent_ShouldAddMouseViewportEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddMouseViewportEvent(1));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that add mouse wheel event should add mouse wheel event
        /// </summary>
        [Fact]
        public void AddMouseWheelEvent_ShouldAddMouseWheelEvent()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.AddMouseWheelEvent(1.0f, 0.0f));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that clear input characters should clear input characters
        /// </summary>
        [Fact]
        public void ClearInputCharacters_ShouldClearInputCharacters()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.ClearInputCharacters());
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that clear input keys should clear input keys
        /// </summary>
        [Fact]
        public void ClearInputKeys_ShouldClearInputKeys()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.ClearInputKeys());
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that set app accepting events should set app accepting events
        /// </summary>
        [Fact]
        public void SetAppAcceptingEvents_ShouldSetAppAcceptingEvents()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.SetAppAcceptingEvents(true));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that set key event native data should set key event native data
        /// </summary>
        [Fact]
        public void SetKeyEventNativeData_ShouldSetKeyEventNativeData()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.SetKeyEventNativeData(ImGuiKey.Tab, 9, 15));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that set key event native data with legacy index should set key event native data
        /// </summary>
        [Fact]
        public void SetKeyEventNativeData_WithLegacyIndex_ShouldSetKeyEventNativeData()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiIoPtr ioPtr = new ImGuiIoPtr(io);
            Assert.Throws<DllNotFoundException>(() => ioPtr.SetKeyEventNativeData(ImGuiKey.Tab, 9, 15, 1));
            // Validate the internal state change here
        }

        /// <summary>
        ///     Tests that config viewports no auto merge should set and get
        /// </summary>
        [Fact]
        public void ConfigViewportsNoAutoMerge_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigViewportsNoAutoMerge = 1;
            Assert.Equal(1, io.ConfigViewportsNoAutoMerge);
        }

        /// <summary>
        ///     Tests that config viewports no task bar icon should set and get
        /// </summary>
        [Fact]
        public void ConfigViewportsNoTaskBarIcon_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigViewportsNoTaskBarIcon = 1;
            Assert.Equal(1, io.ConfigViewportsNoTaskBarIcon);
        }

        /// <summary>
        ///     Tests that config viewports no decoration should set and get
        /// </summary>
        [Fact]
        public void ConfigViewportsNoDecoration_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigViewportsNoDecoration = 1;
            Assert.Equal(1, io.ConfigViewportsNoDecoration);
        }

        /// <summary>
        ///     Tests that config viewports no default parent should set and get
        /// </summary>
        [Fact]
        public void ConfigViewportsNoDefaultParent_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigViewportsNoDefaultParent = 1;
            Assert.Equal(1, io.ConfigViewportsNoDefaultParent);
        }

        /// <summary>
        ///     Tests that mouse draw cursor should set and get
        /// </summary>
        [Fact]
        public void MouseDrawCursor_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDrawCursor = 1;
            Assert.Equal(1, io.MouseDrawCursor);
        }

        /// <summary>
        ///     Tests that config mac osx behaviors should set and get
        /// </summary>
        [Fact]
        public void ConfigMacOsxBehaviors_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigMacOsxBehaviors = 1;
            Assert.Equal(1, io.ConfigMacOsxBehaviors);
        }

        /// <summary>
        ///     Tests that config input trickle event queue should set and get
        /// </summary>
        [Fact]
        public void ConfigInputTrickleEventQueue_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigInputTrickleEventQueue = 1;
            Assert.Equal(1, io.ConfigInputTrickleEventQueue);
        }

        /// <summary>
        ///     Tests that config input text cursor blink should set and get
        /// </summary>
        [Fact]
        public void ConfigInputTextCursorBlink_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigInputTextCursorBlink = 1;
            Assert.Equal(1, io.ConfigInputTextCursorBlink);
        }

        /// <summary>
        ///     Tests that config input text enter keep active should set and get
        /// </summary>
        [Fact]
        public void ConfigInputTextEnterKeepActive_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigInputTextEnterKeepActive = 1;
            Assert.Equal(1, io.ConfigInputTextEnterKeepActive);
        }

        /// <summary>
        ///     Tests that config drag click to input text should set and get
        /// </summary>
        [Fact]
        public void ConfigDragClickToInputText_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigDragClickToInputText = 1;
            Assert.Equal(1, io.ConfigDragClickToInputText);
        }

        /// <summary>
        ///     Tests that config windows resize from edges should set and get
        /// </summary>
        [Fact]
        public void ConfigWindowsResizeFromEdges_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigWindowsResizeFromEdges = 1;
            Assert.Equal(1, io.ConfigWindowsResizeFromEdges);
        }

        /// <summary>
        ///     Tests that config windows move from title bar only should set and get
        /// </summary>
        [Fact]
        public void ConfigWindowsMoveFromTitleBarOnly_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigWindowsMoveFromTitleBarOnly = 1;
            Assert.Equal(1, io.ConfigWindowsMoveFromTitleBarOnly);
        }

        /// <summary>
        ///     Tests that config memory compact timer should set and get
        /// </summary>
        [Fact]
        public void ConfigMemoryCompactTimer_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.ConfigMemoryCompactTimer = 1.0f;
            Assert.Equal(1.0f, io.ConfigMemoryCompactTimer);
        }

        /// <summary>
        ///     Tests that backend platform name should set and get
        /// </summary>
        [Fact]
        public void BackendPlatformName_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.BackendPlatformName = ptr;
            Assert.Equal(ptr, io.BackendPlatformName);
        }

        /// <summary>
        ///     Tests that backend renderer name should set and get
        /// </summary>
        [Fact]
        public void BackendRendererName_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.BackendRendererName = ptr;
            Assert.Equal(ptr, io.BackendRendererName);
        }

        /// <summary>
        ///     Tests that backend platform user data should set and get
        /// </summary>
        [Fact]
        public void BackendPlatformUserData_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.BackendPlatformUserData = ptr;
            Assert.Equal(ptr, io.BackendPlatformUserData);
        }

        /// <summary>
        ///     Tests that backend renderer user data should set and get
        /// </summary>
        [Fact]
        public void BackendRendererUserData_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.BackendRendererUserData = ptr;
            Assert.Equal(ptr, io.BackendRendererUserData);
        }

        /// <summary>
        ///     Tests that backend language user data should set and get
        /// </summary>
        [Fact]
        public void BackendLanguageUserData_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.BackendLanguageUserData = ptr;
            Assert.Equal(ptr, io.BackendLanguageUserData);
        }

        /// <summary>
        ///     Tests that get clipboard text fn should set and get
        /// </summary>
        [Fact]
        public void GetClipboardTextFn_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.GetClipboardTextFn = ptr;
            Assert.Equal(ptr, io.GetClipboardTextFn);
        }

        /// <summary>
        ///     Tests that set clipboard text fn should set and get
        /// </summary>
        [Fact]
        public void SetClipboardTextFn_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.SetClipboardTextFn = ptr;
            Assert.Equal(ptr, io.SetClipboardTextFn);
        }

        /// <summary>
        ///     Tests that clipboard user data should set and get
        /// </summary>
        [Fact]
        public void ClipboardUserData_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.ClipboardUserData = ptr;
            Assert.Equal(ptr, io.ClipboardUserData);
        }

        /// <summary>
        ///     Tests that set platform ime data fn should set and get
        /// </summary>
        [Fact]
        public void SetPlatformImeDataFn_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.SetPlatformImeDataFn = ptr;
            Assert.Equal(ptr, io.SetPlatformImeDataFn);
        }

        /// <summary>
        ///     Tests that unused padding should set and get
        /// </summary>
        [Fact]
        public void UnusedPadding_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr ptr = new IntPtr(123);
            io.UnusedPadding = ptr;
            Assert.Equal(ptr, io.UnusedPadding);
        }

        /// <summary>
        ///     Tests that want capture mouse should set and get
        /// </summary>
        [Fact]
        public void WantCaptureMouse_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.WantCaptureMouse = 1;
            Assert.Equal(1, io.WantCaptureMouse);
        }

        /// <summary>
        ///     Tests that want capture keyboard should set and get
        /// </summary>
        [Fact]
        public void WantCaptureKeyboard_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.WantCaptureKeyboard = 1;
            Assert.Equal(1, io.WantCaptureKeyboard);
        }

        /// <summary>
        ///     Tests that want text input should set and get
        /// </summary>
        [Fact]
        public void WantTextInput_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.WantTextInput = 1;
            Assert.Equal(1, io.WantTextInput);
        }

        /// <summary>
        ///     Tests that want set mouse pos should set and get
        /// </summary>
        [Fact]
        public void WantSetMousePos_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.WantSetMousePos = 1;
            Assert.Equal(1, io.WantSetMousePos);
        }

        /// <summary>
        ///     Tests that want save ini settings should set and get
        /// </summary>
        [Fact]
        public void WantSaveIniSettings_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.WantSaveIniSettings = 1;
            Assert.Equal(1, io.WantSaveIniSettings);
        }

        /// <summary>
        ///     Tests that nav active should set and get
        /// </summary>
        [Fact]
        public void NavActive_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.NavActive = 1;
            Assert.Equal(1, io.NavActive);
        }

        /// <summary>
        ///     Tests that nav visible should set and get
        /// </summary>
        [Fact]
        public void NavVisible_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.NavVisible = 1;
            Assert.Equal(1, io.NavVisible);
        }

        /// <summary>
        ///     Tests that framerate should set and get
        /// </summary>
        [Fact]
        public void Framerate_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.Framerate = 60.0f;
            Assert.Equal(60.0f, io.Framerate);
        }

        /// <summary>
        ///     Tests that metrics render vertices should set and get
        /// </summary>
        [Fact]
        public void MetricsRenderVertices_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MetricsRenderVertices = 1000;
            Assert.Equal(1000, io.MetricsRenderVertices);
        }

        /// <summary>
        ///     Tests that metrics render indices should set and get
        /// </summary>
        [Fact]
        public void MetricsRenderIndices_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MetricsRenderIndices = 500;
            Assert.Equal(500, io.MetricsRenderIndices);
        }

        /// <summary>
        ///     Tests that metrics render windows should set and get
        /// </summary>
        [Fact]
        public void MetricsRenderWindows_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MetricsRenderWindows = 10;
            Assert.Equal(10, io.MetricsRenderWindows);
        }

        /// <summary>
        ///     Tests that metrics active windows should set and get
        /// </summary>
        [Fact]
        public void MetricsActiveWindows_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MetricsActiveWindows = 5;
            Assert.Equal(5, io.MetricsActiveWindows);
        }

        /// <summary>
        ///     Tests that metrics active allocations should set and get
        /// </summary>
        [Fact]
        public void MetricsActiveAllocations_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MetricsActiveAllocations = 20;
            Assert.Equal(20, io.MetricsActiveAllocations);
        }

        /// <summary>
        ///     Tests that mouse delta should set and get
        /// </summary>
        [Fact]
        public void MouseDelta_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F delta = new Vector2F(1.0f, 1.0f);
            io.MouseDelta = delta;
            Assert.Equal(delta, io.MouseDelta);
        }

        /// <summary>
        ///     Tests that mouse pos should set and get
        /// </summary>
        [Fact]
        public void MousePos_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F pos = new Vector2F(100.0f, 200.0f);
            io.MousePos = pos;
            Assert.Equal(pos, io.MousePos);
        }

        /// <summary>
        ///     Tests that mouse wheel should set and get
        /// </summary>
        [Fact]
        public void MouseWheel_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseWheel = 1.0f;
            Assert.Equal(1.0f, io.MouseWheel);
        }

        /// <summary>
        ///     Tests that mouse wheel h should set and get
        /// </summary>
        [Fact]
        public void MouseWheelH_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseWheelH = 1.0f;
            Assert.Equal(1.0f, io.MouseWheelH);
        }

        /// <summary>
        ///     Tests that mouse hovered viewport should set and get
        /// </summary>
        [Fact]
        public void MouseHoveredViewport_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseHoveredViewport = 123;
            Assert.Equal(123u, io.MouseHoveredViewport);
        }

        /// <summary>
        ///     Tests that key ctrl should set and get
        /// </summary>
        [Fact]
        public void KeyCtrl_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeyCtrl = 1;
            Assert.Equal(1, io.KeyCtrl);
        }

        /// <summary>
        ///     Tests that key shift should set and get
        /// </summary>
        [Fact]
        public void KeyShift_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeyShift = 1;
            Assert.Equal(1, io.KeyShift);
        }

        /// <summary>
        ///     Tests that key alt should set and get
        /// </summary>
        [Fact]
        public void KeyAlt_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeyAlt = 1;
            Assert.Equal(1, io.KeyAlt);
        }

        /// <summary>
        ///     Tests that key super should set and get
        /// </summary>
        [Fact]
        public void KeySuper_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeySuper = 1;
            Assert.Equal(1, io.KeySuper);
        }

        /// <summary>
        ///     Tests that key mods should set and get
        /// </summary>
        [Fact]
        public void KeyMods_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKey keyMods = new ImGuiKey();
            io.KeyMods = keyMods;
            Assert.Equal(keyMods, io.KeyMods);
        }

        /// <summary>
        ///     Tests that keys data should set and get
        /// </summary>
        [Fact]
        public void KeysData_Should_SetAndGet()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData keyData = new ImGuiKeyData();
            io.KeysData0 = keyData;
            Assert.Equal(keyData, io.KeysData0);
        }

        /// <summary>
        ///     Tests that keys data 106 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData106_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData106 = value;
            Assert.Equal(value, obj.KeysData106);
        }

        /// <summary>
        ///     Tests that keys data 107 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData107_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData107 = value;
            Assert.Equal(value, obj.KeysData107);
        }

        /// <summary>
        ///     Tests that keys data 108 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData108_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData108 = value;
            Assert.Equal(value, obj.KeysData108);
        }

        /// <summary>
        ///     Tests that keys data 109 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData109_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData109 = value;
            Assert.Equal(value, obj.KeysData109);
        }

        /// <summary>
        ///     Tests that keys data 110 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData110_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData110 = value;
            Assert.Equal(value, obj.KeysData110);
        }

        /// <summary>
        ///     Tests that keys data 111 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData111_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData111 = value;
            Assert.Equal(value, obj.KeysData111);
        }

        /// <summary>
        ///     Tests that keys data 112 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData112_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData112 = value;
            Assert.Equal(value, obj.KeysData112);
        }

        /// <summary>
        ///     Tests that keys data 113 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData113_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData113 = value;
            Assert.Equal(value, obj.KeysData113);
        }

        /// <summary>
        ///     Tests that keys data 114 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData114_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData114 = value;
            Assert.Equal(value, obj.KeysData114);
        }

        /// <summary>
        ///     Tests that keys data 115 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData115_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData115 = value;
            Assert.Equal(value, obj.KeysData115);
        }

        /// <summary>
        ///     Tests that keys data 116 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData116_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData116 = value;
            Assert.Equal(value, obj.KeysData116);
        }

        /// <summary>
        ///     Tests that keys data 117 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData117_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData117 = value;
            Assert.Equal(value, obj.KeysData117);
        }

        /// <summary>
        ///     Tests that keys data 118 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData118_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData118 = value;
            Assert.Equal(value, obj.KeysData118);
        }

        /// <summary>
        ///     Tests that keys data 119 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData119_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData119 = value;
            Assert.Equal(value, obj.KeysData119);
        }

        /// <summary>
        ///     Tests that keys data 120 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData120_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData120 = value;
            Assert.Equal(value, obj.KeysData120);
        }

        /// <summary>
        ///     Tests that keys data 121 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData121_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData121 = value;
            Assert.Equal(value, obj.KeysData121);
        }

        /// <summary>
        ///     Tests that keys data 122 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData122_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData122 = value;
            Assert.Equal(value, obj.KeysData122);
        }

        /// <summary>
        ///     Tests that keys data 123 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData123_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData123 = value;
            Assert.Equal(value, obj.KeysData123);
        }

        /// <summary>
        ///     Tests that keys data 124 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData124_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData124 = value;
            Assert.Equal(value, obj.KeysData124);
        }

        /// <summary>
        ///     Tests that keys data 125 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData125_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData125 = value;
            Assert.Equal(value, obj.KeysData125);
        }

        /// <summary>
        ///     Tests that keys data 126 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData126_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData126 = value;
            Assert.Equal(value, obj.KeysData126);
        }

        /// <summary>
        ///     Tests that keys data 127 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData127_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData127 = value;
            Assert.Equal(value, obj.KeysData127);
        }

        /// <summary>
        ///     Tests that keys data 128 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData128_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData128 = value;
            Assert.Equal(value, obj.KeysData128);
        }

        /// <summary>
        ///     Tests that keys data 129 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData129_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData129 = value;
            Assert.Equal(value, obj.KeysData129);
        }

        /// <summary>
        ///     Tests that keys data 130 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData130_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData130 = value;
            Assert.Equal(value, obj.KeysData130);
        }

        /// <summary>
        ///     Tests that keys data 131 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData131_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData131 = value;
            Assert.Equal(value, obj.KeysData131);
        }

        /// <summary>
        ///     Tests that keys data 132 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData132_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData132 = value;
            Assert.Equal(value, obj.KeysData132);
        }

        /// <summary>
        ///     Tests that keys data 133 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData133_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData133 = value;
            Assert.Equal(value, obj.KeysData133);
        }

        /// <summary>
        ///     Tests that keys data 134 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData134_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData134 = value;
            Assert.Equal(value, obj.KeysData134);
        }

        /// <summary>
        ///     Tests that keys data 135 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData135_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData135 = value;
            Assert.Equal(value, obj.KeysData135);
        }

        /// <summary>
        ///     Tests that keys data 136 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData136_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData136 = value;
            Assert.Equal(value, obj.KeysData136);
        }

        /// <summary>
        ///     Tests that keys data 137 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData137_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData137 = value;
            Assert.Equal(value, obj.KeysData137);
        }

        /// <summary>
        ///     Tests that keys data 138 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData138_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData138 = value;
            Assert.Equal(value, obj.KeysData138);
        }

        /// <summary>
        ///     Tests that keys data 139 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData139_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData139 = value;
            Assert.Equal(value, obj.KeysData139);
        }

        /// <summary>
        ///     Tests that keys data 140 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData140_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData140 = value;
            Assert.Equal(value, obj.KeysData140);
        }

        /// <summary>
        ///     Tests that keys data 141 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData141_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData141 = value;
            Assert.Equal(value, obj.KeysData141);
        }

        /// <summary>
        ///     Tests that keys data 142 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData142_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData142 = value;
            Assert.Equal(value, obj.KeysData142);
        }

        /// <summary>
        ///     Tests that keys data 143 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData143_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData143 = value;
            Assert.Equal(value, obj.KeysData143);
        }

        /// <summary>
        ///     Tests that keys data 144 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData144_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData144 = value;
            Assert.Equal(value, obj.KeysData144);
        }

        /// <summary>
        ///     Tests that keys data 145 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData145_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData145 = value;
            Assert.Equal(value, obj.KeysData145);
        }

        /// <summary>
        ///     Tests that keys data 146 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData146_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData146 = value;
            Assert.Equal(value, obj.KeysData146);
        }

        /// <summary>
        ///     Tests that keys data 147 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData147_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData147 = value;
            Assert.Equal(value, obj.KeysData147);
        }

        /// <summary>
        ///     Tests that keys data 148 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData148_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData148 = value;
            Assert.Equal(value, obj.KeysData148);
        }

        /// <summary>
        ///     Tests that keys data 149 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData149_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData149 = value;
            Assert.Equal(value, obj.KeysData149);
        }

        /// <summary>
        ///     Tests that keys data 150 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData150_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData150 = value;
            Assert.Equal(value, obj.KeysData150);
        }

        /// <summary>
        ///     Tests that keys data 151 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData151_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData151 = value;
            Assert.Equal(value, obj.KeysData151);
        }

        /// <summary>
        ///     Tests that keys data 152 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData152_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData152 = value;
            Assert.Equal(value, obj.KeysData152);
        }

        /// <summary>
        ///     Tests that keys data 153 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData153_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData153 = value;
            Assert.Equal(value, obj.KeysData153);
        }

        /// <summary>
        ///     Tests that keys data 154 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData154_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData154 = value;
            Assert.Equal(value, obj.KeysData154);
        }

        /// <summary>
        ///     Tests that keys data 155 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData155_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData155 = value;
            Assert.Equal(value, obj.KeysData155);
        }

        /// <summary>
        ///     Tests that keys data 156 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData156_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData156 = value;
            Assert.Equal(value, obj.KeysData156);
        }

        /// <summary>
        ///     Tests that keys data 157 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData157_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData157 = value;
            Assert.Equal(value, obj.KeysData157);
        }

        /// <summary>
        ///     Tests that keys data 158 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData158_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData158 = value;
            Assert.Equal(value, obj.KeysData158);
        }

        /// <summary>
        ///     Tests that keys data 159 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData159_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData159 = value;
            Assert.Equal(value, obj.KeysData159);
        }

        /// <summary>
        ///     Tests that keys data 160 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData160_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData160 = value;
            Assert.Equal(value, obj.KeysData160);
        }

        /// <summary>
        ///     Tests that keys data 161 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData161_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData161 = value;
            Assert.Equal(value, obj.KeysData161);
        }

        /// <summary>
        ///     Tests that keys data 162 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData162_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData162 = value;
            Assert.Equal(value, obj.KeysData162);
        }

        /// <summary>
        ///     Tests that keys data 163 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData163_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData163 = value;
            Assert.Equal(value, obj.KeysData163);
        }

        /// <summary>
        ///     Tests that keys data 164 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData164_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData164 = value;
            Assert.Equal(value, obj.KeysData164);
        }

        /// <summary>
        ///     Tests that keys data 165 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData165_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData165 = value;
            Assert.Equal(value, obj.KeysData165);
        }

        /// <summary>
        ///     Tests that keys data 166 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData166_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData166 = value;
            Assert.Equal(value, obj.KeysData166);
        }

        /// <summary>
        ///     Tests that keys data 167 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData167_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData167 = value;
            Assert.Equal(value, obj.KeysData167);
        }

        /// <summary>
        ///     Tests that keys data 168 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData168_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData168 = value;
            Assert.Equal(value, obj.KeysData168);
        }

        /// <summary>
        ///     Tests that keys data 169 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData169_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData169 = value;
            Assert.Equal(value, obj.KeysData169);
        }

        /// <summary>
        ///     Tests that keys data 170 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData170_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData170 = value;
            Assert.Equal(value, obj.KeysData170);
        }

        /// <summary>
        ///     Tests that keys data 171 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData171_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData171 = value;
            Assert.Equal(value, obj.KeysData171);
        }

        /// <summary>
        ///     Tests that keys data 172 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData172_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData172 = value;
            Assert.Equal(value, obj.KeysData172);
        }

        /// <summary>
        ///     Tests that keys data 173 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData173_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData173 = value;
            Assert.Equal(value, obj.KeysData173);
        }

        /// <summary>
        ///     Tests that keys data 174 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData174_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData174 = value;
            Assert.Equal(value, obj.KeysData174);
        }

        /// <summary>
        ///     Tests that keys data 175 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData175_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData175 = value;
            Assert.Equal(value, obj.KeysData175);
        }

        /// <summary>
        ///     Tests that keys data 176 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData176_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData176 = value;
            Assert.Equal(value, obj.KeysData176);
        }

        /// <summary>
        ///     Tests that keys data 177 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData177_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData177 = value;
            Assert.Equal(value, obj.KeysData177);
        }

        /// <summary>
        ///     Tests that keys data 178 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData178_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData178 = value;
            Assert.Equal(value, obj.KeysData178);
        }

        /// <summary>
        ///     Tests that keys data 179 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData179_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData179 = value;
            Assert.Equal(value, obj.KeysData179);
        }

        /// <summary>
        ///     Tests that keys data 180 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData180_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData180 = value;
            Assert.Equal(value, obj.KeysData180);
        }

        /// <summary>
        ///     Tests that keys data 440 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData440_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData440 = value;
            Assert.Equal(value, obj.KeysData440);
        }

        /// <summary>
        ///     Tests that keys data 441 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData441_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData441 = value;
            Assert.Equal(value, obj.KeysData441);
        }

        /// <summary>
        ///     Tests that keys data 442 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData442_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData442 = value;
            Assert.Equal(value, obj.KeysData442);
        }

        /// <summary>
        ///     Tests that keys data 443 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData443_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData443 = value;
            Assert.Equal(value, obj.KeysData443);
        }

        /// <summary>
        ///     Tests that keys data 444 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData444_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData444 = value;
            Assert.Equal(value, obj.KeysData444);
        }

        /// <summary>
        ///     Tests that keys data 445 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData445_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData445 = value;
            Assert.Equal(value, obj.KeysData445);
        }

        /// <summary>
        ///     Tests that keys data 446 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData446_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData446 = value;
            Assert.Equal(value, obj.KeysData446);
        }

        /// <summary>
        ///     Tests that keys data 447 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData447_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData447 = value;
            Assert.Equal(value, obj.KeysData447);
        }

        /// <summary>
        ///     Tests that keys data 448 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData448_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData448 = value;
            Assert.Equal(value, obj.KeysData448);
        }

        /// <summary>
        ///     Tests that keys data 449 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData449_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData449 = value;
            Assert.Equal(value, obj.KeysData449);
        }

        /// <summary>
        ///     Tests that keys data 450 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData450_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData450 = value;
            Assert.Equal(value, obj.KeysData450);
        }

        /// <summary>
        ///     Tests that keys data 451 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData451_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData451 = value;
            Assert.Equal(value, obj.KeysData451);
        }

        /// <summary>
        ///     Tests that keys data 452 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData452_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData452 = value;
            Assert.Equal(value, obj.KeysData452);
        }

        /// <summary>
        ///     Tests that keys data 453 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData453_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData453 = value;
            Assert.Equal(value, obj.KeysData453);
        }

        /// <summary>
        ///     Tests that keys data 454 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData454_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData454 = value;
            Assert.Equal(value, obj.KeysData454);
        }

        /// <summary>
        ///     Tests that keys data 455 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData455_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData455 = value;
            Assert.Equal(value, obj.KeysData455);
        }

        /// <summary>
        ///     Tests that keys data 456 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData456_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData456 = value;
            Assert.Equal(value, obj.KeysData456);
        }

        /// <summary>
        ///     Tests that keys data 457 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData457_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData457 = value;
            Assert.Equal(value, obj.KeysData457);
        }

        /// <summary>
        ///     Tests that keys data 458 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData458_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData458 = value;
            Assert.Equal(value, obj.KeysData458);
        }

        /// <summary>
        ///     Tests that keys data 459 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData459_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData459 = value;
            Assert.Equal(value, obj.KeysData459);
        }

        /// <summary>
        ///     Tests that keys data 460 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData460_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData460 = value;
            Assert.Equal(value, obj.KeysData460);
        }

        /// <summary>
        ///     Tests that keys data 461 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData461_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData461 = value;
            Assert.Equal(value, obj.KeysData461);
        }

        /// <summary>
        ///     Tests that keys data 462 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData462_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData462 = value;
            Assert.Equal(value, obj.KeysData462);
        }

        /// <summary>
        ///     Tests that keys data 463 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData463_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData463 = value;
            Assert.Equal(value, obj.KeysData463);
        }

        /// <summary>
        ///     Tests that keys data 464 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData464_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData464 = value;
            Assert.Equal(value, obj.KeysData464);
        }

        /// <summary>
        ///     Tests that keys data 465 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData465_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData465 = value;
            Assert.Equal(value, obj.KeysData465);
        }

        /// <summary>
        ///     Tests that keys data 466 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData466_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData466 = value;
            Assert.Equal(value, obj.KeysData466);
        }

        /// <summary>
        ///     Tests that keys data 467 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData467_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData467 = value;
            Assert.Equal(value, obj.KeysData467);
        }

        /// <summary>
        ///     Tests that keys data 468 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData468_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData468 = value;
            Assert.Equal(value, obj.KeysData468);
        }

        /// <summary>
        ///     Tests that keys data 469 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData469_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData469 = value;
            Assert.Equal(value, obj.KeysData469);
        }

        /// <summary>
        ///     Tests that keys data 470 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData470_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData470 = value;
            Assert.Equal(value, obj.KeysData470);
        }

        /// <summary>
        ///     Tests that keys data 471 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData471_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData471 = value;
            Assert.Equal(value, obj.KeysData471);
        }

        /// <summary>
        ///     Tests that keys data 472 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData472_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData472 = value;
            Assert.Equal(value, obj.KeysData472);
        }

        /// <summary>
        ///     Tests that keys data 473 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData473_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData473 = value;
            Assert.Equal(value, obj.KeysData473);
        }

        /// <summary>
        ///     Tests that keys data 474 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData474_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData474 = value;
            Assert.Equal(value, obj.KeysData474);
        }

        /// <summary>
        ///     Tests that keys data 475 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData475_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData475 = value;
            Assert.Equal(value, obj.KeysData475);
        }

        /// <summary>
        ///     Tests that keys data 476 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData476_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData476 = value;
            Assert.Equal(value, obj.KeysData476);
        }

        /// <summary>
        ///     Tests that keys data 477 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData477_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData477 = value;
            Assert.Equal(value, obj.KeysData477);
        }

        /// <summary>
        ///     Tests that keys data 478 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData478_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData478 = value;
            Assert.Equal(value, obj.KeysData478);
        }

        /// <summary>
        ///     Tests that keys data 479 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData479_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData479 = value;
            Assert.Equal(value, obj.KeysData479);
        }

        /// <summary>
        ///     Tests that keys data 480 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData480_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData480 = value;
            Assert.Equal(value, obj.KeysData480);
        }

        /// <summary>
        ///     Tests that keys data 481 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData481_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData481 = value;
            Assert.Equal(value, obj.KeysData481);
        }

        /// <summary>
        ///     Tests that keys data 482 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData482_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData482 = value;
            Assert.Equal(value, obj.KeysData482);
        }

        /// <summary>
        ///     Tests that keys data 483 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData483_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData483 = value;
            Assert.Equal(value, obj.KeysData483);
        }

        /// <summary>
        ///     Tests that keys data 484 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData484_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData484 = value;
            Assert.Equal(value, obj.KeysData484);
        }

        /// <summary>
        ///     Tests that keys data 485 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData485_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData485 = value;
            Assert.Equal(value, obj.KeysData485);
        }

        /// <summary>
        ///     Tests that keys data 486 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData486_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData486 = value;
            Assert.Equal(value, obj.KeysData486);
        }

        /// <summary>
        ///     Tests that keys data 487 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData487_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData487 = value;
            Assert.Equal(value, obj.KeysData487);
        }

        /// <summary>
        ///     Tests that keys data 488 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData488_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData488 = value;
            Assert.Equal(value, obj.KeysData488);
        }

        /// <summary>
        ///     Tests that keys data 489 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData489_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData489 = value;
            Assert.Equal(value, obj.KeysData489);
        }

        /// <summary>
        ///     Tests that keys data 490 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData490_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData490 = value;
            Assert.Equal(value, obj.KeysData490);
        }

        /// <summary>
        ///     Tests that keys data 491 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData491_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData491 = value;
            Assert.Equal(value, obj.KeysData491);
        }

        /// <summary>
        ///     Tests that keys data 492 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData492_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData492 = value;
            Assert.Equal(value, obj.KeysData492);
        }

        /// <summary>
        ///     Tests that keys data 493 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData493_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData493 = value;
            Assert.Equal(value, obj.KeysData493);
        }

        /// <summary>
        ///     Tests that keys data 494 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData494_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData494 = value;
            Assert.Equal(value, obj.KeysData494);
        }

        /// <summary>
        ///     Tests that keys data 495 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData495_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData495 = value;
            Assert.Equal(value, obj.KeysData495);
        }

        /// <summary>
        ///     Tests that keys data 496 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData496_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData496 = value;
            Assert.Equal(value, obj.KeysData496);
        }

        /// <summary>
        ///     Tests that keys data 497 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData497_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData497 = value;
            Assert.Equal(value, obj.KeysData497);
        }

        /// <summary>
        ///     Tests that keys data 498 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData498_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData498 = value;
            Assert.Equal(value, obj.KeysData498);
        }

        /// <summary>
        ///     Tests that keys data 499 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData499_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData499 = value;
            Assert.Equal(value, obj.KeysData499);
        }

        /// <summary>
        ///     Tests that keys data 500 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData500_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData500 = value;
            Assert.Equal(value, obj.KeysData500);
        }

        /// <summary>
        ///     Tests that keys data 501 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData501_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData501 = value;
            Assert.Equal(value, obj.KeysData501);
        }

        /// <summary>
        ///     Tests that keys data 502 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData502_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData502 = value;
            Assert.Equal(value, obj.KeysData502);
        }

        /// <summary>
        ///     Tests that keys data 503 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData503_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData503 = value;
            Assert.Equal(value, obj.KeysData503);
        }

        /// <summary>
        ///     Tests that keys data 504 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData504_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData504 = value;
            Assert.Equal(value, obj.KeysData504);
        }

        /// <summary>
        ///     Tests that keys data 505 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData505_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData505 = value;
            Assert.Equal(value, obj.KeysData505);
        }

        /// <summary>
        ///     Tests that keys data 506 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData506_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData506 = value;
            Assert.Equal(value, obj.KeysData506);
        }

        /// <summary>
        ///     Tests that keys data 507 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData507_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData507 = value;
            Assert.Equal(value, obj.KeysData507);
        }

        /// <summary>
        ///     Tests that keys data 508 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData508_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData508 = value;
            Assert.Equal(value, obj.KeysData508);
        }

        /// <summary>
        ///     Tests that keys data 509 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData509_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData509 = value;
            Assert.Equal(value, obj.KeysData509);
        }

        /// <summary>
        ///     Tests that keys data 510 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData510_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData510 = value;
            Assert.Equal(value, obj.KeysData510);
        }

        /// <summary>
        ///     Tests that keys data 511 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData511_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData511 = value;
            Assert.Equal(value, obj.KeysData511);
        }

        /// <summary>
        ///     Tests that keys data 512 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData512_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData512 = value;
            Assert.Equal(value, obj.KeysData512);
        }

        /// <summary>
        ///     Tests that keys data 513 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData513_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData513 = value;
            Assert.Equal(value, obj.KeysData513);
        }

        /// <summary>
        ///     Tests that keys data 514 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData514_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData514 = value;
            Assert.Equal(value, obj.KeysData514);
        }

        /// <summary>
        ///     Tests that keys data 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData1_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData1 = value;
            Assert.Equal(value, obj.KeysData1);
        }

        /// <summary>
        ///     Tests that keys data 2 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData2_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData2 = value;
            Assert.Equal(value, obj.KeysData2);
        }

        /// <summary>
        ///     Tests that keys data 3 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData3_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData3 = value;
            Assert.Equal(value, obj.KeysData3);
        }

        /// <summary>
        ///     Tests that keys data 4 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData4_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData4 = value;
            Assert.Equal(value, obj.KeysData4);
        }

        /// <summary>
        ///     Tests that keys data 5 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData5_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData5 = value;
            Assert.Equal(value, obj.KeysData5);
        }

        /// <summary>
        ///     Tests that keys data 6 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData6_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData6 = value;
            Assert.Equal(value, obj.KeysData6);
        }

        /// <summary>
        ///     Tests that keys data 7 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData7_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData7 = value;
            Assert.Equal(value, obj.KeysData7);
        }

        /// <summary>
        ///     Tests that keys data 8 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData8_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData8 = value;
            Assert.Equal(value, obj.KeysData8);
        }

        /// <summary>
        ///     Tests that keys data 9 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData9_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData9 = value;
            Assert.Equal(value, obj.KeysData9);
        }

        /// <summary>
        ///     Tests that keys data 10 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData10_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData10 = value;
            Assert.Equal(value, obj.KeysData10);
        }

        /// <summary>
        ///     Tests that keys data 11 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData11_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData11 = value;
            Assert.Equal(value, obj.KeysData11);
        }

        /// <summary>
        ///     Tests that keys data 12 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData12_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData12 = value;
            Assert.Equal(value, obj.KeysData12);
        }

        /// <summary>
        ///     Tests that keys data 13 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData13_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData13 = value;
            Assert.Equal(value, obj.KeysData13);
        }

        /// <summary>
        ///     Tests that keys data 14 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData14_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData14 = value;
            Assert.Equal(value, obj.KeysData14);
        }

        /// <summary>
        ///     Tests that keys data 15 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData15_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData15 = value;
            Assert.Equal(value, obj.KeysData15);
        }

        /// <summary>
        ///     Tests that keys data 16 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData16_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData16 = value;
            Assert.Equal(value, obj.KeysData16);
        }

        /// <summary>
        ///     Tests that keys data 17 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData17_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData17 = value;
            Assert.Equal(value, obj.KeysData17);
        }

        /// <summary>
        ///     Tests that keys data 18 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData18_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData18 = value;
            Assert.Equal(value, obj.KeysData18);
        }

        /// <summary>
        ///     Tests that keys data 19 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData19_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData19 = value;
            Assert.Equal(value, obj.KeysData19);
        }

        /// <summary>
        ///     Tests that keys data 20 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData20_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData20 = value;
            Assert.Equal(value, obj.KeysData20);
        }

        /// <summary>
        ///     Tests that keys data 21 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData21_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData21 = value;
            Assert.Equal(value, obj.KeysData21);
        }

        /// <summary>
        ///     Tests that keys data 22 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData22_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData22 = value;
            Assert.Equal(value, obj.KeysData22);
        }

        /// <summary>
        ///     Tests that keys data 23 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData23_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData23 = value;
            Assert.Equal(value, obj.KeysData23);
        }

        /// <summary>
        ///     Tests that keys data 24 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData24_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData24 = value;
            Assert.Equal(value, obj.KeysData24);
        }

        /// <summary>
        ///     Tests that keys data 25 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData25_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData25 = value;
            Assert.Equal(value, obj.KeysData25);
        }

        /// <summary>
        ///     Tests that keys data 26 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData26_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData26 = value;
            Assert.Equal(value, obj.KeysData26);
        }

        /// <summary>
        ///     Tests that keys data 27 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData27_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData27 = value;
            Assert.Equal(value, obj.KeysData27);
        }

        /// <summary>
        ///     Tests that keys data 28 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData28_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData28 = value;
            Assert.Equal(value, obj.KeysData28);
        }

        /// <summary>
        ///     Tests that keys data 29 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData29_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData29 = value;
            Assert.Equal(value, obj.KeysData29);
        }

        /// <summary>
        ///     Tests that keys data 30 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData30_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData30 = value;
            Assert.Equal(value, obj.KeysData30);
        }

        /// <summary>
        ///     Tests that keys data 31 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData31_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData31 = value;
            Assert.Equal(value, obj.KeysData31);
        }

        /// <summary>
        ///     Tests that keys data 32 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData32_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData32 = value;
            Assert.Equal(value, obj.KeysData32);
        }

        /// <summary>
        ///     Tests that keys data 33 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData33_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData33 = value;
            Assert.Equal(value, obj.KeysData33);
        }

        /// <summary>
        ///     Tests that keys data 34 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData34_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData34 = value;
            Assert.Equal(value, obj.KeysData34);
        }

        /// <summary>
        ///     Tests that keys data 35 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData35_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData35 = value;
            Assert.Equal(value, obj.KeysData35);
        }

        /// <summary>
        ///     Tests that keys data 36 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData36_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData36 = value;
            Assert.Equal(value, obj.KeysData36);
        }

        /// <summary>
        ///     Tests that keys data 37 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData37_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData37 = value;
            Assert.Equal(value, obj.KeysData37);
        }

        /// <summary>
        ///     Tests that keys data 38 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData38_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData38 = value;
            Assert.Equal(value, obj.KeysData38);
        }

        /// <summary>
        ///     Tests that keys data 39 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData39_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData39 = value;
            Assert.Equal(value, obj.KeysData39);
        }

        /// <summary>
        ///     Tests that keys data 40 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData40_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData40 = value;
            Assert.Equal(value, obj.KeysData40);
        }

        /// <summary>
        ///     Tests that keys data 41 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData41_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData41 = value;
            Assert.Equal(value, obj.KeysData41);
        }

        /// <summary>
        ///     Tests that keys data 42 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData42_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData42 = value;
            Assert.Equal(value, obj.KeysData42);
        }

        /// <summary>
        ///     Tests that keys data 43 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData43_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData43 = value;
            Assert.Equal(value, obj.KeysData43);
        }

        /// <summary>
        ///     Tests that keys data 44 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData44_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData44 = value;
            Assert.Equal(value, obj.KeysData44);
        }

        /// <summary>
        ///     Tests that keys data 45 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData45_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData45 = value;
            Assert.Equal(value, obj.KeysData45);
        }

        /// <summary>
        ///     Tests that keys data 46 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData46_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData46 = value;
            Assert.Equal(value, obj.KeysData46);
        }

        /// <summary>
        ///     Tests that keys data 47 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData47_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData47 = value;
            Assert.Equal(value, obj.KeysData47);
        }

        /// <summary>
        ///     Tests that keys data 48 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData48_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData48 = value;
            Assert.Equal(value, obj.KeysData48);
        }

        /// <summary>
        ///     Tests that keys data 49 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData49_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData49 = value;
            Assert.Equal(value, obj.KeysData49);
        }

        /// <summary>
        ///     Tests that keys data 50 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData50_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData50 = value;
            Assert.Equal(value, obj.KeysData50);
        }

        /// <summary>
        ///     Tests that keys data 51 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData51_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData51 = value;
            Assert.Equal(value, obj.KeysData51);
        }

        /// <summary>
        ///     Tests that keys data 52 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData52_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData52 = value;
            Assert.Equal(value, obj.KeysData52);
        }

        /// <summary>
        ///     Tests that keys data 53 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData53_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData53 = value;
            Assert.Equal(value, obj.KeysData53);
        }

        /// <summary>
        ///     Tests that keys data 54 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData54_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData54 = value;
            Assert.Equal(value, obj.KeysData54);
        }

        /// <summary>
        ///     Tests that keys data 55 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData55_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData55 = value;
            Assert.Equal(value, obj.KeysData55);
        }

        /// <summary>
        ///     Tests that keys data 56 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData56_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData56 = value;
            Assert.Equal(value, obj.KeysData56);
        }

        /// <summary>
        ///     Tests that keys data 57 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData57_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData57 = value;
            Assert.Equal(value, obj.KeysData57);
        }

        /// <summary>
        ///     Tests that keys data 58 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData58_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData58 = value;
            Assert.Equal(value, obj.KeysData58);
        }

        /// <summary>
        ///     Tests that keys data 59 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData59_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData59 = value;
            Assert.Equal(value, obj.KeysData59);
        }

        /// <summary>
        ///     Tests that keys data 60 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData60_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData60 = value;
            Assert.Equal(value, obj.KeysData60);
        }

        /// <summary>
        ///     Tests that keys data 61 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData61_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData61 = value;
            Assert.Equal(value, obj.KeysData61);
        }

        /// <summary>
        ///     Tests that keys data 62 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData62_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData62 = value;
            Assert.Equal(value, obj.KeysData62);
        }

        /// <summary>
        ///     Tests that keys data 63 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData63_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData63 = value;
            Assert.Equal(value, obj.KeysData63);
        }

        /// <summary>
        ///     Tests that keys data 64 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData64_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData64 = value;
            Assert.Equal(value, obj.KeysData64);
        }

        /// <summary>
        ///     Tests that keys data 65 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData65_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData65 = value;
            Assert.Equal(value, obj.KeysData65);
        }

        /// <summary>
        ///     Tests that keys data 66 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData66_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData66 = value;
            Assert.Equal(value, obj.KeysData66);
        }

        /// <summary>
        ///     Tests that keys data 67 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData67_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData67 = value;
            Assert.Equal(value, obj.KeysData67);
        }

        /// <summary>
        ///     Tests that keys data 68 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData68_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData68 = value;
            Assert.Equal(value, obj.KeysData68);
        }

        /// <summary>
        ///     Tests that keys data 603 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData603_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData603 = value;
            Assert.Equal(value, obj.KeysData603);
        }

        /// <summary>
        ///     Tests that keys data 604 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData604_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData604 = value;
            Assert.Equal(value, obj.KeysData604);
        }

        /// <summary>
        ///     Tests that keys data 605 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData605_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData605 = value;
            Assert.Equal(value, obj.KeysData605);
        }

        /// <summary>
        ///     Tests that keys data 606 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData606_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData606 = value;
            Assert.Equal(value, obj.KeysData606);
        }

        /// <summary>
        ///     Tests that keys data 607 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData607_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData607 = value;
            Assert.Equal(value, obj.KeysData607);
        }

        /// <summary>
        ///     Tests that keys data 608 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData608_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData608 = value;
            Assert.Equal(value, obj.KeysData608);
        }

        /// <summary>
        ///     Tests that keys data 609 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData609_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData609 = value;
            Assert.Equal(value, obj.KeysData609);
        }

        /// <summary>
        ///     Tests that keys data 610 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData610_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData610 = value;
            Assert.Equal(value, obj.KeysData610);
        }

        /// <summary>
        ///     Tests that keys data 611 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData611_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData611 = value;
            Assert.Equal(value, obj.KeysData611);
        }

        /// <summary>
        ///     Tests that keys data 612 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData612_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData612 = value;
            Assert.Equal(value, obj.KeysData612);
        }

        /// <summary>
        ///     Tests that keys data 613 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData613_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData613 = value;
            Assert.Equal(value, obj.KeysData613);
        }

        /// <summary>
        ///     Tests that keys data 614 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData614_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData614 = value;
            Assert.Equal(value, obj.KeysData614);
        }

        /// <summary>
        ///     Tests that keys data 615 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData615_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData615 = value;
            Assert.Equal(value, obj.KeysData615);
        }

        /// <summary>
        ///     Tests that keys data 616 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData616_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData616 = value;
            Assert.Equal(value, obj.KeysData616);
        }

        /// <summary>
        ///     Tests that keys data 617 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData617_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData617 = value;
            Assert.Equal(value, obj.KeysData617);
        }

        /// <summary>
        ///     Tests that keys data 618 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData618_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData618 = value;
            Assert.Equal(value, obj.KeysData618);
        }

        /// <summary>
        ///     Tests that keys data 619 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData619_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData619 = value;
            Assert.Equal(value, obj.KeysData619);
        }

        /// <summary>
        ///     Tests that keys data 620 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData620_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData620 = value;
            Assert.Equal(value, obj.KeysData620);
        }

        /// <summary>
        ///     Tests that keys data 621 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData621_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData621 = value;
            Assert.Equal(value, obj.KeysData621);
        }

        /// <summary>
        ///     Tests that keys data 622 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData622_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData622 = value;
            Assert.Equal(value, obj.KeysData622);
        }

        /// <summary>
        ///     Tests that keys data 623 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData623_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData623 = value;
            Assert.Equal(value, obj.KeysData623);
        }

        /// <summary>
        ///     Tests that keys data 624 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData624_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData624 = value;
            Assert.Equal(value, obj.KeysData624);
        }

        /// <summary>
        ///     Tests that keys data 625 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData625_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData625 = value;
            Assert.Equal(value, obj.KeysData625);
        }

        /// <summary>
        ///     Tests that keys data 626 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData626_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData626 = value;
            Assert.Equal(value, obj.KeysData626);
        }

        /// <summary>
        ///     Tests that keys data 627 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData627_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData627 = value;
            Assert.Equal(value, obj.KeysData627);
        }

        /// <summary>
        ///     Tests that keys data 628 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData628_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData628 = value;
            Assert.Equal(value, obj.KeysData628);
        }

        /// <summary>
        ///     Tests that keys data 629 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData629_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData629 = value;
            Assert.Equal(value, obj.KeysData629);
        }

        /// <summary>
        ///     Tests that keys data 630 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData630_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData630 = value;
            Assert.Equal(value, obj.KeysData630);
        }

        /// <summary>
        ///     Tests that keys data 631 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData631_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData631 = value;
            Assert.Equal(value, obj.KeysData631);
        }

        /// <summary>
        ///     Tests that keys data 632 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData632_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData632 = value;
            Assert.Equal(value, obj.KeysData632);
        }

        /// <summary>
        ///     Tests that keys data 633 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData633_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData633 = value;
            Assert.Equal(value, obj.KeysData633);
        }

        /// <summary>
        ///     Tests that keys data 634 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData634_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData634 = value;
            Assert.Equal(value, obj.KeysData634);
        }

        /// <summary>
        ///     Tests that keys data 635 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData635_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData635 = value;
            Assert.Equal(value, obj.KeysData635);
        }

        /// <summary>
        ///     Tests that keys data 636 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData636_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData636 = value;
            Assert.Equal(value, obj.KeysData636);
        }

        /// <summary>
        ///     Tests that keys data 637 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData637_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData637 = value;
            Assert.Equal(value, obj.KeysData637);
        }

        /// <summary>
        ///     Tests that keys data 638 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData638_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData638 = value;
            Assert.Equal(value, obj.KeysData638);
        }

        /// <summary>
        ///     Tests that keys data 639 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData639_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData639 = value;
            Assert.Equal(value, obj.KeysData639);
        }

        /// <summary>
        ///     Tests that keys data 640 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData640_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData640 = value;
            Assert.Equal(value, obj.KeysData640);
        }

        /// <summary>
        ///     Tests that keys data 641 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData641_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData641 = value;
            Assert.Equal(value, obj.KeysData641);
        }

        /// <summary>
        ///     Tests that keys data 642 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData642_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData642 = value;
            Assert.Equal(value, obj.KeysData642);
        }

        /// <summary>
        ///     Tests that keys data 643 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData643_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData643 = value;
            Assert.Equal(value, obj.KeysData643);
        }

        /// <summary>
        ///     Tests that keys data 644 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData644_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData644 = value;
            Assert.Equal(value, obj.KeysData644);
        }

        /// <summary>
        ///     Tests that keys data 645 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData645_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData645 = value;
            Assert.Equal(value, obj.KeysData645);
        }

        /// <summary>
        ///     Tests that keys data 646 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData646_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData646 = value;
            Assert.Equal(value, obj.KeysData646);
        }

        /// <summary>
        ///     Tests that keys data 647 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData647_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData647 = value;
            Assert.Equal(value, obj.KeysData647);
        }

        /// <summary>
        ///     Tests that keys data 648 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData648_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData648 = value;
            Assert.Equal(value, obj.KeysData648);
        }

        /// <summary>
        ///     Tests that keys data 649 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData649_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData649 = value;
            Assert.Equal(value, obj.KeysData649);
        }

        /// <summary>
        ///     Tests that keys data 650 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData650_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData650 = value;
            Assert.Equal(value, obj.KeysData650);
        }

        /// <summary>
        ///     Tests that keys data 651 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData651_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData651 = value;
            Assert.Equal(value, obj.KeysData651);
        }

        /// <summary>
        ///     Tests that keys data 521 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData521_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData521 = value;
            Assert.Equal(value, obj.KeysData521);
        }

        /// <summary>
        ///     Tests that keys data 522 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData522_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData522 = value;
            Assert.Equal(value, obj.KeysData522);
        }

        /// <summary>
        ///     Tests that keys data 523 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData523_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData523 = value;
            Assert.Equal(value, obj.KeysData523);
        }

        /// <summary>
        ///     Tests that keys data 524 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData524_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData524 = value;
            Assert.Equal(value, obj.KeysData524);
        }

        /// <summary>
        ///     Tests that keys data 525 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData525_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData525 = value;
            Assert.Equal(value, obj.KeysData525);
        }

        /// <summary>
        ///     Tests that keys data 526 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData526_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData526 = value;
            Assert.Equal(value, obj.KeysData526);
        }

        /// <summary>
        ///     Tests that keys data 527 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData527_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData527 = value;
            Assert.Equal(value, obj.KeysData527);
        }

        /// <summary>
        ///     Tests that keys data 528 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData528_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData528 = value;
            Assert.Equal(value, obj.KeysData528);
        }

        /// <summary>
        ///     Tests that keys data 529 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData529_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData529 = value;
            Assert.Equal(value, obj.KeysData529);
        }

        /// <summary>
        ///     Tests that keys data 530 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData530_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData530 = value;
            Assert.Equal(value, obj.KeysData530);
        }

        /// <summary>
        ///     Tests that keys data 531 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData531_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData531 = value;
            Assert.Equal(value, obj.KeysData531);
        }

        /// <summary>
        ///     Tests that keys data 532 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData532_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData532 = value;
            Assert.Equal(value, obj.KeysData532);
        }

        /// <summary>
        ///     Tests that keys data 533 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData533_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData533 = value;
            Assert.Equal(value, obj.KeysData533);
        }

        /// <summary>
        ///     Tests that keys data 534 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData534_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData534 = value;
            Assert.Equal(value, obj.KeysData534);
        }

        /// <summary>
        ///     Tests that keys data 535 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData535_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData535 = value;
            Assert.Equal(value, obj.KeysData535);
        }

        /// <summary>
        ///     Tests that keys data 536 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData536_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData536 = value;
            Assert.Equal(value, obj.KeysData536);
        }

        /// <summary>
        ///     Tests that keys data 537 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData537_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData537 = value;
            Assert.Equal(value, obj.KeysData537);
        }

        /// <summary>
        ///     Tests that keys data 538 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData538_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData538 = value;
            Assert.Equal(value, obj.KeysData538);
        }

        /// <summary>
        ///     Tests that keys data 539 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData539_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData539 = value;
            Assert.Equal(value, obj.KeysData539);
        }

        /// <summary>
        ///     Tests that keys data 540 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData540_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData540 = value;
            Assert.Equal(value, obj.KeysData540);
        }

        /// <summary>
        ///     Tests that keys data 541 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData541_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData541 = value;
            Assert.Equal(value, obj.KeysData541);
        }

        /// <summary>
        ///     Tests that keys data 542 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData542_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData542 = value;
            Assert.Equal(value, obj.KeysData542);
        }

        /// <summary>
        ///     Tests that keys data 543 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData543_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData543 = value;
            Assert.Equal(value, obj.KeysData543);
        }

        /// <summary>
        ///     Tests that keys data 544 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData544_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData544 = value;
            Assert.Equal(value, obj.KeysData544);
        }

        /// <summary>
        ///     Tests that keys data 545 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData545_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData545 = value;
            Assert.Equal(value, obj.KeysData545);
        }

        /// <summary>
        ///     Tests that keys data 546 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData546_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData546 = value;
            Assert.Equal(value, obj.KeysData546);
        }

        /// <summary>
        ///     Tests that keys data 547 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData547_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData547 = value;
            Assert.Equal(value, obj.KeysData547);
        }

        /// <summary>
        ///     Tests that keys data 548 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData548_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData548 = value;
            Assert.Equal(value, obj.KeysData548);
        }

        /// <summary>
        ///     Tests that keys data 549 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData549_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData549 = value;
            Assert.Equal(value, obj.KeysData549);
        }

        /// <summary>
        ///     Tests that keys data 550 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData550_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData550 = value;
            Assert.Equal(value, obj.KeysData550);
        }

        /// <summary>
        ///     Tests that keys data 551 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData551_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData551 = value;
            Assert.Equal(value, obj.KeysData551);
        }

        /// <summary>
        ///     Tests that keys data 552 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData552_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData552 = value;
            Assert.Equal(value, obj.KeysData552);
        }

        /// <summary>
        ///     Tests that keys data 553 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData553_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData553 = value;
            Assert.Equal(value, obj.KeysData553);
        }

        /// <summary>
        ///     Tests that keys data 554 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData554_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData554 = value;
            Assert.Equal(value, obj.KeysData554);
        }

        /// <summary>
        ///     Tests that keys data 555 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData555_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData555 = value;
            Assert.Equal(value, obj.KeysData555);
        }

        /// <summary>
        ///     Tests that keys data 556 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData556_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData556 = value;
            Assert.Equal(value, obj.KeysData556);
        }

        /// <summary>
        ///     Tests that keys data 557 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData557_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData557 = value;
            Assert.Equal(value, obj.KeysData557);
        }

        /// <summary>
        ///     Tests that keys data 558 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData558_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData558 = value;
            Assert.Equal(value, obj.KeysData558);
        }

        /// <summary>
        ///     Tests that keys data 559 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData559_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData559 = value;
            Assert.Equal(value, obj.KeysData559);
        }

        /// <summary>
        ///     Tests that keys data 560 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData560_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData560 = value;
            Assert.Equal(value, obj.KeysData560);
        }

        /// <summary>
        ///     Tests that keys data 561 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData561_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData561 = value;
            Assert.Equal(value, obj.KeysData561);
        }

        /// <summary>
        ///     Tests that keys data 562 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData562_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData562 = value;
            Assert.Equal(value, obj.KeysData562);
        }

        /// <summary>
        ///     Tests that keys data 563 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData563_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData563 = value;
            Assert.Equal(value, obj.KeysData563);
        }

        /// <summary>
        ///     Tests that keys data 564 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData564_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData564 = value;
            Assert.Equal(value, obj.KeysData564);
        }

        /// <summary>
        ///     Tests that keys data 565 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData565_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData565 = value;
            Assert.Equal(value, obj.KeysData565);
        }

        /// <summary>
        ///     Tests that keys data 566 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData566_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData566 = value;
            Assert.Equal(value, obj.KeysData566);
        }

        /// <summary>
        ///     Tests that keys data 567 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData567_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData567 = value;
            Assert.Equal(value, obj.KeysData567);
        }

        /// <summary>
        ///     Tests that keys data 568 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData568_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData568 = value;
            Assert.Equal(value, obj.KeysData568);
        }

        /// <summary>
        ///     Tests that keys data 569 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData569_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData569 = value;
            Assert.Equal(value, obj.KeysData569);
        }

        /// <summary>
        ///     Tests that keys data 570 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData570_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData570 = value;
            Assert.Equal(value, obj.KeysData570);
        }

        /// <summary>
        ///     Tests that keys data 571 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData571_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData571 = value;
            Assert.Equal(value, obj.KeysData571);
        }

        /// <summary>
        ///     Tests that keys data 572 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData572_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData572 = value;
            Assert.Equal(value, obj.KeysData572);
        }

        /// <summary>
        ///     Tests that keys data 573 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData573_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData573 = value;
            Assert.Equal(value, obj.KeysData573);
        }

        /// <summary>
        ///     Tests that keys data 574 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData574_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData574 = value;
            Assert.Equal(value, obj.KeysData574);
        }

        /// <summary>
        ///     Tests that keys data 575 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData575_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData575 = value;
            Assert.Equal(value, obj.KeysData575);
        }

        /// <summary>
        ///     Tests that keys data 576 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData576_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData576 = value;
            Assert.Equal(value, obj.KeysData576);
        }

        /// <summary>
        ///     Tests that keys data 577 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData577_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData577 = value;
            Assert.Equal(value, obj.KeysData577);
        }

        /// <summary>
        ///     Tests that keys data 578 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData578_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData578 = value;
            Assert.Equal(value, obj.KeysData578);
        }

        /// <summary>
        ///     Tests that keys data 579 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData579_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData579 = value;
            Assert.Equal(value, obj.KeysData579);
        }

        /// <summary>
        ///     Tests that keys data 580 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData580_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData580 = value;
            Assert.Equal(value, obj.KeysData580);
        }

        /// <summary>
        ///     Tests that keys data 581 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData581_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData581 = value;
            Assert.Equal(value, obj.KeysData581);
        }

        /// <summary>
        ///     Tests that keys data 582 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData582_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData582 = value;
            Assert.Equal(value, obj.KeysData582);
        }

        /// <summary>
        ///     Tests that keys data 583 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData583_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData583 = value;
            Assert.Equal(value, obj.KeysData583);
        }

        /// <summary>
        ///     Tests that keys data 584 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData584_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData584 = value;
            Assert.Equal(value, obj.KeysData584);
        }

        /// <summary>
        ///     Tests that keys data 585 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData585_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData585 = value;
            Assert.Equal(value, obj.KeysData585);
        }

        /// <summary>
        ///     Tests that keys data 586 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData586_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData586 = value;
            Assert.Equal(value, obj.KeysData586);
        }

        /// <summary>
        ///     Tests that keys data 587 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData587_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData587 = value;
            Assert.Equal(value, obj.KeysData587);
        }

        /// <summary>
        ///     Tests that keys data 588 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData588_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData588 = value;
            Assert.Equal(value, obj.KeysData588);
        }

        /// <summary>
        ///     Tests that keys data 589 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData589_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData589 = value;
            Assert.Equal(value, obj.KeysData589);
        }

        /// <summary>
        ///     Tests that keys data 590 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData590_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData590 = value;
            Assert.Equal(value, obj.KeysData590);
        }

        /// <summary>
        ///     Tests that keys data 591 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData591_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData591 = value;
            Assert.Equal(value, obj.KeysData591);
        }

        /// <summary>
        ///     Tests that keys data 592 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData592_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData592 = value;
            Assert.Equal(value, obj.KeysData592);
        }

        /// <summary>
        ///     Tests that keys data 593 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData593_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData593 = value;
            Assert.Equal(value, obj.KeysData593);
        }

        /// <summary>
        ///     Tests that keys data 594 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData594_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData594 = value;
            Assert.Equal(value, obj.KeysData594);
        }

        /// <summary>
        ///     Tests that keys data 595 set and get returns correct value
        /// </summary>
        [Fact]
        public void V3_KeysData595_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData595 = value;
            Assert.Equal(value, obj.KeysData595);
        }

        /// <summary>
        ///     Tests that keys data 596 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData596_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData596 = value;
            Assert.Equal(value, obj.KeysData596);
        }

        /// <summary>
        ///     Tests that keys data 597 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData597_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData597 = value;
            Assert.Equal(value, obj.KeysData597);
        }

        /// <summary>
        ///     Tests that keys data 598 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData598_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData598 = value;
            Assert.Equal(value, obj.KeysData598);
        }

        /// <summary>
        ///     Tests that keys data 599 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData599_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData599 = value;
            Assert.Equal(value, obj.KeysData599);
        }

        /// <summary>
        ///     Tests that keys data 600 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData600_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData600 = value;
            Assert.Equal(value, obj.KeysData600);
        }

        /// <summary>
        ///     Tests that keys data 601 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData601_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData601 = value;
            Assert.Equal(value, obj.KeysData601);
        }

        /// <summary>
        ///     Tests that keys data 602 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData602_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData602 = value;
            Assert.Equal(value, obj.KeysData602);
        }

        /// <summary>
        ///     Tests that v 2 keys data 589 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData589_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData589 = value;
            Assert.Equal(value, obj.KeysData589);
        }

        /// <summary>
        ///     Tests that v 2 keys data 590 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData590_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData590 = value;
            Assert.Equal(value, obj.KeysData590);
        }

        /// <summary>
        ///     Tests that v 2 keys data 591 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData591_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData591 = value;
            Assert.Equal(value, obj.KeysData591);
        }

        /// <summary>
        ///     Tests that v 2 keys data 592 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData592_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData592 = value;
            Assert.Equal(value, obj.KeysData592);
        }

        /// <summary>
        ///     Tests that v 2 keys data 593 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData593_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData593 = value;
            Assert.Equal(value, obj.KeysData593);
        }

        /// <summary>
        ///     Tests that v 3 keys data 594 set and get returns correct value
        /// </summary>
        [Fact]
        public void V3_KeysData594_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData594 = value;
            Assert.Equal(value, obj.KeysData594);
        }

        /// <summary>
        ///     Tests that v 3 keys data 595 set and get returns correct value
        /// </summary>
        [Fact]
        public void V4_KeysData595_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData595 = value;
            Assert.Equal(value, obj.KeysData595);
        }

        /// <summary>
        ///     Tests that v 3 keys data 596 set and get returns correct value
        /// </summary>
        [Fact]
        public void V3_KeysData596_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData596 = value;
            Assert.Equal(value, obj.KeysData596);
        }

        /// <summary>
        ///     Tests that v 3 keys data 597 set and get returns correct value
        /// </summary>
        [Fact]
        public void V3_KeysData597_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData597 = value;
            Assert.Equal(value, obj.KeysData597);
        }

        /// <summary>
        ///     Tests that v 3 keys data 598 set and get returns correct value
        /// </summary>
        [Fact]
        public void V3_KeysData598_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData598 = value;
            Assert.Equal(value, obj.KeysData598);
        }

        /// <summary>
        ///     Tests that v 2 keys data 599 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData599_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData599 = value;
            Assert.Equal(value, obj.KeysData599);
        }

        /// <summary>
        ///     Tests that v 2 keys data 600 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData600_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData600 = value;
            Assert.Equal(value, obj.KeysData600);
        }

        /// <summary>
        ///     Tests that v 2 keys data 601 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData601_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData601 = value;
            Assert.Equal(value, obj.KeysData601);
        }

        /// <summary>
        ///     Tests that v 2 keys data 602 set and get returns correct value
        /// </summary>
        [Fact]
        public void V2_KeysData602_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData602 = value;
            Assert.Equal(value, obj.KeysData602);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos1_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseClickedPos1 = value;
            Assert.Equal(value, obj.MouseClickedPos1);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 2 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos2_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseClickedPos2 = value;
            Assert.Equal(value, obj.MouseClickedPos2);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 3 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos3_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseClickedPos3 = value;
            Assert.Equal(value, obj.MouseClickedPos3);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 4 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos4_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseClickedPos4 = value;
            Assert.Equal(value, obj.MouseClickedPos4);
        }

        /// <summary>
        ///     Tests that mouse clicked time set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedTime_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            double[] value = new double[5];
            obj.MouseClickedTime = value;
            Assert.Equal(value, obj.MouseClickedTime);
        }

        /// <summary>
        ///     Tests that mouse clicked set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClicked_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte[] value = new byte[5];
            obj.MouseClicked = value;
            Assert.Equal(value, obj.MouseClicked);
        }

        /// <summary>
        ///     Tests that mouse double clicked set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDoubleClicked_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte[] value = new byte[5];
            obj.MouseDoubleClicked = value;
            Assert.Equal(value, obj.MouseDoubleClicked);
        }

        /// <summary>
        ///     Tests that mouse clicked count set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedCount_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ushort[] value = new ushort[5];
            obj.MouseClickedCount = value;
            Assert.Equal(value, obj.MouseClickedCount);
        }

        /// <summary>
        ///     Tests that mouse clicked last count set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedLastCount_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ushort[] value = new ushort[5];
            obj.MouseClickedLastCount = value;
            Assert.Equal(value, obj.MouseClickedLastCount);
        }

        /// <summary>
        ///     Tests that mouse released set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseReleased_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte[] value = new byte[5];
            obj.MouseReleased = value;
            Assert.Equal(value, obj.MouseReleased);
        }

        /// <summary>
        ///     Tests that mouse down owned set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDownOwned_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte[] value = new byte[5];
            obj.MouseDownOwned = value;
            Assert.Equal(value, obj.MouseDownOwned);
        }

        /// <summary>
        ///     Tests that mouse down owned unless popup close set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDownOwnedUnlessPopupClose_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte[] value = new byte[5];
            obj.MouseDownOwnedUnlessPopupClose = value;
            Assert.Equal(value, obj.MouseDownOwnedUnlessPopupClose);
        }

        /// <summary>
        ///     Tests that mouse down duration set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDownDuration_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float[] value = new float[5];
            obj.MouseDownDuration = value;
            Assert.Equal(value, obj.MouseDownDuration);
        }

        /// <summary>
        ///     Tests that mouse down duration prev set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDownDurationPrev_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float[] value = new float[5];
            obj.MouseDownDurationPrev = value;
            Assert.Equal(value, obj.MouseDownDurationPrev);
        }

        /// <summary>
        ///     Tests that v 4 mouse down duration prev set and get returns correct value
        /// </summary>
        [Fact]
        public void V4_MouseDownDurationPrev_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float[] value = new float[5];
            obj.MouseDownDurationPrev = value;
            Assert.Equal(value, obj.MouseDownDurationPrev);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 0 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs0_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseDragMaxDistanceAbs0 = value;
            Assert.Equal(value, obj.MouseDragMaxDistanceAbs0);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs1_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseDragMaxDistanceAbs1 = value;
            Assert.Equal(value, obj.MouseDragMaxDistanceAbs1);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 2 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs2_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseDragMaxDistanceAbs2 = value;
            Assert.Equal(value, obj.MouseDragMaxDistanceAbs2);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 3 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs3_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseDragMaxDistanceAbs3 = value;
            Assert.Equal(value, obj.MouseDragMaxDistanceAbs3);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 4 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs4_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.MouseDragMaxDistanceAbs4 = value;
            Assert.Equal(value, obj.MouseDragMaxDistanceAbs4);
        }

        /// <summary>
        ///     Tests that mouse drag max distance sqr set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceSqr_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float[] value = new float[5];
            obj.MouseDragMaxDistanceSqr = value;
            Assert.Equal(value, obj.MouseDragMaxDistanceSqr);
        }

        /// <summary>
        ///     Tests that keys data 400 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData400_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData400 = value;
            Assert.Equal(value, obj.KeysData400);
        }

        /// <summary>
        ///     Tests that keys data 401 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData401_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData401 = value;
            Assert.Equal(value, obj.KeysData401);
        }

        /// <summary>
        ///     Tests that keys data 402 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData402_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData402 = value;
            Assert.Equal(value, obj.KeysData402);
        }

        /// <summary>
        ///     Tests that keys data 403 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData403_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData403 = value;
            Assert.Equal(value, obj.KeysData403);
        }

        /// <summary>
        ///     Tests that keys data 404 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData404_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData404 = value;
            Assert.Equal(value, obj.KeysData404);
        }

        /// <summary>
        ///     Tests that keys data 405 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData405_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData405 = value;
            Assert.Equal(value, obj.KeysData405);
        }

        /// <summary>
        ///     Tests that keys data 406 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData406_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData406 = value;
            Assert.Equal(value, obj.KeysData406);
        }

        /// <summary>
        ///     Tests that keys data 407 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData407_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData407 = value;
            Assert.Equal(value, obj.KeysData407);
        }

        /// <summary>
        ///     Tests that keys data 408 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData408_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData408 = value;
            Assert.Equal(value, obj.KeysData408);
        }

        /// <summary>
        ///     Tests that keys data 409 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData409_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData409 = value;
            Assert.Equal(value, obj.KeysData409);
        }

        /// <summary>
        ///     Tests that keys data 410 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData410_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData410 = value;
            Assert.Equal(value, obj.KeysData410);
        }

        /// <summary>
        ///     Tests that keys data 411 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData411_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData411 = value;
            Assert.Equal(value, obj.KeysData411);
        }

        /// <summary>
        ///     Tests that keys data 412 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData412_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData412 = value;
            Assert.Equal(value, obj.KeysData412);
        }

        /// <summary>
        ///     Tests that keys data 413 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData413_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData413 = value;
            Assert.Equal(value, obj.KeysData413);
        }

        /// <summary>
        ///     Tests that keys data 414 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData414_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData414 = value;
            Assert.Equal(value, obj.KeysData414);
        }

        /// <summary>
        ///     Tests that keys data 415 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData415_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData415 = value;
            Assert.Equal(value, obj.KeysData415);
        }

        /// <summary>
        ///     Tests that keys data 416 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData416_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData416 = value;
            Assert.Equal(value, obj.KeysData416);
        }

        /// <summary>
        ///     Tests that keys data 417 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData417_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData417 = value;
            Assert.Equal(value, obj.KeysData417);
        }

        /// <summary>
        ///     Tests that keys data 418 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData418_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData418 = value;
            Assert.Equal(value, obj.KeysData418);
        }

        /// <summary>
        ///     Tests that keys data 419 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData419_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData419 = value;
            Assert.Equal(value, obj.KeysData419);
        }

        /// <summary>
        ///     Tests that keys data 515 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData515_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData515 = value;
            Assert.Equal(value, obj.KeysData515);
        }

        /// <summary>
        ///     Tests that keys data 516 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData516_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData516 = value;
            Assert.Equal(value, obj.KeysData516);
        }

        /// <summary>
        ///     Tests that keys data 517 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData517_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData517 = value;
            Assert.Equal(value, obj.KeysData517);
        }

        /// <summary>
        ///     Tests that keys data 518 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData518_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData518 = value;
            Assert.Equal(value, obj.KeysData518);
        }

        /// <summary>
        ///     Tests that keys data 519 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData519_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData519 = value;
            Assert.Equal(value, obj.KeysData519);
        }

        /// <summary>
        ///     Tests that keys data 520 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData520_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData520 = value;
            Assert.Equal(value, obj.KeysData520);
        }

        /// <summary>
        ///     Tests that keys data 420 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData420_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData420 = value;
            Assert.Equal(value, obj.KeysData420);
        }

        /// <summary>
        ///     Tests that keys data 421 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData421_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData421 = value;
            Assert.Equal(value, obj.KeysData421);
        }

        /// <summary>
        ///     Tests that keys data 422 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData422_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData422 = value;
            Assert.Equal(value, obj.KeysData422);
        }

        /// <summary>
        ///     Tests that keys data 423 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData423_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData423 = value;
            Assert.Equal(value, obj.KeysData423);
        }

        /// <summary>
        ///     Tests that keys data 424 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData424_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData424 = value;
            Assert.Equal(value, obj.KeysData424);
        }

        /// <summary>
        ///     Tests that keys data 425 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData425_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData425 = value;
            Assert.Equal(value, obj.KeysData425);
        }

        /// <summary>
        ///     Tests that keys data 426 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData426_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData426 = value;
            Assert.Equal(value, obj.KeysData426);
        }

        /// <summary>
        ///     Tests that keys data 427 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData427_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData427 = value;
            Assert.Equal(value, obj.KeysData427);
        }

        /// <summary>
        ///     Tests that keys data 428 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData428_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData428 = value;
            Assert.Equal(value, obj.KeysData428);
        }

        /// <summary>
        ///     Tests that keys data 429 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData429_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData429 = value;
            Assert.Equal(value, obj.KeysData429);
        }

        /// <summary>
        ///     Tests that keys data 430 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData430_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData430 = value;
            Assert.Equal(value, obj.KeysData430);
        }

        /// <summary>
        ///     Tests that keys data 431 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData431_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData431 = value;
            Assert.Equal(value, obj.KeysData431);
        }

        /// <summary>
        ///     Tests that keys data 432 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData432_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData432 = value;
            Assert.Equal(value, obj.KeysData432);
        }

        /// <summary>
        ///     Tests that keys data 433 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData433_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData433 = value;
            Assert.Equal(value, obj.KeysData433);
        }

        /// <summary>
        ///     Tests that keys data 434 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData434_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData434 = value;
            Assert.Equal(value, obj.KeysData434);
        }

        /// <summary>
        ///     Tests that keys data 435 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData435_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData435 = value;
            Assert.Equal(value, obj.KeysData435);
        }

        /// <summary>
        ///     Tests that keys data 436 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData436_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData436 = value;
            Assert.Equal(value, obj.KeysData436);
        }

        /// <summary>
        ///     Tests that keys data 437 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData437_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData437 = value;
            Assert.Equal(value, obj.KeysData437);
        }

        /// <summary>
        ///     Tests that keys data 438 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData438_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData438 = value;
            Assert.Equal(value, obj.KeysData438);
        }

        /// <summary>
        ///     Tests that keys data 439 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData439_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData439 = value;
            Assert.Equal(value, obj.KeysData439);
        }

        /// <summary>
        ///     Tests that keys data 69 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData69_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData69 = value;
            Assert.Equal(value, obj.KeysData69);
        }

        /// <summary>
        ///     Tests that keys data 70 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData70_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData70 = value;
            Assert.Equal(value, obj.KeysData70);
        }

        /// <summary>
        ///     Tests that v 6 keys data 71 set and get returns correct value
        /// </summary>
        [Fact]
        public void V6_KeysData71_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData71 = value;
            Assert.Equal(value, obj.KeysData71);
        }

        /// <summary>
        ///     Tests that v 6 keys data 72 set and get returns correct value
        /// </summary>
        [Fact]
        public void V6_KeysData72_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData72 = value;
            Assert.Equal(value, obj.KeysData72);
        }

        /// <summary>
        ///     Tests that v 6 keys data 73 set and get returns correct value
        /// </summary>
        [Fact]
        public void V6_KeysData73_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData73 = value;
            Assert.Equal(value, obj.KeysData73);
        }

        /// <summary>
        ///     Tests that keys data 74 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData74_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData74 = value;
            Assert.Equal(value, obj.KeysData74);
        }

        /// <summary>
        ///     Tests that keys data 75 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData75_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData75 = value;
            Assert.Equal(value, obj.KeysData75);
        }

        /// <summary>
        ///     Tests that keys data 76 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData76_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData76 = value;
            Assert.Equal(value, obj.KeysData76);
        }

        /// <summary>
        ///     Tests that keys data 77 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData77_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData77 = value;
            Assert.Equal(value, obj.KeysData77);
        }

        /// <summary>
        ///     Tests that keys data 78 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData78_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData78 = value;
            Assert.Equal(value, obj.KeysData78);
        }

        /// <summary>
        ///     Tests that keys data 79 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData79_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData79 = value;
            Assert.Equal(value, obj.KeysData79);
        }

        /// <summary>
        ///     Tests that keys data 80 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData80_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData80 = value;
            Assert.Equal(value, obj.KeysData80);
        }

        /// <summary>
        ///     Tests that keys data 81 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData81_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData81 = value;
            Assert.Equal(value, obj.KeysData81);
        }

        /// <summary>
        ///     Tests that keys data 82 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData82_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData82 = value;
            Assert.Equal(value, obj.KeysData82);
        }

        /// <summary>
        ///     Tests that keys data 83 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData83_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData83 = value;
            Assert.Equal(value, obj.KeysData83);
        }

        /// <summary>
        ///     Tests that keys data 84 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData84_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData84 = value;
            Assert.Equal(value, obj.KeysData84);
        }

        /// <summary>
        ///     Tests that keys data 85 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData85_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData85 = value;
            Assert.Equal(value, obj.KeysData85);
        }

        /// <summary>
        ///     Tests that keys data 86 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData86_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData86 = value;
            Assert.Equal(value, obj.KeysData86);
        }

        /// <summary>
        ///     Tests that keys data 87 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData87_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData87 = value;
            Assert.Equal(value, obj.KeysData87);
        }

        /// <summary>
        ///     Tests that keys data 88 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData88_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData88 = value;
            Assert.Equal(value, obj.KeysData88);
        }

        /// <summary>
        ///     Tests that keys data 89 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData89_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData89 = value;
            Assert.Equal(value, obj.KeysData89);
        }

        /// <summary>
        ///     Tests that keys data 90 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData90_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData90 = value;
            Assert.Equal(value, obj.KeysData90);
        }

        /// <summary>
        ///     Tests that keys data 91 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData91_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData91 = value;
            Assert.Equal(value, obj.KeysData91);
        }

        /// <summary>
        ///     Tests that keys data 92 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData92_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData92 = value;
            Assert.Equal(value, obj.KeysData92);
        }

        /// <summary>
        ///     Tests that keys data 93 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData93_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData93 = value;
            Assert.Equal(value, obj.KeysData93);
        }

        /// <summary>
        ///     Tests that keys data 94 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData94_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData94 = value;
            Assert.Equal(value, obj.KeysData94);
        }

        /// <summary>
        ///     Tests that keys data 95 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData95_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData95 = value;
            Assert.Equal(value, obj.KeysData95);
        }

        /// <summary>
        ///     Tests that keys data 96 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData96_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData96 = value;
            Assert.Equal(value, obj.KeysData96);
        }

        /// <summary>
        ///     Tests that keys data 97 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData97_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData97 = value;
            Assert.Equal(value, obj.KeysData97);
        }

        /// <summary>
        ///     Tests that keys data 98 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData98_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData98 = value;
            Assert.Equal(value, obj.KeysData98);
        }

        /// <summary>
        ///     Tests that keys data 99 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData99_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData99 = value;
            Assert.Equal(value, obj.KeysData99);
        }

        /// <summary>
        ///     Tests that keys data 100 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData100_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData100 = value;
            Assert.Equal(value, obj.KeysData100);
        }

        /// <summary>
        ///     Tests that keys data 101 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData101_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData101 = value;
            Assert.Equal(value, obj.KeysData101);
        }

        /// <summary>
        ///     Tests that keys data 102 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData102_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData102 = value;
            Assert.Equal(value, obj.KeysData102);
        }

        /// <summary>
        ///     Tests that keys data 103 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData103_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData103 = value;
            Assert.Equal(value, obj.KeysData103);
        }

        /// <summary>
        ///     Tests that keys data 104 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData104_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData104 = value;
            Assert.Equal(value, obj.KeysData104);
        }

        /// <summary>
        ///     Tests that keys data 105 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData105_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData105 = value;
            Assert.Equal(value, obj.KeysData105);
        }

        /// <summary>
        ///     Tests that v 5 keys data 69 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData69_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData69 = value;
            Assert.Equal(value, obj.KeysData69);
        }

        /// <summary>
        ///     Tests that v 5 keys data 70 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData70_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData70 = value;
            Assert.Equal(value, obj.KeysData70);
        }

        /// <summary>
        ///     Tests that v 5 keys data 71 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData71_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData71 = value;
            Assert.Equal(value, obj.KeysData71);
        }

        /// <summary>
        ///     Tests that v 5 keys data 72 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData72_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData72 = value;
            Assert.Equal(value, obj.KeysData72);
        }

        /// <summary>
        ///     Tests that v 5 keys data 73 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData73_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData73 = value;
            Assert.Equal(value, obj.KeysData73);
        }

        /// <summary>
        ///     Tests that v 5 keys data 74 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData74_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData74 = value;
            Assert.Equal(value, obj.KeysData74);
        }

        /// <summary>
        ///     Tests that v 5 keys data 75 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData75_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData75 = value;
            Assert.Equal(value, obj.KeysData75);
        }

        /// <summary>
        ///     Tests that v 5 keys data 76 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData76_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData76 = value;
            Assert.Equal(value, obj.KeysData76);
        }

        /// <summary>
        ///     Tests that v 5 keys data 77 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData77_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData77 = value;
            Assert.Equal(value, obj.KeysData77);
        }

        /// <summary>
        ///     Tests that v 5 keys data 78 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData78_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData78 = value;
            Assert.Equal(value, obj.KeysData78);
        }

        /// <summary>
        ///     Tests that v 5 keys data 79 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData79_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData79 = value;
            Assert.Equal(value, obj.KeysData79);
        }

        /// <summary>
        ///     Tests that v 5 keys data 80 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData80_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData80 = value;
            Assert.Equal(value, obj.KeysData80);
        }

        /// <summary>
        ///     Tests that v 5 keys data 81 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData81_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData81 = value;
            Assert.Equal(value, obj.KeysData81);
        }

        /// <summary>
        ///     Tests that v 5 keys data 82 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData82_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData82 = value;
            Assert.Equal(value, obj.KeysData82);
        }

        /// <summary>
        ///     Tests that v 5 keys data 83 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData83_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData83 = value;
            Assert.Equal(value, obj.KeysData83);
        }

        /// <summary>
        ///     Tests that v 5 keys data 84 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData84_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData84 = value;
            Assert.Equal(value, obj.KeysData84);
        }

        /// <summary>
        ///     Tests that v 5 keys data 85 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData85_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData85 = value;
            Assert.Equal(value, obj.KeysData85);
        }

        /// <summary>
        ///     Tests that v 5 keys data 86 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData86_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData86 = value;
            Assert.Equal(value, obj.KeysData86);
        }

        /// <summary>
        ///     Tests that v 5 keys data 87 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData87_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData87 = value;
            Assert.Equal(value, obj.KeysData87);
        }

        /// <summary>
        ///     Tests that v 5 keys data 88 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData88_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData88 = value;
            Assert.Equal(value, obj.KeysData88);
        }

        /// <summary>
        ///     Tests that v 5 keys data 89 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData89_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData89 = value;
            Assert.Equal(value, obj.KeysData89);
        }

        /// <summary>
        ///     Tests that v 5 keys data 90 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData90_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData90 = value;
            Assert.Equal(value, obj.KeysData90);
        }

        /// <summary>
        ///     Tests that v 5 keys data 91 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData91_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData91 = value;
            Assert.Equal(value, obj.KeysData91);
        }

        /// <summary>
        ///     Tests that v 5 keys data 92 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData92_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData92 = value;
            Assert.Equal(value, obj.KeysData92);
        }

        /// <summary>
        ///     Tests that v 5 keys data 93 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData93_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData93 = value;
            Assert.Equal(value, obj.KeysData93);
        }

        /// <summary>
        ///     Tests that v 5 keys data 94 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData94_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData94 = value;
            Assert.Equal(value, obj.KeysData94);
        }

        /// <summary>
        ///     Tests that v 5 keys data 95 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData95_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData95 = value;
            Assert.Equal(value, obj.KeysData95);
        }

        /// <summary>
        ///     Tests that v 5 keys data 96 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData96_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData96 = value;
            Assert.Equal(value, obj.KeysData96);
        }

        /// <summary>
        ///     Tests that v 5 keys data 97 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData97_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData97 = value;
            Assert.Equal(value, obj.KeysData97);
        }

        /// <summary>
        ///     Tests that v 5 keys data 98 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData98_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData98 = value;
            Assert.Equal(value, obj.KeysData98);
        }

        /// <summary>
        ///     Tests that v 5 keys data 99 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData99_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData99 = value;
            Assert.Equal(value, obj.KeysData99);
        }

        /// <summary>
        ///     Tests that v 5 keys data 100 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData100_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData100 = value;
            Assert.Equal(value, obj.KeysData100);
        }

        /// <summary>
        ///     Tests that v 5 keys data 101 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData101_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData101 = value;
            Assert.Equal(value, obj.KeysData101);
        }

        /// <summary>
        ///     Tests that v 5 keys data 102 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData102_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData102 = value;
            Assert.Equal(value, obj.KeysData102);
        }

        /// <summary>
        ///     Tests that v 5 keys data 103 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData103_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData103 = value;
            Assert.Equal(value, obj.KeysData103);
        }

        /// <summary>
        ///     Tests that v 5 keys data 104 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData104_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData104 = value;
            Assert.Equal(value, obj.KeysData104);
        }

        /// <summary>
        ///     Tests that v 5 keys data 105 set and get returns correct value
        /// </summary>
        [Fact]
        public void V5_KeysData105_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData105 = value;
            Assert.Equal(value, obj.KeysData105);
        }

        /// <summary>
        ///     Tests that keys data 300 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData300_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData300 = value;
            Assert.Equal(value, obj.KeysData300);
        }

        /// <summary>
        ///     Tests that keys data 301 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData301_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData301 = value;
            Assert.Equal(value, obj.KeysData301);
        }

        /// <summary>
        ///     Tests that keys data 302 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData302_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData302 = value;
            Assert.Equal(value, obj.KeysData302);
        }

        /// <summary>
        ///     Tests that keys data 303 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData303_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData303 = value;
            Assert.Equal(value, obj.KeysData303);
        }

        /// <summary>
        ///     Tests that keys data 304 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData304_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData304 = value;
            Assert.Equal(value, obj.KeysData304);
        }

        /// <summary>
        ///     Tests that keys data 305 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData305_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData305 = value;
            Assert.Equal(value, obj.KeysData305);
        }

        /// <summary>
        ///     Tests that keys data 306 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData306_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData306 = value;
            Assert.Equal(value, obj.KeysData306);
        }

        /// <summary>
        ///     Tests that keys data 307 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData307_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData307 = value;
            Assert.Equal(value, obj.KeysData307);
        }

        /// <summary>
        ///     Tests that keys data 308 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData308_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData308 = value;
            Assert.Equal(value, obj.KeysData308);
        }

        /// <summary>
        ///     Tests that keys data 309 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData309_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData309 = value;
            Assert.Equal(value, obj.KeysData309);
        }

        /// <summary>
        ///     Tests that keys data 310 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData310_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData310 = value;
            Assert.Equal(value, obj.KeysData310);
        }

        /// <summary>
        ///     Tests that keys data 311 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData311_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData311 = value;
            Assert.Equal(value, obj.KeysData311);
        }

        /// <summary>
        ///     Tests that keys data 312 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData312_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData312 = value;
            Assert.Equal(value, obj.KeysData312);
        }

        /// <summary>
        ///     Tests that keys data 313 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData313_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData313 = value;
            Assert.Equal(value, obj.KeysData313);
        }

        /// <summary>
        ///     Tests that keys data 314 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData314_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData314 = value;
            Assert.Equal(value, obj.KeysData314);
        }

        /// <summary>
        ///     Tests that keys data 315 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData315_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData315 = value;
            Assert.Equal(value, obj.KeysData315);
        }

        /// <summary>
        ///     Tests that keys data 316 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData316_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData316 = value;
            Assert.Equal(value, obj.KeysData316);
        }

        /// <summary>
        ///     Tests that keys data 317 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData317_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData317 = value;
            Assert.Equal(value, obj.KeysData317);
        }

        /// <summary>
        ///     Tests that keys data 318 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData318_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData318 = value;
            Assert.Equal(value, obj.KeysData318);
        }

        /// <summary>
        ///     Tests that keys data 319 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData319_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData319 = value;
            Assert.Equal(value, obj.KeysData319);
        }

        /// <summary>
        ///     Tests that keys data 320 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData320_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData320 = value;
            Assert.Equal(value, obj.KeysData320);
        }

        /// <summary>
        ///     Tests that keys data 321 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData321_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData321 = value;
            Assert.Equal(value, obj.KeysData321);
        }

        /// <summary>
        ///     Tests that keys data 322 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData322_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData322 = value;
            Assert.Equal(value, obj.KeysData322);
        }

        /// <summary>
        ///     Tests that keys data 323 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData323_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData323 = value;
            Assert.Equal(value, obj.KeysData323);
        }

        /// <summary>
        ///     Tests that keys data 324 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData324_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData324 = value;
            Assert.Equal(value, obj.KeysData324);
        }

        /// <summary>
        ///     Tests that keys data 325 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData325_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData325 = value;
            Assert.Equal(value, obj.KeysData325);
        }

        /// <summary>
        ///     Tests that keys data 326 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData326_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData326 = value;
            Assert.Equal(value, obj.KeysData326);
        }

        /// <summary>
        ///     Tests that keys data 327 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData327_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData327 = value;
            Assert.Equal(value, obj.KeysData327);
        }

        /// <summary>
        ///     Tests that keys data 328 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData328_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData328 = value;
            Assert.Equal(value, obj.KeysData328);
        }

        /// <summary>
        ///     Tests that keys data 329 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData329_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData329 = value;
            Assert.Equal(value, obj.KeysData329);
        }

        /// <summary>
        ///     Tests that keys data 330 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData330_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData330 = value;
            Assert.Equal(value, obj.KeysData330);
        }

        /// <summary>
        ///     Tests that keys data 331 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData331_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData331 = value;
            Assert.Equal(value, obj.KeysData331);
        }

        /// <summary>
        ///     Tests that keys data 332 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData332_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData332 = value;
            Assert.Equal(value, obj.KeysData332);
        }

        /// <summary>
        ///     Tests that keys data 333 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData333_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData333 = value;
            Assert.Equal(value, obj.KeysData333);
        }

        /// <summary>
        ///     Tests that keys data 334 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData334_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData334 = value;
            Assert.Equal(value, obj.KeysData334);
        }

        /// <summary>
        ///     Tests that keys data 335 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData335_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData335 = value;
            Assert.Equal(value, obj.KeysData335);
        }

        /// <summary>
        ///     Tests that keys data 336 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData336_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData336 = value;
            Assert.Equal(value, obj.KeysData336);
        }

        /// <summary>
        ///     Tests that keys data 337 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData337_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData337 = value;
            Assert.Equal(value, obj.KeysData337);
        }

        /// <summary>
        ///     Tests that keys data 338 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData338_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData338 = value;
            Assert.Equal(value, obj.KeysData338);
        }

        /// <summary>
        ///     Tests that keys data 339 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData339_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData339 = value;
            Assert.Equal(value, obj.KeysData339);
        }

        /// <summary>
        ///     Tests that keys data 340 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData340_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData340 = value;
            Assert.Equal(value, obj.KeysData340);
        }

        /// <summary>
        ///     Tests that keys data 341 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData341_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData341 = value;
            Assert.Equal(value, obj.KeysData341);
        }

        /// <summary>
        ///     Tests that keys data 342 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData342_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData342 = value;
            Assert.Equal(value, obj.KeysData342);
        }

        /// <summary>
        ///     Tests that keys data 343 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData343_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData343 = value;
            Assert.Equal(value, obj.KeysData343);
        }

        /// <summary>
        ///     Tests that keys data 344 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData344_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData344 = value;
            Assert.Equal(value, obj.KeysData344);
        }

        /// <summary>
        ///     Tests that keys data 345 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData345_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData345 = value;
            Assert.Equal(value, obj.KeysData345);
        }

        /// <summary>
        ///     Tests that keys data 346 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData346_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData346 = value;
            Assert.Equal(value, obj.KeysData346);
        }

        /// <summary>
        ///     Tests that keys data 347 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData347_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData347 = value;
            Assert.Equal(value, obj.KeysData347);
        }

        /// <summary>
        ///     Tests that keys data 348 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData348_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData348 = value;
            Assert.Equal(value, obj.KeysData348);
        }

        /// <summary>
        ///     Tests that keys data 349 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData349_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData349 = value;
            Assert.Equal(value, obj.KeysData349);
        }

        /// <summary>
        ///     Tests that keys data 350 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData350_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData350 = value;
            Assert.Equal(value, obj.KeysData350);
        }

        /// <summary>
        ///     Tests that keys data 351 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData351_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData351 = value;
            Assert.Equal(value, obj.KeysData351);
        }

        /// <summary>
        ///     Tests that keys data 352 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData352_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData352 = value;
            Assert.Equal(value, obj.KeysData352);
        }

        /// <summary>
        ///     Tests that keys data 353 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData353_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData353 = value;
            Assert.Equal(value, obj.KeysData353);
        }

        /// <summary>
        ///     Tests that keys data 354 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData354_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData354 = value;
            Assert.Equal(value, obj.KeysData354);
        }

        /// <summary>
        ///     Tests that keys data 355 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData355_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData355 = value;
            Assert.Equal(value, obj.KeysData355);
        }

        /// <summary>
        ///     Tests that keys data 356 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData356_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData356 = value;
            Assert.Equal(value, obj.KeysData356);
        }

        /// <summary>
        ///     Tests that keys data 357 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData357_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData357 = value;
            Assert.Equal(value, obj.KeysData357);
        }

        /// <summary>
        ///     Tests that keys data 358 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData358_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData358 = value;
            Assert.Equal(value, obj.KeysData358);
        }

        /// <summary>
        ///     Tests that keys data 359 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData359_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData359 = value;
            Assert.Equal(value, obj.KeysData359);
        }

        /// <summary>
        ///     Tests that keys data 360 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData360_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData360 = value;
            Assert.Equal(value, obj.KeysData360);
        }

        /// <summary>
        ///     Tests that keys data 361 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData361_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData361 = value;
            Assert.Equal(value, obj.KeysData361);
        }

        /// <summary>
        ///     Tests that keys data 362 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData362_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData362 = value;
            Assert.Equal(value, obj.KeysData362);
        }

        /// <summary>
        ///     Tests that keys data 363 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData363_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData363 = value;
            Assert.Equal(value, obj.KeysData363);
        }

        /// <summary>
        ///     Tests that keys data 364 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData364_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData364 = value;
            Assert.Equal(value, obj.KeysData364);
        }

        /// <summary>
        ///     Tests that keys data 365 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData365_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData365 = value;
            Assert.Equal(value, obj.KeysData365);
        }

        /// <summary>
        ///     Tests that keys data 366 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData366_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData366 = value;
            Assert.Equal(value, obj.KeysData366);
        }

        /// <summary>
        ///     Tests that keys data 367 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData367_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData367 = value;
            Assert.Equal(value, obj.KeysData367);
        }

        /// <summary>
        ///     Tests that keys data 368 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData368_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData368 = value;
            Assert.Equal(value, obj.KeysData368);
        }

        /// <summary>
        ///     Tests that keys data 369 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData369_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData369 = value;
            Assert.Equal(value, obj.KeysData369);
        }

        /// <summary>
        ///     Tests that keys data 370 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData370_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData370 = value;
            Assert.Equal(value, obj.KeysData370);
        }

        /// <summary>
        ///     Tests that keys data 371 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData371_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData371 = value;
            Assert.Equal(value, obj.KeysData371);
        }

        /// <summary>
        ///     Tests that keys data 372 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData372_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData372 = value;
            Assert.Equal(value, obj.KeysData372);
        }

        /// <summary>
        ///     Tests that keys data 373 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData373_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData373 = value;
            Assert.Equal(value, obj.KeysData373);
        }

        /// <summary>
        ///     Tests that keys data 374 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData374_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData374 = value;
            Assert.Equal(value, obj.KeysData374);
        }

        /// <summary>
        ///     Tests that keys data 375 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData375_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData375 = value;
            Assert.Equal(value, obj.KeysData375);
        }

        /// <summary>
        ///     Tests that keys data 376 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData376_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData376 = value;
            Assert.Equal(value, obj.KeysData376);
        }

        /// <summary>
        ///     Tests that keys data 377 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData377_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData377 = value;
            Assert.Equal(value, obj.KeysData377);
        }

        /// <summary>
        ///     Tests that keys data 378 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData378_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData378 = value;
            Assert.Equal(value, obj.KeysData378);
        }

        /// <summary>
        ///     Tests that keys data 379 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData379_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData379 = value;
            Assert.Equal(value, obj.KeysData379);
        }

        /// <summary>
        ///     Tests that keys data 380 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData380_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData380 = value;
            Assert.Equal(value, obj.KeysData380);
        }

        /// <summary>
        ///     Tests that keys data 381 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData381_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData381 = value;
            Assert.Equal(value, obj.KeysData381);
        }

        /// <summary>
        ///     Tests that keys data 382 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData382_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData382 = value;
            Assert.Equal(value, obj.KeysData382);
        }

        /// <summary>
        ///     Tests that keys data 383 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData383_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData383 = value;
            Assert.Equal(value, obj.KeysData383);
        }

        /// <summary>
        ///     Tests that keys data 384 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData384_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData384 = value;
            Assert.Equal(value, obj.KeysData384);
        }

        /// <summary>
        ///     Tests that keys data 385 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData385_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData385 = value;
            Assert.Equal(value, obj.KeysData385);
        }

        /// <summary>
        ///     Tests that keys data 386 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData386_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData386 = value;
            Assert.Equal(value, obj.KeysData386);
        }

        /// <summary>
        ///     Tests that keys data 387 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData387_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData387 = value;
            Assert.Equal(value, obj.KeysData387);
        }

        /// <summary>
        ///     Tests that keys data 388 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData388_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData388 = value;
            Assert.Equal(value, obj.KeysData388);
        }

        /// <summary>
        ///     Tests that keys data 389 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData389_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData389 = value;
            Assert.Equal(value, obj.KeysData389);
        }

        /// <summary>
        ///     Tests that keys data 390 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData390_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData390 = value;
            Assert.Equal(value, obj.KeysData390);
        }

        /// <summary>
        ///     Tests that keys data 391 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData391_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData391 = value;
            Assert.Equal(value, obj.KeysData391);
        }

        /// <summary>
        ///     Tests that keys data 392 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData392_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData392 = value;
            Assert.Equal(value, obj.KeysData392);
        }

        /// <summary>
        ///     Tests that keys data 393 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData393_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData393 = value;
            Assert.Equal(value, obj.KeysData393);
        }

        /// <summary>
        ///     Tests that keys data 394 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData394_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData394 = value;
            Assert.Equal(value, obj.KeysData394);
        }

        /// <summary>
        ///     Tests that keys data 395 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData395_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData395 = value;
            Assert.Equal(value, obj.KeysData395);
        }

        /// <summary>
        ///     Tests that keys data 396 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData396_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData396 = value;
            Assert.Equal(value, obj.KeysData396);
        }

        /// <summary>
        ///     Tests that keys data 397 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData397_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData397 = value;
            Assert.Equal(value, obj.KeysData397);
        }

        /// <summary>
        ///     Tests that keys data 398 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData398_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData398 = value;
            Assert.Equal(value, obj.KeysData398);
        }

        /// <summary>
        ///     Tests that keys data 399 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData399_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData399 = value;
            Assert.Equal(value, obj.KeysData399);
        }

        /// <summary>
        ///     Tests that keys data 200 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData200_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData200 = value;
            Assert.Equal(value, obj.KeysData200);
        }

        /// <summary>
        ///     Tests that keys data 201 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData201_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData201 = value;
            Assert.Equal(value, obj.KeysData201);
        }

        /// <summary>
        ///     Tests that keys data 202 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData202_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData202 = value;
            Assert.Equal(value, obj.KeysData202);
        }

        /// <summary>
        ///     Tests that keys data 203 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData203_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData203 = value;
            Assert.Equal(value, obj.KeysData203);
        }

        /// <summary>
        ///     Tests that keys data 204 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData204_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData204 = value;
            Assert.Equal(value, obj.KeysData204);
        }

        /// <summary>
        ///     Tests that keys data 205 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData205_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData205 = value;
            Assert.Equal(value, obj.KeysData205);
        }

        /// <summary>
        ///     Tests that keys data 206 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData206_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData206 = value;
            Assert.Equal(value, obj.KeysData206);
        }

        /// <summary>
        ///     Tests that keys data 207 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData207_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData207 = value;
            Assert.Equal(value, obj.KeysData207);
        }

        /// <summary>
        ///     Tests that keys data 208 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData208_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData208 = value;
            Assert.Equal(value, obj.KeysData208);
        }

        /// <summary>
        ///     Tests that keys data 209 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData209_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData209 = value;
            Assert.Equal(value, obj.KeysData209);
        }

        /// <summary>
        ///     Tests that keys data 210 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData210_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData210 = value;
            Assert.Equal(value, obj.KeysData210);
        }

        /// <summary>
        ///     Tests that keys data 211 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData211_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData211 = value;
            Assert.Equal(value, obj.KeysData211);
        }

        /// <summary>
        ///     Tests that keys data 212 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData212_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData212 = value;
            Assert.Equal(value, obj.KeysData212);
        }

        /// <summary>
        ///     Tests that keys data 213 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData213_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData213 = value;
            Assert.Equal(value, obj.KeysData213);
        }

        /// <summary>
        ///     Tests that keys data 214 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData214_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData214 = value;
            Assert.Equal(value, obj.KeysData214);
        }

        /// <summary>
        ///     Tests that keys data 215 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData215_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData215 = value;
            Assert.Equal(value, obj.KeysData215);
        }

        /// <summary>
        ///     Tests that keys data 216 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData216_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData216 = value;
            Assert.Equal(value, obj.KeysData216);
        }

        /// <summary>
        ///     Tests that keys data 217 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData217_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData217 = value;
            Assert.Equal(value, obj.KeysData217);
        }

        /// <summary>
        ///     Tests that keys data 218 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData218_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData218 = value;
            Assert.Equal(value, obj.KeysData218);
        }

        /// <summary>
        ///     Tests that keys data 219 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData219_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData219 = value;
            Assert.Equal(value, obj.KeysData219);
        }

        /// <summary>
        ///     Tests that keys data 220 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData220_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData220 = value;
            Assert.Equal(value, obj.KeysData220);
        }

        /// <summary>
        ///     Tests that keys data 221 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData221_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData221 = value;
            Assert.Equal(value, obj.KeysData221);
        }

        /// <summary>
        ///     Tests that keys data 222 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData222_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData222 = value;
            Assert.Equal(value, obj.KeysData222);
        }

        /// <summary>
        ///     Tests that keys data 223 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData223_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData223 = value;
            Assert.Equal(value, obj.KeysData223);
        }

        /// <summary>
        ///     Tests that keys data 224 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData224_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData224 = value;
            Assert.Equal(value, obj.KeysData224);
        }

        /// <summary>
        ///     Tests that keys data 225 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData225_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData225 = value;
            Assert.Equal(value, obj.KeysData225);
        }

        /// <summary>
        ///     Tests that keys data 226 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData226_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData226 = value;
            Assert.Equal(value, obj.KeysData226);
        }

        /// <summary>
        ///     Tests that keys data 227 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData227_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData227 = value;
            Assert.Equal(value, obj.KeysData227);
        }

        /// <summary>
        ///     Tests that keys data 228 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData228_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData228 = value;
            Assert.Equal(value, obj.KeysData228);
        }

        /// <summary>
        ///     Tests that keys data 229 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData229_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData229 = value;
            Assert.Equal(value, obj.KeysData229);
        }

        /// <summary>
        ///     Tests that keys data 230 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData230_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData230 = value;
            Assert.Equal(value, obj.KeysData230);
        }

        /// <summary>
        ///     Tests that keys data 231 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData231_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData231 = value;
            Assert.Equal(value, obj.KeysData231);
        }

        /// <summary>
        ///     Tests that keys data 232 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData232_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData232 = value;
            Assert.Equal(value, obj.KeysData232);
        }

        /// <summary>
        ///     Tests that keys data 233 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData233_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData233 = value;
            Assert.Equal(value, obj.KeysData233);
        }

        /// <summary>
        ///     Tests that keys data 234 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData234_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData234 = value;
            Assert.Equal(value, obj.KeysData234);
        }

        /// <summary>
        ///     Tests that keys data 235 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData235_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData235 = value;
            Assert.Equal(value, obj.KeysData235);
        }

        /// <summary>
        ///     Tests that keys data 236 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData236_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData236 = value;
            Assert.Equal(value, obj.KeysData236);
        }

        /// <summary>
        ///     Tests that keys data 237 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData237_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData237 = value;
            Assert.Equal(value, obj.KeysData237);
        }

        /// <summary>
        ///     Tests that keys data 238 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData238_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData238 = value;
            Assert.Equal(value, obj.KeysData238);
        }

        /// <summary>
        ///     Tests that keys data 239 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData239_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData239 = value;
            Assert.Equal(value, obj.KeysData239);
        }

        /// <summary>
        ///     Tests that keys data 240 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData240_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData240 = value;
            Assert.Equal(value, obj.KeysData240);
        }

        /// <summary>
        ///     Tests that keys data 241 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData241_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData241 = value;
            Assert.Equal(value, obj.KeysData241);
        }

        /// <summary>
        ///     Tests that keys data 242 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData242_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData242 = value;
            Assert.Equal(value, obj.KeysData242);
        }

        /// <summary>
        ///     Tests that keys data 243 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData243_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData243 = value;
            Assert.Equal(value, obj.KeysData243);
        }

        /// <summary>
        ///     Tests that keys data 244 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData244_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData244 = value;
            Assert.Equal(value, obj.KeysData244);
        }

        /// <summary>
        ///     Tests that keys data 245 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData245_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData245 = value;
            Assert.Equal(value, obj.KeysData245);
        }

        /// <summary>
        ///     Tests that keys data 246 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData246_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData246 = value;
            Assert.Equal(value, obj.KeysData246);
        }

        /// <summary>
        ///     Tests that keys data 247 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData247_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData247 = value;
            Assert.Equal(value, obj.KeysData247);
        }

        /// <summary>
        ///     Tests that keys data 248 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData248_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData248 = value;
            Assert.Equal(value, obj.KeysData248);
        }

        /// <summary>
        ///     Tests that keys data 249 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData249_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData249 = value;
            Assert.Equal(value, obj.KeysData249);
        }

        /// <summary>
        ///     Tests that keys data 250 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData250_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData250 = value;
            Assert.Equal(value, obj.KeysData250);
        }

        /// <summary>
        ///     Tests that keys data 251 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData251_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData251 = value;
            Assert.Equal(value, obj.KeysData251);
        }

        /// <summary>
        ///     Tests that keys data 252 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData252_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData252 = value;
            Assert.Equal(value, obj.KeysData252);
        }

        /// <summary>
        ///     Tests that keys data 253 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData253_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData253 = value;
            Assert.Equal(value, obj.KeysData253);
        }

        /// <summary>
        ///     Tests that keys data 254 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData254_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData254 = value;
            Assert.Equal(value, obj.KeysData254);
        }

        /// <summary>
        ///     Tests that keys data 255 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData255_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData255 = value;
            Assert.Equal(value, obj.KeysData255);
        }

        /// <summary>
        ///     Tests that keys data 256 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData256_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData256 = value;
            Assert.Equal(value, obj.KeysData256);
        }

        /// <summary>
        ///     Tests that keys data 257 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData257_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData257 = value;
            Assert.Equal(value, obj.KeysData257);
        }

        /// <summary>
        ///     Tests that keys data 258 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData258_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData258 = value;
            Assert.Equal(value, obj.KeysData258);
        }

        /// <summary>
        ///     Tests that keys data 259 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData259_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData259 = value;
            Assert.Equal(value, obj.KeysData259);
        }

        /// <summary>
        ///     Tests that keys data 260 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData260_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData260 = value;
            Assert.Equal(value, obj.KeysData260);
        }

        /// <summary>
        ///     Tests that keys data 261 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData261_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData261 = value;
            Assert.Equal(value, obj.KeysData261);
        }

        /// <summary>
        ///     Tests that keys data 262 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData262_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData262 = value;
            Assert.Equal(value, obj.KeysData262);
        }

        /// <summary>
        ///     Tests that keys data 263 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData263_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData263 = value;
            Assert.Equal(value, obj.KeysData263);
        }

        /// <summary>
        ///     Tests that keys data 264 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData264_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData264 = value;
            Assert.Equal(value, obj.KeysData264);
        }

        /// <summary>
        ///     Tests that keys data 265 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData265_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData265 = value;
            Assert.Equal(value, obj.KeysData265);
        }

        /// <summary>
        ///     Tests that keys data 266 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData266_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData266 = value;
            Assert.Equal(value, obj.KeysData266);
        }

        /// <summary>
        ///     Tests that keys data 267 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData267_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData267 = value;
            Assert.Equal(value, obj.KeysData267);
        }

        /// <summary>
        ///     Tests that keys data 181 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData181_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData181 = value;
            Assert.Equal(value, obj.KeysData181);
        }

        /// <summary>
        ///     Tests that keys data 182 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData182_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData182 = value;
            Assert.Equal(value, obj.KeysData182);
        }

        /// <summary>
        ///     Tests that keys data 183 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData183_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData183 = value;
            Assert.Equal(value, obj.KeysData183);
        }

        /// <summary>
        ///     Tests that keys data 184 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData184_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData184 = value;
            Assert.Equal(value, obj.KeysData184);
        }

        /// <summary>
        ///     Tests that keys data 185 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData185_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData185 = value;
            Assert.Equal(value, obj.KeysData185);
        }

        /// <summary>
        ///     Tests that keys data 186 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData186_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData186 = value;
            Assert.Equal(value, obj.KeysData186);
        }

        /// <summary>
        ///     Tests that keys data 187 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData187_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData187 = value;
            Assert.Equal(value, obj.KeysData187);
        }

        /// <summary>
        ///     Tests that keys data 188 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData188_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData188 = value;
            Assert.Equal(value, obj.KeysData188);
        }

        /// <summary>
        ///     Tests that keys data 189 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData189_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData189 = value;
            Assert.Equal(value, obj.KeysData189);
        }

        /// <summary>
        ///     Tests that keys data 190 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData190_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData190 = value;
            Assert.Equal(value, obj.KeysData190);
        }

        /// <summary>
        ///     Tests that keys data 191 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData191_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData191 = value;
            Assert.Equal(value, obj.KeysData191);
        }

        /// <summary>
        ///     Tests that keys data 192 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData192_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData192 = value;
            Assert.Equal(value, obj.KeysData192);
        }

        /// <summary>
        ///     Tests that keys data 193 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData193_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData193 = value;
            Assert.Equal(value, obj.KeysData193);
        }

        /// <summary>
        ///     Tests that keys data 194 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData194_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData194 = value;
            Assert.Equal(value, obj.KeysData194);
        }

        /// <summary>
        ///     Tests that keys data 195 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData195_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData195 = value;
            Assert.Equal(value, obj.KeysData195);
        }

        /// <summary>
        ///     Tests that keys data 196 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData196_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData196 = value;
            Assert.Equal(value, obj.KeysData196);
        }

        /// <summary>
        ///     Tests that keys data 197 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData197_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData197 = value;
            Assert.Equal(value, obj.KeysData197);
        }

        /// <summary>
        ///     Tests that keys data 198 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData198_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData198 = value;
            Assert.Equal(value, obj.KeysData198);
        }

        /// <summary>
        ///     Tests that keys data 199 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData199_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData199 = value;
            Assert.Equal(value, obj.KeysData199);
        }

        /// <summary>
        ///     Tests that keys data 268 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData268_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData268 = value;
            Assert.Equal(value, obj.KeysData268);
        }

        /// <summary>
        ///     Tests that keys data 269 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData269_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData269 = value;
            Assert.Equal(value, obj.KeysData269);
        }

        /// <summary>
        ///     Tests that keys data 270 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData270_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData270 = value;
            Assert.Equal(value, obj.KeysData270);
        }

        /// <summary>
        ///     Tests that keys data 271 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData271_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData271 = value;
            Assert.Equal(value, obj.KeysData271);
        }

        /// <summary>
        ///     Tests that keys data 272 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData272_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData272 = value;
            Assert.Equal(value, obj.KeysData272);
        }

        /// <summary>
        ///     Tests that keys data 273 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData273_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData273 = value;
            Assert.Equal(value, obj.KeysData273);
        }

        /// <summary>
        ///     Tests that keys data 274 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData274_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData274 = value;
            Assert.Equal(value, obj.KeysData274);
        }

        /// <summary>
        ///     Tests that keys data 275 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData275_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData275 = value;
            Assert.Equal(value, obj.KeysData275);
        }

        /// <summary>
        ///     Tests that keys data 276 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData276_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData276 = value;
            Assert.Equal(value, obj.KeysData276);
        }

        /// <summary>
        ///     Tests that keys data 277 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData277_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData277 = value;
            Assert.Equal(value, obj.KeysData277);
        }

        /// <summary>
        ///     Tests that keys data 278 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData278_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData278 = value;
            Assert.Equal(value, obj.KeysData278);
        }

        /// <summary>
        ///     Tests that keys data 279 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData279_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData279 = value;
            Assert.Equal(value, obj.KeysData279);
        }

        /// <summary>
        ///     Tests that keys data 280 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData280_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData280 = value;
            Assert.Equal(value, obj.KeysData280);
        }

        /// <summary>
        ///     Tests that keys data 281 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData281_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData281 = value;
            Assert.Equal(value, obj.KeysData281);
        }

        /// <summary>
        ///     Tests that keys data 282 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData282_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData282 = value;
            Assert.Equal(value, obj.KeysData282);
        }

        /// <summary>
        ///     Tests that keys data 283 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData283_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData283 = value;
            Assert.Equal(value, obj.KeysData283);
        }

        /// <summary>
        ///     Tests that keys data 284 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData284_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData284 = value;
            Assert.Equal(value, obj.KeysData284);
        }

        /// <summary>
        ///     Tests that keys data 285 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData285_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData285 = value;
            Assert.Equal(value, obj.KeysData285);
        }

        /// <summary>
        ///     Tests that keys data 286 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData286_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData286 = value;
            Assert.Equal(value, obj.KeysData286);
        }

        /// <summary>
        ///     Tests that keys data 287 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData287_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData287 = value;
            Assert.Equal(value, obj.KeysData287);
        }

        /// <summary>
        ///     Tests that keys data 288 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData288_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData288 = value;
            Assert.Equal(value, obj.KeysData288);
        }

        /// <summary>
        ///     Tests that keys data 289 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData289_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData289 = value;
            Assert.Equal(value, obj.KeysData289);
        }

        /// <summary>
        ///     Tests that keys data 290 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData290_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData290 = value;
            Assert.Equal(value, obj.KeysData290);
        }

        /// <summary>
        ///     Tests that keys data 291 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData291_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData291 = value;
            Assert.Equal(value, obj.KeysData291);
        }

        /// <summary>
        ///     Tests that keys data 292 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData292_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData292 = value;
            Assert.Equal(value, obj.KeysData292);
        }

        /// <summary>
        ///     Tests that keys data 293 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData293_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData293 = value;
            Assert.Equal(value, obj.KeysData293);
        }

        /// <summary>
        ///     Tests that keys data 294 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData294_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData294 = value;
            Assert.Equal(value, obj.KeysData294);
        }

        /// <summary>
        ///     Tests that keys data 295 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData295_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData295 = value;
            Assert.Equal(value, obj.KeysData295);
        }

        /// <summary>
        ///     Tests that keys data 296 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData296_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData296 = value;
            Assert.Equal(value, obj.KeysData296);
        }

        /// <summary>
        ///     Tests that keys data 297 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData297_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData297 = value;
            Assert.Equal(value, obj.KeysData297);
        }

        /// <summary>
        ///     Tests that keys data 298 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData298_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData298 = value;
            Assert.Equal(value, obj.KeysData298);
        }

        /// <summary>
        ///     Tests that keys data 299 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData299_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData();
            obj.KeysData299 = value;
            Assert.Equal(value, obj.KeysData299);
        }
    }
}