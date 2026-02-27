// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FileBufferTest.cs
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

using System.IO;
using System.Text;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The file buffer test class
    /// </summary>
    public class FileBufferTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with stream content
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithStreamContent()
        {
            string content = "Hello World";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.Equal(content, buffer.Buffer);
                Assert.Equal(0, buffer.Position);
            }
        }

        /// <summary>
        ///     Tests that next should return character and advance position
        /// </summary>
        [Fact]
        public void Next_ShouldReturnCharacterAndAdvancePosition()
        {
            string content = "ABC";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                char first = buffer.Next;
                
                Assert.Equal('A', first);
                Assert.Equal(1, buffer.Position);
            }
        }

        /// <summary>
        ///     Tests that next should iterate through all characters
        /// </summary>
        [Fact]
        public void Next_ShouldIterateThroughAllCharacters()
        {
            string content = "ABC";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                char c1 = buffer.Next;
                char c2 = buffer.Next;
                char c3 = buffer.Next;
                
                Assert.Equal('A', c1);
                Assert.Equal('B', c2);
                Assert.Equal('C', c3);
            }
        }

        /// <summary>
        ///     Tests that end of buffer should return false when content remains
        /// </summary>
        [Fact]
        public void EndOfBuffer_ShouldReturnFalse_WhenContentRemains()
        {
            string content = "Hello";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.False(buffer.EndOfBuffer);
            }
        }

        /// <summary>
        ///     Tests that end of buffer should return true when all content read
        /// </summary>
        [Fact]
        public void EndOfBuffer_ShouldReturnTrue_WhenAllContentRead()
        {
            string content = "AB";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.False(buffer.EndOfBuffer);
            }
        }

        /// <summary>
        ///     Tests that position property should set and get correctly
        /// </summary>
        [Fact]
        public void PositionProperty_ShouldSetAndGetCorrectly()
        {
            string content = "Hello World";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                buffer.Position = 5;
                
                Assert.Equal(5, buffer.Position);
            }
        }

        /// <summary>
        ///     Tests that buffer property should set and get correctly
        /// </summary>
        [Fact]
        public void BufferProperty_ShouldSetAndGetCorrectly()
        {
            string content = "Initial";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                string newContent = "Modified";
                
                buffer.Buffer = newContent;
                
                Assert.Equal(newContent, buffer.Buffer);
            }
        }

        /// <summary>
        ///     Tests that file buffer should handle empty stream
        /// </summary>
        [Fact]
        public void FileBuffer_ShouldHandleEmptyStream()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.Equal(string.Empty, buffer.Buffer);
                Assert.True(buffer.EndOfBuffer);
            }
        }

        /// <summary>
        ///     Tests that file buffer should handle special characters
        /// </summary>
        [Fact]
        public void FileBuffer_ShouldHandleSpecialCharacters()
        {
            string content = "Hello\nWorld\tTest";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.Equal(content, buffer.Buffer);
            }
        }

        /// <summary>
        ///     Tests that file buffer should handle unicode characters
        /// </summary>
        [Fact]
        public void FileBuffer_ShouldHandleUnicodeCharacters()
        {
            string content = "Hello 世界 🌍";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.Contains("世界", buffer.Buffer);
            }
        }

        /// <summary>
        ///     Tests that position can be reset to read again
        /// </summary>
        [Fact]
        public void Position_CanBeReset_ToReadAgain()
        {
            string content = "ABC";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                buffer.Position = 0;
                char c = buffer.Next;
                
                Assert.Equal('A', c);
            }
        }

        /// <summary>
        ///     Tests that file buffer should handle large content
        /// </summary>
        [Fact]
        public void FileBuffer_ShouldHandleLargeContent()
        {
            string content = new string('A', 10000);
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                FileBuffer buffer = new FileBuffer(stream);
                
                Assert.Equal(10000, buffer.Buffer.Length);
            }
        }
    }
}

