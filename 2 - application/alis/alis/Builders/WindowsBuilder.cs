// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WindowsBuilder.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;
using Alis.Core;
using Alis.Core.Configurations;
using Alis.Core.FluentApi;
using Alis.Core.FluentApi.Words;

namespace Alis.Builders
{
    /// <summary>
    ///     The window builder class
    /// </summary>
    /// <seealso cref="IBuild{TOrigin}" />
    /// <seealso cref="IResolution{TBuilder,TArgument1,TArgument2}" />
    public class WindowBuilder :
        IBuild<Window>,
        IResolution<WindowBuilder, int, int>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The window</returns>
        public Window Build()
        {
            return Game.Setting.Window;
        }

        /// <summary>
        ///     Resolutions the x
        /// </summary>
        /// <param name="width">The </param>
        /// <param name="height">The </param>
        /// <returns>The window builder</returns>
        public WindowBuilder Resolution(int width, int height)
        {
            Game.Setting.Window.Resolution = new Vector2(width, height);
            return this;
        }

        /// <summary>
        ///     Screens the mode using the specified screen mode
        /// </summary>
        /// <param name="screenMode">The screen mode</param>
        /// <returns>The window builder</returns>
        public WindowBuilder ScreenMode(ScreenMode screenMode)
        {
            Game.Setting.Window.ScreenMode = screenMode;
            return this;
        }
    }
}