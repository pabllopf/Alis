// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IProfile.cs
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
    ///     Fluent builder interface that selects or configures an operational profile
    ///     for the game or a subsystem.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The profile type — typically an enum, string key, or profile descriptor object.</typeparam>
    /// <remarks>
    ///     Profiles bundle multiple settings into a named configuration. Examples:
    ///     "HighPerformance" (high FPS, reduced effects), "Cinematic" (high quality, lower FPS),
    ///     "Mobile" (touch input, reduced resolution). This may affect rendering quality,
    ///     physics accuracy, and input mappings simultaneously.
    /// </remarks>
    public interface IProfile<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies the selected profile to the builder.
        /// </summary>
        /// <param name="value">The profile identifier or configuration object.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Profile(TArgument value);
    }
}