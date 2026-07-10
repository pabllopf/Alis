using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class IAnimationComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByAnimation()
        {
            var anim = new Animation();
            Assert.IsAssignableFrom<IAnimation>(anim);
        }

        [Fact]
        public void Animation_HasDefaultProperties()
        {
            var anim = new Animation();
            Assert.NotNull(anim.Frames);
            Assert.Empty(anim.Frames);
        }
    }
}
