// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceBase.cs
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

namespace Alis.Core.Audio
{
    /// <summary>
    /// The audio source base class
    /// </summary>
    public abstract class AudioSourceBase
    {
        /// <summary>
        /// The audio clip base
        /// </summary>
        private AudioClipBase AudioClip { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSourceBase"/> class
        /// </summary>
        /// <param name="audioClipBase">The audio clip base</param>
        public AudioSourceBase(AudioClipBase audioClipBase)
        {
            this.AudioClip = audioClipBase;
        }
        
        /// <summary>
        /// Gets the value of the is playing
        /// </summary>
        public bool IsPlaying { get;}
        
        /// <summary>
        /// Gets or sets the value of the mute
        /// </summary>
        public bool Mute { get; set; }

        /// <summary>
        /// Gets or sets the value of the loop
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        /// Gets or sets the value of the volume
        /// </summary>
        public float Volume { get; set; }

        /// <summary>
        /// Sets or gets the value of the priority
        /// </summary>
        public int Priority { set; get; }

        /// <summary>
        /// Gets or sets the value of the sample rate
        /// </summary>
        public int SampleRate { get; set; }

        /// <summary>
        /// Gets or sets the value of the channel count
        /// </summary>
        public int ChannelCount { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the duration
        /// </summary>
        public float Duration { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the pitch
        /// </summary>
        public int Pitch { get; set; }
        
        /// <summary>
        /// Plays this instance
        /// </summary>
        public void Play() => AudioClip.Play();

        /// <summary>
        /// Stops this instance
        /// </summary>
        public void Stop() => AudioClip.Stop();
        
        /// <summary>
        /// Resumes this instance
        /// </summary>
        public void Resume() => AudioClip.Resume();
    }
}