// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioClipBase.cs
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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Audio.OS;

namespace Alis.Core.Audio
{
    /// <summary>
    ///     The audio clip base class
    /// </summary>
    public abstract class AudioClipBase
    {
        /// <summary>
        ///     The player
        /// </summary>
        private readonly Player player;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClipBase" /> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        protected AudioClipBase(string fullPathAudio)
        {
            FullPathAudioFile = fullPathAudio;
            player = new Player();
            Logger.Log($"Init music: '{fullPathAudio}'");
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClipBase" /> class
        /// </summary>
        protected AudioClipBase()
        {
            player = new Player();
            Logger.Log("Init music: 'null file'");
        }
        
        /// <summary>
        ///     Gets or sets the value of the sample rate
        /// </summary>
        public int SampleRate { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the channel count
        /// </summary>
        public int ChannelCount { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        public float Duration { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the pitch
        /// </summary>
        public int Pitch { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the is mute
        /// </summary>
        public bool IsMute { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the is playing
        /// </summary>
        public bool IsPlaying => player.Playing;
        
        /// <summary>
        ///     Gets or sets the value of the full path audio file
        /// </summary>
        public string FullPathAudioFile { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the is looping
        /// </summary>
        public bool IsLooping { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public float Volume { get; set; } = 100.0f;
        
        /// <summary>
        ///     Plays this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Play()
        {
            Logger.Log($"Init Music::play pass here'{FullPathAudioFile}'");
            
            if (!string.IsNullOrEmpty(FullPathAudioFile))
            {
                if (!player.Playing)
                {
                    Task.Run(() => player.Play(FullPathAudioFile).Wait());
                }
            }
        }
        
        /// <summary>
        ///     Stops this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Stop()
        {
            if (!string.IsNullOrEmpty(FullPathAudioFile))
            {
                if (player.Playing)
                {
                    Task.Run(() => player.Stop());
                }
            }
        }
        
        /// <summary>
        ///     Resumes this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Resume()
        {
            if (!string.IsNullOrEmpty(FullPathAudioFile))
            {
                Task.Run(() => player.Resume().Wait());
            }
        }
    }
}