// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLatestCoverageTests.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Covers the dead entity assertion path of <see cref="GameObject" />.
    /// </summary>
    public class GameObjectLatestCoverageTests
    {
        /// <summary>
        ///     Tests that getting a component from a deleted game object throws invalid operation exception
        /// </summary>
        [Fact]
        public void Get_OnDeletedEntity_ThrowsEntityIsDead()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => entity.Get<Position>());

            Assert.Equal(GameObject.EntityIsDeadMessage, ex.Message);
        }

        /// <summary>
        ///     Tests that adding a component to a deleted game object throws invalid operation exception
        /// </summary>
        [Fact]
        public void Add_OnDeletedEntity_ThrowsEntityIsDead()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => entity.Add(new Velocity {X = 3, Y = 4}));

            Assert.Equal(GameObject.EntityIsDeadMessage, ex.Message);
        }

        /// <summary>
        ///     Tests that reading component types from a deleted game object throws invalid operation exception
        /// </summary>
        [Fact]
        public void ComponentTypes_OnDeletedEntity_ThrowsEntityIsDead()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => _ = entity.ComponentTypes);

            Assert.Equal(GameObject.EntityIsDeadMessage, ex.Message);
        }
    }
}
