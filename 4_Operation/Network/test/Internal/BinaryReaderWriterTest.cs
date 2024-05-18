// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BinaryReaderWriterTest.cs
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
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Internal;
using Xunit;

namespace Alis.Core.Network.Test.Internal
{
    /// <summary>
    /// The binary reader writer test class
    /// </summary>
    public class BinaryReaderWriterTest
    {
        /// <summary>
        /// Tests that read exactly valid input
        /// </summary>
        [Fact]
        public async Task ReadExactly_ValidInput()
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("Test data"));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            await BinaryReaderWriter.ReadExactly(8, stream, buffer, CancellationToken.None);
            Assert.Equal("Test dat", Encoding.UTF8.GetString(buffer.Array));
        }
        
        /// <summary>
        /// Tests that read u short exactly valid input
        /// </summary>
        [Fact]
        public async Task ReadUShortExactly_ValidInput()
        {
            MemoryStream stream = new MemoryStream(BitConverter.GetBytes((ushort) 12345));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2]);
            ushort result = await BinaryReaderWriter.ReadUShortExactly(stream, BitConverter.IsLittleEndian, buffer, CancellationToken.None);
            Assert.Equal((ushort) 12345, result);
        }
        
        /// <summary>
        /// Tests that read u long exactly valid input
        /// </summary>
        [Fact]
        public async Task ReadULongExactly_ValidInput()
        {
            MemoryStream stream = new MemoryStream(BitConverter.GetBytes((ulong) 1234567890123456789));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            ulong result = await BinaryReaderWriter.ReadULongExactly(stream, BitConverter.IsLittleEndian, buffer, CancellationToken.None);
            Assert.Equal((ulong) 1234567890123456789, result);
        }
        
        /// <summary>
        /// Tests that read long exactly valid input
        /// </summary>
        [Fact]
        public async Task ReadLongExactly_ValidInput()
        {
            MemoryStream stream = new MemoryStream(BitConverter.GetBytes((long) 1234567890123456789));
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[8]);
            long result = await BinaryReaderWriter.ReadLongExactly(stream, BitConverter.IsLittleEndian, buffer, CancellationToken.None);
            Assert.Equal((long) 1234567890123456789, result);
        }
        
        /// <summary>
        /// Tests that write int valid input
        /// </summary>
        [Fact]
        public void WriteInt_ValidInput()
        {
            MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteInt(123456789, stream, BitConverter.IsLittleEndian);
            Assert.Equal(BitConverter.GetBytes(123456789), stream.ToArray());
        }
        
        /// <summary>
        /// Tests that write u long valid input
        /// </summary>
        [Fact]
        public void WriteULong_ValidInput()
        {
            MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteULong(1234567890123456789, stream, BitConverter.IsLittleEndian);
            Assert.Equal(BitConverter.GetBytes((ulong) 1234567890123456789), stream.ToArray());
        }
        
        /// <summary>
        /// Tests that write long valid input
        /// </summary>
        [Fact]
        public void WriteLong_ValidInput()
        {
            MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteLong(1234567890123456789, stream, BitConverter.IsLittleEndian);
            Assert.Equal(BitConverter.GetBytes((long) 1234567890123456789), stream.ToArray());
        }
        
        /// <summary>
        /// Tests that write u short valid input
        /// </summary>
        [Fact]
        public void WriteUShort_ValidInput()
        {
            MemoryStream stream = new MemoryStream();
            BinaryReaderWriter.WriteUShort(12345, stream, BitConverter.IsLittleEndian);
            Assert.Equal(BitConverter.GetBytes((ushort) 12345), stream.ToArray());
        }
        
        /// <summary>
        /// Tests that write int should write correctly
        /// </summary>
        [Fact]
        public void WriteInt_ShouldWriteCorrectly()
        {
            MemoryStream stream = new MemoryStream();
            int value = 12345;
            bool isLittleEndian = BitConverter.IsLittleEndian;
            
            BinaryReaderWriter.WriteInt(value, stream, isLittleEndian);
            
            stream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(stream);
            int result = reader.ReadInt32();
            
            Assert.Equal(value, result);
        }
        
        /// <summary>
        /// Tests that write u long should write correctly
        /// </summary>
        [Fact]
        public void WriteULong_ShouldWriteCorrectly()
        {
            MemoryStream stream = new MemoryStream();
            ulong value = 12345678901234567890;
            bool isLittleEndian = BitConverter.IsLittleEndian;
            
            BinaryReaderWriter.WriteULong(value, stream, isLittleEndian);
            
            stream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(stream);
            ulong result = reader.ReadUInt64();
            
            Assert.Equal(value, result);
        }
        
        /// <summary>
        /// Tests that write long should write correctly
        /// </summary>
        [Fact]
        public void WriteLong_ShouldWriteCorrectly()
        {
            MemoryStream stream = new MemoryStream();
            long value = 1234567890123456789;
            bool isLittleEndian = BitConverter.IsLittleEndian;
            
            BinaryReaderWriter.WriteLong(value, stream, isLittleEndian);
            
            stream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(stream);
            long result = reader.ReadInt64();
            
            Assert.Equal(value, result);
        }
        
        /// <summary>
        /// Tests that write long should write correctly when little endian
        /// </summary>
        [Fact]
        public void WriteLong_ShouldWriteCorrectly_WhenLittleEndian()
        {
            MemoryStream stream = new MemoryStream();
            long value = 1234567890123456789;
            bool isLittleEndian = true;
            
            BinaryReaderWriter.WriteLong(value, stream, isLittleEndian);
            
            stream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(stream);
            long result = reader.ReadInt64();
            
            Assert.Equal(value, result);
        }
        
        /// <summary>
        /// Tests that write long should write correctly when big endian
        /// </summary>
        [Fact]
        public void WriteLong_ShouldWriteCorrectly_WhenBigEndian()
        {
            MemoryStream stream = new MemoryStream();
            long value = 1549776473967043089;
            bool isLittleEndian = false;
            
            BinaryReaderWriter.WriteLong(value, stream, isLittleEndian);
            
            stream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(stream);
            long result = BitConverter.ToInt64(BitConverter.GetBytes(reader.ReadInt64()), 0);
            
            Assert.True(result > 0);
        }
        
        
    }
}