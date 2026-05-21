

using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw cmd test class
    /// </summary>
    public class ImDrawCmdTest
    {
        /// <summary>
        ///     Tests that clip rect should be initialized correctly
        /// </summary>
        [Fact]
        public void ClipRect_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ClipRect = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f)};

            Vector4F clipRect = drawCmd.ClipRect;

            Assert.Equal(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f), clipRect);
        }

        /// <summary>
        ///     Tests that texture id should be initialized correctly
        /// </summary>
        [Fact]
        public void TextureId_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};

            IntPtr textureId = drawCmd.TextureId;

            Assert.Equal(new IntPtr(123), textureId);
        }

        /// <summary>
        ///     Tests that vtx offset should be initialized correctly
        /// </summary>
        [Fact]
        public void VtxOffset_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {VtxOffset = 10};

            uint vtxOffset = drawCmd.VtxOffset;

            Assert.Equal(10u, vtxOffset);
        }

        /// <summary>
        ///     Tests that idx offset should be initialized correctly
        /// </summary>
        [Fact]
        public void IdxOffset_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {IdxOffset = 20};

            uint idxOffset = drawCmd.IdxOffset;

            Assert.Equal(20u, idxOffset);
        }

        /// <summary>
        ///     Tests that elem count should be initialized correctly
        /// </summary>
        [Fact]
        public void ElemCount_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ElemCount = 30};

            uint elemCount = drawCmd.ElemCount;

            Assert.Equal(30u, elemCount);
        }

        /// <summary>
        ///     Tests that user callback should be initialized correctly
        /// </summary>
        [Fact]
        public void UserCallback_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallback = new IntPtr(456)};

            IntPtr userCallback = drawCmd.UserCallback;

            Assert.Equal(new IntPtr(456), userCallback);
        }

        /// <summary>
        ///     Tests that user callback data should be initialized correctly
        /// </summary>
        [Fact]
        public void UserCallbackData_ShouldBeInitializedCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallbackData = new IntPtr(789)};

            IntPtr userCallbackData = drawCmd.UserCallbackData;

            Assert.Equal(new IntPtr(789), userCallbackData);
        }

        /// <summary>
        ///     Tests that get clip rect should return correct value
        /// </summary>
        [Fact]
        public void GetClipRect_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ClipRect = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f)};

            Vector4F clipRect = drawCmd.GetClipRect();

            Assert.Equal(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f), clipRect);
        }

        /// <summary>
        ///     Tests that get texture id should return correct value
        /// </summary>
        [Fact]
        public void GetTextureId_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};

            IntPtr textureId = drawCmd.GetTextureId();

            Assert.Equal(new IntPtr(123), textureId);
        }

        /// <summary>
        ///     Tests that get vtx offset should return correct value
        /// </summary>
        [Fact]
        public void GetVtxOffset_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {VtxOffset = 10};

            uint vtxOffset = drawCmd.GetVtxOffset();

            Assert.Equal(10u, vtxOffset);
        }

        /// <summary>
        ///     Tests that get idx offset should return correct value
        /// </summary>
        [Fact]
        public void GetIdxOffset_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {IdxOffset = 20};

            uint idxOffset = drawCmd.GetIdxOffset();

            Assert.Equal(20u, idxOffset);
        }

        /// <summary>
        ///     Tests that get elem count should return correct value
        /// </summary>
        [Fact]
        public void GetElemCount_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ElemCount = 30};

            uint elemCount = drawCmd.GetElemCount();

            Assert.Equal(30u, elemCount);
        }

        /// <summary>
        ///     Tests that get user callback should return correct value
        /// </summary>
        [Fact]
        public void GetUserCallback_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallback = new IntPtr(456)};

            IntPtr userCallback = drawCmd.GetUserCallback();

            Assert.Equal(new IntPtr(456), userCallback);
        }

        /// <summary>
        ///     Tests that get user callback data should return correct value
        /// </summary>
        [Fact]
        public void GetUserCallbackData_ShouldReturnCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallbackData = new IntPtr(789)};

            IntPtr userCallbackData = drawCmd.GetUserCallbackData();

            Assert.Equal(new IntPtr(789), userCallbackData);
        }

        /// <summary>
        ///     Tests that set user callback data should set correct value
        /// </summary>
        [Fact]
        public void SetUserCallbackData_ShouldSetCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr value = new IntPtr(789);

            drawCmd.SetUserCallbackData(value);

            Assert.Equal(value, drawCmd.UserCallbackData);
        }

        /// <summary>
        ///     Tests that get clip rect returns clip rect
        /// </summary>
        [Fact]
        public void GetClipRect_ReturnsClipRect()
        {
            ImDrawCmd cmd = new ImDrawCmd {ClipRect = new Vector4F(1, 2, 3, 4)};
            Assert.Equal(new Vector4F(1, 2, 3, 4), cmd.GetClipRect());
        }

        /// <summary>
        ///     Tests that get texture id returns texture id
        /// </summary>
        [Fact]
        public void GetTextureId_ReturnsTextureId()
        {
            ImDrawCmd cmd = new ImDrawCmd {TextureId = new IntPtr(123)};
            Assert.Equal(new IntPtr(123), cmd.GetTextureId());
        }

        /// <summary>
        ///     Tests that get vtx offset returns vtx offset
        /// </summary>
        [Fact]
        public void GetVtxOffset_ReturnsVtxOffset()
        {
            ImDrawCmd cmd = new ImDrawCmd {VtxOffset = 123};
            Assert.Equal((uint) 123, cmd.GetVtxOffset());
        }

        /// <summary>
        ///     Tests that get idx offset returns idx offset
        /// </summary>
        [Fact]
        public void GetIdxOffset_ReturnsIdxOffset()
        {
            ImDrawCmd cmd = new ImDrawCmd {IdxOffset = 123};
            Assert.Equal((uint) 123, cmd.GetIdxOffset());
        }

        /// <summary>
        ///     Tests that get elem count returns elem count
        /// </summary>
        [Fact]
        public void GetElemCount_ReturnsElemCount()
        {
            ImDrawCmd cmd = new ImDrawCmd {ElemCount = 123};
            Assert.Equal((uint) 123, cmd.GetElemCount());
        }

        /// <summary>
        ///     Tests that get user callback returns user callback
        /// </summary>
        [Fact]
        public void GetUserCallback_ReturnsUserCallback()
        {
            ImDrawCmd cmd = new ImDrawCmd {UserCallback = new IntPtr(123)};
            Assert.Equal(new IntPtr(123), cmd.GetUserCallback());
        }

        /// <summary>
        ///     Tests that get user callback data returns user callback data
        /// </summary>
        [Fact]
        public void GetUserCallbackData_ReturnsUserCallbackData()
        {
            ImDrawCmd cmd = new ImDrawCmd {UserCallbackData = new IntPtr(123)};
            Assert.Equal(new IntPtr(123), cmd.GetUserCallbackData());
        }

        /// <summary>
        ///     Tests that set user callback data sets user callback data
        /// </summary>
        [Fact]
        public void SetUserCallbackData_SetsUserCallbackData()
        {
            ImDrawCmd cmd = new ImDrawCmd();
            IntPtr ptr = new IntPtr(123);
            cmd.SetUserCallbackData(ptr);
            Assert.Equal(ptr, cmd.GetUserCallbackData());
        }

        /// <summary>
        ///     Tests that get tex id returns tex id
        /// </summary>
        [Fact]
        public void GetTexId_ReturnsTexId()
        {
            ImDrawCmd cmd = new ImDrawCmd();
        }
    }
}