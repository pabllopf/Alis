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
    /// <summary>
    /// The texture tests class
    /// </summary>
    public class TextureTests
    {
        /// <summary>
        /// Tests that texture is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Texture)));
        }

        /// <summary>
        /// Tests that texture implements i disposable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Texture_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Texture)));
        }

        /// <summary>
        /// Tests that native handle property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("NativeHandle"));
        }

        /// <summary>
        /// Tests that smooth property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Smooth_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Smooth"));
        }

        /// <summary>
        /// Tests that srgb property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Srgb_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Srgb"));
        }

        /// <summary>
        /// Tests that repeated property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Repeated_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Repeated"));
        }

        /// <summary>
        /// Tests that size property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("Size"));
        }

        /// <summary>
        /// Tests that maximum size property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumSize_Property_Exists()
        {
            Assert.NotNull(typeof(Texture).GetProperty("MaximumSize"));
        }

        /// <summary>
        /// Tests that copy to image method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CopyToImage_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("CopyToImage"));
        }

        /// <summary>
        /// Tests that update with byte array method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithByteArray_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(byte[]) }));
        }

        /// <summary>
        /// Tests that update with byte array width height xy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithByteArrayWidthHeightXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(byte[]), typeof(float), typeof(float), typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that update with texture and xy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithTextureAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Texture), typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that update with image method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithImage_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Image) }));
        }

        /// <summary>
        /// Tests that update with image and xy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithImageAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Image), typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that update with window method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithWindow_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Window) }));
        }

        /// <summary>
        /// Tests that update with window and xy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithWindowAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(Window), typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that update with render window method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithRenderWindow_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(RenderWindow) }));
        }

        /// <summary>
        /// Tests that update with render window and xy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Update_WithRenderWindowAndXY_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Update", new[] { typeof(RenderWindow), typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that generate mipmap method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GenerateMipmap_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("GenerateMipmap"));
        }

        /// <summary>
        /// Tests that swap method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Swap_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Swap"));
        }

        /// <summary>
        /// Tests that bind static method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_StaticMethod_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Bind", new[] { typeof(Texture) }));
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("ToString"));
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(Texture).GetMethod("Destroy"));
        }

        /// <summary>
        /// Tests that constructor width height exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_WidthHeight_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(uint), typeof(uint) }));
        }

        /// <summary>
        /// Tests that constructor filename exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Filename_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(string) }));
        }

        /// <summary>
        /// Tests that constructor filename and area exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_FilenameAndArea_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(string), typeof(IntRect) }));
        }

        /// <summary>
        /// Tests that constructor stream exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Stream_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(System.IO.Stream) }));
        }

        /// <summary>
        /// Tests that constructor stream and area exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_StreamAndArea_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(System.IO.Stream), typeof(IntRect) }));
        }

        /// <summary>
        /// Tests that constructor image exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Image_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(Image) }));
        }

        /// <summary>
        /// Tests that constructor image and area exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ImageAndArea_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(Image), typeof(IntRect) }));
        }

        /// <summary>
        /// Tests that constructor bytes exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Bytes_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(byte[]) }));
        }

        /// <summary>
        /// Tests that constructor copy exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Copy_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(new[] { typeof(Texture) }));
        }

        /// <summary>
        /// Tests that constructor int ptr exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_IntPtr_Exists()
        {
            Assert.NotNull(typeof(Texture).GetConstructor(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null));
        }

        /// <summary>
        /// Tests that smooth property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Smooth_Property_IsReadWrite()
        {
            var prop = typeof(Texture).GetProperty("Smooth");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that srgb property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Srgb_Property_IsReadWrite()
        {
            var prop = typeof(Texture).GetProperty("Srgb");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that repeated property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Repeated_Property_IsReadWrite()
        {
            var prop = typeof(Texture).GetProperty("Repeated");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that size property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_IsReadOnly()
        {
            var prop = typeof(Texture).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that native handle property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void NativeHandle_Property_IsReadOnly()
        {
            var prop = typeof(Texture).GetProperty("NativeHandle");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that maximum size property is static
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumSize_Property_IsStatic()
        {
            var prop = typeof(Texture).GetProperty("MaximumSize");
            Assert.NotNull(prop);
            Assert.True(prop.GetMethod.IsStatic);
        }

        /// <summary>
        /// Tests that maximum size property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MaximumSize_Property_IsReadOnly()
        {
            var prop = typeof(Texture).GetProperty("MaximumSize");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that bind method is static
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Bind_Method_IsStatic()
        {
            var method = typeof(Texture).GetMethod("Bind", new[] { typeof(Texture) });
            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        /// <summary>
        /// Tests that to string is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_IsOverride()
        {
            var method = typeof(Texture).GetMethod("ToString");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that destroy is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_IsOverride()
        {
            var method = typeof(Texture).GetMethod("Destroy");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }
    }
}
