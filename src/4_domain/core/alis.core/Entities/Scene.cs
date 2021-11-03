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
using System.Text.Json.Serialization;
using Alis.Core.Exceptions;
using Alis.FluentApi.Validations;

namespace Alis.Core.Entities
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene
    {
        #region Awake()

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public void Awake()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Awake();
            }
        }

        #endregion

        #region Start()

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Start();
            }
        }

        #endregion

        #region BeforeUpdate()

        /// <summary>
        ///     Befores the update
        /// </summary>
        public void BeforeUpdate()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].BeforeUpdate();
            }
        }

        #endregion

        #region Update()

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Update();
            }
        }

        #endregion

        #region AfterUpdate()

        /// <summary>
        ///     Afters the update
        /// </summary>
        public void AfterUpdate()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].AfterUpdate();
            }
        }

        #endregion

        #region FixedUpdate()

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public void FixedUpdate()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].FixedUpdate();
            }
        }

        #endregion

        #region DispatchEvents()

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public void DispatchEvents()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].DispatchEvents();
            }
        }

        #endregion

        #region Reset()

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Reset();
            }
        }

        #endregion

        #region Stop()

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Stop();
            }
        }

        #endregion

        #region Exit()

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit()
        {
            Span<GameObject> temp = GameObjects.AsSpan();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].Exit();
            }
        }

        #endregion

        #region Destructor

        ~Scene()
        {
            Console.WriteLine(@"destroy");
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        public Scene()
        {
            Name = "Default";
            GameObjects = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="gameobjects">The gameobjects</param>
        /// <exception cref="IndexOutOfBounds"></exception>
        [JsonConstructor]
        public Scene(NotNull<string> name, NotNull<GameObject[]> gameobjects)
        {
            Name = name.Value;
            GameObjects = new GameObject[Game.Setting.Scene.MaxGameObjectByScene];
            if (gameobjects.Value.Length > Game.Setting.Scene.MaxGameObjectByScene)
            {
                throw new IndexOutOfBounds();
            }

            for (int i = 0; i < gameobjects.Value.Length; i++)
            {
                GameObjects[i] = gameobjects.Value[i];
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        [JsonPropertyName("_Name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the game objects
        /// </summary>
        [JsonPropertyName("_GameObjects")]
        public GameObject[] GameObjects { get; set; } 

        #endregion
    }
}