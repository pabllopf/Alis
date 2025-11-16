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

using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Audio;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio clip
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSource(Context context, string nameFile = "", float volume = 100, bool isMute = false, bool playOnAwake = false, bool loop = false) : 
        IAudioSource
    {
        /// <summary>
        ///     The loop
        /// </summary>
        private readonly bool loop = loop;

        /// <summary>
        ///     The player
        /// </summary>
        private readonly Player player = new Player();

        /// <summary>
        ///     Gets or sets the value of the is playing
        /// </summary>
        public bool IsPlaying => player.Playing;

        /// <summary>
        ///     Gets or sets the value of the play on awake
        /// </summary>
        public bool PlayOnAwake { get; set; } = playOnAwake;

        /// <summary>
        ///     Gets or sets the value of the is mute
        /// </summary>
        public bool IsMute { get; set; } = isMute;

        /// <summary>
        ///     Gets or sets the value of the is looping
        /// </summary>
        public bool IsLooping { get; set; } = loop;

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public float Volume { get; set; } = volume;

        /// <summary>
        ///     Gets or sets the value of the name file
        /// </summary>
        public string NameFile { get; set; } = nameFile;

        /// <summary>
        ///     Gets or sets the value of the full path audio file
        /// </summary>
        private string FullPathAudioFile { get; set; } = "";

        /// <summary>
        ///     Plays this instance
        /// </summary>
        public void Play()
        {
            if (string.IsNullOrEmpty(FullPathAudioFile) && !string.IsNullOrEmpty(NameFile))
            {
                FullPathAudioFile = "";
            }

            if (!IsLooping)
            {
                _ = player.Play(string.IsNullOrEmpty(FullPathAudioFile) ? NameFile : FullPathAudioFile);
            }
            else
            {
                _ = player.PlayLoop(string.IsNullOrEmpty(FullPathAudioFile) ? NameFile : FullPathAudioFile, true);
            }
           
        }

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop()
        {
            if (player.Playing)
            {
                _ = player.Stop();
            }
        }

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        public void Resume()
        {
            if (!player.Playing)
            {
                _ = player.Resume();
            }
        }

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            ThreadPool.SetMinThreads(200, 200);
            if (PlayOnAwake)
            {
                Play();
            }
        }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; } = context;
        
        /// <summary>
        /// Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            Stop();
        }
    }
}