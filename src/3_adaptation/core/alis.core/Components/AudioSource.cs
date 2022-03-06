// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AudioSource.cs
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
using Alis.Core.Entities;
using SFML.Audio;

namespace Alis.Core.Components
{
    /// <summary>
    ///     The audio source class
    /// </summary>
    /// <seealso cref="Component" />
    public class AudioSource : Component
    {
        /// <summary>
        ///     The sound
        /// </summary>
        private Music? sound;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSource" /> class
        /// </summary>
        public AudioSource() => PathFile = "";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSource" /> class
        /// </summary>
        /// <param name="pathFile">The path file</param>
        public AudioSource(string pathFile) => PathFile = pathFile;

        /// <summary>
        ///     Gets or sets the value of the path file
        /// </summary>
        public string PathFile { get; set; }

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void Awake()
        {
            if (!string.IsNullOrEmpty(PathFile))
            {
                sound = new Music(PathFile);
                sound.Loop = true;
                sound.Volume = 100;
            }
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Start() => sound?.Play();

        /// <summary>
        ///     Updates this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Update()
        {
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public override void Stop() => sound?.Pause();

        /// <summary>
        ///     Exits this instance
        /// </summary>
        public override void Exit() => sound?.Stop();
    }
}