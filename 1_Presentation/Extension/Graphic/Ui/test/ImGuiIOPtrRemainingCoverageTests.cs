using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiIOPtrRemainingCoverageTests : IDisposable
    {
        private readonly IntPtr _nativePtr;
        private ImGuiIoPtr _ioPtr;

        public ImGuiIOPtrRemainingCoverageTests()
        {
            _nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiIo>());
            var io = new ImGuiIo();
            Marshal.StructureToPtr(io, _nativePtr, false);
            _ioPtr = new ImGuiIoPtr(_nativePtr);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(_nativePtr);
        }

        [Fact]
        public void NativePtr_ShouldReturnConstructorValue()
        {
            var ptr = new ImGuiIoPtr(_nativePtr);
            Assert.Equal(_nativePtr, ptr.NativePtr);
        }

        [Fact]
        public void ImplicitConversion_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr result = _ioPtr;
            Assert.Equal(_nativePtr, result);
        }

        [Fact]
        public void ImplicitConversion_FromIntPtr_ReturnsWrapper()
        {
            ImGuiIoPtr wrapper = _nativePtr;
            Assert.Equal(_nativePtr, wrapper.NativePtr);
        }

        [Fact]
        public void ConfigFlags_GetSet_ShouldRoundtrip()
        {
            var val = ImGuiConfigFlags.DockingEnable;
            _ioPtr.ConfigFlags = val;
            Assert.Equal(val, _ioPtr.ConfigFlags);
        }

        [Fact]
        public void BackendFlags_GetSet_ShouldRoundtrip()
        {
            var val = ImGuiBackendFlags.RendererHasVtxOffset;
            _ioPtr.BackendFlags = val;
            Assert.Equal(val, _ioPtr.BackendFlags);
        }

        [Fact]
        public void DisplaySize_GetSet_ShouldRoundtrip()
        {
            var val = new Vector2F(1920f, 1080f);
            _ioPtr.DisplaySize = val;
            Assert.Equal(val, _ioPtr.DisplaySize);
        }

        [Fact]
        public void DeltaTime_GetSet_ShouldRoundtrip()
        {
            _ioPtr.DeltaTime = 0.016f;
            Assert.Equal(0.016f, _ioPtr.DeltaTime);
        }

        [Fact]
        public void UserData_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(42);
            _ioPtr.UserData = val;
            Assert.Equal(val, _ioPtr.UserData);
        }

        [Fact]
        public void FontGlobalScale_GetSet_ShouldRoundtrip()
        {
            _ioPtr.FontGlobalScale = 1.5f;
            Assert.Equal(1.5f, _ioPtr.FontGlobalScale);
        }

        [Fact]
        public void DisplayFramebufferScale_GetSet_ShouldRoundtrip()
        {
            var val = new Vector2F(2f, 2f);
            _ioPtr.DisplayFramebufferScale = val;
            Assert.Equal(val, _ioPtr.DisplayFramebufferScale);
        }

        [Fact]
        public void ConfigDockingWithShift_GetSet_ShouldRoundtrip()
        {
            _ioPtr.ConfigDockingWithShift = true;
            Assert.True(_ioPtr.ConfigDockingWithShift);
        }

        [Fact]
        public void BackendPlatformName_GetSet_ShouldRoundtrip()
        {
            var str = new NullTerminatedString(new byte[] { (byte)'t', (byte)'e', (byte)'s', (byte)'t' });
            _ioPtr.BackendPlatformName = str;
            Assert.Equal("test", _ioPtr.BackendPlatformName.ToString());
        }

        [Fact]
        public void BackendPlatformUserData_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(100);
            _ioPtr.BackendPlatformUserData = val;
            Assert.Equal(val, _ioPtr.BackendPlatformUserData);
        }

        [Fact]
        public void BackendRendererUserData_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(200);
            _ioPtr.BackendRendererUserData = val;
            Assert.Equal(val, _ioPtr.BackendRendererUserData);
        }

        [Fact]
        public void BackendLanguageUserData_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(300);
            _ioPtr.BackendLanguageUserData = val;
            Assert.Equal(val, _ioPtr.BackendLanguageUserData);
        }

        [Fact]
        public void GetClipboardTextFn_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(400);
            _ioPtr.GetClipboardTextFn = val;
            Assert.Equal(val, _ioPtr.GetClipboardTextFn);
        }

        [Fact]
        public void SetClipboardTextFn_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(500);
            _ioPtr.SetClipboardTextFn = val;
            Assert.Equal(val, _ioPtr.SetClipboardTextFn);
        }

        [Fact]
        public void ClipboardUserData_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(600);
            _ioPtr.ClipboardUserData = val;
            Assert.Equal(val, _ioPtr.ClipboardUserData);
        }

        [Fact]
        public void SetPlatformImeDataFn_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(700);
            _ioPtr.SetPlatformImeDataFn = val;
            Assert.Equal(val, _ioPtr.SetPlatformImeDataFn);
        }

        [Fact]
        public void UnusedPadding_GetSet_ShouldRoundtrip()
        {
            var val = new IntPtr(800);
            _ioPtr.UnusedPadding = val;
            Assert.Equal(val, _ioPtr.UnusedPadding);
        }

        [Fact]
        public void WantCaptureMouse_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantCaptureMouse = true;
            Assert.True(_ioPtr.WantCaptureMouse);
        }

        [Fact]
        public void WantCaptureKeyboard_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantCaptureKeyboard = true;
            Assert.True(_ioPtr.WantCaptureKeyboard);
        }

        [Fact]
        public void WantTextInput_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantTextInput = true;
            Assert.True(_ioPtr.WantTextInput);
        }

        [Fact]
        public void WantSetMousePos_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantSetMousePos = true;
            Assert.True(_ioPtr.WantSetMousePos);
        }

        [Fact]
        public void WantSaveIniSettings_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantSaveIniSettings = true;
            Assert.True(_ioPtr.WantSaveIniSettings);
        }

        [Fact]
        public void NavActive_GetSet_ShouldRoundtrip()
        {
            _ioPtr.NavActive = true;
            Assert.True(_ioPtr.NavActive);
        }

        [Fact]
        public void NavVisible_GetSet_ShouldRoundtrip()
        {
            _ioPtr.NavVisible = true;
            Assert.True(_ioPtr.NavVisible);
        }

        [Fact]
        public void Framerate_GetSet_ShouldRoundtrip()
        {
            _ioPtr.Framerate = 60f;
            Assert.Equal(60f, _ioPtr.Framerate);
        }

        [Fact]
        public void MetricsRenderVertices_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsRenderVertices = 1000;
            Assert.Equal(1000, _ioPtr.MetricsRenderVertices);
        }

        [Fact]
        public void MetricsRenderIndices_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsRenderIndices = 2000;
            Assert.Equal(2000, _ioPtr.MetricsRenderIndices);
        }

        [Fact]
        public void MetricsRenderWindows_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsRenderWindows = 5;
            Assert.Equal(5, _ioPtr.MetricsRenderWindows);
        }

        [Fact]
        public void MetricsActiveWindows_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsActiveWindows = 3;
            Assert.Equal(3, _ioPtr.MetricsActiveWindows);
        }

        [Fact]
        public void MetricsActiveAllocations_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsActiveAllocations = 500;
            Assert.Equal(500, _ioPtr.MetricsActiveAllocations);
        }

        [Fact]
        public void MouseDelta_GetSet_ShouldRoundtrip()
        {
            var val = new Vector2F(10f, 20f);
            _ioPtr.MouseDelta = val;
            Assert.Equal(val, _ioPtr.MouseDelta);
        }

        [Fact]
        public void MousePos_GetSet_ShouldRoundtrip()
        {
            var val = new Vector2F(100f, 200f);
            _ioPtr.MousePos = val;
            Assert.Equal(val, _ioPtr.MousePos);
        }

        [Fact]
        public void MouseWheel_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MouseWheel = 1.5f;
            Assert.Equal(1.5f, _ioPtr.MouseWheel);
        }

        [Fact]
        public void MouseWheelH_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MouseWheelH = 2.5f;
            Assert.Equal(2.5f, _ioPtr.MouseWheelH);
        }

        [Fact]
        public void MouseHoveredViewport_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MouseHoveredViewport = 42u;
            Assert.Equal(42u, _ioPtr.MouseHoveredViewport);
        }

        [Fact]
        public void KeyCtrl_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeyCtrl = true;
            Assert.True(_ioPtr.KeyCtrl);
        }

        [Fact]
        public void KeyShift_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeyShift = true;
            Assert.True(_ioPtr.KeyShift);
        }

        [Fact]
        public void KeyAlt_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeyAlt = true;
            Assert.True(_ioPtr.KeyAlt);
        }

        [Fact]
        public void KeySuper_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeySuper = true;
            Assert.True(_ioPtr.KeySuper);
        }

        [Fact]
        public void KeyMods_GetSet_ShouldRoundtrip()
        {
            var val = ImGuiKey.ImGuiModCtrl | ImGuiKey.ImGuiModShift;
            _ioPtr.KeyMods = val;
            Assert.Equal(val, _ioPtr.KeyMods);
        }

        [Fact]
        public void WantCaptureMouseUnlessPopupClose_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantCaptureMouseUnlessPopupClose = true;
            Assert.True(_ioPtr.WantCaptureMouseUnlessPopupClose);
        }

        [Fact]
        public void MousePosPrev_GetSet_ShouldRoundtrip()
        {
            var val = new Vector2F(50f, 60f);
            _ioPtr.MousePosPrev = val;
            Assert.Equal(val, _ioPtr.MousePosPrev);
        }

        [Fact]
        public void PenPressure_GetSet_ShouldRoundtrip()
        {
            _ioPtr.PenPressure = 0.5f;
            Assert.Equal(0.5f, _ioPtr.PenPressure);
        }

        [Fact]
        public void AppFocusLost_GetSet_ShouldRoundtrip()
        {
            _ioPtr.AppFocusLost = true;
            Assert.True(_ioPtr.AppFocusLost);
        }

        [Fact]
        public void AppAcceptingEvents_GetSet_ShouldRoundtrip()
        {
            _ioPtr.AppAcceptingEvents = true;
            Assert.True(_ioPtr.AppAcceptingEvents);
        }

        [Fact]
        public void BackendUsingLegacyKeyArrays_GetSet_ShouldRoundtrip()
        {
            _ioPtr.BackendUsingLegacyKeyArrays = 1;
            Assert.Equal(1, _ioPtr.BackendUsingLegacyKeyArrays);
        }

        [Fact]
        public void BackendUsingLegacyNavInputArray_GetSet_ShouldRoundtrip()
        {
            _ioPtr.BackendUsingLegacyNavInputArray = true;
            Assert.True(_ioPtr.BackendUsingLegacyNavInputArray);
        }

        [Fact]
        public void InputQueueSurrogate_GetSet_ShouldRoundtrip()
        {
            _ioPtr.InputQueueSurrogate = 0xDC00;
            Assert.Equal(0xDC00, _ioPtr.InputQueueSurrogate);
        }

        [Fact]
        public void ReadOnlyProperties_ShouldHaveDefaultValues()
        {
            Assert.Equal(0f, _ioPtr.MouseDoubleClickTime);
            Assert.Equal(0f, _ioPtr.MouseDoubleClickMaxDist);
            Assert.Equal(0f, _ioPtr.MouseDragThreshold);
            Assert.Equal(0f, _ioPtr.KeyRepeatDelay);
            Assert.Equal(0f, _ioPtr.KeyRepeatRate);
            Assert.Equal(0f, _ioPtr.HoverDelayNormal);
            Assert.Equal(0f, _ioPtr.HoverDelayShort);
            Assert.Equal(0f, _ioPtr.IniSavingRate);
            Assert.Equal(0f, _ioPtr.ConfigMemoryCompactTimer);
            Assert.False(_ioPtr.FontAllowUserScaling);
            Assert.False(_ioPtr.ConfigDockingNoSplit);
            Assert.False(_ioPtr.ConfigDockingAlwaysTabBar);
            Assert.False(_ioPtr.ConfigDockingTransparentPayload);
            Assert.False(_ioPtr.ConfigViewportsNoAutoMerge);
            Assert.False(_ioPtr.ConfigViewportsNoTaskBarIcon);
            Assert.False(_ioPtr.ConfigViewportsNoDecoration);
            Assert.False(_ioPtr.ConfigViewportsNoDefaultParent);
            Assert.False(_ioPtr.MouseDrawCursor);
            Assert.False(_ioPtr.ConfigMacOsxBehaviors);
            Assert.False(_ioPtr.ConfigInputTrickleEventQueue);
            Assert.False(_ioPtr.ConfigInputTextCursorBlink);
            Assert.False(_ioPtr.ConfigInputTextEnterKeepActive);
            Assert.False(_ioPtr.ConfigDragClickToInputText);
            Assert.False(_ioPtr.ConfigWindowsResizeFromEdges);
            Assert.False(_ioPtr.ConfigWindowsMoveFromTitleBarOnly);
        }

        [Fact]
        public void KeyMap_Get_ShouldReturnList()
        {
            var keyMap = _ioPtr.KeyMap;
            Assert.NotNull(keyMap);
            Assert.IsType<List<int>>(keyMap);
        }

        [Fact]
        public void KeysDown_GetSet_ShouldRoundtrip()
        {
            var keysDown = new List<bool>(512);
            for (int i = 0; i < 512; i++) keysDown.Add(i % 2 == 0);
            _ioPtr.KeysDown = keysDown;
            var result = _ioPtr.KeysDown;
            for (int i = 0; i < 512; i++)
            {
                Assert.Equal(keysDown[i], result[i]);
            }
        }

        [Fact]
        public void MouseDown_GetSet_ShouldRoundtrip()
        {
            var mouseDown = new List<bool> { true, false, true, false, true };
            _ioPtr.MouseDown = mouseDown;
            var result = _ioPtr.MouseDown;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(mouseDown[i], result[i]);
            }
        }

        [Fact]
        public void MouseClickedTime_GetSet_ShouldRoundtrip()
        {
            var times = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            _ioPtr.MouseClickedTime = times;
            var result = _ioPtr.MouseClickedTime;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(times[i], result[i]);
            }
        }

        [Fact]
        public void MouseClicked_GetSet_ShouldRoundtrip()
        {
            var clicked = new List<bool> { true, false, true, false, true };
            _ioPtr.MouseClicked = clicked;
            var result = _ioPtr.MouseClicked;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(clicked[i], result[i]);
            }
        }

        [Fact]
        public void MouseDoubleClicked_GetSet_ShouldRoundtrip()
        {
            var dblClicked = new List<bool> { false, true, false, true, false };
            _ioPtr.MouseDoubleClicked = dblClicked;
            var result = _ioPtr.MouseDoubleClicked;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(dblClicked[i], result[i]);
            }
        }

        [Fact]
        public void MouseClickedCount_GetSet_ShouldRoundtrip()
        {
            var counts = new List<ushort> { 1, 2, 3, 4, 5 };
            _ioPtr.MouseClickedCount = counts;
            var result = _ioPtr.MouseClickedCount;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(counts[i], result[i]);
            }
        }

        [Fact]
        public void MouseClickedLastCount_GetSet_ShouldRoundtrip()
        {
            var counts = new List<ushort> { 5, 4, 3, 2, 1 };
            _ioPtr.MouseClickedLastCount = counts;
            var result = _ioPtr.MouseClickedLastCount;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(counts[i], result[i]);
            }
        }

        [Fact]
        public void MouseReleased_GetSet_ShouldRoundtrip()
        {
            var released = new List<bool> { true, true, false, false, true };
            _ioPtr.MouseReleased = released;
            var result = _ioPtr.MouseReleased;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(released[i], result[i]);
            }
        }

        [Fact]
        public void MouseDownOwned_GetSet_ShouldRoundtrip()
        {
            var owned = new List<bool> { false, false, true, true, false };
            _ioPtr.MouseDownOwned = owned;
            var result = _ioPtr.MouseDownOwned;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(owned[i], result[i]);
            }
        }

        [Fact]
        public void MouseDownOwnedUnlessPopupClose_GetSet_ShouldRoundtrip()
        {
            var owned = new List<bool> { true, false, true, false, true };
            _ioPtr.MouseDownOwnedUnlessPopupClose = owned;
            var result = _ioPtr.MouseDownOwnedUnlessPopupClose;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(owned[i], result[i]);
            }
        }

        [Fact]
        public void MouseDownDuration_GetSet_ShouldRoundtrip()
        {
            var durations = new List<float> { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
            _ioPtr.MouseDownDuration = durations;
            var result = _ioPtr.MouseDownDuration;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(durations[i], result[i]);
            }
        }

        [Fact]
        public void MouseDownDurationPrev_GetSet_ShouldRoundtrip()
        {
            var durations = new List<float> { 0.5f, 0.4f, 0.3f, 0.2f, 0.1f };
            _ioPtr.MouseDownDurationPrev = durations;
            var result = _ioPtr.MouseDownDurationPrev;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(durations[i], result[i]);
            }
        }

        [Fact]
        public void MouseDragMaxDistanceSqr_GetSet_ShouldRoundtrip()
        {
            var distances = new List<float> { 1f, 2f, 3f, 4f, 5f };
            _ioPtr.MouseDragMaxDistanceSqr = distances;
            var result = _ioPtr.MouseDragMaxDistanceSqr;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(distances[i], result[i]);
            }
        }

        [Fact]
        public void Constructor_FromImGuiIo_ShouldAllocateAndMarshal()
        {
            var src = new ImGuiIo { DeltaTime = 0.033f };
            var ptr = new ImGuiIoPtr(src);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        [Fact]
        public void ReadOnly_NullTerminatedString_Properties_ShouldNotBeNull()
        {
            Assert.NotNull(_ioPtr.IniFilename);
            Assert.NotNull(_ioPtr.LogFilename);
            Assert.NotNull(_ioPtr.BackendRendererName);
        }

        [Fact]
        public void BackendRendererName_Get_ShouldReturnDefault()
        {
            var name = _ioPtr.BackendRendererName;
            Assert.NotNull(name);
        }

        [Fact]
        public void ReadOnly_Fonts_ShouldReturnImFontAtlasPtr()
        {
            var fonts = _ioPtr.Fonts;
            Assert.NotNull(fonts);
        }

        [Fact]
        public void ReadOnly_FontDefault_ShouldReturnImFontPtr()
        {
            var font = _ioPtr.FontDefault;
            Assert.NotNull(font);
        }

        [Fact]
        public void NavInputs_GetSet_ShouldRoundtrip()
        {
            var navInputs = new List<float>(16);
            for (int i = 0; i < 16; i++) navInputs.Add(i * 0.1f);
            _ioPtr.NavInputs = navInputs;
            var result = _ioPtr.NavInputs;
            for (int i = 0; i < 16; i++)
            {
                Assert.Equal(navInputs[i], result[i]);
            }
        }

        [Fact]
        public void KeyMap_Set_ShouldUpdateValue()
        {
            var keyMap = new List<int>(652);
            for (int i = 0; i < 652; i++) keyMap.Add(i);
            _ioPtr.KeyMap = keyMap;
            var result = _ioPtr.KeyMap;
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(i, result[i]);
            }
        }
    }
}
