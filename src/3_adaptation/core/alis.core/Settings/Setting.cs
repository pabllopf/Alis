// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Setting.cs
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

#region

using Alis.Core.Settings.Configurations;

#endregion

namespace Alis.Core.Settings
{
    /// <summary>
    ///     The setting class
    /// </summary>
    public class Setting
    {
        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        public Debug Debug { get; set; } = new Debug();

        /// <summary>
        ///     Gets or sets the value of the general
        /// </summary>
        public General General { get; set; } = new General();

        /// <summary>
        ///     Gets or sets the value of the graphic
        /// </summary>
        public Graphic Graphic { get; set; } = new Graphic();

        /// <summary>
        ///     Gets or sets the value of the input
        /// </summary>
        //public Input Input { get; set; } = new Input();

        /// <summary>
        ///     Gets or sets the value of the particle
        /// </summary>
        public Particle Particle { get; set; } = new Particle();

        /// <summary>
        ///     Gets or sets the value of the physics
        /// </summary>
        public Physics Physics { get; set; } = new Physics();

        /// <summary>
        ///     Gets or sets the value of the quality
        /// </summary>
        public Quality Quality { get; set; } = new Quality();

        /// <summary>
        ///     Gets or sets the value of the time
        /// </summary>
        //public Time Time { get; set; } = new Time();

        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        public Window Window { get; set; } = new Window();

        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        public GameObject GameObject { get; set; } = new GameObject();

        /// <summary>
        ///     Gets or sets the value of the scene
        /// </summary>
        public Scene Scene { get; set; } = new Scene();
    }
}