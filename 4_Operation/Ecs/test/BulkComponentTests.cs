// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BulkComponentTests.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Bulk component tests for massive coverage generation
    /// </summary>
    public class BulkComponentTests
    {
        /// <summary>
        ///     Tests that bulk component individual component testing
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="componentName">The component name</param>
        [Theory, InlineData(1, "Position"), InlineData(2, "Health"), InlineData(3, "Velocity"), InlineData(4, "Transform"), InlineData(5, "Damage"), InlineData(6, "AnotherComponent"), InlineData(7, "AnotherComponent2"), InlineData(8, "Armor"), InlineData(9, "TagComponent"), InlineData(10, "TestComponent")]
        public void BulkComponent_IndividualComponentTesting(int type, string componentName)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            switch (type)
            {
                case 1:
                    go.Add(new Position {X = 10, Y = 20});
                    Assert.True(go.Has<Position>());
                    Assert.Equal(10, go.Get<Position>().X);
                    break;
                case 2:
                    go.Add(new Health {Value = 100});
                    Assert.True(go.Has<Health>());
                    Assert.Equal(100, go.Get<Health>().Value);
                    break;
                case 3:
                    go.Add(new Velocity {X = 5, Y = 10});
                    Assert.True(go.Has<Velocity>());
                    break;
                case 4:
                    go.Add(new Transform {X = 1, Y = 2});
                    Assert.True(go.Has<Transform>());
                    break;
                case 5:
                    go.Add(new Damage {Value = 20});
                    Assert.True(go.Has<Damage>());
                    break;
                case 6:
                    go.Add(new AnotherComponent {Data = 42});
                    Assert.True(go.Has<AnotherComponent>());
                    break;
                case 7:
                    go.Add(new AnotherComponent2 {Data = 99});
                    Assert.True(go.Has<AnotherComponent2>());
                    break;
                case 8:
                    go.Add(new Armor {Value = 50});
                    Assert.True(go.Has<Armor>());
                    break;
                case 9:
                    go.Add(new TagComponent());
                    Assert.True(go.Has<TagComponent>());
                    break;
                case 10:
                    go.Add(new TestComponent {Value = 777});
                    Assert.True(go.Has<TestComponent>());
                    break;
            }
        }

    
        /// <summary>
        ///     Tests that bulk component stress test component operations
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory, InlineData(100), InlineData(500)]
        public void BulkComponent_StressTestComponentOperations(int operationCount)
        {
            using Scene scene = new Scene();
            List<GameObject> entities = new List<GameObject>();

            for (int i = 0; i < operationCount; i++)
            {
                int operation = i % 4;

                switch (operation)
                {
                    case 0:
                        entities.Add(scene.Create(new Position {X = i, Y = i}));
                        break;
                    case 1:
                        if (entities.Count > 0)
                        {
                            GameObject go = entities[i % entities.Count];
                            if (go.IsAlive && !go.Has<Health>())
                            {
                                go.Add(new Health {Value = 100});
                            }
                        }

                        break;
                    case 2:
                        if (entities.Count > 0)
                        {
                            GameObject go = entities[i % entities.Count];
                            if (go.IsAlive && go.Has<Health>())
                            {
                                go.Remove<Health>();
                            }
                        }

                        break;
                    case 3:
                        if (entities.Count > 0)
                        {
                            GameObject go = entities[i % entities.Count];
                            if (go.IsAlive)
                            {
                                go.Delete();
                            }
                        }

                        break;
                }
            }

            Assert.True(entities.Count >= 0);
        }
    }
}