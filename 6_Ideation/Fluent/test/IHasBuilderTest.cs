// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IHasBuilderTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     Unit tests for the IHasBuilder interface.
    ///     Verifies that the IHasBuilder contract is correctly implemented.
    /// </summary>
    public class IHasBuilderTest
    {
        /// <summary>
        ///     Tests that IHasBuilder can be implemented.
        /// </summary>
        [Fact]
        public void IHasBuilder_CanBeImplemented()
        {
            TestBuilderImpl builder = new TestBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IHasBuilder<string>>(builder);
        }

        /// <summary>
        ///     Tests that Builder method returns expected value.
        /// </summary>
        [Fact]
        public void Builder_ReturnsExpectedValue()
        {
            TestBuilderImpl builder = new TestBuilderImpl();
            string result = builder.Builder();
            Assert.Equal("test_value", result);
        }

        /// <summary>
        ///     Tests that Builder does not return null.
        /// </summary>
        [Fact]
        public void Builder_DoesNotReturnNull()
        {
            TestBuilderImpl builder = new TestBuilderImpl();
            string result = builder.Builder();
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests IHasBuilder with integer type.
        /// </summary>
        [Fact]
        public void IHasBuilder_WithIntegerType()
        {
            IntBuilderImpl builder = new IntBuilderImpl();
            int result = builder.Builder();
            Assert.Equal(100, result);
        }

        /// <summary>
        ///     Tests IHasBuilder with custom object type.
        /// </summary>
        [Fact]
        public void IHasBuilder_WithCustomObjectType()
        {
            CustomBuilderImpl builder = new CustomBuilderImpl();
            TestData result = builder.Builder();
            Assert.NotNull(result);
            Assert.IsType<TestData>(result);
            Assert.Equal("data", result.Value);
        }

        /// <summary>
        ///     Tests covariance with IHasBuilder.
        /// </summary>
        [Fact]
        public void IHasBuilder_SupportsCovariance()
        {
            IHasBuilder<object> builder = new ObjectBuilderImpl();
            object result = builder.Builder();
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Helper implementation for testing.
        /// </summary>
        private class TestBuilderImpl : IHasBuilder<string>
        {
            /// <summary>
            ///     Builders this instance
            /// </summary>
            /// <returns>The string</returns>
            public string Builder() => "test_value";
        }

        /// <summary>
        ///     Helper integer builder implementation.
        /// </summary>
        private class IntBuilderImpl : IHasBuilder<int>
        {
            /// <summary>
            ///     Builders this instance
            /// </summary>
            /// <returns>The int</returns>
            public int Builder() => 100;
        }

        /// <summary>
        ///     Custom data type for testing.
        /// </summary>
        private class TestData
        {
            /// <summary>
            ///     Gets or sets the value of the value
            /// </summary>
            public string Value { get; set; }
        }

        /// <summary>
        ///     Helper custom object builder implementation.
        /// </summary>
        private class CustomBuilderImpl : IHasBuilder<TestData>
        {
            /// <summary>
            ///     Builders this instance
            /// </summary>
            /// <returns>The test data</returns>
            public TestData Builder() => new TestData {Value = "data"};
        }

        /// <summary>
        ///     Helper object builder for testing covariance.
        /// </summary>
        private class ObjectBuilderImpl : IHasBuilder<object>
        {
            /// <summary>
            ///     Builders this instance
            /// </summary>
            /// <returns>The object</returns>
            public object Builder() => "covariant_object";
        }
    }
}