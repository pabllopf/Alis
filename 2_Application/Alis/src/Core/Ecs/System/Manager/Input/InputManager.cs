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

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System.Scope;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Ecs.System.Manager.Input
{
    /// <summary>
    ///     The input manager class
    /// </summary>
    /// <seealso cref="AManager" />
    public class InputManager : AManager
    {
        /// <summary>
        ///     The key callback
        /// </summary>
        private KeyCallback keyCallback;


        /// <summary>
        ///     Initializes a new instance of the <see cref="InputManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public InputManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            keyCallback = KeyCallback;
            Glfw.SetKeyCallback(Context.GraphicManager.Window, keyCallback);
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            if (Glfw.WindowShouldClose(Context.GraphicManager.Window))
            {
                Context.IsRunning = false;
            }
        }

        /// <summary>
        ///     Keys the callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="key">The key</param>
        /// <param name="scancode">The scancode</param>
        /// <param name="state">The state</param>
        /// <param name="mods">The mods</param>
        private void KeyCallback(Window window, Keys key, int scancode, InputState state, ModifierKeys mods)
        {
            Entity.Scene currentScene = Context.SceneManager.CurrentScene;
            if (currentScene == null) return;

            List<GameObject> gameObjects = currentScene.GameObjects;
            foreach (GameObject gameObject in gameObjects)
            {
                List<AComponent> components = gameObject.Components;
                foreach (AComponent component in components)
                {
                    switch (state)
                    {
                        case InputState.Press:
                            component.OnPressKey(key);
                            component.OnPressDownKey(key);
                            break;
                        case InputState.Release:
                            component.OnReleaseKey(key);
                            break;
                        case InputState.Repeat:
                            component.OnPressDownKey(key);
                            break;
                    }
                }
            }
        }
    }
}