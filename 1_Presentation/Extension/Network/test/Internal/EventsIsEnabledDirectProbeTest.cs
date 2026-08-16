// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventsIsEnabledDirectProbeTest.cs
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
    ///     The events is enabled direct probe test class
    /// </summary>
    public class EventsIsEnabledDirectProbeTest
    {
        /// <summary>
        ///     The listener class
        /// </summary>
        private sealed class EmptyListener : EventListener
        {
        }

        /// <summary>
        ///     Tests that the source reports enabled after enabling
        /// </summary>
        [Fact]
        public void Source_ReportsEnabled_AfterEnabling()
        {
            Events log = Events.Log;
            using EmptyListener listener = new EmptyListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            Assert.True(log.IsEnabled());
        }

        /// <summary>
        ///     Tests that the source reports enabled after a direct enable on the instance
        /// </summary>
        [Fact]
        public void Source_ReportsEnabled_AfterDirectEnable()
        {
            Events log = Events.Log;
            using EmptyListener listener = new EmptyListener();
            listener.EnableEvents(log, EventLevel.Verbose, EventKeywords.All);

            Assert.True(Events.Log.IsEnabled());
        }
    }
}