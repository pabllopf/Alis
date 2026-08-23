// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DelegatesTest.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Delegates;
using Alis.Extension.Graphic.Sdl2.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The delegates test class
    /// </summary>
    public class DelegatesTest
    {
        /// <summary>
        /// Tests that sdl audio callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlAudioCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlAudioCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl audio callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlAudioCallback_CanBeCreated()
        {
            void Callback(IntPtr userdata, IntPtr stream, int len) { }
            SdlAudioCallback callback = Callback;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl event filter has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlEventFilter_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlEventFilter);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl event filter can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlEventFilter_CanBeCreated()
        {
            int Filter(IntPtr userdata, IntPtr sdlEvent) => 0;
            SdlEventFilter callback = Filter;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl hit test has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlHitTest_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlHitTest);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl hit test can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlHitTest_CanBeCreated()
        {
            HitTestResult HitTest(IntPtr win, IntPtr area, IntPtr data) => HitTestResult.SdlHitTestNormal;
            SdlHitTest callback = HitTest;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl i phone animation callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlIPhoneAnimationCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlIPhoneAnimationCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl i phone animation callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlIPhoneAnimationCallback_CanBeCreated()
        {
            void Callback(IntPtr p) { }
            SdlIPhoneAnimationCallback callback = Callback;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl log output function has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlLogOutputFunction_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlLogOutputFunction);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl log output function can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlLogOutputFunction_CanBeCreated()
        {
            void LogFunc(IntPtr userdata, int category, LogPriority priority, IntPtr message) { }
            SdlLogOutputFunction callback = LogFunc;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl main func can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlMainFunc_CanBeCreated()
        {
            int MainFunc(int argc, IntPtr argv) => 0;
            SdlMainFunc callback = MainFunc;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl main func has no unmanaged function pointer attribute
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlMainFunc_HasNoUnmanagedFunctionPointerAttribute()
        {
            Type type = typeof(SdlMainFunc);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.Null(attr);
        }

        /// <summary>
        /// Tests that sdl timer callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlTimerCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlTimerCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl timer callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlTimerCallback_CanBeCreated()
        {
            uint TimerCallback(uint interval, IntPtr param) => 0;
            SdlTimerCallback callback = TimerCallback;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl windows message hook has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWindowsMessageHook_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlWindowsMessageHook);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl windows message hook can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWindowsMessageHook_CanBeCreated()
        {
            IntPtr Hook(IntPtr userdata, IntPtr hWnd, uint message, ulong wParam, long lParam) => IntPtr.Zero;
            SdlWindowsMessageHook callback = Hook;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl wops close callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsCloseCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlWopsCloseCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl wops close callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsCloseCallback_CanBeCreated()
        {
            int Close(IntPtr context) => 0;
            SdlWopsCloseCallback callback = Close;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl wops read callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsReadCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlWopsReadCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl wops read callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsReadCallback_CanBeCreated()
        {
            IntPtr Read(IntPtr context, IntPtr ptr, IntPtr size, IntPtr maxNum) => IntPtr.Zero;
            SdlWopsReadCallback callback = Read;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl wops seek callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsSeekCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlWopsSeekCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl wops seek callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsSeekCallback_CanBeCreated()
        {
            long Seek(IntPtr context, long offset, int whence) => 0;
            SdlWopsSeekCallback callback = Seek;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl wops size callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsSizeCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlWopsSizeCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl wops size callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsSizeCallback_CanBeCreated()
        {
            long Size(IntPtr context) => 0;
            SdlWopsSizeCallback callback = Size;
            Assert.NotNull(callback);
        }

        /// <summary>
        /// Tests that sdl wops write callback has correct attribute and signature
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsWriteCallback_HasCorrectAttributeAndSignature()
        {
            Type type = typeof(SdlWopsWriteCallback);
            UnmanagedFunctionPointerAttribute attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        /// <summary>
        /// Tests that sdl wops write callback can be created
        /// </summary>
        [RequireSdl2ImageFact]
        public void SdlWopsWriteCallback_CanBeCreated()
        {
            IntPtr Write(IntPtr context, IntPtr ptr, IntPtr size, IntPtr num) => IntPtr.Zero;
            SdlWopsWriteCallback callback = Write;
            Assert.NotNull(callback);
        }
    }
}
