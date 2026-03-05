using System;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Player event arguments
    /// </summary>
    public class PlayerEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes player event args
        /// </summary>
        public PlayerEventArgs(NetworkPlayer player)
        {
            Player = player;
        }

        /// <summary>
        ///     Gets the player
        /// </summary>
        public NetworkPlayer Player { get; }
    }
}