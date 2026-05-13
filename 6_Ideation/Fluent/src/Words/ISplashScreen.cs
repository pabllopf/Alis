// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ISplashScreen.cs
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
    ///     Fluent builder interface that configures the splash screen
    ///     displayed during application startup.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The splash screen configuration — typically a logo texture, animation, or display duration.</typeparam>
    /// <remarks>
    ///     The splash screen is the first visual element presented to users.
    ///     It may include a company logo, loading progress bar, or animated intro.
    ///     Related interfaces: <see cref="IBackgroundColor"/>, <see cref="ILoadingScreen"/>.
    /// </remarks>
    public interface ISplashScreen<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures the splash screen using the specified value.
        /// </summary>
        /// <param name="value">The splash screen configuration — logo texture, animation descriptor, or display settings.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder SplashScreen(TArgument value);
    }
}