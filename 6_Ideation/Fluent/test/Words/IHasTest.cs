// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IHasTest.cs
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
    ///     Unit tests for the IHas interface.
    ///     Tests the Has method for checking object existence.
    /// </summary>
    public class IHasTest
    {
        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder { public string HasProperty { get; set; } }

        /// <summary>
        ///     Helper implementation of IHas.
        /// </summary>
        private class HasBuilder : IHas<Builder, string>
        {
            private readonly Builder _builder = new Builder();

            public Builder Has(string obj)
            {
                _builder.HasProperty = obj;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IHas can be implemented.
        /// </summary>
        [Fact]
        public void IHas_CanBeImplemented()
        {
            HasBuilder builder = new HasBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IHas<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Has returns builder.
        /// </summary>
        [Fact]
        public void Has_ReturnsBuilder()
        {
            HasBuilder builder = new HasBuilder();
            Builder result = builder.Has("property");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that Has sets property correctly.
        /// </summary>
        [Fact]
        public void Has_SetsPropertyCorrectly()
        {
            HasBuilder builder = new HasBuilder();
            Builder result = builder.Has("test_prop");
            Assert.Equal("test_prop", result.HasProperty);
        }

        /// <summary>
        ///     Tests IHas with object argument.
        /// </summary>
        [Fact]
        public void IHas_WithObjectArgument()
        {
            ObjectHasBuilder builder = new ObjectHasBuilder();
            object obj = new object();
            ObjectBuilder result = builder.Has(obj);
            Assert.Same(obj, result.HasObject);
        }

        /// <summary>
        ///     Helper builder with object.
        /// </summary>
        private class ObjectBuilder { public object HasObject { get; set; } }

        /// <summary>
        ///     Helper implementation with object.
        /// </summary>
        private class ObjectHasBuilder : IHas<ObjectBuilder, object>
        {
            private readonly ObjectBuilder _builder = new ObjectBuilder();

            public ObjectBuilder Has(object obj)
            {
                _builder.HasObject = obj;
                return _builder;
            }
        }
    }
}

