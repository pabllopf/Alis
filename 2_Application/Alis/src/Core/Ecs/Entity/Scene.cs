// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Scene.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.System;

namespace Alis.Core.Ecs.Entity
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene : IScene<GameObject>
    {
       

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        public Scene()
        {
            IsEnable = true;
            Name = GetType().Name;
            Id = Guid.NewGuid().ToString();
            Tag = GetType().Name;
            GameObjects = new List<GameObject>();
            _gameObjectsToAdd = new List<GameObject>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        /// <param name="isEnable">The is enable</param>
        /// <param name="name">The name</param>
        /// <param name="id">The id</param>
        /// <param name="tag">The tag</param>
        [JsonConstructor]
        public Scene(bool isEnable, string name, string id, string tag)
        {
            IsEnable = isEnable;
            Name = name;
            Id = id;
            Tag = tag;
            GameObjects = new List<GameObject>();
            _gameObjectsToAdd = new List<GameObject>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        /// <param name="isEnable">The is enable</param>
        /// <param name="name">The name</param>
        /// <param name="id">The id</param>
        /// <param name="tag">The tag</param>
        /// <param name="gameObjects">The game objects</param>
        public Scene(bool isEnable, string name, string id, string tag, List<GameObject> gameObjects) : this()
        {
            IsEnable = isEnable;
            Name = name;
            Id = id;
            Tag = tag;
            GameObjects = gameObjects;
            _gameObjectsToAdd = new List<GameObject>();
        }

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        [JsonPropertyName("_Context_", true, true)]
        protected internal Context Context => VideoGame.GetContext();

        /// <summary>
        ///     Gets or sets the value of the is enable
        /// </summary>
        [JsonPropertyName("_IsEnable_")]
        public bool IsEnable { get; set; }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name_")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        [JsonPropertyName("_Id_")]
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        [JsonPropertyName("_Tag_")]
        public string Tag { get; set; }

        /// <summary>
        ///     Gets or sets the value of the game objects
        /// </summary>

        [JsonPropertyName("_GameObjects_")]
        public List<GameObject> GameObjects { get; set; }
        
        /// <summary>
        /// The game objects to add
        /// </summary>
        [JsonPropertyName("GameObjectsToAdd", true, true)]
        private List<GameObject> _gameObjectsToAdd;

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public void OnEnable()
        {
            IsEnable = true;
            GameObjects.ForEach(i => i.OnEnable());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            GameObjects.ForEach(i => i.OnInit());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake()
        {
            GameObjects.ForEach(i => i.OnAwake());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
            GameObjects.ForEach(i => i.OnStart());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate()
        {
            GameObjects.ForEach(i => i.OnBeforeUpdate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            GameObjects.ForEach(i => i.OnUpdate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate()
        {
            GameObjects.ForEach(i => i.OnAfterUpdate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate()
        {
            GameObjects.ForEach(i => i.OnBeforeFixedUpdate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate()
        {
            GameObjects.ForEach(i => i.OnFixedUpdate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate()
        {
            GameObjects.ForEach(i => i.OnAfterFixedUpdate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents()
        {
            GameObjects.ForEach(i => i.OnDispatchEvents());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate()
        {
            GameObjects.ForEach(i => i.OnCalculate());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw()
        {
            GameObjects.ForEach(i => i.OnDraw());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui()
        {
            GameObjects.ForEach(i => i.OnGui());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable()
        {
            IsEnable = false;
            GameObjects.ForEach(i => i.OnDisable());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public void OnReset()
        {
            GameObjects.ForEach(i => i.OnReset());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop()
        {
            GameObjects.ForEach(i => i.OnStop());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit()
        {
            GameObjects.ForEach(i => i.OnExit());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy()
        {
            GameObjects.ForEach(i => i.OnDestroy());
            AddPendingGameObjects();
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public virtual void Add<T>(T component) where T : GameObject
        {
            _gameObjectsToAdd.Add(component);
            component.OnInit();
            component.OnAwake();
            component.OnStart();
        }

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public virtual void Remove<T>(T component) where T : GameObject
        {
            GameObjects.Remove(component);
        }

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public virtual T Get<T>() where T : GameObject
        {
            return GameObjects.Find(i => i is T) as T;
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public virtual bool Contains<T>() where T : GameObject
        {
            return GameObjects.Contains(Get<T>());
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public virtual void Clear()
        {
            GameObjects.Clear();
        }
        
        /// <summary>
        /// Adds the pending game objects
        /// </summary>
        private void AddPendingGameObjects()
        {
            if (_gameObjectsToAdd.Count > 0)
            {
                GameObjects.AddRange(_gameObjectsToAdd);
                _gameObjectsToAdd.Clear();
            }
        }
    }
}