// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectiveCInterop.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Utilidades para interoperar con Objective-C
    /// </summary>
    internal static class ObjectiveCInterop
    {
        /// <summary>
        ///     The objc
        /// </summary>
        public const string Objc = "/usr/lib/libobjc.A.dylib";

        internal static readonly IntPtr selMouseLocationOutside =
            Sel("mouseLocationOutsideOfEventStream");

        internal static readonly IntPtr selConvertPointFromView =
            Sel("convertPoint:fromView:");

        /// <summary>
        ///     Objcs the get using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_getClass", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_getClass(string name);

        /// <summary>
        ///     Sels the register name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "sel_registerName", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr sel_registerName(string name);

        [DllImport("libobjc.A.dylib", EntryPoint = "objc_msgSend")]
        [ExcludeFromCodeCoverage]
        public static extern NsRect objc_msgSend_NSRect(IntPtr receiver, IntPtr selector);

        [DllImport("libobjc.A.dylib", EntryPoint = "objc_msgSend_stret")]
        [ExcludeFromCodeCoverage]
        public static extern void objc_msgSend_stret(out NsRect ret, IntPtr receiver, IntPtr selector);


        public static NsRect NSViewGetFrame(IntPtr view) => objc_msgSend_NSRect(view, Sel("frame"));

        public static NsRect GetWindowFrame(IntPtr nsWindow)
        {
#if osxarm64 || osxarm
            // Apple Silicon: usar objc_msgSend directamente
            return objc_msgSend_NSRect(nsWindow, Sel("frame"));
#else
            // Intel: usar objc_msgSend_stret
            objc_msgSend_stret(out NsRect frame, nsWindow, Sel("frame"));
            return frame;
#endif
        }

        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern NsPoint objc_msgSend_NSPoint(IntPtr receiver, IntPtr selector);

        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern NsPoint objc_msgSend_NSPoint_NSPoint_IntPtr(
            IntPtr receiver,
            IntPtr selector,
            NsPoint point,
            IntPtr fromView);


        /// <summary>
        ///     Objcs the msg send using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_msgSend(IntPtr recv, IntPtr sel);

        /// <summary>
        ///     Objcs the msg send int ptr using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="arg1">The arg</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_msgSend_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);

        /// <summary>
        ///     Objcs the msg send void using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern void objc_msgSend_void(IntPtr recv, IntPtr sel);

        /// <summary>
        ///     Objcs the msg send void int ptr using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="arg1">The arg</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern void objc_msgSend_void_IntPtr(IntPtr recv, IntPtr sel, IntPtr arg1);

        /// <summary>
        ///     Objcs the msg send void bool using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="arg1">The arg</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern void objc_msgSend_void_Bool(IntPtr recv, IntPtr sel, bool arg1);

        /// <summary>
        ///     Objcs the msg send void long using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="value">The value</param>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern void objc_msgSend_void_Long(IntPtr recv, IntPtr sel, long value);

        /// <summary>
        ///     Objcs the msg send ns rect ul ul bool using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="styleMask">The style mask</param>
        /// <param name="backing">The backing</param>
        /// <param name="defer">The defer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_msgSend_NSRect_UL_UL_Bool(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            ulong styleMask, ulong backing, bool defer);

        /// <summary>
        ///     Objcs the msg send ns rect int ptr using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="arg1">The arg</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_msgSend_NSRect_IntPtr(
            IntPtr recv, IntPtr sel,
            double x, double y, double w, double h,
            IntPtr arg1);

        /// <summary>
        ///     Objcs the msg send ul int ptr int ptr bool using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <param name="mask">The mask</param>
        /// <param name="untilDate">The until date</param>
        /// <param name="inMode">The in mode</param>
        /// <param name="dequeue">The dequeue</param>
        /// <returns>The int ptr</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_msgSend_UL_IntPtr_IntPtr_Bool(
            IntPtr recv, IntPtr sel, ulong mask, IntPtr untilDate, IntPtr inMode, bool dequeue);

        /// <summary>
        ///     Cfs the string create with c string using the specified alloc
        /// </summary>
        /// <param name="alloc">The alloc</param>
        /// <param name="str">The str</param>
        /// <param name="enc">The enc</param>
        /// <returns>The int ptr</returns>
        [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr CFStringCreateWithCString(IntPtr alloc, string str, uint enc);

        /// <summary>
        ///     Nses the application load
        /// </summary>
        [DllImport("/System/Library/Frameworks/AppKit.framework/AppKit")]
        [ExcludeFromCodeCoverage]
        public static extern void NSApplicationLoad();

        /// <summary>
        ///     S the n
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The int ptr</returns>
        public static IntPtr Class(string n) => objc_getClass(n);

        /// <summary>
        ///     Sels the n
        /// </summary>
        /// <param name="n">The </param>
        /// <returns>The int ptr</returns>
        public static IntPtr Sel(string n) => sel_registerName(n);

        /// <summary>
        ///     Nses the string using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The str</returns>
        public static IntPtr NsString(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            IntPtr mem = Marshal.AllocHGlobal(bytes.Length + 1);
            Marshal.Copy(bytes, 0, mem, bytes.Length);
            Marshal.WriteByte(mem, bytes.Length, 0);
            IntPtr str = objc_msgSend_IntPtr(Class("NSString"), Sel("stringWithUTF8String:"), mem);
            Marshal.FreeHGlobal(mem);
            return str;
        }

        /// <summary>
        ///     Objcs the msg send int using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <returns>The int</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern int objc_msgSend_Int(IntPtr recv, IntPtr sel);

        /// <summary>
        ///     Objcs the msg send ul using the specified recv
        /// </summary>
        /// <param name="recv">The recv</param>
        /// <param name="sel">The sel</param>
        /// <returns>The ulong</returns>
        [DllImport(Objc, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern ulong objc_msgSend_UL(IntPtr recv, IntPtr sel);

        // P/Invoke para obtener la posición global del mouse
        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        [ExcludeFromCodeCoverage]
        public static extern CGPoint CGEventGetLocation(IntPtr eventRef);

        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr CGEventCreate(IntPtr source);

        [DllImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation")]
        [ExcludeFromCodeCoverage]
        public static extern void CFRelease(IntPtr cf);

        /// <summary>
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="selector"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr objc_msgSend(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.A.dylib", EntryPoint = "objc_msgSend")]
        [ExcludeFromCodeCoverage]
        public static extern double objc_msgSend_double(IntPtr receiver, IntPtr selector);

        /// <summary>
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlsym", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr Dlsym(IntPtr handle, string symbol);

        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("/usr/lib/libSystem.B.dylib", EntryPoint = "dlopen", CallingConvention = CallingConvention.Cdecl)]
        [ExcludeFromCodeCoverage]
        public static extern IntPtr Dlopen(string path, int mode);
    }
}

#endif