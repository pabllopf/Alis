// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTest.cs
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

// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTest.cs
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

using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextInputEvent struct.
    /// </summary>
    public class TextInputEventTest
    {
        [Fact]
        public void ShouldReturnTextBytesFromStruct()
        {
            // Arrange: Fill each byte field with unique values
            var evt = new TextInputEvent();
            for (int i = 0; i < 32; ++i)
            {
                typeof(TextInputEvent).GetField($"byte{i}", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValueDirect(__makeref(evt), (byte)(i + 1));
            }
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.Equal(32, bytes.Length);
            for (int i = 0; i < 32; ++i)
            {
                Assert.Equal((byte)(i + 1), bytes[i]);
            }
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTest.cs
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

using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextInputEvent struct.
    /// </summary>
    public class TextInputEventTest
    {
        [Fact]
        public void ShouldReturnTextBytesFromStruct()
        {
            // Arrange: Fill each byte field with unique values
            var evt = new TextInputEvent();
            for (int i = 0; i < 32; ++i)
            {
                typeof(TextInputEvent).GetField($"byte{i}", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValueDirect(__makeref(evt), (byte)(i + 1));
            }
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.Equal(32, bytes.Length);
            for (int i = 0; i < 32; ++i)
            {
                Assert.Equal((byte)(i + 1), bytes[i]);
            }
        }

        [Fact]
        public void ShouldReturnAllZerosWhenDefault()
        {
            // Arrange
            var evt = new TextInputEvent(); // All internals are 0
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.All(bytes, b => Assert.Equal(0, b));
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTest.cs
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

using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextInputEvent struct.
    /// </summary>
    public class TextInputEventTest
    {
        [Fact]
        public void ShouldReturnTextBytesFromStruct()
        {
            // Arrange: Fill each byte field with unique values
            var evt = new TextInputEvent();
            for (int i = 0; i < 32; ++i)
            {
                typeof(TextInputEvent).GetField($"byte{i}", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValueDirect(__makeref(evt), (byte)(i + 1));
            }
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.Equal(32, bytes.Length);
            for (int i = 0; i < 32; ++i)
            {
                Assert.Equal((byte)(i + 1), bytes[i]);
            }
        }

        [Fact]
        public void ShouldReturnAllZerosWhenDefault()
        {
            // Arrange
            var evt = new TextInputEvent(); // All internals are 0
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.All(bytes, b => Assert.Equal(0, b));
        }

        [Fact]
        public void ShouldAllowPublicFieldAssignmentsAndRetrieveCorrectly()
        {
            // Arrange
            var evt = new TextInputEvent
            {
                type = EventType.TextInput,
                timestamp = 1234u,
                windowID = 9u
            };

            // Assert
            Assert.Equal(EventType.TextInput, evt.type);
            Assert.Equal(1234u, evt.timestamp);
            Assert.Equal(9u, evt.windowID);
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextInputEventTest.cs
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

using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextInputEvent struct.
    /// </summary>
    public class TextInputEventTest
    {
        [Fact]
        public void ShouldReturnTextBytesFromStruct()
        {
            // Arrange: Fill each byte field with unique values
            var evt = new TextInputEvent();
            for (int i = 0; i < 32; ++i)
            {
                typeof(TextInputEvent).GetField($"byte{i}", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValueDirect(__makeref(evt), (byte)(i + 1));
            }
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.Equal(32, bytes.Length);
            for (int i = 0; i < 32; ++i)
            {
                Assert.Equal((byte)(i + 1), bytes[i]);
            }
        }

        [Fact]
        public void ShouldReturnAllZerosWhenDefault()
        {
            // Arrange
            var evt = new TextInputEvent(); // All internals are 0
            // Act
            var bytes = evt.Text;
            // Assert
            Assert.All(bytes, b => Assert.Equal(0, b));
        }

        [Fact]
        public void ShouldAllowPublicFieldAssignmentsAndRetrieveCorrectly()
        {
            // Arrange
            var evt = new TextInputEvent
            {
                type = EventType.TextInput,
                timestamp = 1234u,
                windowID = 9u
            };

            // Assert
            Assert.Equal(EventType.TextInput, evt.type);
            Assert.Equal(1234u, evt.timestamp);
            Assert.Equal(9u, evt.windowID);
        }

        [Fact]
        public void ShouldHandleAllOnesInBytes()
        {
            // Arrange
            var evt = new TextInputEvent();
            for (int i = 0; i < 32; ++i)
            {
                typeof(TextInputEvent).GetField($"byte{i}", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                    .SetValueDirect(__makeref(evt), (byte)255);
            }
            // Act
            var bytes = evt.Text;
            // Assert: all bytes should be 255
            Assert.All(bytes, b => Assert.Equal(255, b));
        }
    }
}
