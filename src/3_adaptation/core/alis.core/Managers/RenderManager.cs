// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   RenderManager.cs
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

using System;
using System.Numerics;
using System.Text.Json.Serialization;
using Alis.Core.Entities;

namespace Alis.Core.Managers
{
    /// <summary>Implement the render system of SFML library.</summary>
    public class RenderManager 
    {
        /// <summary>Initializes a new instance of the <see cref="RenderManager" /> class.</summary>
        [JsonConstructor]
        public RenderManager()
        {
        }
        
        /// <summary>
        ///     Generals the on change name using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="name">The name</param>
        private void General_OnChangeName(object? sender, string name)
        {
        }

        /// <summary>
        ///     Generals the on change author using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="author">The author</param>
        private void General_OnChangeAuthor(object? sender, string author)
        {
            
        }


        /// <summary>Renders the window closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object? sender, EventArgs e)
        {
            
        }

        /// <summary>
        ///     Windows the on change screen mode using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="screenMode">The screen mode</param>
        private void Window_OnChangeScreenMode(object? sender, ScreenMode screenMode)
        {
            
        }

        /// <summary>
        ///     Windows the on change resolution using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="resolution">The resolution</param>
        private void Window_OnChangeResolution(object? sender, Vector2 resolution)
        {
            
        }

        /// <summary>Finalizes an instance of the <see cref="RenderManager" /> class.</summary>
        ~RenderManager()
        {
            
        }
    }
}