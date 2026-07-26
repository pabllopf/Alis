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
    public class SfmlTimeRemainingCoverageTests
    {
        [RequireCSfmlWindowsFact]
        public void FromMilliseconds_ReturnsCorrectValue()
        {
            SfmlTime time = SfmlTime.FromMilliseconds(500);
            long microseconds = time.AsMicroseconds();
            Assert.Equal(500_000L, microseconds);
        }

        [RequireCSfmlWindowsFact]
        public void AsMilliseconds_ReturnsCorrectValue()
        {
            SfmlTime time = SfmlTime.FromSeconds(1.5f);
            int ms = time.AsMilliseconds();
            Assert.Equal(1500, ms);
        }

        [Fact]
        public void Equals_BoxedObject_ReturnsTrue()
        {
            SfmlTime t = default;
            object obj = t;
            Assert.True(t.Equals(obj));
        }

        [Fact]
        public void Equals_NonSfmlTimeObject_ReturnsFalse()
        {
            SfmlTime t = default;
            Assert.False(t.Equals(42));
            Assert.False(t.Equals("hello"));
        }

        [Fact]
        public void Equals_NullObject_ReturnsFalse()
        {
            SfmlTime t = default;
            Assert.False(t.Equals(null));
        }

        [RequireCSfmlWindowsFact]
        public void FromMilliseconds_Zero_ReturnsZero()
        {
            SfmlTime time = SfmlTime.FromMilliseconds(0);
            Assert.Equal(default, time);
            Assert.Equal(0L, time.AsMicroseconds());
        }

        [RequireCSfmlWindowsFact]
        public void FromMilliseconds_Negative_ReturnsNegative()
        {
            SfmlTime time = SfmlTime.FromMilliseconds(-100);
            Assert.Equal(-100_000L, time.AsMicroseconds());
        }

        [RequireCSfmlWindowsFact]
        public void AsMilliseconds_RoundTrip_Consistent()
        {
            SfmlTime original = SfmlTime.FromMilliseconds(2500);
            SfmlTime roundTrip = SfmlTime.FromMilliseconds(original.AsMilliseconds());
            Assert.Equal(original.AsMicroseconds(), roundTrip.AsMicroseconds());
        }
    }
}
