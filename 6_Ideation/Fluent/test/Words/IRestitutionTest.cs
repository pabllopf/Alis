// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IRestitutionTest.cs
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
    ///     Unit tests for the IRestitution interface.
    ///     Tests the Restitution method for bounce coefficient assignment.
    /// </summary>
    public class IRestitutionTest
    {
        /// <summary>
        ///     Helper builder class for restitution.
        /// </summary>
        private class RestitutionBuilder
        {
            public float RestitutionValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IRestitution.
        /// </summary>
        private class RestitutionBuilderImpl : IRestitution<RestitutionBuilder, float>
        {
            private readonly RestitutionBuilder _builder = new RestitutionBuilder();

            public RestitutionBuilder Restitution(float value)
            {
                _builder.RestitutionValue = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IRestitution can be implemented.
        /// </summary>
        [Fact]
        public void IRestitution_CanBeImplemented()
        {
            var builder = new RestitutionBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IRestitution<RestitutionBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Restitution sets value correctly.
        /// </summary>
        [Fact]
        public void Restitution_SetsValueCorrectly()
        {
            var builder = new RestitutionBuilderImpl();
            var result = builder.Restitution(0.8f);
            Assert.Equal(0.8f, result.RestitutionValue);
        }

        /// <summary>
        ///     Tests that Restitution returns builder.
        /// </summary>
        [Fact]
        public void Restitution_ReturnsBuilder()
        {
            var builder = new RestitutionBuilderImpl();
            var result = builder.Restitution(0.6f);
            Assert.NotNull(result);
            Assert.IsType<RestitutionBuilder>(result);
        }

        /// <summary>
        ///     Tests Restitution with valid bounce values.
        /// </summary>
        [Theory]
        [InlineData(0f)]
        [InlineData(0.25f)]
        [InlineData(0.5f)]
        [InlineData(0.75f)]
        [InlineData(1f)]
        public void Restitution_WithValidBounceValues(float restitution)
        {
            var builder = new RestitutionBuilderImpl();
            var result = builder.Restitution(restitution);
            Assert.Equal(restitution, result.RestitutionValue);
        }
    }
}

