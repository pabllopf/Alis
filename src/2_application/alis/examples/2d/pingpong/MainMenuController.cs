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
using Alis;
using Alis.Core;
using Alis.Core.Components;
using Alis.Core.Managers;
using Alis.Tools;

namespace PingPong
{
    public class MainMenuController : Component
    {
        public override void Start()
        {
        }

        public override void Update()
        {
        }

        public override void OnReleaseKey(string key)
        {
            switch (key)
            {
                case "Num1":
                    Logger.Log("Starting game");
                    SceneManager.LoadScene(1);
                    break;
                case "Num2":
                    Logger.Log("Exit game");
                    Environment.Exit(0);
                    break;
            }
        }

        public override void OnPressKey(string key)
        {
            
        }
    }
}