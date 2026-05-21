

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the Version struct.
    /// </summary>
    public class VersionTest
    {
        /// <summary>
        ///     Tests the Version constructor with valid parameters.
        /// </summary>
        [Fact]
        public void VersionConstructor_WithValidParameters_InitializesCorrectly()
        {
            int major = 2;
            int minor = 0;
            int patch = 18;

            Version version = new Version(major, minor, patch);

            Assert.Equal((byte) major, version.major);
            Assert.Equal((byte) minor, version.minor);
            Assert.Equal((byte) patch, version.patch);
        }

        /// <summary>
        ///     Tests the Version constructor with zero values.
        /// </summary>
        [Fact]
        public void VersionConstructor_WithZeroValues_InitializesZeroVersion()
        {
            Version version = new Version(0, 0, 0);

            Assert.Equal(0, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(0, version.patch);
        }

        /// <summary>
        ///     Tests the Version constructor with maximum byte values.
        /// </summary>
        [Fact]
        public void VersionConstructor_WithMaxByteValues_InitializesMaxVersion()
        {
            int major = 255;
            int minor = 255;
            int patch = 255;

            Version version = new Version(major, minor, patch);

            Assert.Equal(255, version.major);
            Assert.Equal(255, version.minor);
            Assert.Equal(255, version.patch);
        }

        /// <summary>
        ///     Tests the Version constructor with different values.
        /// </summary>
        [Theory, InlineData(1, 2, 3), InlineData(5, 10, 15), InlineData(100, 50, 25)]
        public void VersionConstructor_WithDifferentValues_InitializesProperly(int major, int minor, int patch)
        {
            Version version = new Version(major, minor, patch);

            Assert.Equal((byte) major, version.major);
            Assert.Equal((byte) minor, version.minor);
            Assert.Equal((byte) patch, version.patch);
        }
    }
}