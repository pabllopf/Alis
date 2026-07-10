using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.OpenGL.Constructs
{
    public class GlCoverageTest
    {
        public GlCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void ShaderSource_SetsSource()
        {
            GlMock.Reset();
            uint shader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(shader, "test source");
            Assert.Equal("test source", GlMock.ShaderSources[shader]);
        }

        [Fact]
        public void GetShaderCompileStatus_ReturnsTrue_WhenCompiled()
        {
            GlMock.Reset();
            uint shader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.GlCompileShader(shader);
            Assert.True(Gl.GetShaderCompileStatus(shader));
        }

        [Fact]
        public void GetShaderCompileStatus_ReturnsFalse_WhenNotCompiled()
        {
            GlMock.Reset();
            GlMock.FailCompilation = true;
            uint shader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.GlCompileShader(shader);
            Assert.False(Gl.GetShaderCompileStatus(shader));
        }

        [Fact]
        public void GetShaderInfoLog_ReturnsError_OnFailedCompilation()
        {
            GlMock.Reset();
            GlMock.FailCompilation = true;
            uint shader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.GlCompileShader(shader);
            Assert.Equal("Mock compilation error", Gl.GetShaderInfoLog(shader));
        }

        [Fact]
        public void GetShaderInfoLog_ReturnsEmpty_OnSuccessfulCompilation()
        {
            GlMock.Reset();
            uint shader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.GlCompileShader(shader);
            Assert.Empty(Gl.GetShaderInfoLog(shader));
        }

        [Fact]
        public void GetProgramLinkStatus_ReturnsTrue_WhenLinked()
        {
            GlMock.Reset();
            uint program = Gl.GlCreateProgram();
            Gl.GlLinkProgram(program);
            Assert.True(Gl.GetProgramLinkStatus(program));
        }

        [Fact]
        public void GetProgramLinkStatus_ReturnsFalse_WhenNotLinked()
        {
            GlMock.Reset();
            GlMock.FailLink = true;
            uint program = Gl.GlCreateProgram();
            Gl.GlLinkProgram(program);
            Assert.False(Gl.GetProgramLinkStatus(program));
        }

        [Fact]
        public void GetProgramInfoLog_ReturnsError_OnFailedLink()
        {
            GlMock.Reset();
            GlMock.FailLink = true;
            uint program = Gl.GlCreateProgram();
            Gl.GlLinkProgram(program);
            Assert.Equal("Mock link error", Gl.GetProgramInfoLog(program));
        }

        [Fact]
        public void GenBuffer_ReturnsNonZero()
        {
            GlMock.Reset();
            Assert.NotEqual(0u, Gl.GenBuffer());
        }

        [Fact]
        public void DeleteBuffer_DoesNotThrow()
        {
            GlMock.Reset();
            Gl.DeleteBuffer(1);
        }

        [Fact]
        public void GenVertexArray_ReturnsNonZero()
        {
            GlMock.Reset();
            Assert.NotEqual(0u, Gl.GenVertexArray());
        }

        [Fact]
        public void DeleteVertexArray_DoesNotThrow()
        {
            GlMock.Reset();
            Gl.DeleteVertexArray(1);
        }

        [Fact]
        public void GenTexture_ReturnsNonZero()
        {
            GlMock.Reset();
            Assert.NotEqual(0u, Gl.GenTexture());
        }

        [Fact]
        public void DeleteTexture_DoesNotThrow()
        {
            GlMock.Reset();
            Gl.DeleteTexture(1);
        }

        [Fact]
        public void GetError_ReturnsZero()
        {
            GlMock.Reset();
            Assert.Equal(0, Gl.GlGetError());
        }

        [Fact]
        public void LineWidth_DoesNotThrow()
        {
            GlMock.Reset();
            Gl.GlLineWidth(1.0f);
        }

        [Fact]
        public void ActiveTexture_DoesNotThrow()
        {
            GlMock.Reset();
            Gl.GlActiveTexture(TextureUnit.Texture0);
        }

        [Fact]
        public void GenerateMipmap_DoesNotThrow()
        {
            GlMock.Reset();
            Gl.GenerateMipmap(TextureTarget.Texture2D);
        }
    }
}
