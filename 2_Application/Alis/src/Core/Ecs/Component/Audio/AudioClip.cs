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

using Alis.Builder.Core.Ecs.Component.Audio;
using Alis.Core.Aspect.Logging;
using Alis.Core.Audio;

namespace Alis.Core.Ecs.Component.Audio
{
    /// <summary>
    ///     The audio clip class
    /// </summary>
    /// <seealso cref="AudioClipBase" />
    public class AudioClip
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClip" /> class
        /// </summary>
        public AudioClip()
        {
            Logger.Trace();
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClip" /> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        public AudioClip(string fullPathAudio) 
        {
            Logger.Trace();
        }
        
        /// <summary>
        /// Gets or sets the value of the is playing
        /// </summary>
        public bool IsPlaying { get; set; }
        /// <summary>
        /// Gets or sets the value of the is mute
        /// </summary>
        public bool IsMute { get; set; }
        /// <summary>
        /// Gets or sets the value of the is looping
        /// </summary>
        public bool IsLooping { get; set; }
        /// <summary>
        /// Gets or sets the value of the volume
        /// </summary>
        public float Volume { get; set; }
        /// <summary>
        /// Gets or sets the value of the full path audio file
        /// </summary>
        public string FullPathAudioFile { get; set; }
        
        /// <summary>
        ///     Plays this instance
        /// </summary>
        internal void Play()
        {
            
        }
        
        /// <summary>
        ///     Stops this instance
        /// </summary>
        internal void Stop()
        {
           
        }
        
        /// <summary>
        ///     Resumes this instance
        /// </summary>
        internal void Resume()
        {
        }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The audio clip builder</returns>
        public static AudioClipBuilder Builder() => new AudioClipBuilder();
    }
}