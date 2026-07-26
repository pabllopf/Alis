// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowTest.cs
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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Unit tests for the Window class.
    /// </summary>
    public class WindowTest
    {
        /// <summary>
        ///     Test helper that exposes the protected Window(IntPtr, int) constructor.
        /// </summary>
        private class TestWindow : Window
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestWindow" /> class.
            /// </summary>
            /// <param name="cPointer">The native pointer.</param>
            public TestWindow(IntPtr cPointer) : base(cPointer, 0)
            {
            }
        }

        /// <summary>
        ///     Tests that InvokeEventHandler with a null handler does not throw.
        /// </summary>
        [Fact]
        public void InvokeEventHandler_NullHandler_DoesNotThrow()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            window.InvokeEventHandler(null);
        }

        /// <summary>
        ///     Tests that InvokeEventHandler with a handler invokes it.
        /// </summary>
        [Fact]
        public void InvokeEventHandler_WithHandler_InvokesHandler()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            EventHandler handler = (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.Same(EventArgs.Empty, args);
            };
            window.InvokeEventHandler(handler);
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that InvokeEventHandler generic with a null handler does not throw.
        /// </summary>
        [Fact]
        public void InvokeEventHandler_Generic_NullHandler_DoesNotThrow()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            window.InvokeEventHandler<EventArgs>(null, EventArgs.Empty);
        }

        /// <summary>
        ///     Tests that InvokeEventHandler generic with a handler invokes it.
        /// </summary>
        [Fact]
        public void InvokeEventHandler_Generic_WithHandler_InvokesHandler()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            EventArgs expectedArgs = new EventArgs();
            EventHandler<EventArgs> handler = (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.Same(expectedArgs, args);
            };
            window.InvokeEventHandler(handler, expectedArgs);
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with Closed event invokes the Closed event.
        /// </summary>
        [Fact]
        public void CallEventHandler_Closed_InvokesClosedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.Closed += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
            };
            window.CallEventHandler(new Event { Type = EventType.Closed });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with GainedFocus invokes the GainedFocus event.
        /// </summary>
        [Fact]
        public void CallEventHandler_GainedFocus_InvokesGainedFocusEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.GainedFocus += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
            };
            window.CallEventHandler(new Event { Type = EventType.GainedFocus });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with LostFocus invokes the LostFocus event.
        /// </summary>
        [Fact]
        public void CallEventHandler_LostFocus_InvokesLostFocusEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.LostFocus += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
            };
            window.CallEventHandler(new Event { Type = EventType.LostFocus });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseEntered invokes the MouseEntered event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseEntered_InvokesMouseEnteredEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseEntered += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseEntered });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseLeft invokes the MouseLeft event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseLeft_InvokesMouseLeftEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseLeft += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseLeft });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with Resized invokes the Resized event with SizeEventArgs.
        /// </summary>
        [Fact]
        public void CallEventHandler_Resized_InvokesResizedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.Resized += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<SizeEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.Resized });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with KeyPressed invokes the KeyPressed event.
        /// </summary>
        [Fact]
        public void CallEventHandler_KeyPressed_InvokesKeyPressedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.KeyPressed += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<KeyEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.KeyPressed });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with KeyReleased invokes the KeyReleased event.
        /// </summary>
        [Fact]
        public void CallEventHandler_KeyReleased_InvokesKeyReleasedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.KeyReleased += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<KeyEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.KeyReleased });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with TextEntered invokes the TextEntered event.
        /// </summary>
        [Fact]
        public void CallEventHandler_TextEntered_InvokesTextEnteredEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.TextEntered += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<TextEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.TextEntered });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseButtonPressed invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseButtonPressed_InvokesMouseButtonPressedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseButtonPressed += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<MouseButtonEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseButtonPressed });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseButtonReleased invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseButtonReleased_InvokesMouseButtonReleasedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseButtonReleased += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<MouseButtonEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseButtonReleased });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseMoved invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseMoved_InvokesMouseMovedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseMoved += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<MouseMoveEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseMoved });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseWheelMoved invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseWheelMoved_InvokesMouseWheelMovedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseWheelMoved += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<MouseWheelEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseWheelMoved });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with MouseWheelScrolled invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_MouseWheelScrolled_InvokesMouseWheelScrolledEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.MouseWheelScrolled += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<MouseWheelScrollEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.MouseWheelScrolled });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with JoystickButtonPressed invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_JoystickButtonPressed_InvokesJoystickButtonPressedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.JoystickButtonPressed += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<JoystickButtonEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.JoystickButtonPressed });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with JoystickButtonReleased invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_JoystickButtonReleased_InvokesJoystickButtonReleasedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.JoystickButtonReleased += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<JoystickButtonEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.JoystickButtonReleased });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with JoystickMoved invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_JoystickMoved_InvokesJoystickMovedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.JoystickMoved += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<JoystickMoveEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.JoystickMoved });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with JoystickConnected invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_JoystickConnected_InvokesJoystickConnectedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.JoystickConnected += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<JoystickConnectEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.JoystickConnected });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with JoystickDisconnected invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_JoystickDisconnected_InvokesJoystickDisconnectedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.JoystickDisconnected += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<JoystickConnectEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.JoystickDisconnected });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with TouchBegan invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_TouchBegan_InvokesTouchBeganEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.TouchBegan += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<TouchEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.TouchBegan });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with TouchMoved invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_TouchMoved_InvokesTouchMovedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.TouchMoved += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<TouchEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.TouchMoved });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with TouchEnded invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_TouchEnded_InvokesTouchEndedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.TouchEnded += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<TouchEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.TouchEnded });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with SensorChanged invokes the event.
        /// </summary>
        [Fact]
        public void CallEventHandler_SensorChanged_InvokesSensorChangedEvent()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            bool called = false;
            window.SensorChanged += (sender, args) =>
            {
                called = true;
                Assert.Same(window, sender);
                Assert.IsType<SensorEventArgs>(args);
            };
            window.CallEventHandler(new Event { Type = EventType.SensorChanged });
            Assert.True(called);
        }

        /// <summary>
        ///     Tests that CallEventHandler with unregistered events does not throw.
        /// </summary>
        [Fact]
        public void CallEventHandler_NoHandler_DoesNotThrow()
        {
            TestWindow window = new TestWindow(IntPtr.Zero);
            window.CallEventHandler(new Event { Type = EventType.Closed });
            window.CallEventHandler(new Event { Type = EventType.KeyPressed });
            window.CallEventHandler(new Event { Type = EventType.MouseMoved });
        }
    }
}
