// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateArity9CoverageTests.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests the non-range Run of the arity 9 update runner.
    /// </summary>
    public class UpdateArity9CoverageTests
    {
        /// <summary>
        ///     Tests that the arity 9 non-range run processes entities with all eight arguments.
        /// </summary>
        [Fact]
        public void Update_Arity9_NonRangeRun_ProcessesEntities()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update9Comp { CallCount = 0 },
                new Position { X = 5, Y = 10 },
                new Velocity { X = 1, Y = 2 },
                new Health { Value = 100 },
                new Armor { Value = 30 },
                new Damage { Value = 7 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 5 }
            );
            entity.Add(new AnotherComponent { Data = 10, Y = 3 });

            ref GameObjectLocation location = ref entity.AssertIsAlive(out Scene sceneRef);
            Archetype archetype = location.Archetype;
            int idx = archetype.GetComponentIndex(Component<Update9Comp>.Id);
            ComponentStorageBase storage = archetype.Components[idx];

            storage.Run(sceneRef, archetype);

            Assert.Equal(1, entity.Get<Update9Comp>().CallCount);
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(12, entity.Get<Position>().Y);
        }
    }

    /// <summary>
    ///     Component for testing arity 9 Update
    /// </summary>
    internal struct Update9Comp : IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>
    {
        /// <summary>
        ///     The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        ///     Updates the self with all 8 arguments
        /// </summary>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health,
            ref Armor armor, ref Damage damage, ref Transform transform, ref TestComponent test, ref AnotherComponent another)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
            health.Value -= damage.Value;
            armor.Value = armor.Value + damage.Value + 1;
            damage.Value += 1;
            transform.Rotation += 2;
            test.Value += test.Value;
            another.Data += 1;
            another.Y += 1;
        }
    }
}
