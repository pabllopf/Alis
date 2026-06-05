using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalWindowsWmInfoTest
    {
        [Fact]
        public void InternalWindowsWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalWindowsWmInfo info = new InternalWindowsWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(IntPtr.Zero, info.Hdc);
            Assert.Equal(IntPtr.Zero, info.HInstance);
        }

        [Fact]
        public void InternalWindowsWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalWindowsWmInfo info = new InternalWindowsWmInfo
            {
                Window = new IntPtr(10),
                Hdc = new IntPtr(20),
                HInstance = new IntPtr(30)
            };

            Assert.Equal(new IntPtr(10), info.Window);
            Assert.Equal(new IntPtr(20), info.Hdc);
            Assert.Equal(new IntPtr(30), info.HInstance);
        }

        [Fact]
        public void InternalWindowsWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWindowsWmInfo original = new InternalWindowsWmInfo { Window = new IntPtr(55) };
            InternalWindowsWmInfo copy = original;

            copy.Window = new IntPtr(66);

            Assert.Equal(new IntPtr(55), original.Window);
            Assert.Equal(new IntPtr(66), copy.Window);
        }
    }
}
