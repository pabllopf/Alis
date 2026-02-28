// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWithTest.cs
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

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IWith interface.
    ///     Tests the With method for fluent builder pattern.
    /// </summary>
    public class IWithTest
    {
        /// <summary>
        ///     Tests that IWith can be implemented.
        /// </summary>
        [Fact]
        public void IWith_CanBeImplemented()
        {
            WithBuilder builder = new WithBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IWith<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that With returns builder.
        /// </summary>
        [Fact]
        public void With_ReturnsBuilder()
        {
            WithBuilder builder = new WithBuilder();
            Builder result = builder.With("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that With sets value correctly.
        /// </summary>
        [Fact]
        public void With_SetsValueCorrectly()
        {
            WithBuilder builder = new WithBuilder();
            Builder result = builder.With("test");
            Assert.Equal("test", result.WithValue);
        }

        /// <summary>
        ///     Tests method chaining support.
        /// </summary>
        [Fact]
        public void With_SupportsMethodChaining()
        {
            WithBuilder withBuilder = new WithBuilder();
            Builder result1 = withBuilder.With("first");
            Assert.Equal("first", result1.WithValue);
        }

        /// <summary>
        ///     Tests IWith with integer argument.
        /// </summary>
        [Fact]
        public void IWith_WithIntegerArgumentType()
        {
            IntWithBuilder builder = new IntWithBuilder();
            IntBuilder result = builder.With(100);
            Assert.Equal(100, result.Value);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder
        {
            public string WithValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IWith.
        /// </summary>
        private class WithBuilder : IWith<Builder, string>
        {
            private readonly Builder _builder = new Builder();

            public Builder With(string value)
            {
                _builder.WithValue = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Helper builder with integer.
        /// </summary>
        private class IntBuilder
        {
            public int Value { get; set; }
        }

        /// <summary>
        ///     Helper implementation with integer.
        /// </summary>
        private class IntWithBuilder : IWith<IntBuilder, int>
        {
            private readonly IntBuilder _builder = new IntBuilder();

            public IntBuilder With(int value)
            {
                _builder.Value = value;
                return _builder;
            }
        }
    }
}