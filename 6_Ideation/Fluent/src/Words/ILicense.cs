// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILicense.cs
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
    ///     Fluent builder interface that sets the software license
    ///     or usage terms for the application or game.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The license type — typically a string, enum, or license descriptor object.</typeparam>
    /// <remarks>
    ///     This is primarily used for metadata, splash screens, or compliance checks.
    ///     Common values include "MIT", "GPL-3.0", "Commercial", etc.
    ///     The license does not affect runtime behavior.
    /// </remarks>
    public interface ILicense<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the license identifier on the builder.
        /// </summary>
        /// <param name="value">The license string, enum value, or license descriptor.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder License(TArgument value);
    }
}