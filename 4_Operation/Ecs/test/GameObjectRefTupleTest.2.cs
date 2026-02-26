using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="GameObjectRefTuple{T1, T2}"/> struct with two components.
    /// </summary>
    public partial class GameObjectRefTupleTest
    {
        /// <summary>
        ///     Tests that game object ref tuple with two components can be created.
        /// </summary>
        [Fact]
        public void RefTuple2_Initialize_ShouldSetGameObjectAndComponents()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 10, Y = 20 };
            Velocity vel = new Velocity { VX = 1, VY = 2 };
            entity.Add(pos);
            entity.Add(vel);
            
            // Act
            GameObjectRefTuple<Position, Velocity> tuple = new GameObjectRefTuple<Position, Velocity>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0)
            };
            
            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(10, tuple.Item1.Value.X);
            Assert.Equal(1, tuple.Item2.Value.VX);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that ref tuple with two components can be deconstructed.
        /// </summary>
        [Fact]
        public void RefTuple2_Deconstruct_ShouldReturnGameObjectAndBothRefs()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 5, Y = 10 };
            Velocity vel = new Velocity { VX = 2, VY = 3 };
            entity.Add(pos);
            entity.Add(vel);
            
            GameObjectRefTuple<Position, Velocity> tuple = new GameObjectRefTuple<Position, Velocity>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0)
            };
            
            // Act
            (GameObject go, Ref<Position> posRef, Ref<Velocity> velRef) = tuple;
            
            // Assert
            Assert.Equal(entity, go);
            Assert.Equal(5, posRef.Value.X);
            Assert.Equal(2, velRef.Value.VX);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that modifying component through ref tuple updates the original.
        /// </summary>
        [Fact]
        public void RefTuple2_ModifyComponents_ShouldUpdateBoth()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 1, Y = 2 };
            Velocity vel = new Velocity { VX = 0.5f, VY = 0.5f };
            entity.Add(pos);
            entity.Add(vel);
            
            GameObjectRefTuple<Position, Velocity> tuple = new GameObjectRefTuple<Position, Velocity>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0)
            };
            
            // Act
            tuple.Item1.Value.X = 100;
            tuple.Item2.Value.VX = 10;
            
            // Assert
            Assert.Equal(1, entity.Get<Position>().X);
            Assert.Equal(0.5, entity.Get<Velocity>().VX);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that multiple ref tuples with two components maintain separate state.
        /// </summary>
        [Fact]
        public void RefTuple2_MultipleTuples_ShouldMaintainSeparateState()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();
            
            Position pos1 = new Position { X = 1, Y = 1 };
            Velocity vel1 = new Velocity { VX = 0.1f, VY = 0.1f };
            entity1.Add(pos1);
            entity1.Add(vel1);
            
            Position pos2 = new Position { X = 2, Y = 2 };
            Velocity vel2 = new Velocity { VX = 0.2f, VY = 0.2f };
            entity2.Add(pos2);
            entity2.Add(vel2);
            
            // Act
            GameObjectRefTuple<Position, Velocity> tuple1 = new GameObjectRefTuple<Position, Velocity>
            {
                GameObject = entity1,
                Item1 = new Ref<Position>(new[] { pos1 }, 0),
                Item2 = new Ref<Velocity>(new[] { vel1 }, 0)
            };
            
            GameObjectRefTuple<Position, Velocity> tuple2 = new GameObjectRefTuple<Position, Velocity>
            {
                GameObject = entity2,
                Item1 = new Ref<Position>(new[] { pos2 }, 0),
                Item2 = new Ref<Velocity>(new[] { vel2 }, 0)
            };
            
            // Assert
            Assert.NotEqual(tuple1.GameObject, tuple2.GameObject);
            Assert.Equal(1, tuple1.Item1.Value.X);
            Assert.Equal(2, tuple2.Item1.Value.X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that all fields of ref tuple with two components are accessible.
        /// </summary>
        [Fact]
        public void RefTuple2_AllFields_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 42, Y = 84 };
            Velocity vel = new Velocity { VX = 1.5f, VY = 2.5f };
            entity.Add(pos);
            entity.Add(vel);
            
            // Act
            GameObjectRefTuple<Position, Velocity> tuple = new GameObjectRefTuple<Position, Velocity>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0)
            };
            
            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(42, tuple.Item1.Value.X);
            Assert.Equal(1.5f, tuple.Item2.Value.VX);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that ref tuple with two components of same type works.
        /// </summary>
        [Fact]
        public void RefTuple2_WithSameComponentTypes_ShouldWork()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Health health = new Health { Value = 100 };
            Armor armor = new Armor { Defense = 50 };
            entity.Add(health);
            entity.Add(armor);
            
            // Act
            GameObjectRefTuple<Health, Armor> tuple = new GameObjectRefTuple<Health, Armor>
            {
                GameObject = entity,
                Item1 = new Ref<Health>(new[] { health }, 0),
                Item2 = new Ref<Armor>(new[] { armor }, 0)
            };
            
            // Assert
            Assert.Equal(100, tuple.Item1.Value.Value);
            Assert.Equal(50, tuple.Item2.Value.Defense);
            
            world.Dispose();
        }
    }
}