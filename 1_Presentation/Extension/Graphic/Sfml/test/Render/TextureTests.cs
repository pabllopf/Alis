// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    public class TextureTests
    {
        [Fact]
        public void Texture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Texture)));
        }

        [Fact]
        public void Texture_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Texture)));
        }

        [Fact]
        public void NativeHandle_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("NativeHandle"));
        }

        [Fact]
        public void Smooth_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Smooth"));
        }

        [Fact]
        public void Srgb_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Srgb"));
        }

        [Fact]
        public void Repeated_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Repeated"));
        }

        [Fact]
        public void Size_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Size"));
        }

        [Fact]
        public void MaximumSize_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("MaximumSize"));
        }

        [Fact]
        public void CopyToImage_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("CopyToImage"));
        }

        [Fact]
        public void Update_WithByteArray_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(byte[]) }));
        }

        [Fact]
        public void Update_WithByteArrayWidthHeightXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(byte[]), typeof(float), typeof(float), typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void Update_WithTextureAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Texture), typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void Update_WithImage_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Image) }));
        }

        [Fact]
        public void Update_WithImageAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Image), typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void Update_WithWindow_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Window) }));
        }

        [Fact]
        public void Update_WithWindowAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Window), typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void Update_WithRenderWindow_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(RenderWindow) }));
        }

        [Fact]
        public void Update_WithRenderWindowAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(RenderWindow), typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void GenerateMipmap_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("GenerateMipmap"));
        }

        [Fact]
        public void Swap_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Swap"));
        }

        [Fact]
        public void Bind_StaticMethod_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Bind", new[] { typeof(Texture) }));
        }

        [Fact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("ToString"));
        }

        [Fact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Destroy"));
        }

        [Fact]
        public void Constructor_WidthHeight_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(uint), typeof(uint) }));
        }

        [Fact]
        public void Constructor_Filename_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(string) }));
        }

        [Fact]
        public void Constructor_FilenameAndArea_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(string), typeof(IntRect) }));
        }

        [Fact]
        public void Constructor_Stream_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(System.IO.Stream) }));
        }

        [Fact]
        public void Constructor_StreamAndArea_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(System.IO.Stream), typeof(IntRect) }));
        }

        [Fact]
        public void Constructor_Image_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(Image) }));
        }

        [Fact]
        public void Constructor_ImageAndArea_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(Image), typeof(IntRect) }));
        }

        [Fact]
        public void Constructor_Bytes_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(byte[]) }));
        }

        [Fact]
        public void Constructor_Copy_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(Texture) }));
        }

        [Fact]
        public void Constructor_IntPtr_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null));
        }

        [Fact]
        public void Smooth_Property_IsReadWrite()
        {
            var prop = typeof(Texture).GetProperty("Smooth");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Srgb_Property_IsReadWrite()
        {
            var prop = typeof(Texture).GetProperty("Srgb");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Repeated_Property_IsReadWrite()
        {
            var prop = typeof(Texture).GetProperty("Repeated");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Size_Property_IsReadOnly()
        {
            var prop = typeof(Texture).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void NativeHandle_Property_IsReadOnly()
        {
            var prop = typeof(Texture).GetProperty("NativeHandle");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void MaximumSize_Property_IsStatic()
        {
            var prop = typeof(Texture).GetProperty("MaximumSize");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        [Fact]
        public void MaximumSize_Property_IsReadOnly()
        {
            var prop = typeof(Texture).GetProperty("MaximumSize");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void Bind_Method_IsStatic()
        {
            var method = typeof(Texture).GetMethod("Bind", new[] { typeof(Texture) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        [Fact]
        public void ToString_IsOverride()
        {
            var method = typeof(Texture).GetMethod("ToString");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        [Fact]
        public void Destroy_IsOverride()
        {
            var method = typeof(Texture).GetMethod("Destroy");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }
    }
}
