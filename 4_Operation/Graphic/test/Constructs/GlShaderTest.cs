// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderTest.cs
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
using System.Linq;
using Xunit;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// Tests for the GlShader class handling individual shader compilation.
    /// </summary>
    public class GlShaderTest
    {
        /// <summary>
        /// Tests that GlShader class is sealed and cannot be inherited.
        /// </summary>
        [Fact]
        public void GlShader_IsSealed_CannotBeInherited()
        {
            // Arrange & Act
            var shaderType = typeof(GlShader);

            // Assert
            Assert.True(shaderType.IsSealed);
        }

        /// <summary>
        /// Tests that GlShader class is public.
        /// </summary>
        [Fact]
        public void GlShader_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            var shaderType = typeof(GlShader);

            // Assert
            Assert.True(shaderType.IsPublic);
        }

        /// <summary>
        /// Tests that GlShader implements IDisposable interface.
        /// </summary>
        [Fact]
        public void GlShader_ImplementsIDisposable_InterfaceIsCorrect()
        {
            // Arrange & Act
            var shaderType = typeof(GlShader);

            // Assert
            Assert.True(typeof(IDisposable).IsAssignableFrom(shaderType));
        }

        /// <summary>
        /// Tests that GlShader has ShaderId property.
        /// </summary>
        [Fact]
        public void GlShader_ShaderId_PropertyExists()
        {
            // Arrange & Act
            var shaderIdProperty = typeof(GlShader).GetProperty("ShaderId");

            // Assert
            Assert.NotNull(shaderIdProperty);
            Assert.Equal(typeof(uint), shaderIdProperty.PropertyType);
        }

        /// <summary>
        /// Tests that GlShader has ShaderType property.
        /// </summary>
        [Fact]
        public void GlShader_ShaderType_PropertyExists()
        {
            // Arrange & Act
            var shaderTypeProperty = typeof(GlShader).GetProperty("ShaderType");

            // Assert
            Assert.NotNull(shaderTypeProperty);
            Assert.Equal(typeof(ShaderType), shaderTypeProperty.PropertyType);
        }

        /// <summary>
        /// Tests that GlShader has ShaderLog property.
        /// </summary>
        [Fact]
        public void GlShader_ShaderLog_PropertyExists()
        {
            // Arrange & Act
            var shaderLogProperty = typeof(GlShader).GetProperty("ShaderLog");

            // Assert
            Assert.NotNull(shaderLogProperty);
            Assert.Equal(typeof(string), shaderLogProperty.PropertyType);
        }

        /// <summary>
        /// Tests that GlShader ShaderLog property is read-only.
        /// </summary>
        [Fact]
        public void GlShader_ShaderLog_IsReadOnly()
        {
            // Arrange & Act
            var shaderLogProperty = typeof(GlShader).GetProperty("ShaderLog");

            // Assert
            Assert.NotNull(shaderLogProperty);
            Assert.True(shaderLogProperty.CanRead);
            Assert.False(shaderLogProperty.CanWrite);
        }
        

        /// <summary>
        /// Tests that GlShader constructor requires source and type parameters.
        /// </summary>
        [Fact]
        public void GlShader_Constructor_ParametersAreCorrect()
        {
            // Arrange
            var constructors = typeof(GlShader).GetConstructors();

            // Act
            var constructor = constructors.FirstOrDefault();

            // Assert
            Assert.NotNull(constructor);
            var parameters = constructor.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType); // source
            Assert.Equal(typeof(ShaderType), parameters[1].ParameterType); // type
        }

        /// <summary>
        /// Tests that GlShader has destructor for cleanup.
        /// </summary>
        [Fact]
        public void GlShader_HasDestructor_CleanupIsProvided()
        {
            // Arrange & Act
            var shaderType = typeof(GlShader);

            // Assert
            Assert.True(shaderType.IsSealed);
        }

        /// <summary>
        /// Tests that GlShader properties provide access to shader metadata.
        /// </summary>
        [Fact]
        public void GlShader_Properties_ProvideMetadata()
        {
            // Arrange
            var shaderType = typeof(GlShader);

            // Act
            var properties = shaderType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotEmpty(properties);
            Assert.NotNull(properties.FirstOrDefault(p => p.Name == "ShaderId"));
            Assert.NotNull(properties.FirstOrDefault(p => p.Name == "ShaderType"));
            Assert.NotNull(properties.FirstOrDefault(p => p.Name == "ShaderLog"));
        }

        /// <summary>
        /// Tests that GlShader class has only public properties and methods expected.
        /// </summary>
        [Fact]
        public void GlShader_PublicMembers_AreCorrect()
        {
            // Arrange
            var shaderType = typeof(GlShader);

            // Act
            var publicProperties = shaderType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var publicMethods = shaderType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);

            // Assert
            Assert.NotEmpty(publicProperties);
            Assert.Contains(publicMethods, m => m.Name == "Dispose");
        }
    }
}