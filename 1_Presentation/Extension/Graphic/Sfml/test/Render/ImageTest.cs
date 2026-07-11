// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImageTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the <see cref="Image"/> class.
    /// </summary>
    public class ImageTest
    {
        [Fact]
        public void Image_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Image)));
        }

        [Fact]
        public void Image_ConstructorOverloads_Exist()
        {
            var ctors = typeof(Image).GetConstructors();
            Assert.Contains(ctors, c => c.GetParameters().Length == 2 && c.GetParameters()[0].ParameterType == typeof(uint) && c.GetParameters()[1].ParameterType == typeof(uint));
            Assert.Contains(ctors, c => c.GetParameters().Length == 3 && c.GetParameters()[0].ParameterType == typeof(uint) && c.GetParameters()[1].ParameterType == typeof(uint) && c.GetParameters()[2].ParameterType == typeof(Color));
            Assert.Contains(ctors, c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(string));
            Assert.Contains(ctors, c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(byte[]));
            Assert.Contains(ctors, c => c.GetParameters().Length == 3 && c.GetParameters()[0].ParameterType == typeof(uint) && c.GetParameters()[1].ParameterType == typeof(uint) && c.GetParameters()[2].ParameterType == typeof(byte[]));
        }

        [Fact]
        public void Pixels_Property_Exists()
        {
            var prop = typeof(Image).GetProperty("Pixels");
            Assert.NotNull(prop);
            Assert.Equal(typeof(byte[]), prop.PropertyType);
        }

        [Fact]
        public void Size_Property_Exists()
        {
            var prop = typeof(Image).GetProperty("Size");
            Assert.NotNull(prop);
        }

        [Fact]
        public void SaveToFile_Method_Exists()
        {
            var method = typeof(Image).GetMethod("SaveToFile");
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        [Fact]
        public void CreateMaskFromColor_SingleParam_Exists()
        {
            var method = typeof(Image).GetMethod("CreateMaskFromColor", new[] { typeof(Color) });
            Assert.NotNull(method);
        }

        [Fact]
        public void CreateMaskFromColor_TwoParams_Exists()
        {
            var method = typeof(Image).GetMethod("CreateMaskFromColor", new[] { typeof(Color), typeof(byte) });
            Assert.NotNull(method);
        }

        [Fact]
        public void Copy_MethodOverloads_Exist()
        {
            Assert.NotNull(typeof(Image).GetMethod("Copy", new[] { typeof(Image), typeof(uint), typeof(uint) }));
            Assert.NotNull(typeof(Image).GetMethod("Copy", new[] { typeof(Image), typeof(uint), typeof(uint), typeof(IntRect) }));
            Assert.NotNull(typeof(Image).GetMethod("Copy", new[] { typeof(Image), typeof(uint), typeof(uint), typeof(IntRect), typeof(bool) }));
        }

        [Fact]
        public void GetPixel_SetPixel_Methods_Exist()
        {
            Assert.NotNull(typeof(Image).GetMethod("GetPixel"));
            Assert.NotNull(typeof(Image).GetMethod("SetPixel"));
        }

        [Fact]
        public void FlipHorizontally_FlipVertically_Methods_Exist()
        {
            Assert.NotNull(typeof(Image).GetMethod("FlipHorizontally"));
            Assert.NotNull(typeof(Image).GetMethod("FlipVertically"));
        }
    }
}
