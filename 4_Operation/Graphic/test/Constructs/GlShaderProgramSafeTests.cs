using System;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// The gl shader program safe tests class
    /// </summary>
    public class GlShaderProgramSafeTests
    {
        /// <summary>
        /// Tests that gl shader program is sealed
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsSealed()
        {
            Assert.True(typeof(GlShaderProgram).IsSealed);
        }

        /// <summary>
        /// Tests that gl shader program implements i disposable
        /// </summary>
        [Fact]
        public void GlShaderProgram_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));
        }

        /// <summary>
        /// Tests that constructor string params throws when gl not available
        /// </summary>
        [Fact]
        public void Constructor_StringParams_ThrowsWhenGlNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("void main(){}", "void main(){}"));
        }

    }
}
