using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// The gl shader program param safe tests class
    /// </summary>
    public class GlShaderProgramParamSafeTests
    {
        /// <summary>
        /// Tests that constructor 3 params sets fields
        /// </summary>
        [Fact]
        public void Constructor_3Params_SetsFields()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
            Assert.Equal(typeof(int), param.Type);
            Assert.Equal(ParamType.Uniform, param.ParamType);
            Assert.Equal("test", param.Name);
        }

        /// <summary>
        /// Tests that constructor 5 params sets fields
        /// </summary>
        [Fact]
        public void Constructor_5Params_SetsFields()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Attribute, "attr", 42u, 7);
            Assert.Equal(typeof(float), param.Type);
            Assert.Equal(ParamType.Attribute, param.ParamType);
            Assert.Equal("attr", param.Name);
        }

        /// <summary>
        /// Tests that location get set works
        /// </summary>
        [Fact]
        public void Location_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            Assert.Equal(0, param.Location);
            param.Location = 42;
            Assert.Equal(42, param.Location);
            param.Location = -5;
            Assert.Equal(-5, param.Location);
        }

        /// <summary>
        /// Tests that program get set works
        /// </summary>
        [Fact]
        public void Program_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            Assert.Equal(0u, param.Program);
            param.Program = 123u;
            Assert.Equal(123u, param.Program);
        }

        /// <summary>
        /// Tests that program id get set works
        /// </summary>
        [Fact]
        public void ProgramId_GetSet_Works()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            Assert.Equal(0u, param.ProgramId);
            param.ProgramId = 456u;
            Assert.Equal(456u, param.ProgramId);
        }

        /// <summary>
        /// Tests that gl shader program param is sealed
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_IsSealed()
        {
            Assert.True(typeof(GlShaderProgramParam).IsSealed);
        }

        /// <summary>
        /// Tests that readonly fields exist
        /// </summary>
        [Fact]
        public void ReadonlyFields_Exist()
        {
            FieldInfo nameField = typeof(GlShaderProgramParam).GetField("Name", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo paramTypeField = typeof(GlShaderProgramParam).GetField("ParamType", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo typeField = typeof(GlShaderProgramParam).GetField("Type", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(nameField);
            Assert.NotNull(paramTypeField);
            Assert.NotNull(typeField);
        }

        /// <summary>
        /// Tests that set value float array invalid length throws argument exception
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_InvalidLength_ThrowsArgumentException()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "x");
            var ex = Assert.Throws<ArgumentException>(() => param.SetValue(new float[0]));
            Assert.Equal("param", ex.ParamName);
        }

        /// <summary>
        /// Tests that set value float array length 16 works with matrix type
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length16_WorksWithMatrixType()
        {
            var param = new GlShaderProgramParam(typeof(Matrix4X4), ParamType.Uniform, "m");
            Assert.ThrowsAny<Exception>(() => param.SetValue(new float[16]));
        }

        /// <summary>
        /// Tests that set value float array length 4 works with vector 4 type
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length4_WorksWithVector4Type()
        {
            var param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "v4");
            Assert.ThrowsAny<Exception>(() => param.SetValue(new float[4]));
        }

        /// <summary>
        /// Tests that set value float array length 3 works with vector 3 type
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length3_WorksWithVector3Type()
        {
            var param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "v3");
            Assert.ThrowsAny<Exception>(() => param.SetValue(new float[3]));
        }

        /// <summary>
        /// Tests that set value float array length 2 works with vector 2 type
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length2_WorksWithVector2Type()
        {
            var param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "v2");
            Assert.ThrowsAny<Exception>(() => param.SetValue(new float[2]));
        }

        /// <summary>
        /// Tests that set value float array length 1 works with float type
        /// </summary>
        [Fact]
        public void SetValue_FloatArray_Length1_WorksWithFloatType()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "f");
            Assert.ThrowsAny<Exception>(() => param.SetValue(new float[1]));
        }

        /// <summary>
        /// Tests that set value bool throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Bool_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(bool), ParamType.Uniform, "b");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(true));
        }

        /// <summary>
        /// Tests that set value int throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Int_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "i");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(42));
        }

        /// <summary>
        /// Tests that set value float throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Float_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "f");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(3.14f));
        }

        /// <summary>
        /// Tests that set value vector 2 f throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Vector2F_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Vector2F), ParamType.Uniform, "v2");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(new Vector2F()));
        }

        /// <summary>
        /// Tests that set value vector 3 f throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Vector3F_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Vector3F), ParamType.Uniform, "v3");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(new Vector3F()));
        }

        /// <summary>
        /// Tests that set value vector 4 f throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Vector4F_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Vector4F), ParamType.Uniform, "v4");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(new Vector4F()));
        }

        /// <summary>
        /// Tests that set value matrix 4 x 4 throws when gl not initialized
        /// </summary>
        [Fact]
        public void SetValue_Matrix4X4_ThrowsWhenGlNotInitialized()
        {
            var param = new GlShaderProgramParam(typeof(Matrix4X4), ParamType.Uniform, "m4");
            param.Location = 0;
            Assert.ThrowsAny<Exception>(() => param.SetValue(new Matrix4X4()));
        }
    }
}
