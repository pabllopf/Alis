using System;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.OpenGL.Constructs
{
    public class GLShaderCoverageTest
    {
        public GLShaderCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void CreateVertexShader_WithValidSource_Succeeds()
        {
            GlMock.Reset();

            const string source = @"
                #version 330 core
                layout(location = 0) in vec3 aPos;
                void main()
                {
                    gl_Position = vec4(aPos, 1.0);
                }";

            using GlShader shader = new GlShader(source, ShaderType.VertexShader);

            Assert.NotEqual(0u, shader.ShaderId);
            Assert.Equal(ShaderType.VertexShader, shader.ShaderType);
        }

        [Fact]
        public void CreateFragmentShader_WithValidSource_Succeeds()
        {
            GlMock.Reset();

            const string source = @"
                #version 330 core
                out vec4 FragColor;
                void main()
                {
                    FragColor = vec4(1.0, 1.0, 1.0, 1.0);
                }";

            using GlShader shader = new GlShader(source, ShaderType.FragmentShader);

            Assert.NotEqual(0u, shader.ShaderId);
            Assert.Equal(ShaderType.FragmentShader, shader.ShaderType);
        }

        [Fact]
        public void CreateShader_WithInvalidSource_ThrowsInvalidOperationException()
        {
            GlMock.Reset();
            GlMock.FailCompilation = true;

            const string source = "invalid shader source code";

            Assert.Throws<InvalidOperationException>(() =>
            {
                using var shader = new GlShader(source, ShaderType.VertexShader);
            });
        }

        [Fact]
        public void ShaderLog_ReturnsNonEmpty_AfterFailedCompilation()
        {
            GlMock.Reset();
            GlMock.FailCompilation = true;

            InvalidOperationException caught = null;
            try
            {
                using var shader = new GlShader("bad", ShaderType.VertexShader);
            }
            catch (InvalidOperationException ex)
            {
                caught = ex;
            }

            Assert.NotNull(caught);
            Assert.False(string.IsNullOrEmpty(caught.Message));
        }



        [Fact]
        public void Dispose_ReleasesUnmanagedResources()
        {
            GlMock.Reset();

            using var shader = new GlShader("void main(){}", ShaderType.VertexShader);
            uint shaderId = shader.ShaderId;

            shader.Dispose();
            Assert.Equal(0u, shader.ShaderId);
        }

        [Fact]
        public void MultipleDispose_DoesNotThrow()
        {
            GlMock.Reset();

            using var shader = new GlShader("void main(){}", ShaderType.VertexShader);

            shader.Dispose();
            shader.Dispose();
        }
    }
}
