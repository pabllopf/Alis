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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;

namespace Alis.Benchmark.CustomEcs.EcsOld.Component.Audio
{
    /// <summary>
    ///     The audio source class
    /// </summary>
    public class AudioSource : AComponent, IHasBuilder<AudioSourceBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSource" /> class
        /// </summary>
        /// <param name="audioClip">The audio clip</param>
        public AudioSource(AudioClip audioClip)
        {
            AudioClip = audioClip;
            Logger.Trace();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSource" /> class
        /// </summary>
        public AudioSource()
        {
            AudioClip = new AudioClip();
            Logger.Trace();
        }

        /// <summary>
        ///     Gets or sets the value of the audio clip
        /// </summary>
        public AudioClip AudioClip { get; set; }

        /// <summary>
        ///     Gets the value of the is playing
        /// </summary>
        public bool IsPlaying => AudioClip.IsPlaying;

        /// <summary>
        ///     Gets or sets the value of the play on awake
        /// </summary>
        public bool PlayOnAwake { get; set; }

        /// <summary>
        ///     Gets or sets the value of the mute
        /// </summary>
        public bool Mute
        {
            get => AudioClip.IsMute;
            set => AudioClip.IsMute = value;
        }

        /// <summary>
        ///     Gets or sets the value of the loop
        /// </summary>
        public bool Loop
        {
            get => AudioClip.IsLooping;
            set => AudioClip.IsLooping = value;
        }

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public float Volume
        {
            get => AudioClip.Volume;
            set => AudioClip.Volume = value;
        }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The audio source builder</returns>
        public AudioSourceBuilder Builder() => new AudioSourceBuilder();

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

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            ThreadPool.SetMinThreads(200, 200);
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void OnStart()
        {
            if (PlayOnAwake)
            {
                Play();
            }
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (AudioClip.IsLooping && !IsPlaying)
            {
                Play();
            }
        }


        /// <summary>
        ///     Ons the stop
        /// </summary>
        public override void OnStop()
        {
            Stop();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Stop();
        }
    }
}