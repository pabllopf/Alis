

using System;
using Xunit;

namespace Alis.Extension.Network.Test
{
    /// <summary>
    ///     The pong event args test class
    /// </summary>
    public class PongEventArgsTest
    {
        /// <summary>
        ///     Tests that pong event args constructor
        /// </summary>
        [Fact]
        public void PongEventArgs_Constructor()
        {
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[0]);
            PongEventArgs pongEventArgs = new PongEventArgs(payload);
            Assert.NotNull(pongEventArgs);
        }

        /// <summary>
        ///     Tests that pong event args payload
        /// </summary>
        [Fact]
        public void PongEventArgs_Payload()
        {
            ArraySegment<byte> payload = new ArraySegment<byte>(new byte[] {1, 2, 3});
            PongEventArgs pongEventArgs = new PongEventArgs(payload);
            Assert.Equal(payload, pongEventArgs.Payload);
        }
    }
}