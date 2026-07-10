using System;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.OpenGL.Constructs
{
    public class GLShaderProgramCoverageTest
    {
        public GLShaderProgramCoverageTest()
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
            Assert.Same(vertex, program.VertexShader);
            Assert.Same(fragment, program.FragmentShader);
        }

        [Fact]
        public void CreateProgram_WithFailedLink_ThrowsInvalidOperationException()
        {
            GlMock.Reset();
            GlMock.FailLink = true;

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);

            Assert.Throws<InvalidOperationException>(() =>
            {
                using var program = new GlShaderProgram(vertex, fragment);
            });
        }

        [Fact]
        public void UseProgram_SetsCurrentProgram()
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

            int location = program.GetUniformLocation("testUniform");
            Assert.NotEqual(-1, location);
        }

        [Fact]
        public void GetAttribLocation_ReturnsLocation()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);

            int location = program.GetAttributeLocation("testAttrib");
            Assert.NotEqual(-1, location);
        }

        [Fact]
        public void Dispose_ReleasesProgramResources()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            var program = new GlShaderProgram(vertex, fragment);
            uint programId = program.ProgramId;

            program.Dispose();
            Assert.Equal(0u, program.ProgramId);
        }

        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            var program = new GlShaderProgram(vertex, fragment);

            program.Dispose();
            program.Dispose();
        }

        [Fact]
        public void UseProgram_AfterDispose_DoesNotThrow()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);

            program.Dispose();
            program.Use();
        }
    }
}
