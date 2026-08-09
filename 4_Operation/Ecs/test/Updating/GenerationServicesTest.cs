// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenerationServicesTest.cs
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
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Test.Updating.Runners;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Tests for GenerationServices registration methods.
    /// </summary>
    public partial class GenerationServicesTest
    {
        /// <summary>
        ///     Tests that register type with invalid factory throws invalid operation exception
        /// </summary>
        [Fact] public void RegisterType_WithInvalidFactory_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                GenerationServices.RegisterType(typeof(UpdateComponent), new object()));

            Assert.Contains("Source generation appears to be broken", ex.Message);
        }

        /// <summary>
        ///     Tests that register type with different factory type for same component throws exception
        /// </summary>
        [Fact] public void RegisterType_WithDifferentFactoryTypeForSameComponent_ThrowsException()
        {
            Type componentType = typeof(GenerationServicesProbeComponent);
            GenerationServices.RegisterType(componentType, new UpdateRunnerFactory<UpdateComponent>());

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                GenerationServices.RegisterType(componentType, new UpdateRunnerFactory<Update2Component, Position, Velocity>()));

            Assert.Contains(componentType.FullName, ex.Message);
        }

        /// <summary>
        ///     Tests that registering the same type with the same factory twice does not throw.
        /// </summary>
        [Fact] public void RegisterType_SameFactoryTwice_DoesNotThrow()
        {
            Type componentType = typeof(GenerationServicesProbeComponent);

            GenerationServices.RegisterType(componentType, new UpdateRunnerFactory<UpdateComponent>());

            GenerationServices.RegisterType(componentType, new UpdateRunnerFactory<UpdateComponent>());
        }

        /// <summary>
        ///     The generation services probe attribute class
        /// </summary>
        /// <seealso cref="Attribute" />
        internal sealed class GenerationServicesProbeAttribute : Attribute
        {
        }

        /// <summary>
        ///     The generation services probe component
        /// </summary>
        internal struct GenerationServicesProbeComponent
        {
        }

        /// <summary>
        ///     The generation services init destroy probe
        /// </summary>
        private partial struct GenerationServicesInitDestroyProbe : IOnInit, IOnDestroy
        {
            /// <summary>
            ///     The init calls
            /// </summary>
            public int InitCalls;

            /// <summary>
            ///     The destroy calls
            /// </summary>
            public int DestroyCalls;

            /// <summary>
            ///     Ons the init using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnInit(IGameObject self)
            {
                InitCalls++;
            }

            /// <summary>
            ///     Ons the destroy
            /// </summary>
            public void OnDestroy()
            {
                DestroyCalls++;
            }
        }
    }
}