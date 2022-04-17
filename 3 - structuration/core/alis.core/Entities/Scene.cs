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

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Alis.Tools;

namespace Alis.Core.Entities
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene
    {
        /// <summary>
        ///     The game objects
        /// </summary>
        private List<GameObject> gameObjects;

        /// <summary>
        ///     The name
        /// </summary>
        private string name;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="gameObjects">The game objects</param>
        [JsonConstructor]
        public Scene(string name, List<GameObject> gameObjects)
        {
            this.name = name;
            this.gameObjects = gameObjects;
            Logger.Trace();
        }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name")]
        public string Name
        {
            get
            {
                Logger.Trace($"name: {name}");
                return name;
            }
            set
            {
                Logger.Trace($"Scene.Name from '{name}' to '{value}'");
                name = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the game objects
        /// </summary>
        [JsonPropertyName("_GameObjects")]
        public List<GameObject> GameObjects
        {
            get
            {
                Logger.Trace($"Scene.GameObjects '{gameObjects}'");
                return gameObjects;
            }
            set
            {
                Logger.Trace($"Scene.GameObjects from '{gameObjects}' to '{value}'");
                gameObjects = value;
            }
        }

        /// <summary>
        ///     Adds the game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void Add(GameObject gameObject) => GameObjects.Add(gameObject);

        /// <summary>
        /// Inits this instance
        /// </summary>
        protected internal void Init() => GameObjects.ForEach(gameObject => gameObject.Init());

        /// <summary>
        /// Befores the awake
        /// </summary>
        protected internal void BeforeAwake() => GameObjects.ForEach(gameObject => gameObject.BeforeAwake());

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public void Awake() => GameObjects.ForEach(gameObject => gameObject.Awake());

        /// <summary>
        /// Afters the awake
        /// </summary>
        protected internal void AfterAwake() => GameObjects.ForEach(gameObject => gameObject.AfterAwake());

        /// <summary>
        /// Befores the start
        /// </summary>
        protected internal void BeforeStart() => GameObjects.ForEach(gameObject => gameObject.BeforeStart());

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start() => GameObjects.ForEach(gameObject => gameObject.Start());

        /// <summary>
        /// Afters the start
        /// </summary>
        protected internal void AfterStart() => GameObjects.ForEach(gameObject => gameObject.AfterStart());

        /// <summary>
        ///     Before run the update
        /// </summary>
        protected internal void BeforeUpdate() => GameObjects.ForEach(gameObject => gameObject.BeforeUpdate());

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update() => GameObjects.ForEach(gameObject => gameObject.Update());

        /// <summary>
        ///     Afters the update
        /// </summary>
        protected internal void AfterUpdate() => GameObjects.ForEach(gameObject => gameObject.AfterUpdate());

        /// <summary>
        ///     Update every frame.
        /// </summary>
        public void FixedUpdate() => GameObjects.ForEach(gameObject => gameObject.FixedUpdate());

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public void DispatchEvents() => GameObjects.ForEach(gameObject => gameObject.DispatchEvents());

        /// <summary>
        /// Draws this instance
        /// </summary>
        protected internal void Draw() => GameObjects.ForEach(gameObject => gameObject.Draw());

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset() => GameObjects.ForEach(gameObject => gameObject.Reset());

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop() => GameObjects.ForEach(gameObject => gameObject.Stop());

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => GameObjects.ForEach(gameObject => gameObject.Exit());

        /// <summary>
        ///     Define the destructor.
        /// </summary>
        ~Scene() => Logger.Trace();
    }
}