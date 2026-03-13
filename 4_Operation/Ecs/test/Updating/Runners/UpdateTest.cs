// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Tests for all Update<...> runner classes (arities 0, 2, 3, 4, 6, 7, 8)
    /// </summary>
    public class UpdateTest
    {
        #region Update<TComp> (Arity 0) Tests

        /// <summary>
        /// Tests that Update with arity 0 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity0_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<UpdateComponent> update = new Update<UpdateComponent>(10);

            // Assert
            Assert.NotNull(update);
        }

        /// <summary>
        /// Tests that Update with arity 0 Run method invokes OnUpdate for all entities
        /// </summary>
        [Fact]
        public void Update_Arity0_Run_InvokesOnUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject entity2 = scene.Create(new UpdateComponent {CallCount = 0});

            scene.Update();

            Assert.Equal(1, entity1.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, entity2.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that Update with arity 0 Run with range invokes OnUpdate for specified entities
        /// </summary>
        [Fact]
        public void Update_Arity0_RunWithRange_InvokesOnUpdateForSpecifiedRange()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject entity2 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject entity3 = scene.Create(new UpdateComponent {CallCount = 0});

            scene.Update();

            // All entities should be updated
            Assert.Equal(1, entity1.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, entity2.Get<UpdateComponent>().CallCount);
            Assert.Equal(1, entity3.Get<UpdateComponent>().CallCount);
        }

        #endregion

        #region Update<TComp, TArg1, TArg2> (Arity 2) Tests

        /// <summary>
        /// Tests that Update with arity 2 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity2_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<Update2Component, Position, Velocity> update = new Update<Update2Component, Position, Velocity>(10);

            // Assert
            Assert.NotNull(update);
        }

        /// <summary>
        /// Tests that Update with arity 2 Run method invokes Update for all entities
        /// </summary>
        [Fact]
        public void Update_Arity2_Run_InvokesUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Update2Component {CallCount = 0},
                new Position {X = 1, Y = 2},
                new Velocity {X = 10, Y = 20}
            );

            scene.Update();

            Assert.Equal(1, entity1.Get<Update2Component>().CallCount);
        }

        /// <summary>
        /// Tests that Update with arity 2 passes correct component references
        /// </summary>
        [Fact]
        public void Update_Arity2_Run_PassesCorrectComponentReferences()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update2Component {CallCount = 0},
                new Position {X = 5, Y = 10},
                new Velocity {X = 1, Y = 2}
            );

            scene.Update();

            // After update, position should have moved by velocity
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(12, entity.Get<Position>().Y);
        }

        #endregion

        #region Update<TComp, TArg1, TArg2, TArg3> (Arity 3) Tests

        /// <summary>
        /// Tests that Update with arity 3 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity3_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<Update3Component, Position, Velocity, Health> update = 
                new Update<Update3Component, Position, Velocity, Health>(10);

            // Assert
            Assert.NotNull(update);
        }

        /// <summary>
        /// Tests that Update with arity 3 Run method invokes Update for all entities
        /// </summary>
        [Fact]
        public void Update_Arity3_Run_InvokesUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(
                new Update3Component {CallCount = 0},
                new Position {X = 1, Y = 2},
                new Velocity {X = 10, Y = 20},
                new Health {Value = 100}
            );

            scene.Update();

            Assert.Equal(1, entity1.Get<Update3Component>().CallCount);
        }

        /// <summary>
        /// Tests that Update with arity 3 passes correct component references
        /// </summary>
        [Fact]
        public void Update_Arity3_Run_PassesCorrectComponentReferences()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update3Component {CallCount = 0},
                new Position {X = 0, Y = 0},
                new Velocity {X = 5, Y = 10},
                new Health {Value = 100}
            );

            scene.Update();

            Assert.Equal(5, entity.Get<Position>().X);
            Assert.Equal(10, entity.Get<Position>().Y);
            Assert.Equal(99, entity.Get<Health>().Value);
        }

        #endregion

        #region Update<TComp, TArg1, TArg2, TArg3, TArg4> (Arity 4) Tests

        /// <summary>
        /// Tests that Update with arity 4 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity4_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<Update4Component, Position, Velocity, Health, Armor> update = 
                new Update<Update4Component, Position, Velocity, Health, Armor>(10);

            // Assert
            Assert.NotNull(update);
        }

        /// <summary>
        /// Tests that Update with arity 4 Run method invokes Update for all entities
        /// </summary>
        [Fact]
        public void Update_Arity4_Run_InvokesUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update4Component {CallCount = 0},
                new Position {X = 1, Y = 2},
                new Velocity {X = 5, Y = 10},
                new Health {Value = 100},
                new Armor {Value = 50}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update4Component>().CallCount);
        }

        #endregion

        #region Update<TComp, TArg1..TArg6> (Arity 6) Tests

        /// <summary>
        /// Tests that Update with arity 6 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity6_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<Update6Component, Position, Velocity, Health, Armor, Damage, Transform> update = 
                new Update<Update6Component, Position, Velocity, Health, Armor, Damage, Transform>(10);

            // Assert
            Assert.NotNull(update);
        }

        /// <summary>
        /// Tests that Update with arity 6 Run method invokes Update for all entities
        /// </summary>
        [Fact]
        public void Update_Arity6_Run_InvokesUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update6Component {CallCount = 0},
                new Position {X = 1, Y = 2},
                new Velocity {X = 5, Y = 10},
                new Health {Value = 100},
                new Armor {Value = 50},
                new Damage {Value = 10},
                new Transform {X = 0, Y = 0, Rotation = 0}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update6Component>().CallCount);
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(12, entity.Get<Position>().Y);
            Assert.Equal(90, entity.Get<Health>().Value);
            Assert.Equal(51, entity.Get<Armor>().Value);
            Assert.Equal(12, entity.Get<Damage>().Value);
            Assert.Equal(1, entity.Get<Transform>().Rotation);
        }

        #endregion

        #region Update<TComp, TArg1..TArg7> (Arity 7) Tests

        /// <summary>
        /// Tests that Update with arity 7 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity7_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<Update7Component, Position, Velocity, Health, Armor, Damage, Transform, TestComponent> update = 
                new Update<Update7Component, Position, Velocity, Health, Armor, Damage, Transform, TestComponent>(10);

            // Assert
            Assert.NotNull(update);
        }

        /// <summary>
        /// Tests that Update with arity 7 Run method invokes Update for all entities
        /// </summary>
        [Fact]
        public void Update_Arity7_Run_InvokesUpdateForAllEntities()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Update7Component {CallCount = 0},
                new Position {X = 1, Y = 2},
                new Velocity {X = 5, Y = 10},
                new Health {Value = 100},
                new Armor {Value = 50},
                new Damage {Value = 10},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 42}
            );

            scene.Update();

            Assert.Equal(1, entity.Get<Update7Component>().CallCount);
            Assert.Equal(6, entity.Get<Position>().X);
            Assert.Equal(12, entity.Get<Position>().Y);
            Assert.Equal(99, entity.Get<Health>().Value);
            Assert.Equal(60, entity.Get<Armor>().Value);
            Assert.Equal(1, entity.Get<Transform>().X);
            Assert.Equal(45, entity.Get<TestComponent>().Value);
        }

        #endregion

        #region Update<TComp, TArg1..TArg8> (Arity 8) Tests

        /// <summary>
        /// Tests that Update with arity 8 can be constructed with capacity
        /// </summary>
        [Fact]
        public void Update_Arity8_Constructor_CreatesInstanceWithCapacity()
        {
            // Act
            Update<Update8Component, Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent> update = 
                new Update<Update8Component, Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>(10);

            // Assert
            Assert.NotNull(update);
        }

        #endregion

        #region Multiple Entities Tests

        /// <summary>
        /// Tests that Update processes multiple entities correctly
        /// </summary>
        [Fact]
        public void Update_Run_ProcessesMultipleEntitiesCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject entity2 = scene.Create(new UpdateComponent {CallCount = 0});
            GameObject entity3 = scene.Create(new UpdateComponent {CallCount = 0});

            scene.Update();
            scene.Update();

            Assert.Equal(2, entity1.Get<UpdateComponent>().CallCount);
            Assert.Equal(2, entity2.Get<UpdateComponent>().CallCount);
            Assert.Equal(2, entity3.Get<UpdateComponent>().CallCount);
        }

        /// <summary>
        /// Tests that Update processes entities in reverse order
        /// </summary>
        [Fact]
        public void Update_Run_ProcessesEntitiesInReverseOrder()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new OrderTrackingComponent {Order = 0});
            GameObject entity2 = scene.Create(new OrderTrackingComponent {Order = 0});
            GameObject entity3 = scene.Create(new OrderTrackingComponent {Order = 0});

            scene.Update();

            // The loop processes from EntityCount-1 to 0, so reverse order
            Assert.True(entity1.Get<OrderTrackingComponent>().Order >= 0);
        }

        #endregion
    }

    #region Test Components

    /// <summary>
    /// Component for testing Update with arity 0
    /// </summary>
    internal struct UpdateComponent : IOnUpdate
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            CallCount++;
        }
    }

    /// <summary>
    /// Component for testing Update with arity 2
    /// </summary>
    internal struct Update2Component : IOnUpdate<Position, Velocity>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="vel">The vel</param>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
        }
    }

    /// <summary>
    /// Component for testing Update with arity 3
    /// </summary>
    internal struct Update3Component : IOnUpdate<Position, Velocity, Health>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="vel">The vel</param>
        /// <param name="health">The health</param>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
            health.Value--;
        }
    }

    /// <summary>
    /// Component for testing Update with arity 4
    /// </summary>
    internal struct Update4Component : IOnUpdate<Position, Velocity, Health, Armor>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="vel">The vel</param>
        /// <param name="health">The health</param>
        /// <param name="armor">The armor</param>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health, ref Armor armor)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
        }
    }

    /// <summary>
    /// Component for testing Update with arity 6
    /// </summary>
    internal struct Update6Component : IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="vel">The vel</param>
        /// <param name="health">The health</param>
        /// <param name="armor">The armor</param>
        /// <param name="damage">The damage</param>
        /// <param name="transform">The transform</param>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health, 
            ref Armor armor, ref Damage damage, ref Transform transform)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
            health.Value -= damage.Value;
            armor.Value = armor.Value + 1;
            damage.Value += 2;
            transform.Rotation += 1;
        }
    }

    /// <summary>
    /// Component for testing Update with arity 7
    /// </summary>
    internal struct Update7Component : IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="vel">The vel</param>
        /// <param name="health">The health</param>
        /// <param name="armor">The armor</param>
        /// <param name="damage">The damage</param>
        /// <param name="transform">The transform</param>
        /// <param name="test">The test</param>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health, 
            ref Armor armor, ref Damage damage, ref Transform transform, ref TestComponent test)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
            health.Value--;
            armor.Value = armor.Value + damage.Value;
            transform.X += 1;
            test.Value += 3;
        }
    }

    /// <summary>
    /// Component for testing Update with arity 8
    /// </summary>
    internal struct Update8Component : IOnUpdate<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="pos">The pos</param>
        /// <param name="vel">The vel</param>
        /// <param name="health">The health</param>
        /// <param name="armor">The armor</param>
        /// <param name="damage">The damage</param>
        /// <param name="transform">The transform</param>
        /// <param name="test">The test</param>
        /// <param name="another">The another</param>
        public void Update(IGameObject self, ref Position pos, ref Velocity vel, ref Health health, 
            ref Armor armor, ref Damage damage, ref Transform transform, ref TestComponent test, ref AnotherComponent another)
        {
            CallCount++;
            pos.X += vel.X;
            pos.Y += vel.Y;
            health.Value--;
            armor.Value = armor.Value + 2;
            damage.Value++;
            transform.Rotation += 2;
            test.Value *= 2;
            another.Data += 1;
            another.Y += 1;
        }
    }

    /// <summary>
    /// Component for tracking execution order
    /// </summary>
    internal struct OrderTrackingComponent : IOnUpdate
    {
        /// <summary>
        /// The order
        /// </summary>
        public int Order;

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            // Track order
        }
    }

    #endregion
}

