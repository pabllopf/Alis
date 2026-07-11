#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public class ObjectiveCInteropFullTests
    {
        [Fact]
        public void Objc_Is_Correct() => Assert.Equal("/usr/lib/libobjc.A.dylib", ObjectiveCInterop.Objc);

        [Fact]
        public void selMouseLocationOutside_Is_NonZero()
        {
            var f = typeof(ObjectiveCInterop).GetField("selMouseLocationOutside", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotEqual(IntPtr.Zero, (IntPtr)f.GetValue(null));
        }

        [Fact]
        public void selConvertPointFromView_Is_NonZero()
        {
            var f = typeof(ObjectiveCInterop).GetField("selConvertPointFromView", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotEqual(IntPtr.Zero, (IntPtr)f.GetValue(null));
        }

        [Fact]
        public void Class_NSObject_NonZero() => Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.Class("NSObject"));

        [Fact]
        public void Sel_alloc_NonZero() => Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.Sel("alloc"));

        [Fact]
        public void CFStringCreateWithCString_ReturnsNonNull()
        {
            IntPtr s = ObjectiveCInterop.CFStringCreateWithCString(IntPtr.Zero, "test", 0x08000100);
            Assert.NotEqual(IntPtr.Zero, s);
        }

        [Fact]
        public void NSApplicationLoad_DoesNotThrow() => ObjectiveCInterop.NSApplicationLoad();

        [Fact]
        public void NsString_ReturnsNonNull() => Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.NsString("hello"));

        [Fact]
        public void NsString_Empty_ReturnsNonNull() => Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.NsString(""));

        [Fact]
        public void objc_getClass_NonZero() => Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.objc_getClass("NSObject"));

        [Fact]
        public void objc_getClass_Unknown_Zero() => Assert.Equal(IntPtr.Zero, ObjectiveCInterop.objc_getClass("NonExistent"));

        [Fact]
        public void sel_registerName_NonZero() => Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.sel_registerName("alloc"));

        [Fact]
        public void objc_msgSend_NSObject_alloc_NonZero()
        {
            IntPtr obj = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSObject"), ObjectiveCInterop.Sel("alloc"));
            Assert.NotEqual(IntPtr.Zero, obj);
        }

        [Fact]
        public void objc_msgSend_void_DoesNotThrow()
        {
            IntPtr obj = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSObject"), ObjectiveCInterop.Sel("alloc"));
            ObjectiveCInterop.objc_msgSend_void(obj, ObjectiveCInterop.Sel("release"));
        }

        [Fact]
        public void Dlopen_OpenGL_NonZero()
        {
            IntPtr h = ObjectiveCInterop.Dlopen("/System/Library/Frameworks/OpenGL.framework/OpenGL", 0);
            Assert.NotEqual(IntPtr.Zero, h);
        }

        [Fact]
        public void Dlsym_Returns_NonZero()
        {
            IntPtr h = ObjectiveCInterop.Dlopen("/System/Library/Frameworks/OpenGL.framework/OpenGL", 0);
            IntPtr sym = ObjectiveCInterop.Dlsym(h, "glGetString");
            Assert.NotEqual(IntPtr.Zero, sym);
        }

        [Fact]
        public void CGEventCreate_Returns_NonZero()
        {
            IntPtr evt = ObjectiveCInterop.CGEventCreate(IntPtr.Zero);
            Assert.NotEqual(IntPtr.Zero, evt);
            ObjectiveCInterop.CFRelease(evt);
        }

        [Fact]
        public void CGEventGetLocation_Returns_Point()
        {
            IntPtr evt = ObjectiveCInterop.CGEventCreate(IntPtr.Zero);
            CGPoint pt = ObjectiveCInterop.CGEventGetLocation(evt);
            ObjectiveCInterop.CFRelease(evt);
            Assert.True(pt.X >= 0 || pt.Y >= 0);
        }
    }
}
#endif
