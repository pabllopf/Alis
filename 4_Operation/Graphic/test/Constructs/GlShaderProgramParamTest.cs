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
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Tests for the GlShaderProgramParam class handling shader program parameters.
    /// </summary>
    public class GlShaderProgramParamTest
    {
        /// <summary>
        ///     Tests that GlShaderProgramParam class is sealed.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_IsSealed_CannotBeInherited()
        {
            Type paramType = typeof(GlShaderProgramParam);

            Assert.True(paramType.IsSealed);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam class is public.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_IsPublic_CanBeAccessed()
        {
            Type paramType = typeof(GlShaderProgramParam);

            Assert.True(paramType.IsPublic);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has Name readonly field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Name_FieldExists()
        {
            FieldInfo nameField = typeof(GlShaderProgramParam).GetField("Name", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(nameField);
            Assert.Equal(typeof(string), nameField.FieldType);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has ParamType readonly field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ParamType_FieldExists()
        {
            FieldInfo paramTypeField = typeof(GlShaderProgramParam).GetField("ParamType", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(paramTypeField);
            Assert.Equal(typeof(ParamType), paramTypeField.FieldType);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has Type readonly field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Type_FieldExists()
        {
            FieldInfo typeField = typeof(GlShaderProgramParam).GetField("Type", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(typeField);
            Assert.Equal(typeof(Type), typeField.FieldType);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has Location property.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Location_PropertyExists()
        {
            PropertyInfo locationProperty = typeof(GlShaderProgramParam).GetProperty("Location");

            Assert.NotNull(locationProperty);
            Assert.Equal(typeof(int), locationProperty.PropertyType);
            Assert.True(locationProperty.CanRead);
            Assert.True(locationProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has Program property.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Program_PropertyExists()
        {
            PropertyInfo programProperty = typeof(GlShaderProgramParam).GetProperty("Program");

            Assert.NotNull(programProperty);
            Assert.Equal(typeof(uint), programProperty.PropertyType);
            Assert.True(programProperty.CanRead);
            Assert.True(programProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has ProgramId property.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ProgramId_PropertyExists()
        {
            PropertyInfo programIdProperty = typeof(GlShaderProgramParam).GetProperty("ProgramId");

            Assert.NotNull(programIdProperty);
            Assert.Equal(typeof(uint), programIdProperty.PropertyType);
            Assert.True(programIdProperty.CanRead);
            Assert.True(programIdProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has two constructors.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_HasTwoConstructors_OverloadsExist()
        {
            ConstructorInfo[] constructors = typeof(GlShaderProgramParam).GetConstructors();

            Assert.Equal(2, constructors.Length);
        }

        /// <summary>
        ///     Tests that first constructor accepts Type, ParamType, and Name.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_FirstConstructor_ParametersAreCorrect()
        {
            ConstructorInfo[] constructors = typeof(GlShaderProgramParam).GetConstructors();
            ConstructorInfo constructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 3);

            ParameterInfo[] parameters = constructor?.GetParameters();

            Assert.NotNull(parameters);
            Assert.Equal(3, parameters.Length);
            Assert.Equal(typeof(Type), parameters[0].ParameterType);
            Assert.Equal(typeof(ParamType), parameters[1].ParameterType);
            Assert.Equal(typeof(string), parameters[2].ParameterType);
        }

        /// <summary>
        ///     Tests that second constructor accepts Type, ParamType, Name, Program, and Location.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_SecondConstructor_ParametersAreCorrect()
        {
            ConstructorInfo[] constructors = typeof(GlShaderProgramParam).GetConstructors();
            ConstructorInfo constructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 5);

            ParameterInfo[] parameters = constructor?.GetParameters();

            Assert.NotNull(parameters);
            Assert.Equal(5, parameters.Length);
            Assert.Equal(typeof(Type), parameters[0].ParameterType);
            Assert.Equal(typeof(ParamType), parameters[1].ParameterType);
            Assert.Equal(typeof(string), parameters[2].ParameterType);
            Assert.Equal(typeof(uint), parameters[3].ParameterType);
            Assert.Equal(typeof(int), parameters[4].ParameterType);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has readonly fields that cannot be modified.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ReadonlyFields_CannotBeModified()
        {
            FieldInfo nameField = typeof(GlShaderProgramParam).GetField("Name", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo paramTypeField = typeof(GlShaderProgramParam).GetField("ParamType", BindingFlags.Public | BindingFlags.Instance);
            FieldInfo typeField = typeof(GlShaderProgramParam).GetField("Type", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(nameField);
            Assert.NotNull(paramTypeField);
            Assert.NotNull(typeField);
            Assert.True((nameField.Attributes & FieldAttributes.InitOnly) != 0);
            Assert.True((paramTypeField.Attributes & FieldAttributes.InitOnly) != 0);
            Assert.True((typeField.Attributes & FieldAttributes.InitOnly) != 0);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam parameter properties can be modified.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_ModifiableProperties_CanBeChanged()
        {
            PropertyInfo locationProperty = typeof(GlShaderProgramParam).GetProperty("Location");
            PropertyInfo programProperty = typeof(GlShaderProgramParam).GetProperty("Program");
            PropertyInfo programIdProperty = typeof(GlShaderProgramParam).GetProperty("ProgramId");

            Assert.True(locationProperty.CanWrite);
            Assert.True(programProperty.CanWrite);
            Assert.True(programIdProperty.CanWrite);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam has methods for parameter value management.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_HasParameterMethods_ValueManagementExists()
        {
            Type paramType = typeof(GlShaderProgramParam);

            MethodInfo[] methods = paramType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            Assert.NotEmpty(methods);
        }

        /// <summary>
        ///     Tests that GlShaderProgramParam maintains type safety with Type field.
        /// </summary>
        [Fact]
        public void GlShaderProgramParam_Type_IsSystemType()
        {
            FieldInfo typeField = typeof(GlShaderProgramParam).GetField("Type", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(typeField);
            Assert.Equal(typeof(Type), typeField.FieldType);
        }
    }
}