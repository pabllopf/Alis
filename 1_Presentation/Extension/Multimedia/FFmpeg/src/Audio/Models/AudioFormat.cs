// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioFormat.cs
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



namespace Alis.Extension.Multimedia.FFmpeg.Audio.Models
{
    /// <summary>
    ///     The audio format class
    /// </summary>
    public class AudioFormat
    {
        /// <summary>
        ///     Gets or sets the value of the filename
        /// </summary>
        
        public string Filename { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb streams
        /// </summary>
        
        public long NbStreams { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb programs
        /// </summary>
        
        public long NbPrograms { get; set; }

        /// <summary>
        ///     Gets or sets the value of the format name
        /// </summary>
        
        public string FormatName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the format long name
        /// </summary>
        
        public string FormatLongName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start time
        /// </summary>
        
        public string StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        
        public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bit rate
        /// </summary>
        
        public string BitRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the probe score
        /// </summary>
        
        public long ProbeScore { get; set; }
    }
}