// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenerationServicesRemainingCoverageTests.cs
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

using System;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="GenerationServices" /> static methods.
    /// </summary>
    public partial class GenerationServicesRemainingCoverageTests
    {

        /// <summary>
        ///     Tests that <see cref="GenerationServices.RegisterType" /> with a non-factory
        ///     object throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void RegisterType_WithInvalidFactory_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                GenerationServices.RegisterType(typeof(CoverageInitDestroyProbe), new object()));

            Assert.Contains("Source generation appears to be broken", ex.Message);
        }

        /// <summary>
        ///     Tests that <see cref="GenerationServices.RegisterType" /> with the same factory
        ///     for an already-registered type does not throw.
        /// </summary>
        [Fact]
        public void RegisterType_WithValidFactory_SameFactoryTwice_DoesNotThrow()
        {
            Type type = typeof(CoverageSameFactoryProbe);
            GenerationServices.RegisterType(type, new UpdateRunnerFactory<CoverageSameFactoryProbe>());
            GenerationServices.RegisterType(type, new UpdateRunnerFactory<CoverageSameFactoryProbe>());
        }

        /// <summary>
        ///     Tests that <see cref="GenerationServices.RegisterType" /> with a different factory
        ///     type for an already-registered type throws <see cref="ArgumentException" />.
        /// </summary>
        [Fact]
        public void RegisterType_WithValidFactory_DifferentFactoryType_ThrowsArgumentException()
        {
            Type type = typeof(CoverageDiffFactoryProbe);
            GenerationServices.RegisterType(type, new UpdateRunnerFactory<CoverageDiffFactoryProbe>());

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                GenerationServices.RegisterType(type, new UpdateRunnerFactory<CoverageAnotherUpdateProbe>()));

            Assert.Contains(type.FullName, ex.Message);
        }

        /// <summary>
        ///     A probe attribute for testing registration.
        /// </summary>
        internal sealed class CoverageProbeAttribute : Attribute;

        /// <summary>
        ///     A probe component implementing both <see cref="IOnInit" /> and
        ///     <see cref="IOnDestroy" /> for testing.
        /// </summary>
        private partial struct CoverageInitDestroyProbe : IOnInit, IOnDestroy
        {
            /// <summary>
            /// Ons the init using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnInit(IGameObject self)
            {
            }

            /// <summary>
            /// Ons the destroy
            /// </summary>
            public void OnDestroy()
            {
            }
        }

        /// <summary>
        ///     Probe component implementing <see cref="IOnUpdate" /> for valid factory tests.
        /// </summary>
        private partial struct CoverageOnUpdateProbe : IOnUpdate
        {
            /// <summary>
            /// Ons the update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnUpdate(IGameObject self)
            {
            }
        }

        /// <summary>
        ///     Probe component for same-factory registration test.
        /// </summary>
        private partial struct CoverageSameFactoryProbe : IOnUpdate
        {
            /// <summary>
            /// Ons the update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnUpdate(IGameObject self)
            {
            }
        }

        /// <summary>
        ///     Probe component for different-factory registration test.
        /// </summary>
        private partial struct CoverageDiffFactoryProbe : IOnUpdate
        {
            /// <summary>
            /// Ons the update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnUpdate(IGameObject self)
            {
            }
        }

        /// <summary>
        ///     Another update probe with a different type identity.
        /// </summary>
        private partial struct CoverageAnotherUpdateProbe : IOnUpdate
        {
            /// <summary>
            /// Ons the update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnUpdate(IGameObject self)
            {
            }
        }
    }
}
