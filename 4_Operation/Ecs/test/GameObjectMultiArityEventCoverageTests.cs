// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectMultiArityEventCoverageTests.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Exercises the world-level and per-entity component-added event branches of the
    ///     multi-arity <see cref="GameObject" /> Add overloads (arity 2 through 8), and the
    ///     dead-entity structural change guard.
    /// </summary>
    public class GameObjectMultiArityEventCoverageTests
    {
        /// <summary>
        ///     Verifies that Add(T1,T2) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

entity.Add(new Position {X = 1, Y = 2}, new Health {Value = 3});

                Assert.Equal(2, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Health>());
            }
        }

        /// <summary>
        ///     Verifies that Add(T1,T2,T3) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2T3_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

                entity.Add(new Position(), new Health(), new Velocity());

                Assert.Equal(3, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Health>());
                Assert.True(entity.Has<Velocity>());
            }
        }

        /// <summary>
        ///     Verifies that Add(T1..T4) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2T3T4_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

                entity.Add(new Position(), new Health(), new Velocity(), new Armor());

                Assert.Equal(4, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<Armor>());
            }
        }

        /// <summary>
        ///     Verifies that Add(T1..T5) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2T3T4T5_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

                entity.Add(new Position(), new Health(), new Velocity(), new Armor(), new Damage());

                Assert.Equal(5, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<Damage>());
            }
        }

        /// <summary>
        ///     Verifies that Add(T1..T6) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2T3T4T5T6_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

                entity.Add(new Position(), new Health(), new Velocity(), new Armor(), new Damage(),
                    new Transform());

                Assert.Equal(6, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<Transform>());
            }
        }

        /// <summary>
        ///     Verifies that Add(T1..T7) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2T3T4T5T6T7_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

                entity.Add(new Position(), new Health(), new Velocity(), new Armor(), new Damage(),
                    new Transform(), new TestComponent());

                Assert.Equal(7, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<TestComponent>());
            }
        }

        /// <summary>
        ///     Verifies that Add(T1..T8) fires both the scene ComponentAdded event and the
        ///     per-entity OnComponentAdded event.
        /// </summary>
        [Fact]
        public void Add_T1T2T3T4T5T6T7T8_FiresWorldAndEntityEvents()
        {
            using (Scene scene = new Scene())
            {
                int worldCount = 0;
                int entityCount = 0;
                scene.ComponentAdded += (_, _) => worldCount++;

                GameObject entity = scene.Create();
                entity.OnComponentAdded += (_, _) => entityCount++;

                entity.Add(new Position(), new Health(), new Velocity(), new Armor(), new Damage(),
                    new Transform(), new TestComponent(), new AnotherComponent());

                Assert.Equal(8, worldCount);
                Assert.Equal(1, entityCount);
                Assert.True(entity.Has<AnotherComponent>());
            }
        }

        /// <summary>
        ///     Verifies that adding a component to a deleted entity throws the
        ///     "GameObject is dead." InvalidOperationException.
        /// </summary>
        [Fact]
        public void Add_OnDeadEntity_ThrowsEntityIsDead()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                entity.Delete();

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                    entity.Add(new Position()));
                Assert.Equal("GameObject is dead.", ex.Message);
            }
        }
    }
}