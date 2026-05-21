

using System;
using System.IO;
using System.Text;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The web socket frame writer test class
    /// </summary>
    public class WebSocketFrameWriterTest
    {
        /// <summary>
        ///     Tests that write valid input
        /// </summary>
        [Fact]
        public void Write_ValidInput()
        {
            WebSocketOpCode opCode = WebSocketOpCode.TextFrame;
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Test data"));
            MemoryStream toStream = new MemoryStream();
            bool isLastFrame = true;
            bool isClient = true;

            WebSocketFrameWriter.Write(opCode, fromPayload, toStream, isLastFrame, isClient);

        }

        /// <summary>
        ///     Tests that write should write correctly when is last frame and is client are true
        /// </summary>
        [Fact]
        public void Write_ShouldWriteCorrectly_WhenIsLastFrameAndIsClientAreTrue()
        {
            WebSocketOpCode opCode = WebSocketOpCode.TextFrame;
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(new byte[10]);
            MemoryStream toStream = new MemoryStream();
            bool isLastFrame = true;
            bool isClient = true;

            WebSocketFrameWriter.Write(opCode, fromPayload, toStream, isLastFrame, isClient);

            toStream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(toStream);
            byte firstByte = reader.ReadByte();
            Assert.Equal(0x81, firstByte); // 0x80 | TextFrame

            byte secondByte = reader.ReadByte();
            Assert.Equal(0x8A, secondByte); // 0x80 | payload length
        }

        /// <summary>
        ///     Tests that write should write correctly when is last frame and is client are false
        /// </summary>
        [Fact]
        public void Write_ShouldWriteCorrectly_WhenIsLastFrameAndIsClientAreFalse()
        {
            WebSocketOpCode opCode = WebSocketOpCode.TextFrame;
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(new byte[10]);
            MemoryStream toStream = new MemoryStream();
            bool isLastFrame = false;
            bool isClient = false;

            WebSocketFrameWriter.Write(opCode, fromPayload, toStream, isLastFrame, isClient);

            toStream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(toStream);
            byte firstByte = reader.ReadByte();
            Assert.Equal(0x01, firstByte); // TextFrame

            byte secondByte = reader.ReadByte();
            Assert.Equal(fromPayload.Count, secondByte); // payload length

            byte[] payload = reader.ReadBytes(fromPayload.Count);
            Assert.Equal(fromPayload.Array, payload);
        }

        /// <summary>
        ///     Tests that determine payload count should return correct value
        /// </summary>
        [Fact]
        public void DeterminePayloadCount_ShouldReturnCorrectValue()
        {
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(new byte[ushort.MaxValue + 1]);

            int result = WebSocketFrameWriter.DeterminePayloadCount(fromPayload);

            Assert.Equal(127, result);
        }

        /// <summary>
        ///     Tests that write payload data should write correctly when payload count is less than or equal to u short max value
        /// </summary>
        [Fact]
        public void WritePayloadData_ShouldWriteCorrectly_WhenPayloadCountIsLessThanOrEqualToUShortMaxValue()
        {
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(new byte[ushort.MaxValue]);
            MemoryStream toStream = new MemoryStream();

            WebSocketFrameWriter.WritePayloadData(fromPayload, toStream);

            toStream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(toStream);
            ushort payloadCount = reader.ReadUInt16();

            Assert.Equal(fromPayload.Count, payloadCount);
        }

        /// <summary>
        ///     Tests that write payload data should write correctly when payload count is greater than u short max value
        /// </summary>
        [Fact]
        public void WritePayloadData_ShouldWriteCorrectly_WhenPayloadCountIsGreaterThanUShortMaxValue()
        {
            ArraySegment<byte> fromPayload = new ArraySegment<byte>(new byte[ushort.MaxValue + 1]);
            MemoryStream toStream = new MemoryStream();

            WebSocketFrameWriter.WritePayloadData(fromPayload, toStream);

            toStream.Seek(0, SeekOrigin.Begin);
            BinaryReader reader = new BinaryReader(toStream);
            ulong payloadCount = reader.ReadUInt64();

            Assert.Equal(1099511627776U, payloadCount);
        }
    }
}