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

using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Profile;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Setting;

namespace Alis
{
    /// <summary>
    ///     The video game class
    /// </summary>
    /// <seealso cref="Game" />
    public class VideoGame : Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGame"/> class
        /// </summary>
        /// <param name="managers"></param>
        public VideoGame(params IManager<IGame>[] managers) : base(managers)
        {   
            Settings = new Settings();
            Add(new AudioManager(this));
        }
        
        /// <summary>
        ///     Gets or sets the value of the audio manager
        /// </summary>
        public AudioManager AudioManager => Find<AudioManager>();
        
        /// <summary>
        ///     Gets or sets the value of the graphic manager
        /// </summary>
        public GraphicManager GraphicManager => Find<GraphicManager>();
        
        /// <summary>
        ///     Gets or sets the value of the input manager
        /// </summary>
        public InputManager InputManager => Find<InputManager>();
        
        /// <summary>
        ///     Gets or sets the value of the network manager
        /// </summary>
        public NetworkManager NetworkManager => Find<NetworkManager>();
        
        /// <summary>
        ///     Gets or sets the value of the physic manager
        /// </summary>
        public PhysicManager PhysicManager => Find<PhysicManager>();
        
        /// <summary>
        ///     Gets or sets the value of the profile manager
        /// </summary>
        public ProfileManager ProfileManager => Find<ProfileManager>();
        
        /// <summary>
        ///     Gets or sets the value of the scene manager
        /// </summary>
        public SceneManager SceneManager => Find<SceneManager>();
        
        /// <summary>
        /// Get the time manager
        /// </summary>
        public new TimeManager TimeManager => base.TimeManager;
        
        /// <summary>
        ///     Gets or sets the value of the setting
        /// </summary>
        public Settings Settings  { get; set; }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}