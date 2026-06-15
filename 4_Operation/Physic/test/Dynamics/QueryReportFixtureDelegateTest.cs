// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryReportFixtureDelegateTest.cs
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

using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The query report fixture delegate test class
    /// </summary>
    public class QueryReportFixtureDelegateTest
    {
        /// <summary>
        /// Tests that delegate should return callback value
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnCallbackValue()
        {
            Fixture capturedFixture = null;
            QueryReportFixtureDelegate callback = fixture =>
            {
                capturedFixture = fixture;
                return fixture != null;
            };

            bool result = callback(null);

            Assert.False(result);
            Assert.Null(capturedFixture);
        }

        /// <summary>
        ///     Tests that chaining multiple handlers should call all
        /// </summary>
        [Fact]
        public void Chaining_ShouldCallAllHandlers()
        {
            int callCount = 0;
            QueryReportFixtureDelegate first = fixture => { callCount++; return true; };
            QueryReportFixtureDelegate second = fixture => { callCount++; return false; };

            QueryReportFixtureDelegate chain = first + second;
            bool result = chain(null);

            Assert.Equal(2, callCount);
            Assert.False(result);
        }
    }
}
