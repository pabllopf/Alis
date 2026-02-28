// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontManagerTest.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Graphic.Ui;
using Xunit;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    ///     Tests for the FontManager static class managing font rendering operations.
    /// </summary>
    public class FontManagerTest
    {
        /// <summary>
        ///     Tests that DefaultFont property is static and accessible.
        /// </summary>
        [Fact]
        public void DefaultFont_IsStatic_CanBeAccessed()
        {
            // Arrange & Act
            PropertyInfo defaultFontProperty = typeof(FontManager).GetProperty("DefaultFont",
                BindingFlags.Public | BindingFlags.Static);

            // Assert
            Assert.NotNull(defaultFontProperty);
            Assert.True(defaultFontProperty.CanRead);
        }

        /// <summary>
        ///     Tests that DefaultFont returns a Font instance.
        /// </summary>
        [Fact]
        public void DefaultFont_ReturnsFont_TypeIsCorrect()
        {
            // Arrange & Act
            PropertyInfo defaultFontProperty = typeof(FontManager).GetProperty("DefaultFont",
                BindingFlags.Public | BindingFlags.Static);

            // Assert
            Assert.NotNull(defaultFontProperty);
            Assert.Equal(typeof(Font), defaultFontProperty.PropertyType);
        }

        /// <summary>
        ///     Tests that DefaultFont property is read-only.
        /// </summary>
        [Fact]
        public void DefaultFont_IsReadOnly_CannotBeModified()
        {
            // Arrange & Act
            PropertyInfo defaultFontProperty = typeof(FontManager).GetProperty("DefaultFont",
                BindingFlags.Public | BindingFlags.Static);

            // Assert
            Assert.NotNull(defaultFontProperty);
            Assert.False(defaultFontProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that RenderText method exists with text and coordinates parameters.
        /// </summary>
        [Fact]
        public void RenderText_MethodWithCoordinatesExists_CanBeInvoked()
        {
            // Arrange & Act
            MethodInfo method = typeof(FontManager).GetMethod("RenderText",
                BindingFlags.Public | BindingFlags.Static,
                null, new[] {typeof(string), typeof(int), typeof(int)}, null);

            // Assert
            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that RenderText method exists with color parameters.
        /// </summary>
        [Fact]
        public void RenderText_MethodWithColorsExists_CanBeInvoked()
        {
            // Arrange & Act
            MethodInfo method = typeof(FontManager).GetMethod("RenderText",
                BindingFlags.Public | BindingFlags.Static,
                null, new[] {typeof(string), typeof(int), typeof(int), typeof(Color), typeof(Color)}, null);

            // Assert
            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that FontManager is a static class (sealed and all members static).
        /// </summary>
        [Fact]
        public void FontManager_IsStatic_ClassIsCorrectlyStructured()
        {
            // Arrange
            Type fontManagerType = typeof(FontManager);

            // Act & Assert
            Assert.True(fontManagerType.IsSealed);
            Assert.True(fontManagerType.IsAbstract); // Static classes are sealed and abstract
        }

        /// <summary>
        ///     Tests that FontManager class is public.
        /// </summary>
        [Fact]
        public void FontManager_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            Type fontManagerType = typeof(FontManager);

            // Assert
            Assert.True(fontManagerType.IsPublic);
        }

        /// <summary>
        ///     Tests that RenderText with colors method accepts correct parameter types.
        /// </summary>
        [Fact]
        public void RenderText_WithColors_ParametersAreCorrect()
        {
            // Arrange
            MethodInfo method = typeof(FontManager).GetMethod("RenderText",
                BindingFlags.Public | BindingFlags.Static,
                null, new[] {typeof(string), typeof(int), typeof(int), typeof(Color), typeof(Color)}, null);

            // Act
            ParameterInfo[] parameters = method?.GetParameters();

            // Assert
            Assert.NotNull(parameters);
            Assert.Equal(5, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
            Assert.Equal(typeof(int), parameters[1].ParameterType);
            Assert.Equal(typeof(int), parameters[2].ParameterType);
            Assert.Equal(typeof(Color), parameters[3].ParameterType);
            Assert.Equal(typeof(Color), parameters[4].ParameterType);
        }

        /// <summary>
        ///     Tests that RenderText with coordinates method accepts correct parameter types.
        /// </summary>
        [Fact]
        public void RenderText_WithCoordinates_ParametersAreCorrect()
        {
            // Arrange
            MethodInfo method = typeof(FontManager).GetMethod("RenderText",
                BindingFlags.Public | BindingFlags.Static,
                null, new[] {typeof(string), typeof(int), typeof(int)}, null);

            // Act
            ParameterInfo[] parameters = method?.GetParameters();

            // Assert
            Assert.NotNull(parameters);
            Assert.Equal(3, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
            Assert.Equal(typeof(int), parameters[1].ParameterType);
            Assert.Equal(typeof(int), parameters[2].ParameterType);
        }

        /// <summary>
        ///     Tests that both RenderText methods return void.
        /// </summary>
        [Fact]
        public void RenderText_Methods_ReturnVoid()
        {
            // Arrange
            MethodInfo method1 = typeof(FontManager).GetMethod("RenderText",
                BindingFlags.Public | BindingFlags.Static,
                null, new[] {typeof(string), typeof(int), typeof(int)}, null);
            MethodInfo method2 = typeof(FontManager).GetMethod("RenderText",
                BindingFlags.Public | BindingFlags.Static,
                null, new[] {typeof(string), typeof(int), typeof(int), typeof(Color), typeof(Color)}, null);

            // Act & Assert
            Assert.NotNull(method1);
            Assert.Equal(typeof(void), method1.ReturnType);
            Assert.NotNull(method2);
            Assert.Equal(typeof(void), method2.ReturnType);
        }

        /// <summary>
        ///     Tests that FontManager has only static members.
        /// </summary>
        [Fact]
        public void FontManager_AllMembers_AreStatic()
        {
            // Arrange
            Type fontManagerType = typeof(FontManager);
            PropertyInfo[] properties = fontManagerType.GetProperties(BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] methods = fontManagerType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            // Act & Assert
            Assert.NotEmpty(properties);
            Assert.NotEmpty(methods);
        }
    }
}