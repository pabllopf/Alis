// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsIsEnabledDiagnosticTest.cs
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

using System.Diagnostics.Tracing;
using Xunit;

namespace Alis.Extension.Network.Test.Internal
{
    /// <summary>
    ///     The events is enabled diagnostic test class
    /// </summary>
    public class EventsIsEnabledDiagnosticTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class DiagnosticListener : EventListener
        {
            /// <summary>
            ///     Gets a value indicating whether the source is enabled
            /// </summary>
            public bool SourceEnabled;

            /// <summary>
            ///     Gets a value indicating whether log source is enabled
            /// </summary>
            public bool LogSourceEnabled;

            /// <summary>
            ///     Handles the event source created using the specified event source
            /// </summary>
            /// <param name="eventSource">The event source</param>
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                SourceEnabled = eventSource.IsEnabled();
                if (eventSource.Name == "Ninja-WebSockets")
                {
                    LogSourceEnabled = eventSource.IsEnabled();
                }
            }
        }

        /// <summary>
        ///     Tests that the event source is enabled after listener creation
        /// </summary>
        [Fact]
        public void EventSource_IsEnabled_AfterListenerCreation()
        {
            using DiagnosticListener listener = new DiagnosticListener();

            Assert.True(listener.SourceEnabled);
        }

        /// <summary>
        ///     Tests that the websocket event source is enabled after listener creation
        /// </summary>
        [Fact]
        public void WebSocketEventSource_IsEnabled_AfterListenerCreation()
        {
            using DiagnosticListener listener = new DiagnosticListener();

            Assert.True(listener.LogSourceEnabled);
        }
    }
}