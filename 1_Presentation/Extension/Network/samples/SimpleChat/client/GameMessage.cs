// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameMessage.cs
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
    ///     Simple message type for testing
    /// </summary>
    public class GameMessage : IJsonSerializable
    {
        /// <summary>
        ///     Gets or sets the value of the message type
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(MessageType), MessageType);
            yield return (nameof(Content), Content);
        }
    }
}