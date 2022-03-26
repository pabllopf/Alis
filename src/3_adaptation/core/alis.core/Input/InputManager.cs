// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   InputManager.cs
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
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Alis.Core.Systems;

namespace Alis.Core.Input
{
    /// <summary>
    /// </summary>
    public class InputManager : InputSystem
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InputManager" /> class
        /// </summary>
        static InputManager()
        {
            OnPressKey += InputManager_OnPressKey;
            OnPressDownKey += InputManager_OnPressDownKey;
            OnReleaseKey += InputManager_OnReleaseKey;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InputManager" /> class
        /// </summary>
        [JsonConstructor]
        public InputManager()
        {
            Keys = new List<Keyboard>();
            KeyboardsValues = Enum.GetValues<Keyboard>();
            KeyboardsNames = Enum.GetNames<Keyboard>();
        }

        /// <summary>
        ///     Gets or sets the value of the keys
        /// </summary>
        private List<Keyboard> Keys { get; }

        /// <summary>
        ///     Gets or sets the value of the keyboards
        /// </summary>
        private Keyboard[] KeyboardsValues { get; }

        /// <summary>
        ///     Gets or sets the value of the keyboards names
        /// </summary>
        private string[] KeyboardsNames { get; }

        /// <summary>
        ///     Gets or sets the value of the temp key
        /// </summary>
        private Graphics2D.Windows.Keyboard.Key TempKey { get; set; }

        public static event EventHandler<string> OnPressKey;

        public static event EventHandler<string> OnPressDownKey;

        public static event EventHandler<string> OnReleaseKey;

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
        }

        /// <summary>Fixed the update.</summary>
        public override void FixedUpdate()
        {
            for (int i = 0; i < KeyboardsValues.Length; i++)
            {
                TempKey = Enum.Parse<Graphics2D.Windows.Keyboard.Key>(KeyboardsNames[i]);
                if (Graphics2D.Windows.Keyboard.IsKeyPressed(TempKey))
                {
                    if (!Keys.Contains(KeyboardsValues[i]))
                    {
                        Keys.Add(KeyboardsValues[i]);
                        PressDown(KeyboardsValues[i]);
                        OnPressDownKey.Invoke(this, KeyboardsValues[i].ToString());
                    }

                    PressKey(KeyboardsValues[i]);
                    OnPressKey.Invoke(this, KeyboardsValues[i].ToString());
                }
                else
                {
                    if (Keys.Contains(KeyboardsValues[i]))
                    {
                        Keys.Remove(KeyboardsValues[i]);
                        PressUp(KeyboardsValues[i]);
                        OnReleaseKey.Invoke(this, KeyboardsValues[i].ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     Ons the press up using the specified keyboards value
        /// </summary>
        /// <param name="keyboardsValue">The keyboards value</param>
        public virtual void PressUp(Keyboard keyboardsValue)
        {
        }

        /// <summary>
        ///     Ons the press key using the specified keyboards value
        /// </summary>
        /// <param name="keyboardsValue">The keyboards value</param>
        public virtual void PressKey(Keyboard keyboardsValue)
        {
        }

        /// <summary>
        ///     Ons the press down using the specified keyboards value
        /// </summary>
        /// <param name="keyboardsValue">The keyboards value</param>
        public virtual void PressDown(Keyboard keyboardsValue)
        {
        }

        /// <summary>Dispatches the events.</summary>
        public override void DispatchEvents()
        {
        }


        /// <summary>Resets this instance.</summary>
        public override void Reset()
        {
        }

        /// <summary>
        ///     Inputs the manager on release key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void InputManager_OnReleaseKey(object? sender, string e)
        {
        }

        /// <summary>
        ///     Inputs the manager on press key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void InputManager_OnPressKey(object? sender, string e)
        {
        }

        /// <summary>
        ///     Inputs the manager on press down key using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private static void InputManager_OnPressDownKey(object? sender, string e)
        {
        }


        /// <summary>Stops this instance.</summary>
        public override void Stop()
        {
        }

        ~InputManager() => Console.WriteLine(@$"Destroy InputManager {GetHashCode().ToString()}");
    }
}