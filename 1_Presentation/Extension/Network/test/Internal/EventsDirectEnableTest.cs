// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsDirectEnableTest.cs
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
    ///     The events direct enable test class
    /// </summary>
    public class EventsDirectEnableTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class CaptureListener : EventListener
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
                if (eventSource == Events.Log)
                {
                    EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                }
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
        ///     Tests that a single event write is captured when the source is enabled
        /// </summary>
        [Fact]
        public void SingleEventWrite_IsCaptured_WhenEnabled()
        {
            using CaptureListener listener = new CaptureListener();
            int before = listener.EventCount;

            Events.Log.ClientConnectingToIpAddress(Guid.NewGuid(), "127.0.0.1", 80);

            Assert.Equal(1, listener.EventCount - before);
        }
    }
}