// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkManagerState.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network manager state enumeration
    /// </summary>
    public enum NetworkManagerState
    {
        /// <summary>
        ///     Not initialized
        /// </summary>
        Uninitialized,

        /// <summary>
        ///     Initialized but not running
        /// </summary>
        Idle,

        /// <summary>
        ///     Connecting
        /// </summary>
        Connecting,

        /// <summary>
        ///     Connected
        /// </summary>
        Connected,

        /// <summary>
        ///     Disconnecting
        /// </summary>
        Disconnecting,

        /// <summary>
        ///     Disconnected
        /// </summary>
        Disconnected,

        /// <summary>
        ///     Error state
        /// </summary>
        Error
    }
}