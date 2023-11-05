// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic;

namespace Alis.Builder.Core.Graphic
{
    /// <summary>
    /// The window builder class
    /// </summary>
    /// <seealso cref="IBuild{Window}"/>
    public class WindowBuilder:
        IBuild<Window>,
        IBackground<WindowBuilder, Color>,
        IResolution<WindowBuilder, float, float>
    {
        /// <summary>
        /// The window
        /// </summary>
        private readonly Window window = new Window();

        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The window</returns>
        public Window Build() => window;

        /// <summary>
        /// Backgrounds the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The window builder</returns>
        public WindowBuilder Background(Color value)
        {
            window.Background = value;
            return this;
        }

        /// <summary>
        /// Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The window builder</returns>
        public WindowBuilder Resolution(float x, float y)
        {
            window.Resolution = new Vector2(x, y);
            return this;
        }
    }
}