// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SceneManager.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Entity.Scene;

namespace Alis.Core.Ecs.System.Manager.Scene
{
    /// <summary>
    ///     The scene manager base class
    /// </summary>
    /// <seealso cref="Manager" />
    public class SceneManager : Manager, ISceneManager
    {
        /// <summary>
        ///     Gets or sets the value of the current scene
        /// </summary>
        public IScene CurrentScene { get; set; } = new Entity.Scene.Scene();

        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>
        public List<IScene> Scenes { get; set; } = new List<IScene>();

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public override void OnEnable()
        {
            CurrentScene.OnEnable();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            CurrentScene.OnInit();
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            CurrentScene.OnAwake();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            CurrentScene.OnStart();
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            CurrentScene.OnBeforeUpdate();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            CurrentScene.OnUpdate();
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            CurrentScene.OnAfterUpdate();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public override void OnBeforeFixedUpdate()
        {
            CurrentScene.OnBeforeFixedUpdate();
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public override void OnFixedUpdate()
        {
            CurrentScene.OnFixedUpdate();
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public override void OnAfterFixedUpdate()
        {
            CurrentScene.OnAfterFixedUpdate();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            CurrentScene.OnDispatchEvents();
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public override void OnCalculate()
        {
            CurrentScene.OnCalculate();
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            CurrentScene.OnDraw();
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            CurrentScene.OnGui();
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public override void OnDisable()
        {
            CurrentScene.OnDisable();
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public override void OnReset()
        {
            CurrentScene.OnReset();
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public override void OnStop()
        {
            CurrentScene.OnStop();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            CurrentScene.OnExit();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            CurrentScene.OnDestroy();
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Add<T>(T component) where T : IScene
        {
            Scenes ??= new List<IScene>();
            Scenes.Add(component);
        }

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : IScene
        {
            Scenes.Remove(component);
        }

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : IScene => (T) Scenes.Find(i => i.GetType() == typeof(T));

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : IScene => Get<T>() != null;

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : IScene
        {
            Scenes.Clear();
        }

        /// <summary>
        ///     Loads the scene using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void LoadScene(IScene scene)
        {
            CurrentScene = scene;
        }

        /// <summary>
        ///     Reloads the scene using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void ReloadScene(IScene scene)
        {
            CurrentScene = scene;
        }

        /// <summary>
        ///     Loads the scene using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        public void LoadScene(string name)
        {
            CurrentScene.OnStop();
            CurrentScene.OnExit();
            Console.WriteLine($"ID={CurrentScene.GetHashCode()}");
            CurrentScene = Scenes.Find(i => i.Name == name);
            Console.WriteLine($"ID={CurrentScene.GetHashCode()}");
            CurrentScene.OnInit();
            CurrentScene.OnAwake();
            CurrentScene.OnStart();
        }


        /// <summary>
        ///     Loads the scene using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void LoadScene(int index)
        {
            CurrentScene.OnStop();
            CurrentScene.OnExit();
            CurrentScene = Scenes[index];
            CurrentScene.OnInit();
            CurrentScene.OnAwake();
            CurrentScene.OnStart();
        }
    }
}