// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBuildTest.cs
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
    ///     Unit tests for the IBuild interface.
    ///     Verifies that Build implementations can be created and return the correct origin type.
    /// </summary>
    public class IBuildTest
    {
        /// <summary>
        ///     Tests that IBuild can be implemented with different return types.
        /// </summary>
        [Fact]
        public void IBuild_CanBeImplemented()
        {
            TestBuilder builder = new TestBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IBuild<string>>(builder);
        }

        /// <summary>
        ///     Tests that Build returns the expected origin value.
        /// </summary>
        [Fact]
        public void Build_ReturnsOriginValue()
        {
            TestBuilder builder = new TestBuilder();
            string result = builder.Build();
            Assert.Equal("built", result);
        }

        /// <summary>
        ///     Tests that Build never returns null.
        /// </summary>
        [Fact]
        public void Build_DoesNotReturnNull()
        {
            TestBuilder builder = new TestBuilder();
            string result = builder.Build();
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests IBuild with integer return type.
        /// </summary>
        [Fact]
        public void IBuild_WithIntegerType()
        {
            IntBuilder builder = new IntBuilder();
            int result = builder.Build();
            Assert.Equal(42, result);
        }

        /// <summary>
        ///     Tests IBuild with object return type.
        /// </summary>
        [Fact]
        public void IBuild_WithObjectType()
        {
            ObjectBuilder builder = new ObjectBuilder();
            object result = builder.Build();
            Assert.NotNull(result);
            Assert.IsType<object>(result);
        }

        /// <summary>
        ///     Helper builder class for testing.
        /// </summary>
        private class TestBuilder : IBuild<string>
        {
            public string Build() => "built";
        }

        /// <summary>
        ///     Helper integer builder for testing.
        /// </summary>
        private class IntBuilder : IBuild<int>
        {
            public int Build() => 42;
        }

        /// <summary>
        ///     Helper object builder for testing.
        /// </summary>
        private class ObjectBuilder : IBuild<object>
        {
            public object Build() => new object();
        }
    }
}