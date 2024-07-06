// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowSetting.cs
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

using Alis.Core.Aspect.Data.Json;
using Alis.Core.Graphic;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The window setting class
    /// </summary>
    public class WindowSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WindowSetting" /> class
        /// </summary>
        public WindowSetting() => Window = new Window();

        /// <summary>
        ///     Initializes a new instance of the <see cref="WindowSetting" /> class
        /// </summary>
        /// <param name="window">The window</param>
        [JsonConstructor]
        public WindowSetting(Window window) => Window = window;

        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        [JsonPropertyName("_Window_")]
        public Window Window { get; set; }
    }
}