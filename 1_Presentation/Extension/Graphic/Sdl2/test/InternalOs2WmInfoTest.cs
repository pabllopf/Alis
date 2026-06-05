using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalOs2WmInfoTest
    {
        [Fact]
        public void InternalOs2WmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalOs2WmInfo info = new InternalOs2WmInfo();

            Assert.Equal(IntPtr.Zero, info.Hwnd);
            Assert.Equal(IntPtr.Zero, info.HwndFrame);
        }

        [Fact]
        public void InternalOs2WmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalOs2WmInfo info = new InternalOs2WmInfo
            {
                Hwnd = new IntPtr(111),
                HwndFrame = new IntPtr(222)
            };

            Assert.Equal(new IntPtr(111), info.Hwnd);
            Assert.Equal(new IntPtr(222), info.HwndFrame);
        }

        [Fact]
        public void InternalOs2WmInfo_IsValueType_CopyIsIndependent()
        {
            InternalOs2WmInfo original = new InternalOs2WmInfo { Hwnd = new IntPtr(77) };
            InternalOs2WmInfo copy = original;

            copy.Hwnd = new IntPtr(88);

            Assert.Equal(new IntPtr(77), original.Hwnd);
            Assert.Equal(new IntPtr(88), copy.Hwnd);
        }
    }
}
