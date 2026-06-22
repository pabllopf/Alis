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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Alis.Core.Aspect.Fluent.Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Moq;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     Helper to create mock ITypeSymbol with a display string
    /// </summary>
    static class MockTypeSymbolFactory
    {
        /// <summary>
        ///     Creates a mock ITypeSymbol with the specified display string
        /// </summary>
        /// <param name="displayString">The display string</param>
        /// <returns>The mock ITypeSymbol</returns>
        public static ITypeSymbol Create(string displayString)
        {
            Mock<ITypeSymbol> mock = new();
            mock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns(displayString);
            return mock.Object;
        }
    }

    /// <summary>
    ///     Helper to create mock IMethodSymbol with containing type and name
    /// </summary>
    static class MockMethodSymbolFactory
    {
        /// <summary>
        ///     Creates a mock IMethodSymbol with the specified containing type display string and method name
        /// </summary>
        /// <param name="containingType">The containing type display string</param>
        /// <param name="methodName">The method name</param>
        /// <returns>The mock IMethodSymbol</returns>
        public static IMethodSymbol Create(string containingType, string methodName)
        {
            Mock<IMethodSymbol> mock = new();
            Mock<INamedTypeSymbol> typeMock = new();
            typeMock.Setup(t => t.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns(containingType);
            mock.SetupGet(m => m.ContainingType).Returns(typeMock.Object);
            mock.Setup(m => m.Name).Returns(methodName);
            return mock.Object;
        }

        /// <summary>
        ///     Creates a mock IMethodSymbol with null containing type and the specified method name
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <returns>The mock IMethodSymbol</returns>
        public static IMethodSymbol CreateNullContainingType(string methodName)
        {
            Mock<IMethodSymbol> mock = new();
            mock.SetupGet(m => m.ContainingType).Returns((INamedTypeSymbol)null);
            mock.Setup(m => m.Name).Returns(methodName);
            return mock.Object;
        }
    }

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
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.Reflection.TypeInfo");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.Emit.AssemblyBuilder is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemReflectionEmitAssemblyBuilder_ReturnsTrue()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.Reflection.Emit.AssemblyBuilder");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.MethodBase is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemReflectionMethodBase_ReturnsTrue()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.Reflection.MethodBase");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Type is detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemType_ReturnsTrue()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.Type");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Object is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemObject_ReturnsFalse()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.Object");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that a custom class is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_CustomClass_ReturnsFalse()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("Alis.Core.Aspect.Fluent.Generator.AotReflectionAnalyzer");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.String is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemString_ReturnsFalse()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.String");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Int32 is not detected as reflection type
        /// </summary>
        [Fact]
        public void IsReflectionType_SystemInt32_ReturnsFalse()
        {
            ITypeSymbol type = MockTypeSymbolFactory.Create("System.Int32");

            bool result = AotReflectionAnalyzer.IsReflectionType(type);

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
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Emit.DynamicMethod", "DefineDynamicMethod");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_AssemblyBuilder_DefineDynamicAssembly_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Emit.AssemblyBuilder", "DefineDynamicAssembly");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.Emit.ModuleBuilder.DefineMethod is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_ModuleBuilder_DefineMethod_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Emit.ModuleBuilder", "DefineMethod");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that a method with GetILGenerator in name is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_GetILGenerator_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Emit.ILGenerator", "GetILGenerator");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that a method with Emit in name is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_Emit_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Emit.OpCode", "Emit");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.MethodInfo.Invoke is not detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_MethodInfo_Invoke_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "Invoke");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_Object_ToString_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Object", "ToString");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsEmitApi_NullContainingType_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.CreateNullContainingType("SomeMethod");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Reflection.AssemblyBuilder.GetDefinedTypes is detected as emit API
        /// </summary>
        [Fact]
        public void IsEmitApi_AssemblyBuilder_GetDefinedTypes_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Emit.AssemblyBuilder", "GetDefinedTypes");

            bool result = AotReflectionAnalyzer.IsEmitApi(method);

            Assert.True(result);
        }

        #endregion

        #region IsInvokeApi Tests

        /// <summary>
        ///     Tests that MethodInfo.Invoke is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_Invoke_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "Invoke");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.GetValue is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_GetValue_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "GetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.SetValue is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_SetValue_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "SetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.InvokeMember is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_InvokeMember_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "InvokeMember");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.GetRuntimeMethod is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_GetRuntimeMethod_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "GetRuntimeMethod");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MemberInfo.Invoke is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MemberInfo_Invoke_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MemberInfo", "Invoke");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that PropertyInfo.GetValue is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_PropertyInfo_GetValue_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.PropertyInfo", "GetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that PropertyInfo.SetValue is detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_PropertyInfo_SetValue_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.PropertyInfo", "SetValue");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that MethodInfo.GetHashCode is not detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_MethodInfo_GetHashCode_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.MethodInfo", "GetHashCode");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as invoke API
        /// </summary>
        [Fact]
        public void IsInvokeApi_Object_ToString_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Object", "ToString");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsInvokeApi_NullContainingType_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.CreateNullContainingType("SomeMethod");

            bool result = AotReflectionAnalyzer.IsInvokeApi(method);

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
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Activator", "CreateInstance");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.CreateInstanceFrom is detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_CreateInstanceFrom_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Activator", "CreateInstanceFrom");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.CreateInstanceUnwrapped is detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_CreateInstanceUnwrapped_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Activator", "CreateInstanceUnwrapped");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.CreateInstanceBound is detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_CreateInstanceBound_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Activator", "CreateInstanceBound");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Activator.GetHashCode is not detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Activator_GetHashCode_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Activator", "GetHashCode");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as activator API
        /// </summary>
        [Fact]
        public void IsActivatorApi_Object_ToString_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Object", "ToString");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsActivatorApi_NullContainingType_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.CreateNullContainingType("SomeMethod");

            bool result = AotReflectionAnalyzer.IsActivatorApi(method);

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
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Type", "GetType");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Assembly.Load is detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Assembly_Load_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Assembly", "Load");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Assembly.LoadFrom is detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Assembly_LoadFrom_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Assembly", "LoadFrom");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Assembly.LoadFile is NOT detected as type-get-type API (only Load/LoadFrom are)
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Assembly_LoadFile_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Reflection.Assembly", "LoadFile");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that Type.FullName is not detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Type_FullName_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Type", "FullName");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as type-get-type API
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_Object_ToString_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Object", "ToString");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsTypeGetTypeApi_NullContainingType_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.CreateNullContainingType("SomeMethod");

            bool result = AotReflectionAnalyzer.IsTypeGetTypeApi(method);

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
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Runtime.Serialization.Formatters.Binary.BinaryFormatter", "Serialize");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Newtonsoft.Json.JsonConvert is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_JsonConvert_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("Newtonsoft.Json.JsonConvert", "SerializeObject");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Text.Json.JsonSerializer is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_JsonSerializer_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Text.Json.JsonSerializer", "Serialize");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that XmlSerializer is detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_XmlSerializer_ReturnsTrue()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Xml.Serialization.XmlSerializer", "Serialize");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that System.Object.ToString is not detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_Object_ToString_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.Object", "ToString");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that System.String.IsNullOrEmpty is not detected as known serializer
        /// </summary>
        [Fact]
        public void IsKnownSerializer_String_IsNullOrEmpty_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.Create("System.String", "IsNullOrEmpty");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that null containing type returns false
        /// </summary>
        [Fact]
        public void IsKnownSerializer_NullContainingType_ReturnsFalse()
        {
            IMethodSymbol method = MockMethodSymbolFactory.CreateNullContainingType("SomeMethod");

            bool result = AotReflectionAnalyzer.IsKnownSerializer(method);

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

            ImmutableArray<DiagnosticDescriptor> diagnostics = analyzer.SupportedDiagnostics;

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

            ImmutableArray<DiagnosticDescriptor> diagnostics = analyzer.SupportedDiagnostics;

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
            string[] ids = new[]
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

            IEnumerable<string> distinct = ids.Distinct();

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

            ImmutableArray<Diagnostic> diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdReflectionApi);
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

            ImmutableArray<Diagnostic> diagnostics = RunAnalyzer(code);

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

            ImmutableArray<Diagnostic> diagnostics = RunAnalyzer(code);

            Assert.DoesNotContain(diagnostics, d => d.Id.StartsWith("ALIS"));
        }

        /// <summary>
        ///     Tests that the analyzer detects ConstructorInfo.Invoke and reports ALIS001 (ReflectionApiRule)
        /// </summary>
        [Fact]
        public void AnalyzeInvocation_ConstructorInfoInvoke_ReportsReflectionApiDiagnostic()
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

            ImmutableArray<Diagnostic> diagnostics = RunAnalyzer(code);

            Assert.Contains(diagnostics, d => d.Id == AotReflectionAnalyzer.IdReflectionApi);
        }

        /// <summary>
        ///     Runs the AotReflectionAnalyzer on the given source code and returns diagnostics
        /// </summary>
        private static ImmutableArray<Diagnostic> RunAnalyzer(string sourceCode)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);

            PortableExecutableReference[] appDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !string.IsNullOrEmpty(a.Location))
                .Select(a => MetadataReference.CreateFromFile(a.Location))
                .ToArray();

            CSharpCompilation compilation = CSharpCompilation.Create(
                "TestAssembly",
                new[] { syntaxTree },
                appDomainAssemblies,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            AotReflectionAnalyzer analyzer = new AotReflectionAnalyzer();
            CompilationWithAnalyzers compilationWithAnalyzers = compilation.WithAnalyzers(ImmutableArray.Create<DiagnosticAnalyzer>(analyzer));

            return compilationWithAnalyzers.GetAllDiagnosticsAsync().GetAwaiter().GetResult();
        }

        #endregion
    }
}
