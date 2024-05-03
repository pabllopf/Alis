// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Context.cs
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

using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    ///     The context class
    /// </summary>
    /// <seealso />
    public class Context : IContext
    {
        /// <summary>
        ///     The video game
        /// </summary>
        private readonly VideoGame videoGame;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="videoGame">The video game</param>
        /// <param name="settings">The settings</param>
        public Context(VideoGame videoGame, Settings settings)
        {
            this.videoGame = videoGame;
            Settings = settings;
        }
        
        /// <summary>
        ///     Gets the value of the audio manager
        /// </summary>
        public AudioManager AudioManager => videoGame.Find<AudioManager>();
        
        /// <summary>
        ///     Gets the value of the graphic manager
        /// </summary>
        public GraphicManager GraphicManager => videoGame.Find<GraphicManager>();
        
        /// <summary>
        ///     Gets the value of the input manager
        /// </summary>
        public InputManager InputManager => videoGame.Find<InputManager>();
        
        /// <summary>
        ///     Gets the value of the network manager
        /// </summary>
        public NetworkManager NetworkManager => videoGame.Find<NetworkManager>();
        
        /// <summary>
        ///     Gets the value of the physic manager
        /// </summary>
        public PhysicManager PhysicManager => videoGame.Find<PhysicManager>();
        
        /// <summary>
        ///     Gets the value of the time manager
        /// </summary>
        public TimeManager TimeManager => videoGame.TimeManager;
        
        /// <summary>
        ///     The settings
        /// </summary>
        public Settings Settings { get; internal set; }
        
        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        public SceneManager SceneManager => videoGame.Find<SceneManager>();
        
        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => videoGame.Exit();
    }
}