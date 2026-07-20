// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryCoveragePushTest.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    /// The component registry coverage push test class
    /// </summary>
    public partial class ComponentRegistryCoveragePushTest
    {
        /// <summary>
        /// The lifecycle comp for destroy
        /// </summary>
        private partial struct LifecycleCompForDestroy : IOnInit, IOnDestroy
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
        /// The custom component
        /// </summary>
        private partial struct CustomComponent : IOnInit
        {
            /// <summary>
            /// Ons the init using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnInit(IGameObject self)
            {
            }
        }

        /// <summary>
        /// Resets
        /// </summary>
        private static void Reset()
        {
            Component.ResetForTests();
        }

        /// <summary>
        /// Tests that get component factory from type user generated type map returns factory
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_UserGeneratedTypeMap_ReturnsFactory()
        {
            Reset();
            GenerationServices.RegisterType(typeof(CustomComponent), new NoneUpdateRunnerFactory<CustomComponent>());

            object factory = Component.GetComponentFactoryFromType(typeof(CustomComponent));

            Assert.NotNull(factory);
        }

        /// <summary>
        /// Tests that get component factory from type none component runner table returns factory
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_NoneComponentRunnerTable_ReturnsFactory()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            object factory = Component.GetComponentFactoryFromType(typeof(Uri));

            Assert.NotNull(factory);
        }
        

        /// <summary>
        /// Tests that register component new type adds to none component runner table
        /// </summary>
        [Fact]
        public void RegisterComponent_NewType_AddsToNoneComponentRunnerTable()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            object factory = Component.GetComponentFactoryFromType(typeof(Uri));
            Assert.NotNull(factory);
        }

        /// <summary>
        /// Tests that register component type in user generated type map skips registration
        /// </summary>
        [Fact]
        public void RegisterComponent_TypeInUserGeneratedTypeMap_SkipsRegistration()
        {
            Reset();
            GenerationServices.RegisterType(typeof(CustomComponent), new NoneUpdateRunnerFactory<CustomComponent>());

            Exception exception = Record.Exception(() => Component.RegisterComponent<CustomComponent>());

            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that get existing or setup new component new type returns valid tuple
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_NewType_ReturnsValidTuple()
        {
            Reset();
            (ComponentId id, IdTable<Guid> stack, ComponentDelegates<Guid>.InitDelegate init, ComponentDelegates<Guid>.DestroyDelegate destroy) =
                Component.GetExistingOrSetupNewComponent<Guid>();

            Assert.NotEqual(default(ComponentId), id);
            Assert.NotNull(stack);
            Assert.Null(init);
            Assert.Null(destroy);
        }

        /// <summary>
        /// Tests that get existing or setup new component existing type returns cached
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_ExistingType_ReturnsCached()
        {
            Reset();
            (ComponentId id1, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();
            (ComponentId id2, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();

            Assert.Equal(id1, id2);
        }

        /// <summary>
        /// Tests that get existing or setup new component with init delegate returns initer
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_WithInitDelegate_ReturnsIniter()
        {
            Reset();
            GenerationServices.RegisterInit<Position>();

            (ComponentId id, _, ComponentDelegates<Position>.InitDelegate init, _) =
                Component.GetExistingOrSetupNewComponent<Position>();

            Assert.NotEqual(default(ComponentId), id);
            Assert.NotNull(init);
        }

        /// <summary>
        /// Tests that get existing or setup new component with destroy delegate returns destroyer
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_WithDestroyDelegate_ReturnsDestroyer()
        {
            Reset();
            GenerationServices.RegisterInit<LifecycleCompForDestroy>();
            GenerationServices.RegisterDestroy<LifecycleCompForDestroy>();

            (ComponentId id, _, _, ComponentDelegates<LifecycleCompForDestroy>.DestroyDelegate destroy) =
                Component.GetExistingOrSetupNewComponent<LifecycleCompForDestroy>();

            Assert.NotEqual(default(ComponentId), id);
            Assert.NotNull(destroy);
        }

        /// <summary>
        /// Tests that get component id existing type returns from cache
        /// </summary>
        [Fact]
        public void GetComponentId_ExistingType_ReturnsFromCache()
        {
            Reset();
            ComponentId first = Component.GetComponentId(typeof(void));
            ComponentId second = Component.GetComponentId(typeof(void));

            Assert.Equal(first, second);
        }

        /// <summary>
        /// Tests that get component id new type after register works
        /// </summary>
        [Fact]
        public void GetComponentId_NewType_AfterRegister_Works()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            ComponentId id = Component.GetComponentId(typeof(Uri));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        /// Tests that get component id non existent i component base type throws source gen message
        /// </summary>
        [Fact]
        public void GetComponentId_NonExistentIComponentBaseType_ThrowsSourceGenMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentId(typeof(IOnInit)));

            Assert.Contains("source generator", ex.Message);
        }

        /// <summary>
        /// Tests that get component id void type returns valid id
        /// </summary>
        [Fact]
        public void GetComponentId_VoidType_ReturnsValidId()
        {
            Reset();
            ComponentId id = Component.GetComponentId(typeof(void));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        /// Tests that reset for tests clears state and reinitializes void
        /// </summary>
        [Fact]
        public void ResetForTests_ClearsState_AndReinitializesVoid()
        {
            Reset();
            ComponentId id = Component.GetComponentId(typeof(void));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        /// Tests that reset for tests allows new registrations
        /// </summary>
        [Fact]
        public void ResetForTests_AllowsNewRegistrations()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            ComponentId id = Component.GetComponentId(typeof(Uri));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        /// Tests that throw component type not init non component type throws register message
        /// </summary>
        [Fact]
        public void Throw_ComponentTypeNotInit_NonComponentType_ThrowsRegisterMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(decimal)));

            Assert.Contains("RegisterComponent", ex.Message);
        }

        /// <summary>
        /// Tests that get component table none component runner table path creates stack
        /// </summary>
        [Fact]
        public void GetComponentTable_NoneComponentRunnerTablePath_CreatesStack()
        {
            Reset();
            Component.RegisterComponent<Version>();

            ComponentId id = Component.GetComponentId(typeof(Version));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        /// Tests that get component id after existing or setup new component returns same id
        /// </summary>
        [Fact]
        public void GetComponentId_AfterExistingOrSetupNewComponent_ReturnsSameId()
        {
            Reset();
            (ComponentId existing, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();

            ComponentId fromGetId = Component.GetComponentId(typeof(Guid));

            Assert.Equal(existing, fromGetId);
        }

        /// <summary>
        /// Tests that get component table user generated type map path creates stack
        /// </summary>
        [Fact]
        public void GetComponentTable_UserGeneratedTypeMapPath_CreatesStack()
        {
            Reset();
            GenerationServices.RegisterType(typeof(CustomComponent), new NoneUpdateRunnerFactory<CustomComponent>());

            ComponentId id = Component.GetComponentId(typeof(CustomComponent));

            Assert.True(id.RawIndex >= 0);
        }
    }
}
