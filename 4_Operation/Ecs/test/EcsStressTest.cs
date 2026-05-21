

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The ECS stress test class
    /// </summary>
    /// <remarks>
    ///     Stress tests for the ECS system to validate performance and stability
    ///     under heavy loads. Tests include large entity counts, many archetypes,
    ///     and intensive operations.
    /// </remarks>
    public class EcsStressTest
    {
        /// <summary>
        ///     Tests rapid component addition and removal cycles
        /// </summary>
        /// <remarks>
        ///     Validates that frequent structural changes don't corrupt
        ///     entity state or cause performance issues.
        /// </remarks>
        [Fact]
        public void EcsStress_RapidComponentCyclesDoNotCorrupt()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            for (int cycle = 0; cycle < 100; cycle++)
            {
                entity.Add(new Position());
                entity.Add(new Velocity());
                entity.Add(new Health());
                entity.Remove<Health>();
                entity.Remove<Velocity>();
                entity.Remove<Position>();
            }

            Assert.False(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }
    }
}