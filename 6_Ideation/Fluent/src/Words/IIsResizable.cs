// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IIsResizable.cs
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
    ///     Fluent builder interface that enables or disables resizing behavior
    ///     for a game window, UI element, or render surface.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The resizable state — typically a boolean toggle (no-argument overload always enables).</typeparam>
    /// <remarks>
    ///     When resizable is enabled, the user or system can change the dimensions
    ///     of the target (e.g., game window or UI panel). Disabling fixes the size.
    /// </remarks>
    public interface IIsResizable<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Enables resizing on the builder (no argument overload — always enabled).
        /// </summary>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder IsResizable();
    }
}