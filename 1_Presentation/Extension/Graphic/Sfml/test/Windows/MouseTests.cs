// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseTests.cs
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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The mouse tests class
    /// </summary>
    public class MouseTests
    {
        /// <summary>
        /// The mock mouse window class
        /// </summary>
        /// <seealso cref="Window"/>
        private class MockMouseWindow : Window
        {
            /// <summary>
            /// Gets or sets the value of the return position
            /// </summary>
            public Vector2F ReturnPosition { get; set; } = new Vector2F(100, 200);
            /// <summary>
            /// Gets or sets the value of the captured position
            /// </summary>
            public Vector2F? CapturedPosition { get; private set; }
            /// <summary>
            /// Gets or sets the value of the internal get mouse position called
            /// </summary>
            public bool InternalGetMousePositionCalled { get; private set; }
            /// <summary>
            /// Gets or sets the value of the internal set mouse position called
            /// </summary>
            public bool InternalSetMousePositionCalled { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="MockMouseWindow"/> class
            /// </summary>
            public MockMouseWindow() : base(IntPtr.Zero, 0)
            {
            }

            /// <summary>
            /// Internals the get mouse position
            /// </summary>
            /// <returns>The return position</returns>
            public override Vector2F InternalGetMousePosition()
            {
                InternalGetMousePositionCalled = true;
                return ReturnPosition;
            }

            /// <summary>
            /// Internals the set mouse position using the specified position
            /// </summary>
            /// <param name="position">The position</param>
            public override void InternalSetMousePosition(Vector2F position)
            {
                InternalSetMousePositionCalled = true;
                CapturedPosition = position;
            }
        }

        /// <summary>
        /// Tests that is button pressed with left button returns bool
        /// </summary>
        [Fact]
        public void IsButtonPressed_WithLeftButton_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.Left);

            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that is button pressed with right button returns bool
        /// </summary>
        [Fact]
        public void IsButtonPressed_WithRightButton_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.Right);

            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that is button pressed with middle button returns bool
        /// </summary>
        [Fact]
        public void IsButtonPressed_WithMiddleButton_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.Middle);

            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that is button pressed with x button 1 returns bool
        /// </summary>
        [Fact]
        public void IsButtonPressed_WithXButton1_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.XButton1);

            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that is button pressed with x button 2 returns bool
        /// </summary>
        [Fact]
        public void IsButtonPressed_WithXButton2_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.XButton2);

            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that get position no param returns vector 2 f
        /// </summary>
        [Fact]
        public void GetPosition_NoParam_ReturnsVector2F()
        {
            Vector2F position = Mouse.GetPosition();

            Assert.IsType<Vector2F>(position);
        }

        /// <summary>
        /// Tests that get position with null window returns vector 2 f
        /// </summary>
        [Fact]
        public void GetPosition_WithNullWindow_ReturnsVector2F()
        {
            Vector2F position = Mouse.GetPosition(null);

            Assert.IsType<Vector2F>(position);
        }

        /// <summary>
        /// Tests that get position with window calls internal get mouse position
        /// </summary>
        [Fact]
        public void GetPosition_WithWindow_CallsInternalGetMousePosition()
        {
            MockMouseWindow window = new MockMouseWindow();
            Vector2F expected = new Vector2F(300, 400);
            window.ReturnPosition = expected;

            Vector2F result = Mouse.GetPosition(window);

            Assert.True(window.InternalGetMousePositionCalled);
            Assert.Equal(expected.X, result.X);
            Assert.Equal(expected.Y, result.Y);
        }

        /// <summary>
        /// Tests that get position with window returns from window
        /// </summary>
        [Fact]
        public void GetPosition_WithWindow_ReturnsFromWindow()
        {
            MockMouseWindow window = new MockMouseWindow();

            Vector2F result = Mouse.GetPosition(window);

            Assert.Equal(window.ReturnPosition.X, result.X);
            Assert.Equal(window.ReturnPosition.Y, result.Y);
        }

        // SetPosition with null/IntPtr.Zero calls sfMouse_setPosition natively which
        // blocks on macOS without accessibility permissions (BLOCKED_BY_PRODUCTION_CODE).
        // Tests for those paths are omitted.

        /// <summary>
        /// Tests that set position with window calls internal set mouse position
        /// </summary>
        [Fact]
        public void SetPosition_WithWindow_CallsInternalSetMousePosition()
        {
            MockMouseWindow window = new MockMouseWindow();
            Vector2F expected = new Vector2F(700, 800);

            Mouse.SetPosition(expected, window);

            Assert.True(window.InternalSetMousePositionCalled);
            Assert.NotNull(window.CapturedPosition);
            Assert.Equal(expected.X, window.CapturedPosition.Value.X);
            Assert.Equal(expected.Y, window.CapturedPosition.Value.Y);
        }

        /// <summary>
        /// Tests that set position with window sets position on window
        /// </summary>
        [Fact]
        public void SetPosition_WithWindow_SetsPositionOnWindow()
        {
            MockMouseWindow window = new MockMouseWindow();
            Vector2F expected = new Vector2F(900, 1000);

            Mouse.SetPosition(expected, window);

            Assert.Equal(expected.X, window.CapturedPosition.Value.X);
            Assert.Equal(expected.Y, window.CapturedPosition.Value.Y);
        }
    }
}
