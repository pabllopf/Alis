// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The shader test class
    /// </summary>
    public class ShaderTest
    {
        /// <summary>
        /// Tests that shader is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Shader_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Shader)));
        }

        /// <summary>
        /// Tests that current texture is null
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CurrentTexture_IsNull()
        {
            Assert.Null(Shader.CurrentTexture);
        }

        /// <summary>
        /// Tests that native handle property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_Property_Exists()
        {
            Assert.NotNull(typeof(Shader).GetProperty("NativeHandle"));
        }

        /// <summary>
        /// Tests that is available is geometry available properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsAvailable_IsGeometryAvailable_Properties_Exist()
        {
            Assert.NotNull(typeof(Shader).GetProperty("IsAvailable"));
            Assert.NotNull(typeof(Shader).GetProperty("IsGeometryAvailable"));
        }

        /// <summary>
        /// Tests that set uniform multiple overloads exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniform_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Shader).GetMethod("SetUniform", new[] { typeof(string), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetUniform", new[] { typeof(string), typeof(int) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetUniform", new[] { typeof(string), typeof(bool) }));
        }

        /// <summary>
        /// Tests that set parameter multiple overloads exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetParameter_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float), typeof(float), typeof(float) }));
            Assert.NotNull(typeof(Shader).GetMethod("SetParameter", new[] { typeof(string), typeof(float), typeof(float), typeof(float), typeof(float) }));
        }

        /// <summary>
        /// Tests that bind static method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_StaticMethod_Exists()
        {
            var method = typeof(Shader).GetMethod("Bind", new[] { typeof(Shader) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        /// <summary>
        /// Tests that from string static method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FromString_StaticMethod_Exists()
        {
            var method = typeof(Shader).GetMethod("FromString", new[] { typeof(string), typeof(string), typeof(string) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        /// <summary>
        /// Tests that set uniform array multiple overloads exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetUniformArray_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Shader).GetMethod("SetUniformArray", new[] { typeof(string), typeof(float[]) }));
        }
    }
}
