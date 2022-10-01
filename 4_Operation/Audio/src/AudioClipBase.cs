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
using Alis.Core.Audio.OS;
using Alis.Core.Audio.SFML;

namespace Alis.Core.Audio
{
    /// <summary>
    /// The audio clip base class
    /// </summary>
    public abstract class AudioClipBase
    {
        /// <summary>
        /// The music
        /// </summary>
        private Music music;

        /// <summary>
        /// The player
        /// </summary>
        private Player player;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipBase"/> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        public AudioClipBase(string fullPathAudio)
        {
            FullPathAudio = fullPathAudio;
            AudioBackendType = AudioBackendType.SFML;
            if (!fullPathAudio.Equals(""))
            {
                music = new Music(fullPathAudio);
                Console.WriteLine($"Init music: '{fullPathAudio}'");
            }
        }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipBase"/> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        /// <param name="audioBackendType">The audio backend type</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public AudioClipBase(string fullPathAudio, AudioBackendType audioBackendType)
        {
            FullPathAudio = fullPathAudio;
            AudioBackendType = audioBackendType;

            if (!fullPathAudio.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        music = new Music(fullPathAudio);
                        break;
                    case AudioBackendType.OS:
                        player = new Player();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets the value of the full path audio
        /// </summary>
        public string FullPathAudio { get; }

        /// <summary>
        /// Gets the value of the audio backend type
        /// </summary>
        public AudioBackendType AudioBackendType { get; }

        /// <summary>
        /// Plays this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void Play()
        {
            Console.WriteLine($"Init Music::play pass here'{FullPathAudio}'"); 
            
            if (!FullPathAudio.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        music.Play();
                        Console.WriteLine("Init Music::play");
                        break;
                    case AudioBackendType.OS:
                        player.Play(FullPathAudio).Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        /// <summary>
        /// Stops this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void Stop()
        {
            if (!FullPathAudio.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        music.Stop();
                        break;
                    case AudioBackendType.OS:
                        player.Stop().Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        /// <summary>
        /// Resumes this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void Resume()
        {
            if (!FullPathAudio.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        music.Play();
                        break;
                    case AudioBackendType.OS:
                        player.Play(FullPathAudio).Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}