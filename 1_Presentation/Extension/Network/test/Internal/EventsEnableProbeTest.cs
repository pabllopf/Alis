// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsEnableProbeTest.cs
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
    ///     The events enable probe test class
    /// </summary>
    public class EventsEnableProbeTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class ProbeListener : EventListener
        {
            /// <summary>
            ///     Gets a value indicating whether the log source is enabled
            /// </summary>
            public bool LogEnabled;

            /// <summary>
            ///     Initializes a new instance of the <see cref="ProbeListener" /> class
            /// </summary>
            public ProbeListener()
            {
                EnableEvents(Events.Log, EventLevel.Verbose, EventKeywords.All);
                LogEnabled = Events.Log.IsEnabled();
            }
        }

        /// <summary>
        ///     Tests that the log source becomes enabled when the listener enables it directly
        /// </summary>
        [Fact]
        public void LogSource_BecomesEnabled_WhenEnabledDirectly()
        {
            using ProbeListener listener = new ProbeListener();

            Assert.True(listener.LogEnabled);
        }

        /// <summary>
        ///     Tests that the log source is enabled after construction
        /// </summary>
        [Fact]
        public void LogSource_IsEnabled_AfterListenerConstruction()
        {
            using ProbeListener listener = new ProbeListener();

            Assert.True(Events.Log.IsEnabled());
        }
    }
}