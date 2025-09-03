using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The bvec tests class
    /// </summary>
    public class Bvec3Tests
    {
        /// <summary>
        /// Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            var bvec = new Bvec3(true, false, true);
            Assert.True(bvec.X);
            Assert.False(bvec.Y);
            Assert.True(bvec.Z);
        }

        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            var bvec = new Bvec3();
            bvec.X = false;
            bvec.Y = true;
            bvec.Z = false;
            Assert.False(bvec.X);
            Assert.True(bvec.Y);
            Assert.False(bvec.Z);
        }
    }
}

