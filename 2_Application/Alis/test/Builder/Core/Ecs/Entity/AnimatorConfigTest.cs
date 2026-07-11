using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    /// <summary>
    /// The animator config test class
    /// </summary>
    public class AnimatorConfigTest
    {
        /// <summary>
        /// Tests that delegate can be invoked
        /// </summary>
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            AnimatorConfig<Animator> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
