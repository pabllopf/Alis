using System;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The sdl image test class
    /// </summary>
    public class SdlImageTest
    {
        /// <summary>
        /// Tests that should return compiled version
        /// </summary>
        [Fact]
        public void ShouldReturnCompiledVersion()
        {
            Version version = SdlImage.Version();
            Assert.Equal(2, version.Major);
            Assert.Equal(0, version.Minor);
        }
    }
}
