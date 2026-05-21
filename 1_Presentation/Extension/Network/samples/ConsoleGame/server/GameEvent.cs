// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameEvent.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.ConsoleGame.Server
{
    /// <summary>
    ///     Game event
    /// </summary>
    public class GameEvent : IJsonSerializable
    {
        /// <summary>
        ///     Initializes a new instance of the GameEvent class
        /// </summary>
        public GameEvent() => Timestamp = DateTime.UtcNow.Ticks;

        /// <summary>
        ///     Gets or sets the timestamp
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        ///     Gets or sets the event type
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        ///     Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the source player
        /// </summary>
        public string SourcePlayer { get; set; }

        /// <summary>
        ///     Gets or sets the target player
        /// </summary>
        public string TargetPlayer { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(Timestamp), Timestamp.ToString());
            yield return (nameof(EventType), EventType ?? "");
            yield return (nameof(Description), Description ?? "");
            yield return (nameof(SourcePlayer), SourcePlayer ?? "");
            yield return (nameof(TargetPlayer), TargetPlayer ?? "");
        }
    }
}