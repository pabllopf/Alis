using System;
using System.Reflection;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    public class FontSafeTests
    {
        [Fact]
        public void Constructor_SetsNameFile()
        {
            var font = new Font("test.bmp", 2, 16);
            Assert.Equal("test.bmp", font.NameFile);
        }

        [Fact]
        public void Depth_GetSet_Works()
        {
            var font = new Font("f", 2, 16);
            Assert.Equal(2, font.Depth);
            font.Depth = 5;
            Assert.Equal(5, font.Depth);
        }

        [Fact]
        public void NameFile_GetSet_Works()
        {
            var font = new Font("test.bmp", 1, 1);
            font.NameFile = "new.bmp";
            Assert.Equal("new.bmp", font.NameFile);
        }

        [Fact]
        public void Font_IsPublic()
        {
            Assert.True(typeof(Font).IsPublic);
        }

        [Fact]
        public void Depth_HasPublicGetterAndSetter()
        {
            PropertyInfo prop = typeof(Font).GetProperty("Depth");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void NameFile_HasPublicGetterAndSetter()
        {
            PropertyInfo prop = typeof(Font).GetProperty("NameFile");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void RenderText_ThrowsWhenOpenGLNotAvailable()
        {
            var font = new Font("test.bmp", 1, 1);
            Assert.ThrowsAny<Exception>(() =>
                font.RenderText("hello", 0, 0, Alis.Core.Aspect.Math.Definition.Color.White, Alis.Core.Aspect.Math.Definition.Color.Transparent));
        }

        [Fact]
        public void RenderText_NullText_Throws()
        {
            var font = new Font("test.bmp", 1, 1);
            Assert.ThrowsAny<Exception>(() =>
                font.RenderText(null, 0, 0, Alis.Core.Aspect.Math.Definition.Color.White, Alis.Core.Aspect.Math.Definition.Color.Transparent));
        }
    }
}
