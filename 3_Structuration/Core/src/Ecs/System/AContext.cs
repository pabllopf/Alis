// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Context.cs
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

using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    /// The context class
    /// </summary>
    /// <seealso cref="IContext"/>
    public abstract class AContext : IContext
    {
        /// <summary>
        /// The video game
        /// </summary>
        private readonly AGame game;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AContext"/> class
        /// </summary>
        /// <param name="videoGame">The video game</param>
        /// <param name="settings">The settings</param>
        protected AContext(AGame videoGame, ASettings settings)
        {
            game = videoGame;
            Settings = settings;
        }
        
        /// <summary>
        /// Gets or sets the value of the settings
        /// </summary>
        public ASettings Settings { get; internal set; }
        
        /// <summary>
        /// Gets the value of the time manager
        /// </summary>
        public TimeManager TimeManager => game.TimeManager;
        
        /// <summary>
        /// Exits this instance
        /// </summary>
        public void Exit() => game.Exit();
    }
}