// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityUpdateTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests for EntityUpdate runner (arity 5 update components).
    /// </summary>
    public class EntityUpdateTest
    {
        [Fact]
        public void EntityUpdate_Constructor_CreatesInstance()
        {
            EntityUpdate<EntityUpdate5Component, Position, Velocity, Health, Armor, Damage> update =
                new EntityUpdate<EntityUpdate5Component, Position, Velocity, Health, Armor, Damage>(8);

            Assert.NotNull(update);
            Assert.Equal(8, update.Buffer.Length);
        }

        [Fact]
        public void EntityUpdate_SceneUpdate_InvokesComponentUpdateAndMutatesAllArgs()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 10, Y = 20},
                new Velocity {VX = 1, VY = 2},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 5}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(11, entity.Get<Position>().X);
            Assert.Equal(22, entity.Get<Position>().Y);
            Assert.Equal(99, entity.Get<Health>().Value);
            Assert.Equal(51, entity.Get<Armor>().Defense);
            Assert.Equal(7, entity.Get<Damage>().Amount);
        }

        [Fact]
        public void EntityUpdate_SceneUpdate_TwoFrames_AccumulatesChanges()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 0, Y = 0},
                new Velocity {VX = 2, VY = 3},
                new Health {Value = 10},
                new Armor {Defense = 1},
                new Damage {Amount = 0}
            );

            scene.Update();
            scene.Update();

            Assert.Equal(2, entity.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(4, entity.Get<Position>().X);
            Assert.Equal(6, entity.Get<Position>().Y);
            Assert.Equal(8, entity.Get<Health>().Value);
            Assert.Equal(3, entity.Get<Armor>().Defense);
            Assert.Equal(4, entity.Get<Damage>().Amount);
        }

        [Fact]
        public void EntityUpdate_SceneUpdate_UpdatesAllMatchingEntities()
        {
            using Scene scene = new Scene();
            GameObject e1 = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 1, Y = 1},
                new Velocity {VX = 1, VY = 1},
                new Health {Value = 5},
                new Armor {Defense = 10},
                new Damage {Amount = 1}
            );
            GameObject e2 = scene.Create(
                new EntityUpdate5Component {CallCount = 0},
                new Position {X = 2, Y = 2},
                new Velocity {VX = 2, VY = 2},
                new Health {Value = 6},
                new Armor {Defense = 20},
                new Damage {Amount = 2}
            );

            scene.Update();

            Assert.Equal(1, e1.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(1, e2.Get<EntityUpdate5Component>().CallCount);
            Assert.Equal(2, e1.Get<Position>().X);
            Assert.Equal(4, e2.Get<Position>().X);
        }

        internal struct EntityUpdate5Component : IOnUpdate<Position, Velocity, Health, Armor, Damage>
        {
            public int CallCount;

            public void Update(IGameObject self, ref Position arg1, ref Velocity arg2, ref Health arg3, ref Armor arg4,
                ref Damage arg5)
            {
                CallCount++;
                arg1.X += arg2.VX;
                arg1.Y += arg2.VY;
                arg3.Value -= 1;
                arg4.Defense += 1;
                arg5.Amount += 2;
            }
        }
    }
}

