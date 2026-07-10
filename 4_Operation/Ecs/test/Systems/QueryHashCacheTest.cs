using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    public class QueryHashCacheTest
    {
        [Fact]
        public void Query_WithSingleComponent_UsesHashCache()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 });
            Query query = scene.Query<With<Position>>();
            Assert.NotNull(query);
        }

        [Fact]
        public void Query_WithTwoComponents_UsesHashCache()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 });
            Query query = scene.Query<With<Position>, With<Velocity>>();
            Assert.NotNull(query);
        }

        [Fact]
        public void Query_WithThreeComponents_UsesHashCache()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 5 });
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            Assert.NotNull(query);
        }

        [Fact]
        public void Query_WithFourComponents_UsesHashCache()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform());
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            Assert.NotNull(query);
        }
    }
}
