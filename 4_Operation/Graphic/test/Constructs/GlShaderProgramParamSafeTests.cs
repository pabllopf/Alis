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
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "test");
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
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Attribute, "attr", 42u, 7);
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
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "n");
            Assert.Equal(0, param.Location);
            param.Location = 42;
            Assert.Equal(42, param.Location);
            param.Location = -5;
            Assert.Equal(-5, param.Location);
        }
      
    }
}
