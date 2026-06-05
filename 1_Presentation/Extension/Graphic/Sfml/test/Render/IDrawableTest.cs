using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class IDrawableTest
    {
        [Fact]
        public void Drawable_ImplementsIDrawable()
        {
            TestDrawable drawable = new TestDrawable();
            Assert.IsAssignableFrom<IDrawable>(drawable);
        }

        [Fact]
        public void Draw_CallsImplementation()
        {
            TestDrawable drawable = new TestDrawable();
            TestRenderTarget target = new TestRenderTarget();
            drawable.Draw(target, new RenderStates());
            Assert.True(drawable.WasDrawn);
        }

        private class TestDrawable : IDrawable
        {
            public bool WasDrawn { get; private set; }

            public void Draw(IRenderTarget target, RenderStates states)
            {
                WasDrawn = true;
            }
        }

        private class TestRenderTarget : IRenderTarget
        {
            public Vector2F MapCoordsToPixel(Vector2F point) => default;
            public Vector2F MapCoordsToPixel(Vector2F point, View view) => default;
            public Vector2F MapPixelToCoords(Vector2F point) => default;
            public Vector2F MapPixelToCoords(Vector2F point, View view) => default;
            public IntRect GetViewport(View view) => default;
            public View GetView() => null;
            public void Clear() { }
            public void Clear(Color color) { }
            public void Draw(IDrawable drawable) { }
            public void Draw(IDrawable drawable, RenderStates states) { }
            public void Draw(Vertex[] vertices, PrimitiveType type) { }
            public void Draw(Vertex[] vertices, PrimitiveType type, RenderStates states) { }
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type) { }
            public void Draw(Vertex[] vertices, uint start, uint count, PrimitiveType type, RenderStates states) { }
            public void PopGlStates() { }
            public void PushGlStates() { }
            public void ResetGlStates() { }
            public void SetView(View view) { }
            public Vector2F Size => default;
            public View DefaultView => null;
        }
    }
}
