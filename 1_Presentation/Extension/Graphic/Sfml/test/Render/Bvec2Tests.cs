using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The bvec tests class
    /// </summary>
    public class Bvec2Tests
    {
        /// <summary>
        /// Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            var bvec = new Bvec2(true, false);
            Assert.True(bvec.X);
            Assert.False(bvec.Y);
        }

        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            var bvec = new Bvec2();
            bvec.X = false;
            bvec.Y = true;
            Assert.False(bvec.X);
            Assert.True(bvec.Y);
        }
    }
}

