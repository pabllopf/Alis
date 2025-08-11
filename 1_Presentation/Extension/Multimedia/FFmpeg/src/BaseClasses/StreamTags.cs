// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StreamTags.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Multimedia.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The stream tags class
    /// </summary>
    [Serializable]
    public partial class StreamTags
    {
        public StreamTags() : this(string.Empty, string.Empty, string.Empty)
        {
        }
        
        public StreamTags(string creationTime, string language, string handlerName)
        {
            CreationTime = creationTime;
            Language = language;
            HandlerName = handlerName;
        }
        
        /// <summary>
        ///     Gets or sets the value of the creation time
        /// </summary>
        [JsonNativePropertyName("creation_time")]
        public string CreationTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the language
        /// </summary>
        [JsonNativePropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the value of the handler name
        /// </summary>
        [JsonNativePropertyName("handler_name")]
        public string HandlerName { get; set; }
    }
}