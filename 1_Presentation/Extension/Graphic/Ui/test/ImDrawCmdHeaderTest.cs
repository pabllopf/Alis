

using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw cmd header test class
    /// </summary>
    public class ImDrawCmdHeaderTest
    {
        /// <summary>
        ///     Tests that clip rect should be initialized correctly
        /// </summary>
        [Fact]
        public void ClipRect_ShouldBeInitializedCorrectly()
        {
            ImDrawCmdHeader drawCmdHeader = new ImDrawCmdHeader {ClipRect = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f)};

            Vector4F clipRect = drawCmdHeader.ClipRect;

            Assert.Equal(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f), clipRect);
        }

        /// <summary>
        ///     Tests that texture id should be initialized correctly
        /// </summary>
        [Fact]
        public void TextureId_ShouldBeInitializedCorrectly()
        {
            ImDrawCmdHeader drawCmdHeader = new ImDrawCmdHeader {TextureId = new IntPtr(123)};

            IntPtr textureId = drawCmdHeader.TextureId;

            Assert.Equal(new IntPtr(123), textureId);
        }

        /// <summary>
        ///     Tests that vtx offset should be initialized correctly
        /// </summary>
        [Fact]
        public void VtxOffset_ShouldBeInitializedCorrectly()
        {
            ImDrawCmdHeader drawCmdHeader = new ImDrawCmdHeader {VtxOffset = 10};

            uint vtxOffset = drawCmdHeader.VtxOffset;

            Assert.Equal(10u, vtxOffset);
        }
    }
}