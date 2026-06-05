using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalMirWmInfoTest
    {
        [Fact]
        public void InternalMirWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalMirWmInfo info = new InternalMirWmInfo();

            Assert.Equal(IntPtr.Zero, info.Connection);
            Assert.Equal(IntPtr.Zero, info.Surface);
        }

        [Fact]
        public void InternalMirWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalMirWmInfo info = new InternalMirWmInfo
            {
                Connection = new IntPtr(100),
                Surface = new IntPtr(200)
            };

            Assert.Equal(new IntPtr(100), info.Connection);
            Assert.Equal(new IntPtr(200), info.Surface);
        }

        [Fact]
        public void InternalMirWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalMirWmInfo original = new InternalMirWmInfo { Connection = new IntPtr(50) };
            InternalMirWmInfo copy = original;

            copy.Connection = new IntPtr(99);

            Assert.Equal(new IntPtr(50), original.Connection);
            Assert.Equal(new IntPtr(99), copy.Connection);
        }
    }
}
