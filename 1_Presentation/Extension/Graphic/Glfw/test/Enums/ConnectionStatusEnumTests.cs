

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Enums
{
    /// <summary>
    ///     Tests for ConnectionStatus enum
    /// </summary>
    public class ConnectionStatusEnumTests
    {
        /// <summary>
        ///     Tests that connection status connected is defined
        /// </summary>
        [Fact]
        public void ConnectionStatus_Connected_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(ConnectionStatus), ConnectionStatus.Connected));
        }

        /// <summary>
        ///     Tests that connection status disconnected is defined
        /// </summary>
        [Fact]
        public void ConnectionStatus_Disconnected_IsDefined()
        {
            Assert.True(Enum.IsDefined(typeof(ConnectionStatus), ConnectionStatus.Disconnected));
        }

        /// <summary>
        ///     Tests that connection status can be cast to int
        /// </summary>
        [Fact]
        public void ConnectionStatus_CanBeCastToInt()
        {
            ConnectionStatus status = ConnectionStatus.Connected;
            int value = (int) status;
            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Tests that connection status connected and disconnected are different
        /// </summary>
        [Fact]
        public void ConnectionStatus_Connected_And_Disconnected_AreDifferent()
        {
            Assert.NotEqual(ConnectionStatus.Connected, ConnectionStatus.Disconnected);
        }
    }
}