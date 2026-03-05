using System;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Client connection event arguments
    /// </summary>
    public class ClientConnectionEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes client connection event args
        /// </summary>
        public ClientConnectionEventArgs(string clientId)
        {
            ClientId = clientId;
        }

        /// <summary>
        ///     Gets client ID
        /// </summary>
        public string ClientId { get; }
    }
}