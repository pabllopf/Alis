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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Entity;
using Alis.Core.Graphic.SFML.Windows;
using Alis.Core.Manager.Scene;

namespace Alis.Core.Manager.Input
{
    /// <summary>
    ///     The input manager class
    /// </summary>
    /// <seealso cref="InputManagerBase" />
    public class InputManager : InputManagerBase
    {
        /// <summary>
        ///     Array of key of keyboard
        /// </summary>
        private List<Key> keys;

        /// <summary>
        ///     Temp list of keys
        /// </summary>
        private List<Key> tempListOfKeys;

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            keys = new List<Key>((Key[]) Enum.GetValues(typeof(Key)));
            tempListOfKeys = new List<Key>();
        }

        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            for (int index = 0; index < keys.Count - 7; index++)
            {
                if (Keyboard.IsKeyPressed(keys[index]) && !tempListOfKeys.Contains(keys[index]))
                {
                    tempListOfKeys.Add(keys[index]);

                    foreach (GameObject currentSceneGameObject in SceneManager.CurrentSceneManager.CurrentScene.GameObjects)
                    {
                        currentSceneGameObject.Components.ForEach(i => i.OnPressKey(keys[index]));
                    }
                }

                if (!Keyboard.IsKeyPressed(keys[index]) && tempListOfKeys.Contains(keys[index]))
                {
                    tempListOfKeys.Remove(keys[index]);
                    foreach (GameObject currentSceneGameObject in SceneManager.CurrentSceneManager.CurrentScene.GameObjects)
                    {
                        currentSceneGameObject.Components.ForEach(i => i.OnReleaseKey(keys[index]));
                    }
                }


                if (Keyboard.IsKeyPressed(keys[index]) && tempListOfKeys.Contains(keys[index]))
                {
                    foreach (GameObject currentSceneGameObject in SceneManager.CurrentSceneManager.CurrentScene.GameObjects)
                    {
                        currentSceneGameObject.Components.ForEach(i => i.OnPressDownKey(keys[index]));
                    }
                }
            }
        }
    }
}