#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    ///     The objective c interop test class
    /// </summary>
    public class ObjectiveCInteropTest
    {
        /// <summary>
        ///     Class_ReturnsNonZero_ForKnownClass
        /// </summary>
        [Fact]
        public void Class_ReturnsNonZero_ForKnownClass()
        {
            IntPtr result = ObjectiveCInterop.Class("NSObject");
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Class_ReturnsZero_ForUnknownClass
        /// </summary>
        [Fact]
        public void Class_ReturnsZero_ForUnknownClass()
        {
            IntPtr result = ObjectiveCInterop.Class("NonExistentClassXYZ");
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Sel_ReturnsNonZero_ForKnownSelector
        /// </summary>
        [Fact]
        public void Sel_ReturnsNonZero_ForKnownSelector()
        {
            IntPtr result = ObjectiveCInterop.Sel("alloc");
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Sel_ReturnsNonZero_ForAnyString
        /// </summary>
        [Fact]
        public void Sel_ReturnsNonZero_ForAnyString()
        {
            IntPtr result = ObjectiveCInterop.Sel("someRandomSelector");
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     selMouseLocationOutside_IsNonZero
        /// </summary>
        [Fact]
        public void selMouseLocationOutside_IsNonZero()
        {
            FieldInfo field = typeof(ObjectiveCInterop).GetField("selMouseLocationOutside", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            IntPtr val = (IntPtr)field.GetValue(null);
            Assert.NotEqual(IntPtr.Zero, val);
        }

        /// <summary>
        ///     selConvertPointFromView_IsNonZero
        /// </summary>
        [Fact]
        public void selConvertPointFromView_IsNonZero()
        {
            FieldInfo field = typeof(ObjectiveCInterop).GetField("selConvertPointFromView", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(field);
            IntPtr val = (IntPtr)field.GetValue(null);
            Assert.NotEqual(IntPtr.Zero, val);
        }

        /// <summary>
        ///     Objc_Constant_IsCorrect
        /// </summary>
        [Fact]
        public void Objc_Constant_IsCorrect()
        {
            Assert.Equal("/usr/lib/libobjc.A.dylib", ObjectiveCInterop.Objc);
        }

        /// <summary>
        ///     NSApplicationLoad_DoesNotThrow
        /// </summary>
        [Fact]
        public void NSApplicationLoad_DoesNotThrow()
        {
            ObjectiveCInterop.NSApplicationLoad();
        }

        /// <summary>
        ///     objc_getClass_NSObject_ReturnsNonZero
        /// </summary>
        [Fact]
        public void objc_getClass_NSObject_ReturnsNonZero()
        {
            IntPtr cls = ObjectiveCInterop.objc_getClass("NSObject");
            Assert.NotEqual(IntPtr.Zero, cls);
        }

        /// <summary>
        ///     sel_registerName_alloc_ReturnsNonZero
        /// </summary>
        [Fact]
        public void sel_registerName_alloc_ReturnsNonZero()
        {
            IntPtr sel = ObjectiveCInterop.sel_registerName("alloc");
            Assert.NotEqual(IntPtr.Zero, sel);
        }

        /// <summary>
        ///     StaticMethods_AreExported
        /// </summary>
        [Fact]
        public void StaticMethods_AreExported()
        {
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("objc_getClass", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("sel_registerName", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("CFStringCreateWithCString", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("Dlopen", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("Dlsym", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("CGEventCreate", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ObjectiveCInterop).GetMethod("CFRelease", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Dlopen_OpenGL_ReturnsNonZero
        /// </summary>
        [Fact]
        public void Dlopen_OpenGL_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.Dlopen(
                "/System/Library/Frameworks/OpenGL.framework/OpenGL", 0);
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     NSViewGetFrame_ReturnsValidFrame_ForNewView
        /// </summary>
        [Fact]
        public void NSViewGetFrame_ReturnsValidFrame_ForNewView()
        {
            IntPtr viewClass = ObjectiveCInterop.Class("NSView");
            IntPtr view = ObjectiveCInterop.objc_msgSend(viewClass, ObjectiveCInterop.Sel("alloc"));
            view = ObjectiveCInterop.objc_msgSend(view, ObjectiveCInterop.Sel("init"));
            NsRect frame = ObjectiveCInterop.NSViewGetFrame(view);
            Assert.True(frame.width >= 0.0);
            Assert.True(frame.height >= 0.0);
        }

        /// <summary>
        ///     GetWindowFrame_ReturnsDefault_ForNilWindow
        /// </summary>
        [Fact]
        public void GetWindowFrame_ReturnsDefault_ForNilWindow()
        {
            NsRect frame = ObjectiveCInterop.GetWindowFrame(IntPtr.Zero);
            Assert.Equal(0.0, frame.x, 5);
            Assert.Equal(0.0, frame.y, 5);
            Assert.Equal(0.0, frame.width, 5);
            Assert.Equal(0.0, frame.height, 5);
        }

        /// <summary>
        ///     NsString_ReturnsNonZero_ForValidString
        /// </summary>
        [Fact]
        public void NsString_ReturnsNonZero_ForValidString()
        {
            IntPtr result = ObjectiveCInterop.NsString("Hello");
            Assert.NotEqual(IntPtr.Zero, result);
        }

        /// <summary>
        ///     NsString_ReturnsNonZero_ForEmptyString
        /// </summary>
        [Fact]
        public void NsString_ReturnsNonZero_ForEmptyString()
        {
            IntPtr result = ObjectiveCInterop.NsString("");
            Assert.NotEqual(IntPtr.Zero, result);
        }
    }
}
#endif
