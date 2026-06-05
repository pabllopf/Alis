using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalAndroidWmInfoTest
    {
        [Fact]
        public void InternalAndroidWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalAndroidWmInfo info = new InternalAndroidWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(IntPtr.Zero, info.Surface);
        }

        [Fact]
        public void InternalAndroidWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalAndroidWmInfo info = new InternalAndroidWmInfo
            {
                Window = new IntPtr(123),
                Surface = new IntPtr(456)
            };

            Assert.Equal(new IntPtr(123), info.Window);
            Assert.Equal(new IntPtr(456), info.Surface);
        }

        [Fact]
        public void InternalAndroidWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalAndroidWmInfo original = new InternalAndroidWmInfo { Window = new IntPtr(100) };
            InternalAndroidWmInfo copy = original;

            copy.Window = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.Window);
            Assert.Equal(new IntPtr(200), copy.Window);
        }
    }
}
