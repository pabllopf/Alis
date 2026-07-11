// license header
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class IRenderTargetTest
    {
        [Fact]
        public void IRenderTarget_IsInterface()
        {
            Assert.True(typeof(IRenderTarget).IsInterface);
        }

        [Fact]
        public void IRenderTarget_DefinesSizeProperty()
        {
            var prop = typeof(IRenderTarget).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
        }

        [Fact]
        public void IRenderTarget_DefinesDefaultViewProperty()
        {
            Assert.NotNull(typeof(IRenderTarget).GetProperty("DefaultView"));
        }

        [Fact]
        public void IRenderTarget_DefinesGetViewMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("GetView"));
        }

        [Fact]
        public void IRenderTarget_DefinesSetViewMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("SetView"));
        }

        [Fact]
        public void IRenderTarget_DefinesGetViewportMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("GetViewport"));
        }

        [Fact]
        public void IRenderTarget_DefinesMapPixelToCoordsMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(View) }));
        }

        [Fact]
        public void IRenderTarget_DefinesMapCoordsToPixelMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(View) }));
        }

        [Fact]
        public void IRenderTarget_DefinesClearMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Clear", System.Type.EmptyTypes));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Clear", new[] { typeof(Color) }));
        }

        [Fact]
        public void IRenderTarget_DefinesDrawMethods()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(IDrawable) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(IDrawable), typeof(RenderStates) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        [Fact]
        public void IRenderTarget_DefinesGlMethods()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("PushGlStates"));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("PopGlStates"));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("ResetGlStates"));
        }
    }
}
