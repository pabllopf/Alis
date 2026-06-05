using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalX11WmInfoTest
    {
        [Fact]
        public void InternalX11WmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalX11WmInfo info = new InternalX11WmInfo();

            Assert.Equal(IntPtr.Zero, info.Display);
            Assert.Equal(IntPtr.Zero, info.Window);
        }

        [Fact]
        public void InternalX11WmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalX11WmInfo info = new InternalX11WmInfo
            {
                Display = new IntPtr(1000),
                Window = new IntPtr(2000)
            };

            Assert.Equal(new IntPtr(1000), info.Display);
            Assert.Equal(new IntPtr(2000), info.Window);
        }

        [Fact]
        public void InternalX11WmInfo_IsValueType_CopyIsIndependent()
        {
            InternalX11WmInfo original = new InternalX11WmInfo { Display = new IntPtr(3000) };
            InternalX11WmInfo copy = original;

            copy.Display = new IntPtr(4000);

            Assert.Equal(new IntPtr(3000), original.Display);
            Assert.Equal(new IntPtr(4000), copy.Display);
        }
    }
}
