using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    public class SpriteConfigTest
    {
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            SpriteConfig<Sprite> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
