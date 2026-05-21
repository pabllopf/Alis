

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems.Configuration.Network
{
    /// <summary>
    ///     The network setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NetworkSetting(
        int port,
        string ip,
        string host,
        string protocol) : INetworkSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkSetting" /> class with default values.
        /// </summary>
        public NetworkSetting() : this(8080, "127.0.0.1", "localhost", "http")
        {
        }

        /// <summary>
        ///     Gets or sets the value of the port
        /// </summary>
        public int Port { get; set; } = port;

        /// <summary>
        ///     Gets or sets the value of the ip
        /// </summary>
        public string Ip { get; set; } = ip;

        /// <summary>
        ///     Gets or sets the value of the host
        /// </summary>
        public string Host { get; set; } = host;

        /// <summary>
        ///     Gets or sets the value of the protocol
        /// </summary>
        public string Protocol { get; set; } = protocol;
    }
}