// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Window.cs
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

using System.Numerics;
using Alis.Builder.Core.Entity;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Graphic.SFML.Graphics;

namespace Alis.Core.Entity
{
    /// <summary>
    ///     The window class
    /// </summary>
    public class Window :
        IBuilder<WindowBuilder>
    {
        /// <summary>
        ///     Gets or sets the value of the background
        /// </summary>
        public Color Background { get; set; } = Color.Black;

        /// <summary>
        ///     Gets or sets the value of the resolution
        /// </summary>
        public Vector2 Resolution { get; set; } = new Vector2(640, 480);

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The window builder</returns>
        public WindowBuilder Builder() => new WindowBuilder();
    }
}