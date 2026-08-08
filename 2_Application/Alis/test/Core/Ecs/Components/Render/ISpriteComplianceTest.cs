using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The sprite compliance test class
    /// </summary>
    public class ISpriteComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by sprite
        /// </summary>
        [Fact]
        public void Interface_IsImplementedBySprite()
        {
            Sprite sprite = new Sprite();
            Assert.IsAssignableFrom<ISprite>(sprite);
        }
    }
}
