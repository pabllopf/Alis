// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateTests.cs
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
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Additional coverage tests for <c>Update.cs</c> runner classes.
    ///     Targets the remaining uncovered lines including arity 8 range-based Run.
    /// </summary>
    public class UpdateTests
    {
        #region Arity 8 Range Run via Direct Archetype Access

        /// <summary>
        ///     Tests that arity 8 range-based Run executes correctly when the
        ///     archetype contains all required component types.
        /// </summary>
        [Fact]
        public void Update_Arity8_RangeRun_WithValidArchetype_ProcessesEntities()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update8Comp { CallCount = 0 },
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
            int idx = archetype.GetComponentIndex(Component<Update8Comp>.Id);
            ComponentStorageBase storage = archetype.Components[idx];

            storage.Run(sceneRef, archetype, 0, archetype.EntityCount);

            Assert.Equal(1, entity.Get<Update8Comp>().CallCount);
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(12, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that arity 8 range Run with zero length does not throw.
        /// </summary>
        [Fact]
        public void Update_Arity8_RangeRun_ZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update8Comp { CallCount = 0 },
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42 }
            );
            entity.Add(new AnotherComponent { Data = 10, Y = 3 });

            ref GameObjectLocation location = ref entity.AssertIsAlive(out Scene sceneRef);
            Archetype archetype = location.Archetype;
            int idx = archetype.GetComponentIndex(Component<Update8Comp>.Id);
            ComponentStorageBase storage = archetype.Components[idx];

            storage.Run(sceneRef, archetype, 0, 0);

            Assert.Equal(0, entity.Get<Update8Comp>().CallCount);
        }

        /// <summary>
        ///     Tests that arity 8 Run with start offset processes only the
        ///     target entities.
        /// </summary>
        [Fact]
        public void Update_Arity8_RangeRun_WithStartOffset_ProcessesOnlyTargetEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Update8Comp { CallCount = 0 },
                new Position { X = 0, Y = 0 },
                new Velocity { X = 1, Y = 1 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 1 }
            );
            entity1.Add(new AnotherComponent { Data = 1, Y = 1 });
            GameObject entity2 = scene.Create(
                new Update8Comp { CallCount = 0 },
                new Position { X = 10, Y = 20 },
                new Velocity { X = 2, Y = 3 },
                new Health { Value = 80 },
                new Armor { Value = 30 },
                new Damage { Value = 5 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 3 }
            );
            entity2.Add(new AnotherComponent { Data = 2, Y = 2 });

            ref GameObjectLocation location = ref entity1.AssertIsAlive(out Scene sceneRef);
            Archetype archetype = location.Archetype;
            int idx = archetype.GetComponentIndex(Component<Update8Comp>.Id);
            ComponentStorageBase storage = archetype.Components[idx];

            storage.Run(sceneRef, archetype, 1, 1);

            Assert.Equal(0, entity1.Get<Update8Comp>().CallCount);
            Assert.Equal(1, entity2.Get<Update8Comp>().CallCount);
            Assert.Equal(12, entity2.Get<Position>().X);
            Assert.Equal(23, entity2.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that arity 8 Run with missing argument component throws
        ///     ComponentNotFoundException.
        /// </summary>
        [Fact]
        public void Update_Arity8_RangeRun_MissingArg_ThrowsComponentNotFound()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update8Comp { CallCount = 0 },
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42 }
            );

            ref GameObjectLocation location = ref entity.AssertIsAlive(out Scene sceneRef);
            Archetype archetype = location.Archetype;
            int idx = archetype.GetComponentIndex(Component<Update8Comp>.Id);
            ComponentStorageBase storage = archetype.Components[idx];

            Assert.Throws<ComponentNotFoundException>(() =>
                storage.Run(sceneRef, archetype, 0, archetype.EntityCount));
        }

        #endregion
    }

    #region Test Components

    /// <summary>
    ///     Component for testing arity 8 Update
    /// </summary>
    internal struct Update8Comp : IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>
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

    #endregion
}
