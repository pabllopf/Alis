// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioClip.cs
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

using Alis.Core.Audio;
using Alis.Core.Entity;

namespace Alis.Core.Component.Audio
{
    /// <summary>
    ///     The audio clip class
    /// </summary>
    public  class AudioClip : AudioClipBase, IComponent
    {
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
        /// <exception cref="System.NotImplementedException"></exception>
        public void Start()
        {
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClip"/> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        public AudioClip(string fullPathAudio) : base(fullPathAudio)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClip"/> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        /// <param name="audioBackendType">The audio backend type</param>
        public AudioClip(string fullPathAudio, AudioBackendType audioBackendType) : base(fullPathAudio, audioBackendType)
        {
        }
    }
}