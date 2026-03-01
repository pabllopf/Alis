// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:OrientationTest.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    ///     The orientation test class
    /// </summary>
    public class OrientationTest
    {
        /// <summary>
        ///     Tests that cw enum value should be defined
        /// </summary>
        [Fact]
        public void CwEnumValue_ShouldBeDefined()
        {
            Orientation orientation = Orientation.Cw;
            
            Assert.Equal(Orientation.Cw, orientation);
        }

        /// <summary>
        ///     Tests that ccw enum value should be defined
        /// </summary>
        [Fact]
        public void CcwEnumValue_ShouldBeDefined()
        {
            Orientation orientation = Orientation.Ccw;
            
            Assert.Equal(Orientation.Ccw, orientation);
        }

        /// <summary>
        ///     Tests that collinear enum value should be defined
        /// </summary>
        [Fact]
        public void CollinearEnumValue_ShouldBeDefined()
        {
            Orientation orientation = Orientation.Collinear;
            
            Assert.Equal(Orientation.Collinear, orientation);
        }

        /// <summary>
        ///     Tests that orientation should have three values
        /// </summary>
        [Fact]
        public void Orientation_ShouldHaveThreeValues()
        {
            var values = System.Enum.GetValues(typeof(Orientation));
            
            Assert.Equal(3, values.Length);
        }

        /// <summary>
        ///     Tests that orientation should be castable to int
        /// </summary>
        [Fact]
        public void Orientation_ShouldBeCastableToInt()
        {
            int cwValue = (int)Orientation.Cw;
            int ccwValue = (int)Orientation.Ccw;
            int collinearValue = (int)Orientation.Collinear;
            
            Assert.Equal(0, cwValue);
            Assert.Equal(1, ccwValue);
            Assert.Equal(2, collinearValue);
        }

        /// <summary>
        ///     Tests that orientation should support equality comparison
        /// </summary>
        [Fact]
        public void Orientation_ShouldSupportEqualityComparison()
        {
            Orientation orientation1 = Orientation.Ccw;
            Orientation orientation2 = Orientation.Ccw;
            
            Assert.Equal(orientation1, orientation2);
        }

        /// <summary>
        ///     Tests that orientation should support inequality comparison
        /// </summary>
        [Fact]
        public void Orientation_ShouldSupportInequalityComparison()
        {
            Orientation orientation1 = Orientation.Cw;
            Orientation orientation2 = Orientation.Collinear;
            
            Assert.NotEqual(orientation1, orientation2);
        }

        /// <summary>
        ///     Tests that orientation should support switch statement
        /// </summary>
        [Fact]
        public void Orientation_ShouldSupportSwitchStatement()
        {
            Orientation orientation = Orientation.Ccw;
            string result = orientation switch
            {
                Orientation.Cw => "Clockwise",
                Orientation.Ccw => "CounterClockwise",
                Orientation.Collinear => "Collinear",
                _ => "Unknown"
            };
            
            Assert.Equal("CounterClockwise", result);
        }
    }
}

