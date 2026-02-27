// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IPhysicTest.cs
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
    ///     Unit tests for the IPhysic interface.
    ///     Tests the Physic method for physics configuration.
    /// </summary>
    public class IPhysicTest
    {
        /// <summary>
        ///     Helper builder class for physics.
        /// </summary>
        private class PhysicBuilder
        {
            public string PhysicsEngine { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IPhysic.
        /// </summary>
        private class PhysicBuilderImpl : IPhysic<PhysicBuilder, string>
        {
            private readonly PhysicBuilder _builder = new PhysicBuilder();

            public PhysicBuilder Physic(string value)
            {
                _builder.PhysicsEngine = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IPhysic can be implemented.
        /// </summary>
        [Fact]
        public void IPhysic_CanBeImplemented()
        {
            var builder = new PhysicBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IPhysic<PhysicBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Physic sets engine correctly.
        /// </summary>
        [Fact]
        public void Physic_SetsEngineCorrectly()
        {
            var builder = new PhysicBuilderImpl();
            var result = builder.Physic("Box2D");
            Assert.Equal("Box2D", result.PhysicsEngine);
        }

        /// <summary>
        ///     Tests that Physic returns builder.
        /// </summary>
        [Fact]
        public void Physic_ReturnsBuilder()
        {
            var builder = new PhysicBuilderImpl();
            var result = builder.Physic("Bullet");
            Assert.NotNull(result);
            Assert.IsType<PhysicBuilder>(result);
        }

        /// <summary>
        ///     Tests Physic with various engines.
        /// </summary>
        [Theory]
        [InlineData("Box2D")]
        [InlineData("Bullet")]
        [InlineData("PhysX")]
        [InlineData("Havok")]
        public void Physic_WithVariousEngines(string engine)
        {
            var builder = new PhysicBuilderImpl();
            var result = builder.Physic(engine);
            Assert.Equal(engine, result.PhysicsEngine);
        }
    }
}

