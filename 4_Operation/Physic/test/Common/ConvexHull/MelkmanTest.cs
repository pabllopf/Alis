using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    /// <summary>
    /// The melkman test class
    /// </summary>
    public class MelkmanTest
    {
        /// <summary>
        /// Tests that melkman type should be accessible
        /// </summary>
        [Fact]
        public void Melkman_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.ConvexHull.Melkman));
        }
    }
}

