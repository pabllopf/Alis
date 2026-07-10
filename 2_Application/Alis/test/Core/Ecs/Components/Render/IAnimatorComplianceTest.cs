using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class IAnimatorComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByAnimator()
        {
            var animator = new Animator();
            Assert.IsAssignableFrom<IAnimator>(animator);
        }
    }
}
