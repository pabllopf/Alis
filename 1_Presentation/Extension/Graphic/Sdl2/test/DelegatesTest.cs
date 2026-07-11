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
    public class DelegatesTest
    {
        [Fact]
        public void SdlAudioCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlAudioCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlAudioCallback_CanBeCreated()
        {
            void Callback(IntPtr userdata, IntPtr stream, int len) { }
            SdlAudioCallback callback = Callback;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlEventFilter_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlEventFilter);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlEventFilter_CanBeCreated()
        {
            int Filter(IntPtr userdata, IntPtr sdlEvent) => 0;
            SdlEventFilter callback = Filter;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlHitTest_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlHitTest);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlHitTest_CanBeCreated()
        {
            HitTestResult HitTest(IntPtr win, IntPtr area, IntPtr data) => HitTestResult.SdlHitTestNormal;
            SdlHitTest callback = HitTest;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlIPhoneAnimationCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlIPhoneAnimationCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlIPhoneAnimationCallback_CanBeCreated()
        {
            void Callback(IntPtr p) { }
            SdlIPhoneAnimationCallback callback = Callback;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlLogOutputFunction_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlLogOutputFunction);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlLogOutputFunction_CanBeCreated()
        {
            void LogFunc(IntPtr userdata, int category, LogPriority priority, IntPtr message) { }
            SdlLogOutputFunction callback = LogFunc;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlMainFunc_CanBeCreated()
        {
            int MainFunc(int argc, IntPtr argv) => 0;
            SdlMainFunc callback = MainFunc;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlMainFunc_HasNoUnmanagedFunctionPointerAttribute()
        {
            var type = typeof(SdlMainFunc);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.Null(attr);
        }

        [Fact]
        public void SdlTimerCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlTimerCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlTimerCallback_CanBeCreated()
        {
            uint TimerCallback(uint interval, IntPtr param) => 0;
            SdlTimerCallback callback = TimerCallback;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlWindowsMessageHook_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlWindowsMessageHook);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlWindowsMessageHook_CanBeCreated()
        {
            IntPtr Hook(IntPtr userdata, IntPtr hWnd, uint message, ulong wParam, long lParam) => IntPtr.Zero;
            SdlWindowsMessageHook callback = Hook;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlWopsCloseCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlWopsCloseCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlWopsCloseCallback_CanBeCreated()
        {
            int Close(IntPtr context) => 0;
            SdlWopsCloseCallback callback = Close;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlWopsReadCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlWopsReadCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlWopsReadCallback_CanBeCreated()
        {
            IntPtr Read(IntPtr context, IntPtr ptr, IntPtr size, IntPtr maxNum) => IntPtr.Zero;
            SdlWopsReadCallback callback = Read;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlWopsSeekCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlWopsSeekCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlWopsSeekCallback_CanBeCreated()
        {
            long Seek(IntPtr context, long offset, int whence) => 0;
            SdlWopsSeekCallback callback = Seek;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlWopsSizeCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlWopsSizeCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlWopsSizeCallback_CanBeCreated()
        {
            long Size(IntPtr context) => 0;
            SdlWopsSizeCallback callback = Size;
            Assert.NotNull(callback);
        }

        [Fact]
        public void SdlWopsWriteCallback_HasCorrectAttributeAndSignature()
        {
            var type = typeof(SdlWopsWriteCallback);
            var attr = (UnmanagedFunctionPointerAttribute)Attribute.GetCustomAttribute(type, typeof(UnmanagedFunctionPointerAttribute));
            Assert.NotNull(attr);
            Assert.Equal(CallingConvention.Cdecl, attr.CallingConvention);
        }

        [Fact]
        public void SdlWopsWriteCallback_CanBeCreated()
        {
            IntPtr Write(IntPtr context, IntPtr ptr, IntPtr size, IntPtr num) => IntPtr.Zero;
            SdlWopsWriteCallback callback = Write;
            Assert.NotNull(callback);
        }
    }
}
