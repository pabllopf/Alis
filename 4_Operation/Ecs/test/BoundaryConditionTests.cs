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
        /// Tests that boundary condition component with extreme values
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void BoundaryCondition_ComponentWithExtremeValues(int value)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Health { Value = value });
            Assert.Equal(value, go.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that boundary condition position with extreme values
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(-1, -1)]
        [InlineData(int.MaxValue, int.MaxValue)]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void BoundaryCondition_PositionWithExtremeValues(int x, int y)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Position { X = x, Y = y });
            Assert.Equal(x, go.Get<Position>().X);
            Assert.Equal(y, go.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that boundary condition single entity creates
        /// </summary>
        [Fact]
        public void BoundaryCondition_SingleEntity_Creates()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            Assert.True(go.IsAlive);
        }

        /// <summary>
        /// Tests that boundary condition empty scene queries
        /// </summary>
        [Fact]
        public void BoundaryCondition_EmptyScene_Queries()
        {
            using Scene scene = new Scene();
            
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
            
            Assert.Equal(0, count);
        }

        /// <summary>
        /// Tests that boundary condition delete single entity
        /// </summary>
        [Fact]
        public void BoundaryCondition_DeleteSingleEntity()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Delete();
            
            Assert.False(go.IsAlive);
        }

        /// <summary>
        /// Tests that boundary condition velocity with zero and negative
        /// </summary>
        /// <param name="val">The val</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-100)]
        public void BoundaryCondition_VelocityWithZeroAndNegative(int val)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Velocity { X = val, Y = val });
            Assert.Equal(val, go.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that boundary condition component add remove add again
        /// </summary>
        [Fact]
        public void BoundaryCondition_ComponentAddRemoveAddAgain()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Position { X = 10, Y = 20 });
            Assert.True(go.Has<Position>());
            
            go.Remove<Position>();
            Assert.False(go.Has<Position>());
            
            go.Add(new Position { X = 30, Y = 40 });
            Assert.True(go.Has<Position>());
            Assert.Equal(30, go.Get<Position>().X);
        }

        /// <summary>
        /// Tests that boundary condition damage with various values
        /// </summary>
        /// <param name="dmg">The dmg</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(1000)]
        [InlineData(int.MaxValue)]
        public void BoundaryCondition_DamageWithVariousValues(int dmg)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Damage { Value = dmg });
            Assert.Equal(dmg, go.Get<Damage>().Value);
        }

        /// <summary>
        /// Tests that boundary condition transform zero coordinates
        /// </summary>
        [Fact]
        public void BoundaryCondition_TransformZeroCoordinates()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Transform { X = 0, Y = 0 });
            Assert.Equal(0, go.Get<Transform>().X);
            Assert.Equal(0, go.Get<Transform>().Y);
        }

        /// <summary>
        /// Tests that boundary condition create varying numbers
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void BoundaryCondition_CreateVaryingNumbers(int count)
        {
            using Scene scene = new Scene();
            
            for (int i = 0; i < count; i++)
            {
                scene.Create();
            }
            
            Assert.True(true);
        }

        /// <summary>
        /// Tests that boundary condition query with single entity match
        /// </summary>
        [Fact]
        public void BoundaryCondition_QueryWithSingleEntityMatch()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 1 });
            
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
            
            Assert.Equal(1, count);
        }

        /// <summary>
        /// Tests that boundary condition armor with various values
        /// </summary>
        /// <param name="armor">The armor</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void BoundaryCondition_ArmorWithVariousValues(int armor)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Armor { Value = armor });
            Assert.Equal(armor, go.Get<Armor>().Value);
        }

        /// <summary>
        /// Tests that boundary condition tag component addition
        /// </summary>
        [Fact]
        public void BoundaryCondition_TagComponentAddition()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new TagComponent());
            Assert.True(go.Has<TagComponent>());
        }

        /// <summary>
        /// Tests that boundary condition all component types on single entity
        /// </summary>
        [Fact]
        public void BoundaryCondition_AllComponentTypesOnSingleEntity()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            go.Add(new Position { X = 1, Y = 1 });
            go.Add(new Health { Value = 100 });
            go.Add(new Velocity { X = 1, Y = 1 });
            go.Add(new Transform { X = 1, Y = 1 });
            go.Add(new Damage { Value = 10 });
            go.Add(new AnotherComponent { Data = 42 });
            go.Add(new AnotherComponent2 { Data = 99 });
            go.Add(new Armor { Value = 50 });
            go.Add(new TagComponent());
            go.Add(new TestComponent { Value = 777 });
            
            Assert.True(go.Has<Position>());
            Assert.True(go.Has<Health>());
            Assert.True(go.Has<Velocity>());
            Assert.True(go.Has<Transform>());
            Assert.True(go.Has<Damage>());
            Assert.True(go.Has<AnotherComponent>());
            Assert.True(go.Has<AnotherComponent2>());
            Assert.True(go.Has<Armor>());
            Assert.True(go.Has<TagComponent>());
            Assert.True(go.Has<TestComponent>());
        }
    }
}

