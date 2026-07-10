using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramParamMockCoverageTest
    {
        public GlShaderProgramParamMockCoverageTest()
        {
            GlMock.Initialize();
        }

        [Fact]
        public void CreateParam_WithTypeAndName_Succeeds()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            Assert.Equal("test", param.Name);
            Assert.Equal(ParamType.Uniform, param.ParamType);
            Assert.Equal(typeof(int), param.Type);
        }

        [Fact]
        public void CreateParam_WithFullConstructor_Succeeds()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test", 1, 0);
            Assert.Equal(1u, param.ProgramId);
            Assert.Equal(0, param.Location);
        }

        [Fact]
        public void SetValue_Bool_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(bool), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(true);
        }

        [Fact]
        public void SetValue_Int_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(42);
        }

        [Fact]
        public void SetValue_Float_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(3.14f);
        }

        [Fact]
        public void SetValue_Vector2F_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(new Vector2F(1, 2));
        }

        [Fact]
        public void SetValue_Vector3F_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(new Vector3F(1, 2, 3));
        }

        [Fact]
        public void SetValue_Vector4F_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(new Vector4F(1, 2, 3, 4));
        }

        [Fact]
        public void SetValue_Matrix4X4_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(new Alis.Core.Aspect.Math.Matrix.Matrix4X4());
        }

        [Fact]
        public void SetValue_FloatArray_DoesNotThrow()
        {
            var param = new GlShaderProgramParam(typeof(float[]), ParamType.Uniform, "test");
            param.Location = 0;
            param.SetValue(new float[] { 1, 2, 3, 4 });
        }

        [Fact]
        public void GetLocation_WithProgram_SetsLocation()
        {
            GlMock.Reset();

            using var vertex = new GlShader("void main(){}", ShaderType.VertexShader);
            using var fragment = new GlShader("void main(){}", ShaderType.FragmentShader);
            using var program = new GlShaderProgram(vertex, fragment);

            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "test");
            param.GetLocation(program);

            Assert.NotEqual(-1, param.Location);
        }
    }
}
