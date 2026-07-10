using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImDrawDataRemainingCoverageTests
    {
        [Fact]
        public void DefaultValues_ShouldBeZero()
        {
            ImDrawData drawData = new ImDrawData();

            Assert.Equal((byte)0, drawData.Valid);
            Assert.Equal(0, drawData.CmdListsCount);
            Assert.Equal(0, drawData.TotalIdxCount);
            Assert.Equal(0, drawData.TotalVtxCount);
            Assert.Equal(IntPtr.Zero, drawData.CmdListsPtr);
            Assert.Equal(default(Vector2F), drawData.DisplayPos);
            Assert.Equal(default(Vector2F), drawData.DisplaySize);
            Assert.Equal(default(Vector2F), drawData.FramebufferScale);
            Assert.Equal(IntPtr.Zero, drawData.OwnerViewportPtr);
        }

        [Fact]
        public void CmdListsRange_WithNonZeroPtr_ShouldReturnAccessor()
        {
            int size = Marshal.SizeOf<ImDrawListPtr>();
            IntPtr ptr = Marshal.AllocHGlobal(size * 2);
            try
            {
                ImDrawData drawData = new ImDrawData { CmdListsPtr = ptr, CmdListsCount = 2 };
                RangePtrAccessor<ImDrawListPtr> range = drawData.CmdListsRange;
                Assert.Equal(2, range.Count);
                Assert.NotEqual(IntPtr.Zero, range.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        [Fact]
        public void Clear_ShouldInvokeNative()
        {
            ImDrawData drawData = new ImDrawData { Valid = 1 };
            drawData.Clear();
        }

        [Fact]
        public void SetAndGetProperties_ShouldRoundtrip()
        {
            ImDrawData drawData = new ImDrawData();

            drawData.Valid = 1;
            drawData.CmdListsCount = 3;
            drawData.TotalIdxCount = 100;
            drawData.TotalVtxCount = 500;
            drawData.CmdListsPtr = new IntPtr(0x1234);
            drawData.DisplayPos = new Vector2F(10f, 20f);
            drawData.DisplaySize = new Vector2F(800f, 600f);
            drawData.FramebufferScale = new Vector2F(1.5f, 1.5f);
            drawData.OwnerViewportPtr = new IntPtr(0x5678);

            Assert.Equal((byte)1, drawData.Valid);
            Assert.Equal(3, drawData.CmdListsCount);
            Assert.Equal(100, drawData.TotalIdxCount);
            Assert.Equal(500, drawData.TotalVtxCount);
            Assert.Equal(new IntPtr(0x1234), drawData.CmdListsPtr);
            Assert.Equal(new Vector2F(10f, 20f), drawData.DisplayPos);
            Assert.Equal(new Vector2F(800f, 600f), drawData.DisplaySize);
            Assert.Equal(new Vector2F(1.5f, 1.5f), drawData.FramebufferScale);
            Assert.Equal(new IntPtr(0x5678), drawData.OwnerViewportPtr);
        }

        [Fact]
        public void DeIndexAllBuffers_ShouldInvokeNative()
        {
            ImDrawData drawData = new ImDrawData();
            drawData.DeIndexAllBuffers();
        }

        [Fact]
        public void ScaleClipRects_ShouldInvokeNative()
        {
            ImDrawData drawData = new ImDrawData();
            Vector2F fbScale = new Vector2F(2.0f, 2.0f);
            drawData.ScaleClipRects(fbScale);
        }
    }
}
