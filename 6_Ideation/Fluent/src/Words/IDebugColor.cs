// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDebugColor.cs
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
    ///     Fluent builder interface that sets the color used for debug visualization
    ///     overlays such as bounding boxes, collision shapes, and gizmos.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The color type for debug visualization, typically <see cref="Color"/>.</typeparam>
    /// <remarks>
    ///     The debug color affects wireframe overlays, bounding box outlines, and other
    ///     diagnostic visual aids. This only takes effect when debug visualization is enabled
    ///     via <see cref="IDebug{out TBuilder, in TArgument}"/>.
    /// </remarks>
    public interface IDebugColor<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the color used for debug visualization overlays.
        /// </summary>
        /// <param name="value">The debug color value — typically a <see cref="Color"/> struct.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder DebugColor(TArgument value);
    }
}