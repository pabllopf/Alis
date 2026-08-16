// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsWriteExceptionProbeTest.cs
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
using Alis.Extension.Network.Internal;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The events write exception probe test class
    /// </summary>
    public class EventsWriteExceptionProbeTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class ProbeListener : EventListener
        {
            /// <summary>
            ///     Handles the event source created using the specified event source
            /// </summary>
            /// <param name="eventSource">The event source</param>
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == "Ninja-WebSockets")
                {
                    EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                }
            }
        }

        /// <summary>
        ///     Tests that a write event does not throw when the source is enabled
        /// </summary>
        [Fact]
        public void WriteEvent_DoesNotThrow_WhenEnabled()
        {
            Events log = Events.Log;
            using ProbeListener listener = new ProbeListener();

            Exception thrown = null;
            try
            {
                log.ClientConnectingToIpAddress(Guid.NewGuid(), "127.0.0.1", 80);
            }
            catch (Exception ex)
            {
                thrown = ex;
            }

            Assert.Null(thrown);
        }
    }
}