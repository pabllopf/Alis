using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animator compliance test class
    /// </summary>
    public class IAnimatorComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by animator
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByAnimator()
        {
            Animator animator = new Animator();
            Assert.IsAssignableFrom<IAnimator>(animator);
        }
    }
}
