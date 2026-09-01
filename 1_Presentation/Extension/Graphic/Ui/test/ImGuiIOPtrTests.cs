// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIOPtrTests.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui io ptr tests class
    /// </summary>
    public class ImGuiIOPtrTests
    {
        /// <summary>
        ///     Tests that keys data getter throws when the field is absent
        /// </summary>
        [Fact]
        public void KeysData_Getter_ThrowsForMissingField()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Assert.Throws<ArgumentException>(() => { List<ImGuiKeyData> data = ptr.KeysData; });
        }

        /// <summary>
        ///     Tests that mouse clicked pos getter throws when the field is absent
        /// </summary>
        [Fact]
        public void MouseClickedPos_Getter_ThrowsForMissingField()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Assert.Throws<ArgumentException>(() => { List<Vector2F> pos = ptr.MouseClickedPos; });
        }

        /// <summary>
        ///     Tests that mouse drag max distance abs getter throws when the field is absent
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceAbs_Getter_ThrowsForMissingField()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Assert.Throws<ArgumentException>(() => { List<Vector2F> abs = ptr.MouseDragMaxDistanceAbs; });
        }

        /// <summary>
        ///     Creates a source instance
        /// </summary>
        private static ImGuiIo CreateSource()
        {
            ImGuiIo io = new ImGuiIo();
            io.KeyMap = new int[652];
            io.KeysDown = new byte[652];
            io.NavInputs = new float[16];
            io.MouseDown = new byte[5];
            io.MouseClickedTime = new double[5];
            io.MouseClicked = new byte[5];
            io.MouseDoubleClicked = new byte[5];
            io.MouseClickedCount = new ushort[5];
            io.MouseClickedLastCount = new ushort[5];
            io.MouseReleased = new byte[5];
            io.MouseDownOwned = new byte[5];
            io.MouseDownOwnedUnlessPopupClose = new byte[5];
            io.MouseDownDuration = new float[5];
            io.MouseDownDurationPrev = new float[5];
            io.MouseDragMaxDistanceSqr = new float[5];
            return io;
        }

        /// <summary>
        ///     Creates a pointer instance
        /// </summary>
        private static ImGuiIoPtr CreatePtr()
        {
            return new ImGuiIoPtr(CreateSource());
        }

        /// <summary>
        ///     Allocates a native string pointer
        /// </summary>
        private static IntPtr StrPtr(string s)
        {
            byte[] b = Encoding.UTF8.GetBytes(s + "\0");
            IntPtr p = Marshal.AllocHGlobal(b.Length);
            Marshal.Copy(b, 0, p, b.Length);
            return p;
        }

        /// <summary>
        ///     ConfigFlags_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void ConfigFlags_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.ConfigFlags = (ImGuiConfigFlags)1;
            Assert.Equal((ImGuiConfigFlags)1, ptr.ConfigFlags);
        }

        /// <summary>
        ///     BackendFlags_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendFlags_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.BackendFlags = (ImGuiBackendFlags)2;
            Assert.Equal((ImGuiBackendFlags)2, ptr.BackendFlags);
        }

        /// <summary>
        ///     DeltaTime_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void DeltaTime_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.DeltaTime = 1.5f;
            Assert.Equal(1.5f, ptr.DeltaTime);
        }

        /// <summary>
        ///     UserData_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void UserData_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.UserData = new IntPtr(7);
            Assert.Equal(new IntPtr(7), ptr.UserData);
        }

        /// <summary>
        ///     FontGlobalScale_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void FontGlobalScale_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.FontGlobalScale = 2.5f;
            Assert.Equal(2.5f, ptr.FontGlobalScale);
        }

        /// <summary>
        ///     BackendPlatformUserData_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendPlatformUserData_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.BackendPlatformUserData = new IntPtr(8);
            Assert.Equal(new IntPtr(8), ptr.BackendPlatformUserData);
        }

        /// <summary>
        ///     BackendRendererUserData_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendRendererUserData_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.BackendRendererUserData = new IntPtr(9);
            Assert.Equal(new IntPtr(9), ptr.BackendRendererUserData);
        }

        /// <summary>
        ///     BackendLanguageUserData_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendLanguageUserData_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.BackendLanguageUserData = new IntPtr(10);
            Assert.Equal(new IntPtr(10), ptr.BackendLanguageUserData);
        }

        /// <summary>
        ///     GetClipboardTextFn_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void GetClipboardTextFn_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.GetClipboardTextFn = new IntPtr(11);
            Assert.Equal(new IntPtr(11), ptr.GetClipboardTextFn);
        }

        /// <summary>
        ///     SetClipboardTextFn_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void SetClipboardTextFn_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.SetClipboardTextFn = new IntPtr(12);
            Assert.Equal(new IntPtr(12), ptr.SetClipboardTextFn);
        }

        /// <summary>
        ///     ClipboardUserData_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void ClipboardUserData_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.ClipboardUserData = new IntPtr(13);
            Assert.Equal(new IntPtr(13), ptr.ClipboardUserData);
        }

        /// <summary>
        ///     SetPlatformImeDataFn_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void SetPlatformImeDataFn_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.SetPlatformImeDataFn = new IntPtr(14);
            Assert.Equal(new IntPtr(14), ptr.SetPlatformImeDataFn);
        }

        /// <summary>
        ///     UnusedPadding_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void UnusedPadding_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.UnusedPadding = new IntPtr(15);
            Assert.Equal(new IntPtr(15), ptr.UnusedPadding);
        }

        /// <summary>
        ///     ConfigDockingWithShift_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void ConfigDockingWithShift_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.ConfigDockingWithShift = true;
            Assert.True(ptr.ConfigDockingWithShift);
        }

        /// <summary>
        ///     WantCaptureMouse_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void WantCaptureMouse_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.WantCaptureMouse = true;
            Assert.True(ptr.WantCaptureMouse);
        }

        /// <summary>
        ///     WantCaptureKeyboard_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void WantCaptureKeyboard_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.WantCaptureKeyboard = true;
            Assert.True(ptr.WantCaptureKeyboard);
        }

        /// <summary>
        ///     WantTextInput_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void WantTextInput_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.WantTextInput = true;
            Assert.True(ptr.WantTextInput);
        }

        /// <summary>
        ///     WantSetMousePos_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void WantSetMousePos_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.WantSetMousePos = true;
            Assert.True(ptr.WantSetMousePos);
        }

        /// <summary>
        ///     WantSaveIniSettings_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void WantSaveIniSettings_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.WantSaveIniSettings = true;
            Assert.True(ptr.WantSaveIniSettings);
        }

        /// <summary>
        ///     NavActive_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void NavActive_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.NavActive = true;
            Assert.True(ptr.NavActive);
        }

        /// <summary>
        ///     NavVisible_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void NavVisible_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.NavVisible = true;
            Assert.True(ptr.NavVisible);
        }

        /// <summary>
        ///     Framerate_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void Framerate_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.Framerate = 60f;
            Assert.Equal(60f, ptr.Framerate);
        }

        /// <summary>
        ///     MetricsRenderVertices_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MetricsRenderVertices_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MetricsRenderVertices = 100;
            Assert.Equal(100, ptr.MetricsRenderVertices);
        }

        /// <summary>
        ///     MetricsRenderIndices_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MetricsRenderIndices_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MetricsRenderIndices = 101;
            Assert.Equal(101, ptr.MetricsRenderIndices);
        }

        /// <summary>
        ///     MetricsRenderWindows_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MetricsRenderWindows_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MetricsRenderWindows = 102;
            Assert.Equal(102, ptr.MetricsRenderWindows);
        }

        /// <summary>
        ///     MetricsActiveWindows_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MetricsActiveWindows_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MetricsActiveWindows = 103;
            Assert.Equal(103, ptr.MetricsActiveWindows);
        }

        /// <summary>
        ///     MetricsActiveAllocations_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MetricsActiveAllocations_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MetricsActiveAllocations = 104;
            Assert.Equal(104, ptr.MetricsActiveAllocations);
        }

        /// <summary>
        ///     MouseWheel_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseWheel_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MouseWheel = 1.5f;
            Assert.Equal(1.5f, ptr.MouseWheel);
        }

        /// <summary>
        ///     MouseWheelH_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseWheelH_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MouseWheelH = 2.5f;
            Assert.Equal(2.5f, ptr.MouseWheelH);
        }

        /// <summary>
        ///     MouseHoveredViewport_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseHoveredViewport_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.MouseHoveredViewport = 3u;
            Assert.Equal(3u, ptr.MouseHoveredViewport);
        }

        /// <summary>
        ///     KeyCtrl_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeyCtrl_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.KeyCtrl = true;
            Assert.True(ptr.KeyCtrl);
        }

        /// <summary>
        ///     KeyShift_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeyShift_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.KeyShift = true;
            Assert.True(ptr.KeyShift);
        }

        /// <summary>
        ///     KeyAlt_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeyAlt_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.KeyAlt = true;
            Assert.True(ptr.KeyAlt);
        }

        /// <summary>
        ///     KeySuper_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeySuper_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.KeySuper = true;
            Assert.True(ptr.KeySuper);
        }

        /// <summary>
        ///     KeyMods_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeyMods_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.KeyMods = (ImGuiKey)1;
            Assert.Equal((ImGuiKey)1, ptr.KeyMods);
        }

        /// <summary>
        ///     PenPressure_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void PenPressure_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.PenPressure = 0.5f;
            Assert.Equal(0.5f, ptr.PenPressure);
        }

        /// <summary>
        ///     AppFocusLost_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void AppFocusLost_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.AppFocusLost = true;
            Assert.True(ptr.AppFocusLost);
        }

        /// <summary>
        ///     AppAcceptingEvents_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void AppAcceptingEvents_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.AppAcceptingEvents = true;
            Assert.True(ptr.AppAcceptingEvents);
        }

        /// <summary>
        ///     BackendUsingLegacyKeyArrays_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendUsingLegacyKeyArrays_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.BackendUsingLegacyKeyArrays = 3;
            Assert.Equal(3, ptr.BackendUsingLegacyKeyArrays);
        }

        /// <summary>
        ///     BackendUsingLegacyNavInputArray_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendUsingLegacyNavInputArray_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.BackendUsingLegacyNavInputArray = true;
            Assert.True(ptr.BackendUsingLegacyNavInputArray);
        }

        /// <summary>
        ///     InputQueueSurrogate_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void InputQueueSurrogate_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.InputQueueSurrogate = 9;
            Assert.Equal((ushort)9, ptr.InputQueueSurrogate);
        }

        /// <summary>
        ///     WantCaptureMouseUnlessPopupClose_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void WantCaptureMouseUnlessPopupClose_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ptr.WantCaptureMouseUnlessPopupClose = true;
            Assert.True(ptr.WantCaptureMouseUnlessPopupClose);
        }

        /// <summary>
        ///     IniSavingRate_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void IniSavingRate_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.IniSavingRate;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     MouseDoubleClickTime_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void MouseDoubleClickTime_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.MouseDoubleClickTime;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     MouseDoubleClickMaxDist_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void MouseDoubleClickMaxDist_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.MouseDoubleClickMaxDist;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     MouseDragThreshold_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void MouseDragThreshold_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.MouseDragThreshold;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     KeyRepeatDelay_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void KeyRepeatDelay_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.KeyRepeatDelay;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     KeyRepeatRate_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void KeyRepeatRate_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.KeyRepeatRate;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     HoverDelayNormal_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void HoverDelayNormal_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.HoverDelayNormal;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     HoverDelayShort_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void HoverDelayShort_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.HoverDelayShort;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigMemoryCompactTimer_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigMemoryCompactTimer_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigMemoryCompactTimer;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     FontAllowUserScaling_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void FontAllowUserScaling_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.FontAllowUserScaling;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigDockingNoSplit_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigDockingNoSplit_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigDockingNoSplit;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigDockingAlwaysTabBar_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigDockingAlwaysTabBar_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigDockingAlwaysTabBar;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigDockingTransparentPayload_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigDockingTransparentPayload_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigDockingTransparentPayload;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigViewportsNoAutoMerge_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigViewportsNoAutoMerge_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigViewportsNoAutoMerge;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigViewportsNoTaskBarIcon_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigViewportsNoTaskBarIcon_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigViewportsNoTaskBarIcon;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigViewportsNoDecoration_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigViewportsNoDecoration_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigViewportsNoDecoration;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigViewportsNoDefaultParent_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigViewportsNoDefaultParent_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigViewportsNoDefaultParent;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     MouseDrawCursor_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void MouseDrawCursor_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.MouseDrawCursor;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigMacOsxBehaviors_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigMacOsxBehaviors_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigMacOsxBehaviors;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigInputTrickleEventQueue_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigInputTrickleEventQueue_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigInputTrickleEventQueue;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigInputTextCursorBlink_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigInputTextCursorBlink_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigInputTextCursorBlink;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigInputTextEnterKeepActive_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigInputTextEnterKeepActive_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigInputTextEnterKeepActive;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigDragClickToInputText_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigDragClickToInputText_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigDragClickToInputText;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigWindowsResizeFromEdges_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigWindowsResizeFromEdges_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigWindowsResizeFromEdges;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     ConfigWindowsMoveFromTitleBarOnly_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void ConfigWindowsMoveFromTitleBarOnly_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.ConfigWindowsMoveFromTitleBarOnly;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     DisplaySize_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void DisplaySize_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Vector2F value = new Vector2F(3f, 4f);
            ptr.DisplaySize = value;
            Assert.Equal(3f, ptr.DisplaySize.X);
            Assert.Equal(4f, ptr.DisplaySize.Y);
        }

        /// <summary>
        ///     DisplayFramebufferScale_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void DisplayFramebufferScale_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Vector2F value = new Vector2F(3f, 4f);
            ptr.DisplayFramebufferScale = value;
            Assert.Equal(3f, ptr.DisplayFramebufferScale.X);
            Assert.Equal(4f, ptr.DisplayFramebufferScale.Y);
        }

        /// <summary>
        ///     MousePos_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MousePos_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Vector2F value = new Vector2F(3f, 4f);
            ptr.MousePos = value;
            Assert.Equal(3f, ptr.MousePos.X);
            Assert.Equal(4f, ptr.MousePos.Y);
        }

        /// <summary>
        ///     MousePosPrev_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MousePosPrev_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Vector2F value = new Vector2F(3f, 4f);
            ptr.MousePosPrev = value;
            Assert.Equal(3f, ptr.MousePosPrev.X);
            Assert.Equal(4f, ptr.MousePosPrev.Y);
        }

        /// <summary>
        ///     MouseDelta_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDelta_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            Vector2F value = new Vector2F(3f, 4f);
            ptr.MouseDelta = value;
            Assert.Equal(3f, ptr.MouseDelta.X);
            Assert.Equal(4f, ptr.MouseDelta.Y);
        }

        /// <summary>
        ///     BackendPlatformName_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void BackendPlatformName_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            IntPtr p = StrPtr("platform");
            ptr.BackendPlatformName = new NullTerminatedString(p);
            Assert.NotEqual(IntPtr.Zero, ptr.BackendPlatformName.Data);
        }

        /// <summary>
        ///     BackendRendererName_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void BackendRendererName_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.BackendRendererName;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     IniFilename_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void IniFilename_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.IniFilename;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     LogFilename_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void LogFilename_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.LogFilename;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     Fonts_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void Fonts_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.Fonts;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     FontDefault_Getter_SeeksNativeMemory
        /// </summary>
        [Fact]
        public void FontDefault_Getter_SeeksNativeMemory()
        {
            ImGuiIoPtr ptr = CreatePtr();
            _ = ptr.FontDefault;
            Assert.True(ptr.NativePtr != IntPtr.Zero);
        }

        /// <summary>
        ///     KeyMap_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeyMap_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<int> value = new List<int> { 1, 2, 3 };
            ptr.KeyMap = value;
            Assert.Equal(1, ptr.KeyMap[0]);
            Assert.Equal(3, ptr.KeyMap[2]);
        }

        /// <summary>
        ///     KeysDown_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void KeysDown_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, true };
            ptr.KeysDown = value;
            Assert.True(ptr.KeysDown[0]);
            Assert.False(ptr.KeysDown[1]);
            Assert.True(ptr.KeysDown[2]);
        }

        /// <summary>
        ///     NavInputs_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void NavInputs_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<float> value = new List<float> { 1f, 2f, 3f };
            ptr.NavInputs = value;
            List<float> read = ptr.NavInputs;
            Assert.Equal(16, read.Count);
            Assert.Equal(1f, read[0]);
            Assert.Equal(3f, read[2]);
        }

        /// <summary>
        ///     MouseDown_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDown_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, true, false, true };
            ptr.MouseDown = value;
            List<bool> read = ptr.MouseDown;
            Assert.Equal(5, read.Count);
            Assert.True(read[0]);
            Assert.False(read[1]);
            Assert.True(read[4]);
        }

        /// <summary>
        ///     MouseClickedTime_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseClickedTime_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<double> value = new List<double> { 1.0, 0, 0, 0, 5.0 };
            ptr.MouseClickedTime = value;
            List<double> read = ptr.MouseClickedTime;
            Assert.Equal(1.0, read[0]);
            Assert.Equal(5.0, read[4]);
        }

        /// <summary>
        ///     MouseClicked_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseClicked_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, false, false, true };
            ptr.MouseClicked = value;
            List<bool> read = ptr.MouseClicked;
            Assert.True(read[0]);
            Assert.True(read[4]);
        }

        /// <summary>
        ///     MouseDoubleClicked_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDoubleClicked_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, false, false, true };
            ptr.MouseDoubleClicked = value;
            List<bool> read = ptr.MouseDoubleClicked;
            Assert.True(read[0]);
            Assert.True(read[4]);
        }

        /// <summary>
        ///     MouseClickedCount_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseClickedCount_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<ushort> value = new List<ushort> { 3, 0, 0, 0, 5 };
            ptr.MouseClickedCount = value;
            List<ushort> read = ptr.MouseClickedCount;
            Assert.Equal((ushort)3, read[0]);
            Assert.Equal((ushort)5, read[4]);
        }

        /// <summary>
        ///     MouseClickedLastCount_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseClickedLastCount_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<ushort> value = new List<ushort> { 3, 0, 0, 0, 5 };
            ptr.MouseClickedLastCount = value;
            List<ushort> read = ptr.MouseClickedLastCount;
            Assert.Equal((ushort)3, read[0]);
            Assert.Equal((ushort)5, read[4]);
        }

        /// <summary>
        ///     MouseReleased_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseReleased_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, false, false, true };
            ptr.MouseReleased = value;
            List<bool> read = ptr.MouseReleased;
            Assert.True(read[0]);
            Assert.True(read[4]);
        }

        /// <summary>
        ///     MouseDownOwned_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDownOwned_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, false, false, true };
            ptr.MouseDownOwned = value;
            List<bool> read = ptr.MouseDownOwned;
            Assert.True(read[0]);
            Assert.True(read[4]);
        }

        /// <summary>
        ///     MouseDownOwnedUnlessPopupClose_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDownOwnedUnlessPopupClose_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<bool> value = new List<bool> { true, false, false, false, true };
            ptr.MouseDownOwnedUnlessPopupClose = value;
            List<bool> read = ptr.MouseDownOwnedUnlessPopupClose;
            Assert.True(read[0]);
            Assert.True(read[4]);
        }

        /// <summary>
        ///     MouseDownDuration_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDownDuration_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<float> value = new List<float> { 1f, 0, 0, 0, 5f };
            ptr.MouseDownDuration = value;
            List<float> read = ptr.MouseDownDuration;
            Assert.Equal(1f, read[0]);
            Assert.Equal(5f, read[4]);
        }

        /// <summary>
        ///     MouseDownDurationPrev_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDownDurationPrev_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<float> value = new List<float> { 1f, 0, 0, 0, 5f };
            ptr.MouseDownDurationPrev = value;
            List<float> read = ptr.MouseDownDurationPrev;
            Assert.Equal(1f, read[0]);
            Assert.Equal(5f, read[4]);
        }

        /// <summary>
        ///     MouseDragMaxDistanceSqr_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void MouseDragMaxDistanceSqr_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            List<float> value = new List<float> { 1f, 0, 0, 0, 5f };
            ptr.MouseDragMaxDistanceSqr = value;
            List<float> read = ptr.MouseDragMaxDistanceSqr;
            Assert.Equal(1f, read[0]);
            Assert.Equal(5f, read[4]);
        }

        /// <summary>
        ///     InputQueueCharacters_SetAndGet_RoundTrips
        /// </summary>
        [Fact]
        public void InputQueueCharacters_SetAndGet_RoundTrips()
        {
            ImGuiIoPtr ptr = CreatePtr();
            ImVectorG<ushort> value = new ImVectorG<ushort>(3, 5, IntPtr.Zero);
            ptr.InputQueueCharacters = value;
            Assert.Equal(3, ptr.InputQueueCharacters.Size);
        }

        /// <summary>
        ///     IntPtrCtor_StoresNativePointer
        /// </summary>
        [Fact]
        public void IntPtrCtor_StoresNativePointer()
        {
            IntPtr raw = new IntPtr(0x1234);
            ImGuiIoPtr ptr = new ImGuiIoPtr(raw);
            Assert.Equal(raw, ptr.NativePtr);
        }

        /// <summary>
        ///     ImplicitToIntPtr_ReturnsNativePointer
        /// </summary>
        [Fact]
        public void ImplicitToIntPtr_ReturnsNativePointer()
        {
            ImGuiIoPtr ptr = CreatePtr();
            IntPtr raw = ptr;
            Assert.Equal(ptr.NativePtr, raw);
        }

        /// <summary>
        ///     ImplicitFromIntPtr_WrapsPointer
        /// </summary>
        [Fact]
        public void ImplicitFromIntPtr_WrapsPointer()
        {
            IntPtr raw = new IntPtr(0x1234);
            ImGuiIoPtr ptr = raw;
            Assert.Equal(raw, ptr.NativePtr);
        }

        /// <summary>
        ///     ImGuiIoCtor_AllocatesNativeMemory
        /// </summary>
        [Fact]
        public void ImGuiIoCtor_AllocatesNativeMemory()
        {
            ImGuiIoPtr ptr = new ImGuiIoPtr(CreateSource());
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

    }
}
