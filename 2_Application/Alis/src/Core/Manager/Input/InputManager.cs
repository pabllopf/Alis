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
using Alis.Core.Graphic.SDL;
using Alis.Core.Graphic.SDL.Enums;
using Alis.Core.Graphic.SDL.Structs;
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
        private List<SdlKeycode> keys;

        /// <summary>
        ///     Temp list of keys
        /// </summary>
        private List<SdlKeycode> tempListOfKeys;
        
        /// <summary>
        /// The sdl event
        /// </summary>
        private static SdlEvent _sdlEvent;
        
        /// <summary>
        ///     The sdl game controller axis
        /// </summary>
        private static readonly List<SdlGameControllerAxis> Axis = new List<SdlGameControllerAxis>((SdlGameControllerAxis[]) Enum.GetValues(typeof(SdlGameControllerAxis)));

        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        private static readonly List<SdlGameControllerButton> Buttons = new List<SdlGameControllerButton>((SdlGameControllerButton[]) Enum.GetValues(typeof(SdlGameControllerButton)));
        
        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            keys = new List<SdlKeycode>((SdlKeycode[]) Enum.GetValues(typeof(SdlKeycode)));
            tempListOfKeys = new List<SdlKeycode>();
        }


        /// <summary>
        ///     Dispatches the events
        /// </summary>
        public override void DispatchEvents()
        {
            Sdl.JoystickUpdate();
            
            while (Sdl.PollEvent(out _sdlEvent) != 0)
            {
                switch (_sdlEvent.type)
                {
                    case SdlEventType.SdlQuit:
                        Console.WriteLine(" Quit was pressed ");
                        VideoGame.Exit();
                        break;
                    case SdlEventType.SdlAudioDeviceAdded:
                        Console.WriteLine($" Audio device was added");
                        Console.WriteLine($" Audio device name: {_sdlEvent.aDevice.ToString()}");
                        break;
                    
                    case SdlEventType.SdlKeyup:
                        SdlKeycode indexUp = _sdlEvent.key.keysym.sym;
                        
                        if (tempListOfKeys.Contains(indexUp))
                        {
                            //Console.WriteLine(indexUp + " was released");
                            tempListOfKeys.Remove(indexUp);
                            NotifyKeyRelease(indexUp);
                        }
                        
                        
                        break;
                    case SdlEventType.SdlKeydown:
                        SdlKeycode indexDown = _sdlEvent.key.keysym.sym;
                        if (!tempListOfKeys.Contains(indexDown))
                        {
                            //Console.WriteLine(indexDown + " was pressed");
                            tempListOfKeys.Add(indexDown);
                            NotifyKeyPress(indexDown);
                        }
                        
                        if (tempListOfKeys.Contains(indexDown))
                        {
                            //Console.WriteLine(indexDown + " holding");
                            NotifyKeyHold(indexDown);
                        }
                        
                        break;
                }

                foreach (SdlGameControllerButton button in Buttons)
                {
                    if ((_sdlEvent.type == SdlEventType.SdlJoyButtonDown)
                        && (button == (SdlGameControllerButton) _sdlEvent.cButton.button))
                    {
                        Console.WriteLine($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed button={button}");
                    }
                }

                foreach (SdlGameControllerAxis axi in Axis)
                {
                    if ((_sdlEvent.type == SdlEventType.SdlJoyAxisMotion)
                        && (axi == (SdlGameControllerAxis) _sdlEvent.cAxis.axis))
                    {
                        Console.WriteLine($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed axi={axi}");
                    }
                }
            }
            
            
            
            for (int index = 0; index < keys.Count - 7; index++)
            {
                HandleKeyPressEvents(index);
                HandleKeyReleaseEvents(index);
                HandleKeyHoldEvents(index);
            }
        }

        /// <summary>
        ///     Handles the key press events using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        private void HandleKeyPressEvents(int index)
        {
            /*
            if (Keyboard.IsKeyPressed(keys[index]) && !tempListOfKeys.Contains(keys[index]))
            {
                tempListOfKeys.Add(keys[index]);
                NotifyKeyPress(keys[index]);
            }*/
        }

        /// <summary>
        ///     Handles the key release events using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        private void HandleKeyReleaseEvents(int index)
        {
            /*
            if (!Keyboard.IsKeyPressed(keys[index]) && tempListOfKeys.Contains(keys[index]))
            {
                tempListOfKeys.Remove(keys[index]);
                NotifyKeyRelease(keys[index]);
            }*/
        }

        /// <summary>
        ///     Handles the key hold events using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        private void HandleKeyHoldEvents(int index)
        {
            /*
            if (Keyboard.IsKeyPressed(keys[index]) && tempListOfKeys.Contains(keys[index]))
            {
                NotifyKeyHold(keys[index]);
            }*/
        }

        /// <summary>
        ///     Notifies the key press using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyPress(SdlKeycode key)
        {
            foreach (GameObject currentSceneGameObject in SceneManager.GetGameObjects())
            {
                currentSceneGameObject.Components.ForEach(i => i.OnPressKey(key));
            }
        }

        /// <summary>
        ///     Notifies the key release using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyRelease(SdlKeycode key)
        {
            foreach (GameObject currentSceneGameObject in SceneManager.GetGameObjects())
            {
                currentSceneGameObject.Components.ForEach(i => i.OnReleaseKey(key));
            }
        }

        /// <summary>
        ///     Notifies the key hold using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyHold(SdlKeycode key)
        {
            foreach (GameObject currentSceneGameObject in SceneManager.GetGameObjects())
            {
                currentSceneGameObject.Components.ForEach(i => i.OnPressDownKey(key));
            }
        }
    }
}