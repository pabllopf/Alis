// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIoRemainingCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui io remaining coverage tests class
    /// </summary>
    public class ImGuiIoRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that config flags set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigFlags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiConfigFlags value = ImGuiConfigFlags.NavEnableKeyboard;
            io.ConfigFlags = value;
            Assert.Equal(value, io.ConfigFlags);
        }

        /// <summary>
        ///     Tests that backend flags set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendFlags_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiBackendFlags value = ImGuiBackendFlags.HasGamepad;
            io.BackendFlags = value;
            Assert.Equal(value, io.BackendFlags);
        }

        /// <summary>
        ///     Tests that display size set and get returns correct value
        /// </summary>
        [Fact]
        public void DisplaySize_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.DisplaySize = value;
            Assert.Equal(value, io.DisplaySize);
        }

        /// <summary>
        ///     Tests that delta time set and get returns correct value
        /// </summary>
        [Fact]
        public void DeltaTime_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.016f;
            io.DeltaTime = value;
            Assert.Equal(value, io.DeltaTime);
        }

        /// <summary>
        ///     Tests that ini saving rate set and get returns correct value
        /// </summary>
        [Fact]
        public void IniSavingRate_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 5.0f;
            io.IniSavingRate = value;
            Assert.Equal(value, io.IniSavingRate);
        }

        /// <summary>
        ///     Tests that ini filename set and get returns correct value
        /// </summary>
        [Fact]
        public void IniFilename_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.IniFilename = value;
            Assert.Equal(value, io.IniFilename);
        }

        /// <summary>
        ///     Tests that log filename set and get returns correct value
        /// </summary>
        [Fact]
        public void LogFilename_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.LogFilename = value;
            Assert.Equal(value, io.LogFilename);
        }

        /// <summary>
        ///     Tests that mouse double click time set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDoubleClickTime_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.3f;
            io.MouseDoubleClickTime = value;
            Assert.Equal(value, io.MouseDoubleClickTime);
        }

        /// <summary>
        ///     Tests that mouse double click max dist set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDoubleClickMaxDist_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 6.0f;
            io.MouseDoubleClickMaxDist = value;
            Assert.Equal(value, io.MouseDoubleClickMaxDist);
        }

        /// <summary>
        ///     Tests that mouse drag threshold set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragThreshold_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 6.0f;
            io.MouseDragThreshold = value;
            Assert.Equal(value, io.MouseDragThreshold);
        }

        /// <summary>
        ///     Tests that key repeat delay set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyRepeatDelay_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.25f;
            io.KeyRepeatDelay = value;
            Assert.Equal(value, io.KeyRepeatDelay);
        }

        /// <summary>
        ///     Tests that key repeat rate set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyRepeatRate_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.05f;
            io.KeyRepeatRate = value;
            Assert.Equal(value, io.KeyRepeatRate);
        }

        /// <summary>
        ///     Tests that hover delay normal set and get returns correct value
        /// </summary>
        [Fact]
        public void HoverDelayNormal_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.3f;
            io.HoverDelayNormal = value;
            Assert.Equal(value, io.HoverDelayNormal);
        }

        /// <summary>
        ///     Tests that hover delay short set and get returns correct value
        /// </summary>
        [Fact]
        public void HoverDelayShort_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.1f;
            io.HoverDelayShort = value;
            Assert.Equal(value, io.HoverDelayShort);
        }

        /// <summary>
        ///     Tests that user data set and get returns correct value
        /// </summary>
        [Fact]
        public void UserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.UserData = value;
            Assert.Equal(value, io.UserData);
        }

        /// <summary>
        ///     Tests that fonts set and get returns correct value
        /// </summary>
        [Fact]
        public void Fonts_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.Fonts = value;
            Assert.Equal(value, io.Fonts);
        }

        /// <summary>
        ///     Tests that font global scale set and get returns correct value
        /// </summary>
        [Fact]
        public void FontGlobalScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 1.5f;
            io.FontGlobalScale = value;
            Assert.Equal(value, io.FontGlobalScale);
        }

        /// <summary>
        ///     Tests that font allow user scaling set and get returns correct value
        /// </summary>
        [Fact]
        public void FontAllowUserScaling_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.FontAllowUserScaling = value;
            Assert.Equal(value, io.FontAllowUserScaling);
        }

        /// <summary>
        ///     Tests that font default set and get returns correct value
        /// </summary>
        [Fact]
        public void FontDefault_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.FontDefault = value;
            Assert.Equal(value, io.FontDefault);
        }

        /// <summary>
        ///     Tests that display framebuffer scale set and get returns correct value
        /// </summary>
        [Fact]
        public void DisplayFramebufferScale_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.DisplayFramebufferScale = value;
            Assert.Equal(value, io.DisplayFramebufferScale);
        }

        /// <summary>
        ///     Tests that config docking no split set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingNoSplit_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigDockingNoSplit = value;
            Assert.Equal(value, io.ConfigDockingNoSplit);
        }

        /// <summary>
        ///     Tests that config docking with shift set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingWithShift_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigDockingWithShift = value;
            Assert.Equal(value, io.ConfigDockingWithShift);
        }

        /// <summary>
        ///     Tests that config docking always tab bar set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingAlwaysTabBar_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigDockingAlwaysTabBar = value;
            Assert.Equal(value, io.ConfigDockingAlwaysTabBar);
        }

        /// <summary>
        ///     Tests that config docking transparent payload set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDockingTransparentPayload_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigDockingTransparentPayload = value;
            Assert.Equal(value, io.ConfigDockingTransparentPayload);
        }

        /// <summary>
        ///     Tests that config viewports no auto merge set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigViewportsNoAutoMerge_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigViewportsNoAutoMerge = value;
            Assert.Equal(value, io.ConfigViewportsNoAutoMerge);
        }

        /// <summary>
        ///     Tests that config viewports no task bar icon set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigViewportsNoTaskBarIcon_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigViewportsNoTaskBarIcon = value;
            Assert.Equal(value, io.ConfigViewportsNoTaskBarIcon);
        }

        /// <summary>
        ///     Tests that config viewports no decoration set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigViewportsNoDecoration_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigViewportsNoDecoration = value;
            Assert.Equal(value, io.ConfigViewportsNoDecoration);
        }

        /// <summary>
        ///     Tests that config viewports no default parent set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigViewportsNoDefaultParent_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigViewportsNoDefaultParent = value;
            Assert.Equal(value, io.ConfigViewportsNoDefaultParent);
        }

        /// <summary>
        ///     Tests that mouse draw cursor set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDrawCursor_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.MouseDrawCursor = value;
            Assert.Equal(value, io.MouseDrawCursor);
        }

        /// <summary>
        ///     Tests that config mac osx behaviors set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigMacOsxBehaviors_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigMacOsxBehaviors = value;
            Assert.Equal(value, io.ConfigMacOsxBehaviors);
        }

        /// <summary>
        ///     Tests that config input trickle event queue set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigInputTrickleEventQueue_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigInputTrickleEventQueue = value;
            Assert.Equal(value, io.ConfigInputTrickleEventQueue);
        }

        /// <summary>
        ///     Tests that config input text cursor blink set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigInputTextCursorBlink_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigInputTextCursorBlink = value;
            Assert.Equal(value, io.ConfigInputTextCursorBlink);
        }

        /// <summary>
        ///     Tests that config input text enter keep active set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigInputTextEnterKeepActive_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigInputTextEnterKeepActive = value;
            Assert.Equal(value, io.ConfigInputTextEnterKeepActive);
        }

        /// <summary>
        ///     Tests that config drag click to input text set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigDragClickToInputText_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigDragClickToInputText = value;
            Assert.Equal(value, io.ConfigDragClickToInputText);
        }

        /// <summary>
        ///     Tests that config windows resize from edges set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigWindowsResizeFromEdges_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigWindowsResizeFromEdges = value;
            Assert.Equal(value, io.ConfigWindowsResizeFromEdges);
        }

        /// <summary>
        ///     Tests that config windows move from title bar only set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigWindowsMoveFromTitleBarOnly_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.ConfigWindowsMoveFromTitleBarOnly = value;
            Assert.Equal(value, io.ConfigWindowsMoveFromTitleBarOnly);
        }

        /// <summary>
        ///     Tests that config memory compact timer set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigMemoryCompactTimer_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 60.0f;
            io.ConfigMemoryCompactTimer = value;
            Assert.Equal(value, io.ConfigMemoryCompactTimer);
        }

        /// <summary>
        ///     Tests that backend platform name set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendPlatformName_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.BackendPlatformName = value;
            Assert.Equal(value, io.BackendPlatformName);
        }

        /// <summary>
        ///     Tests that backend renderer name set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendRendererName_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.BackendRendererName = value;
            Assert.Equal(value, io.BackendRendererName);
        }

        /// <summary>
        ///     Tests that backend platform user data set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendPlatformUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.BackendPlatformUserData = value;
            Assert.Equal(value, io.BackendPlatformUserData);
        }

        /// <summary>
        ///     Tests that backend renderer user data set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendRendererUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.BackendRendererUserData = value;
            Assert.Equal(value, io.BackendRendererUserData);
        }

        /// <summary>
        ///     Tests that backend language user data set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendLanguageUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.BackendLanguageUserData = value;
            Assert.Equal(value, io.BackendLanguageUserData);
        }

        /// <summary>
        ///     Tests that get clipboard text fn set and get returns correct value
        /// </summary>
        [Fact]
        public void GetClipboardTextFn_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.GetClipboardTextFn = value;
            Assert.Equal(value, io.GetClipboardTextFn);
        }

        /// <summary>
        ///     Tests that set clipboard text fn set and get returns correct value
        /// </summary>
        [Fact]
        public void SetClipboardTextFn_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.SetClipboardTextFn = value;
            Assert.Equal(value, io.SetClipboardTextFn);
        }

        /// <summary>
        ///     Tests that clipboard user data set and get returns correct value
        /// </summary>
        [Fact]
        public void ClipboardUserData_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.ClipboardUserData = value;
            Assert.Equal(value, io.ClipboardUserData);
        }

        /// <summary>
        ///     Tests that set platform ime data fn set and get returns correct value
        /// </summary>
        [Fact]
        public void SetPlatformImeDataFn_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.SetPlatformImeDataFn = value;
            Assert.Equal(value, io.SetPlatformImeDataFn);
        }

        /// <summary>
        ///     Tests that unused padding set and get returns correct value
        /// </summary>
        [Fact]
        public void UnusedPadding_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            IntPtr value = new IntPtr(456);
            io.UnusedPadding = value;
            Assert.Equal(value, io.UnusedPadding);
        }

        /// <summary>
        ///     Tests that want capture mouse set and get returns correct value
        /// </summary>
        [Fact]
        public void WantCaptureMouse_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.WantCaptureMouse = value;
            Assert.Equal(value, io.WantCaptureMouse);
        }

        /// <summary>
        ///     Tests that want capture keyboard set and get returns correct value
        /// </summary>
        [Fact]
        public void WantCaptureKeyboard_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.WantCaptureKeyboard = value;
            Assert.Equal(value, io.WantCaptureKeyboard);
        }

        /// <summary>
        ///     Tests that want text input set and get returns correct value
        /// </summary>
        [Fact]
        public void WantTextInput_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.WantTextInput = value;
            Assert.Equal(value, io.WantTextInput);
        }

        /// <summary>
        ///     Tests that want set mouse pos set and get returns correct value
        /// </summary>
        [Fact]
        public void WantSetMousePos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.WantSetMousePos = value;
            Assert.Equal(value, io.WantSetMousePos);
        }

        /// <summary>
        ///     Tests that want save ini settings set and get returns correct value
        /// </summary>
        [Fact]
        public void WantSaveIniSettings_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.WantSaveIniSettings = value;
            Assert.Equal(value, io.WantSaveIniSettings);
        }

        /// <summary>
        ///     Tests that nav active set and get returns correct value
        /// </summary>
        [Fact]
        public void NavActive_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.NavActive = value;
            Assert.Equal(value, io.NavActive);
        }

        /// <summary>
        ///     Tests that nav visible set and get returns correct value
        /// </summary>
        [Fact]
        public void NavVisible_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.NavVisible = value;
            Assert.Equal(value, io.NavVisible);
        }

        /// <summary>
        ///     Tests that framerate set and get returns correct value
        /// </summary>
        [Fact]
        public void Framerate_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 60.0f;
            io.Framerate = value;
            Assert.Equal(value, io.Framerate);
        }

        /// <summary>
        ///     Tests that metrics render vertices set and get returns correct value
        /// </summary>
        [Fact]
        public void MetricsRenderVertices_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            int value = 1234;
            io.MetricsRenderVertices = value;
            Assert.Equal(value, io.MetricsRenderVertices);
        }

        /// <summary>
        ///     Tests that metrics render indices set and get returns correct value
        /// </summary>
        [Fact]
        public void MetricsRenderIndices_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            int value = 5678;
            io.MetricsRenderIndices = value;
            Assert.Equal(value, io.MetricsRenderIndices);
        }

        /// <summary>
        ///     Tests that metrics render windows set and get returns correct value
        /// </summary>
        [Fact]
        public void MetricsRenderWindows_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            int value = 9;
            io.MetricsRenderWindows = value;
            Assert.Equal(value, io.MetricsRenderWindows);
        }

        /// <summary>
        ///     Tests that metrics active windows set and get returns correct value
        /// </summary>
        [Fact]
        public void MetricsActiveWindows_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            int value = 4;
            io.MetricsActiveWindows = value;
            Assert.Equal(value, io.MetricsActiveWindows);
        }

        /// <summary>
        ///     Tests that metrics active allocations set and get returns correct value
        /// </summary>
        [Fact]
        public void MetricsActiveAllocations_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            int value = 7;
            io.MetricsActiveAllocations = value;
            Assert.Equal(value, io.MetricsActiveAllocations);
        }

        /// <summary>
        ///     Tests that mouse delta set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDelta_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseDelta = value;
            Assert.Equal(value, io.MouseDelta);
        }

        /// <summary>
        ///     Tests that mouse pos set and get returns correct value
        /// </summary>
        [Fact]
        public void MousePos_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MousePos = value;
            Assert.Equal(value, io.MousePos);
        }

        /// <summary>
        ///     Tests that mouse wheel set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseWheel_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 1.5f;
            io.MouseWheel = value;
            Assert.Equal(value, io.MouseWheel);
        }

        /// <summary>
        ///     Tests that mouse wheel horizontal set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseWheelH_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.5f;
            io.MouseWheelH = value;
            Assert.Equal(value, io.MouseWheelH);
        }

        /// <summary>
        ///     Tests that mouse hovered viewport set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseHoveredViewport_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            uint value = 42u;
            io.MouseHoveredViewport = value;
            Assert.Equal(value, io.MouseHoveredViewport);
        }

        /// <summary>
        ///     Tests that key ctrl set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyCtrl_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.KeyCtrl = value;
            Assert.Equal(value, io.KeyCtrl);
        }

        /// <summary>
        ///     Tests that key shift set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyShift_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.KeyShift = value;
            Assert.Equal(value, io.KeyShift);
        }

        /// <summary>
        ///     Tests that key alt set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyAlt_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.KeyAlt = value;
            Assert.Equal(value, io.KeyAlt);
        }

        /// <summary>
        ///     Tests that key super set and get returns correct value
        /// </summary>
        [Fact]
        public void KeySuper_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.KeySuper = value;
            Assert.Equal(value, io.KeySuper);
        }

        /// <summary>
        ///     Tests that key mods set and get returns correct value
        /// </summary>
        [Fact]
        public void KeyMods_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKey value = ImGuiKey.Tab;
            io.KeyMods = value;
            Assert.Equal(value, io.KeyMods);
        }

        /// <summary>
        ///     Tests that key map array round-trips a known element
        /// </summary>
        [Fact]
        public void KeyMap_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeyMap = new int[652];
            io.KeyMap[10] = 42;
            Assert.Equal(42, io.KeyMap[10]);
        }

        /// <summary>
        ///     Tests that keys down array round-trips a known element
        /// </summary>
        [Fact]
        public void KeysDown_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeysDown = new byte[652];
            io.KeysDown[20] = 7;
            Assert.Equal(7, io.KeysDown[20]);
        }

        /// <summary>
        ///     Tests that nav inputs array round-trips a known element
        /// </summary>
        [Fact]
        public void NavInputs_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.NavInputs = new float[16];
            io.NavInputs[5] = 0.8f;
            Assert.Equal(0.8f, io.NavInputs[5]);
        }

        /// <summary>
        ///     Tests that mouse down array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDown_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDown = new byte[5];
            io.MouseDown[2] = 1;
            Assert.Equal(1, io.MouseDown[2]);
        }

        /// <summary>
        ///     Tests that keys data 0 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData0_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 0.5f, DownDurationPrev = 0.25f, AnalogValue = 0.75f };
            io.KeysData0 = value;
            Assert.Equal((byte)1, io.KeysData0.Down);
            Assert.Equal(0.5f, io.KeysData0.DownDuration);
            Assert.Equal(0.25f, io.KeysData0.DownDurationPrev);
            Assert.Equal(0.75f, io.KeysData0.AnalogValue);
        }

        /// <summary>
        ///     Tests that keys data 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData1_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 0.5f, DownDurationPrev = 0.25f, AnalogValue = 0.75f };
            io.KeysData1 = value;
            Assert.Equal((byte)1, io.KeysData1.Down);
            Assert.Equal(0.5f, io.KeysData1.DownDuration);
            Assert.Equal(0.25f, io.KeysData1.DownDurationPrev);
            Assert.Equal(0.75f, io.KeysData1.AnalogValue);
        }

        /// <summary>
        ///     Tests that keys data 100 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData100_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 0.5f, DownDurationPrev = 0.25f, AnalogValue = 0.75f };
            io.KeysData100 = value;
            Assert.Equal((byte)1, io.KeysData100.Down);
            Assert.Equal(0.5f, io.KeysData100.DownDuration);
            Assert.Equal(0.25f, io.KeysData100.DownDurationPrev);
            Assert.Equal(0.75f, io.KeysData100.AnalogValue);
        }

        /// <summary>
        ///     Tests that keys data 294 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData294_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 0.5f, DownDurationPrev = 0.25f, AnalogValue = 0.75f };
            io.KeysData294 = value;
            Assert.Equal((byte)1, io.KeysData294.Down);
            Assert.Equal(0.5f, io.KeysData294.DownDuration);
            Assert.Equal(0.25f, io.KeysData294.DownDurationPrev);
            Assert.Equal(0.75f, io.KeysData294.AnalogValue);
        }

        /// <summary>
        ///     Tests that keys data 295 set and get returns correct value
        /// </summary>
        [Fact]
        public void KeysData295_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 0.5f, DownDurationPrev = 0.25f, AnalogValue = 0.75f };
            io.KeysData295 = value;
            Assert.Equal((byte)1, io.KeysData295.Down);
            Assert.Equal(0.5f, io.KeysData295.DownDuration);
            Assert.Equal(0.25f, io.KeysData295.DownDurationPrev);
            Assert.Equal(0.75f, io.KeysData295.AnalogValue);
        }

        /// <summary>
        ///     Tests that default state of im gui io has expected zeroed values
        /// </summary>
        [Fact]
        public void DefaultState_HasZeroedValues()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0f, io.DeltaTime);
            Assert.Equal(0f, io.IniSavingRate);
            Assert.Equal(0, io.FontAllowUserScaling);
            Assert.Equal(IntPtr.Zero, io.UserData);
            Assert.Equal(IntPtr.Zero, io.Fonts);
            Assert.Equal(default(Vector2F), io.DisplaySize);
            Assert.Equal(default(Vector2F), io.DisplayFramebufferScale);
            Assert.Null(io.KeyMap);
            Assert.Null(io.KeysDown);
            Assert.Null(io.NavInputs);
            Assert.Null(io.MouseDown);
        }
    }
}