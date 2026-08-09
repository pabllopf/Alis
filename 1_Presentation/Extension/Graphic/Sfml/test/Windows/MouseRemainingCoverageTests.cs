// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseRemainingCoverageTests.cs
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
    ///     The mouse remaining coverage tests class
    /// </summary>
    public class MouseRemainingCoverageTests
    {
        /// <summary>
        ///     The mock mouse window class
        /// </summary>
        /// <seealso cref="Window"/>
        private class MockMouseWindow : Window
        {
            /// <summary>
            ///     Gets or sets the value of the return position
            /// </summary>
            public Vector2F ReturnPosition { get; set; } = new Vector2F(100, 200);

            /// <summary>
            ///     Gets or sets the value of the captured position
            /// </summary>
            public Vector2F? CapturedPosition { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the internal get mouse position called
            /// </summary>
            public bool InternalGetMousePositionCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the internal set mouse position called
            /// </summary>
            public bool InternalSetMousePositionCalled { get; private set; }

            /// <summary>
            ///     Initializes a new instance of the <see cref="MockMouseWindow"/> class
            /// </summary>
            public MockMouseWindow() : base(IntPtr.Zero, 0)
            {
            }

            /// <summary>
            ///     Internals the get mouse position
            /// </summary>
            /// <returns>The return position</returns>
            public override Vector2F InternalGetMousePosition()
            {
                InternalGetMousePositionCalled = true;
                return ReturnPosition;
            }

            /// <summary>
            ///     Internals the set mouse position using the specified position
            /// </summary>
            /// <param name="position">The position</param>
            public override void InternalSetMousePosition(Vector2F position)
            {
                InternalSetMousePositionCalled = true;
                CapturedPosition = position;
            }
        }

        /// <summary>
        ///     Tests that button enum has correct values
        /// </summary>
        [Fact]
        public void Button_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Mouse.Button.Left);
            Assert.Equal(1, (int)Mouse.Button.Right);
            Assert.Equal(2, (int)Mouse.Button.Middle);
            Assert.Equal(3, (int)Mouse.Button.XButton1);
            Assert.Equal(4, (int)Mouse.Button.XButton2);
            Assert.Equal(5, (int)Mouse.Button.ButtonCount);
        }

        /// <summary>
        ///     Tests that wheel enum has correct values
        /// </summary>
        [Fact]
        public void Wheel_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Mouse.Wheel.VerticalWheel);
            Assert.Equal(1, (int)Mouse.Wheel.HorizontalWheel);
        }

        /// <summary>
        ///     Tests that get position with window calls internal get mouse position
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
        ///     Tests that get position with window returns from window
        /// </summary>
        [Fact]
        public void GetPosition_WithWindow_ReturnsFromWindow()
        {
            MockMouseWindow window = new MockMouseWindow();
            Vector2F expected = new Vector2F(500, 600);
            window.ReturnPosition = expected;

            Vector2F result = Mouse.GetPosition(window);

            Assert.Equal(expected.X, result.X);
            Assert.Equal(expected.Y, result.Y);
        }

        /// <summary>
        ///     Tests that set position with window calls internal set mouse position
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
        ///     Tests that set position with window sets position on window
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
