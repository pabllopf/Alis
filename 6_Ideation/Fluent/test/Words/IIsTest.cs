// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IIsTest.cs
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
    ///     Unit tests for the IIs interface.
    ///     Tests the Is method for type checking and assertion.
    /// </summary>
    public class IIsTest
    {
        /// <summary>
        ///     Tests that IIs can be implemented.
        /// </summary>
        [Fact]
        public void IIs_CanBeImplemented()
        {
            IsBuilder builder = new IsBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IIs<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Is returns builder.
        /// </summary>
        [Fact]
        public void Is_ReturnsBuilder()
        {
            IsBuilder builder = new IsBuilder();
            Builder result = builder.Is<object>("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that Is method preserves value.
        /// </summary>
        [Fact]
        public void Is_PreservesValue()
        {
            IsBuilder builder = new IsBuilder();
            Builder result = builder.Is<object>("test");
            Assert.Equal("test", result.IsValue);
        }

        /// <summary>
        ///     Tests Is with different type parameters.
        /// </summary>
        [Fact]
        public void Is_WithDifferentTypeParameters()
        {
            IsBuilder builder = new IsBuilder();
            Builder result1 = builder.Is<int>("first");
            Builder result2 = builder.Is<string>("second");
            Assert.Equal("second", result2.IsValue);
        }

        /// <summary>
        ///     Tests Is method chaining.
        /// </summary>
        [Fact]
        public void Is_SupportsChaining()
        {
            IsBuilder builder = new IsBuilder();
            Builder result = builder.Is<int>("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder
        {
            /// <summary>
            ///     Gets or sets the value of the is value
            /// </summary>
            public string IsValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IIs.
        /// </summary>
        private class IsBuilder : IIs<Builder, string>
        {
            /// <summary>
            ///     The builder
            /// </summary>
            private readonly Builder _builder = new Builder();

            /// <summary>
            ///     Ises the value
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public Builder Is<T>(string value)
            {
                _builder.IsValue = value;
                return _builder;
            }
        }
    }
}