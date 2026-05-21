// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ICloud.cs
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
    ///     Fluent builder interface that configures cloud save, sync,
    ///     or remote storage settings for game data and profiles.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The cloud configuration type — provider, sync policy, or encryption settings.</typeparam>
    /// <remarks>
    ///     Enables cross-device save synchronization, leaderboard integration,
    ///     or cloud-based content delivery. Configuration varies by provider
    ///     (Google Play Games, Game Center, Steam Cloud, etc.).
    /// </remarks>
    public interface ICloud<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures cloud sync/storage settings on the builder.
        /// </summary>
        /// <param name="value">The cloud configuration — provider, sync policy, or storage parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Cloud(TArgument value);
    }
}