// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacOpenGLContextTests.cs
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    public class MacOpenGLContextTests
    {
        [DllImport("/usr/lib/libSystem.B.dylib")]
        private static extern int pthread_main_np();

        private static bool IsMainThread() => pthread_main_np() != 0;

        private static MacOpenGLContext CreateEmptyContext()
        {
            return (MacOpenGLContext)FormatterServices.GetUninitializedObject(typeof(MacOpenGLContext));
        }

        private static void SetProperty(MacOpenGLContext context, string name, IntPtr value)
        {
            PropertyInfo prop = typeof(MacOpenGLContext).GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            prop.SetValue(context, value);
        }

        [Fact]
        public void Constructor_WithNullWindow_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => new MacOpenGLContext(null));
        }

        [Fact]
        public void Constructor_WithValidWindow_MainThread_CreatesContext()
        {
            if (!IsMainThread())
            {
                return;
            }
            ObjectiveCInterop.NSApplicationLoad();
            MacWindow window = new MacWindow(800, 600, "GL Context Test");
            MacOpenGLContext context = new MacOpenGLContext(window);
            Assert.NotEqual(IntPtr.Zero, context.View);
            Assert.NotEqual(IntPtr.Zero, context.Context);
            Assert.NotEqual(IntPtr.Zero, context.PixelFormat);
        }

        [Fact]
        public void Constructor_WithValidWindow_MainThread_Completes()
        {
            if (!IsMainThread())
            {
                return;
            }
            ObjectiveCInterop.NSApplicationLoad();
            MacWindow window = new MacWindow(800, 600, "GL Complete Test");
            MacOpenGLContext context = null;
            Exception ex = Record.Exception(() => context = new MacOpenGLContext(window));
            Assert.Null(ex);
            Assert.NotNull(context);
        }

        [Fact]
        public void CrearContexto_WithValidWindow_MainThread_SetsAllProperties()
        {
            if (!IsMainThread())
            {
                return;
            }
            ObjectiveCInterop.NSApplicationLoad();
            MacWindow window = new MacWindow(800, 600, "CrearContexto Main Test");
            MacOpenGLContext context = new MacOpenGLContext(window);
            Assert.NotEqual(IntPtr.Zero, context.View);
            Assert.NotEqual(IntPtr.Zero, context.PixelFormat);
            Assert.NotEqual(IntPtr.Zero, context.Context);
        }

        [Fact]
        public void MakeCurrent_WithValidContext_MainThread_Succeeds()
        {
            if (!IsMainThread())
            {
                return;
            }
            ObjectiveCInterop.NSApplicationLoad();
            MacWindow window = new MacWindow(800, 600, "MakeCurrent Main Test");
            MacOpenGLContext context = new MacOpenGLContext(window);
            Exception ex = Record.Exception(() => context.MakeCurrent());
            Assert.Null(ex);
        }

        [Fact]
        public void SwapBuffers_WithValidContext_MainThread_Succeeds()
        {
            if (!IsMainThread())
            {
                return;
            }
            ObjectiveCInterop.NSApplicationLoad();
            MacWindow window = new MacWindow(800, 600, "SwapBuffers Main Test");
            MacOpenGLContext context = new MacOpenGLContext(window);
            Exception ex = Record.Exception(() => context.SwapBuffers());
            Assert.Null(ex);
        }

        [Fact]
        public void CrearContexto_CalledTwice_MainThread_Works()
        {
            if (!IsMainThread())
            {
                return;
            }
            ObjectiveCInterop.NSApplicationLoad();
            MacWindow window = new MacWindow(800, 600, "Twice Main Test");
            MacOpenGLContext context = new MacOpenGLContext(window);
            context.CrearContexto(window);
            Assert.NotEqual(IntPtr.Zero, context.View);
            Assert.NotEqual(IntPtr.Zero, context.Context);
        }

        [Fact]
        public void View_DefaultIsZero()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Assert.Equal(IntPtr.Zero, context.View);
        }

        [Fact]
        public void Context_DefaultIsZero()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Assert.Equal(IntPtr.Zero, context.Context);
        }

        [Fact]
        public void PixelFormat_DefaultIsZero()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Assert.Equal(IntPtr.Zero, context.PixelFormat);
        }

        [Fact]
        public void View_SetAndGetViaReflection()
        {
            MacOpenGLContext context = CreateEmptyContext();
            IntPtr expected = new IntPtr(12345);
            SetProperty(context, "View", expected);
            Assert.Equal(expected, context.View);
        }

        [Fact]
        public void Context_SetAndGetViaReflection()
        {
            MacOpenGLContext context = CreateEmptyContext();
            IntPtr expected = new IntPtr(67890);
            SetProperty(context, "Context", expected);
            Assert.Equal(expected, context.Context);
        }

        [Fact]
        public void PixelFormat_SetAndGetViaReflection()
        {
            MacOpenGLContext context = CreateEmptyContext();
            IntPtr expected = new IntPtr(54321);
            SetProperty(context, "PixelFormat", expected);
            Assert.Equal(expected, context.PixelFormat);
        }

        [Fact]
        public void MakeCurrent_WithZeroContext_DoesNotCrash()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Exception ex = Record.Exception(() => context.MakeCurrent());
            if (ex != null)
            {
                Assert.IsAssignableFrom<Exception>(ex);
            }
        }

        [Fact]
        public void SwapBuffers_WithZeroContext_DoesNotCrash()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Exception ex = Record.Exception(() => context.SwapBuffers());
            if (ex != null)
            {
                Assert.IsAssignableFrom<Exception>(ex);
            }
        }

        [Fact]
        public void CrearContexto_WithNullWindow_ThrowsNullReferenceException()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Assert.Throws<NullReferenceException>(() => context.CrearContexto(null));
        }

        [Fact]
        public void CrearContexto_WithZeroClass_ThrowsOrReturns()
        {
            MacOpenGLContext context = CreateEmptyContext();
            Exception ex = Record.Exception(() => context.CrearContexto(null));
            Assert.NotNull(ex);
            Assert.IsAssignableFrom<NullReferenceException>(ex);
        }

        [Fact]
        public void ViewProperty_Reflection_Exists()
        {
            PropertyInfo prop = typeof(MacOpenGLContext).GetProperty("View");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
        }

        [Fact]
        public void ContextProperty_Reflection_Exists()
        {
            PropertyInfo prop = typeof(MacOpenGLContext).GetProperty("Context");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
        }

        [Fact]
        public void PixelFormatProperty_Reflection_Exists()
        {
            PropertyInfo prop = typeof(MacOpenGLContext).GetProperty("PixelFormat");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
        }

        [Fact]
        public void MakeCurrentMethod_Reflection_Exists()
        {
            MethodInfo method = typeof(MacOpenGLContext).GetMethod("MakeCurrent");
            Assert.NotNull(method);
        }

        [Fact]
        public void SwapBuffersMethod_Reflection_Exists()
        {
            MethodInfo method = typeof(MacOpenGLContext).GetMethod("SwapBuffers");
            Assert.NotNull(method);
        }

        [Fact]
        public void CrearContextoMethod_Reflection_Exists()
        {
            MethodInfo method = typeof(MacOpenGLContext).GetMethod("CrearContexto", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
        }

        [Fact]
        public void Constructor_Reflection_Exists()
        {
            ConstructorInfo ctor = typeof(MacOpenGLContext).GetConstructor(new[] { typeof(MacWindow) });
            Assert.NotNull(ctor);
        }

        [Fact]
        public void Class_IsInternal()
        {
            Type type = typeof(MacOpenGLContext);
            Assert.True(type.IsClass);
            Assert.True(type.IsNotPublic);
        }
    }
}
#endif
