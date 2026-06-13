// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BeforeCollisionEventHandlerTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The before collision event handler test class
    /// </summary>
    public class BeforeCollisionEventHandlerTest
    {
        /// <summary>
        /// Tests that delegate should return expected value
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnExpectedValue()
        {
            BeforeCollisionEventHandler callback = (sender, other) => (sender == null) && (other == null);

            bool result = callback(null, null);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that chaining multiple handlers should call all
        /// </summary>
        [Fact]
        public void Chaining_ShouldCallAllHandlers()
        {
            int callCount = 0;
            BeforeCollisionEventHandler first = (s, o) => { callCount++; return true; };
            BeforeCollisionEventHandler second = (s, o) => { callCount++; return false; };

            BeforeCollisionEventHandler chain = first + second;
            bool result = chain(null, null);

            Assert.Equal(2, callCount);
            Assert.False(result);
        }
    }
}
