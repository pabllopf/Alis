// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGame.cs
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

using System.Collections.Generic;
using Alis.Builder;
using Alis.Core;
using Alis.Core.Manager;
using Alis.Core.Manager.Audio;
using Alis.Core.Manager.Graphic;
using Alis.Core.Manager.Input;
using Alis.Core.Manager.Physic;
using Alis.Core.Manager.Scene;

namespace Alis
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="GameBase" />
    public class VideoGame : GameBase
    {
        /// <summary>
        /// Gets or sets the value of the input manager
        /// </summary>
        public static InputManager InputManager { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the physic manager
        /// </summary>
        public static PhysicManager PhysicManager { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the graphic manager
        /// </summary>
        public static GraphicManager GraphicManager { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the scene manager
        /// </summary>
        public static SceneManager SceneManager { get; set; }
        
        /// <summary>
        /// Gets the value of the audio manager
        /// </summary>
        public static AudioManager AudioManager { get; set; }
        
        /// <summary>
        ///     Video game
        /// </summary>
        public VideoGame()
        {
            PhysicManager = new PhysicManager();
            GraphicManager = new GraphicManager();
            SceneManager = new SceneManager();
            AudioManager = new AudioManager();
            InputManager = new InputManager();
            
            Managers = new List<ManagerBase>
            {
                PhysicManager,
                GraphicManager,
                SceneManager,
                AudioManager,
                InputManager,
            };
        }

        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}