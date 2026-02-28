// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INameTest.cs
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
    ///     Unit tests for the IName interface.
    ///     Tests the Name method for object naming.
    /// </summary>
    public class INameTest
    {
        /// <summary>
        ///     Tests that IName can be implemented.
        /// </summary>
        [Fact]
        public void IName_CanBeImplemented()
        {
            NameBuilderImpl builder = new NameBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IName<NamedBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Name sets name correctly.
        /// </summary>
        [Fact]
        public void Name_SetsNameCorrectly()
        {
            NameBuilderImpl builder = new NameBuilderImpl();
            NamedBuilder result = builder.Name("GameObject");
            Assert.Equal("GameObject", result.Name);
        }

        /// <summary>
        ///     Tests that Name returns builder.
        /// </summary>
        [Fact]
        public void Name_ReturnsBuilder()
        {
            NameBuilderImpl builder = new NameBuilderImpl();
            NamedBuilder result = builder.Name("TestName");
            Assert.NotNull(result);
            Assert.IsType<NamedBuilder>(result);
        }

        /// <summary>
        ///     Tests Name with empty string.
        /// </summary>
        [Fact]
        public void Name_WithEmptyString()
        {
            NameBuilderImpl builder = new NameBuilderImpl();
            NamedBuilder result = builder.Name(string.Empty);
            Assert.Equal(string.Empty, result.Name);
        }

        /// <summary>
        ///     Tests Name with special characters.
        /// </summary>
        [Theory, InlineData("Object_123"), InlineData("Player@Team"), InlineData("Enemy#1")]
        public void Name_WithSpecialCharacters(string name)
        {
            NameBuilderImpl builder = new NameBuilderImpl();
            NamedBuilder result = builder.Name(name);
            Assert.Equal(name, result.Name);
        }

        /// <summary>
        ///     Helper builder class for naming.
        /// </summary>
        private class NamedBuilder
        {
            public string Name { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IName.
        /// </summary>
        private class NameBuilderImpl : IName<NamedBuilder, string>
        {
            private readonly NamedBuilder _builder = new NamedBuilder();

            public NamedBuilder Name(string value)
            {
                _builder.Name = value;
                return _builder;
            }
        }
    }
}