// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Scene.cs
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
using Alis.Core.Exceptions;

namespace Alis.Core.Entities
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        public Scene()
        {
            Name = "Default";
            GameObjects = new List<GameObject>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="gameobjects">The gameobjects</param>
        /// <exception cref="IndexOutOfBounds"></exception>
        [JsonConstructor]
        public Scene(string name, List<GameObject> gameobjects)
        {
            Name = name;
            GameObjects = gameobjects;
            if (gameobjects.Count > Game.Setting.Scene.MaxGameObjectByScene)
            {
                throw new IndexOutOfBounds();
            }
        }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the game objects
        /// </summary>
        [JsonPropertyName("_GameObjects")]
        public List<GameObject> GameObjects { get; set; }

        /// <summary>
        ///     Adds the game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void Add(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public void Awake()
        {
            GameObjects.ForEach(gameObject => gameObject.Awake());
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
            GameObjects.ForEach(gameObject => gameObject.Start());
        }

        /// <summary>
        ///     Before run the update
        /// </summary>
        public void BeforeUpdate()
        {
            GameObjects.ForEach(gameObject => gameObject.BeforeUpdate());
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            GameObjects.ForEach(gameObject => gameObject.Update());
        }

        /// <summary>
        ///     Afters the update
        /// </summary>
        public void AfterUpdate()
        {
            GameObjects.ForEach(gameObject => gameObject.AfterUpdate());
        }

        /// <summary>
        ///     Update every frame.
        /// </summary>
        public void FixedUpdate()
        {
            GameObjects.ForEach(gameObject => gameObject.FixedUpdate());
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public void DispatchEvents()
        {
            GameObjects.ForEach(gameObject => gameObject.DispatchEvents());
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            GameObjects.ForEach(gameObject => gameObject.Reset());
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop()
        {
            GameObjects.ForEach(gameObject => gameObject.Stop());
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit()
        {
            GameObjects.ForEach(gameObject => gameObject.Exit());
        }

        /// <summary>
        ///     Define the destructor.
        /// </summary>
        ~Scene() => Console.WriteLine(@"destroy");
    }
}