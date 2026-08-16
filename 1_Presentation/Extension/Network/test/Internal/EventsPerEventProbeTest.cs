// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsPerEventProbeTest.cs
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
    ///     The events per event probe test class
    /// </summary>
    public class EventsPerEventProbeTest
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
            ///     Handles the event written using the specified event data
            /// </summary>
            /// <param name="eventData">The event data</param>
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                Interlocked.Increment(ref EventCount);
            }
        }

        /// <summary>
        ///     Tests that the close output auto timeout event is captured
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeout_IsCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            log.CloseOutputAutoTimeout(Guid.NewGuid(), WebSocketCloseStatus.EndpointUnavailable, "shutdown", "timeout");

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that the sending frame event is captured
        /// </summary>
        [Fact]
        public void SendingFrame_IsCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            log.SendingFrame(Guid.NewGuid(), WebSocketOpCode.TextFrame, true, 16, false);

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that the close frame received in unexpected state event is captured
        /// </summary>
        [Fact]
        public void CloseFrameReceivedInUnexpectedState_IsCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            log.CloseFrameReceivedInUnexpectedState(Guid.NewGuid(), WebSocketState.CloseReceived,
                WebSocketCloseStatus.NormalClosure, "bye");

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that the handshake sent event is captured
        /// </summary>
        [Fact]
        public void HandshakeSent_IsCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            log.HandshakeSent(Guid.NewGuid(), "GET / HTTP/1.1");

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that the close output auto timeout error event is captured
        /// </summary>
        [Fact]
        public void CloseOutputAutoTimeoutError_IsCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            log.CloseOutputAutoTimeoutError(Guid.NewGuid(), "write failed",
                WebSocketCloseStatus.InternalServerError, "shutdown", "error");

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     Tests that the received frame event is captured
        /// </summary>
        [Fact]
        public void ReceivedFrame_IsCaptured()
        {
            Events log = Events.Log;
            using CountListener listener = new CountListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            log.ReceivedFrame(Guid.NewGuid(), WebSocketOpCode.BinaryFrame, false, 32);

            Assert.Equal(1, listener.EventCount);
        }
    }
}