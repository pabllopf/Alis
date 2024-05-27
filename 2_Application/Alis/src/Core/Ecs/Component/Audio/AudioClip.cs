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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Audio;

namespace Alis.Core.Ecs.Component.Audio
{
    /// <summary>
    ///     The audio clip class
    /// </summary>
    /// <seealso />
    public class AudioClip
    {
        /// <summary>
        /// The player
        /// </summary>
        private readonly Player player = new Player();
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioClip" /> class
        /// </summary>
        public AudioClip()
        {
            NameFile = string.Empty;
            FullPathAudioFile = string.Empty;
            IsPlaying = false;
            IsMute = false;
            IsLooping = false;
            Volume = 100;
            Logger.Trace();
        }
        
        public AudioClip(string nameFile)
        {
            NameFile = nameFile;
            FullPathAudioFile = AssetManager.Find(nameFile);
            IsPlaying = false;
            IsMute = false;
            IsLooping = false;
            Volume = 100;
            Logger.Trace();
        }
        
        [JsonConstructor]
        public AudioClip(string nameFile, bool isPlaying, bool isMute, bool isLooping, float volume)
        {
            NameFile = nameFile;
            IsPlaying = isPlaying;
            IsMute = isMute;
            IsLooping = isLooping;
            Volume = volume;
            FullPathAudioFile = AssetManager.Find(nameFile);
            Logger.Trace();
        }
        
        /// <summary>
        /// Gets or sets the value of the is playing
        /// </summary>
        [JsonPropertyName("_IsPlaying_")]
        public bool IsPlaying { get;  set; }
        
        /// <summary>
        /// Gets or sets the value of the is mute
        /// </summary>
        [JsonPropertyName("_IsMute_")]
        public bool IsMute { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the is looping
        /// </summary>
        [JsonPropertyName("_IsLooping_")]
        public bool IsLooping { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the volume
        /// </summary>
        [JsonPropertyName("_Volume_")]
        public float Volume { get; set; }
        
        [JsonPropertyName("_NameFile_")]
        public string NameFile { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the full path audio file
        /// </summary>
        [JsonIgnore]
        private string FullPathAudioFile { get; set; }
        
        /// <summary>
        ///     Plays this instance
        /// </summary>
        internal void Play()
        {
            if (!string.IsNullOrEmpty(FullPathAudioFile))
            {
                _= player.Play(FullPathAudioFile); 
            }
        }
        
        /// <summary>
        ///     Stops this instance
        /// </summary>
        internal void Stop()
        {
            if (player.Playing)
            {
                _ = player.Stop();
            }
        }
        
        /// <summary>
        ///     Resumes this instance
        /// </summary>
        internal void Resume()
        {
            if (!player.Playing)
            {
                _ = player.Resume();
            }
        }
        
        /// <summary>
        ///     Builders
        /// </summary>
        /// <returns>The audio clip builder</returns>
        public static AudioClipBuilder Builder() => new AudioClipBuilder();
    }
}