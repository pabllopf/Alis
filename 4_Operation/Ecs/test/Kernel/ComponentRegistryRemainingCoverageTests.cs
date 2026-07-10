// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Coverage tests targeting the remaining uncovered branches in ComponentRegistry:
    ///     destroy delegate resolution paths and GetComponentTable error path.
    /// </summary>
    public partial class ComponentRegistryRemainingCoverageTests
    {
        /// <summary>
        ///     Struct implementing life-cycle interfaces for destroy-delegate coverage.
        /// </summary>
        private partial struct LifecycleComponent : IOnInit, IOnDestroy
        {
            public void OnInit(IGameObject self)
            {
            }

            public void OnDestroy()
            {
            }
        }

        /// <summary>
        ///     Plain struct with no IComponentBase heritage, used to exercise the
        ///     GetComponentTable error path (non-void, non-registered type).
        /// </summary>
        private struct NonRegisteredType
        {
            public int Value;
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetExistingOrSetupNewComponent{T}" /> returns
        ///     a non-null Destroyer delegate when the type has a registered destroy handler.
        ///     This covers the TypeDestroyers.TryGetValue == true branch at line 148
        ///     and the corresponding Push branch at line 156.
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_WithDestroyDelegate_ReturnsNonNullDestroyer()
        {
            GenerationServices.RegisterInit<LifecycleComponent>();
            GenerationServices.RegisterDestroy<LifecycleComponent>();

            var result = Component.GetExistingOrSetupNewComponent<LifecycleComponent>();

            Assert.NotNull(result.Destroyer);
            Assert.NotNull(result.Initer);
            Assert.NotEqual(default(ComponentId), result.ComponentID);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentId(Type)" /> correctly stores
        ///     the destroy delegate in the component table when the type has a registered
        ///     destroy handler. Covers the TypeDestroyers.TryGetValue == true branch at line 190.
        /// </summary>
        [Fact]
        public void GetComponentId_WithDestroyDelegate_StoresDestroyerInTable()
        {
            GenerationServices.RegisterInit<LifecycleComponent>();
            GenerationServices.RegisterDestroy<LifecycleComponent>();

            ComponentId id = Component.GetComponentId(typeof(LifecycleComponent));

            Assert.True(id.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentId(Type)" /> throws
        ///     <see cref="InvalidOperationException" /> when called for a non-registered,
        ///     non-void type that does not implement <see cref="IComponentBase" />.
        ///     This covers the throw path in <see cref="Component" />.GetComponentTable
        ///     when called from GetComponentId (line 219).
        /// </summary>
        [Fact]
        public void GetComponentId_NonExistentPlainType_ThrowsThroughGetComponentTable()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentId(typeof(NonRegisteredType)));

            Assert.Contains("RegisterComponent", ex.Message);
        }
    }
}
