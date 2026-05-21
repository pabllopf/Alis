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
        /// <summary>
        ///     Tests that update runner factory arity 0 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity0_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp0> factory = new UpdateRunnerFactory<UpdateComp0>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp0>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 1 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity1_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp1, Arg1> factory = new UpdateRunnerFactory<UpdateComp1, Arg1>();
            AssertFactoryMapping(factory, factory, 6, typeof(GameObjectUpdate<UpdateComp1, Arg1>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 2 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity2_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp2, Arg1, Arg2> factory = new UpdateRunnerFactory<UpdateComp2, Arg1, Arg2>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp2, Arg1, Arg2>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 3 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity3_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3> factory = new UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp3, Arg1, Arg2, Arg3>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 4 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity4_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4> factory = new UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp4, Arg1, Arg2, Arg3, Arg4>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 5 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity5_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5> factory = new UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5>();
            AssertFactoryMapping(factory, factory, 6, typeof(EntityUpdate<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 6 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity6_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6> factory = new UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 7 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity7_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7> factory = new UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 8 creates expected types
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity8_CreatesExpectedTypes()
        {
            UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8> factory = new UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>();
            AssertFactoryMapping(factory, factory, 6, typeof(Update<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>));
        }

        /// <summary>
        ///     Tests that update runner factory arity 0 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory, InlineData(0), InlineData(1), InlineData(32)]
        public void UpdateRunnerFactory_Arity0_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp0> factory = new UpdateRunnerFactory<UpdateComp0>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp0> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp0> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that update runner factory arity 8 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory, InlineData(0), InlineData(5), InlineData(21)]
        public void UpdateRunnerFactory_Arity8_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8> factory = new UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp8> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp8> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        ///     Asserts the factory mapping using the specified base factory
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <param name="baseFactory">The base factory</param>
        /// <param name="typedFactory">The typed factory</param>
        /// <param name="capacity">The capacity</param>
        /// <param name="expectedStorageType">The expected storage type</param>
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

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg1;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg2;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg3;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg4;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg5;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg6;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg7;

        /// <summary>
        ///     The arg
        /// </summary>
        public struct Arg8;

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp0 : IOnUpdate
        {
            /// <summary>
            ///     Ons the update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnUpdate(IGameObject self)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp1 : IOnUpdate<Arg1>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp2 : IOnUpdate<Arg1, Arg2>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp3 : IOnUpdate<Arg1, Arg2, Arg3>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp4 : IOnUpdate<Arg1, Arg2, Arg3, Arg4>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp5 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp6 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5, ref Arg6 arg6)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp7 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            /// <param name="arg7">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5, ref Arg6 arg6, ref Arg7 arg7)
            {
            }
        }

        /// <summary>
        ///     The update comp
        /// </summary>
        public struct UpdateComp8 : IOnUpdate<Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>
        {
            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            /// <param name="arg7">The arg</param>
            /// <param name="arg8">The arg</param>
            public void Update(IGameObject self, ref Arg1 arg1, ref Arg2 arg2, ref Arg3 arg3, ref Arg4 arg4, ref Arg5 arg5, ref Arg6 arg6, ref Arg7 arg7, ref Arg8 arg8)
            {
            }
        }
    }
}