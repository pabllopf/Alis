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

using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui io test class
    /// </summary>
    public class ImGuiIoTest
    {
        /// <summary>
        ///     Tests that keys data 407 should be initialized
        /// </summary>
        [Fact]
        public void KeysData407_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.True(io.KeysData407.AnalogValue >= 0);
        }

        /// <summary>
        ///     Tests that keys data 408 should be initialized
        /// </summary>
        [Fact]
        public void KeysData408_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.True(io.KeysData408.AnalogValue >= 0);
        }

// Repeat similar tests for all KeysData properties

        /// <summary>
        ///     Tests that want capture mouse unless popup close should be initialized
        /// </summary>
        [Fact]
        public void WantCaptureMouseUnlessPopupClose_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.WantCaptureMouseUnlessPopupClose);
        }

        /// <summary>
        ///     Tests that mouse pos prev should be initialized
        /// </summary>
        [Fact]
        public void MousePosPrev_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2F), io.MousePosPrev);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 0 should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedPos0_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2F), io.MouseClickedPos0);
        }

// Repeat similar tests for all MouseClickedPos properties

        /// <summary>
        ///     Tests that mouse clicked time should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedTime_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClickedTime);
        }

        /// <summary>
        ///     Tests that mouse clicked should be initialized
        /// </summary>
        [Fact]
        public void MouseClicked_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClicked);
        }

        /// <summary>
        ///     Tests that mouse double clicked should be initialized
        /// </summary>
        [Fact]
        public void MouseDoubleClicked_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDoubleClicked);
        }

        /// <summary>
        ///     Tests that mouse clicked count should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedCount_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClickedCount);
        }

        /// <summary>
        ///     Tests that mouse clicked last count should be initialized
        /// </summary>
        [Fact]
        public void MouseClickedLastCount_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseClickedLastCount);
        }

        /// <summary>
        ///     Tests that mouse released should be initialized
        /// </summary>
        [Fact]
        public void MouseReleased_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseReleased);
        }

        /// <summary>
        ///     Tests that mouse down owned should be initialized
        /// </summary>
        [Fact]
        public void MouseDownOwned_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownOwned);
        }

        /// <summary>
        ///     Tests that mouse down owned unless popup close should be initialized
        /// </summary>
        [Fact]
        public void MouseDownOwnedUnlessPopupClose_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownOwnedUnlessPopupClose);
        }

        /// <summary>
        ///     Tests that mouse down duration should be initialized
        /// </summary>
        [Fact]
        public void MouseDownDuration_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownDuration);
        }

        /// <summary>
        ///     Tests that mouse down duration prev should be initialized
        /// </summary>
        [Fact]
        public void MouseDownDurationPrev_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDownDurationPrev);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 0 should be initialized
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs0_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2F), io.MouseDragMaxDistanceAbs0);
        }

        /// <summary>
        ///     Tests that mouse drag max distance sqr should be initialized
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceSqr_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Null(io.MouseDragMaxDistanceSqr);
        }

        /// <summary>
        ///     Tests that pen pressure should be initialized
        /// </summary>
        [Fact]
        public void PenPressure_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0f, io.PenPressure);
        }

        /// <summary>
        ///     Tests that app focus lost should be initialized
        /// </summary>
        [Fact]
        public void AppFocusLost_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.AppFocusLost);
        }

        /// <summary>
        ///     Tests that app accepting events should be initialized
        /// </summary>
        [Fact]
        public void AppAcceptingEvents_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.AppAcceptingEvents);
        }

        /// <summary>
        ///     Tests that backend using legacy key arrays should be initialized
        /// </summary>
        [Fact]
        public void BackendUsingLegacyKeyArrays_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.BackendUsingLegacyKeyArrays);
        }

        /// <summary>
        ///     Tests that backend using legacy nav input array should be initialized
        /// </summary>
        [Fact]
        public void BackendUsingLegacyNavInputArray_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.BackendUsingLegacyNavInputArray);
        }

        /// <summary>
        ///     Tests that input queue surrogate should be initialized
        /// </summary>
        [Fact]
        public void InputQueueSurrogate_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0, io.InputQueueSurrogate);
        }

        /// <summary>
        ///     Tests that input queue characters should be initialized
        /// </summary>
        [Fact]
        public void InputQueueCharacters_ShouldBeInitialized()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.True(io.InputQueueCharacters.Size >= 0);
        }

        /// <summary>
        ///     Tests that config flags set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigFlags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiConfigFlags value = new ImGuiConfigFlags();
            obj.ConfigFlags = value;
            Assert.Equal(value, obj.ConfigFlags);
        }

        /// <summary>
        ///     Tests that backend flags set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendFlags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            ImGuiBackendFlags value = new ImGuiBackendFlags();
            obj.BackendFlags = value;
            Assert.Equal(value, obj.BackendFlags);
        }

        /// <summary>
        ///     Tests that display size set and get returns correct value
        /// </summary>
        [Fact]
        public void DisplaySize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.DisplaySize = value;
            Assert.Equal(value, obj.DisplaySize);
        }

        /// <summary>
        ///     Tests that delta time set and get returns correct value
        /// </summary>
        [Fact]
        public void DeltaTime_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.DeltaTime = value;
            Assert.Equal(value, obj.DeltaTime);
        }

        /// <summary>
        ///     Tests that ini saving rate set and get returns correct value
        /// </summary>
        [Fact]
        public void IniSavingRate_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.IniSavingRate = value;
            Assert.Equal(value, obj.IniSavingRate);
        }

        /// <summary>
        ///     Tests that ini filename set and get returns correct value
        /// </summary>
        [Fact]
        public void IniFilename_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            IntPtr value = new IntPtr(123);
            obj.IniFilename = value;
            Assert.Equal(value, obj.IniFilename);
        }

        /// <summary>
        ///     Tests that log filename set and get returns correct value
        /// </summary>
        [Fact]
        public void LogFilename_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            IntPtr value = new IntPtr(123);
            obj.LogFilename = value;
            Assert.Equal(value, obj.LogFilename);
        }

        /// <summary>
        ///     Tests that mouse double click time set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDoubleClickTime_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.MouseDoubleClickTime = value;
            Assert.Equal(value, obj.MouseDoubleClickTime);
        }

        /// <summary>
        ///     Tests that mouse double click max dist set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDoubleClickMaxDist_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.MouseDoubleClickMaxDist = value;
            Assert.Equal(value, obj.MouseDoubleClickMaxDist);
        }

        /// <summary>
        ///     Tests that mouse drag threshold set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragThreshold_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.MouseDragThreshold = value;
            Assert.Equal(value, obj.MouseDragThreshold);
        }

        /// <summary>
        ///     Tests that key repeat delay set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyRepeatDelay_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.KeyRepeatDelay = value;
            Assert.Equal(value, obj.KeyRepeatDelay);
        }

        /// <summary>
        ///     Tests that key repeat rate set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyRepeatRate_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.KeyRepeatRate = value;
            Assert.Equal(value, obj.KeyRepeatRate);
        }

        /// <summary>
        ///     Tests that hover delay normal set and get returns correct value
        /// </summary>
        [Fact]
        public void HoverDelayNormal_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.HoverDelayNormal = value;
            Assert.Equal(value, obj.HoverDelayNormal);
        }

        /// <summary>
        ///     Tests that hover delay short set and get returns correct value
        /// </summary>
        [Fact]
        public void HoverDelayShort_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.HoverDelayShort = value;
            Assert.Equal(value, obj.HoverDelayShort);
        }

        /// <summary>
        ///     Tests that user data set and get returns correct value
        /// </summary>
        [Fact]
        public void UserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            IntPtr value = new IntPtr(123);
            obj.UserData = value;
            Assert.Equal(value, obj.UserData);
        }

        /// <summary>
        ///     Tests that fonts set and get returns correct value
        /// </summary>
        [Fact]
        public void Fonts_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            IntPtr value = new IntPtr(123);
            obj.Fonts = value;
            Assert.Equal(value, obj.Fonts);
        }

        /// <summary>
        ///     Tests that font global scale set and get returns correct value
        /// </summary>
        [Fact]
        public void FontGlobalScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            float value = 1.0f;
            obj.FontGlobalScale = value;
            Assert.Equal(value, obj.FontGlobalScale);
        }

        /// <summary>
        ///     Tests that font allow user scaling set and get returns correct value
        /// </summary>
        [Fact]
        public void FontAllowUserScaling_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte value = 1;
            obj.FontAllowUserScaling = value;
            Assert.Equal(value, obj.FontAllowUserScaling);
        }

        /// <summary>
        ///     Tests that font default set and get returns correct value
        /// </summary>
        [Fact]
        public void FontDefault_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            IntPtr value = new IntPtr(123);
            obj.FontDefault = value;
            Assert.Equal(value, obj.FontDefault);
        }

        /// <summary>
        ///     Tests that display framebuffer scale set and get returns correct value
        /// </summary>
        [Fact]
        public void DisplayFramebufferScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            Vector2F value = new Vector2F();
            obj.DisplayFramebufferScale = value;
            Assert.Equal(value, obj.DisplayFramebufferScale);
        }

        /// <summary>
        ///     Tests that config docking no split set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingNoSplit_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte value = 1;
            obj.ConfigDockingNoSplit = value;
            Assert.Equal(value, obj.ConfigDockingNoSplit);
        }

        /// <summary>
        ///     Tests that config docking with shift set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingWithShift_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte value = 1;
            obj.ConfigDockingWithShift = value;
            Assert.Equal(value, obj.ConfigDockingWithShift);
        }

        /// <summary>
        ///     Tests that config docking always tab bar set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingAlwaysTabBar_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte value = 1;
            obj.ConfigDockingAlwaysTabBar = value;
            Assert.Equal(value, obj.ConfigDockingAlwaysTabBar);
        }

        /// <summary>
        ///     Tests that config docking transparent payload set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingTransparentPayload_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo obj = new ImGuiIo();
            byte value = 1;
            obj.ConfigDockingTransparentPayload = value;
            Assert.Equal(value, obj.ConfigDockingTransparentPayload);
        }
    }
}