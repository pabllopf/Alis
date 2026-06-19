// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectUpdateTest.cs
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
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests for the <see cref="GameObjectUpdate{TComp,TArg}" /> runner class (arity 1)
    /// </summary>
    public class GameObjectUpdateTest
    {
        /// <summary>
        ///     Tests that GameObjectUpdate with arity 1 can be constructed with capacity
        /// </summary>
        [Fact]
        public void GameObjectUpdate_Arity1_Constructor_CreatesInstanceWithCapacity()
        {
            GameObjectUpdate<Update1Component, Position> update = new GameObjectUpdate<Update1Component, Position>(10);

            Assert.NotNull(update);
        }

        /// <summary>
        ///     Tests that GameObjectUpdate Run method invokes Update for all entities
        /// </summary>
        [Fact]
        public void GameObjectUpdate_Arity1_Run_InvokesUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 1, Y = 2 }
            );
            GameObject entity2 = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 3, Y = 4 }
            );

            scene.Update();

            Assert.Equal(1, entity1.Get<Update1Component>().CallCount);
            Assert.Equal(1, entity2.Get<Update1Component>().CallCount);
        }

        /// <summary>
        ///     Tests that GameObjectUpdate Run method passes correct component reference
        /// </summary>
        [Fact]
        public void GameObjectUpdate_Arity1_Run_PassesCorrectComponentReference()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 5, Y = 10 }
            );

            scene.Update();

            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(11, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that GameObjectUpdate Run method processes multiple entities
        /// </summary>
        [Fact]
        public void GameObjectUpdate_Arity1_Run_ProcessesMultipleEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 1, Y = 2 }
            );
            GameObject entity2 = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 3, Y = 4 }
            );
            GameObject entity3 = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 5, Y = 6 }
            );

            scene.Update();

            Assert.Equal(1, entity1.Get<Update1Component>().CallCount);
            Assert.Equal(1, entity2.Get<Update1Component>().CallCount);
            Assert.Equal(1, entity3.Get<Update1Component>().CallCount);

            Assert.Equal(2, entity1.Get<Position>().X);
            Assert.Equal(4, entity2.Get<Position>().X);
            Assert.Equal(6, entity3.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that multiple scene updates increment the call count correctly
        /// </summary>
        [Fact]
        public void GameObjectUpdate_Arity1_Run_MultipleUpdatesIncrementCallCount()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update1Component { CallCount = 0 },
                new Position { X = 0, Y = 0 }
            );

            scene.Update();
            scene.Update();

            Assert.Equal(2, entity.Get<Update1Component>().CallCount);
            Assert.Equal(2, entity.Get<Position>().X);
            Assert.Equal(2, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that GameObjectUpdate constructor sets capacity correctly via base class
        /// </summary>
        [Fact]
        public void GameObjectUpdate_Arity1_Constructor_SetsCapacity()
        {
            const int capacity = 32;
            GameObjectUpdate<Update1Component, Position> update = new GameObjectUpdate<Update1Component, Position>(capacity);

            Assert.Equal(capacity, update.Buffer.Length);
        }
    }

    /// <summary>
    ///     Component for testing GameObjectUpdate (arity 1)
    /// </summary>
    internal struct Update1Component : IOnUpdate<Position>
    {
        /// <summary>
        ///     The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        public void Update(IGameObject self, ref Position pos)
        {
            CallCount++;
            pos.X += 1;
            pos.Y += 1;
        }
    }
}
