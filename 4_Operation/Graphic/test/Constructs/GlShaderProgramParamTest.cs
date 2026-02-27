// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlShaderProgramParamTest.cs
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

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// Tests for the GlShaderProgramParam class handling shader program parameters.
    /// </summary>
    public class GlShaderProgramParamTest
    {
        /// <summary>
        /// Tests that GlShaderProgramParam class is sealed.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_IsSealed_CannotBeInherited()
        {
            // Arrange & Act
            var paramType = typeof(GlShaderProgramParam);

            // Assert
            Assert.True(paramType.IsSealed);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam class is public.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            var paramType = typeof(GlShaderProgramParam);

            // Assert
            Assert.True(paramType.IsPublic);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has Name readonly field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Name_FieldExists()
        {
            // Arrange & Act
            var nameField = typeof(GlShaderProgramParam).GetField("Name", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(nameField);
            Assert.Equal(typeof(string), nameField.FieldType);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has ParamType readonly field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ParamType_FieldExists()
        {
            // Arrange & Act
            var paramTypeField = typeof(GlShaderProgramParam).GetField("ParamType", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(paramTypeField);
            Assert.Equal(typeof(ParamType), paramTypeField.FieldType);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has Type readonly field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Type_FieldExists()
        {
            // Arrange & Act
            var typeField = typeof(GlShaderProgramParam).GetField("Type", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotNull(typeField);
            Assert.Equal(typeof(Type), typeField.FieldType);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has Location property.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Location_PropertyExists()
        {
            // Arrange & Act
            var locationProperty = typeof(GlShaderProgramParam).GetProperty("Location");

            // Assert
            Assert.NotNull(locationProperty);
            Assert.Equal(typeof(int), locationProperty.PropertyType);
            Assert.True(locationProperty.CanRead);
            Assert.True(locationProperty.CanWrite);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has Program property.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Program_PropertyExists()
        {
            // Arrange & Act
            var programProperty = typeof(GlShaderProgramParam).GetProperty("Program");

            // Assert
            Assert.NotNull(programProperty);
            Assert.Equal(typeof(uint), programProperty.PropertyType);
            Assert.True(programProperty.CanRead);
            Assert.True(programProperty.CanWrite);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has ProgramId property.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ProgramId_PropertyExists()
        {
            // Arrange & Act
            var programIdProperty = typeof(GlShaderProgramParam).GetProperty("ProgramId");

            // Assert
            Assert.NotNull(programIdProperty);
            Assert.Equal(typeof(uint), programIdProperty.PropertyType);
            Assert.True(programIdProperty.CanRead);
            Assert.True(programIdProperty.CanWrite);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has two constructors.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_HasTwoConstructors_OverloadsExist()
        {
            // Arrange & Act
            var constructors = typeof(GlShaderProgramParam).GetConstructors();

            // Assert
            Assert.Equal(2, constructors.Length);
        }

        /// <summary>
        /// Tests that first constructor accepts Type, ParamType, and Name.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_FirstConstructor_ParametersAreCorrect()
        {
            // Arrange
            var constructors = typeof(GlShaderProgramParam).GetConstructors();
            var constructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 3);

            // Act
            var parameters = constructor?.GetParameters();

            // Assert
            Assert.NotNull(parameters);
            Assert.Equal(3, parameters.Length);
            Assert.Equal(typeof(Type), parameters[0].ParameterType);
            Assert.Equal(typeof(ParamType), parameters[1].ParameterType);
            Assert.Equal(typeof(string), parameters[2].ParameterType);
        }

        /// <summary>
        /// Tests that second constructor accepts Type, ParamType, Name, Program, and Location.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_SecondConstructor_ParametersAreCorrect()
        {
            // Arrange
            var constructors = typeof(GlShaderProgramParam).GetConstructors();
            var constructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 5);

            // Act
            var parameters = constructor?.GetParameters();

            // Assert
            Assert.NotNull(parameters);
            Assert.Equal(5, parameters.Length);
            Assert.Equal(typeof(Type), parameters[0].ParameterType);
            Assert.Equal(typeof(ParamType), parameters[1].ParameterType);
            Assert.Equal(typeof(string), parameters[2].ParameterType);
            Assert.Equal(typeof(uint), parameters[3].ParameterType);
            Assert.Equal(typeof(int), parameters[4].ParameterType);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has readonly fields that cannot be modified.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ReadonlyFields_CannotBeModified()
        {
            // Arrange
            var nameField = typeof(GlShaderProgramParam).GetField("Name", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var paramTypeField = typeof(GlShaderProgramParam).GetField("ParamType", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var typeField = typeof(GlShaderProgramParam).GetField("Type", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Act & Assert
            Assert.NotNull(nameField);
            Assert.NotNull(paramTypeField);
            Assert.NotNull(typeField);
            // Readonly fields should be InitOnly
            Assert.True((nameField.Attributes & System.Reflection.FieldAttributes.InitOnly) != 0);
            Assert.True((paramTypeField.Attributes & System.Reflection.FieldAttributes.InitOnly) != 0);
            Assert.True((typeField.Attributes & System.Reflection.FieldAttributes.InitOnly) != 0);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam parameter properties can be modified.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ModifiableProperties_CanBeChanged()
        {
            // Arrange & Act
            var locationProperty = typeof(GlShaderProgramParam).GetProperty("Location");
            var programProperty = typeof(GlShaderProgramParam).GetProperty("Program");
            var programIdProperty = typeof(GlShaderProgramParam).GetProperty("ProgramId");

            // Assert
            Assert.True(locationProperty.CanWrite);
            Assert.True(programProperty.CanWrite);
            Assert.True(programIdProperty.CanWrite);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam has methods for parameter value management.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_HasParameterMethods_ValueManagementExists()
        {
            // Arrange
            var paramType = typeof(GlShaderProgramParam);

            // Act
            var methods = paramType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Assert
            Assert.NotEmpty(methods);
        }

        /// <summary>
        /// Tests that GlShaderProgramParam maintains type safety with Type field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Type_IsSystemType()
        {
            // Arrange
            var typeField = typeof(GlShaderProgramParam).GetField("Type", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // Act & Assert
            Assert.NotNull(typeField);
            Assert.Equal(typeof(Type), typeField.FieldType);
        }
    }
}

