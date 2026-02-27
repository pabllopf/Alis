// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ICreateTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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
    ///     Unit tests for the ICreate interface.
    ///     Tests fluent builder pattern with Create method.
    /// </summary>
    public class ICreateTest
    {
        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class TestBuilder { public string CreatedValue { get; set; } }

        /// <summary>
        ///     Helper implementation of ICreate.
        /// </summary>
        private class CreateBuilder : ICreate<TestBuilder, string>
        {
            private readonly TestBuilder _builder = new TestBuilder();

            public TestBuilder Create(string obj)
            {
                _builder.CreatedValue = obj;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that ICreate can be implemented.
        /// </summary>
        [Fact]
        public void ICreate_CanBeImplemented()
        {
            var builder = new CreateBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ICreate<TestBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Create returns builder with value set.
        /// </summary>
        [Fact]
        public void Create_ReturnsBuilderWithValueSet()
        {
            var builder = new CreateBuilder();
            var result = builder.Create("test");
            Assert.NotNull(result);
            Assert.Equal("test", result.CreatedValue);
        }

        /// <summary>
        ///     Tests fluent chaining capability.
        /// </summary>
        [Fact]
        public void Create_SupportsFluentChaining()
        {
            var createBuilder = new CreateBuilder();
            var result = createBuilder.Create("value");
            Assert.NotNull(result);
            Assert.IsType<TestBuilder>(result);
        }

        /// <summary>
        ///     Tests Create with null value.
        /// </summary>
        [Fact]
        public void Create_CanHandleNullArgument()
        {
            var builder = new CreateBuilder();
            var result = builder.Create(null);
            Assert.NotNull(result);
            Assert.Null(result.CreatedValue);
        }

        /// <summary>
        ///     Tests Create with different argument types.
        /// </summary>
        [Fact]
        public void ICreate_WithIntegerArgumentType()
        {
            var builder = new IntCreateBuilder();
            var result = builder.Create(42);
            Assert.Equal(42, result.Value);
        }

        /// <summary>
        ///     Helper builder with integer.
        /// </summary>
        private class IntTestBuilder { public int Value { get; set; } }

        /// <summary>
        ///     Helper implementation with integer.
        /// </summary>
        private class IntCreateBuilder : ICreate<IntTestBuilder, int>
        {
            private readonly IntTestBuilder _builder = new IntTestBuilder();

            public IntTestBuilder Create(int obj)
            {
                _builder.Value = obj;
                return _builder;
            }
        }
    }
}

