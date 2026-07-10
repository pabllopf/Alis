using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramMockCoverageTest
    {
        public GlShaderProgramMockCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void CreateProgram_WithValidShaders_Succeeds()
        {
            GlMock.Reset();
            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);
            Assert.NotEqual(0u, program.ProgramId);
        }

        [Fact]
        public void CreateProgram_WithFailedLink_Throws()
        {
            GlMock.Reset();
            GlMock.FailLink = true;
            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            Assert.Throws<System.InvalidOperationException>(() => new GlShaderProgram(vertex, fragment));
        }

        [Fact]
        public void UseProgram_DoesNotThrow()
        {
            GlMock.Reset();
            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);
            program.Use();
        }

        [Fact]
        public void GetUniformLocation_ReturnsLocation()
        {
            GlMock.Reset();
            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);
            Assert.NotEqual(-1, program.GetUniformLocation("test"));
        }

        [Fact]
        public void Dispose_ReleasesProgramResources()
        {
            GlMock.Reset();
            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            var program = new GlShaderProgram(vertex, fragment);
            program.Dispose();
            Assert.Equal(0u, program.ProgramId);
        }
    }
}
