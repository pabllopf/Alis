// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IMassTest.cs
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
    ///     Unit tests for the IMass interface.
    ///     Tests the Mass method for object mass assignment.
    /// </summary>
    public class IMassTest
    {
        /// <summary>
        ///     Tests that IMass can be implemented.
        /// </summary>
        [Fact]
        public void IMass_CanBeImplemented()
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IMass<MassBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Mass sets value correctly.
        /// </summary>
        [Fact]
        public void Mass_SetsValueCorrectly()
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            MassBuilder result = builder.Mass(2.5f);
            Assert.Equal(2.5f, result.MassValue);
        }

        /// <summary>
        ///     Tests that Mass returns builder.
        /// </summary>
        [Fact]
        public void Mass_ReturnsBuilder()
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            MassBuilder result = builder.Mass(1f);
            Assert.NotNull(result);
            Assert.IsType<MassBuilder>(result);
        }

        /// <summary>
        ///     Tests Mass with typical physics values.
        /// </summary>
        [Theory, InlineData(0.1f), InlineData(1f), InlineData(5f), InlineData(10f), InlineData(100f)]
        public void Mass_WithTypicalPhysicsValues(float mass)
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            MassBuilder result = builder.Mass(mass);
            Assert.Equal(mass, result.MassValue);
        }

        /// <summary>
        ///     Helper builder class for mass.
        /// </summary>
        private class MassBuilder
        {
            public float MassValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IMass.
        /// </summary>
        private class MassBuilderImpl : IMass<MassBuilder, float>
        {
            private readonly MassBuilder _builder = new MassBuilder();

            public MassBuilder Mass(float value)
            {
                _builder.MassValue = value;
                return _builder;
            }
        }
    }
}