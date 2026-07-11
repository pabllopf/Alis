using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The sprite coverage test class
    /// </summary>
    public class SpriteCoverageTest
    {
        /// <summary>
        /// Tests that is sprite visible center within camera returns true
        /// </summary>
        [Fact]
        public void IsSpriteVisible_CenterWithinCamera_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        /// Tests that is sprite visible far outside camera returns false
        /// </summary>
        [Fact]
        public void IsSpriteVisible_FarOutsideCamera_ReturnsFalse()
        {
            Vector2F spritePos = new Vector2F(1000, 1000);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.False(visible);
        }

        /// <summary>
        /// Tests that is sprite visible with rotation returns true
        /// </summary>
        [Fact]
        public void IsSpriteVisible_WithRotation_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 45f;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        /// Tests that is sprite visible with negative rotation returns true
        /// </summary>
        [Fact]
        public void IsSpriteVisible_WithNegativeRotation_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(0, 0);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = -45f;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        /// Tests that is sprite visible with large scale returns true
        /// </summary>
        [Fact]
        public void IsSpriteVisible_WithLargeScale_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(10, 10);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(10, 10);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        /// Tests that is sprite visible at edge of camera returns true
        /// </summary>
        [Fact]
        public void IsSpriteVisible_AtEdgeOfCamera_ReturnsTrue()
        {
            Vector2F spritePos = new Vector2F(11.9f, 8.9f);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.True(visible);
        }

        /// <summary>
        /// Tests that is sprite visible beyond edge of camera returns false
        /// </summary>
        [Fact]
        public void IsSpriteVisible_BeyondEdgeOfCamera_ReturnsFalse()
        {
            Vector2F spritePos = new Vector2F(20, 15);
            Vector2F spriteSize = new Vector2F(32, 32);
            Vector2F spriteScale = new Vector2F(1, 1);
            float rotation = 0;
            Vector2F cameraPos = new Vector2F(0, 0);
            Vector2F cameraRes = new Vector2F(800, 600);
            float ppm = 32;

            bool visible = Sprite.IsSpriteVisible(spritePos, spriteSize, spriteScale, rotation, cameraPos, cameraRes, ppm);

            Assert.False(visible);
        }
    }
}
