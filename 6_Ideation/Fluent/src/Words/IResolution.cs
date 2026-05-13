// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IResolution.cs
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
    ///     Fluent builder interface that sets the display resolution
    ///     for the game window or rendering surface.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument1">The width type, typically <see cref="int"/>.</typeparam>
    /// <typeparam name="TArgument2">The height type, typically <see cref="int"/>.</typeparam>
    /// <remarks>
    ///     Sets the rendering resolution in pixels. Common values: 1920×1080 (Full HD),
    ///     1280×720 (HD), 3840×2160 (4K). On windowed platforms, this may also control
    ///     the window client area size. Related interfaces: <see cref="IFixedRotation"/>,
    ///     <see cref="IWindow"/>.
    /// </remarks>
    public interface IResolution<out TBuilder, in TArgument1, in TArgument2>
    {
        /// <summary>
        ///     Sets the display resolution width and height.
        /// </summary>
        /// <param name="x">The horizontal resolution (width) in pixels.</param>
        /// <param name="y">The vertical resolution (height) in pixels.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Resolution(TArgument1 x, TArgument2 y);
    }
}