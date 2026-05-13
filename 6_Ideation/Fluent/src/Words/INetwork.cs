// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INetwork.cs
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

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures network replication,
    ///     multiplayer synchronization, or remote communication settings.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The network configuration type — replication mode, authority settings, or connection parameters.</typeparam>
    /// <remarks>
    ///     Used for multiplayer games to configure which entities are replicated,
    ///     who has authority (server vs client), and how state is synchronized.
    ///     Relevant only in networked/multiplayer contexts.
    /// </remarks>
    public interface INetwork<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures network replication/communication settings on the builder.
        /// </summary>
        /// <param name="value">The network configuration — replication mode, authority, or connection parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Network(TArgument value);
    }
}