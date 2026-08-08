// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryResetTest.cs
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
    ///     Tests for <see cref="Component.ResetForTests" /> and edge-case paths in <see cref="Component" />.
    /// </summary>
    public class ComponentRegistryResetTest
    {
        /// <summary>
        ///     Tests that after ResetForTests, RegisterComponent works and IDs are stable.
        /// </summary>
        [Fact] public void ResetForTests_ThenRegister_ResultsInStableIds()
        {
            Component.ResetForTests();

            Component.RegisterComponent<Uri>();
            ComponentId id1 = Component.GetComponentId(typeof(Uri));
            ComponentId id2 = Component.GetComponentId(typeof(Uri));

            Assert.Equal(id1, id2);
            Assert.True(id1.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that after ResetForTests, the void type is properly re-initialized.
        /// </summary>
        [Fact] public void ResetForTests_VoidType_IsReinitialized()
        {
            Component.ResetForTests();

            ComponentId voidId = Component.GetComponentId(typeof(void));

            Assert.True(voidId.RawIndex >= 0);
        }

        /// <summary>
        ///     Tests that after ResetForTests, component factory lookup still works for registered types.
        /// </summary>
        [Fact] public void ResetForTests_ThenRegister_FactoryIsAvailable()
        {
            Component.ResetForTests();

            Component.RegisterComponent<Version>();
            object factory = Component.GetComponentFactoryFromType(typeof(Version));

            Assert.NotNull(factory);
        }

        /// <summary>
        ///     Tests that GetExistingOrSetupNewComponent allocates new IDs after ResetForTests.
        /// </summary>
        [Fact] public void GetExistingOrSetupNewComponent_AfterReset_AllocatesFreshIds()
        {
            Component.ResetForTests();

            var result = Component.GetExistingOrSetupNewComponent<Guid>();

            Assert.NotEqual(default(ComponentId), result.ComponentID);
            Assert.True(result.ComponentID.RawIndex >= 0);
        }
    }
}
