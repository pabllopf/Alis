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
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.System;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Ads;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Plugin;
using Alis.Core.Ecs.System.Manager.Profile;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Manager.Script;
using Alis.Core.Ecs.System.Manager.Store;
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
        /// Gets or sets the value of the instance
        /// </summary>
        public static VideoGame Instance { get; private set; }
        
        /// <summary>
        ///     Video game
        /// </summary>
        public VideoGame()
        {
            Managers = new List<IManager>(new List<Manager>
            {
                new AdsManager(),
                new AudioManager(),
                new PhysicManager(),
                new GraphicManager(),
                new SceneManager(),
                new InputManager(),
                new NetworkManager(),
                new PluginManager(),
                new ScriptManager(),
                new StoreManager(),
                new ProfileManager()
            });

            Logger.Trace();
            
            Instance = this;
        }
        
        /// <summary>
        /// Gets or sets the value of the ads setting
        /// </summary>
        public  AdsManager AdsManager => Get<AdsManager>();
        
        /// <summary>
        /// Gets or sets the value of the audio manager
        /// </summary>
        public  AudioManager AudioManager => Get<AudioManager>();
        
        /// <summary>
        /// Gets or sets the value of the graphic manager
        /// </summary>
        public  GraphicManager GraphicManager => Get<GraphicManager>();
        
        /// <summary>
        /// Gets or sets the value of the input manager
        /// </summary>
        public  InputManager InputManager => Get<InputManager>();
        
        /// <summary>
        /// Gets or sets the value of the network manager
        /// </summary>
        public  NetworkManager NetworkManager => Get<NetworkManager>();
        
        /// <summary>
        /// Gets or sets the value of the physic manager
        /// </summary>
        public  PhysicManager PhysicManager => Get<PhysicManager>();
        
        /// <summary>
        /// Gets or sets the value of the plugin manager
        /// </summary>
        public  PluginManager PluginManager => Get<PluginManager>();
        
        /// <summary>
        /// Gets or sets the value of the profile manager
        /// </summary>
        public  ProfileManager ProfileManager => Get<ProfileManager>();
        
        /// <summary>
        /// Gets or sets the value of the scene manager
        /// </summary>
        public  SceneManager SceneManager => Get<SceneManager>();
        
        /// <summary>
        /// Gets or sets the value of the script manager
        /// </summary>
        public  ScriptManager ScriptManager => Get<ScriptManager>();
        
        /// <summary>
        /// Gets or sets the value of the store manager
        /// </summary>
        public StoreManager StoreManager => Get<StoreManager>();

        /// <summary>
        /// Gets or sets the value of the setting
        /// </summary>
        public Settings Settings { get; set; } = new Settings();
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The video game builder</returns>
        public static VideoGameBuilder Builder() => new VideoGameBuilder();
    }
}