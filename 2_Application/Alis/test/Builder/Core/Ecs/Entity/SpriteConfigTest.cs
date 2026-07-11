using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    /// <summary>
    /// The sprite config test class
    /// </summary>
    public class SpriteConfigTest
    {
        /// <summary>
        /// Tests that delegate can be invoked
        /// </summary>
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            SpriteConfig<Sprite> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
