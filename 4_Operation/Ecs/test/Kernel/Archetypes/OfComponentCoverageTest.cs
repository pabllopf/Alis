using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    /// The of component coverage test class
    /// </summary>
    public class OfComponentCoverageTest
    {
        /// <summary>
        /// Tests that multiple arities compile and execute
        /// </summary>
        [Fact] public void MultipleArities_CompileAndExecute()
        {
            using (Scene scene = new())
            {
                scene.Create(new Position(), new Velocity(), new Health());
                scene.Create(new Position(), new Velocity(), new Health(), new Transform());
                scene.Create(new Position(), new Velocity(), new Health(), new Transform(), new TestComponent());
                scene.Create(new Position(), new Velocity(), new Health(), new Transform(), new TestComponent(), new AnotherComponent());
                Assert.NotNull(scene);
            }
        }

        /// <summary>
        /// Tests that archetype edge key is value type
        /// </summary>
        [Fact] public void ArchetypeEdgeKey_IsValueType()
        {
            Assert.True(typeof(ArchetypeEdgeKey).IsValueType);
        }
    }
}
