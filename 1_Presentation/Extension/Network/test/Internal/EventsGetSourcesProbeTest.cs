// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsGetSourcesProbeTest.cs
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
    ///     The events get sources probe test class
    /// </summary>
    public class EventsGetSourcesProbeTest
    {
        /// <summary>
        ///     Tests that the log source is registered with the event source infra structure
        /// </summary>
        [Fact]
        public void LogSource_IsRegistered_WithEventSourceInfrastructure()
        {
            Events log = Events.Log;
            System.Collections.Generic.IEnumerable<EventSource> sources = EventSource.GetSources();

            Assert.Contains(sources, source => source.Name == "Ninja-WebSockets");
        }

        /// <summary>
        ///     Tests that the log source instance matches the singleton
        /// </summary>
        [Fact]
        public void LogSource_Singleton_MatchesGetSources()
        {
            Events log = Events.Log;
            System.Collections.Generic.IEnumerable<EventSource> sources = EventSource.GetSources();

            foreach (EventSource source in sources)
            {
                if (source.Name == "Ninja-WebSockets")
                {
                    Assert.Same(Events.Log, source);
                    return;
                }
            }

            Assert.Fail("Ninja-WebSockets source not found");
        }
    }
}