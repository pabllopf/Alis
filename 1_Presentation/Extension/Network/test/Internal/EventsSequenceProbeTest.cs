// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsSequenceProbeTest.cs
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
using System.Diagnostics.Tracing;
using System.Net.Security;
using System.Net.WebSockets;
using System.Threading;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The events sequence probe test class
    /// </summary>
    public class EventsSequenceProbeTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class SeqListener : EventListener
        {
            /// <summary>
            ///     The event ids
            /// </summary>
            public List<int> EventIds = new List<int>();

            /// <summary>
            ///     Handles the event written using the specified event data
            /// </summary>
            /// <param name="eventData">The event data</param>
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                lock (EventIds)
                {
                    EventIds.Add(eventData.EventId);
                }
            }
        }

        /// <summary>
        ///     Tests that a sequence of three simple events is captured in order
        /// </summary>
        [Fact]
        public void ThreeSimpleEvents_AreCapturedInOrder()
        {
            Events log = Events.Log;
            using SeqListener listener = new SeqListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            Guid guid = Guid.NewGuid();
            log.ClientConnectingToIpAddress(guid, "10.1.2.3", 8080);
            log.ClientConnectingToHost(guid, "host.local", 8080);
            log.CloseHandshakeComplete(guid);

            Assert.Equal(new List<int> {1, 2, 33}, listener.EventIds);
        }
    }
}