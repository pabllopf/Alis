// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:ComponentRegistryExhaustionCoverageTests.cs
//
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
//
//  Copyright (c) 2021 GNU General Public License v3.0
//
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Covers the component-id exhaustion guards and the null-delegate fallback of
    ///     <see cref="Component" />. The id counter is moved to the limit through an
    ///     internal test seam because allocating 65535 distinct component types is not
    ///     feasible in a unit test; the original value is always restored.
    /// </summary>
    public partial class ComponentRegistryExhaustionCoverageTests
    {
        /// <summary>
        ///     Probe type used only by the GetExistingOrSetupNewComponent exhaustion test.
        /// </summary>
        private struct ExhaustionProbeByGeneric
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Probe type used only by the GetComponentId exhaustion test.
        /// </summary>
        private struct ExhaustionProbeByType
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Plain registered type with no life-cycle interfaces, used to exercise the
        ///     null initer/destroyer fallbacks in GetComponentId.
        /// </summary>
        private struct PlainRegisteredProbe
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Plain type that is never pre-registered through RegisterComponent, so
        ///     GetComponentId(Type) must create its entry and store null delegates.
        /// </summary>
        private struct DirectPlainProbe
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     Type with a registered init delegate but no component registration, so
        ///     GetComponentId(Type) stores the delegate through its non-null branch.
        /// </summary>
        private partial struct InitOnlyProbe : IOnInit
        {
            /// <summary>
            ///     Ons the init
            /// </summary>
            /// <param name="self">The owning game object</param>
            public void OnInit(IGameObject self)
            {
            }
        }

        /// <summary>
        ///     Registered type with a life-cycle destroy handler, used to exercise the
        ///     destroy-delegate branch of GetComponentId.
        /// </summary>
        private partial struct DestroyOnlyProbe : IOnDestroy
        {
            /// <summary>
            ///     Ons the destroy
            /// </summary>
            public void OnDestroy()
            {
            }
        }

        /// <summary>
        ///     Verifies that GetExistingOrSetupNewComponent rejects a new component once
        ///     the next id reaches ushort.MaxValue.
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_WhenIdLimitReached_Throws()
        {
            int original = Component.NextComponentIdForTests;
            try
            {
                Component.NextComponentIdForTests = ushort.MaxValue - 1;

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => Component.GetExistingOrSetupNewComponent<ExhaustionProbeByGeneric>());

                Assert.Contains("65535", ex.Message);
            }
            finally
            {
                Component.NextComponentIdForTests = original;
            }
        }

        /// <summary>
        ///     Verifies that GetComponentId rejects a new type once _nextComponentId is one
        ///     below ushort.MaxValue. The guard runs before any table mutation.
        /// </summary>
        [Fact]
        public void GetComponentId_WhenIdLimitReached_Throws()
        {
            int original = Component.NextComponentIdForTests;
            try
            {
                Component.NextComponentIdForTests = ushort.MaxValue - 1;

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                    () => Component.GetComponentId(typeof(ExhaustionProbeByType)));

                Assert.Contains("65535", ex.Message);
            }
            finally
            {
                Component.NextComponentIdForTests = original;
            }
        }

        /// <summary>
        ///     Verifies that a registered type without life-cycle delegates is stored with
        ///     null initer and destroyer. Existing tests only reach this path with
        ///     source-generated types that always provide both delegates.
        /// </summary>
        [Fact]
        public void GetComponentId_PlainRegisteredType_StoresNullDelegates()
        {
            Component.RegisterComponent<PlainRegisteredProbe>();

            ComponentId id = Component.GetComponentId(typeof(PlainRegisteredProbe));

            Assert.True(id.RawIndex >= 0);
            Assert.NotNull(Component.GetComponentFactoryFromType(typeof(PlainRegisteredProbe)));
            Assert.Null(Component.ComponentTable[id.RawIndex].Initer);
            Assert.Null(Component.ComponentTable[id.RawIndex].Destroyer);
        }

        /// <summary>
        ///     Verifies that GetComponentId(Type) creates an entry for a type that was not
        ///     pre-registered and stores null initer/destroyer delegates for it.
        /// </summary>
        [Fact]
        public void GetComponentId_UnregisteredPlainType_StoresNullDelegates()
        {
            GenerationServices.RegisterType(typeof(DirectPlainProbe), new NoneUpdateRunnerFactory<DirectPlainProbe>());

            ComponentId id = Component.GetComponentId(typeof(DirectPlainProbe));

            Assert.True(id.RawIndex >= 0);
            Assert.NotNull(Component.GetComponentFactoryFromType(typeof(DirectPlainProbe)));
            Assert.Null(Component.ComponentTable[id.RawIndex].Initer);
            Assert.Null(Component.ComponentTable[id.RawIndex].Destroyer);
        }

        /// <summary>
        ///     Verifies that GetComponentId(Type) stores a registered init delegate when
        ///     the type has not been registered as a component yet.
        /// </summary>
        [Fact]
        public void GetComponentId_TypeWithInitDelegate_StoresInitDelegate()
        {
            GenerationServices.RegisterInit<InitOnlyProbe>();
            GenerationServices.RegisterType(typeof(InitOnlyProbe), new NoneUpdateRunnerFactory<InitOnlyProbe>());

            ComponentId id = Component.GetComponentId(typeof(InitOnlyProbe));

            Assert.NotNull(Component.ComponentTable[id.RawIndex].Initer);
            Assert.Null(Component.ComponentTable[id.RawIndex].Destroyer);
        }

        /// <summary>
        ///     Verifies that a registered type with a destroy handler is stored with that
        ///     delegate by GetComponentId.
        /// </summary>
        [Fact]
        public void GetComponentId_RegisteredTypeWithDestroyer_StoresDestroyDelegate()
        {
            GenerationServices.RegisterDestroy<DestroyOnlyProbe>();
            Component.RegisterComponent<DestroyOnlyProbe>();

            ComponentId id = Component.GetComponentId(typeof(DestroyOnlyProbe));

            Assert.True(id.RawIndex >= 0);
            Assert.NotNull(Component.ComponentTable[id.RawIndex].Destroyer);
        }
    }
}
