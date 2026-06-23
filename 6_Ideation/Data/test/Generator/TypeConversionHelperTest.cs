// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TypeConversionHelperTest.cs
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
using System.Linq;
using Microsoft.CodeAnalysis;
using Alis.Core.Aspect.Data.Generator;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Generator
{
    /// <summary>
    ///     Stub implementation of ITypeSymbol for testing.
    /// </summary>
    internal sealed class StubTypeSymbol : ITypeSymbol
    {
        /// <summary>
        ///     The display string.
        /// </summary>
        private readonly string _displayString;

        /// <summary>
        ///     The special type.
        /// </summary>
        private readonly SpecialType _specialType;

        /// <summary>
        ///     The type kind.
        /// </summary>
        private readonly TypeKind _typeKind;

        /// <summary>
        ///     Whether the type is a value type.
        /// </summary>
        private readonly bool _isValueType;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StubTypeSymbol" /> class.
        /// </summary>
        /// <param name="displayString">The display string.</param>
        /// <param name="specialType">The special type.</param>
        /// <param name="typeKind">The type kind.</param>
        /// <param name="isValueType">Whether this is a value type.</param>
        public StubTypeSymbol(string displayString, SpecialType specialType = SpecialType.None, TypeKind typeKind = TypeKind.Class, bool isValueType = false)
        {
            _displayString = displayString;
            _specialType = specialType;
            _typeKind = typeKind;
            _isValueType = isValueType;
        }

        public string ToDisplayString(SymbolDisplayFormat? format = null) => _displayString;
        public SpecialType SpecialType => _specialType;
        public TypeKind TypeKind => _typeKind;
        public bool IsValueType => _isValueType;
        public string Name => _displayString.Split('.').Last();
        public string ContainingNamespace => null;
        public ITypeSymbol BaseType => null;
        public IEnumerable<ITypeSymbol> TypeArguments => Enumerable.Empty<ITypeSymbol>();
        public IEnumerable<ISymbol> GetMembers() => Enumerable.Empty<ISymbol>();
        public IEnumerable<ISymbol> GetMembers(string name) => Enumerable.Empty<ISymbol>();
        public ITypeSymbol Construct(params ITypeSymbol[] typeArguments) => null;
        public IEnumerable<IPropertySymbol> GetProperties() => Enumerable.Empty<IPropertySymbol>();
        public IEnumerable<IMethodSymbol> GetMethods() => Enumerable.Empty<IMethodSymbol>();
        public IEnumerable<IFieldSymbol> GetFields() => Enumerable.Empty<IFieldSymbol>();
        public IEnumerable<ISymbol> GetAllMembers() => Enumerable.Empty<ISymbol>();
        public ImmutableArray<AttributeData> GetAttributes() => ImmutableArray<AttributeData>.Empty;
        public string ToDisplayString(SymbolDisplayFormat format, Func<INamedTypeSymbol, string> qualifyWithNamespace) => _displayString;
        public INamespaceSymbol ContainingNamespaceSymbol => null;
        public bool IsAbstract => false;
        public bool IsSealed => false;
        public bool IsStatic => false;
        public bool IsInterface => false;
        public bool IsReferenceType => !_isValueType;
        public string ToDisplayString(ISymbolSymbolContext context) => _displayString;
        public IEnumerable<ITypeSymbol> AllInterfaces => Enumerable.Empty<ITypeSymbol>();
    }

    /// <summary>
    ///     Stub implementation of INamedTypeSymbol for testing.
    /// </summary>
    internal sealed class StubNamedTypeSymbol : StubTypeSymbol, INamedTypeSymbol
    {
        /// <summary>
        ///     The type arguments.
        /// </summary>
        private readonly ITypeSymbol[] _typeArguments;

        /// <summary>
        ///     The interfaces implemented.
        /// </summary>
        private readonly ITypeSymbol[] _interfaces;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StubNamedTypeSymbol" /> class.
        /// </summary>
        /// <param name="displayString">The display string.</param>
        /// <param name="typeArguments">The type arguments for generic types.</param>
        /// <param name="interfaces">The interfaces this type implements.</param>
        public StubNamedTypeSymbol(string displayString, ITypeSymbol[] typeArguments = null, ITypeSymbol[] interfaces = null)
            : base(displayString, SpecialType.None, TypeKind.Class)
        {
            _typeArguments = typeArguments ?? Array.Empty<ITypeSymbol>();
            _interfaces = interfaces ?? Array.Empty<ITypeSymbol>();
        }

        public ITypeSymbol[] TypeArguments => _typeArguments;
        public INamedTypeSymbol Construct(params ITypeSymbol[] typeArguments) => this;
        public ImmutableArray<ITypeParameterSymbol> TypeParameters => ImmutableArray<ITypeParameterSymbol>.Empty;
        public bool IsTupleType => false;
        public string TupleElementName => null;
        public IEnumerable<INamedTypeSymbol> AllInterfaces => _interfaces;
    }

    /// <summary>
    ///     Stub implementation of IArrayTypeSymbol for testing.
    /// </summary>
    internal sealed class StubArrayTypeSymbol : StubTypeSymbol, IArrayTypeSymbol
    {
        /// <summary>
        ///     The element type.
        /// </summary>
        private readonly ITypeSymbol _elementType;

        /// <summary>
        ///     The array rank.
        /// </summary>
        private readonly int _rank;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StubArrayTypeSymbol" /> class.
        /// </summary>
        /// <param name="elementType">The element type.</param>
        /// <param name="rank">The array rank.</param>
        public StubArrayTypeSymbol(ITypeSymbol elementType, int rank = 1)
            : base($"{elementType.ToDisplayString()}[{new string(',', rank - 1)}]", SpecialType.None, TypeKind.Class, false)
        {
            _elementType = elementType;
            _rank = rank;
        }

        public ITypeSymbol ElementType => _elementType;
        public int Rank => _rank;
        public IArrayTypeSymbol WithElementTypeAndRank(ITypeSymbol elementType, int rank) => new StubArrayTypeSymbol(elementType, rank);
    }

    /// <summary>
    ///     Stub implementation of IPropertySymbol for testing.
    /// </summary>
    internal sealed class StubPropertySymbol : IPropertySymbol
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
        ///     Initializes a new instance of the <see cref="StubPropertySymbol" /> class.
        /// </summary>
        /// <param name="name">The property name.</param>
        /// <param name="type">The property type.</param>
        /// <param name="accessibility">The accessibility.</param>
        /// <param name="isIndexer">Whether this is an indexer.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="hasSetter">Whether this property has a setter.</param>
        public StubPropertySymbol(string name, ITypeSymbol type, Accessibility accessibility = Accessibility.Public, bool isIndexer = false, ImmutableArray<AttributeData> attributes = null, bool hasSetter = true)
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
        public IMethodSymbol SetMethod => _hasSetter ? new StubMethodSymbol() : null;
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
    ///     Stub implementation of IMethodSymbol for testing.
    /// </summary>
    internal sealed class StubMethodSymbol : IMethodSymbol
    {
        public string Name => "Method";
        public MethodKind MethodKind => MethodKind.Normal;
        public ITypeSymbol ReturnType => null;
        public IParameterSymbol[] Parameters => Array.Empty<IParameterSymbol>();
        public bool IsAbstract => false;
        public bool IsVirtual => false;
        public bool IsOverride => false;
        public Accessibility DeclaredAccessibility => Accessibility.Public;
        public IMethodSymbol OriginalDefinition => null;
        public string MetadataName => "Method";
        public ImmutableArray<AttributeData> GetAttributes() => ImmutableArray<AttributeData>.Empty;
        public ISymbol ContainingSymbol => null;
        public SymbolKind Kind => SymbolKind.Method;
        public string ToDisplayString(SymbolDisplayFormat? format = null) => "Method";
    }

    /// <summary>
    ///     Stub implementation of IAttributeData for testing.
    /// </summary>
    internal sealed class StubAttributeData : IAttributeData
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
        ///     Initializes a new instance of the <see cref="StubAttributeData" /> class.
        /// </summary>
        /// <param name="className">The attribute class name.</param>
        /// <param name="constructorArgs">The constructor arguments.</param>
        public StubAttributeData(string className, params object[] constructorArgs)
        {
            _className = className;
            _constructorArgs = constructorArgs.Select(a => TypedConstant.Create(a)).ToArray();
        }

        public INamedTypeSymbol AttributeClass => new StubNamedTypeSymbol(_className);
        public ImmutableArray<TypedConstant> ConstructorArguments => _constructorArgs.Length > 0 ? _constructorArgs.ToImmutableArray() : ImmutableArray<TypedConstant>.Empty;
        public ImmutableArray<KeyValuePair<string, TypedConstant>> NamedArguments => ImmutableArray<KeyValuePair<string, TypedConstant>>.Empty;
    }

    /// <summary>
    ///     Stub implementation of TypedConstant for testing.
    /// </summary>
    internal sealed class TypedConstant
    {
        private readonly object _value;

        public object Value => _value;

        private TypedConstant(object value) => _value = value;

        public static TypedConstant Create(object value) => new(value);
    }

    /// <summary>
    ///     Stub implementation of INamespaceSymbol for testing.
    /// </summary>
    internal sealed class StubNamespaceSymbol : INamespaceSymbol
    {
        public string Name => "TestNamespace";
        public string NamespaceName => "TestNamespace";
        public bool IsGlobalNamespace => false;
        public IEnumerable<ISymbol> GetMembers() => Enumerable.Empty<ISymbol>();
        public IEnumerable<ISymbol> GetMembers(string name) => Enumerable.Empty<ISymbol>();
        public INamespaceSymbol LookupNamespace(string name) => null;
    }

    /// <summary>
    ///     Unit tests for the <see cref="TypeConversionHelper" /> class.
    /// </summary>
    public class TypeConversionHelperTest
    {
        /// <summary>
        ///     Tests that IsListOrCollection returns true for a generic list type.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithListType_ReturnsTrue()
        {
            ITypeSymbol listType = new StubNamedTypeSymbol(
                "System.Collections.Generic.List<string>",
                new[] { new StubTypeSymbol("string") },
                new[] { new StubTypeSymbol("System.Collections.Generic.IEnumerable<string>") });

            bool result = TypeConversionHelper.IsListOrCollection(listType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns true for a generic collection type.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithCollectionType_ReturnsTrue()
        {
            ITypeSymbol collectionType = new StubNamedTypeSymbol(
                "System.Collections.Generic.ICollection<int>",
                new[] { new StubTypeSymbol("int") },
                new[] { new StubTypeSymbol("System.Collections.Generic.ICollection<int>") });

            bool result = TypeConversionHelper.IsListOrCollection(collectionType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns true for a generic IList type.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithIListType_ReturnsTrue()
        {
            ITypeSymbol ilistType = new StubNamedTypeSymbol(
                "System.Collections.Generic.IList<double>",
                new[] { new StubTypeSymbol("double") },
                new[] { new StubTypeSymbol("System.Collections.Generic.IList<double>") });

            bool result = TypeConversionHelper.IsListOrCollection(ilistType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns true for a generic enumerable type.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithEnumerableType_ReturnsTrue()
        {
            ITypeSymbol enumerableType = new StubNamedTypeSymbol(
                "System.Collections.Generic.IEnumerable<bool>",
                new[] { new StubTypeSymbol("bool") },
                new[] { new StubTypeSymbol("System.Collections.Generic.IEnumerable<bool>") });

            bool result = TypeConversionHelper.IsListOrCollection(enumerableType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns false for a non-generic type.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithNonGenericType_ReturnsFalse()
        {
            ITypeSymbol nonGeneric = new StubNamedTypeSymbol("MyNonGenericClass");

            bool result = TypeConversionHelper.IsListOrCollection(nonGeneric);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns false for a generic type with more than one type argument.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithMultiGeneric_ReturnsFalse()
        {
            ITypeSymbol multiGeneric = new StubNamedTypeSymbol(
                "System.Collections.Generic.Dictionary<string, int>",
                new[] { new StubTypeSymbol("string"), new StubTypeSymbol("int") });

            bool result = TypeConversionHelper.IsListOrCollection(multiGeneric);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns false for a type without enumerable interfaces.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithoutEnumerableInterface_ReturnsFalse()
        {
            ITypeSymbol noInterfaces = new StubNamedTypeSymbol(
                "System.Collections.ArrayList",
                null,
                new[] { new StubTypeSymbol("SomeOtherInterface") });

            bool result = TypeConversionHelper.IsListOrCollection(noInterfaces);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns false for null type.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithNullType_ReturnsFalse()
        {
            bool result = TypeConversionHelper.IsListOrCollection(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsDictionary returns true for a generic Dictionary type.
        /// </summary>
        [Fact]
        public void IsDictionary_WithDictionaryType_ReturnsTrue()
        {
            ITypeSymbol dictType = new StubTypeSymbol("System.Collections.Generic.Dictionary<string, int>");

            bool result = TypeConversionHelper.IsDictionary(dictType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsDictionary returns true for a Dictionary with string key and string value.
        /// </summary>
        [Fact]
        public void IsDictionary_WithStringStringDictionary_ReturnsTrue()
        {
            ITypeSymbol dictType = new StubTypeSymbol("System.Collections.Generic.Dictionary<string, string>");

            bool result = TypeConversionHelper.IsDictionary(dictType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsDictionary returns false for a non-dictionary type.
        /// </summary>
        [Fact]
        public void IsDictionary_WithNonDictionaryType_ReturnsFalse()
        {
            ITypeSymbol listType = new StubTypeSymbol("System.Collections.Generic.List<string>");

            bool result = TypeConversionHelper.IsDictionary(listType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsDictionary returns false for a custom class.
        /// </summary>
        [Fact]
        public void IsDictionary_WithCustomClass_ReturnsFalse()
        {
            ITypeSymbol customType = new StubTypeSymbol("MyCustomClass");

            bool result = TypeConversionHelper.IsDictionary(customType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsDictionary returns false for null type.
        /// </summary>
        [Fact]
        public void IsDictionary_WithNullType_ReturnsFalse()
        {
            bool result = TypeConversionHelper.IsDictionary(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsComplexType returns false for special types.
        /// </summary>
        [Fact]
        public void IsComplexType_WithSpecialType_ReturnsFalse()
        {
            ITypeSymbol specialType = new StubTypeSymbol("System.Object", SpecialType.System_Object);

            bool result = TypeConversionHelper.IsComplexType(specialType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsComplexType returns false for enum types.
        /// </summary>
        [Fact]
        public void IsComplexType_WithEnumType_ReturnsFalse()
        {
            ITypeSymbol enumType = new StubTypeSymbol("MyEnum", SpecialType.None, TypeKind.Enum);

            bool result = TypeConversionHelper.IsComplexType(enumType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsComplexType returns true for a complex custom type.
        /// </summary>
        [Fact]
        public void IsComplexType_WithComplexType_ReturnsTrue()
        {
            ITypeSymbol complexType = new StubTypeSymbol("MyNamespace.MyClass");

            bool result = TypeConversionHelper.IsComplexType(complexType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsComplexType returns false for special built-in types.
        /// </summary>
        [Fact]
        public void IsComplexType_WithSpecialBuiltInTypes_ReturnsFalse()
        {
            ITypeSymbol dateTime = new StubTypeSymbol("System.DateTime");
            ITypeSymbol guid = new StubTypeSymbol("System.Guid");

            Assert.False(TypeConversionHelper.IsComplexType(dateTime));
            Assert.False(TypeConversionHelper.IsComplexType(guid));
        }

        /// <summary>
        ///     Tests that IsComplexType returns false for value types.
        /// </summary>
        [Fact]
        public void IsComplexType_WithValueType_ReturnsFalse()
        {
            ITypeSymbol valueType = new StubTypeSymbol("int", SpecialType.System_Int32);

            bool result = TypeConversionHelper.IsComplexType(valueType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsSpecialType returns true for known special types.
        /// </summary>
        [Fact]
        public void IsSpecialType_WithKnownSpecialTypes_ReturnsTrue()
        {
            Assert.True(TypeConversionHelper.IsSpecialType("System.DateTime"));
            Assert.True(TypeConversionHelper.IsSpecialType("System.DateTimeOffset"));
            Assert.True(TypeConversionHelper.IsSpecialType("System.Guid"));
            Assert.True(TypeConversionHelper.IsSpecialType("System.TimeSpan"));
            Assert.True(TypeConversionHelper.IsSpecialType("System.Uri"));
            Assert.True(TypeConversionHelper.IsSpecialType("System.Version"));
        }

        /// <summary>
        ///     Tests that IsSpecialType returns false for unknown types.
        /// </summary>
        [Fact]
        public void IsSpecialType_WithUnknownTypes_ReturnsFalse()
        {
            Assert.False(TypeConversionHelper.IsSpecialType("MyCustomClass"));
            Assert.False(TypeConversionHelper.IsSpecialType("System.String"));
            Assert.False(TypeConversionHelper.IsSpecialType("System.Int32"));
        }

        /// <summary>
        ///     Tests that IsSpecialType returns false for null.
        /// </summary>
        [Fact]
        public void IsSpecialType_WithNull_ReturnsFalse()
        {
            Assert.False(TypeConversionHelper.IsSpecialType(null));
        }

        /// <summary>
        ///     Tests that IsArrayType returns true for a 1D array.
        /// </summary>
        [Fact]
        public void IsArrayType_With1DArray_ReturnsTrue()
        {
            ITypeSymbol arrayType = new StubArrayTypeSymbol(new StubTypeSymbol("string"), 1);

            bool result = TypeConversionHelper.IsArrayType(arrayType, 1);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsArrayType returns true for a 2D array.
        /// </summary>
        [Fact]
        public void IsArrayType_With2DArray_ReturnsTrue()
        {
            ITypeSymbol arrayType = new StubArrayTypeSymbol(new StubTypeSymbol("int"), 2);

            bool result = TypeConversionHelper.IsArrayType(arrayType, 2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsArrayType returns false when rank does not match.
        /// </summary>
        [Fact]
        public void IsArrayType_WithWrongRank_ReturnsFalse()
        {
            ITypeSymbol arrayType = new StubArrayTypeSymbol(new StubTypeSymbol("string"), 2);

            bool result = TypeConversionHelper.IsArrayType(arrayType, 1);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsArrayType returns false for a non-array type.
        /// </summary>
        [Fact]
        public void IsArrayType_WithNonArrayType_ReturnsFalse()
        {
            ITypeSymbol nonArrayType = new StubTypeSymbol("string");

            bool result = TypeConversionHelper.IsArrayType(nonArrayType, 1);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsArrayType returns false for null.
        /// </summary>
        [Fact]
        public void IsArrayType_WithNull_ReturnsFalse()
        {
            bool result = TypeConversionHelper.IsArrayType(null, 1);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsReferenceType returns true for reference types.
        /// </summary>
        [Fact]
        public void IsReferenceType_WithReferenceType_ReturnsTrue()
        {
            ITypeSymbol referenceType = new StubTypeSymbol("string", isValueType: false);

            bool result = TypeConversionHelper.IsReferenceType(referenceType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsReferenceType returns false for value types.
        /// </summary>
        [Fact]
        public void IsReferenceType_WithValueType_ReturnsFalse()
        {
            ITypeSymbol valueType = new StubTypeSymbol("int", isValueType: true);

            bool result = TypeConversionHelper.IsReferenceType(valueType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsReferenceType returns false for null.
        /// </summary>
        [Fact]
        public void IsReferenceType_WithNull_ReturnsFalse()
        {
            bool result = TypeConversionHelper.IsReferenceType(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection returns true for a List with enumerable interface.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithMultipleInterfaces_ReturnsTrue()
        {
            ITypeSymbol listType = new StubNamedTypeSymbol(
                "System.Collections.Generic.List<byte>",
                new[] { new StubTypeSymbol("byte") },
                new[]
                {
                    new StubTypeSymbol("System.Collections.Generic.IEnumerable<byte>"),
                    new StubTypeSymbol("System.Collections.Generic.ICollection<byte>"),
                    new StubTypeSymbol("System.Collections.Generic.IList<byte>")
                });

            bool result = TypeConversionHelper.IsListOrCollection(listType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsComplexType returns true for a class with no special type.
        /// </summary>
        [Fact]
        public void IsComplexType_WithClass_NoSpecialType_ReturnsTrue()
        {
            ITypeSymbol classType = new StubNamedTypeSymbol("MyApp.Models.UserData");

            bool result = TypeConversionHelper.IsComplexType(classType);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsComplexType returns false for Nullable types.
        /// </summary>
        [Fact]
        public void IsComplexType_WithNullableType_ReturnsFalse()
        {
            ITypeSymbol nullableType = new StubTypeSymbol("System.Nullable<int>", SpecialType.System_Nullable_T);

            bool result = TypeConversionHelper.IsComplexType(nullableType);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsSpecialType handles edge case strings.
        /// </summary>
        [Fact]
        public void IsSpecialType_WithEdgeCaseStrings_ReturnsFalse()
        {
            Assert.False(TypeConversionHelper.IsSpecialType(""));
            Assert.False(TypeConversionHelper.IsSpecialType("System"));
            Assert.False(TypeConversionHelper.IsSpecialType("DateTime"));
        }

        /// <summary>
        ///     Tests that IsArrayType works with arrays of complex types.
        /// </summary>
        [Fact]
        public void IsArrayType_WithComplexElementType_ReturnsTrue()
        {
            ITypeSymbol complexArray = new StubArrayTypeSymbol(new StubNamedTypeSymbol("MyNamespace.UserData"), 1);

            bool result = TypeConversionHelper.IsArrayType(complexArray, 1);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection handles types with only some enumerable interfaces.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithOnlyIEnumerable_ReturnsTrue()
        {
            ITypeSymbol onlyEnumerable = new StubNamedTypeSymbol(
                "MyEnumerableWrapper",
                new[] { new StubTypeSymbol("string") },
                new[] { new StubTypeSymbol("System.Collections.Generic.IEnumerable<string>") });

            bool result = TypeConversionHelper.IsListOrCollection(onlyEnumerable);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that IsListOrCollection handles types with only ICollection interface.
        /// </summary>
        [Fact]
        public void IsListOrCollection_WithOnlyICollection_ReturnsTrue()
        {
            ITypeSymbol onlyCollection = new StubNamedTypeSymbol(
                "MyCollectionWrapper",
                new[] { new StubTypeSymbol("int") },
                new[] { new StubTypeSymbol("System.Collections.Generic.ICollection<int>") });

            bool result = TypeConversionHelper.IsListOrCollection(onlyCollection);

            Assert.True(result);
        }
    }
}
