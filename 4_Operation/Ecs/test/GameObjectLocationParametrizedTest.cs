// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLocationParametrizedTest.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Parametrized tests for GameObject location and identity
    /// </summary>
    public class GameObjectLocationParametrizedTest
    {
       
        /// <summary>
        ///     Tests that game object location entity identity persists across operations
        /// </summary>
        [Fact] public void GameObjectLocation_EntityIdentity_PersistsAcrossOperations()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            GameObject id1 = entity;
            entity.Add(new Health {Value = 100});
            GameObject id2 = entity;
            ref Position pos = ref entity.Get<Position>();
            pos.X = 50;
            GameObject id3 = entity;

            Assert.Equal(id1, id2);
            Assert.Equal(id2, id3);
        }

       
        /// <summary>
        ///     Tests that game object location entity location within scene accessible
        /// </summary>
        [Fact] public void GameObjectLocation_EntityLocationWithinScene_Accessible()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create(new Position {X = 100, Y = 200});

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.Equal(100, entity.Get<Position>().X);
        }

       
    }
}