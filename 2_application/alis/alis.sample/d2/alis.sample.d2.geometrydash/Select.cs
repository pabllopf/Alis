// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Select.cs
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

namespace Alis.Sample.D2.GeometryDash
{
    /// <summary>
    ///     The select class
    /// </summary>
    /// <seealso cref="Component" />
    public class Select : Component
    {
        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
            //Input.OnPressKey += Input_OnPressKeyOnce;
        }

        /// <summary>
        ///     Inputs the on press key once using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="key">The key</param>
        private void Input_OnPressKeyOnce(object sender, Keyboard key)
        {
            /*
            if (key.Equals(Keyboard.Num1))
            {
                SceneManager.Load("Game");
                return;
            }

            if (key.Equals(Keyboard.Num2))
            {
                Environment.Exit(0);
                return;
            }*/
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}