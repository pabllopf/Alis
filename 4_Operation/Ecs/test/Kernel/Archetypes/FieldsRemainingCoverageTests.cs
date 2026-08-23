// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FieldsRemainingCoverageTests.cs
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

using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The fields remaining coverage tests class
    /// </summary>
    public class FieldsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that get component data reference with missing component throws
        /// </summary>
        [Fact]
        public void GetComponentDataReference_WithMissingComponent_Throws()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2});

                WorldArchetypeTableItem worldItem = Archetype<Position>.CreateNewOrGetExistingArchetypes(scene);
                Archetype arch = worldItem.Archetype;
                Fields fields = arch.Data;

                Assert.Throws<ComponentNotFoundException>(() => fields.GetComponentDataReference<Velocity>());
            }
        }
    }
}
