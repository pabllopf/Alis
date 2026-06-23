// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▀
// 
//  --------------------------------------------------------------------------
//  File:SerializationCodeBuilderTest.cs
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
using System.Linq;
using Microsoft.CodeAnalysis;
using Alis.Core.Aspect.Data.Generator;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Generator
{
    /// <summary>
    ///     Stub implementation of INamedTypeSymbol for serialization builder tests.
    /// </summary>
    internal sealed class StubTestClassSymbol : INamedTypeSymbol
    {
        /// <summary>
        ///     The type name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        ///     The type kind.
        /// </summary>
        private readonly TypeKind _typeKind;

        /// <summary>
        ///     The namespace.
        /// </summary>
        private readonly string _namespace;

        /// <summary>
        ///     The properties.
        /// </summary>
        private readonly IPropertySymbol[] _properties;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StubTestClassSymbol" /> class.
        /// </summary>
        /// <param name="name">The type name.</param>
        /// <param name="typeKind">The type kind (class or struct).</param>
        /// <param name="namespaceName">The namespace.</param>
        /// <param name="properties">The properties of this type.</param>
        public StubTestClassSymbol(string name, TypeKind typeKind = TypeKind.Class, string namespaceName = "TestNamespace", IPropertySymbol[] properties = null)
        {
            _name = name;
            _typeKind = typeKind;
            _namespace = namespaceName;
            _properties = properties ?? Array.Empty<IPropertySymbol>();
        }

        public string Name => _name;
        public string MetadataName => _name;
        public string ToDisplayString(SymbolDisplayFormat? format = null) => $"{_namespace}.{_name}";
        public SpecialType SpecialType => SpecialType.None;
        public TypeKind TypeKind => _typeKind;
        public bool IsAbstract => false;
        public bool IsSealed => false;
        public bool IsStatic => false;
        public bool IsInterface => false;
        public bool IsTupleType => false;
        public bool IsValueType => _typeKind == TypeKind.Struct;
        public bool IsReferenceType => _typeKind == TypeKind.Class;
        public INamespaceSymbol ContainingNamespaceSymbol => null;
        public string ContainingNamespace => _namespace;
        public ITypeSymbol BaseType => null;
        public ImmutableArray<ITypeParameterSymbol> TypeParameters => ImmutableArray<ITypeParameterSymbol>.Empty;
        public ITypeSymbol[] TypeArguments => Array.Empty<ITypeSymbol>();
        public INamedTypeSymbol OriginalDefinition => null;
        public IEnumerable<INamedTypeSymbol> AllInterfaces => Enumerable.Empty<INamedTypeSymbol>();
        public IEnumerable<IPropertySymbol> GetProperties() => _properties;
        public IEnumerable<IMethodSymbol> GetMethods() => Enumerable.Empty<IMethodSymbol>();
        public IEnumerable<IFieldSymbol> GetFields() => Enumerable.Empty<IFieldSymbol>();
        public IEnumerable<ISymbol> GetMembers() => _properties.Cast<ISymbol>();
        public IEnumerable<ISymbol> GetMembers(string name) => _properties.Where(p => p.Name == name).Cast<ISymbol>();
        public ITypeSymbol Construct(params ITypeSymbol[] typeArguments) => this;
        public ImmutableArray<AttributeData> GetAttributes() => ImmutableArray<AttributeData>.Empty;
        public string ToDisplayString(SymbolDisplayFormat format, Func<INamedTypeSymbol, string> qualifyWithNamespace) => ToDisplayString(format);
        public ISymbol OriginalDefinitionSymbol => null;
    }

    /// <summary>
    ///     Stub property symbol for serialization builder tests.
    /// </summary>
    internal sealed class StubTestPropertySymbol : IPropertySymbol
    {
        /// <summary>
        ///     The property name.
        /// </summary>
        private readonly string _name;

        /// <summary>
        ///     The property type.
        /// </summary>
        private readonly ITypeSymbol _type;

        /// <summary>
        ///     The accessibility.
        /// </summary>
        private readonly Accessibility _accessibility;

        /// <summary>
        ///     Whether this is an indexer.
        /// </summary>
        private readonly bool _isIndexer;

        /// <summary>
        ///     Attributes for this property.
        /// </summary>
        private readonly ImmutableArray<AttributeData> _attributes;

        /// <summary>
        ///     Whether this property has a setter.
        /// </summary>
        private readonly bool _hasSetter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StubTestPropertySymbol" /> class.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <param name="accessibility">The accessibility.</param>
        /// <param name="isIndexer">Whether this is an indexer.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="hasSetter">Whether this property has a setter.</param>
        public StubTestPropertySymbol(string name, ITypeSymbol type, Accessibility accessibility = Accessibility.Public, bool isIndexer = false, ImmutableArray<AttributeData> attributes = null, bool hasSetter = true)
        {
            _name = name;
            _type = type;
            _accessibility = accessibility;
            _isIndexer = isIndexer;
            _attributes = attributes ?? ImmutableArray<AttributeData>.Empty;
            _hasSetter = hasSetter;
        }

        public string Name => _name;
        public ITypeSymbol Type => _type;
        public Accessibility DeclaredAccessibility => _accessibility;
        public bool IsIndexer => _isIndexer;
        public bool IsStatic => false;
        public bool IsAbstract => false;
        public bool IsVirtual => false;
        public bool IsOverride => false;
        public bool IsReadOnly => false;
        public bool IsWriteOnly => false;
        public IMethodSymbol GetMethod => null;
        public IMethodSymbol SetMethod => _hasSetter ? new StubTestMethodSymbol() : null;
        public IMethodSymbol[] Methods => Array.Empty<IMethodSymbol>();
        public ISymbol ContainingSymbol => null;
        public SymbolKind Kind => SymbolKind.Property;
        public ImmutableArray<AttributeData> GetAttributes() => _attributes;
        public string ToDisplayString(SymbolDisplayFormat? format = null) => _name;
        public ISymbol OriginalDefinition => null;
        public string MetadataName => _name;
        public IEnumerable<ISymbol> GetMembers() => Enumerable.Empty<ISymbol>();
        public IEnumerable<ISymbol> GetMembers(string name) => Enumerable.Empty<ISymbol>();
    }

    /// <summary>
    ///     Stub method symbol for serialization builder tests.
    /// </summary>
    internal sealed class StubTestMethodSymbol : IMethodSymbol
    {
        public string Name => "Set";
        public MethodKind MethodKind => MethodKind.Normal;
        public ITypeSymbol ReturnType => null;
        public IParameterSymbol[] Parameters => Array.Empty<IParameterSymbol>();
        public bool IsAbstract => false;
        public bool IsVirtual => false;
        public bool IsOverride => false;
        public Accessibility DeclaredAccessibility => Accessibility.Public;
        public IMethodSymbol OriginalDefinition => null;
        public string MetadataName => "Set";
        public ImmutableArray<AttributeData> GetAttributes() => ImmutableArray<AttributeData>.Empty;
        public ISymbol ContainingSymbol => null;
        public SymbolKind Kind => SymbolKind.Method;
        public string ToDisplayString(SymbolDisplayFormat? format = null) => "Set";
    }

    /// <summary>
    ///     Stub attribute data for serialization builder tests.
    /// </summary>
    internal sealed class StubTestAttributeData : IAttributeData
    {
        /// <summary>
        ///     The attribute class name.
        /// </summary>
        private readonly string _className;

        /// <summary>
        ///     The constructor arguments.
        /// </summary>
        private readonly TypedConstant[] _constructorArgs;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StubTestAttributeData" /> class.
        /// </summary>
        /// <param name="className">The attribute class name.</param>
        /// <param name="constructorArgs">The constructor arguments.</param>
        public StubTestAttributeData(string className, params object[] constructorArgs)
        {
            _className = className;
            _constructorArgs = constructorArgs.Select(a => TypedConstant.Create(a)).ToArray();
        }

        public INamedTypeSymbol AttributeClass => new StubTestNamedTypeSymbol(_className);
        public ImmutableArray<TypedConstant> ConstructorArguments => _constructorArgs.Length > 0 ? _constructorArgs.ToImmutableArray() : ImmutableArray<TypedConstant>.Empty;
        public ImmutableArray<KeyValuePair<string, TypedConstant>> NamedArguments => ImmutableArray<KeyValuePair<string, TypedConstant>>.Empty;
    }

    /// <summary>
    ///     Stub named type symbol for attribute class name.
    /// </summary>
    internal sealed class StubTestNamedTypeSymbol : INamedTypeSymbol
    {
        private readonly string _name;

        public StubTestNamedTypeSymbol(string name) => _name = name;

        public string Name => _name;
        public string MetadataName => _name;
        public string ToDisplayString(SymbolDisplayFormat? format = null) => _name;
        public SpecialType SpecialType => SpecialType.None;
        public TypeKind TypeKind => TypeKind.Class;
        public bool IsAbstract => false;
        public bool IsSealed => false;
        public bool IsStatic => false;
        public bool IsInterface => false;
        public bool IsTupleType => false;
        public bool IsValueType => false;
        public bool IsReferenceType => true;
        public INamespaceSymbol ContainingNamespaceSymbol => null;
        public string ContainingNamespace => null;
        public ITypeSymbol BaseType => null;
        public ImmutableArray<ITypeParameterSymbol> TypeParameters => ImmutableArray<ITypeParameterSymbol>.Empty;
        public ITypeSymbol[] TypeArguments => Array.Empty<ITypeSymbol>();
        public INamedTypeSymbol OriginalDefinition => null;
        public IEnumerable<INamedTypeSymbol> AllInterfaces => Enumerable.Empty<INamedTypeSymbol>();
        public IEnumerable<IPropertySymbol> GetProperties() => Enumerable.Empty<IPropertySymbol>();
        public IEnumerable<IMethodSymbol> GetMethods() => Enumerable.Empty<IMethodSymbol>();
        public IEnumerable<IFieldSymbol> GetFields() => Enumerable.Empty<IFieldSymbol>();
        public IEnumerable<ISymbol> GetMembers() => Enumerable.Empty<ISymbol>();
        public IEnumerable<ISymbol> GetMembers(string name) => Enumerable.Empty<ISymbol>();
        public ITypeSymbol Construct(params ITypeSymbol[] typeArguments) => this;
        public ImmutableArray<AttributeData> GetAttributes() => ImmutableArray<AttributeData>.Empty;
        public string ToDisplayString(SymbolDisplayFormat format, Func<INamedTypeSymbol, string> qualifyWithNamespace) => _name;
        public ISymbol OriginalDefinitionSymbol => null;
    }

    /// <summary>
    ///     Helper to create a property with JsonNativeIgnore attribute.
    /// </summary>
    internal static class PropertyBuilder
    {
        /// <summary>
        ///     Creates a property with JsonNativeIgnore attribute.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <returns>The property symbol with ignore attribute.</returns>
        public static IPropertySymbol WithIgnoreAttribute(string name, ITypeSymbol type)
        {
            ImmutableArray<AttributeData> attrs = ImmutableArray.Create<AttributeData>(new StubTestAttributeData("JsonNativeIgnoreAttribute"));
            return new StubTestPropertySymbol(name, type, attributes: attrs);
        }

        /// <summary>
        ///     Creates a property with JsonNativePropertyName attribute.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <param name="jsonName">The JSON property name.</param>
        /// <returns>The property symbol with property name attribute.</returns>
        public static IPropertySymbol WithPropertyNameAttribute(string name, ITypeSymbol type, string jsonName)
        {
            ImmutableArray<AttributeData> attrs = ImmutableArray.Create<AttributeData>(new StubTestAttributeData("JsonNativePropertyNameAttribute", jsonName));
            return new StubTestPropertySymbol(name, type, attributes: attrs);
        }

        /// <summary>
        ///     Creates a simple property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <returns>The property symbol.</returns>
        public static IPropertySymbol Create(string name, ITypeSymbol type) => new StubTestPropertySymbol(name, type);

        /// <summary>
        ///     Creates a property without setter.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <returns>The property symbol without setter.</returns>
        public static IPropertySymbol CreateReadOnly(string name, ITypeSymbol type) => new StubTestPropertySymbol(name, type, hasSetter: false);

        /// <summary>
        ///     Creates an indexer property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <returns>The indexer property symbol.</returns>
        public static IPropertySymbol CreateIndexer(string name, ITypeSymbol type) => new StubTestPropertySymbol(name, type, isIndexer: true);

        /// <summary>
        ///     Creates a non-public property.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <returns>The non-public property symbol.</returns>
        public static IPropertySymbol CreateNonPublic(string name, ITypeSymbol type) => new StubTestPropertySymbol(name, type, accessibility: Accessibility.Private);
    }

    /// <summary>
    ///     Stub type symbols for serialization builder tests.
    /// </summary>
    internal static class TypeBuilders
    {
        public static ITypeSymbol String => new StubTypeSymbol("string", SpecialType.System_String, isValueType: false);
        public static ITypeSymbol Int => new StubTypeSymbol("int", SpecialType.System_Int32, isValueType: true);
        public static ITypeSymbol Boolean => new StubTypeSymbol("bool", SpecialType.System_Boolean, isValueType: true);
        public static ITypeSymbol Double => new StubTypeSymbol("double", SpecialType.System_Double, isValueType: true);
        public static ITypeSymbol Float => new StubTypeSymbol("float", SpecialType.System_Single, isValueType: true);
        public static ITypeSymbol Long => new StubTypeSymbol("long", SpecialType.System_Int64, isValueType: true);
        public static ITypeSymbol Decimal => new StubTypeSymbol("decimal", SpecialType.System_Decimal, isValueType: true);
        public static ITypeSymbol Char => new StubTypeSymbol("char", SpecialType.System_Char, isValueType: true);
        public static ITypeSymbol Byte => new StubTypeSymbol("byte", SpecialType.System_Byte, isValueType: true);
        public static ITypeSymbol SByte => new StubTypeSymbol("sbyte", SpecialType.System_SByte, isValueType: true);
        public static ITypeSymbol Short => new StubTypeSymbol("short", SpecialType.System_Int16, isValueType: true);
        public static ITypeSymbol UShort => new StubTypeSymbol("ushort", SpecialType.System_UInt16, isValueType: true);
        public static ITypeSymbol UInt => new StubTypeSymbol("uint", SpecialType.System_UInt32, isValueType: true);
        public static ITypeSymbol ULong => new StubTypeSymbol("ulong", SpecialType.System_UInt64, isValueType: true);
        public static ITypeSymbol DateTime => new StubTypeSymbol("System.DateTime");
        public static ITypeSymbol DateTimeOffset => new StubTypeSymbol("System.DateTimeOffset");
        public static ITypeSymbol TimeSpan => new StubTypeSymbol("System.TimeSpan");
        public static ITypeSymbol Guid => new StubTypeSymbol("System.Guid");
        public static ITypeSymbol Uri => new StubTypeSymbol("System.Uri");
        public static ITypeSymbol Version => new StubTypeSymbol("System.Version");
        public static ITypeSymbol EnumType => new StubTypeSymbol("MyEnum", SpecialType.None, TypeKind.Enum);
        public static ITypeSymbol ComplexType => new StubTestClassSymbol("UserData", TypeKind.Class, "MyNamespace");
        public static ITypeSymbol StringArray => new StubArrayTypeSymbol(String, 1);
        public static ITypeSymbol IntArray2D => new StubArrayTypeSymbol(Int, 2);
        public static ITypeSymbol StringList => new StubNamedTypeSymbol("System.Collections.Generic.List<string>", new[] { String }, new[] { new StubTypeSymbol("System.Collections.Generic.IEnumerable<string>") });
        public static ITypeSymbol StringDict => new StubNamedTypeSymbol("System.Collections.Generic.Dictionary<string, string>");
    }

    /// <summary>
    ///     Unit tests for the <see cref="SerializationCodeBuilder" /> class.
    /// </summary>
    public class SerializationCodeBuilderTest
    {
        /// <summary>
        ///     Tests that constructor accepts INamedTypeSymbol.
        /// </summary>
        [Fact]
        public void Constructor_AcceptsNamedTypeSymbol()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that Build returns a non-empty string.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonEmptyString()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: Array.Empty<IPropertySymbol>());

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that Build contains the namespace declaration.
        /// </summary>
        [Fact]
        public void Build_ContainsNamespaceDeclaration()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", namespaceName: "MyApp.Models");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("namespace MyApp.Models", result);
        }

        /// <summary>
        ///     Tests that Build contains the class declaration with partial keyword.
        /// </summary>
        [Fact]
        public void Build_ContainsPartialClassDeclaration()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("public partial class TestUser", result);
        }

        /// <summary>
        ///     Tests that Build contains struct keyword for struct types.
        /// </summary>
        [Fact]
        public void Build_ContainsStructKeywordForStructs()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", TypeKind.Struct);

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("public partial struct TestUser", result);
        }

        /// <summary>
        ///     Tests that Build implements IJsonSerializable.
        /// </summary>
        [Fact]
        public void Build_ImplementsIJsonSerializable()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("IJsonSerializable", result);
        }

        /// <summary>
        ///     Tests that Build implements IJsonDesSerializable.
        /// </summary>
        [Fact]
        public void Build_ImplementsIJsonDesSerializable()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("IJsonDesSerializable<TestUser>", result);
        }

        /// <summary>
        ///     Tests that Build contains GetSerializableProperties method.
        /// </summary>
        [Fact]
        public void Build_ContainsGetSerializablePropertiesMethod()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("GetSerializableProperties", result);
        }

        /// <summary>
        ///     Tests that Build contains CreateFromProperties method.
        /// </summary>
        [Fact]
        public void Build_ContainsCreateFromPropertiesMethod()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("CreateFromProperties", result);
        }

        /// <summary>
        ///     Tests that Build contains extension methods ToJson and FromJson.
        /// </summary>
        [Fact]
        public void Build_ContainsExtensionMethods()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("ToJson()", result);
            Assert.Contains("FromJson(string json)", result);
        }

        /// <summary>
        ///     Tests that Build contains pragma warning disable directives.
        /// </summary>
        [Fact]
        public void Build_ContainsPragmaWarningDisableDirectives()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("#pragma warning disable CS1591", result);
            Assert.Contains("#pragma warning disable CS8603", result);
            Assert.Contains("#pragma warning disable CS8604", result);
            Assert.Contains("#pragma warning disable CS8618", result);
        }

        /// <summary>
        ///     Tests that Build contains pragma warning restore directives.
        /// </summary>
        [Fact]
        public void Build_ContainsPragmaWarningRestoreDirectives()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("#pragma warning restore CS8618", result);
            Assert.Contains("#pragma warning restore CS8604", result);
            Assert.Contains("#pragma warning restore CS8603", result);
            Assert.Contains("#pragma warning restore CS1591", result);
        }

        /// <summary>
        ///     Tests that Build contains using directives.
        /// </summary>
        [Fact]
        public void Build_ContainsUsingDirectives()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("using System;", result);
            Assert.Contains("using System.Linq;", result);
            Assert.Contains("using System.Collections.Generic;", result);
            Assert.Contains("using Alis.Core.Aspect.Data.Json;", result);
        }

        /// <summary>
        ///     Tests that Build skips properties with JsonNativeIgnore attribute.
        /// </summary>
        [Fact]
        public void Build_SkipsPropertiesWithJsonNativeIgnoreAttribute()
        {
            ITypeSymbol intType = TypeBuilders.Int;
            IPropertySymbol normalProp = PropertyBuilder.Create("NormalProp", intType);
            IPropertySymbol ignoredProp = PropertyBuilder.WithIgnoreAttribute("IgnoredProp", intType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { normalProp, ignoredProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("NormalProp", result);
            Assert.DoesNotContain("IgnoredProp", result);
        }

        /// <summary>
        ///     Tests that Build skips indexer properties.
        /// </summary>
        [Fact]
        public void Build_SkipsIndexerProperties()
        {
            ITypeSymbol intType = TypeBuilders.Int;
            IPropertySymbol normalProp = PropertyBuilder.Create("NormalProp", intType);
            IPropertySymbol indexerProp = PropertyBuilder.CreateIndexer("this[int]", intType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { normalProp, indexerProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("NormalProp", result);
            Assert.DoesNotContain("this[int]", result);
        }

        /// <summary>
        ///     Tests that Build skips non-public properties.
        /// </summary>
        [Fact]
        public void Build_SkipsNonPublicProperties()
        {
            ITypeSymbol intType = TypeBuilders.Int;
            IPropertySymbol publicProp = PropertyBuilder.Create("PublicProp", intType);
            IPropertySymbol privateProp = PropertyBuilder.CreateNonPublic("PrivateProp", intType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { publicProp, privateProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("PublicProp", result);
            Assert.DoesNotContain("PrivateProp", result);
        }

        /// <summary>
        ///     Tests that Build uses JsonNativePropertyName for property names.
        /// </summary>
        [Fact]
        public void Build_UsesJsonNativePropertyNameForPropertyNames()
        {
            ITypeSymbol stringType = TypeBuilders.String;
            IPropertySymbol namedProp = PropertyBuilder.WithPropertyNameAttribute("MyProperty", stringType, "custom_name");

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { namedProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("custom_name", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for string properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForStringProperties()
        {
            ITypeSymbol stringType = TypeBuilders.String;
            IPropertyPropertys = PropertyBuilder.Create("Name", stringType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { stringProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("yield return", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for int properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForIntProperties()
        {
            ITypeSymbol intType = TypeBuilders.Int;
            IPropertySymbol intProp = PropertyBuilder.Create("Age", intType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { intProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("yield return", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for array properties using SerializeArray.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForArrayProperties()
        {
            ITypeSymbol stringArray = TypeBuilders.StringArray;
            IPropertySymbol arrayProp = PropertyBuilder.Create("Tags", stringArray);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { arrayProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("SerializeArray", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for 2D array properties using Serialize2DArray.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeFor2DArrayProperties()
        {
            ITypeSymbol intArray2D = TypeBuilders.IntArray2D;
            IPropertySymbol arrayProp = PropertyBuilder.Create("Matrix", intArray2D);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { arrayProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("Serialize2DArray", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for list properties using SerializeCollection.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForListProperties()
        {
            ITypeSymbol stringList = TypeBuilders.StringList;
            IPropertySymbol listProp = PropertyBuilder.Create("Items", stringList);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { listProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("SerializeCollection", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for dictionary properties using SerializeDictionary.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForDictionaryProperties()
        {
            ITypeSymbol stringDict = TypeBuilders.StringDict;
            IPropertySymbol dictProp = PropertyBuilder.Create("Metadata", stringDict);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { dictProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("SerializeDictionary", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for enum properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForEnumProperties()
        {
            ITypeSymbol enumType = TypeBuilders.EnumType;
            IPropertySymbol enumProp = PropertyBuilder.Create("Status", enumType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { enumProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("ToString()", result);
        }

        /// <summary>
        ///     Tests that Build generates serialization code for complex type properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesSerializationCodeForComplexTypeProperties()
        {
            ITypeSymbol complexType = TypeBuilders.ComplexType;
            IPropertySymbol complexProp = PropertyBuilder.Create("UserData", complexType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { complexProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("IJsonSerializable", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for boolean properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForBooleanProperties()
        {
            ITypeSymbol boolType = TypeBuilders.Boolean;
            IPropertySymbol boolProp = PropertyBuilder.Create("IsActive", boolType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { boolProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("bool.TryParse", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for string properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForStringProperties()
        {
            ITypeSymbol stringType = TypeBuilders.String;
            IPropertySymbol stringProp = PropertyBuilder.Create("Name", stringType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { stringProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("TryGetValue", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for int properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForIntProperties()
        {
            ITypeSymbol intType = TypeBuilders.Int;
            IPropertySymbol intProp = PropertyBuilder.Create("Age", intType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { intProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("int.TryParse", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for all numeric types.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForAllNumericTypes()
        {
            IPropertySymbol charProp = PropertyBuilder.Create("C", TypeBuilders.Char);
            IPropertySymbol byteProp = PropertyBuilder.Create("B", TypeBuilders.Byte);
            IPropertySymbol sbyteProp = PropertyBuilder.Create("Sb", TypeBuilders.SByte);
            IPropertySymbol shortProp = PropertyBuilder.Create("S", TypeBuilders.Short);
            IPropertySymbol ushortProp = PropertyBuilder.Create("Us", TypeBuilders.UShort);
            IPropertySymbol uintProp = PropertyBuilder.Create("Ui", TypeBuilders.UInt);
            IPropertySymbol longProp = PropertyBuilder.Create("L", TypeBuilders.Long);
            IPropertySymbol ulongProp = PropertyBuilder.Create("Ul", TypeBuilders.ULong);
            IPropertySymbol floatProp = PropertyBuilder.Create("F", TypeBuilders.Float);
            IPropertySymbol doubleProp = PropertyBuilder.Create("D", TypeBuilders.Double);
            IPropertySymbol decimalProp = PropertyBuilder.Create("Dec", TypeBuilders.Decimal);

            ITypeSymbol typeSymbol = new StubTestClassSymbol(
                "TestUser",
                properties: new[] { charProp, byteProp, sbyteProp, shortProp, ushortProp, uintProp, longProp, ulongProp, floatProp, doubleProp, decimalProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("char.TryParse", result);
            Assert.Contains("byte.TryParse", result);
            Assert.Contains("sbyte.TryParse", result);
            Assert.Contains("short.TryParse", result);
            Assert.Contains("ushort.TryParse", result);
            Assert.Contains("uint.TryParse", result);
            Assert.Contains("long.TryParse", result);
            Assert.Contains("ulong.TryParse", result);
            Assert.Contains("float.TryParse", result);
            Assert.Contains("double.TryParse", result);
            Assert.Contains("decimal.TryParse", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for extended types.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForExtendedTypes()
        {
            IPropertySymbol dateTimeProp = PropertyBuilder.Create("Dt", TypeBuilders.DateTime);
            IPropertySymbol dateTimeOffsetProp = PropertyBuilder.Create("Dto", TypeBuilders.DateTimeOffset);
            IPropertySymbol timeSpanProp = PropertyBuilder.Create("Ts", TypeBuilders.TimeSpan);
            IPropertySymbol guidProp = PropertyBuilder.Create("G", TypeBuilders.Guid);
            IPropertySymbol uriProp = PropertyBuilder.Create("U", TypeBuilders.Uri);
            IPropertySymbol versionProp = PropertyBuilder.Create("V", TypeBuilders.Version);

            ITypeSymbol typeSymbol = new StubTestClassSymbol(
                "TestUser",
                properties: new[] { dateTimeProp, dateTimeOffsetProp, timeSpanProp, guidProp, uriProp, versionProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("DateTime.TryParse", result);
            Assert.Contains("DateTimeOffset.TryParse", result);
            Assert.Contains("TimeSpan.TryParse", result);
            Assert.Contains("Guid.TryParse", result);
            Assert.Contains("Uri.TryCreate", result);
            Assert.Contains("new Version", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for array properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForArrayProperties()
        {
            ITypeSymbol stringArray = TypeBuilders.StringArray;
            IPropertySymbol arrayProp = PropertyBuilder.Create("Tags", stringArray);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { arrayProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("DeserializeArray", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for 2D array properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeFor2DArrayProperties()
        {
            ITypeSymbol intArray2D = TypeBuilders.IntArray2D;
            IPropertySymbol arrayProp = PropertyBuilder.Create("Matrix", intArray2D);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { arrayProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("Deserialize2DArray", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for list properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForListProperties()
        {
            ITypeSymbol stringList = TypeBuilders.StringList;
            IPropertySymbol listProp = PropertyBuilder.Create("Items", stringList);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { listProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("DeserializeList", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for dictionary properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForDictionaryProperties()
        {
            ITypeSymbol stringDict = TypeBuilders.StringDict;
            IPropertySymbol dictProp = PropertyBuilder.Create("Metadata", stringDict);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { dictProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("DeserializeDictionary", result);
        }

        /// <summary>
        ///     Tests that Build generates deserialization code for enum properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesDeserializationCodeForEnumProperties()
        {
            ITypeSymbol enumType = TypeBuilders.EnumType;
            IPropertySymbol enumProp = PropertyBuilder.Create("Status", enumType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { enumProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("Enum.TryParse", result);
        }

        /// <summary>
        ///     Tests that Build generates correct class name in partial declaration.
        /// </summary>
        [Fact]
        public void Build_UsesCorrectClassNameInDeclaration()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("MyCustomClass");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("partial class MyCustomClass", result);
        }

        /// <summary>
        ///     Tests that Build generates partial struct for struct types.
        /// </summary>
        [Fact]
        public void Build_UsesStructKeywordForStructTypes()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("MyCustomStruct", TypeKind.Struct);

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("partial struct MyCustomStruct", result);
        }

        /// <summary>
        ///     Tests that Build generates helper methods section.
        /// </summary>
        [Fact]
        public void Build_ContainsHelperMethods()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("SerializeArray", result);
            Assert.Contains("DeserializeArray", result);
        }

        /// <summary>
        ///     Tests that Build generates complete output with multiple properties.
        /// </summary>
        [Fact]
        public void Build_GeneratesCompleteOutputWithMultipleProperties()
        {
            IPropertySymbol nameProp = PropertyBuilder.Create("Name", TypeBuilders.String);
            IPropertySymbol ageProp = PropertyBuilder.Create("Age", TypeBuilders.Int);
            IPropertySymbol activeProp = PropertyBuilder.Create("Active", TypeBuilders.Boolean);

            ITypeSymbol typeSymbol = new StubTestClassSymbol(
                "CompleteUser",
                properties: new[] { nameProp, ageProp, activeProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("Name", result);
            Assert.Contains("Age", result);
            Assert.Contains("Active", result);
        }

        /// <summary>
        ///     Tests that Build skips properties without setters in CreateFromProperties.
        /// </summary>
        [Fact]
        public void Build_SkipsReadOnlyPropertiesInCreateFromProperties()
        {
            IPropertySymbol writeProp = PropertyBuilder.Create("Writable", TypeBuilders.String);
            IPropertySymbol readOnlyProp = PropertyBuilder.CreateReadOnly("ReadOnly", TypeBuilders.String);

            ITypeSymbol typeSymbol = new StubTestClassSymbol(
                "TestUser",
                properties: new[] { writeProp, readOnlyProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("Writable", result);
            Assert.DoesNotContain("ReadOnly", result);
        }

        /// <summary>
        ///     Tests that Build uses default values for properties without JSON key.
        /// </summary>
        [Fact]
        public void Build_UsesDefaultValuesForMissingProperties()
        {
            IPropertySymbol intProp = PropertyBuilder.Create("Count", TypeBuilders.Int);

            ITypeSymbol typeSymbol = new StubTestClassSymbol(
                "TestUser",
                properties: new[] { intProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("default", result);
        }

        /// <summary>
        ///     Tests that Build contains yield break in GetSerializableProperties.
        /// </summary>
        [Fact]
        public void Build_ContainsYieldBreak()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("yield break", result);
        }

        /// <summary>
        ///     Tests that Build contains JsonNativeAot references.
        /// </summary>
        [Fact]
        public void Build_ContainsJsonNativeAotReferences()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("JsonNativeAot.Serialize", result);
            Assert.Contains("JsonNativeAot.Deserialize", result);
        }

        /// <summary>
        ///     Tests that Build generates proper class body with opening and closing braces.
        /// </summary>
        [Fact]
        public void Build_GeneratesProperClassBodyStructure()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            // Count class body braces - should have balanced structure
            int openBraces = result.Count(c => c == '{');
            int closeBraces = result.Count(c => c == '}');
            Assert.True(openBraces > 0, "Expected at least one opening brace");
            Assert.Equal(openBraces, closeBraces);
        }

        /// <summary>
        ///     Tests that Build generates FromJson with correct return type.
        /// </summary>
        [Fact]
        public void Build_GeneratesFromJsonWithCorrectReturnType()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("public static TestUser FromJson(string json)", result);
        }

        /// <summary>
        ///     Tests that Build generates ToJson with correct return type.
        /// </summary>
        [Fact]
        public void Build_GeneratesToJsonWithCorrectReturnType()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("public string ToJson()", result);
        }

        /// <summary>
        ///     Tests that Build handles properties with JsonNativePropertyName correctly in deserialization.
        /// </summary>
        [Fact]
        public void Build_UsesJsonPropertyNameInDeserialization()
        {
            IPropertySymbol namedProp = PropertyBuilder.WithPropertyNameAttribute("MyProperty", TypeBuilders.String, "custom_key");

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { namedProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("custom_key", result);
        }

        /// <summary>
        ///     Tests that Build generates proper constructor instantiation in CreateFromProperties.
        /// </summary>
        [Fact]
        public void Build_GeneratesConstructorInstantiation()
        {
            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser");

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("new TestUser", result);
        }

        /// <summary>
        ///     Tests that Build handles properties with complex type and null check.
        /// </summary>
        [Fact]
        public void Build_HandlesComplexTypeWithNullCheck()
        {
            IPropertySymbol complexProp = PropertyBuilder.Create("UserData", TypeBuilders.ComplexType);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { complexProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("!= null", result);
        }

        /// <summary>
        ///     Tests that Build generates property assignment in CreateFromProperties.
        /// </summary>
        [Fact]
        public void Build_GeneratesPropertyAssignmentsInCreateFromProperties()
        {
            IPropertyPropertys = PropertyBuilder.Create("Name", TypeBuilders.String);

            ITypeSymbol typeSymbol = new StubTestClassSymbol("TestUser", properties: new[] { stringProp });

            var builder = new SerializationCodeBuilder((INamedTypeSymbol)typeSymbol);
            string result = builder.Build();

            Assert.Contains("=", result);
        }
    }
}
