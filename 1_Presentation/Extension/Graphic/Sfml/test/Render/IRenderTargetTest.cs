// license header
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The render target test class
    /// </summary>
    public class IRenderTargetTest
    {
        /// <summary>
        /// Tests that i render target is interface
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_IsInterface()
        {
            Assert.True(typeof(IRenderTarget).IsInterface);
        }

        /// <summary>
        /// Tests that i render target defines size property
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesSizeProperty()
        {
            var prop = typeof(IRenderTarget).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
        }

        /// <summary>
        /// Tests that i render target defines default view property
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesDefaultViewProperty()
        {
            Assert.NotNull(typeof(IRenderTarget).GetProperty("DefaultView"));
        }

        /// <summary>
        /// Tests that i render target defines get view method
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesGetViewMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("GetView"));
        }

        /// <summary>
        /// Tests that i render target defines set view method
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesSetViewMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("SetView"));
        }

        /// <summary>
        /// Tests that i render target defines get viewport method
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesGetViewportMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("GetViewport"));
        }

        /// <summary>
        /// Tests that i render target defines map pixel to coords method
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesMapPixelToCoordsMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that i render target defines map coords to pixel method
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesMapCoordsToPixelMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that i render target defines clear method
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesClearMethod()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Clear", System.Type.EmptyTypes));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Clear", new[] { typeof(Color) }));
        }

        /// <summary>
        /// Tests that i render target defines draw methods
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesDrawMethods()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(IDrawable) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(IDrawable), typeof(RenderStates) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType) }));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        /// <summary>
        /// Tests that i render target defines gl methods
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IRenderTarget_DefinesGlMethods()
        {
            Assert.NotNull(typeof(IRenderTarget).GetMethod("PushGlStates"));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("PopGlStates"));
            Assert.NotNull(typeof(IRenderTarget).GetMethod("ResetGlStates"));
        }
    }
}
