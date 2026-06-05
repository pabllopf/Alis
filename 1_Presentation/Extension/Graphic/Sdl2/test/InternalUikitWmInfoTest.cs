using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalUikitWmInfoTest
    {
        [Fact]
        public void InternalUikitWmInfo_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalUikitWmInfo info = new InternalUikitWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(0u, info.framebuffer);
            Assert.Equal(0u, info.colorBuffer);
            Assert.Equal(0u, info.resolveFramebuffer);
        }

        [Fact]
        public void InternalUikitWmInfo_SetFields_StoresValuesCorrectly()
        {
            InternalUikitWmInfo info = new InternalUikitWmInfo
            {
                Window = new IntPtr(999),
                framebuffer = 1u,
                colorBuffer = 2u,
                resolveFramebuffer = 3u
            };

            Assert.Equal(new IntPtr(999), info.Window);
            Assert.Equal(1u, info.framebuffer);
            Assert.Equal(2u, info.colorBuffer);
            Assert.Equal(3u, info.resolveFramebuffer);
        }

        [Fact]
        public void InternalUikitWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalUikitWmInfo original = new InternalUikitWmInfo { framebuffer = 10u };
            InternalUikitWmInfo copy = original;

            copy.framebuffer = 20u;

            Assert.Equal(10u, original.framebuffer);
            Assert.Equal(20u, copy.framebuffer);
        }
    }
}
