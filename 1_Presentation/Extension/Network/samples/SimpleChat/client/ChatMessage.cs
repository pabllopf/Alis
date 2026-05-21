// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChatMessage.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.SimpleChat.Client
{
    /// <summary>
    ///     Chat message structure (shared with server)
    /// </summary>
    public class ChatMessage : IJsonSerializable
    {
        /// <summary>
        ///     Gets or sets sender name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        ///     Gets or sets message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Gets or sets timestamp
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        ///     Gets serializable properties
        /// </summary>
        public IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(SenderName), SenderName);
            yield return (nameof(Content), Content);
            yield return (nameof(Timestamp), Timestamp);
        }
    }
}