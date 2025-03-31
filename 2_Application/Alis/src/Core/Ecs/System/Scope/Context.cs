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

using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.System.Configuration;
using Alis.Core.Ecs.System.Execution;
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Manager.Time;

namespace Alis.Core.Ecs.System.Scope
{
    /// <summary>
    ///     The context class
    /// </summary>
    /// <seealso />
    public class Context : IContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        public Context()
        {
            IsRunning = true;
            Setting = new Setting();
            Runtime = new Runtime<AManager>(
                new AudioManager(this),
                new GraphicManager(this),
                new InputManager(this),
                new NetworkManager(this),
                new PhysicManager(this),
                new SceneManager(this),
                new TimeManager(this)
            );
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="setting">The settings</param>
        public Context(Setting setting)
        {
            IsRunning = true;
            Setting = setting;
            Runtime = new Runtime<AManager>(
                new AudioManager(this),
                new GraphicManager(this),
                new InputManager(this),
                new NetworkManager(this),
                new PhysicManager(this),
                new SceneManager(this),
                new TimeManager(this)
            );
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="setting">The settings</param>
        /// <param name="sceneManager">The scene manager</param>
        [JsonConstructor]
        public Context(Setting setting, SceneManager sceneManager)
        {
            IsRunning = true;
            Setting = setting;
            Runtime = new Runtime<AManager>(
                new AudioManager(this),
                new GraphicManager(this),
                new InputManager(this),
                new NetworkManager(this),
                new PhysicManager(this),
                sceneManager,
                new TimeManager(this)
            );
        }

        /// <summary>
        ///     The runtime
        /// </summary>
        [JsonIgnore]
        public Runtime<AManager> Runtime { get; }

        /// <summary>
        ///     Gets or sets the value of the is running
        /// </summary>
        public bool IsRunning { get; internal set; }

        /// <summary>
        ///     Gets the value of the audio manager
        /// </summary>
        [JsonIgnore]
        public AudioManager AudioManager => Runtime.Get<AudioManager>();

        /// <summary>
        ///     Gets the value of the graphic manager
        /// </summary>
        [JsonIgnore]
        public GraphicManager GraphicManager => Runtime.Get<GraphicManager>();

        /// <summary>
        ///     Gets the value of the input manager
        /// </summary>
        [JsonIgnore]
        public InputManager InputManager => Runtime.Get<InputManager>();

        /// <summary>
        ///     Gets the value of the network manager
        /// </summary>
        [JsonIgnore]
        public NetworkManager NetworkManager => Runtime.Get<NetworkManager>();

        /// <summary>
        ///     Gets the value of the physic manager
        /// </summary>
        [JsonIgnore]
        public PhysicManager PhysicManager => Runtime.Get<PhysicManager>();

        /// <summary>
        ///     Gets the value of the time manager
        /// </summary>
        [JsonIgnore]
        public TimeManager TimeManager => Runtime.Get<TimeManager>();

        /// <summary>
        ///     The settings
        /// </summary>
        [JsonPropertyName("_Settings_")]
        public Setting Setting { get; set; }

        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        [JsonPropertyName("_SceneManager_")]
        public SceneManager SceneManager => Runtime.Get<SceneManager>();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => IsRunning = false;
    }
}