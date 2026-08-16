// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsFreshSourceProbeTest.cs
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
    ///     The events fresh source probe test class
    /// </summary>
    public class EventsFreshSourceProbeTest
    {
        /// <summary>
        ///     The fresh source class
        /// </summary>
        [EventSource(Name = "Fresh-Probe-Source")]
        private sealed class FreshSource : EventSource
        {
            /// <summary>
            ///     Logs the test using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            [Event(1, Level = EventLevel.Informational)]
            public void LogTest(string value)
            {
                if (IsEnabled())
                {
                    WriteEvent(1, value);
                }
            }
        }

        /// <summary>
        ///     Tests that a fresh event source is enabled after enabling
        /// </summary>
        [Fact]
        public void FreshSource_IsEnabled_AfterEnabling()
        {
            FreshSource source = new FreshSource();
            using FreshListener listener = new FreshListener(source);

            Assert.True(source.IsEnabled());
        }

        /// <summary>
        ///     Tests that a fresh event source is enabled when enabling after construction
        /// </summary>
        [Fact]
        public void FreshSource_IsEnabled_WhenEnabledAfterConstruction()
        {
            FreshSource source = new FreshSource();
            using FreshListener listener = new FreshListener();
            listener.EnableEvents(source, EventLevel.Verbose, EventKeywords.All);

            Assert.True(source.IsEnabled());
        }

        /// <summary>
        ///     Tests that a fresh event source writes events when enabled after construction
        /// </summary>
        [Fact]
        public void FreshSource_WritesEvent_WhenEnabledAfterConstruction()
        {
            FreshSource source = new FreshSource();
            using CaptureListener listener = new CaptureListener();
            listener.EnableEvents(source, EventLevel.Verbose, EventKeywords.All);

            source.LogTest("hello");

            Assert.Equal(1, listener.EventCount);
        }

        /// <summary>
        ///     The fresh listener class
        /// </summary>
        private sealed class FreshListener : EventListener
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="FreshListener" /> class
            /// </summary>
            public FreshListener()
            {
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="FreshListener" /> class
            /// </summary>
            /// <param name="source">The source</param>
            public FreshListener(FreshSource source)
            {
                EnableEvents(source, EventLevel.Verbose, EventKeywords.All);
            }
        }

        /// <summary>
        ///     The capture listener class
        /// </summary>
        private sealed class CaptureListener : EventListener
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
                EventCount++;
            }
        }
    }
}