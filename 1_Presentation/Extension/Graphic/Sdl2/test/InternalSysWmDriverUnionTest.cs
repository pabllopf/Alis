using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalSysWmDriverUnionTest
    {
        [Fact]
        public void InternalSysWmDriverUnion_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalSysWmDriverUnion u = new InternalSysWmDriverUnion();

            Assert.Equal(0, u.win.Window);
            Assert.Equal(0, u.winrt.Window);
            Assert.Equal(0, u.x11.Display);
            Assert.Equal(0, u.dfb.Window);
            Assert.Equal(0, u.cocoa.Window);
            Assert.Equal(0, u.uikit.Window);
        }

        [Fact]
        public void InternalSysWmDriverUnion_IsValueType_CopyIsIndependent()
        {
            InternalSysWmDriverUnion original = new InternalSysWmDriverUnion();
            InternalSysWmDriverUnion copy = original;

            Assert.Equal(original.win.Window, copy.win.Window);
            Assert.Equal(original.winrt.Window, copy.winrt.Window);
        }
    }
}
