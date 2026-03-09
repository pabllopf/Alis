// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateRunnerFactoryTest.cs
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
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests for all UpdateRunnerFactory generic arities.
    /// </summary>
    public class UpdateRunnerFactoryTest
    {
        [Fact]
        public void UpdateRunnerFactory_Arity0_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp0>();
            AssertFactoryMapping<UpdateComp0>(factory, factory, 6, typeof(Update<UpdateComp0>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity1_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp1, Arg1>();
            AssertFactoryMapping<UpdateComp1>(factory, factory, 6, typeof(GameObjectUpdate<UpdateComp1, Arg1>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity2_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp2, Arg1, Arg2>();
            AssertFactoryMapping<UpdateComp2>(factory, factory, 6, typeof(Update<UpdateComp2, Arg1, Arg2>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity3_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3>();
            AssertFactoryMapping<UpdateComp3>(factory, factory, 6, typeof(Update<UpdateComp3, Arg1, Arg2, Arg3>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity4_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4>();
            AssertFactoryMapping<UpdateComp4>(factory, factory, 6, typeof(Update<UpdateComp4, Arg1, Arg2, Arg3, Arg4>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity5_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5>();
            AssertFactoryMapping<UpdateComp5>(factory, factory, 6, typeof(EntityUpdate<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity6_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>();
            AssertFactoryMapping<UpdateComp6>(factory, factory, 6, typeof(Update<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity7_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>();
            AssertFactoryMapping<UpdateComp7>(factory, factory, 6, typeof(Update<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>));
        }

        [Fact]
        public void UpdateRunnerFactory_Arity8_CreatesExpectedTypes()
        {
            var factory = new UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>();
            AssertFactoryMapping<UpdateComp8>(factory, factory, 6, typeof(Update<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(32)]
        public void UpdateRunnerFactory_Arity0_ForwardsCapacity(int capacity)
        {
            var factory = new UpdateRunnerFactory<UpdateComp0>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp0> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp0> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(21)]
        public void UpdateRunnerFactory_Arity8_ForwardsCapacity(int capacity)
        {
            var factory = new UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp8> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp8> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        private static void AssertFactoryMapping<TComp>(
            IComponentStorageBaseFactory baseFactory,
            IComponentStorageBaseFactory<TComp> typedFactory,
            int capacity,
            Type expectedStorageType)
        {
            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<TComp> strongStorage = typedFactory.CreateStronglyTyped(capacity);
            IdTable stack = baseFactory.CreateStack();

            Assert.Equal(expectedStorageType, storage.GetType());
            Assert.Equal(expectedStorageType, strongStorage.GetType());
            Assert.IsType<IdTable<TComp>>(stack);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
            Assert.IsAssignableFrom<ComponentStorage<TComp>>(storage);
        }

        public struct Arg1;
        public struct Arg2;
        public struct Arg3;
        public struct Arg4;
        public struct Arg5;
        public struct Arg6;
        public struct Arg7;
        public struct Arg8;

        public struct UpdateComp0 : IOnUpdate
        {
            public void OnUpdate(IGameObject self) { }
        }

        public struct UpdateComp1 : IOnUpdate<Arg1>
        {
            public void Update(IGameObject self, ref Arg1 arg) { }
        }

        public struct UpdateComp2 : IOnUpdate<Arg1, Arg2>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2) { }
        }

        public struct UpdateComp3 : IOnUpdate<Arg1, Arg2, Arg3>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3) { }
        }

        public struct UpdateComp4 : IOnUpdate<Arg1, Arg2, Arg3, Arg4>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4) { }
        }

        public struct UpdateComp5 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5) { }
        }

        public struct UpdateComp6 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5, ref Arg6 arg6) { }
        }

        public struct UpdateComp7 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5, ref Arg6 arg6, ref Arg7 arg7) { }
        }

        public struct UpdateComp8 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>
        {
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5, ref Arg6 arg6, ref Arg7 arg7, ref Arg8 arg8) { }
        }
    }
}

