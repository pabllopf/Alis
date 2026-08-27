// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTests.cs
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

using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextInputEvent struct.
    /// </summary>
    public class TextInputEventsTest
    {
        /// <summary>
        ///     Tests that the default event type is FirstEvent.
        /// </summary>
        [Fact]
        public void ShouldDefaultTypeToFirstEvent()
        {
            // Arrange
            TextInputEvent evt = new TextInputEvent();
            // Act
            EventType type = evt.type;
            // Assert
            Assert.Equal(EventType.FirstEvent, type);
        }

        /// <summary>
        ///     Tests that the default timestamp is zero.
        /// </summary>
        [Fact]
        public void ShouldDefaultTimestampToZero()
        {
            // Arrange
            TextInputEvent evt = new TextInputEvent();
            // Act
            uint timestamp = evt.timestamp;
            // Assert
            Assert.Equal(0u, timestamp);
        }

        /// <summary>
        ///     Tests that the default window id is zero.
        /// </summary>
        [Fact]
        public void ShouldDefaultWindowIdToZero()
        {
            // Arrange
            TextInputEvent evt = new TextInputEvent();
            // Act
            uint windowId = evt.windowID;
            // Assert
            Assert.Equal(0u, windowId);
        }

        /// <summary>
        ///     Tests that the Text property returns a thirty two byte buffer.
        /// </summary>
        [Fact]
        public void ShouldReturnTextOfLengthThirtyTwo()
        {
            // Arrange
            TextInputEvent evt = new TextInputEvent();
            // Act
            byte[] text = evt.Text;
            // Assert
            Assert.Equal(32, text.Length);
        }

        /// <summary>
        ///     Tests that the Text property returns all zeros when the event is default.
        /// </summary>
        [Fact]
        public void ShouldReturnAllZeroTextWhenDefault()
        {
            // Arrange
            TextInputEvent evt = new TextInputEvent();
            // Act
            byte[] text = evt.Text;
            // Assert
            Assert.All(text, b => Assert.Equal(0, b));
        }

        /// <summary>
        ///     Tests that the public fields can be assigned and read back.
        /// </summary>
        [Fact]
        public void ShouldRoundTripPublicFields()
        {
            // Arrange
            TextInputEvent evt = new TextInputEvent();
            // Act
            evt.type = EventType.TextInput;
            evt.timestamp = 42u;
            evt.windowID = 7u;
            // Assert
            Assert.Equal(EventType.TextInput, evt.type);
            Assert.Equal(42u, evt.timestamp);
            Assert.Equal(7u, evt.windowID);
        }
    }
}
