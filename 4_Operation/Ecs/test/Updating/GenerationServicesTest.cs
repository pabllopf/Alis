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
using System.Reflection;
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
        [Fact]
        public void RegisterType_WithInvalidFactory_ThrowsInvalidOperationException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                GenerationServices.RegisterType(typeof(UpdateComponent), new object()));

            Assert.Contains("Source generation appears to be broken", ex.Message);
        }

        /// <summary>
        ///     Tests that register type with different factory type for same component throws exception
        /// </summary>
        [Fact]
        public void RegisterType_WithDifferentFactoryTypeForSameComponent_ThrowsException()
        {
            Type componentType = typeof(GenerationServicesProbeComponent);
            GenerationServices.RegisterType(componentType, new UpdateRunnerFactory<UpdateComponent>());

            Exception ex = Assert.Throws<Exception>(() =>
                GenerationServices.RegisterType(componentType, new UpdateRunnerFactory<Update2Component, Position, Velocity>()));

            Assert.Contains(componentType.FullName, ex.Message);
        }

        /// <summary>
        ///     Tests that register update method attribute adds component type to cache
        /// </summary>
        [Fact]
        public void RegisterUpdateMethodAttribute_AddsComponentTypeToCache()
        {
            Type attributeType = typeof(GenerationServicesProbeAttribute);
            Type componentType = typeof(UpdateComponent);

            GenerationServices.RegisterUpdateMethodAttribute(attributeType, componentType);
            IDictionary cache = (IDictionary) typeof(GenerationServices)
                .GetField("TypeAttributeCache", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            Assert.True(cache.Contains(attributeType));
            Assert.Contains(componentType, (HashSet<Type>) cache[attributeType]);
        }

        /// <summary>
        ///     Tests that register init registers delegate that invokes on init
        /// </summary>
        [Fact]
        public void RegisterInit_RegistersDelegateThatInvokesOnInit()
        {
            GenerationServices.RegisterInit<GenerationServicesInitDestroyProbe>();
            IDictionary cache = (IDictionary) typeof(GenerationServices)
                .GetField("TypeIniters", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            ComponentDelegates<GenerationServicesInitDestroyProbe>.InitDelegate init =
                (ComponentDelegates<GenerationServicesInitDestroyProbe>.InitDelegate) cache[typeof(GenerationServicesInitDestroyProbe)];

            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            GenerationServicesInitDestroyProbe probe = default(GenerationServicesInitDestroyProbe);

            init(entity, ref probe);

            Assert.Equal(1, probe.InitCalls);
        }

        /// <summary>
        ///     Tests that register destroy registers delegate that invokes on destroy
        /// </summary>
        [Fact]
        public void RegisterDestroy_RegistersDelegateThatInvokesOnDestroy()
        {
            GenerationServices.RegisterDestroy<GenerationServicesInitDestroyProbe>();
            IDictionary cache = (IDictionary) typeof(GenerationServices)
                .GetField("TypeDestroyers", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            ComponentDelegates<GenerationServicesInitDestroyProbe>.DestroyDelegate destroy =
                (ComponentDelegates<GenerationServicesInitDestroyProbe>.DestroyDelegate) cache[typeof(GenerationServicesInitDestroyProbe)];

            GenerationServicesInitDestroyProbe probe = default(GenerationServicesInitDestroyProbe);
            destroy(ref probe);

            Assert.Equal(1, probe.DestroyCalls);
        }

        /// <summary>
        ///     The generation services probe attribute class
        /// </summary>
        /// <seealso cref="Attribute" />
        private sealed class GenerationServicesProbeAttribute : Attribute
        {
        }

        /// <summary>
        ///     The generation services probe component
        /// </summary>
        private struct GenerationServicesProbeComponent
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