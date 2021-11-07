// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VideoGame.cs
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
using Alis.Builders;
using Alis.Core;
using Alis.Core.Sfml.Managers;
using Alis.Core.Systems;

namespace Alis
{
    /// <summary>
    ///     Define a video game on Alis.
    /// </summary>
    /// <seealso cref="Game" />
    public class VideoGame : Game
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoGame" /> class
        /// </summary>
        public VideoGame()
        {
            InputSystem = new InputManager();
            SceneSystem = new SceneManager();
            PhysicsSystem = new PhysicsManager();
            RenderSystem = new RenderManager();
        }

        /// <summary>
        ///     Creates
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Create() => new VideoGameBuilder();
        
        /// <summary>
        /// Destroy object.
        /// </summary>
        ~VideoGame() => Console.WriteLine(@$"Destroy VideoGame {GetHashCode().ToString()}");
    }
}