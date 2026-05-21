// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoAudioPlaybackExample.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Extension.Media.FFmpeg.Audio;

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Reproduccion de video en la ventana OpenGL junto al audio del mismo asset.
    /// </summary>
    internal class VideoAudioPlaybackExample : VideoExampleBase
    {
        /// <summary>
        /// The audio player
        /// </summary>
        private AudioPlayer audioPlayer;

        /// <summary>
        /// Gets the value of the loop video
        /// </summary>
        protected override bool LoopVideo => false;

        /// <summary>
        /// Called after the video reader and GL resources are initialized
        /// </summary>
        protected override void OnInitialize()
        {
            try
            {
                audioPlayer = new AudioPlayer(VideoPath);
                audioPlayer.PlayInBackground("-autoexit -vn");
            }
            catch (Exception ex)
            {
                Logger.Info($"No se pudo iniciar el audio para '{VideoAssetName}': {ex.Message}");
            }
        }

        /// <summary>
        /// Called during cleanup before releasing base resources
        /// </summary>
        protected override void OnCleanup()
        {
            audioPlayer?.Dispose();
            audioPlayer = null;
        }
    }
}

