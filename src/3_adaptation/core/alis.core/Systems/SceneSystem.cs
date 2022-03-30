// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SceneSystem.cs
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
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Alis.Core.Entities;
using Alis.Core.Exceptions;
using Alis.Tools;

namespace Alis.Core.Systems
{
    /// <summary>
    ///     The scene system class
    /// </summary>
    /// <seealso cref="System" />
    public class SceneSystem : System
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneSystem" /> class
        /// </summary>
        /// <param name="scenes">The scenes</param>
        /// <exception cref="MaxSceneGame"></exception>
        public SceneSystem(List<Scene> scenes)
        {
            Scenes = scenes;
            ActiveScene = scenes[0];
            _current = this;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneSystem" /> class
        /// </summary>
        /// <param name="activeScene">The active scene</param>
        /// <param name="scenes">The scenes</param>
        /// <exception cref="MaxSceneGame"></exception>
        [JsonConstructor]
        public SceneSystem(Scene activeScene, List<Scene> scenes)
        {
            ActiveScene = activeScene;
            Scenes = scenes;
            _current = this;
        }

        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>
        [JsonPropertyName("_Scenes")]
        public List<Scene> Scenes { get; set; }

        /// <summary>
        ///     Gets or sets the value of the active scene
        /// </summary>
        [JsonPropertyName("_ActiveScene")]
        private Scene ActiveScene { get; set; }

        /// <summary>
        ///     The current
        /// </summary>
        private static SceneSystem _current = null!;

        /// <summary>
        ///     Changes the scene using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public static void LoadScene(int index)
        {
            _current.ActiveScene.Stop();
            _current.ActiveScene.Exit();
            _current.ActiveScene = _current.Scenes[index];
            _current.ActiveScene.Awake();
            _current.ActiveScene.Start();
            Logger.Info($"Scene changed to {_current.ActiveScene.Name}");
        }

        /// <summary>
        ///     Adds the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void Add(Scene scene)
        {
            Scenes.Add(scene);
            ActiveScene = scene;
        }

        /// <summary>
        /// Inits this instance
        /// </summary>
        public override void Init() => ActiveScene.Init();
        
        /// <summary>
        /// Before the awake
        /// </summary>
        public override void BeforeAwake() => ActiveScene.BeforeAwake();

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake() => ActiveScene.Awake();

        /// <summary>
        /// Afters the awake
        /// </summary>
        public override void AfterAwake() => ActiveScene.AfterAwake();

        /// <summary>
        /// Before the start
        /// </summary>
        public override void BeforeStart()=> ActiveScene.BeforeStart();

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start() => ActiveScene.Start();

        /// <summary>
        /// Afters the start
        /// </summary>
        public override void AfterStart()=> ActiveScene.AfterStart();

        /// <summary>
        ///     Before the update
        /// </summary>
        public override void BeforeUpdate() => ActiveScene.BeforeUpdate();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update() => ActiveScene.Update();

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate() => ActiveScene.AfterUpdate();

        /// <summary>
        ///     Fixed the update
        /// </summary>
        public override void FixedUpdate() => ActiveScene.FixedUpdate();

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents() => ActiveScene.DispatchEvents();

        /// <summary>
        /// Draws this instance
        /// </summary>
        public override void Draw()=> ActiveScene.Draw();

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset() => ActiveScene.Reset();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop() => ActiveScene.Stop();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit() => ActiveScene.Exit();

        /// <summary>
        ///     Simple destructor
        /// </summary>
        ~SceneSystem() => Console.WriteLine(@$"Destroy SceneSystem {GetHashCode().ToString()}");
    }
}