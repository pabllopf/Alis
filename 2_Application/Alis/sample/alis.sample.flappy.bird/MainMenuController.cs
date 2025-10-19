// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainMenuController.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The main menu controller class
    /// </summary>
    
    public class MainMenuController : IOnUpdate, IOnPressKey, IHasContext<Context>
    {

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        /// Ons the press key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        public void OnPressKey(KeyEventInfo info)
        {
            if (info.Key == ConsoleKey.Spacebar)
            {
                Logger.Info("Changing to game scene 'Game_Scene'...");
                Context.SceneManager.LoadScene(1);
            }
        }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }
    }
}