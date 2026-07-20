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
    public partial class ComponentRegistryCoveragePushTest
    {
        private partial struct LifecycleCompForDestroy : IOnInit, IOnDestroy
        {
            public void OnInit(IGameObject self)
            {
            }

            public void OnDestroy()
            {
            }
        }

        private partial struct CustomComponent : IOnInit
        {
            public void OnInit(IGameObject self)
            {
            }
        }

        private static void Reset()
        {
            Component.ResetForTests();
        }

        [Fact]
        public void GetComponentFactoryFromType_UserGeneratedTypeMap_ReturnsFactory()
        {
            Reset();
            GenerationServices.RegisterType(typeof(CustomComponent), new NoneUpdateRunnerFactory<CustomComponent>());

            object factory = Component.GetComponentFactoryFromType(typeof(CustomComponent));

            Assert.NotNull(factory);
        }

        [Fact]
        public void GetComponentFactoryFromType_NoneComponentRunnerTable_ReturnsFactory()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            object factory = Component.GetComponentFactoryFromType(typeof(Uri));

            Assert.NotNull(factory);
        }

        [Fact]
        public void GetComponentFactoryFromType_IComponentBaseType_ThrowsSourceGenMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(IOnInit)));

            Assert.Contains("source generator", ex.Message);
        }

        [Fact]
        public void RegisterComponent_NewType_AddsToNoneComponentRunnerTable()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            object factory = Component.GetComponentFactoryFromType(typeof(Uri));
            Assert.NotNull(factory);
        }

        [Fact]
        public void RegisterComponent_TypeInUserGeneratedTypeMap_SkipsRegistration()
        {
            Reset();
            GenerationServices.RegisterType(typeof(CustomComponent), new NoneUpdateRunnerFactory<CustomComponent>());

            Exception exception = Record.Exception(() => Component.RegisterComponent<CustomComponent>());

            Assert.Null(exception);
        }

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

        [Fact]
        public void GetExistingOrSetupNewComponent_ExistingType_ReturnsCached()
        {
            Reset();
            (ComponentId id1, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();
            (ComponentId id2, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();

            Assert.Equal(id1, id2);
        }

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

        [Fact]
        public void GetComponentId_ExistingType_ReturnsFromCache()
        {
            Reset();
            ComponentId first = Component.GetComponentId(typeof(void));
            ComponentId second = Component.GetComponentId(typeof(void));

            Assert.Equal(first, second);
        }

        [Fact]
        public void GetComponentId_NewType_AfterRegister_Works()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            ComponentId id = Component.GetComponentId(typeof(Uri));

            Assert.True(id.RawIndex >= 0);
        }

        [Fact]
        public void GetComponentId_NonExistentPlainType_ThrowsRegisterMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentId(typeof(string)));

            Assert.Contains("RegisterComponent", ex.Message);
        }

        [Fact]
        public void GetComponentId_NonExistentIComponentBaseType_ThrowsSourceGenMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentId(typeof(IOnInit)));

            Assert.Contains("source generator", ex.Message);
        }

        [Fact]
        public void GetComponentId_VoidType_ReturnsValidId()
        {
            Reset();
            ComponentId id = Component.GetComponentId(typeof(void));

            Assert.True(id.RawIndex >= 0);
        }

        [Fact]
        public void ResetForTests_ClearsState_AndReinitializesVoid()
        {
            Reset();
            ComponentId id = Component.GetComponentId(typeof(void));

            Assert.True(id.RawIndex >= 0);
        }

        [Fact]
        public void ResetForTests_AllowsNewRegistrations()
        {
            Reset();
            Component.RegisterComponent<Uri>();

            ComponentId id = Component.GetComponentId(typeof(Uri));

            Assert.True(id.RawIndex >= 0);
        }

        [Fact]
        public void Throw_ComponentTypeNotInit_NonComponentType_ThrowsRegisterMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(decimal)));

            Assert.Contains("RegisterComponent", ex.Message);
        }

        [Fact]
        public void Throw_ComponentTypeNotInit_IComponentBaseInterface_ThrowsSourceGenMessage()
        {
            Reset();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(IOnInit)));

            Assert.Contains("source generator", ex.Message);
        }

        [Fact]
        public void GetComponentTable_NoneComponentRunnerTablePath_CreatesStack()
        {
            Reset();
            Component.RegisterComponent<Version>();

            ComponentId id = Component.GetComponentId(typeof(Version));

            Assert.True(id.RawIndex >= 0);
        }

        [Fact]
        public void GetComponentId_AfterExistingOrSetupNewComponent_ReturnsSameId()
        {
            Reset();
            (ComponentId existing, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();

            ComponentId fromGetId = Component.GetComponentId(typeof(Guid));

            Assert.Equal(existing, fromGetId);
        }

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
