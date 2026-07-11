// license header
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class ShaderTest
    {
        [Fact]
        public void Shader_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Shader)));
        }

        [Fact]
        public void CurrentTexture_IsNull()
        {
            Assert.Null(Shader.CurrentTexture);
        }

        [Fact]
        public void NativeHandle_Property_Exists()
        {
            Assert.NotNull(typeof(Shader).GetProperty("NativeHandle"));
        }

        [Fact]
        public void IsAvailable_IsGeometryAvailable_Properties_Exist()
        {
            Assert.NotNull(typeof(Shader).GetProperty("IsAvailable"));
            Assert.NotNull(typeof(Shader).GetProperty("IsGeometryAvailable"));
        }

        [Fact]
        public void SetUniform_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Shader).GetMethod("SetUniform", new[] { typeof(string), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetUniform", new[] { typeof(string), typeof(int) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetUniform", new[] { typeof(string), typeof(bool) }));
        }

        [Fact]
        public void SetParameter_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float), typeof(float), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float), typeof(float), typeof(float), typeof(float) }));
        }

        [Fact]
        public void Bind_StaticMethod_Exists()
        {
            var method = typeof(Shader).GetMethod("Bind", new[] { typeof(Shader) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        [Fact]
        public void FromString_StaticMethod_Exists()
        {
            var method = typeof(Shader).GetMethod("FromString", new[] { typeof(string), typeof(string), typeof(string) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        [Fact]
        public void SetUniformArray_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Shader).GetMethod("SetUniformArray", new[] { typeof(string), typeof(float[]) }));
        }
    }
}
