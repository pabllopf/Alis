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
using System.Linq;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Sdl = Alis.Core.Graphic.Sdl2.Sdl;

namespace Alis.Core.Ecs.System.Manager.Input
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="Manager" />
    public class InputManager : Manager, IInputManager
    {
        /// <summary>
        ///     The sdl event
        /// </summary>
        private static SdlEvent _sdlEvent;

        /// <summary>
        ///     The sdl game controller axis
        /// </summary>
        private static readonly List<GameControllerAxis> Axis = new List<GameControllerAxis>((GameControllerAxis[]) Enum.GetValues(typeof(GameControllerAxis)));

        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        private static readonly List<GameControllerButton> Buttons = new List<GameControllerButton>((GameControllerButton[]) Enum.GetValues(typeof(GameControllerButton)));

        /// <summary>
        ///     Array of key of keyboard
        /// </summary>
        private List<SdlKeycode> keys;

        /// <summary>
        ///     Temp list of keys
        /// </summary>
        private List<SdlKeycode> tempListOfKeys;

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public override void OnEnable()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            Logger.Trace();

            keys = new List<SdlKeycode>((SdlKeycode[]) Enum.GetValues(typeof(SdlKeycode)));
            tempListOfKeys = new List<SdlKeycode>();
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public override void OnBeforeFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public override void OnFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public override void OnAfterFixedUpdate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            Logger.Trace();

            Sdl.JoystickUpdate();

            while (Sdl.PollEvent(out _sdlEvent) != 0)
            {
                switch (_sdlEvent.type)
                {
                    case EventType.SdlQuit:
                        //Console.WriteLine(" Quit was pressed ");
                        VideoGame.Instance.Exit();
                        break;

                    case EventType.SdlKeyup:
                        SdlKeycode indexUp = _sdlEvent.key.keySym.sym;

                        if (tempListOfKeys.Contains(indexUp))
                        {
                            //Console.WriteLine(indexUp + " was released");
                            tempListOfKeys.Remove(indexUp);
                            NotifyKeyRelease(indexUp);
                        }

                        break;
                    case EventType.SdlKeydown:
                        SdlKeycode indexDown = _sdlEvent.key.keySym.sym;
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

                foreach (GameControllerButton button in Buttons)
                {
                    if ((_sdlEvent.type == EventType.SdlJoyButtonDown)
                        && (button == (GameControllerButton) _sdlEvent.cButton.button))
                    {
                        Console.WriteLine($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed button={button}");
                    }
                }

                foreach (GameControllerAxis axi in Axis)
                {
                    if ((_sdlEvent.type == EventType.SdlJoyAxisMotion)
                        && (axi == (GameControllerAxis) _sdlEvent.cAxis.axis))
                    {
                        Console.WriteLine($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed axi={axi}");
                    }
                }
            }
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public override void OnCalculate()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public override void OnDisable()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public override void OnReset()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public override void OnStop()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Notifies the key press using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        private void NotifyKeyPress(SdlKeycode key)
        {
            foreach (GameObject currentSceneGameObject in VideoGame.Instance.SceneManager.CurrentScene.GameObjects.Cast<GameObject>())
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
            foreach (GameObject currentSceneGameObject in VideoGame.Instance.SceneManager.CurrentScene.GameObjects.Cast<GameObject>())
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
            foreach (GameObject currentSceneGameObject in VideoGame.Instance.SceneManager.CurrentScene.GameObjects.Cast<GameObject>())
            {
                currentSceneGameObject.Components.ForEach(i => i.OnPressDownKey(key));
            }
        }
    }
}