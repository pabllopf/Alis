// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeColdPathExperimentTest.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The archetype cold path experiment test class
    /// </summary>
    public class ArchetypeColdPathExperimentTest
    {
        /// <summary>
        ///     Tests that adding a component to an entity without any components covers cold archetype paths
        /// </summary>
        [Fact]
        public void Add_FromEmptyToSingle_FirstTime()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Add(new Position {X = 1});
            entity.Remove<Position>();
            entity.Add(new Position {X = 2});
        }

        /// <summary>
        ///     Tests adding and removing in alternating order across multiple entities
        /// </summary>
        [Fact]
        public void AlternatingAddRemove_MultipleEntities()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 4; i++)
            {
                GameObject entity = scene.Create(new Position {X = i}, new Health {Value = i});
                entity.Remove<Position>();
                entity.Add(new Position {X = i + 10});
                entity.Remove<Health>();
                entity.Add(new Health {Value = i + 20});
            }
        }

        /// <summary>
        ///     Tests removal of the only component then re-addition
        /// </summary>
        [Fact]
        public void RemoveLastComponent_ThenReadd()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1});
            entity.Remove<Position>();
            Assert.False(entity.Has<Position>());
            entity.Add(new Position {X = 5});
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests adding components in different orders to different entities
        /// </summary>
        [Fact]
        public void AddComponents_InDifferentOrders()
        {
            using Scene scene = new Scene();
            GameObject a = scene.Create();
            a.Add(new Position {X = 1});
            a.Add(new Health {Value = 2});

            GameObject b = scene.Create();
            b.Add(new Health {Value = 3});
            b.Add(new Position {X = 4});
        }

        /// <summary>
        ///     Tests removing a component from a multi-component entity in different orders
        /// </summary>
        [Fact]
        public void RemoveComponents_InDifferentOrders()
        {
            using Scene scene = new Scene();
            GameObject a = scene.Create(new Position {X = 1}, new Health {Value = 2}, new Velocity {X = 3});
            a.Remove<Health>();
            a.Remove<Position>();

            GameObject b = scene.Create(new Position {X = 1}, new Health {Value = 2}, new Velocity {X = 3});
            b.Remove<Position>();
            b.Remove<Velocity>();
        }
    }
}
