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

namespace Alis.Extension.Network.Sample.SimpleGame.Client
{
    /// <summary>
    ///     Game event
    /// </summary>
    public class GameEvent
    {
        /// <summary>
        ///     Initializes a new instance of the GameEvent class
        /// </summary>
        public GameEvent()
        {
            Timestamp = DateTime.UtcNow.Ticks;
            Data = new Dictionary<string, object>();
        }

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
        ///     Gets or sets the data
        /// </summary>
        public Dictionary<string, object> Data { get; set; }
    }
}