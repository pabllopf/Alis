 using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class GameObjectAddRemoveOverloadsUnitTest
    {
        [Fact]
        public void Add_Arity1_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position { X = 1, Y = 2 });

            Assert.True(entity.Has<Position>());
            Assert.Equal(1, entity.Get<Position>().X);
            Assert.Equal(2, entity.Get<Position>().Y);
        }

        [Fact]
        public void Add_Arity2_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.Equal(3, entity.Get<Velocity>().X);
        }

        [Fact]
        public void Add_Arity3_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 5 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.Equal(5, entity.Get<Health>().Value);
        }

        [Fact]
        public void Add_Arity4_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 5 },
                new Armor { Value = 6 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.Equal(6, entity.Get<Armor>().Value);
        }

        [Fact]
        public void Add_Arity5_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 5 },
                new Armor { Value = 6 },
                new Damage { Value = 7 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.Equal(7, entity.Get<Damage>().Value);
        }

        [Fact]
        public void Add_Arity6_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 5 },
                new Armor { Value = 6 },
                new Damage { Value = 7 },
                new Transform { X = 8, Y = 9, Rotation = 10 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.Equal(10, entity.Get<Transform>().Rotation);
        }

        [Fact]
        public void Add_Arity7_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 5 },
                new Armor { Value = 6 },
                new Damage { Value = 7 },
                new Transform { X = 8, Y = 9, Rotation = 10 },
                new TestComponent { Value = 11 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
            Assert.Equal(11, entity.Get<TestComponent>().Value);
        }

        [Fact]
        public void Add_Arity8_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 5 },
                new Armor { Value = 6 },
                new Damage { Value = 7 },
                new Transform { X = 8, Y = 9, Rotation = 10 },
                new TestComponent { Value = 11 },
                new AnotherComponent { Name = "eight", Data = 12, Y = 13 });

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
            Assert.True(entity.Has<AnotherComponent>());
            Assert.Equal("eight", entity.Get<AnotherComponent>().Name);
            Assert.Equal(12, entity.Get<AnotherComponent>().Data);
        }

        [Fact]
        public void Remove_Arity1_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position>();

            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity2_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity3_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity, Health>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity4_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity, Health, Armor>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity5_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity, Health, Armor, Damage>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity6_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity, Health, Armor, Damage, Transform>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity7_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.True(entity.Has<AnotherComponent>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_Arity8_UsesGenericOverload()
        {
            using Scene scene = new Scene();
            GameObject entity = CreateEntityWithNineComponents(scene);

            entity.Remove<Position, Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>();

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
            Assert.True(entity.Has<AnotherComponent2>());
            Assert.Equal("marker", entity.Get<AnotherComponent2>().Name);
            Assert.Equal(99, entity.Get<AnotherComponent2>().Data);
        }

        private static GameObject CreateEntityWithNineComponents(Scene scene)
        {
            GameObject entity = scene.Create();

            entity.Add(new Position { X = 1, Y = 2 });
            entity.Add(new Velocity { X = 3, Y = 4 });
            entity.Add(new Health { Value = 5 });
            entity.Add(new Armor { Value = 6 });
            entity.Add(new Damage { Value = 7 });
            entity.Add(new Transform { X = 8, Y = 9, Rotation = 10 });
            entity.Add(new TestComponent { Value = 11 });
            entity.Add(new AnotherComponent { Name = "payload", Data = 12, Y = 13 });
            entity.Add(new AnotherComponent2 { Name = "marker", Data = 99 });

            return entity;
        }
    }
}

