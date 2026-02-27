// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ISetTest.cs
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
    ///     Unit tests for the ISet interface.
    ///     Tests the Set method for generic property assignment.
    /// </summary>
    public class ISetTest
    {
        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder { public string SetValue { get; set; } }

        /// <summary>
        ///     Helper implementation of ISet.
        /// </summary>
        private class SetBuilder : ISet<Builder, string>
        {
            private readonly Builder _builder = new Builder();

            public Builder Set<T>(string value)
            {
                _builder.SetValue = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that ISet can be implemented.
        /// </summary>
        [Fact]
        public void ISet_CanBeImplemented()
        {
            var builder = new SetBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ISet<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Set returns builder.
        /// </summary>
        [Fact]
        public void Set_ReturnsBuilder()
        {
            var builder = new SetBuilder();
            var result = builder.Set<object>("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that Set assigns value correctly.
        /// </summary>
        [Fact]
        public void Set_AssignsValueCorrectly()
        {
            var builder = new SetBuilder();
            var result = builder.Set<object>("assigned");
            Assert.Equal("assigned", result.SetValue);
        }

        /// <summary>
        ///     Tests Set with different generic type parameter.
        /// </summary>
        [Fact]
        public void Set_SupportsGenericTypeParameter()
        {
            var builder = new SetBuilder();
            var result1 = builder.Set<int>("value1");
            var result2 = builder.Set<string>("value2");
            Assert.Equal("value2", result2.SetValue);
        }
    }
}

