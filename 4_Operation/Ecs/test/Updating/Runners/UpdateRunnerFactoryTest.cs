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
        /// Tests that update runner factory arity 0 create forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(32)]
        public void UpdateRunnerFactory_Arity0_Create_ForwardsCapacity(int capacity)
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
        /// Tests that update runner factory arity 0 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity0_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp0> factory = new UpdateRunnerFactory<UpdateComp0>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp0>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 1 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(21)]
        public void UpdateRunnerFactory_Arity1_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp1, Arg1> factory = new UpdateRunnerFactory<UpdateComp1, Arg1>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp1> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp1> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 1 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity1_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp1, Arg1> factory = new UpdateRunnerFactory<UpdateComp1, Arg1>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp1>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 2 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(7)]
        [InlineData(15)]
        public void UpdateRunnerFactory_Arity2_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp2, Arg1, Arg2> factory = new UpdateRunnerFactory<UpdateComp2, Arg1, Arg2>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp2> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp2> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 2 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity2_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp2, Arg1, Arg2> factory = new UpdateRunnerFactory<UpdateComp2, Arg1, Arg2>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp2>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 3 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(42)]
        public void UpdateRunnerFactory_Arity3_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3> factory = new UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp3> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp3> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 3 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity3_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3> factory = new UpdateRunnerFactory<UpdateComp3, Arg1, Arg2, Arg3>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp3>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 4 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(8)]
        [InlineData(64)]
        public void UpdateRunnerFactory_Arity4_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4> factory = new UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp4> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp4> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 4 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity4_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4> factory = new UpdateRunnerFactory<UpdateComp4, Arg1, Arg2, Arg3, Arg4>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp4>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 5 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(99)]
        public void UpdateRunnerFactory_Arity5_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5> factory = new UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp5> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp5> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 5 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity5_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5> factory = new UpdateRunnerFactory<UpdateComp5, Arg1, Arg2, Arg3, Arg4, Arg5>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp5>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 6 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(12)]
        [InlineData(50)]
        public void UpdateRunnerFactory_Arity6_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6> factory = new UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp6> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp6> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 6 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity6_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6> factory = new UpdateRunnerFactory<UpdateComp6, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp6>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 7 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(128)]
        public void UpdateRunnerFactory_Arity7_ForwardsCapacity(int capacity)
        {
            UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7> factory = new UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<UpdateComp7> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(capacity);
            ComponentStorage<UpdateComp7> strongStorage = typedFactory.CreateStronglyTyped(capacity);

            Assert.Equal(capacity, storage.Buffer.Length);
            Assert.Equal(capacity, strongStorage.Buffer.Length);
        }

        /// <summary>
        /// Tests that update runner factory arity 7 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity7_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7> factory = new UpdateRunnerFactory<UpdateComp7, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp7>>(stack);
        }

        /// <summary>
        /// Tests that update runner factory arity 8 forwards capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(21)]
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
        /// Tests that update runner factory arity 8 create stack returns id table
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_Arity8_CreateStack_ReturnsIdTable()
        {
            UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8> factory = new UpdateRunnerFactory<UpdateComp8, Arg1, Arg2, Arg3, Arg4, Arg5, Arg6, Arg7, Arg8>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.NotNull(stack);
            Assert.IsType<IdTable<UpdateComp8>>(stack);
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
