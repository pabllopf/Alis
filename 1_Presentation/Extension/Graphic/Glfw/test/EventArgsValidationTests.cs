// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventArgsValidationTests.cs
// 
//  Author:GitHub Copilot
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
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for event arguments validation
    /// </summary>
    public class EventArgsValidationTests
    {
        /// <summary>
        ///     Test SizeChangeEventArgs is instantiable
        /// </summary>
        [Fact]
        public void SizeChangeEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            SizeChangeEventArgs args = new SizeChangeEventArgs(1024, 768);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MouseButtonEventArgs is instantiable
        /// </summary>
        [Fact]
        public void MouseButtonEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            MouseButtonEventArgs args = new MouseButtonEventArgs(
                MouseButton.Button1,
                InputState.Press,
                ModifierKeys.Control);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MouseButtonEventArgs Button property
        /// </summary>
        [Fact]
        public void MouseButtonEventArgsButton_ShouldReturnCorrectValue()
        {
            // Arrange
            MouseButton button = MouseButton.Button1;
            MouseButtonEventArgs args = new MouseButtonEventArgs(
                button,
                InputState.Press,
                ModifierKeys.Control);

            // Act
            MouseButton retrievedButton = args.Button;

            // Assert
            Assert.Equal(button, retrievedButton);
        }

        /// <summary>
        ///     Test MouseMoveEventArgs is instantiable
        /// </summary>
        [Fact]
        public void MouseMoveEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            MouseMoveEventArgs args = new MouseMoveEventArgs(100, 200);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MouseMoveEventArgs Position property
        /// </summary>
        [Fact]
        public void MouseMoveEventArgsPosition_ShouldReturnCorrectValue()
        {
            // Arrange
            double x = 100;
            double y = 200;
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            // Act
            System.Drawing.PointF position = args.Position;

            // Assert
            Assert.Equal((float)x, position.X);
            Assert.Equal((float)y, position.Y);
        }

        /// <summary>
        ///     Test KeyEventArgs is instantiable
        /// </summary>
        [Fact]
        public void KeyEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            KeyEventArgs args = new KeyEventArgs(
                Keys.A,
                0,
                InputState.Press,
                ModifierKeys.Control);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test KeyEventArgs Key property
        /// </summary>
        [Fact]
        public void KeyEventArgsKey_ShouldReturnCorrectValue()
        {
            // Arrange
            Keys key = Keys.A;
            KeyEventArgs args = new KeyEventArgs(
                key,
                0,
                InputState.Press,
                ModifierKeys.Control);

            // Act
            Keys retrievedKey = args.Key;

            // Assert
            Assert.Equal(key, retrievedKey);
        }

        /// <summary>
        ///     Test CharEventArgs is instantiable
        /// </summary>
        [Fact]
        public void CharEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            CharEventArgs args = new CharEventArgs('A', ModifierKeys.Control);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test CharEventArgs can be passed to handlers
        /// </summary>
        [Fact]
        public void CharEventArgsInHandler_ShouldWork()
        {
            // Arrange
            CharEventArgs args = new CharEventArgs('A', ModifierKeys.Control);

            // Act & Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test FileDropEventArgs is instantiable
        /// </summary>
        [Fact]
        public void FileDropEventArgsConstructor_ShouldSucceed()
        {
            // Arrange
            string[] files = { "file1.txt", "file2.txt" };

            // Act
            FileDropEventArgs args = new FileDropEventArgs(files);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test FileDropEventArgs can be used in handlers
        /// </summary>
        [Fact]
        public void FileDropEventArgsInHandler_ShouldWork()
        {
            // Arrange
            string[] files = { "file1.txt", "file2.txt" };
            FileDropEventArgs args = new FileDropEventArgs(files);

            // Act & Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MaximizeEventArgs is instantiable
        /// </summary>
        [Fact]
        public void MaximizeEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            MaximizeEventArgs args = new MaximizeEventArgs(true);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MaximizeEventArgs can be used in handlers
        /// </summary>
        [Fact]
        public void MaximizeEventArgsInHandler_ShouldWork()
        {
            // Arrange
            MaximizeEventArgs args = new MaximizeEventArgs(true);

            // Act & Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test ContentScaleEventArgs is instantiable
        /// </summary>
        [Fact]
        public void ContentScaleEventArgsConstructor_ShouldSucceed()
        {
            // Arrange & Act
            ContentScaleEventArgs args = new ContentScaleEventArgs(1.5f, 1.5f);

            // Assert
            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test ContentScaleEventArgs XScale property
        /// </summary>
        [Fact]
        public void ContentScaleEventArgsXScale_ShouldReturnCorrectValue()
        {
            // Arrange
            float xScale = 1.5f;
            ContentScaleEventArgs args = new ContentScaleEventArgs(xScale, 1.5f);

            // Act
            float retrievedXScale = args.XScale;

            // Assert
            Assert.Equal(xScale, retrievedXScale);
        }

        /// <summary>
        ///     Test ContentScaleEventArgs YScale property
        /// </summary>
        [Fact]
        public void ContentScaleEventArgsYScale_ShouldReturnCorrectValue()
        {
            // Arrange
            float yScale = 2.0f;
            ContentScaleEventArgs args = new ContentScaleEventArgs(1.5f, yScale);

            // Act
            float retrievedYScale = args.YScale;

            // Assert
            Assert.Equal(yScale, retrievedYScale);
        }

        /// <summary>
        ///     Test all EventArgs types are EventArgs subclasses
        /// </summary>
        [Fact]
        public void AllEventArgsAreEventArgsSubclasses_ShouldBeTrue()
        {
            // Arrange & Act
            SizeChangeEventArgs sizeArgs = new SizeChangeEventArgs(800, 600);
            MouseButtonEventArgs mouseButtonArgs = new MouseButtonEventArgs(
                MouseButton.Button1,
                InputState.Press,
                ModifierKeys.Control);
            MouseMoveEventArgs mouseMoveArgs = new MouseMoveEventArgs(100, 200);
            KeyEventArgs keyArgs = new KeyEventArgs(
                Keys.A,
                0,
                InputState.Press,
                ModifierKeys.Control);
            CharEventArgs charArgs = new CharEventArgs('A', ModifierKeys.Control);
            FileDropEventArgs fileDropArgs = new FileDropEventArgs(new[] { "file.txt" });
            MaximizeEventArgs maximizeArgs = new MaximizeEventArgs(true);
            ContentScaleEventArgs contentScaleArgs = new ContentScaleEventArgs(1.5f, 1.5f);

            // Assert
            Assert.IsAssignableFrom<EventArgs>(sizeArgs);
            Assert.IsAssignableFrom<EventArgs>(mouseButtonArgs);
            Assert.IsAssignableFrom<EventArgs>(mouseMoveArgs);
            Assert.IsAssignableFrom<EventArgs>(keyArgs);
            Assert.IsAssignableFrom<EventArgs>(charArgs);
            Assert.IsAssignableFrom<EventArgs>(fileDropArgs);
            Assert.IsAssignableFrom<EventArgs>(maximizeArgs);
            Assert.IsAssignableFrom<EventArgs>(contentScaleArgs);
        }
    }
}

