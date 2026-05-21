

namespace Alis.Core.Ecs.Systems.Configuration.Network
{
    /// <summary>
    ///     The network setting interface
    /// </summary>
    public interface INetworkSetting
    {
        /// <summary>
        ///     Gets or sets the value of the port
        /// </summary>
        int Port { get; set; }

        /// <summary>
        ///     Gets or sets the value of the ip
        /// </summary>
        string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the value of the host
        /// </summary>
        string Host { get; set; }

        /// <summary>
        ///     Gets or sets the value of the protocol
        /// </summary>
        string Protocol { get; set; }
    }
}