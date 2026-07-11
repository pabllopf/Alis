// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class TextureTest
    {
        [Fact]
        public void Texture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Texture)));
        }

        [Fact]
        public void NativeHandle_Smooth_Srgb_Repeated_Properties_Exist()
        {
            Assert.NotNull(typeof(Texture).GetProperty("NativeHandle"));
            Assert.NotNull(typeof(Texture).GetProperty("Smooth"));
            Assert.NotNull(typeof(Texture).GetProperty("Srgb"));
            Assert.NotNull(typeof(Texture).GetProperty("Repeated"));
        }

        [Fact]
        public void Size_MaximumSize_Properties_Exist()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Size"));
            Assert.NotNull(typeof(Texture).GetProperty("MaximumSize"));
        }

        [Fact]
        public void CopyToImage_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("CopyToImage"));
        }

        [Fact]
        public void Update_MultipleOverloads_Exist()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(byte[]) }));
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Image) }));
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Window) }));
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(RenderWindow) }));
        }

        [Fact]
        public void GenerateMipmap_Swap_Bind_Methods_Exist()
        {
            Assert.NotNull(typeof(Texture).GetMethod("GenerateMipmap"));
            Assert.NotNull(typeof(Texture).GetMethod("Swap"));
            Assert.NotNull(typeof(Texture).GetMethod("Bind"));
        }

        [Fact]
        public void Bind_IsStatic()
        {
            var method = typeof(Texture).GetMethod("Bind", new[] { typeof(Texture) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }
    }
}
