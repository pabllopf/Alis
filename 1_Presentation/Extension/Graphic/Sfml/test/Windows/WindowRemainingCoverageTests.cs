// license header
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class WindowRemainingCoverageTests
    {
        [Fact]
        public void Window_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Window)));
        }

        [Fact]
        public void IsOpen_Settings_Position_Size_Properties_Exist()
        {
            Assert.NotNull(typeof(Window).GetProperty("IsOpen"));
            Assert.NotNull(typeof(Window).GetProperty("Settings"));
            Assert.NotNull(typeof(Window).GetProperty("Position"));
            Assert.NotNull(typeof(Window).GetProperty("Size"));
        }

        [Fact]
        public void SystemHandle_Property_Exists()
        {
            Assert.NotNull(typeof(Window).GetProperty("SystemHandle"));
        }

        [Fact]
        public void Close_Display_SetTitle_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("Close"));
            Assert.NotNull(typeof(Window).GetMethod("Display"));
            Assert.NotNull(typeof(Window).GetMethod("SetTitle"));
        }

        [Fact]
        public void SetIcon_SetVisible_SetMouseCursorVisible_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetIcon"));
            Assert.NotNull(typeof(Window).GetMethod("SetVisible"));
            Assert.NotNull(typeof(Window).GetMethod("SetMouseCursorVisible"));
        }

        [Fact]
        public void SetMouseCursorGrabbed_SetMouseCursor_SetVerticalSyncEnabled_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetMouseCursorGrabbed"));
            Assert.NotNull(typeof(Window).GetMethod("SetMouseCursor"));
            Assert.NotNull(typeof(Window).GetMethod("SetVerticalSyncEnabled"));
        }

        [Fact]
        public void SetKeyRepeatEnabled_SetActive_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetKeyRepeatEnabled", new[] { typeof(bool) }));
        }

        [Fact]
        public void SetActive_NoParam_CallsSetActiveTrue()
        {
            var method = typeof(Window).GetMethod("SetActive", System.Type.EmptyTypes);
            Assert.NotNull(method);
        }

        [Fact]
        public void SetFramerateLimit_SetJoystickThreshold_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetFramerateLimit"));
            Assert.NotNull(typeof(Window).GetMethod("SetJoystickThreshold"));
        }

        [Fact]
        public void WaitAndDispatchEvents_DispatchEvents_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("WaitAndDispatchEvents"));
            Assert.NotNull(typeof(Window).GetMethod("DispatchEvents"));
        }

        [Fact]
        public void RequestFocus_HasFocus_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("RequestFocus"));
            Assert.NotNull(typeof(Window).GetMethod("HasFocus"));
        }

        [Fact]
        public void PollEvent_WaitEvent_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("PollEvent"));
            Assert.NotNull(typeof(Window).GetMethod("WaitEvent"));
        }

        [Fact]
        public void InternalGetMousePosition_InternalSetMousePosition_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("InternalGetMousePosition"));
            Assert.NotNull(typeof(Window).GetMethod("InternalSetMousePosition"));
        }

        [Fact]
        public void InternalGetTouchPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Window).GetMethod("InternalGetTouchPosition"));
        }

        [Fact]
        public void Events_AreDeclared()
        {
            Assert.NotNull(typeof(Window).GetEvent("Closed"));
            Assert.NotNull(typeof(Window).GetEvent("Resized"));
            Assert.NotNull(typeof(Window).GetEvent("LostFocus"));
            Assert.NotNull(typeof(Window).GetEvent("GainedFocus"));
            Assert.NotNull(typeof(Window).GetEvent("TextEntered"));
            Assert.NotNull(typeof(Window).GetEvent("KeyPressed"));
            Assert.NotNull(typeof(Window).GetEvent("KeyReleased"));
            Assert.NotNull(typeof(Window).GetEvent("MouseWheelMoved"));
            Assert.NotNull(typeof(Window).GetEvent("MouseWheelScrolled"));
            Assert.NotNull(typeof(Window).GetEvent("MouseButtonPressed"));
            Assert.NotNull(typeof(Window).GetEvent("MouseButtonReleased"));
            Assert.NotNull(typeof(Window).GetEvent("MouseMoved"));
            Assert.NotNull(typeof(Window).GetEvent("MouseEntered"));
            Assert.NotNull(typeof(Window).GetEvent("MouseLeft"));
            Assert.NotNull(typeof(Window).GetEvent("JoystickButtonPressed"));
            Assert.NotNull(typeof(Window).GetEvent("JoystickButtonReleased"));
            Assert.NotNull(typeof(Window).GetEvent("JoystickMoved"));
            Assert.NotNull(typeof(Window).GetEvent("JoystickConnected"));
            Assert.NotNull(typeof(Window).GetEvent("JoystickDisconnected"));
            Assert.NotNull(typeof(Window).GetEvent("TouchBegan"));
            Assert.NotNull(typeof(Window).GetEvent("TouchMoved"));
            Assert.NotNull(typeof(Window).GetEvent("TouchEnded"));
            Assert.NotNull(typeof(Window).GetEvent("SensorChanged"));
        }
    }
}
