using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.OpenGL.Constructs
{
    public class GLShaderProgramParamCoverageTest
    {
        public GLShaderProgramParamCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void CreateParam_WithTypeAndName_Succeeds()
        {
            GlMock.Reset();

            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "testParam");

            Assert.Equal("testParam", param.Name);
            Assert.Equal(ParamType.Uniform, param.ParamType);
            Assert.Equal(typeof(int), param.Type);
        }

        [Fact]
        public void SetValue_WithBool_DoesNotThrow()
        {
            GlMock.Reset();

            var param = new GlShaderProgramParam(typeof(bool), ParamType.Uniform, "testBool");
            param.Location = 0;

            param.SetValue(true);
        }

        [Fact]
        public void SetValue_WithInt_DoesNotThrow()
        {
            GlMock.Reset();

            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "testInt");
            param.Location = 0;

            param.SetValue(42);
        }

        [Fact]
        public void SetValue_WithFloat_DoesNotThrow()
        {
            GlMock.Reset();

            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "testFloat");
            param.Location = 0;

            param.SetValue(3.14f);
        }

        [Fact]
        public void GetLocation_WithProgram_SetsLocation()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);

            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "testUniform");
            param.GetLocation(program);

            Assert.NotEqual(-1, param.Location);
        }
    }
}
