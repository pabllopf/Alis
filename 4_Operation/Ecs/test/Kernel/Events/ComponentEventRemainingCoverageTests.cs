// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentEventRemainingCoverageTests.cs
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

using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     The component event remaining coverage tests class
    /// </summary>
    public class ComponentEventRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default constructor has listeners returns false
        /// </summary>
        [Fact]
        public void DefaultConstructor_HasListeners_ReturnsFalse()
        {
            ComponentEvent componentEvent = new ComponentEvent();

            Assert.False(componentEvent.HasListeners);
        }

        /// <summary>
        ///     Tests that default constructor generic event is null
        /// </summary>
        [Fact]
        public void DefaultConstructor_GenericEvent_IsNull()
        {
            ComponentEvent componentEvent = new ComponentEvent();

            Assert.Null(componentEvent.GenericEvent);
        }

        /// <summary>
        ///     Tests that default constructor normal event is initialized
        /// </summary>
        [Fact]
        public void DefaultConstructor_NormalEvent_IsInitialized()
        {
            ComponentEvent componentEvent = new ComponentEvent();

            Assert.False(componentEvent.HasListeners);
        }

        /// <summary>
        ///     Tests that has listeners covers generic event non null branch
        /// </summary>
        [Fact]
        public void HasListeners_GenericEventNotNull_CoversNonNullBranch()
        {
            ComponentEvent componentEvent = new ComponentEvent();
            componentEvent.GenericEvent = new GenericEvent();

            Assert.False(componentEvent.HasListeners);
        }
    }
}