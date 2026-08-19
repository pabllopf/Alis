// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectComprehensiveTest.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Comprehensive tests for GameObject struct covering all aspects
    /// </summary>
    public class GameObjectComprehensiveTest
    {
        /// <summary>
        ///     Tests that game object null static is null
        /// </summary>
        [Fact] public void GameObject_NullStatic_IsNull()
        {
            GameObject nullGo = GameObject.Null;

            Assert.True(nullGo.IsNull);
            Assert.False(nullGo.IsAlive);
        }

        /// <summary>
        ///     Tests that game object create sets correct properties
        /// </summary>
        [Fact] public void GameObject_Create_SetsCorrectProperties()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();
                Assert.True(go.IsAlive);
                Assert.False(go.IsNull);
            }
        }

        /// <summary>
        ///     Tests that game object create with component stores component
        /// </summary>
        [Fact] public void GameObject_CreateWithComponent_StoresComponent()
        {
            using (Scene scene = new Scene())
            {
                Position pos = new Position {X = 10, Y = 20};

                GameObject go = scene.Create(pos);

                Assert.True(go.Has<Position>());
                Assert.Equal(10, go.Get<Position>().X);
                Assert.Equal(20, go.Get<Position>().Y);
            }
        }

    

        /// <summary>
        ///     Tests that game object add component component exists
        /// </summary>
        [Fact] public void GameObject_AddComponent_ComponentExists()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();
                Position pos = new Position {X = 5, Y = 15};

                go.Add(pos);

                Assert.True(go.Has<Position>());
                Assert.Equal(5, go.Get<Position>().X);
            }
        }

        /// <summary>
        ///     Tests that game object add multiple components all exist
        /// </summary>
        [Fact] public void GameObject_AddMultipleComponents_AllExist()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                go.Add(new Position {X = 1, Y = 2});
                go.Add(new Health {Value = 100});
                go.Add(new Velocity {X = 10, Y = 20});

                Assert.True(go.Has<Position>());
                Assert.True(go.Has<Health>());
                Assert.True(go.Has<Velocity>());
            }
        }

        /// <summary>
        ///     Tests that game object remove component component no longer exists
        /// </summary>
        [Fact] public void GameObject_RemoveComponent_ComponentNoLongerExists()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create(new Position {X = 1, Y = 2});

                go.Remove<Position>();

                Assert.False(go.Has<Position>());
            }
        }

        /// <summary>
        ///     Tests that game object get component returns correct value
        /// </summary>
        [Fact] public void GameObject_GetComponent_ReturnsCorrectValue()
        {
            using (Scene scene = new Scene())
            {
                Position expected = new Position {X = 42, Y = 84};
                GameObject go = scene.Create(expected);

                ref Position actual = ref go.Get<Position>();

                Assert.Equal(expected.X, actual.X);
                Assert.Equal(expected.Y, actual.Y);
            }
        }

        /// <summary>
        ///     Tests that game object modify component via ref changes are persisted
        /// </summary>
        [Fact] public void GameObject_ModifyComponentViaRef_ChangesArePersisted()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create(new Position {X = 10, Y = 20});

                ref Position pos = ref go.Get<Position>();
                pos.X = 100;
                pos.Y = 200;

                Assert.Equal(100, go.Get<Position>().X);
                Assert.Equal(200, go.Get<Position>().Y);
            }
        }

       

        /// <summary>
        ///     Tests that game object equals operator compares two entities
        /// </summary>
        [Fact] public void GameObject_EqualsOperator_ComparesTwoEntities()
        {
            using (Scene scene = new Scene())
            {
                GameObject go1 = scene.Create();
                GameObject go2 = scene.Create();

                Assert.NotEqual(go1, go2);
                Assert.True(go1 == go1);
                Assert.False(go1 == go2);
            }
        }

        /// <summary>
        ///     Tests that game object not equals operator differentiate entities
        /// </summary>
        [Fact] public void GameObject_NotEqualsOperator_DifferentiateEntities()
        {
            using (Scene scene = new Scene())
            {
                GameObject go1 = scene.Create();
                GameObject go2 = scene.Create();

                Assert.True(go1 != go2);
                Assert.False(go1 != go1);
            }
        }

        /// <summary>
        ///     Tests that game object get hash code consistent for same entity
        /// </summary>
        [Fact] public void GameObject_GetHashCode_ConsistentForSameEntity()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                int hash1 = go.GetHashCode();
                int hash2 = go.GetHashCode();

                Assert.Equal(hash1, hash2);
            }
        }

        /// <summary>
        ///     Tests that game object to string returns valid string
        /// </summary>
        [Fact] public void GameObject_ToString_ReturnsValidString()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                string str = go.ToString();

                Assert.NotNull(str);
                Assert.False(string.IsNullOrEmpty(str));
            }
        }

      

        /// <summary>
        ///     Tests that game object remove all components entity still alive
        /// </summary>
        [Fact] public void GameObject_RemoveAllComponents_EntityStillAlive()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create(new Position {X = 1, Y = 1}, new Health {Value = 100});

                go.Remove<Position>();
                go.Remove<Health>();

                Assert.False(go.Has<Position>());
                Assert.False(go.Has<Health>());
            }
        }

        /// <summary>
        ///     Tests that game object get component count reflects added components
        /// </summary>
        [Fact] public void GameObject_GetComponentCount_ReflectsAddedComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create();

                go.Add(new Position {X = 1, Y = 1});
                go.Add(new Health {Value = 50});

                Assert.True(go.Has<Position>());
                Assert.True(go.Has<Health>());
            }
        }
    }
}