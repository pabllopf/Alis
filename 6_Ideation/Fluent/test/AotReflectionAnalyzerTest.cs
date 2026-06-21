// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AotReflectionAnalyzerTest.cs
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
using System.Collections.Immutable;
using System.Linq;
using Alis.Core.Aspect.Fluent.Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Moq;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     Unit tests for the AotReflectionAnalyzer helper methods
    /// </summary>
    public class AotReflectionAnalyzerTest
    {
        #region IsReflectionType Tests

        /// <summary>
        ///     Tests that null type returns false
        /// </summary>
        [Fact]
        public void IsReflectionType_NullType_ReturnsFalse()
        {
            ITypeSymbol type = null;

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.TypeInfo is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemReflectionTypeInfo_ReturnsTrue()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.TypeInfo");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.Emit.AssemblyBuilder is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemReflectionEmitAssemblyBuilder_ReturnsTrue()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Emit.AssemblyBuilder");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.MethodBase is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemReflectionMethodBase_ReturnsTrue()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodBase");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Type is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemType_ReturnsTrue()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Type");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Object is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemObject_ReturnsFalse()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Object");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a custom class is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_CustomClass_ReturnsFalse()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Alis.Core.Aspect.Fluent.Generator.AotReflectionAnalyzer");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.String is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemString_ReturnsFalse()
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.String");

            bool result = AotReflectionAnalyzer.IsReflectionType(mock.Object);

            Assert.False(result);
        }

        #endregion

        #region IsEmitApi Tests

        /// <summary>
        ///     Tests that System.Reflection.Emit.DynamicMethod.DefineDynamicMethod is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_DynamicMethod_DefineDynamicMethod_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Emit.DynamicMethod");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("DefineDynamicMethod");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_AssemblyBuilder_DefineDynamicAssembly_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Emit.AssemblyBuilder");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("DefineDynamicAssembly");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.Emit.ModuleBuilder.DefineMethod is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_ModuleBuilder_DefineMethod_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Emit.ModuleBuilder");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("DefineMethod");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that a method with GetILGenerator in name is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_GetILGenerator_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Emit.ILGenerator");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("GetILGenerator");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that a method with Emit in name is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_Emit_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Emit.OpCode");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("Emit");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.MethodBase.Invoke is not detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_MethodInfo_Invoke_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("Invoke");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_Object_ToString_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Object");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("ToString");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsEmitApi_NullContainingType_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            mock.Setup(m => m.ContainingType).Returns((INamedTypeSymbol)null);
            mock.Setup(m => m.Name).Returns("SomeMethod");

            bool result = AotReflectionAnalyzer.IsEmitApi(mock.Object);

            Assert.False(result);
        }

        #endregion

        #region IsInvokeApi Tests

        /// <summary>
        ///     Tests that MethodInfo.Invoke is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_Invoke_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("Invoke");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.GetValue is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_GetValue_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("GetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.SetValue is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_SetValue_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("SetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.InvokeMember is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_InvokeMember_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("InvokeMember");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MemberInfo.Invoke is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MemberInfo_Invoke_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MemberInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("Invoke");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that PropertyInfo.Invoke is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_PropertyInfo_Invoke_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.PropertyInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("GetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.GetHashCode is not detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_GetHashCode_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.MethodInfo");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("GetHashCode");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_Object_ToString_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Object");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("ToString");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsInvokeApi_NullContainingType_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            mock.Setup(m => m.ContainingType).Returns((INamedTypeSymbol)null);
            mock.Setup(m => m.Name).Returns("SomeMethod");

            bool result = AotReflectionAnalyzer.IsInvokeApi(mock.Object);

            Assert.False(result);
        }

        #endregion

        #region IsActivatorApi Tests

        /// <summary>
        ///     Tests that Activator.CreateInstance is detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_CreateInstance_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Activator");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("CreateInstance");

            bool result = AotReflectionAnalyzer.IsActivatorApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.CreateInstanceFrom is detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_CreateInstanceFrom_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Activator");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("CreateInstanceFrom");

            bool result = AotReflectionAnalyzer.IsActivatorApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.CreateInstanceUnwrapped is detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_CreateInstanceUnwrapped_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Activator");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("CreateInstanceUnwrapped");

            bool result = AotReflectionAnalyzer.IsActivatorApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.GetHashCode is not detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_GetHashCode_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Activator");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("GetHashCode");

            bool result = AotReflectionAnalyzer.IsActivatorApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Object_ToString_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Object");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("ToString");

            bool result = AotReflectionAnalyzer.IsActivatorApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsActivatorApi_NullContainingType_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            mock.Setup(m => m.ContainingType).Returns((INamedTypeSymbol)null);
            mock.Setup(m => m.Name).Returns("SomeMethod");

            bool result = AotReflectionAnalyzer.IsActivatorApi(mock.Object);

            Assert.False(result);
        }

        #endregion

        #region IsTypeGetTypeApi Tests

        /// <summary>
        ///     Tests that Type.GetType is detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Type_GetType_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Type");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("GetType");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Assembly.Load is detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Assembly_Load_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Assembly");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("Load");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Assembly.LoadFrom is detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Assembly_LoadFrom_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Reflection.Assembly");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("LoadFrom");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Type.FullName is not detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Type_FullName_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Type");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("FullName");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Object_ToString_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Object");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("ToString");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_NullContainingType_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            mock.Setup(m => m.ContainingType).Returns((INamedTypeSymbol)null);
            mock.Setup(m => m.Name).Returns("SomeMethod");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(mock.Object);

            Assert.False(result);
        }

        #endregion

        #region IsKnownSerializer Tests

        /// <summary>
        ///     Tests that BinaryFormatter is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_BinaryFormatter_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Runtime.Serialization.Formatters.Binary.BinaryFormatter");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);

            bool result = AotReflectionAnalyzer.IsKnownSerializer(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Newtonsoft.Json.JsonConvert is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_JsonConvert_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Newtonsoft.Json.JsonConvert");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);

            bool result = AotReflectionAnalyzer.IsKnownSerializer(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Text.Json.JsonSerializer is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_JsonSerializer_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Text.Json.JsonSerializer");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);

            bool result = AotReflectionAnalyzer.IsKnownSerializer(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that XmlSerializer is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_XmlSerializer_ReturnsTrue()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Xml.Serialization.XmlSerializer");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);

            bool result = AotReflectionAnalyzer.IsKnownSerializer(mock.Object);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_Object_ToString_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.Object");
            mock.Setup(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns("ToString");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(mock.Object);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsKnownSerializer_NullContainingType_ReturnsFalse()
        {
            Mock<IMethodSymbol> mock = new();
            mock.Setup(m => m.ContainingType).Returns((INamedTypeSymbol)null);
            mock.Setup(m => m.Name).Returns("SomeMethod");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(mock.Object);

            Assert.False(result);
        }

        #endregion

        #region SupportedDiagnostics Tests

        /// <summary>
        ///     Tests that SupportedDiagnostics returns all expected diagnostic descriptors
        /// </summary>
        [Fact]
        public void SupportedDiagnostics_ReturnsAllRules()
        {
            AotReflectionAnalyzer analyzer = new();

            var diagnostics = analyzer.SupportedDiagnostics;

            Assert.NotNull(diagnostics);
            Assert.Equal(10, diagnostics.Length);
        }

        /// <summary>
        ///     Tests that SupportedDiagnostics is not empty
        /// </summary>
        [Fact]
        public void SupportedDiagnostics_IsNotEmpty()
        {
            AotReflectionAnalyzer analyzer = new();

            var diagnostics = analyzer.SupportedDiagnostics;

            Assert.NotEmpty(diagnostics);
        }

        #endregion

        #region DiagnosticId Constants Tests

        /// <summary>
        ///     Tests that all diagnostic ID constants have expected values
        /// </summary>
        [Fact]
        public void DiagnosticIdConstants_HaveExpectedValues()
        {
            Assert.Equal("ALIS001", AotReflectionAnalyzer.IdReflectionApi);
            Assert.Equal("ALIS002", AotReflectionAnalyzer.IdEmitApi);
            Assert.Equal("ALIS003", AotReflectionAnalyzer.IdInvokeApi);
            Assert.Equal("ALIS004", AotReflectionAnalyzer.IdActivatorApi);
            Assert.Equal("ALIS005", AotReflectionAnalyzer.IdTypeGetType);
            Assert.Equal("ALIS006", AotReflectionAnalyzer.IdDynamic);
            Assert.Equal("ALIS007", AotReflectionAnalyzer.IdSerialization);
            Assert.Equal("ALIS008", AotReflectionAnalyzer.IdExpressionCompile);
            Assert.Equal("ALIS009", AotReflectionAnalyzer.IdRuntimeHelpers);
            Assert.Equal("ALIS010", AotReflectionAnalyzer.IdUnknownReflection);
        }

        /// <summary>
        ///     Tests that all diagnostic IDs are unique
        /// </summary>
        [Fact]
        public void DiagnosticIdConstants_AreAllUnique()
        {
            var ids = new[]
            {
                AotReflectionAnalyzer.IdReflectionApi,
                AotReflectionAnalyzer.IdEmitApi,
                AotReflectionAnalyzer.IdInvokeApi,
                AotReflectionAnalyzer.IdActivatorApi,
                AotReflectionAnalyzer.IdTypeGetType,
                AotReflectionAnalyzer.IdDynamic,
                AotReflectionAnalyzer.IdSerialization,
                AotReflectionAnalyzer.IdExpressionCompile,
                AotReflectionAnalyzer.IdRuntimeHelpers,
                AotReflectionAnalyzer.IdUnknownReflection
            };

            var distinct = ids.Distinct();

            Assert.Equal(ids.Length, distinct.Count());
        }

        #endregion

        #region Analyzer Integration Tests

        /// <summary>
        ///     Tests that the analyzer detects MethodInfo.Invoke and reports ALIS003 (InvokeApiRule)
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_MethodInfoInvoke_ReportsInvokeApiDiagnostic()
        {
            const string code = @"
using System.Reflection;
public class TestClass
{
    public void TestMethod()
    {
        var method = typeof(string).GetMethod(""Length"");
        method.Invoke(""hello"", null);
    }
}";

            var diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdInvokeApi);
        }

        /// <summary>
        ///     Tests that the analyzer detects Activator.CreateInstance and reports ALIS004 (ActivatorRule)
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_ActivatorCreateInstance_ReportsActivatorDiagnostic()
        {
            const string code = @"
public class TestClass
{
    public void TestMethod()
    {
        System.Activator.CreateInstance(typeof(string));
    }
}";

            var diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdActivatorApi);
        }

        /// <summary>
        ///     Tests that the analyzer detects Expression.Compile and reports ALIS008 (ExpressionCompileRule)
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_ExpressionCompile_ReportsExpressionCompileDiagnostic()
        {
            const string code = @"
using System.Linq.Expressions;
public class TestClass
{
    public void TestMethod()
    {
        Expression<System.Func<int, int>> expr = x => x + 1;
        expr.Compile();
    }
}";

            var diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdExpressionCompile);
        }

        /// <summary>
        ///     Tests that the analyzer detects Type.GetType and reports ALIS005 (TypeGetTypeRule)
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_TypeGetType_ReportsTypeGetTypeDiagnostic()
        {
            const string code = @"
public class TestClass
{
    public void TestMethod()
    {
        var t = System.Type.GetType(""System.String"");
    }
}";

            var diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdTypeGetType);
        }

        /// <summary>
        ///     Tests that the analyzer does NOT report diagnostics for safe code
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_SafeCode_NoDiagnosticReported()
        {
            const string code = @"
using System;
public class TestClass
{
    public int TestMethod(int x, int y)
    {
        return x + y;
    }
}";

            var diagnostics = RunAnalyzer(code);

            Assert.DoesNotContain(diagnostics, d => d.Id.StartsWith("ALIS"));
        }

        /// <summary>
        ///     Tests that the analyzer detects ConstructorInfo.Invoke and reports ALIS003
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_ConstructorInfoInvoke_ReportsInvokeApiDiagnostic()
        {
            const string code = @"
using System.Reflection;
public class TestClass
{
    public void TestMethod()
    {
        var ctor = typeof(string).GetConstructors()[0];
        ctor.Invoke(new object[] { ""a"", ""b"" });
    }
}";

            var diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdInvokeApi);
        }

        /// <summary>
        ///     Runs the AotReflectionAnalyzer on the given source code and returns diagnostics
        /// </summary>
        private static ImmutableArray<Diagnostic> RunAnalyzer(string sourceCode)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            var refPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var systemRuntime = MetadataReference.CreateFromFile(Path.Combine(refPath!, "System.Runtime.dll"));
            var systemConsole = MetadataReference.CreateFromFile(Path.Combine(refPath!, "System.Console.dll"));
            var systemLinqExpressions = MetadataReference.CreateFromFile(typeof(System.Linq.Expressions.Expression).Assembly.Location);

            var compilation = CSharpCompilation.Create(
                "TestAssembly",
                new[] { syntaxTree },
                new[] { systemRuntime, systemConsole, systemLinqExpressions },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var analyzer = new AotReflectionAnalyzer();
            var compilationWithAnalyzers = compilation.WithAnalyzers(ImmutableArray.Create<DiagnosticAnalyzer>(analyzer));

            return compilationWithAnalyzers.GetAllDiagnosticsAsync().GetAwaiter().GetResult();
        }

        #endregion
    }
}
