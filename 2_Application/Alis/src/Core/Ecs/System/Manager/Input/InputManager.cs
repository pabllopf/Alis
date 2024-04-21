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
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Entity;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Sdl = Alis.Core.Graphic.Sdl2.Sdl;

namespace Alis.Core.Ecs.System.Manager.Input
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="Manager" />
    public class InputManager : Manager
    {
        /// <summary>
        ///     The sdl game controller axis
        /// </summary>
        private readonly List<GameControllerAxis> axis = new List<GameControllerAxis>((GameControllerAxis[]) Enum.GetValues(typeof(GameControllerAxis)));
        
        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        private readonly List<GameControllerButton> buttons = new List<GameControllerButton>((GameControllerButton[]) Enum.GetValues(typeof(GameControllerButton)));
        
        /// <summary>
        ///     The sdl event
        /// </summary>
        private Event sdlEvent;
        
        /// <summary>
        ///     Temp list of keys
        /// </summary>
        private List<KeyCode> tempListOfKeys;
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            Logger.Trace();
            tempListOfKeys = new List<KeyCode>();
        }
        
        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            Sdl.JoystickUpdate();
            
            while (Sdl.PollEvent(out sdlEvent) != 0)
            {
                HandleSdlQuitEvent();
                HandleSdlKeyupEvent();
                HandleSdlKeydownEvent();
                HandleSdlJoyButtonDownEvent();
                HandleSdlJoyAxisMotionEvent();
            }
            
            NotifyKeyHold();
        }
        
        /// <summary>
        ///     Handles the sdl quit event
        /// </summary>
        private void HandleSdlQuitEvent()
        {
            if (sdlEvent.type == EventType.Quit)
            {
                Context.Exit();
            }
        }
        
        /// <summary>
        ///     Handles the sdl keyup event
        /// </summary>
        private void HandleSdlKeyupEvent()
        {
            if (sdlEvent.type == EventType.Keyup)
            {
                KeyCode indexUp = sdlEvent.key.keySym.sym;
                
                if (tempListOfKeys.Contains(indexUp))
                {
                    tempListOfKeys.Remove(indexUp);
                    NotifyKeyRelease(indexUp);
                }
            }
        }
        
        /// <summary>
        ///     Handles the sdl keydown event
        /// </summary>
        private void HandleSdlKeydownEvent()
        {
            if (sdlEvent.type == EventType.Keydown)
            {
                KeyCode indexDown = sdlEvent.key.keySym.sym;
                if (!tempListOfKeys.Contains(indexDown))
                {
                    tempListOfKeys.Add(indexDown);
                    NotifyKeyPress(indexDown);
                }
            }
        }
        
        /// <summary>
        ///     Handles the sdl joy button down event
        /// </summary>
        private void HandleSdlJoyButtonDownEvent()
        {
            for (int index = 0; index < buttons.Count; index++)
            {
                GameControllerButton button = buttons[index];
                if ((sdlEvent.type == EventType.JoyButtonDown)
                    && (button == (GameControllerButton) sdlEvent.cButton.button))
                {
                    Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cDevice.which}'] Pressed button={button}");
                }
            }
        }
        
        /// <summary>
        ///     Handles the sdl joy axis motion event
        /// </summary>
        private void HandleSdlJoyAxisMotionEvent()
        {
            for (int index = 0; index < axis.Count; index++)
            {
                GameControllerAxis axi = axis[index];
                if ((sdlEvent.type == EventType.JoyAxisMotion)
                    && (axi == (GameControllerAxis) sdlEvent.cAxis.axis))
                {
                    Console.WriteLine($"[SDL_JoystickName_id = '{sdlEvent.cDevice.which}'] Pressed axi={axi}");
                }
            }
        }
        
        /// <summary>
        ///     Notifies the key hold
        /// </summary>
        private void NotifyKeyHold()
        {
            foreach (KeyCode key in tempListOfKeys)
            {
                NotifyKeyHold(key);
            }
        }
        
        /// <summary>
        ///     Notifies the key press using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyPress(KeyCode key)
        {
            foreach (GameObject currentSceneGameObject in Context.SceneManager.CurrentScene.GameObjects)
            {
                currentSceneGameObject.Components.ForEach(i => i.OnPressKey(key));
            }
        }
        
        /// <summary>
        ///     Notifies the key release using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyRelease(KeyCode key)
        {
            foreach (GameObject currentSceneGameObject in Context.SceneManager.CurrentScene.GameObjects)
            {
                currentSceneGameObject.Components.ForEach(i => i.OnReleaseKey(key));
            }
        }
        
        /// <summary>
        ///     Notifies the key hold using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyHold(KeyCode key)
        {
            foreach (GameObject currentSceneGameObject in Context.SceneManager.CurrentScene.GameObjects)
            {
                currentSceneGameObject.Components.ForEach(i => i.OnPressDownKey(key));
            }
        }
    }
}