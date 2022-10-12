// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputManager.cs
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
using Alis.Core.Entity;
using Alis.Core.Graphic.D2.SFML.Windows;
using Alis.Core.Manager.Scene;

namespace Alis.Core.Manager.Input
{
    /// <summary>
    /// </summary>
    public class InputManager : InputManagerBase
    {
        /// <summary>
        /// Array of key of keyboard
        /// </summary>
        private List<Key> keys;

        /// <summary>
        /// Temp list of keys
        /// </summary>
        private List<Key> tempListOfKeys;

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            keys = new List<Key>((Key[])Enum.GetValues(typeof(Key)));
            tempListOfKeys = new List<Key>();
        }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        ///     Befores the update
        /// </summary>
        public override void BeforeUpdate()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            
        }

        /// <summary>
        ///     Afters the update
        /// </summary>
        public override void AfterUpdate()
        {
        }

        /// <summary>
        ///     Fixeds the update
        /// </summary>
        public override void FixedUpdate()
        {
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            for (int index = 0; index < keys.Count - 7; index++)
            {
                Key key = keys[index];
                if (Keyboard.IsKeyPressed(key) && !tempListOfKeys.Contains(key))
                {
                    //Console.WriteLine($"Key pressed={key}");
                    tempListOfKeys.Add(key);

                    foreach (GameObject currentSceneGameObject in SceneManager.currentSceneManager.currentScene.gameObjects)
                    {
                        currentSceneGameObject.components.ForEach(i => i.OnPressKey(key.ToString()));
                    }
                }

                if (!Keyboard.IsKeyPressed(key) && tempListOfKeys.Contains(key))
                {
                    //Console.WriteLine($"Key NOT pressed={key}");
                    tempListOfKeys.Remove(key);
                    foreach (GameObject currentSceneGameObject in SceneManager.currentSceneManager.currentScene.gameObjects)
                    {
                        currentSceneGameObject.components.ForEach(i => i.OnReleaseKey(key.ToString()));
                    }
                }


                if (Keyboard.IsKeyPressed(key) && tempListOfKeys.Contains(key))
                {
                    //Console.WriteLine($"Key pressing={key}");

                    foreach (GameObject currentSceneGameObject in SceneManager.currentSceneManager.currentScene.gameObjects)
                    {
                        currentSceneGameObject.components.ForEach(i => i.OnPressDownKey(key.ToString()));
                    }
                }
            }
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public override void Reset()
        {
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop()
        {
        }

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit()
        {
        }
    }
}