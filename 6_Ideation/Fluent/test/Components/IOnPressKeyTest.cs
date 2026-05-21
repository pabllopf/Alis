

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnPressKey interface.
    ///     Tests the OnPressKey lifecycle method for keyboard input detection.
    /// </summary>
    public class IOnPressKeyTest
    {
        /// <summary>
        ///     Tests that IOnPressKey can be implemented.
        /// </summary>
        [Fact]
        public void IOnPressKey_CanBeImplemented()
        {
            PressKeyHandler handler = new PressKeyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnPressKey>(handler);
        }

        /// <summary>
        ///     Tests that OnPressKey method can be called.
        /// </summary>
        [Fact]
        public void OnPressKey_CanBeCalled()
        {
            PressKeyHandler handler = new PressKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.A, DateTime.UtcNow, TimeSpan.Zero);
            handler.OnPressKey(self, keyInfo);
            Assert.Equal(1, handler.PressCount);
        }

        /// <summary>
        ///     Tests that OnPressKey records key event.
        /// </summary>
        [Fact]
        public void OnPressKey_RecordsKeyEvent()
        {
            PressKeyHandler handler = new PressKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.Enter, DateTime.UtcNow, TimeSpan.FromMilliseconds(100));
            handler.OnPressKey(self, keyInfo);
            Assert.Equal(ConsoleKey.Enter, handler.LastKeyEvent.Key);
        }

        /// <summary>
        ///     Tests multiple key press events.
        /// </summary>
        [Fact]
        public void OnPressKey_HandlesMultiplePresses()
        {
            PressKeyHandler handler = new PressKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo1 = new KeyEventInfo(ConsoleKey.A, DateTime.UtcNow, TimeSpan.Zero);
            KeyEventInfo keyInfo2 = new KeyEventInfo(ConsoleKey.B, DateTime.UtcNow, TimeSpan.Zero);
            handler.OnPressKey(self, keyInfo1);
            handler.OnPressKey(self, keyInfo2);
            Assert.Equal(2, handler.PressCount);
            Assert.Equal(ConsoleKey.B, handler.LastKeyEvent.Key);
        }


        /// <summary>
        ///     Helper implementation for testing IOnPressKey.
        /// </summary>
        private class PressKeyHandler : IOnPressKey
        {
            /// <summary>
            ///     Gets or sets the value of the press count
            /// </summary>
            public int PressCount { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the last key event
            /// </summary>
            public KeyEventInfo LastKeyEvent { get; private set; }

            /// <summary>
            ///     Ons the press key using the specified info
            /// </summary>
            /// <param name="info">The info</param>
            /// <exception cref="NotImplementedException"></exception>
            public void OnPressKey(KeyEventInfo info)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Ons the press key using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="keyInfo">The key info</param>
            public void OnPressKey(IGameObject self, KeyEventInfo keyInfo)
            {
                PressCount++;
                LastKeyEvent = keyInfo;
            }
        }
    }
}