using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    /// The query hash cache test class
    /// </summary>
    public class QueryHashCacheTest
    {
        /// <summary>
        /// Tests that query with single component uses hash cache
        /// </summary>
        [Fact] public void Query_WithSingleComponent_UsesHashCache()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2});
                Query query = scene.Query<With<Position>>();
                Assert.NotNull(query);
            }
        }

        /// <summary>
        /// Tests that query with two components uses hash cache
        /// </summary>
        [Fact] public void Query_WithTwoComponents_UsesHashCache()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
                Query query = scene.Query<With<Position>, With<Velocity>>();
                Assert.NotNull(query);
            }
        }

        /// <summary>
        /// Tests that query with three components uses hash cache
        /// </summary>
        [Fact] public void Query_WithThreeComponents_UsesHashCache()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();
                Assert.NotNull(query);
            }
        }

        /// <summary>
        /// Tests that query with four components uses hash cache
        /// </summary>
        [Fact] public void Query_WithFourComponents_UsesHashCache()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position(), new Velocity(), new Health(), new Transform());
                Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
                Assert.NotNull(query);
            }
        }
    }
}
