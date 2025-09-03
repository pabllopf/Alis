using Xunit;
using Alis.Extension.Graphic.Sfml.Render;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The bvec tests class
    /// </summary>
    public class Bvec4Tests
    {
        /// <summary>
        /// Tests that constructor sets fields correctly
        /// </summary>
        [Fact]
        public void Constructor_SetsFieldsCorrectly()
        {
            Bvec4 bvec = new Bvec4(true, false, true, false);
            Assert.True(bvec.X);
            Assert.False(bvec.Y);
            Assert.True(bvec.Z);
            Assert.False(bvec.W);
        }

        /// <summary>
        /// Tests that can set fields
        /// </summary>
        [Fact]
        public void CanSetFields()
        {
            Bvec4 bvec = new Bvec4();
            bvec.X = false;
            bvec.Y = true;
            bvec.Z = false;
            bvec.W = true;
            Assert.False(bvec.X);
            Assert.True(bvec.Y);
            Assert.False(bvec.Z);
            Assert.True(bvec.W);
        }
    }
}

