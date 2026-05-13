// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IStyle.cs
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
    ///     Fluent builder interface that applies a named visual style, theme,
    ///     or CSS-like configuration to a UI element or entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The style definition — a style object, theme key, or style sheet reference.</typeparam>
    /// <remarks>
    ///     Styles bundle visual properties (colors, fonts, borders, spacing)
    ///     into reusable configurations. Changes to a style propagate to all
    ///     elements that reference it.
    /// </remarks>
    public interface IStyle<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Applies a visual style or theme to the builder's target element.
        /// </summary>
        /// <param name="value">The style definition, theme key, or style sheet reference.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Style(TArgument value);
    }
}