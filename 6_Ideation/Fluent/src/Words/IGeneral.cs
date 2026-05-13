// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IGeneral.cs
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
    ///     Fluent builder interface for configuring general-purpose,
    ///     global game settings that apply across the entire application.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The general settings type, typically a configuration object with engine-wide parameters.</typeparam>
    /// <remarks>
    ///     Used to set application-wide properties such as target frame rate,
    ///     global time scale, rendering quality presets, or platform-specific defaults.
    ///     These settings affect all scenes and entities unless overridden locally.
    /// </remarks>
    public interface IGeneral<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures general application settings on the builder.
        /// </summary>
        /// <param name="value">The general settings object containing engine-wide configuration parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder General(TArgument value);
    }
}