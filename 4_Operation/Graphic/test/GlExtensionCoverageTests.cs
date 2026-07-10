// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlExtensionCoverageTests.cs
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
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    public class GlExtensionCoverageTests : IDisposable
    {
        private readonly FieldInfo _getProcAddressField;
        private readonly object _previousValue;

        public GlExtensionCoverageTests()
        {
            _getProcAddressField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);
            _previousValue = _getProcAddressField?.GetValue(null);
        }

        public void Dispose()
        {
            _getProcAddressField?.SetValue(null, _previousValue);
        }

        [Fact]
        public void Gl_IsStaticClass()
        {
            Assert.True(typeof(Gl).IsAbstract && typeof(Gl).IsSealed);
        }

        [Fact]
        public void IsKeyDown_Method_DoesNotExist()
        {
            Assert.Null(typeof(Gl).GetMethod("IsKeyDown", BindingFlags.Public | BindingFlags.Static));
        }

        [Fact]
        public void IsKeyDown_Property_DoesNotExist()
        {
            Assert.Null(typeof(Gl).GetProperty("IsKeyDown"));
        }

        [Fact]
        public void Initialize_StoresDelegate()
        {
            Assert.Null(_getProcAddressField?.GetValue(null));

            Gl.GetProcAddressDelegate del = name => IntPtr.Zero;
            Gl.Initialize(del);

            Assert.NotNull(_getProcAddressField?.GetValue(null));
        }

        [Fact]
        public void GetString_NullPointer_ReturnsEmpty()
        {
            GetString dummy = (StringName _) => IntPtr.Zero;
            IntPtr funcPtr = Marshal.GetFunctionPointerForDelegate(dummy);

            Gl.Initialize(name => name == "glGetString" ? funcPtr : IntPtr.Zero);

            string result = Gl.GlGetString(StringName.Vendor);
            Assert.Equal(string.Empty, result);
        }
    }
}
