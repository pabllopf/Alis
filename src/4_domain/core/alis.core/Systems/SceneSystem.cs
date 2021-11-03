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

#region

using System;
using System.Text.Json.Serialization;
using Alis.Core.Entities;
using Alis.Core.Exceptions;
using Alis.FluentApi.Validations;

#endregion

namespace Alis.Core.Systems
{
    /// <summary>
    ///     The scene system class
    /// </summary>
    /// <seealso cref="System" />
    public class SceneSystem : System
    {
        #region ChangeScene()

        /// <summary>
        ///     Changes the scene using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <exception cref="IndexOutOfBounds"></exception>
        public void ChangeScene(NotNull<int> index)
        {
            if (index.Value > Game.Setting.Scene.MaxScenesOfGame || index.Value < 0) throw new IndexOutOfBounds();

            if (Scenes[index.Value] is not null) ActiveScene = Scenes[index.Value];
        }

        #endregion

        #region AddScene()

        /// <summary>
        ///     Adds the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void Add(Scene scene)
        {
            var temp = Scenes.AsSpan();
            for (var i = 0; i < temp.Length; i++)
                if (temp[i] is null)
                {
                    temp[i] = scene;
                    return;
                }
        }

        #endregion

        #region Awake()

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            ActiveScene.Awake();
        }

        #endregion

        #region Start()

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            ActiveScene.Start();
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
            ActiveScene.BeforeUpdate();
        }

        #endregion

        #region Update()

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            ActiveScene.Update();
        }

        #endregion

        #region AfterUpdate()

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
            ActiveScene.AfterUpdate();
        }

        #endregion

        #region FixedUpdate()

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
            ActiveScene.FixedUpdate();
        }

        #endregion

        #region DispatchEvents()

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            ActiveScene.DispatchEvents();
        }

        #endregion

        #region Reset()

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset()
        {
            ActiveScene.Reset();
        }

        #endregion

        #region Stop()

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop()
        {
            ActiveScene.Stop();
        }

        #endregion

        #region Exit()

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
            ActiveScene.Exit();
        }

        #endregion

        #region Destructor()

        ~SceneSystem()
        {
            Console.WriteLine(@"Destroy");
        }

        #endregion

        #region Constructor()

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneSystem" /> class
        /// </summary>
        public SceneSystem()
        {
            Scenes = new Scene[Game.Setting.Scene.MaxScenesOfGame];
            ActiveScene = new Scene();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneSystem" /> class
        /// </summary>
        /// <param name="scenes">The scenes</param>
        /// <exception cref="MaxSceneGame"></exception>
        public SceneSystem(NotNull<Scene[]> scenes)
        {
            if (scenes.Value.Length > Game.Setting.Scene.MaxScenesOfGame) throw new MaxSceneGame();

            Scenes = new Scene[Game.Setting.Scene.MaxScenesOfGame];
            for (var i = 0; i < scenes.Value.Length; i++) Scenes[i] = scenes.Value[i];

            ActiveScene = Scenes[0];
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneSystem" /> class
        /// </summary>
        /// <param name="activeScene">The active scene</param>
        /// <param name="scenes">The scenes</param>
        /// <exception cref="MaxSceneGame"></exception>
        [JsonConstructor]
        public SceneSystem(NotNull<Scene> activeScene, NotNull<Scene[]> scenes)
        {
            ActiveScene = activeScene.Value;
            if (scenes.Value.Length > Game.Setting.Scene.MaxScenesOfGame) throw new MaxSceneGame();

            Scenes = new Scene[Game.Setting.Scene.MaxScenesOfGame];
            for (var i = 0; i < scenes.Value.Length; i++) Scenes[i] = scenes.Value[i];
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>
        [JsonPropertyName("_Scenes")]
        public Scene[] Scenes { get; set; }

        /// <summary>
        ///     Gets or sets the value of the active scene
        /// </summary>
        [JsonPropertyName("_ActiveScene")]
        public Scene ActiveScene { get; set; } = new();

        #endregion
    }
}