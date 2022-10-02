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
            FullPathAudioFile = fullPathAudio;
            AudioBackendType = AudioBackendType.SFML;
            IsPlaying = false;
            if (!fullPathAudio.Equals(""))
            {
                music = new Music(fullPathAudio);
                Console.WriteLine($"Init music: '{fullPathAudio}'");
            }
        }
        
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
        /// Gets or sets the value of the is mute
        /// </summary>
        public bool IsMute { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the is playing
        /// </summary>
        public bool IsPlaying { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipBase"/> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        /// <param name="audioBackendType">The audio backend type</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected AudioClipBase(string fullPathAudio, AudioBackendType audioBackendType)
        {
            FullPathAudioFile = fullPathAudio;
            AudioBackendType = audioBackendType;
            IsPlaying = false;
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
        /// Gets or sets the value of the full path audio file
        /// </summary>
        public string FullPathAudioFile { get; set; }

        /// <summary>
        /// Gets the value of the audio backend type
        /// </summary>
        public AudioBackendType AudioBackendType { get; set; }

        /// <summary>
        /// Gets or sets the value of the is loopping
        /// </summary>
        public bool IsLooping { get; set; }

        /// <summary>
        /// Gets or sets the value of the volume
        /// </summary>
        public float Volume { get; set; } = 100.0f;

        /// <summary>
        /// Plays this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Play()
        {
            Console.WriteLine($"Init Music::play pass here'{FullPathAudioFile}'");
            
            if (!FullPathAudioFile.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        Console.WriteLine($"Volume={Volume}");

                        music ??= new Music(FullPathAudioFile);

                        music.Volume = Volume;
                        music.Play();
                        Console.WriteLine("Init Music::play");
                        break;
                    case AudioBackendType.OS:
                        player.Play(FullPathAudioFile).Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                IsPlaying = true;
            }
        }
        
        /// <summary>
        /// Stops this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Stop()
        {
            if (!FullPathAudioFile.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        music ??= new Music(FullPathAudioFile);
                        music.Volume = Volume;
                        music.Stop();
                        break;
                    case AudioBackendType.OS:
                        player.Stop().Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                IsPlaying = false;
            }
        }
        
        /// <summary>
        /// Resumes this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Resume()
        {
            if (!FullPathAudioFile.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.SFML:
                        music ??= new Music(FullPathAudioFile);
                        music.Volume = Volume;
                        music.Play();
                        break;
                    case AudioBackendType.OS:
                        player.Play(FullPathAudioFile).Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                IsPlaying = true;
            }
        }
    }
}