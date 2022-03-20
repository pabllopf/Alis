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

using Alis.Core.Settings.Configurations;
using Alis.Tools;

namespace Alis.Core.Settings
{
    /// <summary>
    ///     The setting class
    /// </summary>
    public class Setting
    {
        /// <summary>
        ///     The debug
        /// </summary>
        private Debug debug = new Debug();

        /// <summary>
        ///     The game object
        /// </summary>
        private GameObject gameObject = new GameObject();

        /// <summary>
        ///     The general
        /// </summary>
        private General general = new General();

        /// <summary>
        ///     The graphic
        /// </summary>
        private Graphic graphic = new Graphic();

        /// <summary>
        ///     The particle
        /// </summary>
        private Particle particle = new Particle();

        /// <summary>
        ///     The physics
        /// </summary>
        private Configurations.Physics physics = new Configurations.Physics();

        /// <summary>
        ///     The quality
        /// </summary>
        private Quality quality = new Quality();

        /// <summary>
        ///     The scene
        /// </summary>
        private Scene scene = new Scene();

        /// <summary>
        ///     The time
        /// </summary>
        private Time time = new Time();

        /// <summary>
        ///     The window
        /// </summary>
        private Window window = new Window();

        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        public Debug Debug
        {
            get => debug;
            set => debug = value;
        }

        /// <summary>
        ///     Gets or sets the value of the general
        /// </summary>
        public General General
        {
            get => general;
            set => general = value;
        }

        /// <summary>
        ///     Gets or sets the value of the graphic
        /// </summary>
        public Graphic Graphic
        {
            get => graphic;
            set => graphic = value;
        }

        /// <summary>
        ///     Gets or sets the value of the particle
        /// </summary>
        public Particle Particle
        {
            get
            {
                Logger.Trace($"Setting.Particle '{particle}'");
                return particle;
            }
            set
            {
                Logger.Trace($"Setting.Particle from '{particle}' to '{value}'");
                particle = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the physics
        /// </summary>
        public Configurations.Physics Physics
        {
            get
            {
                Logger.Trace($"Setting.Physics '{physics}'");
                return physics;
            }
            set
            {
                Logger.Trace($"Setting.Physics from '{physics}' to '{value}'");
                physics = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the quality
        /// </summary>
        public Quality Quality
        {
            get
            {
                Logger.Trace($"Setting.Quality '{quality}'");
                return quality;
            }
            set
            {
                Logger.Trace($"Setting.Quality from '{quality}' to '{value}'");
                quality = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        public Window Window
        {
            get => window;
            set => window = value;
        }

        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        public GameObject GameObject
        {
            get => gameObject;
            set => gameObject = value;
        }

        /// <summary>
        ///     Gets or sets the value of the scene
        /// </summary>
        public Scene Scene
        {
            get => scene;
            set => scene = value;
        }

        /// <summary>
        ///     Gets or sets the value of the time
        /// </summary>
        public Time Time
        {
            get => time;
            set => time = value;
        }
    }
}