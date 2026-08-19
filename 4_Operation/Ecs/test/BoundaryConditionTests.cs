// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoundaryConditionTests.cs
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
    ///     Boundary condition tests
    /// </summary>
    public class BoundaryConditionTests
    {
        
        /// <summary>
        ///     Tests that boundary condition single entity creates
        /// </summary>
        [Fact] public void BoundaryCondition_SingleEntity_Creates()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                Assert.True(go.IsAlive);
            }
        }

        /// <summary>
        ///     Tests that boundary condition empty scene queries
        /// </summary>
        [Fact] public void BoundaryCondition_EmptyScene_Queries()
        {
            using (Scene scene = new Scene())
            {
                int count = 0;
                foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(0, count);
            }
        }

        /// <summary>
        ///     Tests that boundary condition delete single entity
        /// </summary>
        [Fact] public void BoundaryCondition_DeleteSingleEntity()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                go.Delete();

                Assert.False(go.IsAlive);
            }
        }

       
        /// <summary>
        ///     Tests that boundary condition component add remove add again
        /// </summary>
        [Fact] public void BoundaryCondition_ComponentAddRemoveAddAgain()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                go.Add(new Position {X = 10, Y = 20});
                Assert.True(go.Has<Position>());

                go.Remove<Position>();
                Assert.False(go.Has<Position>());

                go.Add(new Position {X = 30, Y = 40});
                Assert.True(go.Has<Position>());
                Assert.Equal(30, go.Get<Position>().X);
            }
        }

        

        /// <summary>
        ///     Tests that boundary condition transform zero coordinates
        /// </summary>
        [Fact] public void BoundaryCondition_TransformZeroCoordinates()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                go.Add(new Transform {X = 0, Y = 0});
                Assert.Equal(0, go.Get<Transform>().X);
                Assert.Equal(0, go.Get<Transform>().Y);
            }
        }

       

        /// <summary>
        ///     Tests that boundary condition query with single entity match
        /// </summary>
        [Fact] public void BoundaryCondition_QueryWithSingleEntityMatch()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 1});

                int count = 0;
                foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(1, count);
            }
        }
        
    }
}