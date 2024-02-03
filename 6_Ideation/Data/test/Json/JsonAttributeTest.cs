// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonAttributeTest.cs
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

using Alis.Core.Aspect.Data.Json;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The json attribute test class
    /// </summary>
    public class JsonAttributeTest
    {
        /// <summary>
        /// Tests that test constructor
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            JsonAttribute attribute = new JsonAttribute();
            Assert.NotNull(attribute);
        }

        /// <summary>
        /// Tests that test constructor with name
        /// </summary>
        [Fact]
        public void TestConstructorWithName()
        {
            string name = "TestName";
            JsonAttribute attribute = new JsonAttribute(name);
            Assert.Equal(name, attribute.Name);
        }

        /// <summary>
        /// Tests that test name property
        /// </summary>
        [Fact]
        public void TestNameProperty()
        {
            string name = "TestName";
            JsonAttribute attribute = new JsonAttribute {Name = name};
            Assert.Equal(name, attribute.Name);
        }

        /// <summary>
        /// Tests that test ignore when serializing property
        /// </summary>
        [Fact]
        public void TestIgnoreWhenSerializingProperty()
        {
            JsonAttribute attribute = new JsonAttribute {IgnoreWhenSerializing = true};
            Assert.True(attribute.IgnoreWhenSerializing);
        }

        /// <summary>
        /// Tests that test ignore when deserializing property
        /// </summary>
        [Fact]
        public void TestIgnoreWhenDeserializingProperty()
        {
            JsonAttribute attribute = new JsonAttribute {IgnoreWhenDeserializing = true};
            Assert.True(attribute.IgnoreWhenDeserializing);
        }

        /// <summary>
        /// Tests that test default value property
        /// </summary>
        [Fact]
        public void TestDefaultValueProperty()
        {
            object defaultValue = new object();
            JsonAttribute attribute = new JsonAttribute {DefaultValue = defaultValue};
            Assert.Equal(defaultValue, attribute.DefaultValue);
        }

        /// <summary>
        /// Tests that test has default value property
        /// </summary>
        [Fact]
        public void TestHasDefaultValueProperty()
        {
            JsonAttribute attribute = new JsonAttribute {HasDefaultValue = true};
            Assert.True(attribute.HasDefaultValue);
        }
    }
}