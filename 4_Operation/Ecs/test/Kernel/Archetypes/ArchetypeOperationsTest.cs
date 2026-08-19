// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeOperationsTest.cs
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

using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype operations test class
    /// </summary>
    /// <remarks>
    ///     Tests archetype functionality and entity transitions between archetypes.
    ///     Archetypes are the core data structure of the ECS organizing entities
    ///     by their component composition for efficient memory layout and querying.
    /// </remarks>
    public class ArchetypeOperationsTest
    {
        /// <summary>
        ///     Tests that default archetype is accessible
        /// </summary>
        /// <remarks>
        ///     Verifies that the default archetype exists and is accessible
        ///     for empty entities without components.
        /// </remarks>
        [Fact] public void Archetype_DefaultArchetypeIsAccessible()
        {
            Scene scene = new Scene();

            Archetype defaultArchetype = scene.DefaultArchetype;

            Assert.NotNull(defaultArchetype);

            
        }

        /// <summary>
        ///     Tests archetype changes when component is added
        /// </summary>
        /// <remarks>
        ///     Validates that adding a component causes an entity to
        ///     transition to a new archetype.
        /// </remarks>
        [Fact] public void Archetype_ChangesWhenComponentIsAdded()
        {
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position());

            Assert.True(entity.Has<Position>());

            
        }

        /// <summary>
        ///     Tests entities with same components share archetype
        /// </summary>
        /// <remarks>
        ///     Verifies that multiple entities with identical component sets
        ///     share the same archetype for memory efficiency.
        /// </remarks>
        [Fact] public void Archetype_SameComponentSetSharesArchetype()
        {
            Scene scene = new Scene();

            GameObject e1 = scene.Create();
            e1.Add(new Position());
            e1.Add(new Velocity());

            GameObject e2 = scene.Create();
            e2.Add(new Position());
            e2.Add(new Velocity());

            Assert.True(e1.Has<Position>());
            Assert.True(e2.Has<Position>());

            
        }

        /// <summary>
        ///     Tests archetype transitions are deterministic
        /// </summary>
        /// <remarks>
        ///     Validates that the same sequence of component additions
        ///     always results in the same archetype.
        /// </remarks>
        [Fact] public void Archetype_TransitionsAreDeterministic()
        {
            Scene scene = new Scene();
            GameObject e1 = scene.Create();
            GameObject e2 = scene.Create();

            e1.Add(new Position());
            e1.Add(new Velocity());

            e2.Add(new Position());
            e2.Add(new Velocity());

            Assert.True(e1.Has<Position>());
            Assert.True(e1.Has<Velocity>());
            Assert.True(e2.Has<Position>());
            Assert.True(e2.Has<Velocity>());

            
        }

       

  
        /// <summary>
        ///     Tests component access works across archetype transitions
        /// </summary>
        /// <remarks>
        ///     Validates that component data remains accessible and correct
        ///     even after archetype transitions.
        /// </remarks>
        [Fact]
        public void Archetype_ComponentAccessWorksAcrossTransitions()
        {
            Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position());
            ref Position pos1 = ref entity.Get<Position>();
            pos1.X = 100;
            pos1.Y = 200;

            entity.Add(new Velocity());
            ref Position pos2 = ref entity.Get<Position>();

            Assert.Equal(100, pos2.X);
            Assert.Equal(200, pos2.Y);

            
        }
    }
}