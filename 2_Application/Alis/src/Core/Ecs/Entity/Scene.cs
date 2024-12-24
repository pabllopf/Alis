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
using Alis.Builder.Core.Ecs.Entity.Scene;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Core.Ecs.Entity
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene : IScene<GameObject>, IHasBuilder<SceneBuilder>
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
            PendingGameObjectsToAdd = new List<GameObject>();
            PendingGameObjectsToRemove = new List<GameObject>();
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
            PendingGameObjectsToAdd = new List<GameObject>();
            PendingGameObjectsToRemove = new List<GameObject>();
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
            GameObjects.ForEach(i => i.SetContext(Context));
            PendingGameObjectsToAdd = new List<GameObject>();
            PendingGameObjectsToRemove = new List<GameObject>();
        }
        
        /// <summary>
        ///     The context
        /// </summary>
        [JsonIgnore]
        public Context Context { get; private set; }

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
        /// Gets the value of the pending game objects to add
        /// </summary>
        [JsonPropertyName("_PendingGameObjectsToAdd_")]
        public List<GameObject> PendingGameObjectsToAdd { get; }

        /// <summary>
        /// Gets the value of the pending game objects to remove
        /// </summary>
        [JsonPropertyName("_PendingGameObjectsToRemove_")]
        public List<GameObject> PendingGameObjectsToRemove  { get; }
        
        /// <summary>
        ///     Ons the enable
        /// </summary>
        public void OnEnable()
        {
            IsEnable = true;
            GameObjects.ForEach(i => i.OnEnable());
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit()
        {
            GameObjects.ForEach(i => i.OnInit());
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake()
        {
            GameObjects.ForEach(i => i.OnAwake());
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart()
        {
            GameObjects.ForEach(i => i.OnStart());
        }

        /// <summary>
        ///     Ons the physic update
        /// </summary>
        public void OnPhysicUpdate()
        {
            GameObjects.ForEach(i => i.OnPhysicUpdate());
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate()
        {
            GameObjects.ForEach(i => i.OnBeforeUpdate());
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate()
        {
            GameObjects.ForEach(i => i.OnUpdate());
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate()
        {
            GameObjects.ForEach(i => i.OnAfterUpdate());
        }

        /// <summary>
        /// Ons the process pending changes
        /// </summary>
        public void OnProcessPendingChanges()
        {
            GameObjects.ForEach(i => i.OnProcessPendingChanges());
            AddPendingGameObjects();
            RemovePendingGameObjects();
        }

        /// <summary>
        /// Adds the pending game objects
        /// </summary>
        private void AddPendingGameObjects()
        {
            if (PendingGameObjectsToAdd.Count == 0) return;

            foreach (GameObject gameObject in PendingGameObjectsToAdd)
            {
                gameObject.SetContext(Context);
            }
            
            foreach (GameObject gameObject in PendingGameObjectsToAdd)
            {
                gameObject.OnInit();
            }
            
            foreach (GameObject gameObject in PendingGameObjectsToAdd)
            {
                gameObject.OnAwake();
            }
            
            foreach (GameObject gameObject in PendingGameObjectsToAdd)
            {
                gameObject.OnStart();
            }
            
            foreach (GameObject gameObject in PendingGameObjectsToAdd)
            {
                GameObjects.Add(gameObject);
            }
            
            PendingGameObjectsToAdd.Clear();
        }

        /// <summary>
        /// Removes the pending game objects
        /// </summary>
        private void RemovePendingGameObjects()
        {
            if (PendingGameObjectsToRemove.Count == 0) return;
            
            foreach (GameObject gameObject in PendingGameObjectsToRemove)
            {
                gameObject.OnStop();
            }
            foreach (GameObject gameObject in PendingGameObjectsToRemove)
            {
                gameObject.OnExit();
            }
            foreach (GameObject gameObject in PendingGameObjectsToRemove)
            {
                GameObjects.Remove(gameObject);
            }

            PendingGameObjectsToRemove.Clear();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate()
        {
            GameObjects.ForEach(i => i.OnBeforeFixedUpdate());
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate()
        {
            GameObjects.ForEach(i => i.OnFixedUpdate());
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate()
        {
            GameObjects.ForEach(i => i.OnAfterFixedUpdate());
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents()
        {
            GameObjects.ForEach(i => i.OnDispatchEvents());
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate()
        {
            GameObjects.ForEach(i => i.OnCalculate());
        }

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public void OnBeforeDraw()
        {
            GameObjects.ForEach(i => i.OnBeforeDraw());
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw()
        {
            GameObjects.ForEach(i => i.OnDraw());
        }

        /// <summary>
        ///     Ons the after draw
        /// </summary>
        public void OnAfterDraw()
        {
            GameObjects.ForEach(i => i.OnAfterDraw());
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui()
        {
            GameObjects.ForEach(i => i.OnGui());
        }

        /// <summary>
        ///     Ons the render present
        /// </summary>
        public void OnRenderPresent()
        {
            GameObjects.ForEach(i => i.OnRenderPresent());
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable()
        {
            IsEnable = false;
            GameObjects.ForEach(i => i.OnDisable());
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public void OnReset()
        {
            GameObjects.ForEach(i => i.OnReset());
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop()
        {
            GameObjects.ForEach(i => i.OnStop());
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit()
        {
            GameObjects.ForEach(i => i.OnExit());
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy()
        {
            GameObjects.ForEach(i => i.OnDestroy());
        }

        /// <summary>
        /// Ons the save
        /// </summary>
        public void OnSave() => GameObjects.ForEach(i => i.OnSave());

        /// <summary>
        /// Ons the load
        /// </summary>
        public void OnLoad() => GameObjects.ForEach(i => i.OnLoad());

        /// <summary>
        /// Ons the save using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public void OnSave(string path) => GameObjects.ForEach(i => i.OnSave(path));

        /// <summary>
        /// Ons the load using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public void OnLoad(string path) => GameObjects.ForEach(i => i.OnLoad(path));

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The component</param>
        public virtual void Add<T>(T value) where T : GameObject
        {
            if (!PendingGameObjectsToAdd.Contains(value) && !GameObjects.Contains(value))
            {
                value.SetContext(Context);
                PendingGameObjectsToAdd.Add(value);
            }
        }

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The component</param>
        public virtual void Remove<T>(T value) where T : GameObject
        {
            if (GameObjects.Contains(value) && !PendingGameObjectsToRemove.Contains(value))
            {
                PendingGameObjectsToRemove.Add(value);
            }
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
        /// Gets the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The game object</returns>
        public GameObject Get(string name)
        {
            return GameObjects.Find(i => i.Name == name);
        }
        
        /// <summary>
        /// Gets the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The game object</returns>
        public GameObject Get(Guid id)
        {
            return GameObjects.Find(i => i.Id == id.ToString());
        }
        
        /// <summary>
        /// Gets the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The game object</returns>
        public GameObject Get(int index)
        {
            return GameObjects[index];
        }
        
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>The game objects</returns>
        public List<GameObject> GetAll()
        {
            return GameObjects;
        }
        
        /// <summary>
        /// Gets the by tag using the specified tag
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The game object</returns>
        public GameObject GetByTag(string tag)
        {
            return GameObjects.Find(i => i.Tag == tag);
        }

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public virtual bool Contains<T>() where T : GameObject => GameObjects.Contains(Get<T>());

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public virtual void Clear()
        {
            GameObjects.Clear();
        }

        /// <summary>
        ///     Sets the context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public void SetContext(Context context)
        {
            Context = context;
            GameObjects.ForEach(i => i.SetContext(context));
        }

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The scene builder</returns>
        public SceneBuilder Builder() => new SceneBuilder(this.Context);
    }
}