using System;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Client disconnection event arguments
    /// </summary>
    public class ClientDisconnectionEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes client disconnection event args
        /// </summary>
        public ClientDisconnectionEventArgs(string clientId, string reason = null)
        {
            ClientId = clientId;
            Reason = reason;
        }

        /// <summary>
        ///     Gets client ID
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        ///     Gets disconnection reason
        /// </summary>
        public string Reason { get; }
    }
}