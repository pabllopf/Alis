// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryFinalCoverageTest.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Final coverage push tests for <see cref="Component" /> targeting the remaining uncovered
    ///     factory-recreation path in <see cref="Component.ResetForTests" /> and other edge-case paths.
    /// </summary>
    public class ComponentRegistryFinalCoverageTest
    {
        /// <summary>
        ///     Tests that <see cref="Component.ResetForTests" /> recreates the NoneUpdateRunnerFactory
        ///     for a non-source-generated type that was present in the component ID table before the reset.
        ///     This exercises the inner-loop body in ResetForTests (MakeGenericType + Activator.CreateInstance).
        /// </summary>
        [Fact]
        public void ResetForTests_WithPreRegisteredPlainType_RecreatesFactory()
        {
            Component.RegisterComponent<Uri>();

            ComponentId before = Component.GetComponentId(typeof(Uri));

            Component.ResetForTests();

            ComponentId after = Component.GetComponentId(typeof(Uri));

            Assert.NotEqual(default(ComponentId), before);
            Assert.NotEqual(default(ComponentId), after);
            object factory = Component.GetComponentFactoryFromType(typeof(Uri));
            Assert.NotNull(factory);
        }

        /// <summary>
        ///     Tests that after <see cref="Component.ResetForTests" /> with multiple pre-registered
        ///     plain types, all their factories are correctly recreated and IDs stay unique.
        /// </summary>
        [Fact]
        public void ResetForTests_WithMultiplePreRegisteredPlainTypes_AllFactoriesRecreated()
        {
            Component.RegisterComponent<DayOfWeek>();
            Component.RegisterComponent<Version>();

            ComponentId dayOfWeekBefore = Component.GetComponentId(typeof(DayOfWeek));
            ComponentId versionBefore = Component.GetComponentId(typeof(Version));

            Component.ResetForTests();

            ComponentId dayOfWeekAfter = Component.GetComponentId(typeof(DayOfWeek));
            ComponentId versionAfter = Component.GetComponentId(typeof(Version));

            Assert.True(dayOfWeekBefore.RawIndex >= 0);
            Assert.True(versionBefore.RawIndex >= 0);
            Assert.True(dayOfWeekAfter.RawIndex >= 0);
            Assert.True(versionAfter.RawIndex >= 0);
            Assert.NotEqual(dayOfWeekAfter, versionAfter);

            object dayOfWeekFactory = Component.GetComponentFactoryFromType(typeof(DayOfWeek));
            object versionFactory = Component.GetComponentFactoryFromType(typeof(Version));
            Assert.NotNull(dayOfWeekFactory);
            Assert.NotNull(versionFactory);
        }

        /// <summary>
        ///     Tests that <see cref="Component.ResetForTests" /> preserves the factory for
        ///     source-generated types that remain in the table after reset.
        ///     The inner-loop skips types present in <see cref="GenerationServices.UserGeneratedTypeMap" />.
        /// </summary>
        [Fact]
        public void ResetForTests_SourceGeneratedTypesPreserved()
        {
            object factoryBefore = Component.GetComponentFactoryFromType(typeof(Position));

            Component.ResetForTests();

            object factoryAfter = Component.GetComponentFactoryFromType(typeof(Position));

            Assert.NotNull(factoryBefore);
            Assert.NotNull(factoryAfter);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentId" /> called for void type
        ///     after ResetForTests with other types still returns valid ID.
        /// </summary>
        [Fact]
        public void ResetForTests_VoidTypeAfterPreRegistration_ReturnsValidId()
        {
            Component.RegisterComponent<Guid>();
            ComponentId voidBefore = Component.GetComponentId(typeof(void));

            Component.ResetForTests();

            ComponentId voidAfter = Component.GetComponentId(typeof(void));
            Assert.Equal(voidBefore, voidAfter);
            Assert.True(voidAfter.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentFactoryFromType" /> returns
        ///     non-null factory for a plain type after going through
        ///     <see cref="Component.RegisterComponent{T}" /> twice with reset in between.
        /// </summary>
        [Fact]
        public void RegisterComponent_ThenReset_ThenRegisterAgain_ReturnsFactory()
        {
            Component.RegisterComponent<Decimal>();
            Component.ResetForTests();
            Component.RegisterComponent<Decimal>();

            object factory = Component.GetComponentFactoryFromType(typeof(Decimal));
            Assert.NotNull(factory);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetExistingOrSetupNewComponent{T}" /> works
        ///     after a full reset cycle and the returned ID has valid raw index.
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_AfterResetCycle_ReturnsValidId()
        {
            Component.RegisterComponent<Uri>();
            Component.ResetForTests();

            (ComponentId ComponentID, IdTable<Uri> Stack, ComponentDelegates<Uri>.InitDelegate Initer, ComponentDelegates<Uri>.DestroyDelegate Destroyer) result = Component.GetExistingOrSetupNewComponent<Uri>();
            Assert.True(result.ComponentID.RawIndex >= 0);
            Assert.NotNull(result.Stack);
            Assert.Null(result.Initer);
            Assert.Null(result.Destroyer);
        }

        /// <summary>
        ///     Tests that calling <see cref="Component.ResetForTests" /> multiple times
        ///     is idempotent and state remains consistent.
        /// </summary>
        [Fact]
        public void ResetForTests_MultipleCalls_IsIdempotent()
        {
            Component.RegisterComponent<Version>();
            Component.RegisterComponent<Decimal>();

            Component.ResetForTests();
            Component.ResetForTests();
            Component.ResetForTests();

            ComponentId versionId = Component.GetComponentId(typeof(Version));
            Assert.True(versionId.RawIndex >= 0);

            object versionFactory = Component.GetComponentFactoryFromType(typeof(Version));
            Assert.NotNull(versionFactory);
        }

        /// <summary>
        ///     Tests that after <see cref="Component.ResetForTests" /> with pre-registered type,
        ///     a subsequent <see cref="Component.RegisterComponent{T}" /> followed by
        ///     <see cref="Component.GetComponentId" /> returns the same ID for the same type.
        /// </summary>
        [Fact]
        public void ResetForTests_WithPreRegisteredType_ThenRegister_ReturnsStableId()
        {
            Component.RegisterComponent<Uri>();
            Component.ResetForTests();
            Component.RegisterComponent<Uri>();

            ComponentId id1 = Component.GetComponentId(typeof(Uri));
            ComponentId id2 = Component.GetComponentId(typeof(Uri));
            Assert.Equal(id1, id2);
        }

        /// <summary>
        ///     Tests that the factory path through
        ///     <see cref="Component.GetComponentFactoryFromType" /> for a type that is
        ///     only in NoneComponentRunnerTable (not in UserGeneratedTypeMap) correctly
        ///     returns after factory recreation in ResetForTests.
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_AfterResetWithNoneComponentType_ReturnsFactory()
        {
            Component.RegisterComponent<DayOfWeek>();
            Component.ResetForTests();

            object factory = Component.GetComponentFactoryFromType(typeof(DayOfWeek));

            Assert.NotNull(factory);
        }
    }
}
