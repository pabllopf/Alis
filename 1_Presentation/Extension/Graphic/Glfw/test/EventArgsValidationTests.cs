// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventArgsValidationTests.cs
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
using System.Drawing;
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
            SizeChangeEventArgs args = new SizeChangeEventArgs(1024, 768);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MouseButtonEventArgs is instantiable
        /// </summary>
        [Fact]
        public void MouseButtonEventArgsConstructor_ShouldSucceed()
        {
            MouseButtonEventArgs args = new MouseButtonEventArgs(
                MouseButton.Button1,
                InputState.Press,
                ModifierKeys.Control);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MouseButtonEventArgs Button property
        /// </summary>
        [Fact]
        public void MouseButtonEventArgsButton_ShouldReturnCorrectValue()
        {
            MouseButton button = MouseButton.Button1;
            MouseButtonEventArgs args = new MouseButtonEventArgs(
                button,
                InputState.Press,
                ModifierKeys.Control);

            MouseButton retrievedButton = args.Button;

            Assert.Equal(button, retrievedButton);
        }

        /// <summary>
        ///     Test MouseMoveEventArgs is instantiable
        /// </summary>
        [Fact]
        public void MouseMoveEventArgsConstructor_ShouldSucceed()
        {
            MouseMoveEventArgs args = new MouseMoveEventArgs(100, 200);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MouseMoveEventArgs Position property
        /// </summary>
        [Fact]
        public void MouseMoveEventArgsPosition_ShouldReturnCorrectValue()
        {
            double x = 100;
            double y = 200;
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            PointF position = args.Position;

            Assert.Equal((float) x, position.X);
            Assert.Equal((float) y, position.Y);
        }

        /// <summary>
        ///     Test KeyEventArgs is instantiable
        /// </summary>
        [Fact]
        public void KeyEventArgsConstructor_ShouldSucceed()
        {
            KeyEventArgs args = new KeyEventArgs(
                Keys.A,
                0,
                InputState.Press,
                ModifierKeys.Control);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test KeyEventArgs Key property
        /// </summary>
        [Fact]
        public void KeyEventArgsKey_ShouldReturnCorrectValue()
        {
            Keys key = Keys.A;
            KeyEventArgs args = new KeyEventArgs(
                key,
                0,
                InputState.Press,
                ModifierKeys.Control);

            Keys retrievedKey = args.Key;

            Assert.Equal(key, retrievedKey);
        }

        /// <summary>
        ///     Test CharEventArgs is instantiable
        /// </summary>
        [Fact]
        public void CharEventArgsConstructor_ShouldSucceed()
        {
            CharEventArgs args = new CharEventArgs('A', ModifierKeys.Control);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test CharEventArgs can be passed to handlers
        /// </summary>
        [Fact]
        public void CharEventArgsInHandler_ShouldWork()
        {
            CharEventArgs args = new CharEventArgs('A', ModifierKeys.Control);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test FileDropEventArgs is instantiable
        /// </summary>
        [Fact]
        public void FileDropEventArgsConstructor_ShouldSucceed()
        {
            string[] files = {"file1.txt", "file2.txt"};

            FileDropEventArgs args = new FileDropEventArgs(files);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test FileDropEventArgs can be used in handlers
        /// </summary>
        [Fact]
        public void FileDropEventArgsInHandler_ShouldWork()
        {
            string[] files = {"file1.txt", "file2.txt"};
            FileDropEventArgs args = new FileDropEventArgs(files);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MaximizeEventArgs is instantiable
        /// </summary>
        [Fact]
        public void MaximizeEventArgsConstructor_ShouldSucceed()
        {
            MaximizeEventArgs args = new MaximizeEventArgs(true);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test MaximizeEventArgs can be used in handlers
        /// </summary>
        [Fact]
        public void MaximizeEventArgsInHandler_ShouldWork()
        {
            MaximizeEventArgs args = new MaximizeEventArgs(true);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test ContentScaleEventArgs is instantiable
        /// </summary>
        [Fact]
        public void ContentScaleEventArgsConstructor_ShouldSucceed()
        {
            ContentScaleEventArgs args = new ContentScaleEventArgs(1.5f, 1.5f);

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Test ContentScaleEventArgs XScale property
        /// </summary>
        [Fact]
        public void ContentScaleEventArgsXScale_ShouldReturnCorrectValue()
        {
            float xScale = 1.5f;
            ContentScaleEventArgs args = new ContentScaleEventArgs(xScale, 1.5f);

            float retrievedXScale = args.XScale;

            Assert.Equal(xScale, retrievedXScale);
        }

        /// <summary>
        ///     Test ContentScaleEventArgs YScale property
        /// </summary>
        [Fact]
        public void ContentScaleEventArgsYScale_ShouldReturnCorrectValue()
        {
            float yScale = 2.0f;
            ContentScaleEventArgs args = new ContentScaleEventArgs(1.5f, yScale);

            float retrievedYScale = args.YScale;

            Assert.Equal(yScale, retrievedYScale);
        }

        /// <summary>
        ///     Test all EventArgs types are EventArgs subclasses
        /// </summary>
        [Fact]
        public void AllEventArgsAreEventArgsSubclasses_ShouldBeTrue()
        {
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
            FileDropEventArgs fileDropArgs = new FileDropEventArgs(new[] {"file.txt"});
            MaximizeEventArgs maximizeArgs = new MaximizeEventArgs(true);
            ContentScaleEventArgs contentScaleArgs = new ContentScaleEventArgs(1.5f, 1.5f);

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