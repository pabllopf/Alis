using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animation compliance test class
    /// </summary>
    public class IAnimationComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by animation
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByAnimation()
        {
            Animation anim = new Animation();
            Assert.IsAssignableFrom<IAnimation>(anim);
        }

        /// <summary>
        /// Tests that animation has default properties
        /// </summary>
        [Fact]
        public void Animation_HasDefaultProperties()
        {
            Animation anim = new Animation();
            Assert.NotNull(anim.Frames);
            Assert.Empty(anim.Frames);
        }
    }
}
