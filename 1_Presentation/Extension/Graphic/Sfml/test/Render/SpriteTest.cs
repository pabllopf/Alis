using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// Unit tests for the Sprite class.
    /// </summary>
    public class SpriteTest
    {
        /// <summary>
        /// Tests default constructor creates a valid object.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesObject()
        {
            Sprite sprite = new Sprite();
            Assert.NotNull(sprite);
        }

        /// <summary>
        /// Tests constructor with texture parameter.
        /// </summary>
        [Fact]
        public void Constructor_WithTexture_Works()
        {
            Texture texture = null;
            Sprite sprite = new Sprite(texture);
            Assert.NotNull(sprite);
        }
    }
}

