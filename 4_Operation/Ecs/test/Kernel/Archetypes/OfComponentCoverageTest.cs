using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    public class OfComponentCoverageTest
    {
        [Fact]
        public void MultipleArities_CompileAndExecute()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health());
            scene.Create(new Position(), new Velocity(), new Health(), new Transform());
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(), new TestComponent());
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(), new TestComponent(), new AnotherComponent());
            Assert.NotNull(scene);
        }

        [Fact]
        public void ArchetypeEdgeKey_IsValueType()
        {
            Assert.True(typeof(ArchetypeEdgeKey).IsValueType);
        }
    }
}
