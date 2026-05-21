

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Parametrized tests for Ref struct
    /// </summary>
    public class RefParametrizedTest
    {
        /// <summary>
        ///     Tests that ref create and access works
        /// </summary>
        [Fact]
        public void Ref_CreateAndAccess_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            ref Position pos = ref entity.Get<Position>();

            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }

        /// <summary>
        ///     Tests that ref modify via ref changes are persisted
        /// </summary>
        [Fact]
        public void Ref_ModifyViaRef_ChangesArePersisted()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 10, Y = 20});

            ref Position pos = ref entity.Get<Position>();
            pos.X = 30;
            pos.Y = 40;

            Assert.Equal(30, entity.Get<Position>().X);
            Assert.Equal(40, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that ref modify multiple times all changes apply
        /// </summary>
        /// <param name="initialX">The initial</param>
        /// <param name="finalX">The final</param>
        [Theory, InlineData(1, 1), InlineData(5, 5), InlineData(10, 10), InlineData(100, 100)]
        public void Ref_ModifyMultipleTimes_AllChangesApply(int initialX, int finalX)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = initialX, Y = initialX});

            ref Position pos = ref entity.Get<Position>();
            for (int i = 0; i < 10; i++)
            {
                pos.X = finalX + i;
            }

            Assert.Equal(finalX + 9, entity.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that ref multiple entities independently works
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(50)]
        public void Ref_MultipleEntitiesIndependently_Works(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create(new Position {X = i, Y = i});
            }

            for (int i = 0; i < entityCount; i++)
            {
                ref Position pos = ref entities[i].Get<Position>();
                pos.X = i * 2;
            }

            for (int i = 0; i < entityCount; i++)
            {
                Assert.Equal(i * 2, entities[i].Get<Position>().X);
            }
        }

        /// <summary>
        ///     Tests that ref health modify value
        /// </summary>
        [Fact]
        public void Ref_Health_ModifyValue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Health {Value = 100});

            ref Health health = ref entity.Get<Health>();
            health.Value = 50;

            Assert.Equal(50, entity.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that ref velocity modify both components
        /// </summary>
        [Fact]
        public void Ref_Velocity_ModifyBothComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity {X = 1, Y = 1});

            ref Velocity vel = ref entity.Get<Velocity>();
            vel.X = 10;
            vel.Y = 20;

            Assert.Equal(10, entity.Get<Velocity>().X);
            Assert.Equal(20, entity.Get<Velocity>().Y);
        }

        /// <summary>
        ///     Tests that ref transform modify coordinates
        /// </summary>
        [Fact]
        public void Ref_Transform_ModifyCoordinates()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Transform {X = 0, Y = 0});

            ref Transform transform = ref entity.Get<Transform>();
            transform.X = 100;
            transform.Y = 200;

            Assert.Equal(100, entity.Get<Transform>().X);
            Assert.Equal(200, entity.Get<Transform>().Y);
        }

        /// <summary>
        ///     Tests that ref stress test many modifications
        /// </summary>
        /// <param name="modificationCount">The modification count</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void Ref_StressTest_ManyModifications(int modificationCount)
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 0, Y = 0});

            for (int i = 0; i < modificationCount; i++)
            {
                ref Position pos = ref entity.Get<Position>();
                pos.X += 1;
                pos.Y += 1;
            }

            Assert.Equal(modificationCount, entity.Get<Position>().X);
            Assert.Equal(modificationCount, entity.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that ref chained modifications works
        /// </summary>
        [Fact]
        public void Ref_ChainedModifications_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 1},
                new Health {Value = 100}
            );

            ref Position pos = ref entity.Get<Position>();
            pos.X = 5;

            ref Health health = ref entity.Get<Health>();
            health.Value = 50;

            Assert.Equal(5, entity.Get<Position>().X);
            Assert.Equal(50, entity.Get<Health>().Value);
        }
    }
}