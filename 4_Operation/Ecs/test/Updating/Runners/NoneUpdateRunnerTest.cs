// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NoneUpdateRunnerTest.cs
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

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests for <see cref="NoneUpdate{TComp}" /> and <see cref="NoneUpdateRunnerFactory{T}" />
    /// </summary>
    public class NoneUpdateRunnerTest
    {
        /// <summary>
        ///     Tests that none update can be created with capacity
        /// </summary>
        [Fact]
        public void ShouldCreateNoneUpdateWithCapacity()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);

            Assert.NotNull(storage);
            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that none update can be created with zero capacity
        /// </summary>
        [Fact]
        public void ShouldCreateNoneUpdateWithZeroCapacity()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(0);

            Assert.NotNull(storage);
            Assert.Equal(0, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that none update is assignable to component storage
        /// </summary>
        [Fact]
        public void ShouldBeAssignableFromComponentStorage()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            ComponentStorage<int> baseRef = storage;

            Assert.NotNull(baseRef);
        }

        /// <summary>
        ///     Tests that none update is assignable to component storage base
        /// </summary>
        [Fact]
        public void ShouldBeAssignableFromComponentStorageBase()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            ComponentStorageBase baseRef = storage;

            Assert.NotNull(baseRef);
        }

        /// <summary>
        ///     Tests that none update factory creates storage via base interface
        /// </summary>
        [Fact]
        public void ShouldCreateStorageViaBaseFactory()
        {
            NoneUpdateRunnerFactory<int> factory = new NoneUpdateRunnerFactory<int>();
            IComponentStorageBaseFactory baseFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(16);

            Assert.IsType<NoneUpdate<int>>(storage);
            Assert.Equal(16, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that none update factory creates strongly typed storage
        /// </summary>
        [Fact]
        public void ShouldCreateStronglyTypedStorage()
        {
            NoneUpdateRunnerFactory<int> factory = new NoneUpdateRunnerFactory<int>();
            IComponentStorageBaseFactory<int> typedFactory = factory;

            ComponentStorage<int> storage = typedFactory.CreateStronglyTyped(12);

            Assert.IsType<NoneUpdate<int>>(storage);
            Assert.Equal(12, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that none update factory creates id table
        /// </summary>
        [Fact]
        public void ShouldCreateIdTable()
        {
            NoneUpdateRunnerFactory<int> factory = new NoneUpdateRunnerFactory<int>();
            IComponentStorageBaseFactory baseFactory = factory;

            IdTable stack = baseFactory.CreateStack();

            Assert.IsType<IdTable<int>>(stack);
        }

        /// <summary>
        ///     Tests that none update factory forwards zero capacity
        /// </summary>
        [Fact]
        public void ShouldForwardZeroCapacity()
        {
            NoneUpdateRunnerFactory<string> factory = new NoneUpdateRunnerFactory<string>();
            IComponentStorageBaseFactory baseFactory = factory;
            IComponentStorageBaseFactory<string> typedFactory = factory;

            ComponentStorageBase storage = baseFactory.Create(0);
            ComponentStorage<string> strongStorage = typedFactory.CreateStronglyTyped(0);

            Assert.Equal(0, storage.Buffer.Length);
            Assert.Equal(0, strongStorage.Buffer.Length);
        }
    }
}
