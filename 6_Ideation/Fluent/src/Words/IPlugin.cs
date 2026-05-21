// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPlugin.cs
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
    ///     Fluent builder interface that registers or configures a plugin
    ///     or extension module on the game engine or a specific subsystem.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The plugin configuration, type, or initialization parameters.</typeparam>
    /// <remarks>
    ///     Plugins extend engine functionality — such as custom physics solvers,
    ///     procedural generation modules, analytics hooks, or third-party SDK integrations.
    ///     The plugin is typically initialized when the builder's <see cref="IBuild{TOrigin}.Build()"/> is called.
    /// </remarks>
    public interface IPlugin<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Registers or configures a plugin on the builder.
        /// </summary>
        /// <param name="value">The plugin configuration, instance, or initialization parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Plugin(TArgument value);
    }
}