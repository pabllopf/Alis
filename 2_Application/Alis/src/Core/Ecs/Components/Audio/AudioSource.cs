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

using System.Threading;
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Ecs.Components.Audio
{
    public struct AudioSource(AudioClip audioClip) : IAudioSource, IInitable, IEntityComponent
    {
        public AudioClip AudioClip { get; set; } = audioClip;
        
        /// <summary>
        ///     Gets the value of the is playing
        /// </summary>
        public bool IsPlaying => AudioClip.IsPlaying;
        
        /// <summary>
        ///     Gets or sets the value of the mute
        /// </summary>
        public bool Mute
        {
            get => AudioClip.IsMute;
            set => AudioClip = AudioClip with {IsMute = value};
        }

        /// <summary>
        ///     Gets or sets the value of the loop
        /// </summary>
        public bool Loop
        {
            get => AudioClip.IsLooping;
            set => AudioClip = AudioClip with {IsLooping = value};
        }

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public float Volume
        {
            get => AudioClip.Volume;
            set => AudioClip = AudioClip with {Volume = value};
        }
        
        /// <summary>
        ///     Plays this instance
        /// </summary>
        public void Play() => AudioClip.Play();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        public void Stop() => AudioClip.Stop();

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        public void Resume() => AudioClip.Resume();
        
        public void Init(IGameObject self)
        {
            ThreadPool.SetMinThreads(200, 200);
            if (AudioClip.PlayOnAwake)
            {
                Play();
            }
        }

        public void Update(IGameObject self)
        {
            if (AudioClip.IsLooping && !IsPlaying)
            {
                Play();
            }
        }
    }
}