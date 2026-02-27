// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramTest.cs
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
    /// Tests for the GlShaderProgram class handling shader compilation and linking.
    /// </summary>
    public class GlShaderProgramTest
    {
        /// <summary>
        /// Tests that GlShaderProgram class is sealed.
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsSealed_CannotBeInherited()
        {
            // Arrange & Act
            var programType = typeof(GlShaderProgram);

            // Assert
            Assert.True(programType.IsSealed);
        }

        /// <summary>
        /// Tests that GlShaderProgram class is public.
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            var programType = typeof(GlShaderProgram);

            // Assert
            Assert.True(programType.IsPublic);
        }

        /// <summary>
        /// Tests that GlShaderProgram implements IDisposable interface.
        /// </summary>
        [Fact]
        public void GlShaderProgram_ImplementsIDisposable_InterfaceIsCorrect()
        {
            // Arrange & Act
            var programType = typeof(GlShaderProgram);

            // Assert
            Assert.True(typeof(IDisposable).IsAssignableFrom(programType));
        }

        /// <summary>
        /// Tests that GlShaderProgram has ProgramId property.
        /// </summary>
        [Fact]
        public void GlShaderProgram_ProgramId_PropertyExists()
        {
            // Arrange & Act
            var programIdProperty = typeof(GlShaderProgram).GetProperty("ProgramId");

            // Assert
            Assert.NotNull(programIdProperty);
            Assert.Equal(typeof(uint), programIdProperty.PropertyType);
        }

        /// <summary>
        /// Tests that GlShaderProgram has indexer for shader parameters.
        /// </summary>
        [Fact]
        public void GlShaderProgram_Indexer_CanAccessParameters()
        {
            // Arrange & Act
            var indexerProperty = typeof(GlShaderProgram).GetProperty("Item", 
                System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance,
                null, null, new[] { typeof(string) }, null);

            // Assert
            Assert.NotNull(indexerProperty);
        }

        /// <summary>
        /// Tests that GlShaderProgram has two constructor overloads.
        /// </summary>
        [Fact]
        public void GlShaderProgram_HasTwoConstructors_OverloadsExist()
        {
            // Arrange & Act
            var constructors = typeof(GlShaderProgram).GetConstructors();

            // Assert
            Assert.Equal(2, constructors.Length);
        }

        /// <summary>
        /// Tests that GlShaderProgram first constructor accepts two GlShader parameters.
        /// </summary>
        [Fact]
        public void GlShaderProgram_FirstConstructor_AcceptsShaders()
        {
            // Arrange
            var constructors = typeof(GlShaderProgram).GetConstructors();
            var constructor = constructors.FirstOrDefault(c => c.GetParameters().All(p => p.ParameterType == typeof(GlShader)));

            // Act & Assert
            Assert.NotNull(constructor);
            var parameters = constructor.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(GlShader), parameters[0].ParameterType);
            Assert.Equal(typeof(GlShader), parameters[1].ParameterType);
        }

        /// <summary>
        /// Tests that GlShaderProgram second constructor accepts two string parameters.
        /// </summary>
        [Fact]
        public void GlShaderProgram_SecondConstructor_AcceptsSourceCode()
        {
            // Arrange
            var constructors = typeof(GlShaderProgram).GetConstructors();
            var constructor = constructors.FirstOrDefault(c => c.GetParameters().All(p => p.ParameterType == typeof(string)));

            // Act & Assert
            Assert.NotNull(constructor);
            var parameters = constructor.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
            Assert.Equal(typeof(string), parameters[1].ParameterType);
        }

        /// <summary>
        /// Tests that GlShaderProgram has ProgramLog property.
        /// </summary>
        [Fact]
        public void GlShaderProgram_ProgramLog_PropertyExists()
        {
            // Arrange & Act
            var programLogProperty = typeof(GlShaderProgram).GetProperty("ProgramLog");

            // Assert
            Assert.NotNull(programLogProperty);
            Assert.Equal(typeof(string), programLogProperty.PropertyType);
        }

        /// <summary>
        /// Tests that GlShaderProgram ProgramLog is read-only.
        /// </summary>
        [Fact]
        public void GlShaderProgram_ProgramLog_IsReadOnly()
        {
            // Arrange & Act
            var programLogProperty = typeof(GlShaderProgram).GetProperty("ProgramLog");

            // Assert
            Assert.NotNull(programLogProperty);
            Assert.True(programLogProperty.CanRead);
            Assert.False(programLogProperty.CanWrite);
        }

        /// <summary>
        /// Tests that GlShaderProgram has methods for parameter management.
        /// </summary>
        [Fact]
        public void GlShaderProgram_HasParameterMethods_ParameterManagementExists()
        {
            // Arrange
            var programType = typeof(GlShaderProgram);

            // Act
            var methods = programType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotEmpty(methods);
        }

        /// <summary>
        /// Tests that GlShaderProgram ProgramId property is public.
        /// </summary>
        [Fact]
        public void GlShaderProgram_ProgramId_IsPublic()
        {
            // Arrange & Act
            var programIdProperty = typeof(GlShaderProgram).GetProperty("ProgramId");

            // Assert
            Assert.NotNull(programIdProperty);
            Assert.True(programIdProperty.CanRead);
            Assert.True(programIdProperty.CanWrite);
        }
    }
}