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
using Alis.Core.Aspect.Logging;
using Alis.Core.Entity;
using Alis.Core.Graphic.SDL;
using Alis.Core.Graphic.SFML.Windows;
using Alis.Core.Manager.Scene;

namespace Alis.Core.Manager.Input
{
    /// <summary>
    /// </summary>
    public class InputManager : InputManagerBase
    {
        /// <summary>
        ///     The axis
        /// </summary>
        private List<SDL.SDL_GameControllerAxis> axis;

        /// <summary>
        ///     The axis temp
        /// </summary>
        private List<SDL.SDL_GameControllerAxis> axisTemp;

        /// <summary>
        ///     The buttons
        /// </summary>
        private List<SDL.SDL_GameControllerButton> buttons;

        /// <summary>
        ///     The buttons temp
        /// </summary>
        private Dictionary<string, SDL.SDL_GameControllerButton> buttonsTemp;


        /// <summary>
        ///     The currentsdl numjoysticks
        /// </summary>
        private int currentSdlNumJoysticks;

        /// <summary>
        ///     The joysticks
        /// </summary>
        private List<IntPtr> joysticks;

        /// <summary>
        ///     Array of key of keyboard
        /// </summary>
        private List<Key> keys;


        /// <summary>
        ///     The sdl event
        /// </summary>
        private SDL.SDL_Event sdlEvent;

        /// <summary>
        ///     Temp list of keys
        /// </summary>
        private List<Key> tempListOfKeys;

/*
        /// <summary>
        /// The sdl key status
        /// </summary>
        private IntPtr sdlKeyStatus;

        /// <summary>
        /// The numkeys
        /// </summary>
        private int numkeys;*/

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void Init()
        {
            SDL.SDL_SetHint(SDL.SDL_HINT_XINPUT_ENABLED, "0");
            SDL.SDL_SetHint(SDL.SDL_HINT_JOYSTICK_THREAD, "1");
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);

            joysticks = new List<IntPtr>();

            for (int i = 0; i < SDL.SDL_NumJoysticks(); i++)
            {
                IntPtr myJoystick = SDL.SDL_JoystickOpen(i);
                if (myJoystick == IntPtr.Zero)
                {
                    Logger.Exception($"Error on SDL2: {SDL.SDL_GetError()}");
                }
                else
                {
                    Logger.Log($"[SDL_JoystickName_id = '{i}'] \n" +
                               $"SDL_JoystickName={SDL.SDL_JoystickName(myJoystick)} \n" +
                               $"SDL_JoystickNumAxes={SDL.SDL_JoystickNumAxes(myJoystick)} \n" +
                               $"SDL_JoystickNumButtons={SDL.SDL_JoystickNumButtons(myJoystick)}");
                }

                joysticks.Add(myJoystick);
            }

            currentSdlNumJoysticks = SDL.SDL_NumJoysticks();


            buttons = new List<SDL.SDL_GameControllerButton>((SDL.SDL_GameControllerButton[]) Enum.GetValues(typeof(SDL.SDL_GameControllerButton)));
            buttonsTemp = new Dictionary<string, SDL.SDL_GameControllerButton>();

            axis = new List<SDL.SDL_GameControllerAxis>((SDL.SDL_GameControllerAxis[]) Enum.GetValues(typeof(SDL.SDL_GameControllerAxis)));
            axisTemp = new List<SDL.SDL_GameControllerAxis>();

            keys = new List<Key>((Key[]) Enum.GetValues(typeof(Key)));
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
            SDL.SDL_JoystickUpdate();
            SDL.SDL_GameControllerUpdate();

            if (SDL.SDL_NumJoysticks() != currentSdlNumJoysticks)
            {
                joysticks = new List<IntPtr>();
                for (int i = 0; i < SDL.SDL_NumJoysticks(); i++)
                {
                    IntPtr myJoystick = SDL.SDL_JoystickOpen(i);
                    if (myJoystick == IntPtr.Zero)
                    {
                        Logger.Exception($"Error on SDL2: {SDL.SDL_GetError()}");
                    }
                    else
                    {
                        Logger.Log($"[SDL_JoystickName_id = '{i}'] \n" +
                                   $"SDL_JoystickName={SDL.SDL_JoystickName(myJoystick)} \n" +
                                   $"SDL_JoystickNumAxes={SDL.SDL_JoystickNumAxes(myJoystick)} \n" +
                                   $"SDL_JoystickNumButtons={SDL.SDL_JoystickNumButtons(myJoystick)}");
                    }

                    joysticks.Add(myJoystick);
                }

                currentSdlNumJoysticks = SDL.SDL_NumJoysticks();
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
            while (SDL.SDL_PollEvent(out sdlEvent) != 0)
            {
                if (SDL.SDL_NumJoysticks() > 0)
                {
                    for (int joystickId = 0; joystickId < joysticks.Count; joystickId++)
                    {
                        for (int index = 0; index < buttons.Count; index++)
                        {
                            if ((SDL.SDL_JoystickGetButton(joysticks[joystickId], (int) buttons[index]) != 0)
                                && !buttonsTemp.ContainsKey($"{joysticks[joystickId]}|{buttons[index]}"))
                            {
                                buttonsTemp.Add($"{joysticks[joystickId]}|{buttons[index]}", buttons[index]);
                                foreach (GameObject currentSceneGameObject in SceneManager.CurrentSceneManager.CurrentScene.GameObjects)
                                {
                                    currentSceneGameObject.Components.ForEach(i => i.OnPressButton(buttons[index], joystickId));
                                }
                            }

                            if ((SDL.SDL_JoystickGetButton(joysticks[joystickId], (int) buttons[index]) == 0)
                                && buttonsTemp.ContainsKey($"{joysticks[joystickId]}|{buttons[index]}"))
                            {
                                buttonsTemp.Remove($"{joysticks[joystickId]}|{buttons[index]}");
                                foreach (GameObject currentSceneGameObject in SceneManager.CurrentSceneManager.CurrentScene.GameObjects)
                                {
                                    currentSceneGameObject.Components.ForEach(i => i.OnReleaseButton(buttons[index], joystickId));
                                }
                            }
                        }
                    }
                }
            }

            if (SDL.SDL_NumJoysticks() > 0)
            {
                for (int joystickId = 0; joystickId < joysticks.Count; joystickId++)
                {
                    for (int index = 0; index < buttons.Count; index++)
                    {
                        if ((SDL.SDL_JoystickGetButton(joysticks[joystickId], (int) buttons[index]) != 0)
                            && buttonsTemp.ContainsKey($"{joysticks[joystickId]}|{buttons[index]}"))
                        {
                            foreach (GameObject currentSceneGameObject in SceneManager.CurrentSceneManager.CurrentScene.GameObjects)
                            {
                                currentSceneGameObject.Components.ForEach(i => i.OnPressDownButton(buttons[index], joystickId));
                            }
                        }
                    }
                }
            }
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

        /*
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
                    tempListOfKeys.Add(key);

                    foreach (GameObject currentSceneGameObject in SceneManager.currentSceneManager.currentScene.gameObjects)
                    {
                        currentSceneGameObject.components.ForEach(i => i.OnPressKey(key.ToString()));
                    }
                }

                if (!Keyboard.IsKeyPressed(key) && tempListOfKeys.Contains(key))
                {
                    tempListOfKeys.Remove(key);
                    foreach (GameObject currentSceneGameObject in SceneManager.currentSceneManager.currentScene.gameObjects)
                    {
                        currentSceneGameObject.components.ForEach(i => i.OnReleaseKey(key.ToString()));
                    }
                }


                if (Keyboard.IsKeyPressed(key) && tempListOfKeys.Contains(key))
                {
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
        }*/
    }
}