// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateRunnerFactoryCoverageTests.cs
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
    ///     The update runner factory coverage tests class
    /// </summary>
    public class UpdateRunnerFactoryCoverageTests
    {
        /// <summary>
        ///     Tests that the arity 0 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity0_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 0 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity0_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 0 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity0_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 1 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity1_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 1 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity1_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 1 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity1_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 2 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity2_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 2 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity2_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 2 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity2_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 3 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity3_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 3 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity3_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 3 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity3_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 4 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity4_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 4 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity4_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 4 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity4_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 5 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity5_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 5 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity5_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 5 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity5_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 6 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity6_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 6 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity6_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 6 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity6_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 7 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity7_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 7 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity7_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 7 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity7_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }

        /// <summary>
        ///     Tests that the arity 8 factory creates a component storage base
        /// </summary>
        [Fact]
        public void Arity8_Create_ReturnsComponentStorageBase()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int, int, int>();

            Assert.NotNull(factory.Create(8));
        }

        /// <summary>
        ///     Tests that the arity 8 factory creates a stack
        /// </summary>
        [Fact]
        public void Arity8_CreateStack_ReturnsIdTable()
        {
            IComponentStorageBaseFactory factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStack());
        }

        /// <summary>
        ///     Tests that the arity 8 factory creates a strongly typed storage
        /// </summary>
        [Fact]
        public void Arity8_CreateStronglyTyped_ReturnsComponentStorage()
        {
            IComponentStorageBaseFactory<AllArityComp> factory = new UpdateRunnerFactory<AllArityComp, int, int, int, int, int, int, int, int>();

            Assert.NotNull(factory.CreateStronglyTyped(8));
        }
    }

    /// <summary>
    ///     A component implementing all update arities from zero to eight.
    /// </summary>
    internal struct AllArityComp : IOnUpdate,
        IOnUpdate<int>,
        IOnUpdate<int, int>,
        IOnUpdate<int, int, int>,
        IOnUpdate<int, int, int, int>,
        IOnUpdate<int, int, int, int, int>,
        IOnUpdate<int, int, int, int, int, int>,
        IOnUpdate<int, int, int, int, int, int, int>,
        IOnUpdate<int, int, int, int, int, int, int, int>
    {
        /// <summary>
        ///     Updates the self with zero arguments
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
        }

        /// <summary>
        ///     Updates the self with one argument
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        public void Update(IGameObject self, ref int arg1)
        {
        }

        /// <summary>
        ///     Updates the self with two arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2)
        {
        }

        /// <summary>
        ///     Updates the self with three arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        /// <param name="arg3">The arg3</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2, ref int arg3)
        {
        }

        /// <summary>
        ///     Updates the self with four arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        /// <param name="arg3">The arg3</param>
        /// <param name="arg4">The arg4</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2, ref int arg3, ref int arg4)
        {
        }

        /// <summary>
        ///     Updates the self with five arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        /// <param name="arg3">The arg3</param>
        /// <param name="arg4">The arg4</param>
        /// <param name="arg5">The arg5</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5)
        {
        }

        /// <summary>
        ///     Updates the self with six arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        /// <param name="arg3">The arg3</param>
        /// <param name="arg4">The arg4</param>
        /// <param name="arg5">The arg5</param>
        /// <param name="arg6">The arg6</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6)
        {
        }

        /// <summary>
        ///     Updates the self with seven arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        /// <param name="arg3">The arg3</param>
        /// <param name="arg4">The arg4</param>
        /// <param name="arg5">The arg5</param>
        /// <param name="arg6">The arg6</param>
        /// <param name="arg7">The arg7</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7)
        {
        }

        /// <summary>
        ///     Updates the self with eight arguments
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg1</param>
        /// <param name="arg2">The arg2</param>
        /// <param name="arg3">The arg3</param>
        /// <param name="arg4">The arg4</param>
        /// <param name="arg5">The arg5</param>
        /// <param name="arg6">The arg6</param>
        /// <param name="arg7">The arg7</param>
        /// <param name="arg8">The arg8</param>
        public void Update(IGameObject self, ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7, ref int arg8)
        {
        }
    }
}
