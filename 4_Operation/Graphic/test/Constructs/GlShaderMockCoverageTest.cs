using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderMockCoverageTest
    {
        public GlShaderMockCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void CreateVertexShader_WithValidSource_Succeeds()
        {
            GlMock.Reset();
            using var shader = new GlShader("void main(){}", ShaderType.VertexShader);
            Assert.NotEqual(0u, shader.ShaderId);
            Assert.Equal(ShaderType.VertexShader, shader.ShaderType);
        }

        [Fact]
        public void CreateFragmentShader_WithValidSource_Succeeds()
        {
            GlMock.Reset();
            using var shader = new GlShader("void main(){}", ShaderType.FragmentShader);
            Assert.NotEqual(0u, shader.ShaderId);
            Assert.Equal(ShaderType.FragmentShader, shader.ShaderType);
        }

        [Fact]
        public void CreateShader_WithInvalidSource_ThrowsInvalidOperationException()
        {
            GlMock.Reset();
            GlMock.FailCompilation = true;
            Assert.Throws<System.InvalidOperationException>(() => new GlShader("bad", ShaderType.VertexShader));
        }

        [Fact]
        public void Dispose_ReleasesUnmanagedResources()
        {
            GlMock.Reset();
            var shader = new GlShader("void main(){}", ShaderType.VertexShader);
            shader.Dispose();
            Assert.Equal(0u, shader.ShaderId);
        }
    }
}
