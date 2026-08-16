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
    ///     Tests the archetype id overflow guard by creating the maximum number of unique
    ///     archetypes and verifying the throw. The global counter is restored afterwards so
    ///     subsequent tests are unaffected.
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
            int originalBufferSize = GlobalWorldTables.ComponentTagTableBufferSize;
            bool threw = false;
            try
            {
                GlobalWorldTables.ComponentTagTableBufferSize = 128;
                int created = 0;
                int limit = 66000;
                for (int i = 0; i < 126 && created < limit; i++)
                {
                    for (int j = i + 1; j < 127 && created < limit; j++)
                    {
                        for (int k = j + 1; k < 128 && created < limit; k++)
                        {
                            ComponentId[] types =
                            {
                                new ComponentId((ushort) i),
                                new ComponentId((ushort) j),
                                new ComponentId((ushort) k)
                            };
                            try
                            {
                                Archetype.GetArchetypeId(types);
                            }
                            catch (InvalidOperationException ex)
                            {
                                threw = true;
                                Assert.Contains("65535", ex.Message);
                                break;
                            }

                            created++;
                        }

                        if (threw)
                        {
                            break;
                        }
                    }

                    if (threw)
                    {
                        break;
                    }
                }

                Assert.True(threw, "Expected the archetype overflow guard to throw");
            }
            finally
            {
                Archetype.NextArchetypeId = original;
                GlobalWorldTables.ComponentTagTableBufferSize = originalBufferSize;
            }
        }
    }
}
