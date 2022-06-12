// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MainMenuController.cs
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

namespace Alis.Sample.D2.GeometryDash
{
    /// <summary>
    ///     The main menu controller class
    /// </summary>
    /// <seealso cref="Component" />
    public class MainMenuController : Component
    {
        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void Start()
        {
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(string key)
        {
            switch (key)
            {
                case "Enter":
                    Logger.Log("Starting game");
                    SceneSystem.LoadScene(1);
                    break;
                case "Escape":
                    Logger.Log("Exit game");
                    Environment.Exit(0);
                    break;
            }
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(string key)
        {
        }
    }
}