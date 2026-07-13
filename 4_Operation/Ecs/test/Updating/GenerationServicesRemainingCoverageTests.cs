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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="GenerationServices" /> static methods.
    /// </summary>
    public partial class GenerationServicesRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="GenerationServices.RegisterInit{T}" /> stores a
        ///     delegate in the <c>TypeIniters</c> dictionary.
        /// </summary>
        [Fact]
        public void RegisterInit_StoresDelegate()
        {
            GenerationServices.RegisterInit<CoverageInitDestroyProbe>();

            IDictionary cache = (IDictionary)typeof(GenerationServices)
                .GetField("TypeIniters", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            Assert.True(cache.Contains(typeof(CoverageInitDestroyProbe)));
        }

        /// <summary>
        ///     Tests that <see cref="GenerationServices.RegisterDestroy{T}" /> stores a
        ///     delegate in the <c>TypeDestroyers</c> dictionary.
        /// </summary>
        [Fact]
        public void RegisterDestroy_StoresDelegate()
        {
            GenerationServices.RegisterDestroy<CoverageInitDestroyProbe>();

            IDictionary cache = (IDictionary)typeof(GenerationServices)
                .GetField("TypeDestroyers", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            Assert.True(cache.Contains(typeof(CoverageInitDestroyProbe)));
        }

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
        ///     Tests that <see cref="GenerationServices.RegisterUpdateMethodAttribute" />
        ///     adds a new entry to the <c>TypeAttributeCache</c> when the attribute type
        ///     has not been seen before.
        /// </summary>
        [Fact]
        public void RegisterUpdateMethodAttribute_NewAttribute_AddsToCache()
        {
            GenerationServices.RegisterUpdateMethodAttribute(typeof(CoverageProbeAttribute), typeof(CoverageInitDestroyProbe));

            IDictionary cache = (IDictionary)typeof(GenerationServices)
                .GetField("TypeAttributeCache", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            Assert.True(cache.Contains(typeof(CoverageProbeAttribute)));

            HashSet<Type> components = (HashSet<Type>)cache[typeof(CoverageProbeAttribute)];
            Assert.Contains(typeof(CoverageInitDestroyProbe), components);
            Assert.Single(components);
        }

        /// <summary>
        ///     Tests that <see cref="GenerationServices.RegisterUpdateMethodAttribute" />
        ///     appends to an existing entry in the <c>TypeAttributeCache</c>.
        /// </summary>
        [Fact]
        public void RegisterUpdateMethodAttribute_ExistingAttribute_AppendsComponent()
        {
            GenerationServices.RegisterUpdateMethodAttribute(typeof(CoverageProbeAttribute), typeof(CoverageInitDestroyProbe));
            GenerationServices.RegisterUpdateMethodAttribute(typeof(CoverageProbeAttribute), typeof(CoverageAnotherProbeComponent));

            IDictionary cache = (IDictionary)typeof(GenerationServices)
                .GetField("TypeAttributeCache", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null);

            HashSet<Type> components = (HashSet<Type>)cache[typeof(CoverageProbeAttribute)];
            Assert.Equal(2, components.Count);
            Assert.Contains(typeof(CoverageInitDestroyProbe), components);
            Assert.Contains(typeof(CoverageAnotherProbeComponent), components);
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
            public void OnInit(IGameObject self)
            {
            }

            public void OnDestroy()
            {
            }
        }

        /// <summary>
        ///     A second probe component type for testing.
        /// </summary>
        private struct CoverageAnotherProbeComponent;
    }
}
