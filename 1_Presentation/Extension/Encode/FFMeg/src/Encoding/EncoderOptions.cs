// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EncoderOptions.cs
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

namespace Alis.Extension.Encode.FFMeg.Encoding
{
    /// <summary>
    ///     FFmpeg video encoding options to pass to FFmpeg when encoding. Check the online FFmpeg documentation for more info.
    /// </summary>
    public class EncoderOptions
    {
        /// <summary>
        ///     Container format. (example: 'mp4', 'flv', 'webm', 'mp3', 'ogg')
        /// </summary>
        public string Format { get; set; }
        
        /// <summary>
        ///     Encoder name. (example: 'libx264', 'libx265', 'libvpx', 'libopus', 'libvorbis', 'h264_nvenc')
        /// </summary>
        public string EncoderName { get; set; }
        
        /// <summary>
        ///     Arguments for the encoder. This depends on the used encoder.
        /// </summary>
        public string EncoderArguments { get; set; }
    }
}