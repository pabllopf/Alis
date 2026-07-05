// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryExtendedTest.cs
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
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests the <see cref="Component" /> class, covering registration, factory resolution,
    ///     and exception paths.
    /// </summary>
    public class ComponentRegistryExtendedTest
    {
        /// <summary>
        ///     Tests that <see cref="Component.GetComponentId" /> succeeds for the void type
        ///     which is initialized by the static constructor.
        /// </summary>
        [Fact]
        public void GetComponentId_VoidType_Succeeds()
        {
            ComponentId id = Component.GetComponentId(typeof(void));

            Assert.NotNull(id);
        }

        /// <summary>
        ///     Tests that <see cref="Component.RegisterComponent{T}" /> registers a non-component
        ///     type without throwing.
        /// </summary>
        [Fact]
        public void RegisterComponent_NonComponentType_DoesNotThrow()
        {
            Exception exception = Record.Exception(() => Component.RegisterComponent<Uri>());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that after <see cref="Component.RegisterComponent{T}" />, the factory for
        ///     the type can be resolved and is non-null.
        /// </summary>
        [Fact]
        public void RegisterComponent_ThenGetFactory_ReturnsFactory()
        {
            Component.RegisterComponent<DayOfWeek>();

            object factory = Component.GetComponentFactoryFromType(typeof(DayOfWeek));

            Assert.NotNull(factory);
        }

        /// <summary>
        ///     Tests that <see cref="Component.RegisterComponent{T}" /> can be called multiple
        ///     times for the same type without throwing.
        /// </summary>
        [Fact]
        public void RegisterComponent_SameTypeTwice_DoesNotThrow()
        {
            Component.RegisterComponent<decimal>();

            Exception exception = Record.Exception(() => Component.RegisterComponent<decimal>());

            Assert.Null(exception);
        }
        
        /// <summary>
        ///     Tests that <see cref="Component.GetExistingOrSetupNewComponent{T}" /> returns
        ///     a valid tuple for a newly requested component type.
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_NewType_ReturnsValidTuple()
        {
            (ComponentId id, _, _, _) = Component.GetExistingOrSetupNewComponent<Guid>();

            Assert.NotEqual(default(ComponentId), id);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentFactoryFromType" /> throws
        ///     for the void type (no factory exists for void).
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_VoidType_ThrowsInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(void)));
        }
    }
}
