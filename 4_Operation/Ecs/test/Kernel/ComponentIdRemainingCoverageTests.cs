// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentIdRemainingCoverageTests.cs
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
    public class ComponentIdRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the internal parameterized constructor sets RawIndex to the given non-zero value.
        /// </summary>
        [Fact]
        public void InternalConstructor_SetsRawIndex()
        {
            ComponentId id = new ComponentId((ushort)42);

            Assert.Equal((ushort)42, id.RawIndex);
        }

        /// <summary>
        ///     Verifies that the internal parameterized constructor sets RawIndex to zero when given zero.
        /// </summary>
        [Fact]
        public void InternalConstructor_DefaultValue_SetsZero()
        {
            ComponentId id = new ComponentId((ushort)0);

            Assert.Equal((ushort)0, id.RawIndex);
        }

        /// <summary>
        ///     Verifies that the explicit ITypeId.Value implementation returns RawIndex for a non-zero instance.
        /// </summary>
        [Fact]
        public void ITypeIdValue_ReturnsRawIndex()
        {
            ComponentId id = new ComponentId((ushort)99);
            ITypeId typeId = id;

            Assert.Equal((ushort)99, typeId.Value);
        }

        /// <summary>
        ///     Verifies that the explicit ITypeId.Value implementation returns zero for a default instance.
        /// </summary>
        [Fact]
        public void ITypeIdValue_DefaultIsZero()
        {
            ComponentId id = default;
            ITypeId typeId = id;

            Assert.Equal((ushort)0, typeId.Value);
        }

        /// <summary>
        ///     Verifies that GetHashCode returns the non-zero RawIndex value.
        /// </summary>
        [Fact]
        public void GetHashCode_NonZeroRawIndex_ReturnsRawIndex()
        {
            ComponentId id = new ComponentId((ushort)7);

            Assert.Equal(7, id.GetHashCode());
        }

        /// <summary>
        ///     Verifies that Equals returns false when comparing two instances with different non-zero RawIndex values.
        /// </summary>
        [Fact]
        public void Equals_DifferentRawIndex_ReturnsFalse()
        {
            ComponentId a = new ComponentId((ushort)1);
            ComponentId b = new ComponentId((ushort)2);

            Assert.False(a.Equals(b));
        }

        /// <summary>
        ///     Verifies that Equals returns true when comparing two instances with the same non-zero RawIndex value.
        /// </summary>
        [Fact]
        public void Equals_SameNonZeroRawIndex_ReturnsTrue()
        {
            ComponentId a = new ComponentId((ushort)5);
            ComponentId b = new ComponentId((ushort)5);

            Assert.True(a.Equals(b));
        }

        /// <summary>
        ///     Verifies that the equality operator returns false for two instances with different non-zero RawIndex values.
        /// </summary>
        [Fact]
        public void OperatorEquals_DifferentRawIndex_ReturnsFalse()
        {
            ComponentId a = new ComponentId((ushort)3);
            ComponentId b = new ComponentId((ushort)4);

            Assert.False(a == b);
        }

        /// <summary>
        ///     Verifies that the inequality operator returns true for two instances with different non-zero RawIndex values.
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentRawIndex_ReturnsTrue()
        {
            ComponentId a = new ComponentId((ushort)3);
            ComponentId b = new ComponentId((ushort)4);

            Assert.True(a != b);
        }

        /// <summary>
        ///     Verifies that Equals(object) returns true for a boxed instance with the same non-zero RawIndex value.
        /// </summary>
        [Fact]
        public void Equals_Object_NonZeroRawIndex_ReturnsTrueForSameValue()
        {
            ComponentId a = new ComponentId((ushort)10);
            object b = new ComponentId((ushort)10);

            Assert.True(a.Equals(b));
        }
    }
}