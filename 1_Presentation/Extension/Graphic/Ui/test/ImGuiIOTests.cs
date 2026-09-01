// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIOTests.cs
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
    ///     The im gui io tests class
    /// </summary>
    public class ImGuiIOTests
    {
        /// <summary>
        ///     Tests that ConfigFlags set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigFlags_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiConfigFlags value = (ImGuiConfigFlags)1;            io.ConfigFlags = value;            Assert.Equal(value, io.ConfigFlags);        }
        /// <summary>
        ///     Tests that BackendFlags set and get returns correct value
        /// </summary>
        [Fact]        public void BackendFlags_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiBackendFlags value = (ImGuiBackendFlags)2;            io.BackendFlags = value;            Assert.Equal(value, io.BackendFlags);        }
        /// <summary>
        ///     Tests that DisplaySize set and get returns correct value
        /// </summary>
        [Fact]        public void DisplaySize_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(1f, 2f);            io.DisplaySize = value;            Assert.Equal(value, io.DisplaySize);        }
        /// <summary>
        ///     Tests that DeltaTime set and get returns correct value
        /// </summary>
        [Fact]        public void DeltaTime_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 1f;            io.DeltaTime = value;            Assert.Equal(value, io.DeltaTime);        }
        /// <summary>
        ///     Tests that IniSavingRate set and get returns correct value
        /// </summary>
        [Fact]        public void IniSavingRate_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 2f;            io.IniSavingRate = value;            Assert.Equal(value, io.IniSavingRate);        }
        /// <summary>
        ///     Tests that IniFilename set and get returns correct value
        /// </summary>
        [Fact]        public void IniFilename_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(123);            io.IniFilename = value;            Assert.Equal(value, io.IniFilename);        }
        /// <summary>
        ///     Tests that LogFilename set and get returns correct value
        /// </summary>
        [Fact]        public void LogFilename_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(124);            io.LogFilename = value;            Assert.Equal(value, io.LogFilename);        }
        /// <summary>
        ///     Tests that MouseDoubleClickTime set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDoubleClickTime_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 3f;            io.MouseDoubleClickTime = value;            Assert.Equal(value, io.MouseDoubleClickTime);        }
        /// <summary>
        ///     Tests that MouseDoubleClickMaxDist set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDoubleClickMaxDist_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 4f;            io.MouseDoubleClickMaxDist = value;            Assert.Equal(value, io.MouseDoubleClickMaxDist);        }
        /// <summary>
        ///     Tests that MouseDragThreshold set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDragThreshold_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 5f;            io.MouseDragThreshold = value;            Assert.Equal(value, io.MouseDragThreshold);        }
        /// <summary>
        ///     Tests that KeyRepeatDelay set and get returns correct value
        /// </summary>
        [Fact]        public void KeyRepeatDelay_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 6f;            io.KeyRepeatDelay = value;            Assert.Equal(value, io.KeyRepeatDelay);        }
        /// <summary>
        ///     Tests that KeyRepeatRate set and get returns correct value
        /// </summary>
        [Fact]        public void KeyRepeatRate_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 7f;            io.KeyRepeatRate = value;            Assert.Equal(value, io.KeyRepeatRate);        }
        /// <summary>
        ///     Tests that HoverDelayNormal set and get returns correct value
        /// </summary>
        [Fact]        public void HoverDelayNormal_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 8f;            io.HoverDelayNormal = value;            Assert.Equal(value, io.HoverDelayNormal);        }
        /// <summary>
        ///     Tests that HoverDelayShort set and get returns correct value
        /// </summary>
        [Fact]        public void HoverDelayShort_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 9f;            io.HoverDelayShort = value;            Assert.Equal(value, io.HoverDelayShort);        }
        /// <summary>
        ///     Tests that UserData set and get returns correct value
        /// </summary>
        [Fact]        public void UserData_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(125);            io.UserData = value;            Assert.Equal(value, io.UserData);        }
        /// <summary>
        ///     Tests that Fonts set and get returns correct value
        /// </summary>
        [Fact]        public void Fonts_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(126);            io.Fonts = value;            Assert.Equal(value, io.Fonts);        }
        /// <summary>
        ///     Tests that FontGlobalScale set and get returns correct value
        /// </summary>
        [Fact]        public void FontGlobalScale_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 10f;            io.FontGlobalScale = value;            Assert.Equal(value, io.FontGlobalScale);        }
        /// <summary>
        ///     Tests that FontAllowUserScaling set and get returns correct value
        /// </summary>
        [Fact]        public void FontAllowUserScaling_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.FontAllowUserScaling = value;            Assert.Equal(value, io.FontAllowUserScaling);        }
        /// <summary>
        ///     Tests that FontDefault set and get returns correct value
        /// </summary>
        [Fact]        public void FontDefault_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(127);            io.FontDefault = value;            Assert.Equal(value, io.FontDefault);        }
        /// <summary>
        ///     Tests that DisplayFramebufferScale set and get returns correct value
        /// </summary>
        [Fact]        public void DisplayFramebufferScale_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(3f, 4f);            io.DisplayFramebufferScale = value;            Assert.Equal(value, io.DisplayFramebufferScale);        }
        /// <summary>
        ///     Tests that ConfigDockingNoSplit set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigDockingNoSplit_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigDockingNoSplit = value;            Assert.Equal(value, io.ConfigDockingNoSplit);        }
        /// <summary>
        ///     Tests that ConfigDockingWithShift set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigDockingWithShift_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigDockingWithShift = value;            Assert.Equal(value, io.ConfigDockingWithShift);        }
        /// <summary>
        ///     Tests that ConfigDockingAlwaysTabBar set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigDockingAlwaysTabBar_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigDockingAlwaysTabBar = value;            Assert.Equal(value, io.ConfigDockingAlwaysTabBar);        }
        /// <summary>
        ///     Tests that ConfigDockingTransparentPayload set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigDockingTransparentPayload_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigDockingTransparentPayload = value;            Assert.Equal(value, io.ConfigDockingTransparentPayload);        }
        /// <summary>
        ///     Tests that ConfigViewportsNoAutoMerge set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigViewportsNoAutoMerge_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigViewportsNoAutoMerge = value;            Assert.Equal(value, io.ConfigViewportsNoAutoMerge);        }
        /// <summary>
        ///     Tests that ConfigViewportsNoTaskBarIcon set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigViewportsNoTaskBarIcon_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigViewportsNoTaskBarIcon = value;            Assert.Equal(value, io.ConfigViewportsNoTaskBarIcon);        }
        /// <summary>
        ///     Tests that ConfigViewportsNoDecoration set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigViewportsNoDecoration_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigViewportsNoDecoration = value;            Assert.Equal(value, io.ConfigViewportsNoDecoration);        }
        /// <summary>
        ///     Tests that ConfigViewportsNoDefaultParent set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigViewportsNoDefaultParent_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigViewportsNoDefaultParent = value;            Assert.Equal(value, io.ConfigViewportsNoDefaultParent);        }
        /// <summary>
        ///     Tests that MouseDrawCursor set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDrawCursor_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.MouseDrawCursor = value;            Assert.Equal(value, io.MouseDrawCursor);        }
        /// <summary>
        ///     Tests that ConfigMacOsxBehaviors set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigMacOsxBehaviors_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigMacOsxBehaviors = value;            Assert.Equal(value, io.ConfigMacOsxBehaviors);        }
        /// <summary>
        ///     Tests that ConfigInputTrickleEventQueue set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigInputTrickleEventQueue_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigInputTrickleEventQueue = value;            Assert.Equal(value, io.ConfigInputTrickleEventQueue);        }
        /// <summary>
        ///     Tests that ConfigInputTextCursorBlink set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigInputTextCursorBlink_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigInputTextCursorBlink = value;            Assert.Equal(value, io.ConfigInputTextCursorBlink);        }
        /// <summary>
        ///     Tests that ConfigInputTextEnterKeepActive set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigInputTextEnterKeepActive_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigInputTextEnterKeepActive = value;            Assert.Equal(value, io.ConfigInputTextEnterKeepActive);        }
        /// <summary>
        ///     Tests that ConfigDragClickToInputText set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigDragClickToInputText_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigDragClickToInputText = value;            Assert.Equal(value, io.ConfigDragClickToInputText);        }
        /// <summary>
        ///     Tests that ConfigWindowsResizeFromEdges set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigWindowsResizeFromEdges_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigWindowsResizeFromEdges = value;            Assert.Equal(value, io.ConfigWindowsResizeFromEdges);        }
        /// <summary>
        ///     Tests that ConfigWindowsMoveFromTitleBarOnly set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigWindowsMoveFromTitleBarOnly_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.ConfigWindowsMoveFromTitleBarOnly = value;            Assert.Equal(value, io.ConfigWindowsMoveFromTitleBarOnly);        }
        /// <summary>
        ///     Tests that ConfigMemoryCompactTimer set and get returns correct value
        /// </summary>
        [Fact]        public void ConfigMemoryCompactTimer_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 11f;            io.ConfigMemoryCompactTimer = value;            Assert.Equal(value, io.ConfigMemoryCompactTimer);        }
        /// <summary>
        ///     Tests that BackendPlatformName set and get returns correct value
        /// </summary>
        [Fact]        public void BackendPlatformName_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(128);            io.BackendPlatformName = value;            Assert.Equal(value, io.BackendPlatformName);        }
        /// <summary>
        ///     Tests that BackendRendererName set and get returns correct value
        /// </summary>
        [Fact]        public void BackendRendererName_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(129);            io.BackendRendererName = value;            Assert.Equal(value, io.BackendRendererName);        }
        /// <summary>
        ///     Tests that BackendPlatformUserData set and get returns correct value
        /// </summary>
        [Fact]        public void BackendPlatformUserData_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(130);            io.BackendPlatformUserData = value;            Assert.Equal(value, io.BackendPlatformUserData);        }
        /// <summary>
        ///     Tests that BackendRendererUserData set and get returns correct value
        /// </summary>
        [Fact]        public void BackendRendererUserData_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(131);            io.BackendRendererUserData = value;            Assert.Equal(value, io.BackendRendererUserData);        }
        /// <summary>
        ///     Tests that BackendLanguageUserData set and get returns correct value
        /// </summary>
        [Fact]        public void BackendLanguageUserData_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(132);            io.BackendLanguageUserData = value;            Assert.Equal(value, io.BackendLanguageUserData);        }
        /// <summary>
        ///     Tests that GetClipboardTextFn set and get returns correct value
        /// </summary>
        [Fact]        public void GetClipboardTextFn_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(133);            io.GetClipboardTextFn = value;            Assert.Equal(value, io.GetClipboardTextFn);        }
        /// <summary>
        ///     Tests that SetClipboardTextFn set and get returns correct value
        /// </summary>
        [Fact]        public void SetClipboardTextFn_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(134);            io.SetClipboardTextFn = value;            Assert.Equal(value, io.SetClipboardTextFn);        }
        /// <summary>
        ///     Tests that ClipboardUserData set and get returns correct value
        /// </summary>
        [Fact]        public void ClipboardUserData_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(135);            io.ClipboardUserData = value;            Assert.Equal(value, io.ClipboardUserData);        }
        /// <summary>
        ///     Tests that SetPlatformImeDataFn set and get returns correct value
        /// </summary>
        [Fact]        public void SetPlatformImeDataFn_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(136);            io.SetPlatformImeDataFn = value;            Assert.Equal(value, io.SetPlatformImeDataFn);        }
        /// <summary>
        ///     Tests that UnusedPadding set and get returns correct value
        /// </summary>
        [Fact]        public void UnusedPadding_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            IntPtr value = new IntPtr(137);            io.UnusedPadding = value;            Assert.Equal(value, io.UnusedPadding);        }
        /// <summary>
        ///     Tests that WantCaptureMouse set and get returns correct value
        /// </summary>
        [Fact]        public void WantCaptureMouse_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.WantCaptureMouse = value;            Assert.Equal(value, io.WantCaptureMouse);        }
        /// <summary>
        ///     Tests that WantCaptureKeyboard set and get returns correct value
        /// </summary>
        [Fact]        public void WantCaptureKeyboard_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.WantCaptureKeyboard = value;            Assert.Equal(value, io.WantCaptureKeyboard);        }
        /// <summary>
        ///     Tests that WantTextInput set and get returns correct value
        /// </summary>
        [Fact]        public void WantTextInput_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.WantTextInput = value;            Assert.Equal(value, io.WantTextInput);        }
        /// <summary>
        ///     Tests that WantSetMousePos set and get returns correct value
        /// </summary>
        [Fact]        public void WantSetMousePos_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.WantSetMousePos = value;            Assert.Equal(value, io.WantSetMousePos);        }
        /// <summary>
        ///     Tests that WantSaveIniSettings set and get returns correct value
        /// </summary>
        [Fact]        public void WantSaveIniSettings_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.WantSaveIniSettings = value;            Assert.Equal(value, io.WantSaveIniSettings);        }
        /// <summary>
        ///     Tests that NavActive set and get returns correct value
        /// </summary>
        [Fact]        public void NavActive_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.NavActive = value;            Assert.Equal(value, io.NavActive);        }
        /// <summary>
        ///     Tests that NavVisible set and get returns correct value
        /// </summary>
        [Fact]        public void NavVisible_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.NavVisible = value;            Assert.Equal(value, io.NavVisible);        }
        /// <summary>
        ///     Tests that Framerate set and get returns correct value
        /// </summary>
        [Fact]        public void Framerate_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 12f;            io.Framerate = value;            Assert.Equal(value, io.Framerate);        }
        /// <summary>
        ///     Tests that MetricsRenderVertices set and get returns correct value
        /// </summary>
        [Fact]        public void MetricsRenderVertices_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            int value = 42;            io.MetricsRenderVertices = value;            Assert.Equal(value, io.MetricsRenderVertices);        }
        /// <summary>
        ///     Tests that MetricsRenderIndices set and get returns correct value
        /// </summary>
        [Fact]        public void MetricsRenderIndices_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            int value = 43;            io.MetricsRenderIndices = value;            Assert.Equal(value, io.MetricsRenderIndices);        }
        /// <summary>
        ///     Tests that MetricsRenderWindows set and get returns correct value
        /// </summary>
        [Fact]        public void MetricsRenderWindows_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            int value = 44;            io.MetricsRenderWindows = value;            Assert.Equal(value, io.MetricsRenderWindows);        }
        /// <summary>
        ///     Tests that MetricsActiveWindows set and get returns correct value
        /// </summary>
        [Fact]        public void MetricsActiveWindows_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            int value = 45;            io.MetricsActiveWindows = value;            Assert.Equal(value, io.MetricsActiveWindows);        }
        /// <summary>
        ///     Tests that MetricsActiveAllocations set and get returns correct value
        /// </summary>
        [Fact]        public void MetricsActiveAllocations_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            int value = 46;            io.MetricsActiveAllocations = value;            Assert.Equal(value, io.MetricsActiveAllocations);        }
        /// <summary>
        ///     Tests that MouseDelta set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDelta_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(5f, 6f);            io.MouseDelta = value;            Assert.Equal(value, io.MouseDelta);        }
        /// <summary>
        ///     Tests that MousePos set and get returns correct value
        /// </summary>
        [Fact]        public void MousePos_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(7f, 8f);            io.MousePos = value;            Assert.Equal(value, io.MousePos);        }
        /// <summary>
        ///     Tests that MouseWheel set and get returns correct value
        /// </summary>
        [Fact]        public void MouseWheel_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 13f;            io.MouseWheel = value;            Assert.Equal(value, io.MouseWheel);        }
        /// <summary>
        ///     Tests that MouseWheelH set and get returns correct value
        /// </summary>
        [Fact]        public void MouseWheelH_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 14f;            io.MouseWheelH = value;            Assert.Equal(value, io.MouseWheelH);        }
        /// <summary>
        ///     Tests that MouseHoveredViewport set and get returns correct value
        /// </summary>
        [Fact]        public void MouseHoveredViewport_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            uint value = 25u;            io.MouseHoveredViewport = value;            Assert.Equal(value, io.MouseHoveredViewport);        }
        /// <summary>
        ///     Tests that KeyCtrl set and get returns correct value
        /// </summary>
        [Fact]        public void KeyCtrl_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.KeyCtrl = value;            Assert.Equal(value, io.KeyCtrl);        }
        /// <summary>
        ///     Tests that KeyShift set and get returns correct value
        /// </summary>
        [Fact]        public void KeyShift_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.KeyShift = value;            Assert.Equal(value, io.KeyShift);        }
        /// <summary>
        ///     Tests that KeyAlt set and get returns correct value
        /// </summary>
        [Fact]        public void KeyAlt_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.KeyAlt = value;            Assert.Equal(value, io.KeyAlt);        }
        /// <summary>
        ///     Tests that KeySuper set and get returns correct value
        /// </summary>
        [Fact]        public void KeySuper_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.KeySuper = value;            Assert.Equal(value, io.KeySuper);        }
        /// <summary>
        ///     Tests that KeyMods set and get returns correct value
        /// </summary>
        [Fact]        public void KeyMods_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKey value = (ImGuiKey)1;            io.KeyMods = value;            Assert.Equal(value, io.KeyMods);        }
        /// <summary>
        ///     Tests that WantCaptureMouseUnlessPopupClose set and get returns correct value
        /// </summary>
        [Fact]        public void WantCaptureMouseUnlessPopupClose_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.WantCaptureMouseUnlessPopupClose = value;            Assert.Equal(value, io.WantCaptureMouseUnlessPopupClose);        }
        /// <summary>
        ///     Tests that MousePosPrev set and get returns correct value
        /// </summary>
        [Fact]        public void MousePosPrev_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(9f, 10f);            io.MousePosPrev = value;            Assert.Equal(value, io.MousePosPrev);        }
        /// <summary>
        ///     Tests that MouseClickedPos1 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseClickedPos1_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(11f, 12f);            io.MouseClickedPos1 = value;            Assert.Equal(value, io.MouseClickedPos1);        }
        /// <summary>
        ///     Tests that MouseClickedPos2 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseClickedPos2_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(13f, 14f);            io.MouseClickedPos2 = value;            Assert.Equal(value, io.MouseClickedPos2);        }
        /// <summary>
        ///     Tests that MouseClickedPos3 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseClickedPos3_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(15f, 16f);            io.MouseClickedPos3 = value;            Assert.Equal(value, io.MouseClickedPos3);        }
        /// <summary>
        ///     Tests that MouseClickedPos4 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseClickedPos4_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(17f, 18f);            io.MouseClickedPos4 = value;            Assert.Equal(value, io.MouseClickedPos4);        }
        /// <summary>
        ///     Tests that MouseDragMaxDistanceAbs0 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDragMaxDistanceAbs0_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(19f, 20f);            io.MouseDragMaxDistanceAbs0 = value;            Assert.Equal(value, io.MouseDragMaxDistanceAbs0);        }
        /// <summary>
        ///     Tests that MouseDragMaxDistanceAbs1 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDragMaxDistanceAbs1_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(21f, 22f);            io.MouseDragMaxDistanceAbs1 = value;            Assert.Equal(value, io.MouseDragMaxDistanceAbs1);        }
        /// <summary>
        ///     Tests that MouseDragMaxDistanceAbs2 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDragMaxDistanceAbs2_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(23f, 24f);            io.MouseDragMaxDistanceAbs2 = value;            Assert.Equal(value, io.MouseDragMaxDistanceAbs2);        }
        /// <summary>
        ///     Tests that MouseDragMaxDistanceAbs3 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDragMaxDistanceAbs3_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(25f, 26f);            io.MouseDragMaxDistanceAbs3 = value;            Assert.Equal(value, io.MouseDragMaxDistanceAbs3);        }
        /// <summary>
        ///     Tests that MouseDragMaxDistanceAbs4 set and get returns correct value
        /// </summary>
        [Fact]        public void MouseDragMaxDistanceAbs4_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            Vector2F value = new Vector2F(27f, 28f);            io.MouseDragMaxDistanceAbs4 = value;            Assert.Equal(value, io.MouseDragMaxDistanceAbs4);        }
        /// <summary>
        ///     Tests that PenPressure set and get returns correct value
        /// </summary>
        [Fact]        public void PenPressure_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            float value = 15f;            io.PenPressure = value;            Assert.Equal(value, io.PenPressure);        }
        /// <summary>
        ///     Tests that AppFocusLost set and get returns correct value
        /// </summary>
        [Fact]        public void AppFocusLost_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.AppFocusLost = value;            Assert.Equal(value, io.AppFocusLost);        }
        /// <summary>
        ///     Tests that AppAcceptingEvents set and get returns correct value
        /// </summary>
        [Fact]        public void AppAcceptingEvents_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.AppAcceptingEvents = value;            Assert.Equal(value, io.AppAcceptingEvents);        }
        /// <summary>
        ///     Tests that BackendUsingLegacyKeyArrays set and get returns correct value
        /// </summary>
        [Fact]        public void BackendUsingLegacyKeyArrays_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            sbyte value = (sbyte)1;            io.BackendUsingLegacyKeyArrays = value;            Assert.Equal(value, io.BackendUsingLegacyKeyArrays);        }
        /// <summary>
        ///     Tests that BackendUsingLegacyNavInputArray set and get returns correct value
        /// </summary>
        [Fact]        public void BackendUsingLegacyNavInputArray_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            byte value = (byte)1;            io.BackendUsingLegacyNavInputArray = value;            Assert.Equal(value, io.BackendUsingLegacyNavInputArray);        }
        /// <summary>
        ///     Tests that InputQueueSurrogate set and get returns correct value
        /// </summary>
        [Fact]        public void InputQueueSurrogate_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ushort value = (ushort)25;            io.InputQueueSurrogate = value;            Assert.Equal(value, io.InputQueueSurrogate);        }
        /// <summary>
        ///     Tests that InputQueueCharacters set and get returns correct value
        /// </summary>
        [Fact]        public void InputQueueCharacters_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImVectorG<ushort> value = new ImVectorG<ushort>(3, 5, IntPtr.Zero);            io.InputQueueCharacters = value;            Assert.Equal(value, io.InputQueueCharacters);        }
        /// <summary>
        ///     Tests that mouse clicked pos 0 returns default value
        /// </summary>
        [Fact]        public void MouseClickedPos0_Get_ReturnsDefaultValue()        {            ImGuiIo io = new ImGuiIo();            Assert.Equal(default(Vector2F), io.MouseClickedPos0);        }
        /// <summary>
        ///     Tests that KeyMap set and get returns correct size
        /// </summary>
        [Fact]        public void KeyMap_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            int[] value = new int[652];            io.KeyMap = value;            Assert.Equal(652, io.KeyMap.Length);        }
        /// <summary>
        ///     Tests that KeysDown set and get returns correct size
        /// </summary>
        [Fact]        public void KeysDown_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[652];            io.KeysDown = value;            Assert.Equal(652, io.KeysDown.Length);        }
        /// <summary>
        ///     Tests that NavInputs set and get returns correct size
        /// </summary>
        [Fact]        public void NavInputs_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            float[] value = new float[16];            io.NavInputs = value;            Assert.Equal(16, io.NavInputs.Length);        }
        /// <summary>
        ///     Tests that MouseDown set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDown_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[5];            io.MouseDown = value;            Assert.Equal(5, io.MouseDown.Length);        }
        /// <summary>
        ///     Tests that MouseClickedTime set and get returns correct size
        /// </summary>
        [Fact]        public void MouseClickedTime_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            double[] value = new double[5];            io.MouseClickedTime = value;            Assert.Equal(5, io.MouseClickedTime.Length);        }
        /// <summary>
        ///     Tests that MouseClicked set and get returns correct size
        /// </summary>
        [Fact]        public void MouseClicked_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[5];            io.MouseClicked = value;            Assert.Equal(5, io.MouseClicked.Length);        }
        /// <summary>
        ///     Tests that MouseDoubleClicked set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDoubleClicked_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[5];            io.MouseDoubleClicked = value;            Assert.Equal(5, io.MouseDoubleClicked.Length);        }
        /// <summary>
        ///     Tests that MouseClickedCount set and get returns correct size
        /// </summary>
        [Fact]        public void MouseClickedCount_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            ushort[] value = new ushort[5];            io.MouseClickedCount = value;            Assert.Equal(5, io.MouseClickedCount.Length);        }
        /// <summary>
        ///     Tests that MouseClickedLastCount set and get returns correct size
        /// </summary>
        [Fact]        public void MouseClickedLastCount_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            ushort[] value = new ushort[5];            io.MouseClickedLastCount = value;            Assert.Equal(5, io.MouseClickedLastCount.Length);        }
        /// <summary>
        ///     Tests that MouseReleased set and get returns correct size
        /// </summary>
        [Fact]        public void MouseReleased_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[5];            io.MouseReleased = value;            Assert.Equal(5, io.MouseReleased.Length);        }
        /// <summary>
        ///     Tests that MouseDownOwned set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDownOwned_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[5];            io.MouseDownOwned = value;            Assert.Equal(5, io.MouseDownOwned.Length);        }
        /// <summary>
        ///     Tests that MouseDownOwnedUnlessPopupClose set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDownOwnedUnlessPopupClose_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            byte[] value = new byte[5];            io.MouseDownOwnedUnlessPopupClose = value;            Assert.Equal(5, io.MouseDownOwnedUnlessPopupClose.Length);        }
        /// <summary>
        ///     Tests that MouseDownDuration set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDownDuration_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            float[] value = new float[5];            io.MouseDownDuration = value;            Assert.Equal(5, io.MouseDownDuration.Length);        }
        /// <summary>
        ///     Tests that MouseDownDurationPrev set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDownDurationPrev_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            float[] value = new float[5];            io.MouseDownDurationPrev = value;            Assert.Equal(5, io.MouseDownDurationPrev.Length);        }
        /// <summary>
        ///     Tests that MouseDragMaxDistanceSqr set and get returns correct size
        /// </summary>
        [Fact]        public void MouseDragMaxDistanceSqr_SetAndGet_ReturnsCorrectSize()        {            ImGuiIo io = new ImGuiIo();            float[] value = new float[5];            io.MouseDragMaxDistanceSqr = value;            Assert.Equal(5, io.MouseDragMaxDistanceSqr.Length);        }
        /// <summary>
        ///     Tests that keys data 0 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData0_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData0 = value;            Assert.Equal((byte)1, io.KeysData0.Down);            Assert.Equal(2.5f, io.KeysData0.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 1 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData1_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData1 = value;            Assert.Equal((byte)1, io.KeysData1.Down);            Assert.Equal(2.5f, io.KeysData1.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 2 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData2_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData2 = value;            Assert.Equal((byte)1, io.KeysData2.Down);            Assert.Equal(2.5f, io.KeysData2.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 3 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData3_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData3 = value;            Assert.Equal((byte)1, io.KeysData3.Down);            Assert.Equal(2.5f, io.KeysData3.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 4 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData4_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData4 = value;            Assert.Equal((byte)1, io.KeysData4.Down);            Assert.Equal(2.5f, io.KeysData4.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 5 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData5_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData5 = value;            Assert.Equal((byte)1, io.KeysData5.Down);            Assert.Equal(2.5f, io.KeysData5.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 6 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData6_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData6 = value;            Assert.Equal((byte)1, io.KeysData6.Down);            Assert.Equal(2.5f, io.KeysData6.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 7 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData7_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData7 = value;            Assert.Equal((byte)1, io.KeysData7.Down);            Assert.Equal(2.5f, io.KeysData7.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 8 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData8_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData8 = value;            Assert.Equal((byte)1, io.KeysData8.Down);            Assert.Equal(2.5f, io.KeysData8.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 9 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData9_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData9 = value;            Assert.Equal((byte)1, io.KeysData9.Down);            Assert.Equal(2.5f, io.KeysData9.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 10 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData10_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData10 = value;            Assert.Equal((byte)1, io.KeysData10.Down);            Assert.Equal(2.5f, io.KeysData10.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 11 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData11_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData11 = value;            Assert.Equal((byte)1, io.KeysData11.Down);            Assert.Equal(2.5f, io.KeysData11.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 12 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData12_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData12 = value;            Assert.Equal((byte)1, io.KeysData12.Down);            Assert.Equal(2.5f, io.KeysData12.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 13 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData13_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData13 = value;            Assert.Equal((byte)1, io.KeysData13.Down);            Assert.Equal(2.5f, io.KeysData13.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 14 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData14_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData14 = value;            Assert.Equal((byte)1, io.KeysData14.Down);            Assert.Equal(2.5f, io.KeysData14.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 15 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData15_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData15 = value;            Assert.Equal((byte)1, io.KeysData15.Down);            Assert.Equal(2.5f, io.KeysData15.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 16 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData16_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData16 = value;            Assert.Equal((byte)1, io.KeysData16.Down);            Assert.Equal(2.5f, io.KeysData16.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 17 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData17_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData17 = value;            Assert.Equal((byte)1, io.KeysData17.Down);            Assert.Equal(2.5f, io.KeysData17.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 18 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData18_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData18 = value;            Assert.Equal((byte)1, io.KeysData18.Down);            Assert.Equal(2.5f, io.KeysData18.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 19 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData19_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData19 = value;            Assert.Equal((byte)1, io.KeysData19.Down);            Assert.Equal(2.5f, io.KeysData19.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 20 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData20_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData20 = value;            Assert.Equal((byte)1, io.KeysData20.Down);            Assert.Equal(2.5f, io.KeysData20.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 21 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData21_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData21 = value;            Assert.Equal((byte)1, io.KeysData21.Down);            Assert.Equal(2.5f, io.KeysData21.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 22 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData22_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData22 = value;            Assert.Equal((byte)1, io.KeysData22.Down);            Assert.Equal(2.5f, io.KeysData22.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 23 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData23_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData23 = value;            Assert.Equal((byte)1, io.KeysData23.Down);            Assert.Equal(2.5f, io.KeysData23.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 24 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData24_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData24 = value;            Assert.Equal((byte)1, io.KeysData24.Down);            Assert.Equal(2.5f, io.KeysData24.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 25 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData25_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData25 = value;            Assert.Equal((byte)1, io.KeysData25.Down);            Assert.Equal(2.5f, io.KeysData25.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 26 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData26_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData26 = value;            Assert.Equal((byte)1, io.KeysData26.Down);            Assert.Equal(2.5f, io.KeysData26.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 27 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData27_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData27 = value;            Assert.Equal((byte)1, io.KeysData27.Down);            Assert.Equal(2.5f, io.KeysData27.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 28 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData28_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData28 = value;            Assert.Equal((byte)1, io.KeysData28.Down);            Assert.Equal(2.5f, io.KeysData28.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 29 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData29_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData29 = value;            Assert.Equal((byte)1, io.KeysData29.Down);            Assert.Equal(2.5f, io.KeysData29.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 30 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData30_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData30 = value;            Assert.Equal((byte)1, io.KeysData30.Down);            Assert.Equal(2.5f, io.KeysData30.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 31 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData31_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData31 = value;            Assert.Equal((byte)1, io.KeysData31.Down);            Assert.Equal(2.5f, io.KeysData31.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 32 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData32_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData32 = value;            Assert.Equal((byte)1, io.KeysData32.Down);            Assert.Equal(2.5f, io.KeysData32.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 33 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData33_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData33 = value;            Assert.Equal((byte)1, io.KeysData33.Down);            Assert.Equal(2.5f, io.KeysData33.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 34 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData34_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData34 = value;            Assert.Equal((byte)1, io.KeysData34.Down);            Assert.Equal(2.5f, io.KeysData34.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 35 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData35_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData35 = value;            Assert.Equal((byte)1, io.KeysData35.Down);            Assert.Equal(2.5f, io.KeysData35.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 36 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData36_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData36 = value;            Assert.Equal((byte)1, io.KeysData36.Down);            Assert.Equal(2.5f, io.KeysData36.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 37 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData37_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData37 = value;            Assert.Equal((byte)1, io.KeysData37.Down);            Assert.Equal(2.5f, io.KeysData37.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 38 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData38_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData38 = value;            Assert.Equal((byte)1, io.KeysData38.Down);            Assert.Equal(2.5f, io.KeysData38.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 39 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData39_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData39 = value;            Assert.Equal((byte)1, io.KeysData39.Down);            Assert.Equal(2.5f, io.KeysData39.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 40 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData40_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData40 = value;            Assert.Equal((byte)1, io.KeysData40.Down);            Assert.Equal(2.5f, io.KeysData40.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 41 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData41_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData41 = value;            Assert.Equal((byte)1, io.KeysData41.Down);            Assert.Equal(2.5f, io.KeysData41.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 42 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData42_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData42 = value;            Assert.Equal((byte)1, io.KeysData42.Down);            Assert.Equal(2.5f, io.KeysData42.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 43 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData43_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData43 = value;            Assert.Equal((byte)1, io.KeysData43.Down);            Assert.Equal(2.5f, io.KeysData43.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 44 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData44_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData44 = value;            Assert.Equal((byte)1, io.KeysData44.Down);            Assert.Equal(2.5f, io.KeysData44.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 45 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData45_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData45 = value;            Assert.Equal((byte)1, io.KeysData45.Down);            Assert.Equal(2.5f, io.KeysData45.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 46 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData46_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData46 = value;            Assert.Equal((byte)1, io.KeysData46.Down);            Assert.Equal(2.5f, io.KeysData46.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 47 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData47_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData47 = value;            Assert.Equal((byte)1, io.KeysData47.Down);            Assert.Equal(2.5f, io.KeysData47.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 48 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData48_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData48 = value;            Assert.Equal((byte)1, io.KeysData48.Down);            Assert.Equal(2.5f, io.KeysData48.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 49 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData49_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData49 = value;            Assert.Equal((byte)1, io.KeysData49.Down);            Assert.Equal(2.5f, io.KeysData49.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 50 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData50_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData50 = value;            Assert.Equal((byte)1, io.KeysData50.Down);            Assert.Equal(2.5f, io.KeysData50.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 51 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData51_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData51 = value;            Assert.Equal((byte)1, io.KeysData51.Down);            Assert.Equal(2.5f, io.KeysData51.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 52 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData52_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData52 = value;            Assert.Equal((byte)1, io.KeysData52.Down);            Assert.Equal(2.5f, io.KeysData52.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 53 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData53_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData53 = value;            Assert.Equal((byte)1, io.KeysData53.Down);            Assert.Equal(2.5f, io.KeysData53.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 54 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData54_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData54 = value;            Assert.Equal((byte)1, io.KeysData54.Down);            Assert.Equal(2.5f, io.KeysData54.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 55 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData55_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData55 = value;            Assert.Equal((byte)1, io.KeysData55.Down);            Assert.Equal(2.5f, io.KeysData55.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 56 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData56_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData56 = value;            Assert.Equal((byte)1, io.KeysData56.Down);            Assert.Equal(2.5f, io.KeysData56.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 57 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData57_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData57 = value;            Assert.Equal((byte)1, io.KeysData57.Down);            Assert.Equal(2.5f, io.KeysData57.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 58 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData58_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData58 = value;            Assert.Equal((byte)1, io.KeysData58.Down);            Assert.Equal(2.5f, io.KeysData58.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 59 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData59_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData59 = value;            Assert.Equal((byte)1, io.KeysData59.Down);            Assert.Equal(2.5f, io.KeysData59.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 60 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData60_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData60 = value;            Assert.Equal((byte)1, io.KeysData60.Down);            Assert.Equal(2.5f, io.KeysData60.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 61 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData61_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData61 = value;            Assert.Equal((byte)1, io.KeysData61.Down);            Assert.Equal(2.5f, io.KeysData61.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 62 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData62_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData62 = value;            Assert.Equal((byte)1, io.KeysData62.Down);            Assert.Equal(2.5f, io.KeysData62.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 63 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData63_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData63 = value;            Assert.Equal((byte)1, io.KeysData63.Down);            Assert.Equal(2.5f, io.KeysData63.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 64 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData64_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData64 = value;            Assert.Equal((byte)1, io.KeysData64.Down);            Assert.Equal(2.5f, io.KeysData64.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 65 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData65_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData65 = value;            Assert.Equal((byte)1, io.KeysData65.Down);            Assert.Equal(2.5f, io.KeysData65.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 66 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData66_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData66 = value;            Assert.Equal((byte)1, io.KeysData66.Down);            Assert.Equal(2.5f, io.KeysData66.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 67 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData67_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData67 = value;            Assert.Equal((byte)1, io.KeysData67.Down);            Assert.Equal(2.5f, io.KeysData67.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 68 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData68_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData68 = value;            Assert.Equal((byte)1, io.KeysData68.Down);            Assert.Equal(2.5f, io.KeysData68.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 69 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData69_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData69 = value;            Assert.Equal((byte)1, io.KeysData69.Down);            Assert.Equal(2.5f, io.KeysData69.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 70 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData70_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData70 = value;            Assert.Equal((byte)1, io.KeysData70.Down);            Assert.Equal(2.5f, io.KeysData70.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 71 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData71_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData71 = value;            Assert.Equal((byte)1, io.KeysData71.Down);            Assert.Equal(2.5f, io.KeysData71.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 72 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData72_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData72 = value;            Assert.Equal((byte)1, io.KeysData72.Down);            Assert.Equal(2.5f, io.KeysData72.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 73 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData73_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData73 = value;            Assert.Equal((byte)1, io.KeysData73.Down);            Assert.Equal(2.5f, io.KeysData73.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 74 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData74_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData74 = value;            Assert.Equal((byte)1, io.KeysData74.Down);            Assert.Equal(2.5f, io.KeysData74.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 75 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData75_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData75 = value;            Assert.Equal((byte)1, io.KeysData75.Down);            Assert.Equal(2.5f, io.KeysData75.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 76 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData76_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData76 = value;            Assert.Equal((byte)1, io.KeysData76.Down);            Assert.Equal(2.5f, io.KeysData76.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 77 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData77_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData77 = value;            Assert.Equal((byte)1, io.KeysData77.Down);            Assert.Equal(2.5f, io.KeysData77.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 78 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData78_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData78 = value;            Assert.Equal((byte)1, io.KeysData78.Down);            Assert.Equal(2.5f, io.KeysData78.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 79 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData79_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData79 = value;            Assert.Equal((byte)1, io.KeysData79.Down);            Assert.Equal(2.5f, io.KeysData79.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 80 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData80_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData80 = value;            Assert.Equal((byte)1, io.KeysData80.Down);            Assert.Equal(2.5f, io.KeysData80.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 81 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData81_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData81 = value;            Assert.Equal((byte)1, io.KeysData81.Down);            Assert.Equal(2.5f, io.KeysData81.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 82 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData82_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData82 = value;            Assert.Equal((byte)1, io.KeysData82.Down);            Assert.Equal(2.5f, io.KeysData82.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 83 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData83_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData83 = value;            Assert.Equal((byte)1, io.KeysData83.Down);            Assert.Equal(2.5f, io.KeysData83.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 84 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData84_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData84 = value;            Assert.Equal((byte)1, io.KeysData84.Down);            Assert.Equal(2.5f, io.KeysData84.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 85 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData85_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData85 = value;            Assert.Equal((byte)1, io.KeysData85.Down);            Assert.Equal(2.5f, io.KeysData85.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 86 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData86_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData86 = value;            Assert.Equal((byte)1, io.KeysData86.Down);            Assert.Equal(2.5f, io.KeysData86.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 87 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData87_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData87 = value;            Assert.Equal((byte)1, io.KeysData87.Down);            Assert.Equal(2.5f, io.KeysData87.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 88 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData88_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData88 = value;            Assert.Equal((byte)1, io.KeysData88.Down);            Assert.Equal(2.5f, io.KeysData88.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 89 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData89_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData89 = value;            Assert.Equal((byte)1, io.KeysData89.Down);            Assert.Equal(2.5f, io.KeysData89.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 90 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData90_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData90 = value;            Assert.Equal((byte)1, io.KeysData90.Down);            Assert.Equal(2.5f, io.KeysData90.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 91 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData91_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData91 = value;            Assert.Equal((byte)1, io.KeysData91.Down);            Assert.Equal(2.5f, io.KeysData91.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 92 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData92_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData92 = value;            Assert.Equal((byte)1, io.KeysData92.Down);            Assert.Equal(2.5f, io.KeysData92.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 93 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData93_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData93 = value;            Assert.Equal((byte)1, io.KeysData93.Down);            Assert.Equal(2.5f, io.KeysData93.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 94 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData94_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData94 = value;            Assert.Equal((byte)1, io.KeysData94.Down);            Assert.Equal(2.5f, io.KeysData94.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 95 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData95_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData95 = value;            Assert.Equal((byte)1, io.KeysData95.Down);            Assert.Equal(2.5f, io.KeysData95.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 96 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData96_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData96 = value;            Assert.Equal((byte)1, io.KeysData96.Down);            Assert.Equal(2.5f, io.KeysData96.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 97 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData97_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData97 = value;            Assert.Equal((byte)1, io.KeysData97.Down);            Assert.Equal(2.5f, io.KeysData97.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 98 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData98_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData98 = value;            Assert.Equal((byte)1, io.KeysData98.Down);            Assert.Equal(2.5f, io.KeysData98.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 99 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData99_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData99 = value;            Assert.Equal((byte)1, io.KeysData99.Down);            Assert.Equal(2.5f, io.KeysData99.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 100 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData100_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData100 = value;            Assert.Equal((byte)1, io.KeysData100.Down);            Assert.Equal(2.5f, io.KeysData100.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 101 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData101_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData101 = value;            Assert.Equal((byte)1, io.KeysData101.Down);            Assert.Equal(2.5f, io.KeysData101.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 102 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData102_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData102 = value;            Assert.Equal((byte)1, io.KeysData102.Down);            Assert.Equal(2.5f, io.KeysData102.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 103 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData103_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData103 = value;            Assert.Equal((byte)1, io.KeysData103.Down);            Assert.Equal(2.5f, io.KeysData103.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 104 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData104_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData104 = value;            Assert.Equal((byte)1, io.KeysData104.Down);            Assert.Equal(2.5f, io.KeysData104.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 105 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData105_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData105 = value;            Assert.Equal((byte)1, io.KeysData105.Down);            Assert.Equal(2.5f, io.KeysData105.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 106 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData106_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData106 = value;            Assert.Equal((byte)1, io.KeysData106.Down);            Assert.Equal(2.5f, io.KeysData106.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 107 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData107_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData107 = value;            Assert.Equal((byte)1, io.KeysData107.Down);            Assert.Equal(2.5f, io.KeysData107.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 108 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData108_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData108 = value;            Assert.Equal((byte)1, io.KeysData108.Down);            Assert.Equal(2.5f, io.KeysData108.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 109 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData109_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData109 = value;            Assert.Equal((byte)1, io.KeysData109.Down);            Assert.Equal(2.5f, io.KeysData109.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 110 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData110_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData110 = value;            Assert.Equal((byte)1, io.KeysData110.Down);            Assert.Equal(2.5f, io.KeysData110.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 111 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData111_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData111 = value;            Assert.Equal((byte)1, io.KeysData111.Down);            Assert.Equal(2.5f, io.KeysData111.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 112 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData112_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData112 = value;            Assert.Equal((byte)1, io.KeysData112.Down);            Assert.Equal(2.5f, io.KeysData112.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 113 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData113_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData113 = value;            Assert.Equal((byte)1, io.KeysData113.Down);            Assert.Equal(2.5f, io.KeysData113.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 114 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData114_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData114 = value;            Assert.Equal((byte)1, io.KeysData114.Down);            Assert.Equal(2.5f, io.KeysData114.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 115 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData115_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData115 = value;            Assert.Equal((byte)1, io.KeysData115.Down);            Assert.Equal(2.5f, io.KeysData115.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 116 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData116_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData116 = value;            Assert.Equal((byte)1, io.KeysData116.Down);            Assert.Equal(2.5f, io.KeysData116.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 117 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData117_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData117 = value;            Assert.Equal((byte)1, io.KeysData117.Down);            Assert.Equal(2.5f, io.KeysData117.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 118 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData118_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData118 = value;            Assert.Equal((byte)1, io.KeysData118.Down);            Assert.Equal(2.5f, io.KeysData118.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 119 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData119_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData119 = value;            Assert.Equal((byte)1, io.KeysData119.Down);            Assert.Equal(2.5f, io.KeysData119.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 120 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData120_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData120 = value;            Assert.Equal((byte)1, io.KeysData120.Down);            Assert.Equal(2.5f, io.KeysData120.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 121 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData121_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData121 = value;            Assert.Equal((byte)1, io.KeysData121.Down);            Assert.Equal(2.5f, io.KeysData121.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 122 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData122_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData122 = value;            Assert.Equal((byte)1, io.KeysData122.Down);            Assert.Equal(2.5f, io.KeysData122.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 123 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData123_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData123 = value;            Assert.Equal((byte)1, io.KeysData123.Down);            Assert.Equal(2.5f, io.KeysData123.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 124 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData124_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData124 = value;            Assert.Equal((byte)1, io.KeysData124.Down);            Assert.Equal(2.5f, io.KeysData124.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 125 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData125_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData125 = value;            Assert.Equal((byte)1, io.KeysData125.Down);            Assert.Equal(2.5f, io.KeysData125.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 126 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData126_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData126 = value;            Assert.Equal((byte)1, io.KeysData126.Down);            Assert.Equal(2.5f, io.KeysData126.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 127 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData127_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData127 = value;            Assert.Equal((byte)1, io.KeysData127.Down);            Assert.Equal(2.5f, io.KeysData127.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 128 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData128_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData128 = value;            Assert.Equal((byte)1, io.KeysData128.Down);            Assert.Equal(2.5f, io.KeysData128.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 129 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData129_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData129 = value;            Assert.Equal((byte)1, io.KeysData129.Down);            Assert.Equal(2.5f, io.KeysData129.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 130 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData130_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData130 = value;            Assert.Equal((byte)1, io.KeysData130.Down);            Assert.Equal(2.5f, io.KeysData130.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 131 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData131_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData131 = value;            Assert.Equal((byte)1, io.KeysData131.Down);            Assert.Equal(2.5f, io.KeysData131.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 132 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData132_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData132 = value;            Assert.Equal((byte)1, io.KeysData132.Down);            Assert.Equal(2.5f, io.KeysData132.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 133 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData133_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData133 = value;            Assert.Equal((byte)1, io.KeysData133.Down);            Assert.Equal(2.5f, io.KeysData133.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 134 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData134_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData134 = value;            Assert.Equal((byte)1, io.KeysData134.Down);            Assert.Equal(2.5f, io.KeysData134.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 135 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData135_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData135 = value;            Assert.Equal((byte)1, io.KeysData135.Down);            Assert.Equal(2.5f, io.KeysData135.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 136 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData136_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData136 = value;            Assert.Equal((byte)1, io.KeysData136.Down);            Assert.Equal(2.5f, io.KeysData136.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 137 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData137_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData137 = value;            Assert.Equal((byte)1, io.KeysData137.Down);            Assert.Equal(2.5f, io.KeysData137.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 138 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData138_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData138 = value;            Assert.Equal((byte)1, io.KeysData138.Down);            Assert.Equal(2.5f, io.KeysData138.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 139 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData139_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData139 = value;            Assert.Equal((byte)1, io.KeysData139.Down);            Assert.Equal(2.5f, io.KeysData139.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 140 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData140_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData140 = value;            Assert.Equal((byte)1, io.KeysData140.Down);            Assert.Equal(2.5f, io.KeysData140.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 141 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData141_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData141 = value;            Assert.Equal((byte)1, io.KeysData141.Down);            Assert.Equal(2.5f, io.KeysData141.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 142 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData142_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData142 = value;            Assert.Equal((byte)1, io.KeysData142.Down);            Assert.Equal(2.5f, io.KeysData142.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 143 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData143_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData143 = value;            Assert.Equal((byte)1, io.KeysData143.Down);            Assert.Equal(2.5f, io.KeysData143.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 144 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData144_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData144 = value;            Assert.Equal((byte)1, io.KeysData144.Down);            Assert.Equal(2.5f, io.KeysData144.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 145 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData145_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData145 = value;            Assert.Equal((byte)1, io.KeysData145.Down);            Assert.Equal(2.5f, io.KeysData145.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 146 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData146_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData146 = value;            Assert.Equal((byte)1, io.KeysData146.Down);            Assert.Equal(2.5f, io.KeysData146.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 147 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData147_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData147 = value;            Assert.Equal((byte)1, io.KeysData147.Down);            Assert.Equal(2.5f, io.KeysData147.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 148 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData148_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData148 = value;            Assert.Equal((byte)1, io.KeysData148.Down);            Assert.Equal(2.5f, io.KeysData148.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 149 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData149_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData149 = value;            Assert.Equal((byte)1, io.KeysData149.Down);            Assert.Equal(2.5f, io.KeysData149.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 150 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData150_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData150 = value;            Assert.Equal((byte)1, io.KeysData150.Down);            Assert.Equal(2.5f, io.KeysData150.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 151 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData151_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData151 = value;            Assert.Equal((byte)1, io.KeysData151.Down);            Assert.Equal(2.5f, io.KeysData151.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 152 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData152_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData152 = value;            Assert.Equal((byte)1, io.KeysData152.Down);            Assert.Equal(2.5f, io.KeysData152.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 153 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData153_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData153 = value;            Assert.Equal((byte)1, io.KeysData153.Down);            Assert.Equal(2.5f, io.KeysData153.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 154 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData154_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData154 = value;            Assert.Equal((byte)1, io.KeysData154.Down);            Assert.Equal(2.5f, io.KeysData154.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 155 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData155_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData155 = value;            Assert.Equal((byte)1, io.KeysData155.Down);            Assert.Equal(2.5f, io.KeysData155.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 156 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData156_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData156 = value;            Assert.Equal((byte)1, io.KeysData156.Down);            Assert.Equal(2.5f, io.KeysData156.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 157 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData157_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData157 = value;            Assert.Equal((byte)1, io.KeysData157.Down);            Assert.Equal(2.5f, io.KeysData157.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 158 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData158_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData158 = value;            Assert.Equal((byte)1, io.KeysData158.Down);            Assert.Equal(2.5f, io.KeysData158.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 159 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData159_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData159 = value;            Assert.Equal((byte)1, io.KeysData159.Down);            Assert.Equal(2.5f, io.KeysData159.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 160 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData160_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData160 = value;            Assert.Equal((byte)1, io.KeysData160.Down);            Assert.Equal(2.5f, io.KeysData160.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 161 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData161_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData161 = value;            Assert.Equal((byte)1, io.KeysData161.Down);            Assert.Equal(2.5f, io.KeysData161.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 162 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData162_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData162 = value;            Assert.Equal((byte)1, io.KeysData162.Down);            Assert.Equal(2.5f, io.KeysData162.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 163 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData163_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData163 = value;            Assert.Equal((byte)1, io.KeysData163.Down);            Assert.Equal(2.5f, io.KeysData163.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 164 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData164_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData164 = value;            Assert.Equal((byte)1, io.KeysData164.Down);            Assert.Equal(2.5f, io.KeysData164.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 165 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData165_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData165 = value;            Assert.Equal((byte)1, io.KeysData165.Down);            Assert.Equal(2.5f, io.KeysData165.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 166 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData166_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData166 = value;            Assert.Equal((byte)1, io.KeysData166.Down);            Assert.Equal(2.5f, io.KeysData166.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 167 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData167_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData167 = value;            Assert.Equal((byte)1, io.KeysData167.Down);            Assert.Equal(2.5f, io.KeysData167.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 168 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData168_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData168 = value;            Assert.Equal((byte)1, io.KeysData168.Down);            Assert.Equal(2.5f, io.KeysData168.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 169 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData169_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData169 = value;            Assert.Equal((byte)1, io.KeysData169.Down);            Assert.Equal(2.5f, io.KeysData169.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 170 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData170_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData170 = value;            Assert.Equal((byte)1, io.KeysData170.Down);            Assert.Equal(2.5f, io.KeysData170.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 171 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData171_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData171 = value;            Assert.Equal((byte)1, io.KeysData171.Down);            Assert.Equal(2.5f, io.KeysData171.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 172 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData172_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData172 = value;            Assert.Equal((byte)1, io.KeysData172.Down);            Assert.Equal(2.5f, io.KeysData172.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 173 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData173_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData173 = value;            Assert.Equal((byte)1, io.KeysData173.Down);            Assert.Equal(2.5f, io.KeysData173.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 174 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData174_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData174 = value;            Assert.Equal((byte)1, io.KeysData174.Down);            Assert.Equal(2.5f, io.KeysData174.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 175 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData175_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData175 = value;            Assert.Equal((byte)1, io.KeysData175.Down);            Assert.Equal(2.5f, io.KeysData175.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 176 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData176_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData176 = value;            Assert.Equal((byte)1, io.KeysData176.Down);            Assert.Equal(2.5f, io.KeysData176.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 177 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData177_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData177 = value;            Assert.Equal((byte)1, io.KeysData177.Down);            Assert.Equal(2.5f, io.KeysData177.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 178 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData178_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData178 = value;            Assert.Equal((byte)1, io.KeysData178.Down);            Assert.Equal(2.5f, io.KeysData178.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 179 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData179_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData179 = value;            Assert.Equal((byte)1, io.KeysData179.Down);            Assert.Equal(2.5f, io.KeysData179.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 180 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData180_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData180 = value;            Assert.Equal((byte)1, io.KeysData180.Down);            Assert.Equal(2.5f, io.KeysData180.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 181 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData181_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData181 = value;            Assert.Equal((byte)1, io.KeysData181.Down);            Assert.Equal(2.5f, io.KeysData181.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 182 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData182_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData182 = value;            Assert.Equal((byte)1, io.KeysData182.Down);            Assert.Equal(2.5f, io.KeysData182.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 183 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData183_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData183 = value;            Assert.Equal((byte)1, io.KeysData183.Down);            Assert.Equal(2.5f, io.KeysData183.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 184 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData184_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData184 = value;            Assert.Equal((byte)1, io.KeysData184.Down);            Assert.Equal(2.5f, io.KeysData184.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 185 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData185_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData185 = value;            Assert.Equal((byte)1, io.KeysData185.Down);            Assert.Equal(2.5f, io.KeysData185.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 186 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData186_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData186 = value;            Assert.Equal((byte)1, io.KeysData186.Down);            Assert.Equal(2.5f, io.KeysData186.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 187 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData187_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData187 = value;            Assert.Equal((byte)1, io.KeysData187.Down);            Assert.Equal(2.5f, io.KeysData187.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 188 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData188_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData188 = value;            Assert.Equal((byte)1, io.KeysData188.Down);            Assert.Equal(2.5f, io.KeysData188.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 189 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData189_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData189 = value;            Assert.Equal((byte)1, io.KeysData189.Down);            Assert.Equal(2.5f, io.KeysData189.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 190 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData190_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData190 = value;            Assert.Equal((byte)1, io.KeysData190.Down);            Assert.Equal(2.5f, io.KeysData190.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 191 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData191_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData191 = value;            Assert.Equal((byte)1, io.KeysData191.Down);            Assert.Equal(2.5f, io.KeysData191.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 192 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData192_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData192 = value;            Assert.Equal((byte)1, io.KeysData192.Down);            Assert.Equal(2.5f, io.KeysData192.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 193 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData193_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData193 = value;            Assert.Equal((byte)1, io.KeysData193.Down);            Assert.Equal(2.5f, io.KeysData193.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 194 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData194_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData194 = value;            Assert.Equal((byte)1, io.KeysData194.Down);            Assert.Equal(2.5f, io.KeysData194.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 195 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData195_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData195 = value;            Assert.Equal((byte)1, io.KeysData195.Down);            Assert.Equal(2.5f, io.KeysData195.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 196 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData196_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData196 = value;            Assert.Equal((byte)1, io.KeysData196.Down);            Assert.Equal(2.5f, io.KeysData196.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 197 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData197_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData197 = value;            Assert.Equal((byte)1, io.KeysData197.Down);            Assert.Equal(2.5f, io.KeysData197.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 198 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData198_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData198 = value;            Assert.Equal((byte)1, io.KeysData198.Down);            Assert.Equal(2.5f, io.KeysData198.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 199 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData199_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData199 = value;            Assert.Equal((byte)1, io.KeysData199.Down);            Assert.Equal(2.5f, io.KeysData199.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 200 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData200_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData200 = value;            Assert.Equal((byte)1, io.KeysData200.Down);            Assert.Equal(2.5f, io.KeysData200.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 201 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData201_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData201 = value;            Assert.Equal((byte)1, io.KeysData201.Down);            Assert.Equal(2.5f, io.KeysData201.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 202 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData202_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData202 = value;            Assert.Equal((byte)1, io.KeysData202.Down);            Assert.Equal(2.5f, io.KeysData202.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 203 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData203_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData203 = value;            Assert.Equal((byte)1, io.KeysData203.Down);            Assert.Equal(2.5f, io.KeysData203.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 204 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData204_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData204 = value;            Assert.Equal((byte)1, io.KeysData204.Down);            Assert.Equal(2.5f, io.KeysData204.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 205 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData205_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData205 = value;            Assert.Equal((byte)1, io.KeysData205.Down);            Assert.Equal(2.5f, io.KeysData205.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 206 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData206_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData206 = value;            Assert.Equal((byte)1, io.KeysData206.Down);            Assert.Equal(2.5f, io.KeysData206.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 207 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData207_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData207 = value;            Assert.Equal((byte)1, io.KeysData207.Down);            Assert.Equal(2.5f, io.KeysData207.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 208 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData208_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData208 = value;            Assert.Equal((byte)1, io.KeysData208.Down);            Assert.Equal(2.5f, io.KeysData208.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 209 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData209_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData209 = value;            Assert.Equal((byte)1, io.KeysData209.Down);            Assert.Equal(2.5f, io.KeysData209.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 210 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData210_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData210 = value;            Assert.Equal((byte)1, io.KeysData210.Down);            Assert.Equal(2.5f, io.KeysData210.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 211 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData211_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData211 = value;            Assert.Equal((byte)1, io.KeysData211.Down);            Assert.Equal(2.5f, io.KeysData211.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 212 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData212_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData212 = value;            Assert.Equal((byte)1, io.KeysData212.Down);            Assert.Equal(2.5f, io.KeysData212.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 213 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData213_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData213 = value;            Assert.Equal((byte)1, io.KeysData213.Down);            Assert.Equal(2.5f, io.KeysData213.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 214 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData214_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData214 = value;            Assert.Equal((byte)1, io.KeysData214.Down);            Assert.Equal(2.5f, io.KeysData214.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 215 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData215_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData215 = value;            Assert.Equal((byte)1, io.KeysData215.Down);            Assert.Equal(2.5f, io.KeysData215.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 216 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData216_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData216 = value;            Assert.Equal((byte)1, io.KeysData216.Down);            Assert.Equal(2.5f, io.KeysData216.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 217 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData217_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData217 = value;            Assert.Equal((byte)1, io.KeysData217.Down);            Assert.Equal(2.5f, io.KeysData217.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 218 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData218_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData218 = value;            Assert.Equal((byte)1, io.KeysData218.Down);            Assert.Equal(2.5f, io.KeysData218.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 219 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData219_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData219 = value;            Assert.Equal((byte)1, io.KeysData219.Down);            Assert.Equal(2.5f, io.KeysData219.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 220 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData220_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData220 = value;            Assert.Equal((byte)1, io.KeysData220.Down);            Assert.Equal(2.5f, io.KeysData220.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 221 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData221_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData221 = value;            Assert.Equal((byte)1, io.KeysData221.Down);            Assert.Equal(2.5f, io.KeysData221.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 222 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData222_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData222 = value;            Assert.Equal((byte)1, io.KeysData222.Down);            Assert.Equal(2.5f, io.KeysData222.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 223 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData223_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData223 = value;            Assert.Equal((byte)1, io.KeysData223.Down);            Assert.Equal(2.5f, io.KeysData223.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 224 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData224_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData224 = value;            Assert.Equal((byte)1, io.KeysData224.Down);            Assert.Equal(2.5f, io.KeysData224.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 225 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData225_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData225 = value;            Assert.Equal((byte)1, io.KeysData225.Down);            Assert.Equal(2.5f, io.KeysData225.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 226 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData226_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData226 = value;            Assert.Equal((byte)1, io.KeysData226.Down);            Assert.Equal(2.5f, io.KeysData226.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 227 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData227_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData227 = value;            Assert.Equal((byte)1, io.KeysData227.Down);            Assert.Equal(2.5f, io.KeysData227.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 228 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData228_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData228 = value;            Assert.Equal((byte)1, io.KeysData228.Down);            Assert.Equal(2.5f, io.KeysData228.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 229 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData229_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData229 = value;            Assert.Equal((byte)1, io.KeysData229.Down);            Assert.Equal(2.5f, io.KeysData229.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 230 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData230_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData230 = value;            Assert.Equal((byte)1, io.KeysData230.Down);            Assert.Equal(2.5f, io.KeysData230.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 231 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData231_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData231 = value;            Assert.Equal((byte)1, io.KeysData231.Down);            Assert.Equal(2.5f, io.KeysData231.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 232 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData232_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData232 = value;            Assert.Equal((byte)1, io.KeysData232.Down);            Assert.Equal(2.5f, io.KeysData232.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 233 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData233_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData233 = value;            Assert.Equal((byte)1, io.KeysData233.Down);            Assert.Equal(2.5f, io.KeysData233.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 234 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData234_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData234 = value;            Assert.Equal((byte)1, io.KeysData234.Down);            Assert.Equal(2.5f, io.KeysData234.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 235 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData235_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData235 = value;            Assert.Equal((byte)1, io.KeysData235.Down);            Assert.Equal(2.5f, io.KeysData235.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 236 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData236_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData236 = value;            Assert.Equal((byte)1, io.KeysData236.Down);            Assert.Equal(2.5f, io.KeysData236.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 237 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData237_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData237 = value;            Assert.Equal((byte)1, io.KeysData237.Down);            Assert.Equal(2.5f, io.KeysData237.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 238 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData238_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData238 = value;            Assert.Equal((byte)1, io.KeysData238.Down);            Assert.Equal(2.5f, io.KeysData238.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 239 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData239_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData239 = value;            Assert.Equal((byte)1, io.KeysData239.Down);            Assert.Equal(2.5f, io.KeysData239.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 240 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData240_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData240 = value;            Assert.Equal((byte)1, io.KeysData240.Down);            Assert.Equal(2.5f, io.KeysData240.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 241 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData241_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData241 = value;            Assert.Equal((byte)1, io.KeysData241.Down);            Assert.Equal(2.5f, io.KeysData241.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 242 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData242_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData242 = value;            Assert.Equal((byte)1, io.KeysData242.Down);            Assert.Equal(2.5f, io.KeysData242.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 243 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData243_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData243 = value;            Assert.Equal((byte)1, io.KeysData243.Down);            Assert.Equal(2.5f, io.KeysData243.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 244 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData244_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData244 = value;            Assert.Equal((byte)1, io.KeysData244.Down);            Assert.Equal(2.5f, io.KeysData244.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 245 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData245_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData245 = value;            Assert.Equal((byte)1, io.KeysData245.Down);            Assert.Equal(2.5f, io.KeysData245.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 246 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData246_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData246 = value;            Assert.Equal((byte)1, io.KeysData246.Down);            Assert.Equal(2.5f, io.KeysData246.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 247 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData247_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData247 = value;            Assert.Equal((byte)1, io.KeysData247.Down);            Assert.Equal(2.5f, io.KeysData247.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 248 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData248_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData248 = value;            Assert.Equal((byte)1, io.KeysData248.Down);            Assert.Equal(2.5f, io.KeysData248.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 249 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData249_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData249 = value;            Assert.Equal((byte)1, io.KeysData249.Down);            Assert.Equal(2.5f, io.KeysData249.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 250 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData250_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData250 = value;            Assert.Equal((byte)1, io.KeysData250.Down);            Assert.Equal(2.5f, io.KeysData250.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 251 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData251_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData251 = value;            Assert.Equal((byte)1, io.KeysData251.Down);            Assert.Equal(2.5f, io.KeysData251.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 252 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData252_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData252 = value;            Assert.Equal((byte)1, io.KeysData252.Down);            Assert.Equal(2.5f, io.KeysData252.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 253 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData253_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData253 = value;            Assert.Equal((byte)1, io.KeysData253.Down);            Assert.Equal(2.5f, io.KeysData253.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 254 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData254_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData254 = value;            Assert.Equal((byte)1, io.KeysData254.Down);            Assert.Equal(2.5f, io.KeysData254.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 255 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData255_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData255 = value;            Assert.Equal((byte)1, io.KeysData255.Down);            Assert.Equal(2.5f, io.KeysData255.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 256 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData256_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData256 = value;            Assert.Equal((byte)1, io.KeysData256.Down);            Assert.Equal(2.5f, io.KeysData256.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 257 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData257_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData257 = value;            Assert.Equal((byte)1, io.KeysData257.Down);            Assert.Equal(2.5f, io.KeysData257.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 258 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData258_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData258 = value;            Assert.Equal((byte)1, io.KeysData258.Down);            Assert.Equal(2.5f, io.KeysData258.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 259 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData259_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData259 = value;            Assert.Equal((byte)1, io.KeysData259.Down);            Assert.Equal(2.5f, io.KeysData259.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 260 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData260_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData260 = value;            Assert.Equal((byte)1, io.KeysData260.Down);            Assert.Equal(2.5f, io.KeysData260.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 261 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData261_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData261 = value;            Assert.Equal((byte)1, io.KeysData261.Down);            Assert.Equal(2.5f, io.KeysData261.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 262 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData262_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData262 = value;            Assert.Equal((byte)1, io.KeysData262.Down);            Assert.Equal(2.5f, io.KeysData262.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 263 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData263_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData263 = value;            Assert.Equal((byte)1, io.KeysData263.Down);            Assert.Equal(2.5f, io.KeysData263.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 264 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData264_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData264 = value;            Assert.Equal((byte)1, io.KeysData264.Down);            Assert.Equal(2.5f, io.KeysData264.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 265 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData265_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData265 = value;            Assert.Equal((byte)1, io.KeysData265.Down);            Assert.Equal(2.5f, io.KeysData265.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 266 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData266_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData266 = value;            Assert.Equal((byte)1, io.KeysData266.Down);            Assert.Equal(2.5f, io.KeysData266.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 267 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData267_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData267 = value;            Assert.Equal((byte)1, io.KeysData267.Down);            Assert.Equal(2.5f, io.KeysData267.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 268 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData268_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData268 = value;            Assert.Equal((byte)1, io.KeysData268.Down);            Assert.Equal(2.5f, io.KeysData268.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 269 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData269_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData269 = value;            Assert.Equal((byte)1, io.KeysData269.Down);            Assert.Equal(2.5f, io.KeysData269.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 270 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData270_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData270 = value;            Assert.Equal((byte)1, io.KeysData270.Down);            Assert.Equal(2.5f, io.KeysData270.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 271 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData271_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData271 = value;            Assert.Equal((byte)1, io.KeysData271.Down);            Assert.Equal(2.5f, io.KeysData271.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 272 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData272_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData272 = value;            Assert.Equal((byte)1, io.KeysData272.Down);            Assert.Equal(2.5f, io.KeysData272.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 273 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData273_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData273 = value;            Assert.Equal((byte)1, io.KeysData273.Down);            Assert.Equal(2.5f, io.KeysData273.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 274 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData274_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData274 = value;            Assert.Equal((byte)1, io.KeysData274.Down);            Assert.Equal(2.5f, io.KeysData274.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 275 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData275_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData275 = value;            Assert.Equal((byte)1, io.KeysData275.Down);            Assert.Equal(2.5f, io.KeysData275.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 276 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData276_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData276 = value;            Assert.Equal((byte)1, io.KeysData276.Down);            Assert.Equal(2.5f, io.KeysData276.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 277 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData277_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData277 = value;            Assert.Equal((byte)1, io.KeysData277.Down);            Assert.Equal(2.5f, io.KeysData277.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 278 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData278_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData278 = value;            Assert.Equal((byte)1, io.KeysData278.Down);            Assert.Equal(2.5f, io.KeysData278.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 279 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData279_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData279 = value;            Assert.Equal((byte)1, io.KeysData279.Down);            Assert.Equal(2.5f, io.KeysData279.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 280 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData280_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData280 = value;            Assert.Equal((byte)1, io.KeysData280.Down);            Assert.Equal(2.5f, io.KeysData280.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 281 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData281_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData281 = value;            Assert.Equal((byte)1, io.KeysData281.Down);            Assert.Equal(2.5f, io.KeysData281.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 282 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData282_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData282 = value;            Assert.Equal((byte)1, io.KeysData282.Down);            Assert.Equal(2.5f, io.KeysData282.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 283 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData283_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData283 = value;            Assert.Equal((byte)1, io.KeysData283.Down);            Assert.Equal(2.5f, io.KeysData283.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 284 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData284_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData284 = value;            Assert.Equal((byte)1, io.KeysData284.Down);            Assert.Equal(2.5f, io.KeysData284.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 285 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData285_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData285 = value;            Assert.Equal((byte)1, io.KeysData285.Down);            Assert.Equal(2.5f, io.KeysData285.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 286 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData286_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData286 = value;            Assert.Equal((byte)1, io.KeysData286.Down);            Assert.Equal(2.5f, io.KeysData286.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 287 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData287_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData287 = value;            Assert.Equal((byte)1, io.KeysData287.Down);            Assert.Equal(2.5f, io.KeysData287.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 288 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData288_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData288 = value;            Assert.Equal((byte)1, io.KeysData288.Down);            Assert.Equal(2.5f, io.KeysData288.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 289 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData289_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData289 = value;            Assert.Equal((byte)1, io.KeysData289.Down);            Assert.Equal(2.5f, io.KeysData289.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 290 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData290_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData290 = value;            Assert.Equal((byte)1, io.KeysData290.Down);            Assert.Equal(2.5f, io.KeysData290.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 291 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData291_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData291 = value;            Assert.Equal((byte)1, io.KeysData291.Down);            Assert.Equal(2.5f, io.KeysData291.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 292 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData292_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData292 = value;            Assert.Equal((byte)1, io.KeysData292.Down);            Assert.Equal(2.5f, io.KeysData292.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 293 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData293_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData293 = value;            Assert.Equal((byte)1, io.KeysData293.Down);            Assert.Equal(2.5f, io.KeysData293.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 294 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData294_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData294 = value;            Assert.Equal((byte)1, io.KeysData294.Down);            Assert.Equal(2.5f, io.KeysData294.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 295 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData295_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData295 = value;            Assert.Equal((byte)1, io.KeysData295.Down);            Assert.Equal(2.5f, io.KeysData295.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 296 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData296_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData296 = value;            Assert.Equal((byte)1, io.KeysData296.Down);            Assert.Equal(2.5f, io.KeysData296.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 297 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData297_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData297 = value;            Assert.Equal((byte)1, io.KeysData297.Down);            Assert.Equal(2.5f, io.KeysData297.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 298 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData298_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData298 = value;            Assert.Equal((byte)1, io.KeysData298.Down);            Assert.Equal(2.5f, io.KeysData298.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 299 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData299_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData299 = value;            Assert.Equal((byte)1, io.KeysData299.Down);            Assert.Equal(2.5f, io.KeysData299.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 300 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData300_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData300 = value;            Assert.Equal((byte)1, io.KeysData300.Down);            Assert.Equal(2.5f, io.KeysData300.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 301 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData301_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData301 = value;            Assert.Equal((byte)1, io.KeysData301.Down);            Assert.Equal(2.5f, io.KeysData301.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 302 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData302_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData302 = value;            Assert.Equal((byte)1, io.KeysData302.Down);            Assert.Equal(2.5f, io.KeysData302.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 303 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData303_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData303 = value;            Assert.Equal((byte)1, io.KeysData303.Down);            Assert.Equal(2.5f, io.KeysData303.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 304 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData304_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData304 = value;            Assert.Equal((byte)1, io.KeysData304.Down);            Assert.Equal(2.5f, io.KeysData304.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 305 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData305_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData305 = value;            Assert.Equal((byte)1, io.KeysData305.Down);            Assert.Equal(2.5f, io.KeysData305.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 306 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData306_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData306 = value;            Assert.Equal((byte)1, io.KeysData306.Down);            Assert.Equal(2.5f, io.KeysData306.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 307 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData307_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData307 = value;            Assert.Equal((byte)1, io.KeysData307.Down);            Assert.Equal(2.5f, io.KeysData307.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 308 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData308_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData308 = value;            Assert.Equal((byte)1, io.KeysData308.Down);            Assert.Equal(2.5f, io.KeysData308.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 309 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData309_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData309 = value;            Assert.Equal((byte)1, io.KeysData309.Down);            Assert.Equal(2.5f, io.KeysData309.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 310 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData310_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData310 = value;            Assert.Equal((byte)1, io.KeysData310.Down);            Assert.Equal(2.5f, io.KeysData310.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 311 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData311_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData311 = value;            Assert.Equal((byte)1, io.KeysData311.Down);            Assert.Equal(2.5f, io.KeysData311.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 312 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData312_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData312 = value;            Assert.Equal((byte)1, io.KeysData312.Down);            Assert.Equal(2.5f, io.KeysData312.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 313 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData313_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData313 = value;            Assert.Equal((byte)1, io.KeysData313.Down);            Assert.Equal(2.5f, io.KeysData313.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 314 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData314_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData314 = value;            Assert.Equal((byte)1, io.KeysData314.Down);            Assert.Equal(2.5f, io.KeysData314.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 315 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData315_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData315 = value;            Assert.Equal((byte)1, io.KeysData315.Down);            Assert.Equal(2.5f, io.KeysData315.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 316 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData316_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData316 = value;            Assert.Equal((byte)1, io.KeysData316.Down);            Assert.Equal(2.5f, io.KeysData316.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 317 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData317_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData317 = value;            Assert.Equal((byte)1, io.KeysData317.Down);            Assert.Equal(2.5f, io.KeysData317.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 318 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData318_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData318 = value;            Assert.Equal((byte)1, io.KeysData318.Down);            Assert.Equal(2.5f, io.KeysData318.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 319 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData319_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData319 = value;            Assert.Equal((byte)1, io.KeysData319.Down);            Assert.Equal(2.5f, io.KeysData319.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 320 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData320_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData320 = value;            Assert.Equal((byte)1, io.KeysData320.Down);            Assert.Equal(2.5f, io.KeysData320.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 321 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData321_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData321 = value;            Assert.Equal((byte)1, io.KeysData321.Down);            Assert.Equal(2.5f, io.KeysData321.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 322 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData322_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData322 = value;            Assert.Equal((byte)1, io.KeysData322.Down);            Assert.Equal(2.5f, io.KeysData322.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 323 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData323_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData323 = value;            Assert.Equal((byte)1, io.KeysData323.Down);            Assert.Equal(2.5f, io.KeysData323.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 324 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData324_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData324 = value;            Assert.Equal((byte)1, io.KeysData324.Down);            Assert.Equal(2.5f, io.KeysData324.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 325 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData325_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData325 = value;            Assert.Equal((byte)1, io.KeysData325.Down);            Assert.Equal(2.5f, io.KeysData325.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 326 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData326_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData326 = value;            Assert.Equal((byte)1, io.KeysData326.Down);            Assert.Equal(2.5f, io.KeysData326.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 327 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData327_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData327 = value;            Assert.Equal((byte)1, io.KeysData327.Down);            Assert.Equal(2.5f, io.KeysData327.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 328 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData328_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData328 = value;            Assert.Equal((byte)1, io.KeysData328.Down);            Assert.Equal(2.5f, io.KeysData328.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 329 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData329_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData329 = value;            Assert.Equal((byte)1, io.KeysData329.Down);            Assert.Equal(2.5f, io.KeysData329.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 330 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData330_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData330 = value;            Assert.Equal((byte)1, io.KeysData330.Down);            Assert.Equal(2.5f, io.KeysData330.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 331 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData331_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData331 = value;            Assert.Equal((byte)1, io.KeysData331.Down);            Assert.Equal(2.5f, io.KeysData331.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 332 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData332_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData332 = value;            Assert.Equal((byte)1, io.KeysData332.Down);            Assert.Equal(2.5f, io.KeysData332.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 333 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData333_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData333 = value;            Assert.Equal((byte)1, io.KeysData333.Down);            Assert.Equal(2.5f, io.KeysData333.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 334 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData334_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData334 = value;            Assert.Equal((byte)1, io.KeysData334.Down);            Assert.Equal(2.5f, io.KeysData334.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 335 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData335_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData335 = value;            Assert.Equal((byte)1, io.KeysData335.Down);            Assert.Equal(2.5f, io.KeysData335.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 336 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData336_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData336 = value;            Assert.Equal((byte)1, io.KeysData336.Down);            Assert.Equal(2.5f, io.KeysData336.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 337 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData337_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData337 = value;            Assert.Equal((byte)1, io.KeysData337.Down);            Assert.Equal(2.5f, io.KeysData337.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 338 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData338_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData338 = value;            Assert.Equal((byte)1, io.KeysData338.Down);            Assert.Equal(2.5f, io.KeysData338.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 339 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData339_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData339 = value;            Assert.Equal((byte)1, io.KeysData339.Down);            Assert.Equal(2.5f, io.KeysData339.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 340 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData340_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData340 = value;            Assert.Equal((byte)1, io.KeysData340.Down);            Assert.Equal(2.5f, io.KeysData340.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 341 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData341_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData341 = value;            Assert.Equal((byte)1, io.KeysData341.Down);            Assert.Equal(2.5f, io.KeysData341.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 342 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData342_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData342 = value;            Assert.Equal((byte)1, io.KeysData342.Down);            Assert.Equal(2.5f, io.KeysData342.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 343 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData343_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData343 = value;            Assert.Equal((byte)1, io.KeysData343.Down);            Assert.Equal(2.5f, io.KeysData343.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 344 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData344_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData344 = value;            Assert.Equal((byte)1, io.KeysData344.Down);            Assert.Equal(2.5f, io.KeysData344.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 345 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData345_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData345 = value;            Assert.Equal((byte)1, io.KeysData345.Down);            Assert.Equal(2.5f, io.KeysData345.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 346 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData346_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData346 = value;            Assert.Equal((byte)1, io.KeysData346.Down);            Assert.Equal(2.5f, io.KeysData346.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 347 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData347_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData347 = value;            Assert.Equal((byte)1, io.KeysData347.Down);            Assert.Equal(2.5f, io.KeysData347.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 348 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData348_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData348 = value;            Assert.Equal((byte)1, io.KeysData348.Down);            Assert.Equal(2.5f, io.KeysData348.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 349 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData349_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData349 = value;            Assert.Equal((byte)1, io.KeysData349.Down);            Assert.Equal(2.5f, io.KeysData349.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 350 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData350_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData350 = value;            Assert.Equal((byte)1, io.KeysData350.Down);            Assert.Equal(2.5f, io.KeysData350.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 351 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData351_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData351 = value;            Assert.Equal((byte)1, io.KeysData351.Down);            Assert.Equal(2.5f, io.KeysData351.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 352 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData352_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData352 = value;            Assert.Equal((byte)1, io.KeysData352.Down);            Assert.Equal(2.5f, io.KeysData352.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 353 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData353_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData353 = value;            Assert.Equal((byte)1, io.KeysData353.Down);            Assert.Equal(2.5f, io.KeysData353.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 354 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData354_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData354 = value;            Assert.Equal((byte)1, io.KeysData354.Down);            Assert.Equal(2.5f, io.KeysData354.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 355 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData355_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData355 = value;            Assert.Equal((byte)1, io.KeysData355.Down);            Assert.Equal(2.5f, io.KeysData355.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 356 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData356_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData356 = value;            Assert.Equal((byte)1, io.KeysData356.Down);            Assert.Equal(2.5f, io.KeysData356.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 357 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData357_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData357 = value;            Assert.Equal((byte)1, io.KeysData357.Down);            Assert.Equal(2.5f, io.KeysData357.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 358 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData358_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData358 = value;            Assert.Equal((byte)1, io.KeysData358.Down);            Assert.Equal(2.5f, io.KeysData358.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 359 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData359_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData359 = value;            Assert.Equal((byte)1, io.KeysData359.Down);            Assert.Equal(2.5f, io.KeysData359.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 360 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData360_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData360 = value;            Assert.Equal((byte)1, io.KeysData360.Down);            Assert.Equal(2.5f, io.KeysData360.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 361 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData361_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData361 = value;            Assert.Equal((byte)1, io.KeysData361.Down);            Assert.Equal(2.5f, io.KeysData361.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 362 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData362_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData362 = value;            Assert.Equal((byte)1, io.KeysData362.Down);            Assert.Equal(2.5f, io.KeysData362.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 363 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData363_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData363 = value;            Assert.Equal((byte)1, io.KeysData363.Down);            Assert.Equal(2.5f, io.KeysData363.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 364 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData364_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData364 = value;            Assert.Equal((byte)1, io.KeysData364.Down);            Assert.Equal(2.5f, io.KeysData364.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 365 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData365_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData365 = value;            Assert.Equal((byte)1, io.KeysData365.Down);            Assert.Equal(2.5f, io.KeysData365.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 366 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData366_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData366 = value;            Assert.Equal((byte)1, io.KeysData366.Down);            Assert.Equal(2.5f, io.KeysData366.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 367 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData367_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData367 = value;            Assert.Equal((byte)1, io.KeysData367.Down);            Assert.Equal(2.5f, io.KeysData367.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 368 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData368_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData368 = value;            Assert.Equal((byte)1, io.KeysData368.Down);            Assert.Equal(2.5f, io.KeysData368.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 369 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData369_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData369 = value;            Assert.Equal((byte)1, io.KeysData369.Down);            Assert.Equal(2.5f, io.KeysData369.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 370 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData370_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData370 = value;            Assert.Equal((byte)1, io.KeysData370.Down);            Assert.Equal(2.5f, io.KeysData370.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 371 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData371_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData371 = value;            Assert.Equal((byte)1, io.KeysData371.Down);            Assert.Equal(2.5f, io.KeysData371.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 372 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData372_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData372 = value;            Assert.Equal((byte)1, io.KeysData372.Down);            Assert.Equal(2.5f, io.KeysData372.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 373 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData373_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData373 = value;            Assert.Equal((byte)1, io.KeysData373.Down);            Assert.Equal(2.5f, io.KeysData373.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 374 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData374_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData374 = value;            Assert.Equal((byte)1, io.KeysData374.Down);            Assert.Equal(2.5f, io.KeysData374.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 375 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData375_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData375 = value;            Assert.Equal((byte)1, io.KeysData375.Down);            Assert.Equal(2.5f, io.KeysData375.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 376 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData376_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData376 = value;            Assert.Equal((byte)1, io.KeysData376.Down);            Assert.Equal(2.5f, io.KeysData376.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 377 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData377_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData377 = value;            Assert.Equal((byte)1, io.KeysData377.Down);            Assert.Equal(2.5f, io.KeysData377.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 378 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData378_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData378 = value;            Assert.Equal((byte)1, io.KeysData378.Down);            Assert.Equal(2.5f, io.KeysData378.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 379 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData379_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData379 = value;            Assert.Equal((byte)1, io.KeysData379.Down);            Assert.Equal(2.5f, io.KeysData379.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 380 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData380_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData380 = value;            Assert.Equal((byte)1, io.KeysData380.Down);            Assert.Equal(2.5f, io.KeysData380.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 381 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData381_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData381 = value;            Assert.Equal((byte)1, io.KeysData381.Down);            Assert.Equal(2.5f, io.KeysData381.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 382 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData382_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData382 = value;            Assert.Equal((byte)1, io.KeysData382.Down);            Assert.Equal(2.5f, io.KeysData382.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 383 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData383_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData383 = value;            Assert.Equal((byte)1, io.KeysData383.Down);            Assert.Equal(2.5f, io.KeysData383.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 384 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData384_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData384 = value;            Assert.Equal((byte)1, io.KeysData384.Down);            Assert.Equal(2.5f, io.KeysData384.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 385 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData385_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData385 = value;            Assert.Equal((byte)1, io.KeysData385.Down);            Assert.Equal(2.5f, io.KeysData385.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 386 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData386_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData386 = value;            Assert.Equal((byte)1, io.KeysData386.Down);            Assert.Equal(2.5f, io.KeysData386.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 387 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData387_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData387 = value;            Assert.Equal((byte)1, io.KeysData387.Down);            Assert.Equal(2.5f, io.KeysData387.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 388 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData388_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData388 = value;            Assert.Equal((byte)1, io.KeysData388.Down);            Assert.Equal(2.5f, io.KeysData388.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 389 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData389_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData389 = value;            Assert.Equal((byte)1, io.KeysData389.Down);            Assert.Equal(2.5f, io.KeysData389.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 390 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData390_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData390 = value;            Assert.Equal((byte)1, io.KeysData390.Down);            Assert.Equal(2.5f, io.KeysData390.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 391 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData391_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData391 = value;            Assert.Equal((byte)1, io.KeysData391.Down);            Assert.Equal(2.5f, io.KeysData391.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 392 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData392_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData392 = value;            Assert.Equal((byte)1, io.KeysData392.Down);            Assert.Equal(2.5f, io.KeysData392.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 393 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData393_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData393 = value;            Assert.Equal((byte)1, io.KeysData393.Down);            Assert.Equal(2.5f, io.KeysData393.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 394 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData394_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData394 = value;            Assert.Equal((byte)1, io.KeysData394.Down);            Assert.Equal(2.5f, io.KeysData394.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 395 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData395_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData395 = value;            Assert.Equal((byte)1, io.KeysData395.Down);            Assert.Equal(2.5f, io.KeysData395.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 396 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData396_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData396 = value;            Assert.Equal((byte)1, io.KeysData396.Down);            Assert.Equal(2.5f, io.KeysData396.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 397 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData397_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData397 = value;            Assert.Equal((byte)1, io.KeysData397.Down);            Assert.Equal(2.5f, io.KeysData397.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 398 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData398_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData398 = value;            Assert.Equal((byte)1, io.KeysData398.Down);            Assert.Equal(2.5f, io.KeysData398.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 399 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData399_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData399 = value;            Assert.Equal((byte)1, io.KeysData399.Down);            Assert.Equal(2.5f, io.KeysData399.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 400 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData400_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData400 = value;            Assert.Equal((byte)1, io.KeysData400.Down);            Assert.Equal(2.5f, io.KeysData400.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 401 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData401_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData401 = value;            Assert.Equal((byte)1, io.KeysData401.Down);            Assert.Equal(2.5f, io.KeysData401.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 402 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData402_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData402 = value;            Assert.Equal((byte)1, io.KeysData402.Down);            Assert.Equal(2.5f, io.KeysData402.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 403 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData403_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData403 = value;            Assert.Equal((byte)1, io.KeysData403.Down);            Assert.Equal(2.5f, io.KeysData403.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 404 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData404_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData404 = value;            Assert.Equal((byte)1, io.KeysData404.Down);            Assert.Equal(2.5f, io.KeysData404.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 405 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData405_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData405 = value;            Assert.Equal((byte)1, io.KeysData405.Down);            Assert.Equal(2.5f, io.KeysData405.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 406 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData406_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData406 = value;            Assert.Equal((byte)1, io.KeysData406.Down);            Assert.Equal(2.5f, io.KeysData406.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 407 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData407_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData407 = value;            Assert.Equal((byte)1, io.KeysData407.Down);            Assert.Equal(2.5f, io.KeysData407.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 408 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData408_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData408 = value;            Assert.Equal((byte)1, io.KeysData408.Down);            Assert.Equal(2.5f, io.KeysData408.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 409 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData409_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData409 = value;            Assert.Equal((byte)1, io.KeysData409.Down);            Assert.Equal(2.5f, io.KeysData409.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 410 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData410_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData410 = value;            Assert.Equal((byte)1, io.KeysData410.Down);            Assert.Equal(2.5f, io.KeysData410.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 411 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData411_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData411 = value;            Assert.Equal((byte)1, io.KeysData411.Down);            Assert.Equal(2.5f, io.KeysData411.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 412 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData412_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData412 = value;            Assert.Equal((byte)1, io.KeysData412.Down);            Assert.Equal(2.5f, io.KeysData412.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 413 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData413_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData413 = value;            Assert.Equal((byte)1, io.KeysData413.Down);            Assert.Equal(2.5f, io.KeysData413.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 414 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData414_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData414 = value;            Assert.Equal((byte)1, io.KeysData414.Down);            Assert.Equal(2.5f, io.KeysData414.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 415 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData415_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData415 = value;            Assert.Equal((byte)1, io.KeysData415.Down);            Assert.Equal(2.5f, io.KeysData415.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 416 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData416_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData416 = value;            Assert.Equal((byte)1, io.KeysData416.Down);            Assert.Equal(2.5f, io.KeysData416.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 417 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData417_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData417 = value;            Assert.Equal((byte)1, io.KeysData417.Down);            Assert.Equal(2.5f, io.KeysData417.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 418 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData418_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData418 = value;            Assert.Equal((byte)1, io.KeysData418.Down);            Assert.Equal(2.5f, io.KeysData418.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 419 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData419_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData419 = value;            Assert.Equal((byte)1, io.KeysData419.Down);            Assert.Equal(2.5f, io.KeysData419.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 420 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData420_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData420 = value;            Assert.Equal((byte)1, io.KeysData420.Down);            Assert.Equal(2.5f, io.KeysData420.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 421 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData421_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData421 = value;            Assert.Equal((byte)1, io.KeysData421.Down);            Assert.Equal(2.5f, io.KeysData421.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 422 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData422_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData422 = value;            Assert.Equal((byte)1, io.KeysData422.Down);            Assert.Equal(2.5f, io.KeysData422.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 423 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData423_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData423 = value;            Assert.Equal((byte)1, io.KeysData423.Down);            Assert.Equal(2.5f, io.KeysData423.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 424 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData424_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData424 = value;            Assert.Equal((byte)1, io.KeysData424.Down);            Assert.Equal(2.5f, io.KeysData424.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 425 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData425_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData425 = value;            Assert.Equal((byte)1, io.KeysData425.Down);            Assert.Equal(2.5f, io.KeysData425.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 426 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData426_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData426 = value;            Assert.Equal((byte)1, io.KeysData426.Down);            Assert.Equal(2.5f, io.KeysData426.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 427 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData427_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData427 = value;            Assert.Equal((byte)1, io.KeysData427.Down);            Assert.Equal(2.5f, io.KeysData427.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 428 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData428_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData428 = value;            Assert.Equal((byte)1, io.KeysData428.Down);            Assert.Equal(2.5f, io.KeysData428.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 429 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData429_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData429 = value;            Assert.Equal((byte)1, io.KeysData429.Down);            Assert.Equal(2.5f, io.KeysData429.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 430 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData430_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData430 = value;            Assert.Equal((byte)1, io.KeysData430.Down);            Assert.Equal(2.5f, io.KeysData430.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 431 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData431_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData431 = value;            Assert.Equal((byte)1, io.KeysData431.Down);            Assert.Equal(2.5f, io.KeysData431.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 432 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData432_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData432 = value;            Assert.Equal((byte)1, io.KeysData432.Down);            Assert.Equal(2.5f, io.KeysData432.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 433 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData433_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData433 = value;            Assert.Equal((byte)1, io.KeysData433.Down);            Assert.Equal(2.5f, io.KeysData433.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 434 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData434_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData434 = value;            Assert.Equal((byte)1, io.KeysData434.Down);            Assert.Equal(2.5f, io.KeysData434.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 435 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData435_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData435 = value;            Assert.Equal((byte)1, io.KeysData435.Down);            Assert.Equal(2.5f, io.KeysData435.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 436 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData436_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData436 = value;            Assert.Equal((byte)1, io.KeysData436.Down);            Assert.Equal(2.5f, io.KeysData436.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 437 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData437_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData437 = value;            Assert.Equal((byte)1, io.KeysData437.Down);            Assert.Equal(2.5f, io.KeysData437.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 438 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData438_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData438 = value;            Assert.Equal((byte)1, io.KeysData438.Down);            Assert.Equal(2.5f, io.KeysData438.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 439 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData439_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData439 = value;            Assert.Equal((byte)1, io.KeysData439.Down);            Assert.Equal(2.5f, io.KeysData439.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 440 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData440_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData440 = value;            Assert.Equal((byte)1, io.KeysData440.Down);            Assert.Equal(2.5f, io.KeysData440.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 441 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData441_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData441 = value;            Assert.Equal((byte)1, io.KeysData441.Down);            Assert.Equal(2.5f, io.KeysData441.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 442 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData442_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData442 = value;            Assert.Equal((byte)1, io.KeysData442.Down);            Assert.Equal(2.5f, io.KeysData442.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 443 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData443_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData443 = value;            Assert.Equal((byte)1, io.KeysData443.Down);            Assert.Equal(2.5f, io.KeysData443.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 444 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData444_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData444 = value;            Assert.Equal((byte)1, io.KeysData444.Down);            Assert.Equal(2.5f, io.KeysData444.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 445 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData445_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData445 = value;            Assert.Equal((byte)1, io.KeysData445.Down);            Assert.Equal(2.5f, io.KeysData445.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 446 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData446_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData446 = value;            Assert.Equal((byte)1, io.KeysData446.Down);            Assert.Equal(2.5f, io.KeysData446.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 447 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData447_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData447 = value;            Assert.Equal((byte)1, io.KeysData447.Down);            Assert.Equal(2.5f, io.KeysData447.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 448 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData448_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData448 = value;            Assert.Equal((byte)1, io.KeysData448.Down);            Assert.Equal(2.5f, io.KeysData448.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 449 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData449_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData449 = value;            Assert.Equal((byte)1, io.KeysData449.Down);            Assert.Equal(2.5f, io.KeysData449.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 450 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData450_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData450 = value;            Assert.Equal((byte)1, io.KeysData450.Down);            Assert.Equal(2.5f, io.KeysData450.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 451 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData451_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData451 = value;            Assert.Equal((byte)1, io.KeysData451.Down);            Assert.Equal(2.5f, io.KeysData451.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 452 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData452_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData452 = value;            Assert.Equal((byte)1, io.KeysData452.Down);            Assert.Equal(2.5f, io.KeysData452.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 453 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData453_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData453 = value;            Assert.Equal((byte)1, io.KeysData453.Down);            Assert.Equal(2.5f, io.KeysData453.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 454 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData454_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData454 = value;            Assert.Equal((byte)1, io.KeysData454.Down);            Assert.Equal(2.5f, io.KeysData454.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 455 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData455_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData455 = value;            Assert.Equal((byte)1, io.KeysData455.Down);            Assert.Equal(2.5f, io.KeysData455.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 456 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData456_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData456 = value;            Assert.Equal((byte)1, io.KeysData456.Down);            Assert.Equal(2.5f, io.KeysData456.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 457 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData457_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData457 = value;            Assert.Equal((byte)1, io.KeysData457.Down);            Assert.Equal(2.5f, io.KeysData457.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 458 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData458_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData458 = value;            Assert.Equal((byte)1, io.KeysData458.Down);            Assert.Equal(2.5f, io.KeysData458.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 459 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData459_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData459 = value;            Assert.Equal((byte)1, io.KeysData459.Down);            Assert.Equal(2.5f, io.KeysData459.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 460 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData460_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData460 = value;            Assert.Equal((byte)1, io.KeysData460.Down);            Assert.Equal(2.5f, io.KeysData460.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 461 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData461_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData461 = value;            Assert.Equal((byte)1, io.KeysData461.Down);            Assert.Equal(2.5f, io.KeysData461.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 462 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData462_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData462 = value;            Assert.Equal((byte)1, io.KeysData462.Down);            Assert.Equal(2.5f, io.KeysData462.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 463 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData463_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData463 = value;            Assert.Equal((byte)1, io.KeysData463.Down);            Assert.Equal(2.5f, io.KeysData463.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 464 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData464_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData464 = value;            Assert.Equal((byte)1, io.KeysData464.Down);            Assert.Equal(2.5f, io.KeysData464.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 465 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData465_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData465 = value;            Assert.Equal((byte)1, io.KeysData465.Down);            Assert.Equal(2.5f, io.KeysData465.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 466 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData466_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData466 = value;            Assert.Equal((byte)1, io.KeysData466.Down);            Assert.Equal(2.5f, io.KeysData466.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 467 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData467_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData467 = value;            Assert.Equal((byte)1, io.KeysData467.Down);            Assert.Equal(2.5f, io.KeysData467.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 468 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData468_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData468 = value;            Assert.Equal((byte)1, io.KeysData468.Down);            Assert.Equal(2.5f, io.KeysData468.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 469 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData469_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData469 = value;            Assert.Equal((byte)1, io.KeysData469.Down);            Assert.Equal(2.5f, io.KeysData469.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 470 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData470_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData470 = value;            Assert.Equal((byte)1, io.KeysData470.Down);            Assert.Equal(2.5f, io.KeysData470.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 471 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData471_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData471 = value;            Assert.Equal((byte)1, io.KeysData471.Down);            Assert.Equal(2.5f, io.KeysData471.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 472 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData472_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData472 = value;            Assert.Equal((byte)1, io.KeysData472.Down);            Assert.Equal(2.5f, io.KeysData472.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 473 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData473_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData473 = value;            Assert.Equal((byte)1, io.KeysData473.Down);            Assert.Equal(2.5f, io.KeysData473.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 474 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData474_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData474 = value;            Assert.Equal((byte)1, io.KeysData474.Down);            Assert.Equal(2.5f, io.KeysData474.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 475 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData475_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData475 = value;            Assert.Equal((byte)1, io.KeysData475.Down);            Assert.Equal(2.5f, io.KeysData475.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 476 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData476_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData476 = value;            Assert.Equal((byte)1, io.KeysData476.Down);            Assert.Equal(2.5f, io.KeysData476.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 477 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData477_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData477 = value;            Assert.Equal((byte)1, io.KeysData477.Down);            Assert.Equal(2.5f, io.KeysData477.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 478 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData478_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData478 = value;            Assert.Equal((byte)1, io.KeysData478.Down);            Assert.Equal(2.5f, io.KeysData478.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 479 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData479_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData479 = value;            Assert.Equal((byte)1, io.KeysData479.Down);            Assert.Equal(2.5f, io.KeysData479.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 480 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData480_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData480 = value;            Assert.Equal((byte)1, io.KeysData480.Down);            Assert.Equal(2.5f, io.KeysData480.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 481 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData481_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData481 = value;            Assert.Equal((byte)1, io.KeysData481.Down);            Assert.Equal(2.5f, io.KeysData481.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 482 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData482_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData482 = value;            Assert.Equal((byte)1, io.KeysData482.Down);            Assert.Equal(2.5f, io.KeysData482.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 483 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData483_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData483 = value;            Assert.Equal((byte)1, io.KeysData483.Down);            Assert.Equal(2.5f, io.KeysData483.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 484 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData484_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData484 = value;            Assert.Equal((byte)1, io.KeysData484.Down);            Assert.Equal(2.5f, io.KeysData484.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 485 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData485_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData485 = value;            Assert.Equal((byte)1, io.KeysData485.Down);            Assert.Equal(2.5f, io.KeysData485.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 486 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData486_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData486 = value;            Assert.Equal((byte)1, io.KeysData486.Down);            Assert.Equal(2.5f, io.KeysData486.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 487 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData487_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData487 = value;            Assert.Equal((byte)1, io.KeysData487.Down);            Assert.Equal(2.5f, io.KeysData487.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 488 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData488_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData488 = value;            Assert.Equal((byte)1, io.KeysData488.Down);            Assert.Equal(2.5f, io.KeysData488.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 489 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData489_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData489 = value;            Assert.Equal((byte)1, io.KeysData489.Down);            Assert.Equal(2.5f, io.KeysData489.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 490 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData490_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData490 = value;            Assert.Equal((byte)1, io.KeysData490.Down);            Assert.Equal(2.5f, io.KeysData490.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 491 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData491_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData491 = value;            Assert.Equal((byte)1, io.KeysData491.Down);            Assert.Equal(2.5f, io.KeysData491.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 492 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData492_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData492 = value;            Assert.Equal((byte)1, io.KeysData492.Down);            Assert.Equal(2.5f, io.KeysData492.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 493 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData493_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData493 = value;            Assert.Equal((byte)1, io.KeysData493.Down);            Assert.Equal(2.5f, io.KeysData493.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 494 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData494_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData494 = value;            Assert.Equal((byte)1, io.KeysData494.Down);            Assert.Equal(2.5f, io.KeysData494.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 495 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData495_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData495 = value;            Assert.Equal((byte)1, io.KeysData495.Down);            Assert.Equal(2.5f, io.KeysData495.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 496 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData496_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData496 = value;            Assert.Equal((byte)1, io.KeysData496.Down);            Assert.Equal(2.5f, io.KeysData496.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 497 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData497_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData497 = value;            Assert.Equal((byte)1, io.KeysData497.Down);            Assert.Equal(2.5f, io.KeysData497.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 498 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData498_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData498 = value;            Assert.Equal((byte)1, io.KeysData498.Down);            Assert.Equal(2.5f, io.KeysData498.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 499 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData499_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData499 = value;            Assert.Equal((byte)1, io.KeysData499.Down);            Assert.Equal(2.5f, io.KeysData499.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 500 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData500_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData500 = value;            Assert.Equal((byte)1, io.KeysData500.Down);            Assert.Equal(2.5f, io.KeysData500.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 501 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData501_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData501 = value;            Assert.Equal((byte)1, io.KeysData501.Down);            Assert.Equal(2.5f, io.KeysData501.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 502 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData502_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData502 = value;            Assert.Equal((byte)1, io.KeysData502.Down);            Assert.Equal(2.5f, io.KeysData502.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 503 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData503_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData503 = value;            Assert.Equal((byte)1, io.KeysData503.Down);            Assert.Equal(2.5f, io.KeysData503.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 504 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData504_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData504 = value;            Assert.Equal((byte)1, io.KeysData504.Down);            Assert.Equal(2.5f, io.KeysData504.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 505 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData505_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData505 = value;            Assert.Equal((byte)1, io.KeysData505.Down);            Assert.Equal(2.5f, io.KeysData505.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 506 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData506_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData506 = value;            Assert.Equal((byte)1, io.KeysData506.Down);            Assert.Equal(2.5f, io.KeysData506.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 507 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData507_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData507 = value;            Assert.Equal((byte)1, io.KeysData507.Down);            Assert.Equal(2.5f, io.KeysData507.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 508 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData508_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData508 = value;            Assert.Equal((byte)1, io.KeysData508.Down);            Assert.Equal(2.5f, io.KeysData508.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 509 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData509_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData509 = value;            Assert.Equal((byte)1, io.KeysData509.Down);            Assert.Equal(2.5f, io.KeysData509.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 510 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData510_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData510 = value;            Assert.Equal((byte)1, io.KeysData510.Down);            Assert.Equal(2.5f, io.KeysData510.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 511 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData511_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData511 = value;            Assert.Equal((byte)1, io.KeysData511.Down);            Assert.Equal(2.5f, io.KeysData511.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 512 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData512_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData512 = value;            Assert.Equal((byte)1, io.KeysData512.Down);            Assert.Equal(2.5f, io.KeysData512.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 513 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData513_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData513 = value;            Assert.Equal((byte)1, io.KeysData513.Down);            Assert.Equal(2.5f, io.KeysData513.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 514 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData514_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData514 = value;            Assert.Equal((byte)1, io.KeysData514.Down);            Assert.Equal(2.5f, io.KeysData514.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 515 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData515_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData515 = value;            Assert.Equal((byte)1, io.KeysData515.Down);            Assert.Equal(2.5f, io.KeysData515.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 516 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData516_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData516 = value;            Assert.Equal((byte)1, io.KeysData516.Down);            Assert.Equal(2.5f, io.KeysData516.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 517 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData517_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData517 = value;            Assert.Equal((byte)1, io.KeysData517.Down);            Assert.Equal(2.5f, io.KeysData517.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 518 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData518_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData518 = value;            Assert.Equal((byte)1, io.KeysData518.Down);            Assert.Equal(2.5f, io.KeysData518.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 519 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData519_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData519 = value;            Assert.Equal((byte)1, io.KeysData519.Down);            Assert.Equal(2.5f, io.KeysData519.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 520 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData520_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData520 = value;            Assert.Equal((byte)1, io.KeysData520.Down);            Assert.Equal(2.5f, io.KeysData520.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 521 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData521_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData521 = value;            Assert.Equal((byte)1, io.KeysData521.Down);            Assert.Equal(2.5f, io.KeysData521.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 522 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData522_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData522 = value;            Assert.Equal((byte)1, io.KeysData522.Down);            Assert.Equal(2.5f, io.KeysData522.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 523 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData523_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData523 = value;            Assert.Equal((byte)1, io.KeysData523.Down);            Assert.Equal(2.5f, io.KeysData523.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 524 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData524_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData524 = value;            Assert.Equal((byte)1, io.KeysData524.Down);            Assert.Equal(2.5f, io.KeysData524.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 525 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData525_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData525 = value;            Assert.Equal((byte)1, io.KeysData525.Down);            Assert.Equal(2.5f, io.KeysData525.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 526 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData526_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData526 = value;            Assert.Equal((byte)1, io.KeysData526.Down);            Assert.Equal(2.5f, io.KeysData526.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 527 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData527_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData527 = value;            Assert.Equal((byte)1, io.KeysData527.Down);            Assert.Equal(2.5f, io.KeysData527.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 528 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData528_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData528 = value;            Assert.Equal((byte)1, io.KeysData528.Down);            Assert.Equal(2.5f, io.KeysData528.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 529 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData529_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData529 = value;            Assert.Equal((byte)1, io.KeysData529.Down);            Assert.Equal(2.5f, io.KeysData529.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 530 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData530_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData530 = value;            Assert.Equal((byte)1, io.KeysData530.Down);            Assert.Equal(2.5f, io.KeysData530.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 531 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData531_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData531 = value;            Assert.Equal((byte)1, io.KeysData531.Down);            Assert.Equal(2.5f, io.KeysData531.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 532 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData532_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData532 = value;            Assert.Equal((byte)1, io.KeysData532.Down);            Assert.Equal(2.5f, io.KeysData532.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 533 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData533_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData533 = value;            Assert.Equal((byte)1, io.KeysData533.Down);            Assert.Equal(2.5f, io.KeysData533.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 534 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData534_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData534 = value;            Assert.Equal((byte)1, io.KeysData534.Down);            Assert.Equal(2.5f, io.KeysData534.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 535 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData535_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData535 = value;            Assert.Equal((byte)1, io.KeysData535.Down);            Assert.Equal(2.5f, io.KeysData535.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 536 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData536_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData536 = value;            Assert.Equal((byte)1, io.KeysData536.Down);            Assert.Equal(2.5f, io.KeysData536.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 537 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData537_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData537 = value;            Assert.Equal((byte)1, io.KeysData537.Down);            Assert.Equal(2.5f, io.KeysData537.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 538 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData538_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData538 = value;            Assert.Equal((byte)1, io.KeysData538.Down);            Assert.Equal(2.5f, io.KeysData538.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 539 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData539_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData539 = value;            Assert.Equal((byte)1, io.KeysData539.Down);            Assert.Equal(2.5f, io.KeysData539.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 540 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData540_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData540 = value;            Assert.Equal((byte)1, io.KeysData540.Down);            Assert.Equal(2.5f, io.KeysData540.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 541 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData541_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData541 = value;            Assert.Equal((byte)1, io.KeysData541.Down);            Assert.Equal(2.5f, io.KeysData541.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 542 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData542_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData542 = value;            Assert.Equal((byte)1, io.KeysData542.Down);            Assert.Equal(2.5f, io.KeysData542.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 543 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData543_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData543 = value;            Assert.Equal((byte)1, io.KeysData543.Down);            Assert.Equal(2.5f, io.KeysData543.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 544 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData544_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData544 = value;            Assert.Equal((byte)1, io.KeysData544.Down);            Assert.Equal(2.5f, io.KeysData544.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 545 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData545_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData545 = value;            Assert.Equal((byte)1, io.KeysData545.Down);            Assert.Equal(2.5f, io.KeysData545.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 546 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData546_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData546 = value;            Assert.Equal((byte)1, io.KeysData546.Down);            Assert.Equal(2.5f, io.KeysData546.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 547 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData547_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData547 = value;            Assert.Equal((byte)1, io.KeysData547.Down);            Assert.Equal(2.5f, io.KeysData547.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 548 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData548_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData548 = value;            Assert.Equal((byte)1, io.KeysData548.Down);            Assert.Equal(2.5f, io.KeysData548.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 549 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData549_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData549 = value;            Assert.Equal((byte)1, io.KeysData549.Down);            Assert.Equal(2.5f, io.KeysData549.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 550 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData550_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData550 = value;            Assert.Equal((byte)1, io.KeysData550.Down);            Assert.Equal(2.5f, io.KeysData550.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 551 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData551_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData551 = value;            Assert.Equal((byte)1, io.KeysData551.Down);            Assert.Equal(2.5f, io.KeysData551.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 552 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData552_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData552 = value;            Assert.Equal((byte)1, io.KeysData552.Down);            Assert.Equal(2.5f, io.KeysData552.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 553 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData553_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData553 = value;            Assert.Equal((byte)1, io.KeysData553.Down);            Assert.Equal(2.5f, io.KeysData553.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 554 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData554_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData554 = value;            Assert.Equal((byte)1, io.KeysData554.Down);            Assert.Equal(2.5f, io.KeysData554.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 555 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData555_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData555 = value;            Assert.Equal((byte)1, io.KeysData555.Down);            Assert.Equal(2.5f, io.KeysData555.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 556 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData556_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData556 = value;            Assert.Equal((byte)1, io.KeysData556.Down);            Assert.Equal(2.5f, io.KeysData556.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 557 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData557_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData557 = value;            Assert.Equal((byte)1, io.KeysData557.Down);            Assert.Equal(2.5f, io.KeysData557.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 558 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData558_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData558 = value;            Assert.Equal((byte)1, io.KeysData558.Down);            Assert.Equal(2.5f, io.KeysData558.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 559 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData559_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData559 = value;            Assert.Equal((byte)1, io.KeysData559.Down);            Assert.Equal(2.5f, io.KeysData559.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 560 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData560_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData560 = value;            Assert.Equal((byte)1, io.KeysData560.Down);            Assert.Equal(2.5f, io.KeysData560.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 561 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData561_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData561 = value;            Assert.Equal((byte)1, io.KeysData561.Down);            Assert.Equal(2.5f, io.KeysData561.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 562 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData562_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData562 = value;            Assert.Equal((byte)1, io.KeysData562.Down);            Assert.Equal(2.5f, io.KeysData562.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 563 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData563_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData563 = value;            Assert.Equal((byte)1, io.KeysData563.Down);            Assert.Equal(2.5f, io.KeysData563.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 564 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData564_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData564 = value;            Assert.Equal((byte)1, io.KeysData564.Down);            Assert.Equal(2.5f, io.KeysData564.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 565 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData565_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData565 = value;            Assert.Equal((byte)1, io.KeysData565.Down);            Assert.Equal(2.5f, io.KeysData565.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 566 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData566_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData566 = value;            Assert.Equal((byte)1, io.KeysData566.Down);            Assert.Equal(2.5f, io.KeysData566.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 567 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData567_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData567 = value;            Assert.Equal((byte)1, io.KeysData567.Down);            Assert.Equal(2.5f, io.KeysData567.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 568 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData568_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData568 = value;            Assert.Equal((byte)1, io.KeysData568.Down);            Assert.Equal(2.5f, io.KeysData568.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 569 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData569_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData569 = value;            Assert.Equal((byte)1, io.KeysData569.Down);            Assert.Equal(2.5f, io.KeysData569.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 570 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData570_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData570 = value;            Assert.Equal((byte)1, io.KeysData570.Down);            Assert.Equal(2.5f, io.KeysData570.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 571 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData571_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData571 = value;            Assert.Equal((byte)1, io.KeysData571.Down);            Assert.Equal(2.5f, io.KeysData571.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 572 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData572_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData572 = value;            Assert.Equal((byte)1, io.KeysData572.Down);            Assert.Equal(2.5f, io.KeysData572.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 573 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData573_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData573 = value;            Assert.Equal((byte)1, io.KeysData573.Down);            Assert.Equal(2.5f, io.KeysData573.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 574 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData574_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData574 = value;            Assert.Equal((byte)1, io.KeysData574.Down);            Assert.Equal(2.5f, io.KeysData574.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 575 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData575_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData575 = value;            Assert.Equal((byte)1, io.KeysData575.Down);            Assert.Equal(2.5f, io.KeysData575.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 576 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData576_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData576 = value;            Assert.Equal((byte)1, io.KeysData576.Down);            Assert.Equal(2.5f, io.KeysData576.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 577 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData577_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData577 = value;            Assert.Equal((byte)1, io.KeysData577.Down);            Assert.Equal(2.5f, io.KeysData577.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 578 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData578_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData578 = value;            Assert.Equal((byte)1, io.KeysData578.Down);            Assert.Equal(2.5f, io.KeysData578.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 579 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData579_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData579 = value;            Assert.Equal((byte)1, io.KeysData579.Down);            Assert.Equal(2.5f, io.KeysData579.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 580 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData580_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData580 = value;            Assert.Equal((byte)1, io.KeysData580.Down);            Assert.Equal(2.5f, io.KeysData580.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 581 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData581_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData581 = value;            Assert.Equal((byte)1, io.KeysData581.Down);            Assert.Equal(2.5f, io.KeysData581.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 582 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData582_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData582 = value;            Assert.Equal((byte)1, io.KeysData582.Down);            Assert.Equal(2.5f, io.KeysData582.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 583 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData583_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData583 = value;            Assert.Equal((byte)1, io.KeysData583.Down);            Assert.Equal(2.5f, io.KeysData583.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 584 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData584_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData584 = value;            Assert.Equal((byte)1, io.KeysData584.Down);            Assert.Equal(2.5f, io.KeysData584.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 585 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData585_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData585 = value;            Assert.Equal((byte)1, io.KeysData585.Down);            Assert.Equal(2.5f, io.KeysData585.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 586 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData586_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData586 = value;            Assert.Equal((byte)1, io.KeysData586.Down);            Assert.Equal(2.5f, io.KeysData586.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 587 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData587_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData587 = value;            Assert.Equal((byte)1, io.KeysData587.Down);            Assert.Equal(2.5f, io.KeysData587.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 588 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData588_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData588 = value;            Assert.Equal((byte)1, io.KeysData588.Down);            Assert.Equal(2.5f, io.KeysData588.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 589 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData589_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData589 = value;            Assert.Equal((byte)1, io.KeysData589.Down);            Assert.Equal(2.5f, io.KeysData589.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 590 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData590_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData590 = value;            Assert.Equal((byte)1, io.KeysData590.Down);            Assert.Equal(2.5f, io.KeysData590.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 591 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData591_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData591 = value;            Assert.Equal((byte)1, io.KeysData591.Down);            Assert.Equal(2.5f, io.KeysData591.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 592 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData592_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData592 = value;            Assert.Equal((byte)1, io.KeysData592.Down);            Assert.Equal(2.5f, io.KeysData592.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 593 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData593_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData593 = value;            Assert.Equal((byte)1, io.KeysData593.Down);            Assert.Equal(2.5f, io.KeysData593.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 594 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData594_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData594 = value;            Assert.Equal((byte)1, io.KeysData594.Down);            Assert.Equal(2.5f, io.KeysData594.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 595 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData595_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData595 = value;            Assert.Equal((byte)1, io.KeysData595.Down);            Assert.Equal(2.5f, io.KeysData595.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 596 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData596_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData596 = value;            Assert.Equal((byte)1, io.KeysData596.Down);            Assert.Equal(2.5f, io.KeysData596.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 597 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData597_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData597 = value;            Assert.Equal((byte)1, io.KeysData597.Down);            Assert.Equal(2.5f, io.KeysData597.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 598 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData598_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData598 = value;            Assert.Equal((byte)1, io.KeysData598.Down);            Assert.Equal(2.5f, io.KeysData598.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 599 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData599_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData599 = value;            Assert.Equal((byte)1, io.KeysData599.Down);            Assert.Equal(2.5f, io.KeysData599.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 600 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData600_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData600 = value;            Assert.Equal((byte)1, io.KeysData600.Down);            Assert.Equal(2.5f, io.KeysData600.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 601 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData601_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData601 = value;            Assert.Equal((byte)1, io.KeysData601.Down);            Assert.Equal(2.5f, io.KeysData601.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 602 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData602_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData602 = value;            Assert.Equal((byte)1, io.KeysData602.Down);            Assert.Equal(2.5f, io.KeysData602.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 603 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData603_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData603 = value;            Assert.Equal((byte)1, io.KeysData603.Down);            Assert.Equal(2.5f, io.KeysData603.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 604 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData604_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData604 = value;            Assert.Equal((byte)1, io.KeysData604.Down);            Assert.Equal(2.5f, io.KeysData604.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 605 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData605_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData605 = value;            Assert.Equal((byte)1, io.KeysData605.Down);            Assert.Equal(2.5f, io.KeysData605.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 606 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData606_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData606 = value;            Assert.Equal((byte)1, io.KeysData606.Down);            Assert.Equal(2.5f, io.KeysData606.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 607 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData607_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData607 = value;            Assert.Equal((byte)1, io.KeysData607.Down);            Assert.Equal(2.5f, io.KeysData607.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 608 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData608_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData608 = value;            Assert.Equal((byte)1, io.KeysData608.Down);            Assert.Equal(2.5f, io.KeysData608.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 609 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData609_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData609 = value;            Assert.Equal((byte)1, io.KeysData609.Down);            Assert.Equal(2.5f, io.KeysData609.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 610 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData610_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData610 = value;            Assert.Equal((byte)1, io.KeysData610.Down);            Assert.Equal(2.5f, io.KeysData610.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 611 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData611_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData611 = value;            Assert.Equal((byte)1, io.KeysData611.Down);            Assert.Equal(2.5f, io.KeysData611.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 612 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData612_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData612 = value;            Assert.Equal((byte)1, io.KeysData612.Down);            Assert.Equal(2.5f, io.KeysData612.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 613 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData613_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData613 = value;            Assert.Equal((byte)1, io.KeysData613.Down);            Assert.Equal(2.5f, io.KeysData613.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 614 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData614_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData614 = value;            Assert.Equal((byte)1, io.KeysData614.Down);            Assert.Equal(2.5f, io.KeysData614.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 615 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData615_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData615 = value;            Assert.Equal((byte)1, io.KeysData615.Down);            Assert.Equal(2.5f, io.KeysData615.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 616 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData616_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData616 = value;            Assert.Equal((byte)1, io.KeysData616.Down);            Assert.Equal(2.5f, io.KeysData616.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 617 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData617_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData617 = value;            Assert.Equal((byte)1, io.KeysData617.Down);            Assert.Equal(2.5f, io.KeysData617.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 618 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData618_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData618 = value;            Assert.Equal((byte)1, io.KeysData618.Down);            Assert.Equal(2.5f, io.KeysData618.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 619 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData619_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData619 = value;            Assert.Equal((byte)1, io.KeysData619.Down);            Assert.Equal(2.5f, io.KeysData619.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 620 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData620_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData620 = value;            Assert.Equal((byte)1, io.KeysData620.Down);            Assert.Equal(2.5f, io.KeysData620.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 621 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData621_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData621 = value;            Assert.Equal((byte)1, io.KeysData621.Down);            Assert.Equal(2.5f, io.KeysData621.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 622 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData622_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData622 = value;            Assert.Equal((byte)1, io.KeysData622.Down);            Assert.Equal(2.5f, io.KeysData622.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 623 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData623_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData623 = value;            Assert.Equal((byte)1, io.KeysData623.Down);            Assert.Equal(2.5f, io.KeysData623.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 624 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData624_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData624 = value;            Assert.Equal((byte)1, io.KeysData624.Down);            Assert.Equal(2.5f, io.KeysData624.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 625 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData625_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData625 = value;            Assert.Equal((byte)1, io.KeysData625.Down);            Assert.Equal(2.5f, io.KeysData625.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 626 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData626_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData626 = value;            Assert.Equal((byte)1, io.KeysData626.Down);            Assert.Equal(2.5f, io.KeysData626.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 627 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData627_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData627 = value;            Assert.Equal((byte)1, io.KeysData627.Down);            Assert.Equal(2.5f, io.KeysData627.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 628 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData628_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData628 = value;            Assert.Equal((byte)1, io.KeysData628.Down);            Assert.Equal(2.5f, io.KeysData628.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 629 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData629_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData629 = value;            Assert.Equal((byte)1, io.KeysData629.Down);            Assert.Equal(2.5f, io.KeysData629.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 630 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData630_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData630 = value;            Assert.Equal((byte)1, io.KeysData630.Down);            Assert.Equal(2.5f, io.KeysData630.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 631 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData631_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData631 = value;            Assert.Equal((byte)1, io.KeysData631.Down);            Assert.Equal(2.5f, io.KeysData631.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 632 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData632_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData632 = value;            Assert.Equal((byte)1, io.KeysData632.Down);            Assert.Equal(2.5f, io.KeysData632.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 633 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData633_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData633 = value;            Assert.Equal((byte)1, io.KeysData633.Down);            Assert.Equal(2.5f, io.KeysData633.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 634 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData634_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData634 = value;            Assert.Equal((byte)1, io.KeysData634.Down);            Assert.Equal(2.5f, io.KeysData634.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 635 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData635_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData635 = value;            Assert.Equal((byte)1, io.KeysData635.Down);            Assert.Equal(2.5f, io.KeysData635.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 636 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData636_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData636 = value;            Assert.Equal((byte)1, io.KeysData636.Down);            Assert.Equal(2.5f, io.KeysData636.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 637 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData637_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData637 = value;            Assert.Equal((byte)1, io.KeysData637.Down);            Assert.Equal(2.5f, io.KeysData637.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 638 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData638_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData638 = value;            Assert.Equal((byte)1, io.KeysData638.Down);            Assert.Equal(2.5f, io.KeysData638.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 639 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData639_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData639 = value;            Assert.Equal((byte)1, io.KeysData639.Down);            Assert.Equal(2.5f, io.KeysData639.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 640 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData640_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData640 = value;            Assert.Equal((byte)1, io.KeysData640.Down);            Assert.Equal(2.5f, io.KeysData640.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 641 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData641_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData641 = value;            Assert.Equal((byte)1, io.KeysData641.Down);            Assert.Equal(2.5f, io.KeysData641.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 642 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData642_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData642 = value;            Assert.Equal((byte)1, io.KeysData642.Down);            Assert.Equal(2.5f, io.KeysData642.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 643 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData643_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData643 = value;            Assert.Equal((byte)1, io.KeysData643.Down);            Assert.Equal(2.5f, io.KeysData643.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 644 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData644_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData644 = value;            Assert.Equal((byte)1, io.KeysData644.Down);            Assert.Equal(2.5f, io.KeysData644.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 645 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData645_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData645 = value;            Assert.Equal((byte)1, io.KeysData645.Down);            Assert.Equal(2.5f, io.KeysData645.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 646 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData646_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData646 = value;            Assert.Equal((byte)1, io.KeysData646.Down);            Assert.Equal(2.5f, io.KeysData646.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 647 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData647_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData647 = value;            Assert.Equal((byte)1, io.KeysData647.Down);            Assert.Equal(2.5f, io.KeysData647.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 648 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData648_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData648 = value;            Assert.Equal((byte)1, io.KeysData648.Down);            Assert.Equal(2.5f, io.KeysData648.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 649 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData649_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData649 = value;            Assert.Equal((byte)1, io.KeysData649.Down);            Assert.Equal(2.5f, io.KeysData649.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 650 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData650_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData650 = value;            Assert.Equal((byte)1, io.KeysData650.Down);            Assert.Equal(2.5f, io.KeysData650.AnalogValue);        }
        /// <summary>
        ///     Tests that keys data 651 set and get returns correct value
        /// </summary>
        [Fact]        public void KeysData651_SetAndGet_ReturnsCorrectValue()        {            ImGuiIo io = new ImGuiIo();            ImGuiKeyData value = new ImGuiKeyData();            value.Down = (byte)1;            value.AnalogValue = 2.5f;            io.KeysData651 = value;            Assert.Equal((byte)1, io.KeysData651.Down);            Assert.Equal(2.5f, io.KeysData651.AnalogValue);        }
    }
}
