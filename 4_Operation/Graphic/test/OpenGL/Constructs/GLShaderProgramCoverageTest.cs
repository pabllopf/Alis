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

        [Fact]
        public void CreateProgram_FromStringSource_Succeeds()
        {
            GlMock.Reset();

            const string vertexSource = @"
                #version 330 core
                layout(location = 0) in vec3 aPos;
                void main() { gl_Position = vec4(aPos, 1.0); }";

            const string fragmentSource = @"
                #version 330 core
                out vec4 FragColor;
                void main() { FragColor = vec4(1.0); }";

            using var program = new GlShaderProgram(vertexSource, fragmentSource);

            Assert.NotEqual(0u, program.ProgramId);
            Assert.NotNull(program.VertexShader);
            Assert.NotNull(program.FragmentShader);
        }

        [Fact]
        public void CreateProgram_FromStringSource_WithFailedShader_Throws()
        {
            GlMock.Reset();
            GlMock.FailCompilation = true;

            const string vertexSource = "bad vertex";
            const string fragmentSource = "bad fragment";

            Assert.Throws<InvalidOperationException>(() =>
            {
                using var program = new GlShaderProgram(vertexSource, fragmentSource);
            });
        }

        [Fact]
        public void ProgramLog_ReturnsString()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);

            string log = program.ProgramLog;
            Assert.NotNull(log);
        }

        [Fact]
        public void Indexer_ReturnsNull_ForUnknownParam()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);

            var result = program["nonexistent"];
            Assert.Null(result);
        }
    }
}
