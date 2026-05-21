

using System;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Server message event arguments
    /// </summary>
    public class ServerMessageEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes server message event args
        /// </summary>
        public ServerMessageEventArgs(string channel, string message)
        {
            Channel = channel;
            Message = message;
        }

        /// <summary>
        ///     Gets channel
        /// </summary>
        public string Channel { get; }

        /// <summary>
        ///     Gets message
        /// </summary>
        public string Message { get; }
    }
}