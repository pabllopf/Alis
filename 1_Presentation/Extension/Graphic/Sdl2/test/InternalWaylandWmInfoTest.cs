using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalWaylandWmInfoTest
    {
        [Fact]
        public void InternalWaylandWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalWaylandWmInfo info = new InternalWaylandWmInfo();

            Assert.Equal(IntPtr.Zero, info.Display);
            Assert.Equal(IntPtr.Zero, info.Surface);
            Assert.Equal(IntPtr.Zero, info.ShellSurface);
            Assert.Equal(IntPtr.Zero, info.EglWindow);
            Assert.Equal(IntPtr.Zero, info.XdgSurface);
            Assert.Equal(IntPtr.Zero, info.XdgToplevel);
        }

        [Fact]
        public void InternalWaylandWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalWaylandWmInfo info = new InternalWaylandWmInfo
            {
                Display = new IntPtr(1),
                Surface = new IntPtr(2),
                ShellSurface = new IntPtr(3),
                EglWindow = new IntPtr(4),
                XdgSurface = new IntPtr(5),
                XdgToplevel = new IntPtr(6)
            };

            Assert.Equal(new IntPtr(1), info.Display);
            Assert.Equal(new IntPtr(2), info.Surface);
            Assert.Equal(new IntPtr(3), info.ShellSurface);
            Assert.Equal(new IntPtr(4), info.EglWindow);
            Assert.Equal(new IntPtr(5), info.XdgSurface);
            Assert.Equal(new IntPtr(6), info.XdgToplevel);
        }

        [Fact]
        public void InternalWaylandWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWaylandWmInfo original = new InternalWaylandWmInfo { Display = new IntPtr(100) };
            InternalWaylandWmInfo copy = original;

            copy.Display = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.Display);
            Assert.Equal(new IntPtr(200), copy.Display);
        }
    }
}
