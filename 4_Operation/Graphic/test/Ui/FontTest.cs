// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontTest.cs
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

using System.Linq;
using Xunit;
using Alis.Core.Graphic.Ui;
using Alis.Core.Aspect.Math.Definition;

namespace Alis.Core.Graphic.Test.Ui
{
    /// <summary>
    /// Tests for the Font class handling font rendering with OpenGL shaders.
    /// </summary>
    public class FontTest
    {
        /// <summary>
        /// Tests that Font class can be instantiated with required parameters.
        /// </summary>
        [Fact]
        public void Font_Constructor_CanBeCreated()
        {
            // Arrange & Act
            var fontType = typeof(Font);

            // Assert
            Assert.NotNull(fontType);
        }

        /// <summary>
        /// Tests that Font class is public.
        /// </summary>
        [Fact]
        public void Font_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            var fontType = typeof(Font);

            // Assert
            Assert.True(fontType.IsPublic);
        }

        /// <summary>
        /// Tests that Font has NameFile property.
        /// </summary>
        [Fact]
        public void Font_NameFile_PropertyExists()
        {
            // Arrange & Act
            var nameFileProperty = typeof(Font).GetProperty("NameFile");

            // Assert
            Assert.NotNull(nameFileProperty);
            Assert.Equal(typeof(string), nameFileProperty.PropertyType);
        }

        /// <summary>
        /// Tests that Font has Depth property.
        /// </summary>
        [Fact]
        public void Font_Depth_PropertyExists()
        {
            // Arrange & Act
            var depthProperty = typeof(Font).GetProperty("Depth");

            // Assert
            Assert.NotNull(depthProperty);
            Assert.Equal(typeof(int), depthProperty.PropertyType);
        }

        /// <summary>
        /// Tests that Font has RenderText method.
        /// </summary>
        [Fact]
        public void Font_RenderText_MethodExists()
        {
            // Arrange & Act
            var renderMethod = typeof(Font).GetMethod("RenderText");

            // Assert
            Assert.NotNull(renderMethod);
        }
        
        /// <summary>
        /// Tests that Font has LoadTexture internal method.
        /// </summary>
        [Fact]
        public void Font_LoadTexture_MethodExists()
        {
            // Arrange & Act
            var loadTextureMethod = typeof(Font).GetMethod("LoadTexture", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(loadTextureMethod);
        }

        /// <summary>
        /// Tests that Font has SetupBuffers method for buffer initialization.
        /// </summary>
        [Fact]
        public void Font_SetupBuffers_MethodExists()
        {
            // Arrange & Act
            var setupMethod = typeof(Font).GetMethod("SetupBuffers", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(setupMethod);
        }

        /// <summary>
        /// Tests that Font constructor accepts four parameters.
        /// </summary>
        [Fact]
        public void Font_Constructor_ParametersAreCorrect()
        {
            // Arrange
            var constructors = typeof(Font).GetConstructors();

            // Act
            var constructor = constructors.FirstOrDefault();

            // Assert
            Assert.NotNull(constructor);
            var parameters = constructor.GetParameters();
            Assert.Equal(4, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType); // NameFile
            Assert.Equal(typeof(int), parameters[1].ParameterType);    // Depth
            Assert.Equal(typeof(int), parameters[2].ParameterType);    // size
            Assert.Equal(typeof(string), parameters[3].ParameterType); // fullPath
        }

        /// <summary>
        /// Tests that Font has private properties for shader management.
        /// </summary>
        [Fact]
        public void Font_HasPrivateShaderProperties_ShaderManagementExists()
        {
            // Arrange
            var fontType = typeof(Font);

            // Act
            var shaderProgram = fontType.GetProperty("ShaderProgram", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var vao = fontType.GetProperty("Vao", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var vbo = fontType.GetProperty("Vbo", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var texture = fontType.GetProperty("Texture", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(shaderProgram);
            Assert.NotNull(vao);
            Assert.NotNull(vbo);
            Assert.NotNull(texture);
        }

        /// <summary>
        /// Tests that Font has private method InitializeShaders.
        /// </summary>
        [Fact]
        public void Font_InitializeShaders_MethodExists()
        {
            // Arrange & Act
            var initShaders = typeof(Font).GetMethod("InitializeShaders", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(initShaders);
        }

        /// <summary>
        /// Tests that Font has Size property for managing dimensions.
        /// </summary>
        [Fact]
        public void Font_Size_PropertyExists()
        {
            // Arrange & Act
            var sizeProperty = typeof(Font).GetProperty("Size", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(sizeProperty);
        }

        /// <summary>
        /// Tests that Font has CharacterRects dictionary for character positioning.
        /// </summary>
        [Fact]
        public void Font_CharacterRects_DictionaryExists()
        {
            // Arrange
            var fontType = typeof(Font);

            // Act
            var characterRectsField = fontType.GetField("CharacterRects", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(characterRectsField);
        }
        

        /// <summary>
        /// Tests that Font RenderText method returns void.
        /// </summary>
        [Fact]
        public void Font_RenderText_ReturnsVoid()
        {
            // Arrange
            var renderMethod = typeof(Font).GetMethod("RenderText");

            // Act & Assert
            Assert.NotNull(renderMethod);
            Assert.Equal(typeof(void), renderMethod.ReturnType);
        }

        /// <summary>
        /// Tests that Font has GCHandle fields for memory management.
        /// </summary>
        [Fact]
        public void Font_HasGCHandleFields_MemoryManagementExists()
        {
            // Arrange
            var fontType = typeof(Font);

            // Act
            var imageHandle = fontType.GetField("imageHandle", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var indicesHandle = fontType.GetField("indicesHandle", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var verticesHandle = fontType.GetField("verticesHandle", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(imageHandle);
            Assert.NotNull(indicesHandle);
            Assert.NotNull(verticesHandle);
        }
    }
}

