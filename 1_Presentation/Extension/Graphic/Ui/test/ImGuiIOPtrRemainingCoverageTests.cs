using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui io ptr remaining coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImGuiIOPtrRemainingCoverageTests : IDisposable
    {
        /// <summary>
        /// The native ptr
        /// </summary>
        internal readonly IntPtr _nativePtr;
        /// <summary>
        /// The io ptr
        /// </summary>
        private ImGuiIoPtr _ioPtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImGuiIOPtrRemainingCoverageTests"/> class
        /// </summary>
        public ImGuiIOPtrRemainingCoverageTests()
        {
            _nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiIo>());
            ImGuiIo io = new ImGuiIo();
            Marshal.StructureToPtr(io, _nativePtr, false);
            _ioPtr = new ImGuiIoPtr(_nativePtr);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Marshal.FreeHGlobal(_nativePtr);
        }

        /// <summary>
        /// Tests that native ptr should return constructor value
        /// </summary>
        [RequireCImguiSystemFact]
        public void NativePtr_ShouldReturnConstructorValue()
        {
            ImGuiIoPtr ptr = new ImGuiIoPtr(_nativePtr);
            Assert.Equal(_nativePtr, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that implicit conversion to int ptr returns native ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversion_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr result = _ioPtr;
            Assert.Equal(_nativePtr, result);
        }

        /// <summary>
        /// Tests that implicit conversion from int ptr returns wrapper
        /// </summary>
        [RequireCImguiSystemFact]
        public void ImplicitConversion_FromIntPtr_ReturnsWrapper()
        {
            ImGuiIoPtr wrapper = _nativePtr;
            Assert.Equal(_nativePtr, wrapper.NativePtr);
        }

        /// <summary>
        /// Tests that config flags get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void ConfigFlags_GetSet_ShouldRoundtrip()
        {
            ImGuiConfigFlags val = ImGuiConfigFlags.DockingEnable;
            _ioPtr.ConfigFlags = val;
            Assert.Equal(val, _ioPtr.ConfigFlags);
        }

        /// <summary>
        /// Tests that backend flags get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendFlags_GetSet_ShouldRoundtrip()
        {
            ImGuiBackendFlags val = ImGuiBackendFlags.RendererHasVtxOffset;
            _ioPtr.BackendFlags = val;
            Assert.Equal(val, _ioPtr.BackendFlags);
        }

        /// <summary>
        /// Tests that display size get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void DisplaySize_GetSet_ShouldRoundtrip()
        {
            Vector2F val = new Vector2F(1920f, 1080f);
            _ioPtr.DisplaySize = val;
            Assert.Equal(val, _ioPtr.DisplaySize);
        }

        /// <summary>
        /// Tests that delta time get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void DeltaTime_GetSet_ShouldRoundtrip()
        {
            _ioPtr.DeltaTime = 0.016f;
            Assert.Equal(0.016f, _ioPtr.DeltaTime, 5);
        }

        /// <summary>
        /// Tests that user data get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void UserData_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(42);
            _ioPtr.UserData = val;
            Assert.Equal(val, _ioPtr.UserData);
        }

        /// <summary>
        /// Tests that font global scale get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void FontGlobalScale_GetSet_ShouldRoundtrip()
        {
            _ioPtr.FontGlobalScale = 1.5f;
            Assert.Equal(1.5f, _ioPtr.FontGlobalScale, 5);
        }

        /// <summary>
        /// Tests that display framebuffer scale get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void DisplayFramebufferScale_GetSet_ShouldRoundtrip()
        {
            Vector2F val = new Vector2F(2f, 2f);
            _ioPtr.DisplayFramebufferScale = val;
            Assert.Equal(val, _ioPtr.DisplayFramebufferScale);
        }

        /// <summary>
        /// Tests that config docking with shift get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void ConfigDockingWithShift_GetSet_ShouldRoundtrip()
        {
            _ioPtr.ConfigDockingWithShift = true;
            Assert.True(_ioPtr.ConfigDockingWithShift);
        }

        /// <summary>
        /// Tests that backend platform name get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendPlatformName_GetSet_ShouldRoundtrip()
        {
            NullTerminatedString str = new NullTerminatedString(new byte[] { (byte)'t', (byte)'e', (byte)'s', (byte)'t' });
            _ioPtr.BackendPlatformName = str;
            Assert.Equal("test", _ioPtr.BackendPlatformName.ToString());
        }

        /// <summary>
        /// Tests that backend platform user data get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendPlatformUserData_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(100);
            _ioPtr.BackendPlatformUserData = val;
            Assert.Equal(val, _ioPtr.BackendPlatformUserData);
        }

        /// <summary>
        /// Tests that backend renderer user data get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendRendererUserData_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(200);
            _ioPtr.BackendRendererUserData = val;
            Assert.Equal(val, _ioPtr.BackendRendererUserData);
        }

        /// <summary>
        /// Tests that backend language user data get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendLanguageUserData_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(300);
            _ioPtr.BackendLanguageUserData = val;
            Assert.Equal(val, _ioPtr.BackendLanguageUserData);
        }

        /// <summary>
        /// Tests that get clipboard text fn get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetClipboardTextFn_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(400);
            _ioPtr.GetClipboardTextFn = val;
            Assert.Equal(val, _ioPtr.GetClipboardTextFn);
        }

        /// <summary>
        /// Tests that set clipboard text fn get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetClipboardTextFn_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(500);
            _ioPtr.SetClipboardTextFn = val;
            Assert.Equal(val, _ioPtr.SetClipboardTextFn);
        }

        /// <summary>
        /// Tests that clipboard user data get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClipboardUserData_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(600);
            _ioPtr.ClipboardUserData = val;
            Assert.Equal(val, _ioPtr.ClipboardUserData);
        }

        /// <summary>
        /// Tests that set platform ime data fn get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetPlatformImeDataFn_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(700);
            _ioPtr.SetPlatformImeDataFn = val;
            Assert.Equal(val, _ioPtr.SetPlatformImeDataFn);
        }

        /// <summary>
        /// Tests that unused padding get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void UnusedPadding_GetSet_ShouldRoundtrip()
        {
            IntPtr val = new IntPtr(800);
            _ioPtr.UnusedPadding = val;
            Assert.Equal(val, _ioPtr.UnusedPadding);
        }

        /// <summary>
        /// Tests that want capture mouse get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void WantCaptureMouse_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantCaptureMouse = true;
            Assert.True(_ioPtr.WantCaptureMouse);
        }

        /// <summary>
        /// Tests that want capture keyboard get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void WantCaptureKeyboard_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantCaptureKeyboard = true;
            Assert.True(_ioPtr.WantCaptureKeyboard);
        }

        /// <summary>
        /// Tests that want text input get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void WantTextInput_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantTextInput = true;
            Assert.True(_ioPtr.WantTextInput);
        }

        /// <summary>
        /// Tests that want set mouse pos get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void WantSetMousePos_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantSetMousePos = true;
            Assert.True(_ioPtr.WantSetMousePos);
        }

        /// <summary>
        /// Tests that want save ini settings get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void WantSaveIniSettings_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantSaveIniSettings = true;
            Assert.True(_ioPtr.WantSaveIniSettings);
        }

        /// <summary>
        /// Tests that nav active get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void NavActive_GetSet_ShouldRoundtrip()
        {
            _ioPtr.NavActive = true;
            Assert.True(_ioPtr.NavActive);
        }

        /// <summary>
        /// Tests that nav visible get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void NavVisible_GetSet_ShouldRoundtrip()
        {
            _ioPtr.NavVisible = true;
            Assert.True(_ioPtr.NavVisible);
        }

        /// <summary>
        /// Tests that framerate get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void Framerate_GetSet_ShouldRoundtrip()
        {
            _ioPtr.Framerate = 60f;
            Assert.Equal(60f, _ioPtr.Framerate, 5);
        }

        /// <summary>
        /// Tests that metrics render vertices get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MetricsRenderVertices_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsRenderVertices = 1000;
            Assert.Equal(1000, _ioPtr.MetricsRenderVertices);
        }

        /// <summary>
        /// Tests that metrics render indices get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MetricsRenderIndices_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsRenderIndices = 2000;
            Assert.Equal(2000, _ioPtr.MetricsRenderIndices);
        }

        /// <summary>
        /// Tests that metrics render windows get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MetricsRenderWindows_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsRenderWindows = 5;
            Assert.Equal(5, _ioPtr.MetricsRenderWindows);
        }

        /// <summary>
        /// Tests that metrics active windows get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MetricsActiveWindows_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsActiveWindows = 3;
            Assert.Equal(3, _ioPtr.MetricsActiveWindows);
        }

        /// <summary>
        /// Tests that metrics active allocations get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MetricsActiveAllocations_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MetricsActiveAllocations = 500;
            Assert.Equal(500, _ioPtr.MetricsActiveAllocations);
        }

        /// <summary>
        /// Tests that mouse delta get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDelta_GetSet_ShouldRoundtrip()
        {
            Vector2F val = new Vector2F(10f, 20f);
            _ioPtr.MouseDelta = val;
            Assert.Equal(val, _ioPtr.MouseDelta);
        }

        /// <summary>
        /// Tests that mouse pos get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MousePos_GetSet_ShouldRoundtrip()
        {
            Vector2F val = new Vector2F(100f, 200f);
            _ioPtr.MousePos = val;
            Assert.Equal(val, _ioPtr.MousePos);
        }

        /// <summary>
        /// Tests that mouse wheel get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseWheel_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MouseWheel = 1.5f;
            Assert.Equal(1.5f, _ioPtr.MouseWheel, 5);
        }

        /// <summary>
        /// Tests that mouse wheel h get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseWheelH_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MouseWheelH = 2.5f;
            Assert.Equal(2.5f, _ioPtr.MouseWheelH, 5);
        }

        /// <summary>
        /// Tests that mouse hovered viewport get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseHoveredViewport_GetSet_ShouldRoundtrip()
        {
            _ioPtr.MouseHoveredViewport = 42u;
            Assert.Equal(42u, _ioPtr.MouseHoveredViewport);
        }

        /// <summary>
        /// Tests that key ctrl get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeyCtrl_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeyCtrl = true;
            Assert.True(_ioPtr.KeyCtrl);
        }

        /// <summary>
        /// Tests that key shift get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeyShift_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeyShift = true;
            Assert.True(_ioPtr.KeyShift);
        }

        /// <summary>
        /// Tests that key alt get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeyAlt_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeyAlt = true;
            Assert.True(_ioPtr.KeyAlt);
        }

        /// <summary>
        /// Tests that key super get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeySuper_GetSet_ShouldRoundtrip()
        {
            _ioPtr.KeySuper = true;
            Assert.True(_ioPtr.KeySuper);
        }

        /// <summary>
        /// Tests that key mods get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeyMods_GetSet_ShouldRoundtrip()
        {
            ImGuiKey val = ImGuiKey.ImGuiModCtrl | ImGuiKey.ImGuiModShift;
            _ioPtr.KeyMods = val;
            Assert.Equal(val, _ioPtr.KeyMods);
        }

        /// <summary>
        /// Tests that want capture mouse unless popup close get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void WantCaptureMouseUnlessPopupClose_GetSet_ShouldRoundtrip()
        {
            _ioPtr.WantCaptureMouseUnlessPopupClose = true;
            Assert.True(_ioPtr.WantCaptureMouseUnlessPopupClose);
        }

        /// <summary>
        /// Tests that mouse pos prev get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MousePosPrev_GetSet_ShouldRoundtrip()
        {
            Vector2F val = new Vector2F(50f, 60f);
            _ioPtr.MousePosPrev = val;
            Assert.Equal(val, _ioPtr.MousePosPrev);
        }

        /// <summary>
        /// Tests that pen pressure get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void PenPressure_GetSet_ShouldRoundtrip()
        {
            _ioPtr.PenPressure = 0.5f;
            Assert.Equal(0.5f, _ioPtr.PenPressure, 5);
        }

        /// <summary>
        /// Tests that app focus lost get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void AppFocusLost_GetSet_ShouldRoundtrip()
        {
            _ioPtr.AppFocusLost = true;
            Assert.True(_ioPtr.AppFocusLost);
        }

        /// <summary>
        /// Tests that app accepting events get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void AppAcceptingEvents_GetSet_ShouldRoundtrip()
        {
            _ioPtr.AppAcceptingEvents = true;
            Assert.True(_ioPtr.AppAcceptingEvents);
        }

        /// <summary>
        /// Tests that backend using legacy key arrays get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendUsingLegacyKeyArrays_GetSet_ShouldRoundtrip()
        {
            _ioPtr.BackendUsingLegacyKeyArrays = 1;
            Assert.Equal(1, _ioPtr.BackendUsingLegacyKeyArrays);
        }

        /// <summary>
        /// Tests that backend using legacy nav input array get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendUsingLegacyNavInputArray_GetSet_ShouldRoundtrip()
        {
            _ioPtr.BackendUsingLegacyNavInputArray = true;
            Assert.True(_ioPtr.BackendUsingLegacyNavInputArray);
        }

        /// <summary>
        /// Tests that input queue surrogate get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputQueueSurrogate_GetSet_ShouldRoundtrip()
        {
            _ioPtr.InputQueueSurrogate = 0xDC00;
            Assert.Equal(0xDC00, _ioPtr.InputQueueSurrogate);
        }

        /// <summary>
        /// Tests that read only properties should have default values
        /// </summary>
        [RequireCImguiSystemFact]
        public void ReadOnlyProperties_ShouldHaveDefaultValues()
        {
            Assert.Equal(0f, _ioPtr.MouseDoubleClickTime, 5);
            Assert.Equal(0f, _ioPtr.MouseDoubleClickMaxDist, 5);
            Assert.Equal(0f, _ioPtr.MouseDragThreshold, 5);
            Assert.Equal(0f, _ioPtr.KeyRepeatDelay, 5);
            Assert.Equal(0f, _ioPtr.KeyRepeatRate, 5);
            Assert.Equal(0f, _ioPtr.HoverDelayNormal, 5);
            Assert.Equal(0f, _ioPtr.HoverDelayShort, 5);
            Assert.Equal(0f, _ioPtr.IniSavingRate, 5);
            Assert.Equal(0f, _ioPtr.ConfigMemoryCompactTimer, 5);
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

        /// <summary>
        /// Tests that key map get should return list
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeyMap_Get_ShouldReturnList()
        {
            List<int> keyMap = _ioPtr.KeyMap;
            Assert.NotNull(keyMap);
            Assert.IsType<List<int>>(keyMap);
        }

        /// <summary>
        /// Tests that keys down get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeysDown_GetSet_ShouldRoundtrip()
        {
            List<bool> keysDown = new List<bool>(512);
            for (int i = 0; i < 512; i++) keysDown.Add(i % 2 == 0);
            _ioPtr.KeysDown = keysDown;
            List<bool> result = _ioPtr.KeysDown;
            for (int i = 0; i < 512; i++)
            {
                Assert.Equal(keysDown[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse down get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDown_GetSet_ShouldRoundtrip()
        {
            List<bool> mouseDown = new List<bool> { true, false, true, false, true };
            _ioPtr.MouseDown = mouseDown;
            List<bool> result = _ioPtr.MouseDown;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(mouseDown[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse clicked time get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseClickedTime_GetSet_ShouldRoundtrip()
        {
            List<double> times = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            _ioPtr.MouseClickedTime = times;
            List<double> result = _ioPtr.MouseClickedTime;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(times[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse clicked get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseClicked_GetSet_ShouldRoundtrip()
        {
            List<bool> clicked = new List<bool> { true, false, true, false, true };
            _ioPtr.MouseClicked = clicked;
            List<bool> result = _ioPtr.MouseClicked;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(clicked[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse double clicked get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDoubleClicked_GetSet_ShouldRoundtrip()
        {
            List<bool> dblClicked = new List<bool> { false, true, false, true, false };
            _ioPtr.MouseDoubleClicked = dblClicked;
            List<bool> result = _ioPtr.MouseDoubleClicked;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(dblClicked[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse clicked count get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseClickedCount_GetSet_ShouldRoundtrip()
        {
            List<ushort> counts = new List<ushort> { 1, 2, 3, 4, 5 };
            _ioPtr.MouseClickedCount = counts;
            List<ushort> result = _ioPtr.MouseClickedCount;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(counts[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse clicked last count get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseClickedLastCount_GetSet_ShouldRoundtrip()
        {
            List<ushort> counts = new List<ushort> { 5, 4, 3, 2, 1 };
            _ioPtr.MouseClickedLastCount = counts;
            List<ushort> result = _ioPtr.MouseClickedLastCount;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(counts[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse released get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseReleased_GetSet_ShouldRoundtrip()
        {
            List<bool> released = new List<bool> { true, true, false, false, true };
            _ioPtr.MouseReleased = released;
            List<bool> result = _ioPtr.MouseReleased;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(released[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse down owned get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDownOwned_GetSet_ShouldRoundtrip()
        {
            List<bool> owned = new List<bool> { false, false, true, true, false };
            _ioPtr.MouseDownOwned = owned;
            List<bool> result = _ioPtr.MouseDownOwned;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(owned[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse down owned unless popup close get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDownOwnedUnlessPopupClose_GetSet_ShouldRoundtrip()
        {
            List<bool> owned = new List<bool> { true, false, true, false, true };
            _ioPtr.MouseDownOwnedUnlessPopupClose = owned;
            List<bool> result = _ioPtr.MouseDownOwnedUnlessPopupClose;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(owned[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse down duration get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDownDuration_GetSet_ShouldRoundtrip()
        {
            List<float> durations = new List<float> { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
            _ioPtr.MouseDownDuration = durations;
            List<float> result = _ioPtr.MouseDownDuration;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(durations[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse down duration prev get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDownDurationPrev_GetSet_ShouldRoundtrip()
        {
            List<float> durations = new List<float> { 0.5f, 0.4f, 0.3f, 0.2f, 0.1f };
            _ioPtr.MouseDownDurationPrev = durations;
            List<float> result = _ioPtr.MouseDownDurationPrev;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(durations[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that mouse drag max distance sqr get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseDragMaxDistanceSqr_GetSet_ShouldRoundtrip()
        {
            List<float> distances = new List<float> { 1f, 2f, 3f, 4f, 5f };
            _ioPtr.MouseDragMaxDistanceSqr = distances;
            List<float> result = _ioPtr.MouseDragMaxDistanceSqr;
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(distances[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that constructor from im gui io should allocate and marshal
        /// </summary>
        [RequireCImguiSystemFact]
        public void Constructor_FromImGuiIo_ShouldAllocateAndMarshal()
        {
            ImGuiIo src = new ImGuiIo { DeltaTime = 0.033f };
            ImGuiIoPtr ptr = new ImGuiIoPtr(src);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that read only null terminated string properties should not be null
        /// </summary>
        [RequireCImguiSystemFact]
        public void ReadOnly_NullTerminatedString_Properties_ShouldNotBeNull()
        {
            Assert.NotNull(_ioPtr.IniFilename);
            Assert.NotNull(_ioPtr.LogFilename);
            Assert.NotNull(_ioPtr.BackendRendererName);
        }

        /// <summary>
        /// Tests that backend renderer name get should return default
        /// </summary>
        [RequireCImguiSystemFact]
        public void BackendRendererName_Get_ShouldReturnDefault()
        {
            NullTerminatedString name = _ioPtr.BackendRendererName;
            Assert.NotNull(name);
        }

        /// <summary>
        /// Tests that read only fonts should return im font atlas ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ReadOnly_Fonts_ShouldReturnImFontAtlasPtr()
        {
            ImFontAtlasPtr fonts = _ioPtr.Fonts;
            Assert.NotNull(fonts);
        }

        /// <summary>
        /// Tests that read only font default should return im font ptr
        /// </summary>
        [RequireCImguiSystemFact]
        public void ReadOnly_FontDefault_ShouldReturnImFontPtr()
        {
            ImFontPtr font = _ioPtr.FontDefault;
            Assert.NotNull(font);
        }

        /// <summary>
        /// Tests that nav inputs get set should roundtrip
        /// </summary>
        [RequireCImguiSystemFact]
        public void NavInputs_GetSet_ShouldRoundtrip()
        {
            List<float> navInputs = new List<float>(16);
            for (int i = 0; i < 16; i++) navInputs.Add(i * 0.1f);
            _ioPtr.NavInputs = navInputs;
            List<float> result = _ioPtr.NavInputs;
            for (int i = 0; i < 16; i++)
            {
                Assert.Equal(navInputs[i], result[i]);
            }
        }

        /// <summary>
        /// Tests that key map set should update value
        /// </summary>
        [RequireCImguiSystemFact]
        public void KeyMap_Set_ShouldUpdateValue()
        {
            List<int> keyMap = new List<int>(652);
            for (int i = 0; i < 652; i++) keyMap.Add(i);
            _ioPtr.KeyMap = keyMap;
            List<int> result = _ioPtr.KeyMap;
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(i, result[i]);
            }
        }
    }
}
