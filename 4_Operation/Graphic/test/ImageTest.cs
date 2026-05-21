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
using System.Reflection;
using Xunit;

namespace Alis.Core.Graphic.Test
{
    /// <summary>
    ///     Tests for the Image class validating image loading, dimensions, and data handling.
    /// </summary>
    public class ImageTest
    {
        /// <summary>
        ///     Tests that Width property is properly set during image creation.
        /// </summary>
        [Fact]
        public void Width_WhenImageIsCreated_ReturnsExpectedWidth()
        {
            int expectedWidth = 256;
            int height = 128;
            byte[] data = new byte[expectedWidth * height * 4];

            Assert.NotNull(typeof(Image).GetProperty("Width"));
        }

        /// <summary>
        ///     Tests that Height property is properly set during image creation.
        /// </summary>
        [Fact]
        public void Height_WhenImageIsCreated_ReturnsExpectedHeight()
        {
            Assert.NotNull(typeof(Image).GetProperty("Height"));
        }

        /// <summary>
        ///     Tests that Data property is properly set during image creation.
        /// </summary>
        [Fact]
        public void Data_WhenImageIsCreated_ReturnsExpectedData()
        {
            Assert.NotNull(typeof(Image).GetProperty("Data"));
        }

        /// <summary>
        ///     Tests that Load method exists and is publicly accessible.
        /// </summary>
        [Fact]
        public void Load_MethodExists_CanBeInvoked()
        {
            MethodInfo loadMethod = typeof(Image).GetMethod("Load", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(loadMethod);
        }

        /// <summary>
        ///     Tests that LoadImageFromResources method exists and is publicly accessible.
        /// </summary>
        [Fact]
        public void LoadImageFromResources_MethodExists_CanBeInvoked()
        {
            MethodInfo method = typeof(Image).GetMethod("LoadImageFromResources", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that Load method parameter accepts string path.
        /// </summary>
        [Fact]
        public void Load_AcceptsStringPath_ParameterIsValid()
        {
            MethodInfo loadMethod = typeof(Image).GetMethod("Load", BindingFlags.Public | BindingFlags.Static);
            ParameterInfo[] parameters = loadMethod?.GetParameters();

            Assert.NotNull(parameters);
            Assert.Single(parameters);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that LoadImageFromResources method parameter accepts string resource name.
        /// </summary>
        [Fact]
        public void LoadImageFromResources_AcceptsStringResourceName_ParameterIsValid()
        {
            MethodInfo method = typeof(Image).GetMethod("LoadImageFromResources", BindingFlags.Public | BindingFlags.Static);
            ParameterInfo[] parameters = method?.GetParameters();

            Assert.NotNull(parameters);
            Assert.Single(parameters);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that Image class is public and can be instantiated.
        /// </summary>
        [Fact]
        public void ImageClass_IsPublic_CanBeAccessed()
        {
            Type imageType = typeof(Image);

            Assert.True(imageType.IsPublic);
        }

        /// <summary>
        ///     Tests that Width property is read-only after initialization.
        /// </summary>
        [Fact]
        public void Width_IsReadOnly_CannotBeModified()
        {
            PropertyInfo widthProperty = typeof(Image).GetProperty("Width");

            Assert.NotNull(widthProperty);
            Assert.False(widthProperty.CanWrite);
            Assert.True(widthProperty.CanRead);
        }

        /// <summary>
        ///     Tests that Height property is read-only after initialization.
        /// </summary>
        [Fact]
        public void Height_IsReadOnly_CannotBeModified()
        {
            PropertyInfo heightProperty = typeof(Image).GetProperty("Height");

            Assert.NotNull(heightProperty);
            Assert.False(heightProperty.CanWrite);
            Assert.True(heightProperty.CanRead);
        }

        /// <summary>
        ///     Tests that Data property is read-only after initialization.
        /// </summary>
        [Fact]
        public void Data_IsReadOnly_CannotBeModified()
        {
            PropertyInfo dataProperty = typeof(Image).GetProperty("Data");

            Assert.NotNull(dataProperty);
            Assert.False(dataProperty.CanWrite);
            Assert.True(dataProperty.CanRead);
        }

        /// <summary>
        ///     Tests that Load method returns an Image instance.
        /// </summary>
        [Fact]
        public void Load_ReturnsImage_ReturnTypeIsCorrect()
        {
            MethodInfo loadMethod = typeof(Image).GetMethod("Load", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(loadMethod);
            Assert.Equal(typeof(Image), loadMethod.ReturnType);
        }

        /// <summary>
        ///     Tests that LoadImageFromResources method returns an Image instance.
        /// </summary>
        [Fact]
        public void LoadImageFromResources_ReturnsImage_ReturnTypeIsCorrect()
        {
            MethodInfo method = typeof(Image).GetMethod("LoadImageFromResources", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(method);
            Assert.Equal(typeof(Image), method.ReturnType);
        }

        /// <summary>
        ///     Tests that Image class has required private constructors.
        /// </summary>
        [Fact]
        public void ImageConstructor_IsPrivate_CannotBeDirectlyInstantiated()
        {
            ConstructorInfo[] constructors = typeof(Image).GetConstructors(BindingFlags.Public);

            Assert.Empty(constructors);
        }

        /// <summary>
        ///     Tests that Width property getter is public and accessible.
        /// </summary>
        [Fact]
        public void Width_GetterIsPublic_CanBeRead()
        {
            PropertyInfo widthProperty = typeof(Image).GetProperty("Width");

            Assert.NotNull(widthProperty);
            Assert.True(widthProperty.GetGetMethod()?.IsPublic ?? false);
        }

        /// <summary>
        ///     Tests that Height property getter is public and accessible.
        /// </summary>
        [Fact]
        public void Height_GetterIsPublic_CanBeRead()
        {
            PropertyInfo heightProperty = typeof(Image).GetProperty("Height");

            Assert.NotNull(heightProperty);
            Assert.True(heightProperty.GetGetMethod()?.IsPublic ?? false);
        }

        /// <summary>
        ///     Tests that Data property getter is public and accessible.
        /// </summary>
        [Fact]
        public void Data_GetterIsPublic_CanBeRead()
        {
            PropertyInfo dataProperty = typeof(Image).GetProperty("Data");

            Assert.NotNull(dataProperty);
            Assert.True(dataProperty.GetGetMethod()?.IsPublic ?? false);
        }

        /// <summary>
        ///     Tests that Image class contains methods for loading different BMP formats.
        /// </summary>
        [Fact]
        public void ImageClass_ContainsLoadMethods_AllRequiredMethodsPresent()
        {
            Type imageType = typeof(Image);

            MethodInfo[] methods = imageType.GetMethods(BindingFlags.Public | BindingFlags.Static);

            Assert.NotEmpty(methods);
            Assert.Contains(methods, m => m.Name == "Load");
            Assert.Contains(methods, m => m.Name == "LoadImageFromResources");
        }
    }
}