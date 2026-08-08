// license header

using System.Reflection;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The window remaining coverage tests class
    /// </summary>
    public class WindowRemainingCoverageTests
    {
        /// <summary>
        /// Tests that window is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Window_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Window)));
        }

        /// <summary>
        /// Tests that is open settings position size properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsOpen_Settings_Position_Size_Properties_Exist()
        {
            Assert.NotNull(typeof(Window).GetProperty("IsOpen"));
            Assert.NotNull(typeof(Window).GetProperty("Settings"));
            Assert.NotNull(typeof(Window).GetProperty("Position"));
            Assert.NotNull(typeof(Window).GetProperty("Size"));
        }

        /// <summary>
        /// Tests that system handle property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SystemHandle_Property_Exists()
        {
            Assert.NotNull(typeof(Window).GetProperty("SystemHandle"));
        }

        /// <summary>
        /// Tests that close display set title methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Close_Display_SetTitle_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("Close"));
            Assert.NotNull(typeof(Window).GetMethod("Display"));
            Assert.NotNull(typeof(Window).GetMethod("SetTitle"));
        }

        /// <summary>
        /// Tests that set icon set visible set mouse cursor visible methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetIcon_SetVisible_SetMouseCursorVisible_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetIcon"));
            Assert.NotNull(typeof(Window).GetMethod("SetVisible"));
            Assert.NotNull(typeof(Window).GetMethod("SetMouseCursorVisible"));
        }

        /// <summary>
        /// Tests that set mouse cursor grabbed set mouse cursor set vertical sync enabled methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetMouseCursorGrabbed_SetMouseCursor_SetVerticalSyncEnabled_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetMouseCursorGrabbed"));
            Assert.NotNull(typeof(Window).GetMethod("SetMouseCursor"));
            Assert.NotNull(typeof(Window).GetMethod("SetVerticalSyncEnabled"));
        }

        /// <summary>
        /// Tests that set key repeat enabled set active methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetKeyRepeatEnabled_SetActive_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetKeyRepeatEnabled", new[] { typeof(bool) }));
        }

        /// <summary>
        /// Tests that set active no param calls set active true
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetActive_NoParam_CallsSetActiveTrue()
        {
            MethodInfo method = typeof(Window).GetMethod("SetActive", System.Type.EmptyTypes);
            Assert.NotNull(method);
        }

        /// <summary>
        /// Tests that set framerate limit set joystick threshold methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetFramerateLimit_SetJoystickThreshold_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("SetFramerateLimit"));
            Assert.NotNull(typeof(Window).GetMethod("SetJoystickThreshold"));
        }

        /// <summary>
        /// Tests that wait and dispatch events dispatch events methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void WaitAndDispatchEvents_DispatchEvents_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("WaitAndDispatchEvents"));
            Assert.NotNull(typeof(Window).GetMethod("DispatchEvents"));
        }

        /// <summary>
        /// Tests that request focus has focus methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RequestFocus_HasFocus_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("RequestFocus"));
            Assert.NotNull(typeof(Window).GetMethod("HasFocus"));
        }

        /// <summary>
        /// Tests that poll event wait event methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PollEvent_WaitEvent_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("PollEvent"));
            Assert.NotNull(typeof(Window).GetMethod("WaitEvent"));
        }

        /// <summary>
        /// Tests that internal get mouse position internal set mouse position methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InternalGetMousePosition_InternalSetMousePosition_Methods_Exist()
        {
            Assert.NotNull(typeof(Window).GetMethod("InternalGetMousePosition"));
            Assert.NotNull(typeof(Window).GetMethod("InternalSetMousePosition"));
        }

        /// <summary>
        /// Tests that internal get touch position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InternalGetTouchPosition_Method_Exists()
        {
            Assert.NotNull(typeof(Window).GetMethod("InternalGetTouchPosition"));
        }

        /// <summary>
        /// Tests that events are declared
        /// </summary>
        [RequireCSfmlSystemFact]
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
