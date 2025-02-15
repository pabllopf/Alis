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
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Entity;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Core.Ecs.System.Manager.Input
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class InputManager : AManager
    {
        /// <summary>
        ///     The sdl game controller axis
        /// </summary>
        //internal readonly List<GameControllerAxis> Axis = new List<GameControllerAxis>((GameControllerAxis[]) Enum.GetValues(typeof(GameControllerAxis)));

        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        //internal readonly List<GameControllerButton> Buttons = new List<GameControllerButton>((GameControllerButton[]) Enum.GetValues(typeof(GameControllerButton)));

        /// <summary>
        ///     The sdl event
        /// </summary>
        //internal Event SdlEvent;

        /// <summary>
        ///     Temp list of keys
        /// </summary>
        internal List<KeyCodes> TempListOfKeys = new List<KeyCodes>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="InputManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public InputManager(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InputManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        /// <param name="sdlEvent">The sdl event</param>
        //public InputManager(string id, string name, string tag, bool isEnable, Context context, Event sdlEvent) : base(id, name, tag, isEnable, context) => SdlEvent = sdlEvent;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            Logger.Trace();
            TempListOfKeys = new List<KeyCodes>();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            /*
            if (Context is null || Sdl.WasInit(InitSettings.InitEvents) == 0)
            {
                return;
            }

            Sdl.JoystickUpdate();

            while (Sdl.PollEvent(out SdlEvent) != 0)
            {
                HandleSdlQuitEvent();
                HandleSdlKeyupEvent();
                HandleSdlKeydownEvent();
                HandleSdlJoyButtonDownEvent();
                HandleSdlJoyAxisMotionEvent();
            }

            NotifyKeyHold();*/
        }

        /// <summary>
        ///     Handles the sdl quit event
        /// </summary>
        internal void HandleSdlQuitEvent()
        {
            /*if (SdlEvent.type == EventType.Quit)
            {
                Context.Exit();
            }*/
        }

        /// <summary>
        ///     Handles the sdl keyup event
        /// </summary>
        internal void HandleSdlKeyupEvent()
        {
            /*
            if (SdlEvent.type == EventType.Keyup)
            {
                KeyCodes indexUp = SdlEvent.key.KeySym.sym;

                if (TempListOfKeys.Contains(indexUp))
                {
                    TempListOfKeys.Remove(indexUp);
                    NotifyKeyRelease(indexUp);
                }
            }*/
        }

        /// <summary>
        ///     Handles the sdl keydown event
        /// </summary>
        internal void HandleSdlKeydownEvent()
        {
            /*
            if (SdlEvent.type == EventType.Keydown)
            {
                KeyCodes indexDown = SdlEvent.key.KeySym.sym;
                if (!TempListOfKeys.Contains(indexDown))
                {
                    TempListOfKeys.Add(indexDown);
                    NotifyKeyPress(indexDown);
                }
            }*/
        }

        /// <summary>
        ///     Handles the sdl joy button down event
        /// </summary>
        internal void HandleSdlJoyButtonDownEvent()
        {
            /*
            for (int index = 0; index < Buttons.Count; index++)
            {
                GameControllerButton button = Buttons[index];
                if ((SdlEvent.type == EventType.JoyButtonDown)
                    && (button == (GameControllerButton) SdlEvent.cButton.button))
                {
                    Logger.Info($"[SDL_JoystickName_id = '{SdlEvent.cDevice.which}'] Pressed button={button}");
                }
            }*/
        }

        /// <summary>
        ///     Handles the sdl joy axis motion event
        /// </summary>
        internal void HandleSdlJoyAxisMotionEvent()
        {
            /*
            for (int index = 0; index < Axis.Count; index++)
            {
                GameControllerAxis axi = Axis[index];
                if ((SdlEvent.type == EventType.JoyAxisMotion)
                    && (axi == (GameControllerAxis) SdlEvent.cAxis.axis))
                {
                    Logger.Info($"[SDL_JoystickName_id = '{SdlEvent.cDevice.which}'] Pressed axi={axi}");
                }
            }*/
        }

        /// <summary>
        ///     Notifies the key hold
        /// </summary>
        internal void NotifyKeyHold()
        {
            foreach (KeyCodes key in TempListOfKeys)
            {
                NotifyKeyHold(key);
            }
        }

        /// <summary>
        ///     Notifies the key press using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        internal void NotifyKeyPress(KeyCodes key)
        {
            if (Context == null)
            {
                return;
            }

            foreach (GameObject currentSceneGameObject in Context.SceneManager.CurrentScene.GameObjects)
            {
                foreach (AComponent currentSceneGameObjectComponent in currentSceneGameObject.Components)
                {
                    currentSceneGameObjectComponent.OnPressKey(key);
                }
            }
        }

        /// <summary>
        ///     Notifies the key release using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        internal void NotifyKeyRelease(KeyCodes key)
        {
            if (Context == null)
            {
                return;
            }

            foreach (GameObject currentSceneGameObject in Context.SceneManager.CurrentScene.GameObjects)
            {
                foreach (AComponent currentSceneGameObjectComponent in currentSceneGameObject.Components)
                {
                    currentSceneGameObjectComponent.OnReleaseKey(key);
                }
            }
        }

        /// <summary>
        ///     Notifies the key hold using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        internal void NotifyKeyHold(KeyCodes key)
        {
            if (Context == null)
            {
                return;
            }

            foreach (GameObject currentSceneGameObject in Context.SceneManager.CurrentScene.GameObjects)
            {
                foreach (AComponent currentSceneGameObjectComponent in currentSceneGameObject.Components)
                {
                    currentSceneGameObjectComponent.OnPressDownKey(key);
                }
            }
        }
    }
}