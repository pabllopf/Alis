

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Network;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Network
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class NetworkSettingBuilder :
        IBuild<NetworkSetting>
    {
        /// <summary>
        ///     The audio setting
        /// </summary>
        private readonly NetworkSetting networkSetting = new NetworkSetting();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public NetworkSetting Build() => networkSetting;


        /// <summary>
        ///     Ips the ip
        /// </summary>
        /// <param name="ip">The ip</param>
        /// <returns>The network setting builder</returns>
        public NetworkSettingBuilder Ip(string ip) => this;
    }
}