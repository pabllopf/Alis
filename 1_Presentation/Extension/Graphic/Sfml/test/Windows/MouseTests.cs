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
    public class MouseTests
    {
        private class MockMouseWindow : Window
        {
            public Vector2F ReturnPosition { get; set; } = new Vector2F(100, 200);
            public Vector2F? CapturedPosition { get; private set; }
            public bool InternalGetMousePositionCalled { get; private set; }
            public bool InternalSetMousePositionCalled { get; private set; }

            public MockMouseWindow() : base(IntPtr.Zero, 0)
            {
            }

            public override Vector2F InternalGetMousePosition()
            {
                InternalGetMousePositionCalled = true;
                return ReturnPosition;
            }

            public override void InternalSetMousePosition(Vector2F position)
            {
                InternalSetMousePositionCalled = true;
                CapturedPosition = position;
            }
        }

        [Fact]
        public void IsButtonPressed_WithLeftButton_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.Left);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsButtonPressed_WithRightButton_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.Right);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsButtonPressed_WithMiddleButton_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.Middle);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsButtonPressed_WithXButton1_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.XButton1);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsButtonPressed_WithXButton2_ReturnsBool()
        {
            bool result = Mouse.IsButtonPressed(Mouse.Button.XButton2);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void GetPosition_NoParam_ReturnsVector2F()
        {
            Vector2F position = Mouse.GetPosition();

            Assert.IsType<Vector2F>(position);
        }

        [Fact]
        public void GetPosition_WithNullWindow_ReturnsVector2F()
        {
            Vector2F position = Mouse.GetPosition(null);

            Assert.IsType<Vector2F>(position);
        }

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
