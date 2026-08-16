// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsCountProbeTest.cs
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
using System.Diagnostics.Tracing;
using System.Threading;
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The events count probe test class
    /// </summary>
    public class EventsCountProbeTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class CountListener : EventListener
        {
            /// <summary>
            ///     The event count
            /// </summary>
            public int EventCount;

            /// <summary>
            ///     Handles the event source created using the specified event source
            /// </summary>
            /// <param name="eventSource">The event source</param>
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
            }

            /// <summary>
            ///     Handles the event written using the specified event data
            /// </summary>
            /// <param name="eventData">The event data</param>
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                Interlocked.Increment(ref EventCount);
            }
        }

        /// <summary>
        ///     Tests that the websocket event is captured by id
        /// </summary>
        [Fact]
        public void WebSocketEvent_IsCaptured_WithCorrectId()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();

            log.ClientConnectingToIpAddress(Guid.NewGuid(), "10.1.2.3", 8080);

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that multiple websocket events are captured
        /// </summary>
        [Fact]
        public void MultipleWebSocketEvents_AreCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();

            log.ClientConnectingToIpAddress(Guid.NewGuid(), "10.1.2.3", 8080);
            log.ClientConnectingToHost(Guid.NewGuid(), "host.local", 8080);
            log.CloseHandshakeComplete(Guid.NewGuid());

            Assert.Equal(3, listener.EventCount);
        }
    }
}