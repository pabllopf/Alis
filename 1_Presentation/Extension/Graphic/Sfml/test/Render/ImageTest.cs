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

using System;
using System.IO;
using System.Reflection;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The image test class
    /// </summary>
    public class ImageTest
    {
        /// <summary>
        /// Tests that image is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Image)));
        }

        /// <summary>
        /// Tests that image implements i disposable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Image)));
        }

        /// <summary>
        /// Tests that image constructor overloads exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_ConstructorOverloads_Exist()
        {
            ConstructorInfo[] ctors = typeof(Image).GetConstructors();
            Assert.Contains(ctors, c => c.GetParameters().Length == 2 && c.GetParameters()[0].ParameterType == typeof(uint) && c.GetParameters()[1].ParameterType == typeof(uint));
            Assert.Contains(ctors, c => c.GetParameters().Length == 3 && c.GetParameters()[0].ParameterType == typeof(uint) && c.GetParameters()[1].ParameterType == typeof(uint) && c.GetParameters()[2].ParameterType == typeof(Color));
            Assert.Contains(ctors, c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(string));
            Assert.Contains(ctors, c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(byte[]));
            Assert.Contains(ctors, c => c.GetParameters().Length == 3 && c.GetParameters()[0].ParameterType == typeof(uint) && c.GetParameters()[1].ParameterType == typeof(uint) && c.GetParameters()[2].ParameterType == typeof(byte[]));
        }

        /// <summary>
        /// Tests that image stream constructor exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_StreamConstructor_Exists()
        {
            ConstructorInfo ctor = typeof(Image).GetConstructor(new[] { typeof(Stream) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Tests that image copy constructor exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_CopyConstructor_Exists()
        {
            ConstructorInfo ctor = typeof(Image).GetConstructor(new[] { typeof(Image) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Tests that image internal constructor exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Image_InternalConstructor_Exists()
        {
            ConstructorInfo[] ctors = typeof(Image).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            Assert.Contains(ctors, c =>
            {
                ParameterInfo[] parameters = c.GetParameters();
                return parameters.Length == 1 && parameters[0].ParameterType == typeof(IntPtr);
            });
        }

        /// <summary>
        /// Tests that pixels property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Pixels_Property_Exists()
        {
            PropertyInfo prop = typeof(Image).GetProperty("Pixels");
            Assert.NotNull(prop);
            Assert.Equal(typeof(byte[]), prop.PropertyType);
        }

        /// <summary>
        /// Tests that pixels property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Pixels_Property_IsReadOnly()
        {
            PropertyInfo prop = typeof(Image).GetProperty("Pixels");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that size property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_Exists()
        {
            PropertyInfo prop = typeof(Image).GetProperty("Size");
            Assert.NotNull(prop);
        }

        /// <summary>
        /// Tests that size property is read only
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Size_Property_IsReadOnly()
        {
            PropertyInfo prop = typeof(Image).GetProperty("Size");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that c pointer property exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CPointer_Property_Exists()
        {
            PropertyInfo prop = typeof(Image).GetProperty("CPointer");
            Assert.NotNull(prop);
            Assert.Equal(typeof(IntPtr), prop.PropertyType);
        }

        /// <summary>
        /// Tests that save to file method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SaveToFile_Method_Exists()
        {
            MethodInfo method = typeof(Image).GetMethod("SaveToFile");
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Tests that create mask from color single param exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CreateMaskFromColor_SingleParam_Exists()
        {
            MethodInfo method = typeof(Image).GetMethod("CreateMaskFromColor", new[] { typeof(Color) });
            Assert.NotNull(method);
        }

        /// <summary>
        /// Tests that create mask from color two params exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CreateMaskFromColor_TwoParams_Exists()
        {
            MethodInfo method = typeof(Image).GetMethod("CreateMaskFromColor", new[] { typeof(Color), typeof(byte) });
            Assert.NotNull(method);
        }

        /// <summary>
        /// Tests that copy method overloads exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Copy_MethodOverloads_Exist()
        {
            Assert.NotNull(typeof(Image).GetMethod("Copy", new[] { typeof(Image), typeof(uint), typeof(uint) }));
            Assert.NotNull(typeof(Image).GetMethod("Copy", new[] { typeof(Image), typeof(uint), typeof(uint), typeof(IntRect) }));
            Assert.NotNull(typeof(Image).GetMethod("Copy", new[] { typeof(Image), typeof(uint), typeof(uint), typeof(IntRect), typeof(bool) }));
        }

        /// <summary>
        /// Tests that get pixel set pixel methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetPixel_SetPixel_Methods_Exist()
        {
            Assert.NotNull(typeof(Image).GetMethod("GetPixel"));
            Assert.NotNull(typeof(Image).GetMethod("SetPixel"));
        }

        /// <summary>
        /// Tests that flip horizontally flip vertically methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void FlipHorizontally_FlipVertically_Methods_Exist()
        {
            Assert.NotNull(typeof(Image).GetMethod("FlipHorizontally"));
            Assert.NotNull(typeof(Image).GetMethod("FlipVertically"));
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_Method_Exists()
        {
            MethodInfo method = typeof(Image).GetMethod("ToString", Type.EmptyTypes);
            Assert.NotNull(method);
        }

        /// <summary>
        /// Tests that to string is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_IsOverride()
        {
            MethodInfo method = typeof(Image).GetMethod("ToString", Type.EmptyTypes);
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_Method_Exists()
        {
            MethodInfo method = typeof(Image).GetMethod("Destroy", new[] { typeof(bool) });
            Assert.NotNull(method);
        }

        /// <summary>
        /// Tests that destroy is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_IsOverride()
        {
            MethodInfo method = typeof(Image).GetMethod("Destroy", new[] { typeof(bool) });
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }
    }
}
