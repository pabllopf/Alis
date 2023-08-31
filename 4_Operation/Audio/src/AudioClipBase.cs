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
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Logging;
using Alis.Core.Audio.OS;
#if AudioBackendSDL || AudioBackendAll
using Alis.Core.Audio.SDL;
#endif
#if AudioBackendSFML || AudioBackendAll
using Alis.Core.Audio.SFML;
#endif

namespace Alis.Core.Audio
{
    /// <summary>
    ///     The audio clip base class
    /// </summary>
    public abstract class AudioClipBase
    {
#if AudioBackendSDL || AudioBackendAll
        /// <summary>
        ///     The music ptr
        /// </summary>
        private readonly IntPtr musicPtr;
#endif

        /// <summary>
        ///     The player
        /// </summary>
        private readonly Player player;

#if AudioBackendSFML || AudioBackendAll
        /// <summary>
        ///     The music
        /// </summary>
        private Music music;
#endif

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClipBase" /> class
        /// </summary>
        static AudioClipBase()
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("csfml-audio", AudioDlls.CsfmlAudioDllBytes);
            EmbeddedDllClass.ExtractEmbeddedDlls("openal32", AudioDlls.OpenalAudioDllBytes);
            EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_mixer", AudioDlls.SdlAudioDllBytes);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClipBase" /> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        public AudioClipBase(string fullPathAudio)
        {
            FullPathAudioFile = fullPathAudio;
            AudioBackendType = AudioBackendType.Sfml;
            IsPlaying = false;
#if AudioBackendSFML || AudioBackendAll
            music = new Music(fullPathAudio);
#endif
            Logger.Log($"Init music: '{fullPathAudio}'");
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClipBase" /> class
        /// </summary>
        public AudioClipBase()
        {
            AudioBackendType = AudioBackendType.Sfml;
            Logger.Log("Init music: 'null file'");
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClipBase" /> class
        /// </summary>
        /// <param name="fullPathAudio">The full path audio</param>
        /// <param name="audioBackendType">The audio backend type</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected AudioClipBase(string fullPathAudio, AudioBackendType audioBackendType)
        {
            FullPathAudioFile = fullPathAudio;
            AudioBackendType = audioBackendType;
            IsPlaying = false;
            switch (AudioBackendType)
            {
#if AudioBackendSFML || AudioBackendAll
                case AudioBackendType.Sfml:
                    music = new Music(fullPathAudio);
                    break;
#endif
                case AudioBackendType.Os:
                    player = new Player();
                    break;
                
#if AudioBackendSDL || AudioBackendAll
                case AudioBackendType.Sdl:
                    //Initialize all SDL subsystems
                    SdlMixerExtern.SDL_Init(SdlMixer.SdlInitAudio);
                    SdlMixerExtern.Mix_OpenAudio(22050, SdlMixer.MixDefaultFormat, 2, 4096);
                    musicPtr = SdlMixer.Mix_LoadMUS(fullPathAudio);
                    break;
#endif
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
        public bool IsPlaying { get; set; }

        /// <summary>
        ///     Gets or sets the value of the full path audio file
        /// </summary>
        public string FullPathAudioFile { get; set; }

        /// <summary>
        ///     Gets the value of the audio backend type
        /// </summary>
        public AudioBackendType AudioBackendType { get; }

        /// <summary>
        ///     Gets or sets the value of the is loopping
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

            if (!FullPathAudioFile.Equals(""))
            {
                switch (AudioBackendType)
                {
#if AudioBackendSFML || AudioBackendAll
                    case AudioBackendType.Sfml:
                        Logger.Log($"Volume={Volume}");

                        music ??= new Music(FullPathAudioFile);

                        music.Volume = Volume;
                        music.Play();
                        Logger.Log("Init Music::play");
                        break;
#endif
                    case AudioBackendType.Os:
                        player.Play(FullPathAudioFile).Wait();
                        break;
#if AudioBackendSDL || AudioBackendAll
                    case AudioBackendType.Sdl:
                        SdlMixerExtern.Mix_PlayMusic(musicPtr, -1);
                        break;
#endif
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                IsPlaying = true;
            }
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Stop()
        {
            if (!FullPathAudioFile.Equals(""))
            {
                switch (AudioBackendType)
                {
                    case AudioBackendType.Sfml:
#if AudioBackendSFML || AudioBackendAll
                        music ??= new Music(FullPathAudioFile);
                        music.Volume = Volume;
                        music.Stop();
                        break;
#endif
                    case AudioBackendType.Os:
                        player.Stop().Wait();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                IsPlaying = false;
            }
        }

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected void Resume()
        {
            if (!FullPathAudioFile.Equals(""))
            {
                switch (AudioBackendType)
                {
#if AudioBackendSFML || AudioBackendAll
                    case AudioBackendType.Sfml:
                        music ??= new Music(FullPathAudioFile);
                        music.Volume = Volume;
                        music.Play();
                        break;
#endif
                    case AudioBackendType.Os:
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