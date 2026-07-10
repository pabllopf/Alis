using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    public class AnimatorConfigTest
    {
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            AnimatorConfig<Animator> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
