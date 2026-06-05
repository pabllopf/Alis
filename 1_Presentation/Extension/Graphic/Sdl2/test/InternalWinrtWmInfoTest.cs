using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalWinrtWmInfoTest
    {
        [Fact]
        public void InternalWinrtWmInfo_DefaultInitialization_PropertyHasDefaultValue()
        {
            InternalWinrtWmInfo info = new InternalWinrtWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
        }

        [Fact]
        public void InternalWinrtWmInfo_SetProperty_StoresValueCorrectly()
        {
            InternalWinrtWmInfo info = new InternalWinrtWmInfo
            {
                Window = new IntPtr(777)
            };

            Assert.Equal(new IntPtr(777), info.Window);
        }

        [Fact]
        public void InternalWinrtWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWinrtWmInfo original = new InternalWinrtWmInfo { Window = new IntPtr(111) };
            InternalWinrtWmInfo copy = original;

            copy.Window = new IntPtr(222);

            Assert.Equal(new IntPtr(111), original.Window);
            Assert.Equal(new IntPtr(222), copy.Window);
        }
    }
}
