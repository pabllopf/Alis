// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlTimeRemainingCoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    /// The sfml time remaining coverage tests class
    /// </summary>
    public class SfmlTimeRemainingCoverageTests
    {
        /// <summary>
        /// Creates the milliseconds returns correct value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FromMilliseconds_ReturnsCorrectValue()
        {
            SfmlTime time = SfmlTime.FromMilliseconds(500);
            long microseconds = time.AsMicroseconds();
            Assert.Equal(500_000L, microseconds);
        }

        /// <summary>
        /// Converts the milliseconds returns correct value
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void AsMilliseconds_ReturnsCorrectValue()
        {
            SfmlTime time = SfmlTime.FromSeconds(1.5f);
            int ms = time.AsMilliseconds();
            Assert.Equal(1500, ms);
        }

        /// <summary>
        /// Tests that equals boxed object returns true
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_BoxedObject_ReturnsTrue()
        {
            SfmlTime t = default;
            object obj = t;
            Assert.True(t.Equals(obj));
        }

        /// <summary>
        /// Tests that equals non sfml time object returns false
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_NonSfmlTimeObject_ReturnsFalse()
        {
            SfmlTime t = default;
            Assert.False(t.Equals(42));
            Assert.False(t.Equals("hello"));
        }

        /// <summary>
        /// Tests that equals null object returns false
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Equals_NullObject_ReturnsFalse()
        {
            SfmlTime t = default;
            Assert.False(t.Equals(null));
        }

        /// <summary>
        /// Creates the milliseconds zero returns zero
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FromMilliseconds_Zero_ReturnsZero()
        {
            SfmlTime time = SfmlTime.FromMilliseconds(0);
            Assert.Equal(default, time);
            Assert.Equal(0L, time.AsMicroseconds());
        }

        /// <summary>
        /// Creates the milliseconds negative returns negative
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void FromMilliseconds_Negative_ReturnsNegative()
        {
            SfmlTime time = SfmlTime.FromMilliseconds(-100);
            Assert.Equal(-100_000L, time.AsMicroseconds());
        }

        /// <summary>
        /// Converts the milliseconds round trip consistent
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void AsMilliseconds_RoundTrip_Consistent()
        {
            SfmlTime original = SfmlTime.FromMilliseconds(2500);
            SfmlTime roundTrip = SfmlTime.FromMilliseconds(original.AsMilliseconds());
            Assert.Equal(original.AsMicroseconds(), roundTrip.AsMicroseconds());
        }

        /// <summary>
        /// Tests that equals object returns true for boxed same value
        /// </summary>
        [Fact]
        public void Equals_BoxedSameValue_ReturnsTrue()
        {
            SfmlTime time = default;
            object obj = time;
            Assert.True(time.Equals(obj));
        }

        /// <summary>
        /// Tests that equals object returns false for other type
        /// </summary>
        [Fact]
        public void Equals_OtherType_ReturnsFalse()
        {
            SfmlTime time = default;
            Assert.False(time.Equals(42));
            Assert.False(time.Equals("hello"));
            Assert.False(time.Equals(null));
        }

        /// <summary>
        /// Tests that typed equals returns true for equal microseconds
        /// </summary>
        [Fact]
        public void Equals_TypedSameValue_ReturnsTrue()
        {
            SfmlTime first = default;
            SfmlTime second = default;
            Assert.True(first.Equals(second));
        }

        /// <summary>
        /// Tests that equality operators return true for equal values
        /// </summary>
        [Fact]
        public void EqualityOperators_EqualValues_ReturnTrue()
        {
            SfmlTime first = default;
            SfmlTime second = default;
            Assert.True(first == second);
            Assert.False(first != second);
        }

        /// <summary>
        /// Tests that get hash code is stable for equal values
        /// </summary>
        [Fact]
        public void GetHashCode_IsStableForEqualValues()
        {
            SfmlTime first = default;
            SfmlTime second = default;
            Assert.Equal(first.GetHashCode(), second.GetHashCode());
        }
    }
}
