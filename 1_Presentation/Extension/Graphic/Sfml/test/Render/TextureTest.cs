// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The texture test class
    /// </summary>
    public class TextureTest
    {
        /// <summary>
        /// Tests that texture is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Texture)));
        }

        /// <summary>
        /// Tests that native handle smooth srgb repeated properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_Smooth_Srgb_Repeated_Properties_Exist()
        {
            Assert.NotNull(typeof(Texture).GetProperty("NativeHandle"));
            Assert.NotNull(typeof(Texture).GetProperty("Smooth"));
            Assert.NotNull(typeof(Texture).GetProperty("Srgb"));
            Assert.NotNull(typeof(Texture).GetProperty("Repeated"));
        }

        /// <summary>
        /// Tests that size maximum size properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_MaximumSize_Properties_Exist()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Size"));
            Assert.NotNull(typeof(Texture).GetProperty("MaximumSize"));
        }

        /// <summary>
        /// Tests that copy to image method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyToImage_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("CopyToImage"));
        }

        /// <summary>
        /// Tests that update multiple overloads exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(byte[]) }));
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Image) }));
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Window) }));
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(RenderWindow) }));
        }

        /// <summary>
        /// Tests that generate mipmap swap bind methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GenerateMipmap_Swap_Bind_Methods_Exist()
        {
            Assert.NotNull(typeof(Texture).GetMethod("GenerateMipmap"));
            Assert.NotNull(typeof(Texture).GetMethod("Swap"));
            Assert.NotNull(typeof(Texture).GetMethod("Bind"));
        }

        /// <summary>
        /// Tests that bind is static
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_IsStatic()
        {
            var method = typeof(Texture).GetMethod("Bind", new[] { typeof(Texture) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }
    }
}
