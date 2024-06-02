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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Data.Json;
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
        /// Initializes a new instance of the <see cref="Context"/> class
        /// </summary>
        public Context()
        {
            Settings = new Settings();
            TimeManager = new TimeManager();
            AudioManager = new AudioManager();
            GraphicManager = new GraphicManager();
            InputManager = new InputManager();
            NetworkManager = new NetworkManager();
            PhysicManager = new PhysicManager();
            SceneManager = new SceneManager();
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="settings">The settings</param>
        public Context(Settings settings)
        {
            Settings = settings;
            TimeManager = new TimeManager();
            AudioManager = new AudioManager();
            GraphicManager = new GraphicManager();
            InputManager = new InputManager();
            NetworkManager = new NetworkManager();
            PhysicManager = new PhysicManager();
            SceneManager = new SceneManager();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <param name="sceneManager">The scene manager</param>
        [JsonConstructor]
        [ExcludeFromCodeCoverage]
        public Context(Settings settings, SceneManager sceneManager)
        {
            Settings = settings;
            TimeManager = new TimeManager();
            AudioManager = new AudioManager();
            GraphicManager = new GraphicManager();
            InputManager = new InputManager();
            NetworkManager = new NetworkManager();
            PhysicManager = new PhysicManager();
            SceneManager = sceneManager;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <param name="audioManager">The audio manager</param>
        /// <param name="graphicManager">The graphic manager</param>
        /// <param name="inputManager">The input manager</param>
        /// <param name="networkManager">The network manager</param>
        /// <param name="physicManager">The physic manager</param>
        /// <param name="sceneManager">The scene manager</param>
        [ExcludeFromCodeCoverage]
        public Context(Settings settings, AudioManager audioManager, GraphicManager graphicManager, InputManager inputManager, NetworkManager networkManager, PhysicManager physicManager, SceneManager sceneManager)
        {
           Settings = settings;
           AudioManager = audioManager;
           GraphicManager = graphicManager;
           InputManager = inputManager;
           NetworkManager = networkManager;
           PhysicManager = physicManager;
           SceneManager = sceneManager;
        }
        
        /// <summary>
        ///     Gets the value of the audio manager
        /// </summary>
        [JsonPropertyName("_AudioManager_", true, true)]
        public AudioManager AudioManager { get; set; }
        
        /// <summary>
        ///     Gets the value of the graphic manager
        /// </summary>
        [JsonPropertyName("_GraphicManager_", true, true)]
        public GraphicManager GraphicManager { get; set; }
        
        /// <summary>
        ///     Gets the value of the input manager
        /// </summary>
        [JsonPropertyName("_InputManager_", true, true)]
        public InputManager InputManager { get; set; }
        
        /// <summary>
        ///     Gets the value of the network manager
        /// </summary>
        [JsonPropertyName("_NetworkManager_", true, true)]
        public NetworkManager NetworkManager { get; set; }
        
        /// <summary>
        ///     Gets the value of the physic manager
        /// </summary>
        [JsonPropertyName("_PhysicManager_", true, true)]
        public PhysicManager PhysicManager { get; set; }
        
        /// <summary>
        ///     Gets the value of the time manager
        /// </summary>
        [JsonPropertyName("_TimeManager_", true, true)]
        public TimeManager TimeManager { get; set; }
        
        /// <summary>
        ///     The settings
        /// </summary>
        [JsonPropertyName("_Settings_")]
        public Settings Settings { get; set; }
        
        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        [JsonPropertyName("_SceneManager_")]
        public SceneManager SceneManager { get; set; }
        
        /// <summary>
        /// Ons the exit
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnExit()
        {
            AudioManager.OnExit();
            GraphicManager.OnExit();
            InputManager.OnExit();
            NetworkManager.OnExit();
            PhysicManager.OnExit();
            SceneManager.OnExit();
        }
        
        /// <summary>
        /// Ons the stop
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnStop()
        {
            AudioManager.OnStop();
            GraphicManager.OnStop();
            InputManager.OnStop();
            NetworkManager.OnStop();
            PhysicManager.OnStop();
            SceneManager.OnStop();
        }
        
        /// <summary>
        /// Ons the init
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnInit()
        {
            AudioManager.OnInit();
            GraphicManager.OnInit();
            InputManager.OnInit();
            NetworkManager.OnInit();
            PhysicManager.OnInit();
            SceneManager.OnInit();
        }
        
        /// <summary>
        /// Ons the awake
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnAwake()
        {
            AudioManager.OnAwake();
            GraphicManager.OnAwake();
            InputManager.OnAwake();
            NetworkManager.OnAwake();
            PhysicManager.OnAwake();
            SceneManager.OnAwake();
        }
        
        /// <summary>
        /// Ons the start
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnStart()
        {
            AudioManager.OnStart();
            GraphicManager.OnStart();
            InputManager.OnStart();
            NetworkManager.OnStart();
            PhysicManager.OnStart();
            SceneManager.OnStart();
        }
        
        /// <summary>
        /// Ons the dispatch events
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnDispatchEvents()
        {
            AudioManager.OnDispatchEvents();
            GraphicManager.OnDispatchEvents();
            InputManager.OnDispatchEvents();
            NetworkManager.OnDispatchEvents();
            PhysicManager.OnDispatchEvents();
            SceneManager.OnDispatchEvents();
        }
        
        /// <summary>
        /// Ons the before update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnBeforeUpdate()
        {
            AudioManager.OnBeforeUpdate();
            GraphicManager.OnBeforeUpdate();
            InputManager.OnBeforeUpdate();
            NetworkManager.OnBeforeUpdate();
            PhysicManager.OnBeforeUpdate();
            SceneManager.OnBeforeUpdate();
        }
        
        /// <summary>
        /// Ons the update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnUpdate()
        {
            AudioManager.OnUpdate();
            GraphicManager.OnUpdate();
            InputManager.OnUpdate();
            NetworkManager.OnUpdate();
            PhysicManager.OnUpdate();
            SceneManager.OnUpdate();
        }
        
        /// <summary>
        /// Ons the after update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnAfterUpdate()
        {
            AudioManager.OnAfterUpdate();
            GraphicManager.OnAfterUpdate();
            InputManager.OnAfterUpdate();
            NetworkManager.OnAfterUpdate();
            PhysicManager.OnAfterUpdate();
            SceneManager.OnAfterUpdate();
        }
        
        /// <summary>
        /// Ons the before fixed update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnBeforeFixedUpdate()
        {
            AudioManager.OnBeforeFixedUpdate();
            GraphicManager.OnBeforeFixedUpdate();
            InputManager.OnBeforeFixedUpdate();
            NetworkManager.OnBeforeFixedUpdate();
            PhysicManager.OnBeforeFixedUpdate();
            SceneManager.OnBeforeFixedUpdate();
        }
        
        /// <summary>
        /// Ons the fixed update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnFixedUpdate()
        {
            AudioManager.OnFixedUpdate();
            GraphicManager.OnFixedUpdate();
            InputManager.OnFixedUpdate();
            NetworkManager.OnFixedUpdate();
            PhysicManager.OnFixedUpdate();
            SceneManager.OnFixedUpdate();
        }
        
        /// <summary>
        /// Ons the after fixed update
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnAfterFixedUpdate()
        {
            AudioManager.OnAfterFixedUpdate();
            GraphicManager.OnAfterFixedUpdate();
            InputManager.OnAfterFixedUpdate();
            NetworkManager.OnAfterFixedUpdate();
            PhysicManager.OnAfterFixedUpdate();
            SceneManager.OnAfterFixedUpdate();
        }
        
        /// <summary>
        /// Ons the draw
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnDraw()
        {
            AudioManager.OnDraw();
            GraphicManager.OnDraw();
            InputManager.OnDraw();
            NetworkManager.OnDraw();
            PhysicManager.OnDraw();
            SceneManager.OnDraw();
        }
        
        /// <summary>
        /// Ons the gui
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnGui()
        {
            AudioManager.OnGui();
            GraphicManager.OnGui();
            InputManager.OnGui();
            NetworkManager.OnGui();
            PhysicManager.OnGui();
            SceneManager.OnGui();
        }
        
        /// <summary>
        /// Ons the calculate
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void OnCalculate()
        {
            AudioManager.OnCalculate();
            GraphicManager.OnCalculate();
            InputManager.OnCalculate();
            NetworkManager.OnCalculate();
            PhysicManager.OnCalculate();
            SceneManager.OnCalculate();
        }
        
        /// <summary>
        ///     Exits this instance
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void Exit() => TimeManager.IsRunning = false;
        
        /// <summary>
        /// Sets the scene manager using the specified scene manager
        /// </summary>
        /// <param name="sceneManager">The scene manager</param>
        [ExcludeFromCodeCoverage]
        public void SetSceneManager(SceneManager sceneManager) => SceneManager = sceneManager;
    }
}