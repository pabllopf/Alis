// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentIdTest.cs
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

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    public class ComponentIdTest
    {
        [Fact]
        public void Type_ShouldBeStruct()
        {
            Assert.True(typeof(ComponentId).IsValueType);
            Assert.False(typeof(ComponentId).IsClass);
        }

        [Fact]
        public void Struct_ShouldBeReadOnly()
        {
            Assert.True(typeof(ComponentId).IsValueType);
        }

        [Fact]
        public void Struct_ShouldImplementITypeId()
        {
            Assert.IsAssignableFrom<ITypeId>(default(ComponentId));
        }

        [Fact]
        public void Struct_ShouldImplementIEquatable()
        {
            Assert.Contains(typeof(System.IEquatable<>).MakeGenericType(typeof(ComponentId)), typeof(ComponentId).GetInterfaces());
        }

        [Fact]
        public void DefaultInstance_ShouldHaveZeroValue()
        {
            ComponentId id = default;

            Assert.Equal(0, id.GetHashCode());
        }

        [Fact]
        public void Equals_SameDefault_ShouldBeTrue()
        {
            ComponentId a = default;
            ComponentId b = default;

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void OperatorEquals_SameDefault_ShouldBeTrue()
        {
            ComponentId a = default;
            ComponentId b = default;

            Assert.True(a == b);
        }

        [Fact]
        public void OperatorNotEquals_DifferentValues_ShouldBeTrue()
        {
            ComponentId a = default;
            ComponentId b = default;

            Assert.False(a != b);
        }

        [Fact]
        public void Equals_Object_ShouldBeTrueForSameType()
        {
            ComponentId a = default;
            object b = a;

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void Equals_Object_ShouldBeFalseForDifferentType()
        {
            ComponentId a = default;
            object b = "not a component id";

            Assert.False(a.Equals(b));
        }
    }
}
