using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class ISpriteComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedBySprite()
        {
            var sprite = new Sprite();
            Assert.IsAssignableFrom<ISprite>(sprite);
        }
    }
}
