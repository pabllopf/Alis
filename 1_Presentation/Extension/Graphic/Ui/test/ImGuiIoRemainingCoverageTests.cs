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
using System.Reflection;
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
            Assert.Equal(0.8f, io.NavInputs[5], 5);
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
            Assert.Equal(0.5f, io.KeysData0.DownDuration, 5);
            Assert.Equal(0.25f, io.KeysData0.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData0.AnalogValue, 5);
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
            Assert.Equal(0.5f, io.KeysData1.DownDuration, 5);
            Assert.Equal(0.25f, io.KeysData1.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData1.AnalogValue, 5);
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
            Assert.Equal(0.5f, io.KeysData100.DownDuration, 5);
            Assert.Equal(0.25f, io.KeysData100.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData100.AnalogValue, 5);
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
            Assert.Equal(0.5f, io.KeysData294.DownDuration, 5);
            Assert.Equal(0.25f, io.KeysData294.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData294.AnalogValue, 5);
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
            Assert.Equal(0.5f, io.KeysData295.DownDuration, 5);
            Assert.Equal(0.25f, io.KeysData295.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData295.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that default state of im gui io has expected zeroed values
        /// </summary>
        [Fact]
        public void DefaultState_HasZeroedValues()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(0f, io.DeltaTime, 5);
            Assert.Equal(0f, io.IniSavingRate, 5);
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

        /// <summary>
        ///     Tests that want capture mouse unless popup close set and get returns correct value
        /// </summary>
        [Fact]
        public void WantCaptureMouseUnlessPopupClose_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.WantCaptureMouseUnlessPopupClose = value;
            Assert.Equal(value, io.WantCaptureMouseUnlessPopupClose);
        }

        /// <summary>
        ///     Tests that mouse pos prev set and get returns correct value
        /// </summary>
        [Fact]
        public void MousePosPrev_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MousePosPrev = value;
            Assert.Equal(value, io.MousePosPrev);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 0 get returns default value
        /// </summary>
        [Fact]
        public void MouseClickedPos0_Get_ReturnsDefaultValue()
        {
            ImGuiIo io = new ImGuiIo();
            Assert.Equal(default(Vector2F), io.MouseClickedPos0);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos1_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseClickedPos1 = value;
            Assert.Equal(value, io.MouseClickedPos1);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 2 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos2_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseClickedPos2 = value;
            Assert.Equal(value, io.MouseClickedPos2);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 3 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos3_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseClickedPos3 = value;
            Assert.Equal(value, io.MouseClickedPos3);
        }

        /// <summary>
        ///     Tests that mouse clicked pos 4 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseClickedPos4_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseClickedPos4 = value;
            Assert.Equal(value, io.MouseClickedPos4);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 0 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs0_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseDragMaxDistanceAbs0 = value;
            Assert.Equal(value, io.MouseDragMaxDistanceAbs0);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs1_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseDragMaxDistanceAbs1 = value;
            Assert.Equal(value, io.MouseDragMaxDistanceAbs1);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 2 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs2_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseDragMaxDistanceAbs2 = value;
            Assert.Equal(value, io.MouseDragMaxDistanceAbs2);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 3 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs3_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseDragMaxDistanceAbs3 = value;
            Assert.Equal(value, io.MouseDragMaxDistanceAbs3);
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs 4 set and get returns correct value
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs4_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            Vector2F value = new Vector2F(2f, 3f);
            io.MouseDragMaxDistanceAbs4 = value;
            Assert.Equal(value, io.MouseDragMaxDistanceAbs4);
        }

        /// <summary>
        ///     Tests that pen pressure set and get returns correct value
        /// </summary>
        [Fact]
        public void PenPressure_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            float value = 0.5f;
            io.PenPressure = value;
            Assert.Equal(value, io.PenPressure);
        }

        /// <summary>
        ///     Tests that app focus lost set and get returns correct value
        /// </summary>
        [Fact]
        public void AppFocusLost_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.AppFocusLost = value;
            Assert.Equal(value, io.AppFocusLost);
        }

        /// <summary>
        ///     Tests that app accepting events set and get returns correct value
        /// </summary>
        [Fact]
        public void AppAcceptingEvents_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.AppAcceptingEvents = value;
            Assert.Equal(value, io.AppAcceptingEvents);
        }

        /// <summary>
        ///     Tests that backend using legacy key arrays set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendUsingLegacyKeyArrays_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            sbyte value = -1;
            io.BackendUsingLegacyKeyArrays = value;
            Assert.Equal(value, io.BackendUsingLegacyKeyArrays);
        }

        /// <summary>
        ///     Tests that backend using legacy nav input array set and get returns correct value
        /// </summary>
        [Fact]
        public void BackendUsingLegacyNavInputArray_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            byte value = 1;
            io.BackendUsingLegacyNavInputArray = value;
            Assert.Equal(value, io.BackendUsingLegacyNavInputArray);
        }

        /// <summary>
        ///     Tests that input queue surrogate set and get returns correct value
        /// </summary>
        [Fact]
        public void InputQueueSurrogate_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ushort value = 42;
            io.InputQueueSurrogate = value;
            Assert.Equal(value, io.InputQueueSurrogate);
        }

        /// <summary>
        ///     Tests that input queue characters set and get returns correct value
        /// </summary>
        [Fact]
        public void InputQueueCharacters_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImVectorG<ushort> value = new ImVectorG<ushort>(1, 2, new IntPtr(123));
            io.InputQueueCharacters = value;
            Assert.Equal(1, io.InputQueueCharacters.Size);
            Assert.Equal(2, io.InputQueueCharacters.Capacity);
            Assert.Equal(new IntPtr(123), io.InputQueueCharacters.Data);
        }

        /// <summary>
        ///     Tests that mouse clicked time array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseClickedTime_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseClickedTime = new double[5];
            io.MouseClickedTime[3] = 1.5;
            Assert.Equal(1.5, io.MouseClickedTime[3], 5);
        }

        /// <summary>
        ///     Tests that mouse clicked array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseClicked_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseClicked = new byte[5];
            io.MouseClicked[1] = 1;
            Assert.Equal(1, io.MouseClicked[1]);
        }

        /// <summary>
        ///     Tests that mouse double clicked array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDoubleClicked_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDoubleClicked = new byte[5];
            io.MouseDoubleClicked[0] = 1;
            Assert.Equal(1, io.MouseDoubleClicked[0]);
        }

        /// <summary>
        ///     Tests that mouse clicked count array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseClickedCount_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseClickedCount = new ushort[5];
            io.MouseClickedCount[2] = 3;
            Assert.Equal(3u, io.MouseClickedCount[2]);
        }

        /// <summary>
        ///     Tests that mouse clicked last count array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseClickedLastCount_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseClickedLastCount = new ushort[5];
            io.MouseClickedLastCount[4] = 7;
            Assert.Equal(7u, io.MouseClickedLastCount[4]);
        }

        /// <summary>
        ///     Tests that mouse released array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseReleased_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseReleased = new byte[5];
            io.MouseReleased[2] = 1;
            Assert.Equal(1, io.MouseReleased[2]);
        }

        /// <summary>
        ///     Tests that mouse down owned array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDownOwned_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDownOwned = new byte[5];
            io.MouseDownOwned[3] = 1;
            Assert.Equal(1, io.MouseDownOwned[3]);
        }

        /// <summary>
        ///     Tests that mouse down owned unless popup close array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDownOwnedUnlessPopupClose_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDownOwnedUnlessPopupClose = new byte[5];
            io.MouseDownOwnedUnlessPopupClose[0] = 1;
            Assert.Equal(1, io.MouseDownOwnedUnlessPopupClose[0]);
        }

        /// <summary>
        ///     Tests that mouse down duration array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDownDuration_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDownDuration = new float[5];
            io.MouseDownDuration[1] = 0.5f;
            Assert.Equal(0.5f, io.MouseDownDuration[1], 5);
        }

        /// <summary>
        ///     Tests that mouse down duration prev array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDownDurationPrev_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDownDurationPrev = new float[5];
            io.MouseDownDurationPrev[2] = 0.3f;
            Assert.Equal(0.3f, io.MouseDownDurationPrev[2], 5);
        }

        /// <summary>
        ///     Tests that mouse drag max distance sqr array round-trips a known element
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceSqr_Array_SetAndGetValue_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            io.MouseDragMaxDistanceSqr = new float[5];
            io.MouseDragMaxDistanceSqr[0] = 10.0f;
            Assert.Equal(10.0f, io.MouseDragMaxDistanceSqr[0], 5);
        }

        /// <summary>
        ///     Tests that all keys data set and get returns correct value via reflection
        /// </summary>
        [Fact]
        public void AllKeysDataSetAndGet_ReturnsCorrectValue()
        {
            object boxed = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 0.5f, DownDurationPrev = 0.25f, AnalogValue = 0.75f };
            System.Type type = typeof(ImGuiIo);
            for (int i = 0; i <= 651; i++)
            {
                if (i == 0 || i == 1 || i == 100 || i == 294 || i == 295)
                {
                    continue;
                }
                PropertyInfo prop = type.GetProperty("KeysData" + i);
                prop.SetValue(boxed, value);
                ImGuiKeyData result = (ImGuiKeyData)prop.GetValue(boxed);
                Assert.Equal((byte)1, result.Down);
                Assert.Equal(0.5f, result.DownDuration, 5);
                Assert.Equal(0.25f, result.DownDurationPrev, 5);
                Assert.Equal(0.75f, result.AnalogValue, 5);
            }
        }
    }
}