// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeOverflowCoverageTests.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests the archetype id overflow guard. The global counter is advanced directly so the
    ///     guard can be exercised without allocating tens of thousands of archetypes (which would
    ///     permanently pollute the process-wide archetype tables), and it is restored afterwards.
    /// </summary>
    public class ArchetypeOverflowCoverageTests
    {
        /// <summary>
        ///     Tests that get archetype id throws when the maximum unique archetype count is exceeded.
        /// </summary>
        [Fact]
        public void GetArchetypeId_WhenExceedingMaxArchetypeCount_Throws()
        {
            int original = Archetype.NextArchetypeId;
            try
            {
                Archetype.NextArchetypeId = ushort.MaxValue - 1;

                ComponentId[] types =
                {
                    new ComponentId((ushort) (ushort.MaxValue - 3)),
                    new ComponentId((ushort) (ushort.MaxValue - 2)),
                    new ComponentId((ushort) (ushort.MaxValue - 1))
                };

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => Archetype.GetArchetypeId(types));
                Assert.Contains("65535", ex.Message);
            }
            finally
            {
                Archetype.NextArchetypeId = original;
            }
        }
    }
}
