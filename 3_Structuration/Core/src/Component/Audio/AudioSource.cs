// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSource.cs
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
using Alis.Core.Audio;
using Alis.Core.Entity;

namespace Alis.Core.Component.Audio
{
    /// <summary>
    /// The audio source class
    /// </summary>
    public class AudioSource : AudioSourceBase, IComponent
    {
        /// <summary>
        /// Gets or sets the value of the audio clip
        /// </summary>
        public AudioClip AudioClip { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSource"/> class
        /// </summary>
        /// <param name="audioClip">The audio clip base</param>
        public AudioSource(AudioClip audioClip) : base(audioClip)
        {
            AudioClip = audioClip;
        }

        /// <summary>
        /// Gets or sets the value of the is active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the value of the destroyed
        /// </summary>
        public bool Destroyed { get; set; }
        /// <summary>
        /// Gets or sets the value of the game object
        /// </summary>
        public GameObject GameObject { get; set; }
        
        /// <summary>
        /// Starts this instance
        /// </summary>
        public void Start()
        {
            Play();
            Console.WriteLine($"Play sound: '{AudioClip.FullPathAudio}'");
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
        }
    }
}