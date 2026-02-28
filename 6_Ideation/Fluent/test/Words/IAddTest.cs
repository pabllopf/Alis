// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAddTest.cs
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
    ///     Unit tests for the IAdd interface.
    ///     Ensures the Add method can be implemented and returns the correct builder type.
    /// </summary>
    public class IAddTest
    {
        /// <summary>
        ///     Ensures Add returns a builder with the correct value.
        /// </summary>
        [Fact]
        public void Add_ReturnsBuilderWithCorrectValue()
        {
            DummyAdd add = new DummyAdd();
            DummyBuilder builder = add.Add(123);
            Assert.NotNull(builder);
            Assert.Equal(123, builder.Value);
        }

        private class DummyBuilder
        {
            public int Value;
        }

        private class DummyAdd : IAdd<DummyBuilder, int>
        {
            public DummyBuilder Add(int value) => new DummyBuilder {Value = value};
        }
    }
}