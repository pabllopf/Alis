// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTypeRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="GameObjectType" />.
    /// </summary>
    public class GameObjectTypeRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the internal constructor sets RawIndex to the given non-zero value.
        /// </summary>
        [Fact]
        public void InternalConstructor_SetsRawIndex()
        {
            GameObjectType t = new GameObjectType((ushort)42);

            Assert.Equal((ushort)42, t.RawIndex);
        }

        /// <summary>
        ///     Verifies that the internal constructor sets RawIndex to zero when given zero.
        /// </summary>
        [Fact]
        public void InternalConstructor_DefaultValue_SetsZero()
        {
            GameObjectType t = new GameObjectType((ushort)0);

            Assert.Equal((ushort)0, t.RawIndex);
        }

        /// <summary>
        ///     Verifies that Equals returns true for instances with the same RawIndex.
        /// </summary>
        [Fact]
        public void Equals_SameRawIndex_ReturnsTrue()
        {
            GameObjectType a = new GameObjectType((ushort)5);
            GameObjectType b = new GameObjectType((ushort)5);

            Assert.True(a.Equals(b));
        }

        /// <summary>
        ///     Verifies that Equals returns false for instances with different RawIndex values.
        /// </summary>
        [Fact]
        public void Equals_DifferentRawIndex_ReturnsFalse()
        {
            GameObjectType a = new GameObjectType((ushort)1);
            GameObjectType b = new GameObjectType((ushort)2);

            Assert.False(a.Equals(b));
        }

        /// <summary>
        ///     Verifies that Equals(object) returns true when given a boxed instance with the same value.
        /// </summary>
        [Fact]
        public void Equals_Object_SameType_ReturnsTrue()
        {
            GameObjectType t = new GameObjectType((ushort)5);
            object t2 = new GameObjectType((ushort)5);

            Assert.True(t.Equals(t2));
        }

        /// <summary>
        ///     Verifies that Equals(object) returns false when given a non-GameObjectType object.
        /// </summary>
        [Fact]
        public void Equals_Object_DifferentType_ReturnsFalse()
        {
            GameObjectType t = new GameObjectType((ushort)5);

            Assert.False(t.Equals("string"));
        }

        /// <summary>
        ///     Verifies that GetHashCode returns the RawIndex value.
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsRawIndex()
        {
            GameObjectType t = new GameObjectType((ushort)7);

            Assert.Equal(7, t.GetHashCode());
        }

        /// <summary>
        ///     Verifies that the equality operator returns true for instances with the same value.
        /// </summary>
        [Fact]
        public void OperatorEquals_SameValues_ReturnsTrue()
        {
            GameObjectType a = new GameObjectType((ushort)5);
            GameObjectType b = new GameObjectType((ushort)5);

            Assert.True(a == b);
        }

        /// <summary>
        ///     Verifies that the inequality operator returns true for instances with different values.
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentValues_ReturnsTrue()
        {
            GameObjectType a = new GameObjectType((ushort)3);
            GameObjectType b = new GameObjectType((ushort)4);

            Assert.True(a != b);
        }

        /// <summary>
        ///     Verifies that a default GameObjectType has RawIndex equal to zero.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ZeroRawIndex()
        {
            GameObjectType t = default;

            Assert.Equal((ushort)0, t.RawIndex);
        }
    }
}
