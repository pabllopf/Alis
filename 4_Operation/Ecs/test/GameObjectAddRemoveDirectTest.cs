// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectAddRemoveDirectTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for all Add and Remove methods of GameObject using direct GameObject methods (no Scene.Create)
    /// </summary>
    public class GameObjectAddRemoveDirectTest
    {
        /// <summary>
        /// Helper method to create a GameObject with initial components using Scene
        /// </summary>
        private GameObject CreateEntity(Scene scene, params object[] components)
        {
            return scene.Create(components);
        }

        #region Add<T> Tests

        /// <summary>
        /// Tests that Add with 1 component works correctly
        /// </summary>
        [Fact]
        public void GameObject_Add_Single_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.Add(new Velocity {X = 10, Y = 20});

            Assert.True(go.Has<Velocity>());
            Assert.Equal(10, go.Get<Velocity>().X);
            Assert.Equal(20, go.Get<Velocity>().Y);
        }

        /// <summary>
        /// Tests that Add with 1 component updates component data correctly
        /// </summary>
        [Fact]
        public void GameObject_Add_Single_UpdatesComponentDataCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 0, Y = 0});

            go.Add(new Health {Value = 100});
            
            ref Health health = ref go.Get<Health>();
            health.Value = 50;

            Assert.Equal(50, go.Get<Health>().Value);
        }

        #endregion


        

        #region Add<T1..T5> Tests

        /// <summary>
        /// Tests that Add with 5 components works sequentially
        /// </summary>
        [Fact]
        public void GameObject_Add_FiveComponents_Sequential_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.Add(new Velocity {X = 5, Y = 10});
            go.Add(new Health {Value = 100});
            go.Add(new Armor {Value = 50});
            go.Add(new Damage {Value = 25});
            go.Add(new Transform {X = 0, Y = 0, Rotation = 0});

            Assert.True(go.Has<Transform>());
            Assert.Equal(5, go.Get<Velocity>().X);
        }

        #endregion

        #region Add<T1..T6> Tests

        /// <summary>
        /// Tests that Add with 6 components works sequentially
        /// </summary>
        [Fact]
        public void GameObject_Add_SixComponents_Sequential_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.Add(new Velocity {X = 5, Y = 10});
            go.Add(new Health {Value = 100});
            go.Add(new Armor {Value = 50});
            go.Add(new Damage {Value = 25});
            go.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            go.Add(new TestComponent {Value = 42});

            Assert.True(go.Has<TestComponent>());
            Assert.Equal(42, go.Get<TestComponent>().Value);
        }

        #endregion

        #region Add<T1..T7> Tests

        /// <summary>
        /// Tests that Add with 7 components works sequentially
        /// </summary>
        [Fact]
        public void GameObject_Add_SevenComponents_Sequential_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.Add(new Velocity {X = 5, Y = 10});
            go.Add(new Health {Value = 100});
            go.Add(new Armor {Value = 50});
            go.Add(new Damage {Value = 25});
            go.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            go.Add(new TestComponent {Value = 42});
            go.Add(new AnotherComponent {Data = 1, Y = 1});

            Assert.True(go.Has<AnotherComponent>());
            Assert.Equal(1, go.Get<AnotherComponent>().Data);
        }

        #endregion

        #region Add<T1..T8> Tests

        /// <summary>
        /// Tests that Add with 8 components works sequentially
        /// </summary>
        [Fact]
        public void GameObject_Add_EightComponents_Sequential_WorksCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.Add(new Velocity {X = 5, Y = 10});
            go.Add(new Health {Value = 100});
            go.Add(new Armor {Value = 50});
            go.Add(new Damage {Value = 25});
            go.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            go.Add(new TestComponent {Value = 42});
            go.Add(new AnotherComponent {Data = 1, Y = 1});
            go.Add(new AnotherComponent2 {Name = "test"});

            Assert.True(go.Has<AnotherComponent2>());
            Assert.Equal("test", go.Get<AnotherComponent2>().Name);
        }

        #endregion

        #region AddBoxed Tests

        /// <summary>
        /// Tests that AddBoxed adds component successfully
        /// </summary>
        [Fact]
        public void GameObject_AddBoxed_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.AddBoxed(new Velocity {X = 10, Y = 20});

            Assert.True(go.Has<Velocity>());
            Assert.Equal(10, go.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that AddBoxed works with boxed value types
        /// </summary>
        [Fact]
        public void GameObject_AddBoxed_WorksWithBoxedValueTypes()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            object boxedHealth = new Health {Value = 75};
            go.AddBoxed(boxedHealth);

            Assert.True(go.Has<Health>());
            Assert.Equal(75, go.Get<Health>().Value);
        }
        
        #endregion

        #region AddAs(Type) Tests

        /// <summary>
        /// Tests that AddAs with Type adds component successfully
        /// </summary>
        [Fact]
        public void GameObject_AddAs_WithType_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.AddAs(typeof(Velocity), new Velocity {X = 15, Y = 25});

            Assert.True(go.Has<Velocity>());
            Assert.Equal(15, go.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that AddAs with Type preserves component data
        /// </summary>
        [Fact]
        public void GameObject_AddAs_WithType_PreservesComponentData()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 10, Y = 20});

            go.AddAs(typeof(Health), new Health {Value = 150});

            Assert.Equal(150, go.Get<Health>().Value);
        }

        #endregion

        #region AddAs(ComponentId) Tests

        /// <summary>
        /// Tests that AddAs with ComponentId adds component successfully
        /// </summary>
        [Fact]
        public void GameObject_AddAs_WithComponentId_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.AddAs(Component<Velocity>.Id, new Velocity {X = 20, Y = 30});

            Assert.True(go.Has<Velocity>());
            Assert.Equal(20, go.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that AddAs with ComponentId works with multiple adds
        /// </summary>
        [Fact]
        public void GameObject_AddAs_WithComponentId_WorksWithMultipleAdds()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.AddAs(Component<Velocity>.Id, new Velocity {X = 5, Y = 10});
            go.AddAs(Component<Health>.Id, new Health {Value = 100});

            Assert.True(go.Has<Velocity>());
            Assert.True(go.Has<Health>());
        }

        #endregion

 

       

        #region Integration Tests

        /// <summary>
        /// Tests that Add and Remove work together correctly
        /// </summary>
        [Fact]
        public void GameObject_AddRemove_WorkTogetherCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            go.Add(new Velocity {X = 10, Y = 20});
            Assert.True(go.Has<Velocity>());

            go.Remove<Velocity>();
            Assert.False(go.Has<Velocity>());

            go.Add(new Velocity {X = 5, Y = 15});
            Assert.True(go.Has<Velocity>());
            Assert.Equal(5, go.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that all Add variants work correctly
        /// </summary>
        [Fact]
        public void GameObject_AllAddVariants_WorkCorrectly()
        {
            using Scene scene = new Scene();
            GameObject go = CreateEntity(scene, new Position {X = 1, Y = 2});

            // Generic Add
            go.Add(new Velocity {X = 5, Y = 10});
            Assert.True(go.Has<Velocity>());

            // AddBoxed
            go.AddBoxed(new Health {Value = 100});
            Assert.True(go.Has<Health>());

            // AddAs(Type)
            go.AddAs(typeof(Armor), new Armor {Value = 50});
            Assert.True(go.Has<Armor>());

            // AddAs(ComponentId)
            go.AddAs(Component<Damage>.Id, new Damage {Value = 25});
            Assert.True(go.Has<Damage>());
        }

  
        

        #endregion
    }
}

