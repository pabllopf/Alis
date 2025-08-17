#if OSX
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Sample.Platform.OSX.Internal
{
    /// <summary>
    /// Utilidades para interoperar con Objective-C
    /// </summary>
    internal static class ObjectiveCInterop
    {
        const string Objc = "/usr/lib/libobjc.A.dylib";
        [DllImport(Objc, EntryPoint = "objc_getClass", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objc_getClass(string name);
        [DllImport(Objc, EntryPoint = "sel_registerName", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr sel_registerName(string name);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objc_msgSend(IntPtr recv, IntPtr sel);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objc_msgSend_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern void objc_msgSend_void(IntPtr recv, IntPtr sel);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern void objc_msgSend_void_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern void objc_msgSend_void_Bool(IntPtr recv, IntPtr sel, bool arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern void objc_msgSend_void_Long(IntPtr recv, IntPtr sel, long value);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objc_msgSend_NSRect_UL_UL_Bool(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            ulong styleMask, ulong backing, bool defer);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objc_msgSend_NSRect_IntPtr(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            IntPtr arg1);
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr objc_msgSend_UL_IntPtr_IntPtr_Bool(
            IntPtr recv, IntPtr sel, ulong mask, IntPtr untilDate, IntPtr inMode, bool dequeue);
        [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
        public static extern IntPtr CFStringCreateWithCString(IntPtr alloc, string str, uint enc);
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        public static extern void NSApplicationLoad();
        public static IntPtr Class(string n) => objc_getClass(n);
        public static IntPtr Sel(string n) => sel_registerName(n);
        public static IntPtr NsString(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var mem = Marshal.AllocHGlobal(bytes.Length + 1);
            Marshal.Copy(bytes, 0, mem, bytes.Length);
            Marshal.WriteByte(mem, bytes.Length, 0);
            var str = objc_msgSend_IntPtr(Class("NSString"), Sel("stringWithUTF8String:"), mem);
            Marshal.FreeHGlobal(mem);
            return str;
        }
    }
}
#endif

