using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal sys wm driver union test class
    /// </summary>
    public class InternalSysWmDriverUnionTest
    {
        /// <summary>
        /// Tests that internal sys wm driver union default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalSysWmDriverUnion_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalSysWmDriverUnion u = new InternalSysWmDriverUnion();

            Assert.Equal((IntPtr)0, u.win.Window);
            Assert.Equal((IntPtr)0, u.winrt.Window);
            Assert.Equal((IntPtr)0, u.x11.Display);
            Assert.Equal((IntPtr)0, u.dfb.Window);
            Assert.Equal((IntPtr)0, u.cocoa.Window);
            Assert.Equal((IntPtr)0, u.uikit.Window);
        }

        /// <summary>
        /// Tests that internal sys wm driver union is value type copy is independent
        /// </summary>
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
