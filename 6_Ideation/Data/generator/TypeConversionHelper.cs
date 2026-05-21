

using System.Linq;
using Microsoft.CodeAnalysis;

namespace Alis.Core.Aspect.Data.Generator
{
    /// <summary>
    ///     Helper class for type conversion and detection in code generation.
    /// </summary>
    internal static class TypeConversionHelper
    {
        /// <summary>
        ///     Determines whether the specified type is a list or enumerable collection.
        /// </summary>
        /// <param name="type">The type symbol to check.</param>
        /// <returns>True if the type is a list or enumerable collection; otherwise, false.</returns>
        internal static bool IsListOrCollection(ITypeSymbol type)
        {
            if (type is not INamedTypeSymbol namedType || namedType.TypeArguments.Length != 1)
            {
                return false;
            }

            return type.AllInterfaces.Any(i =>
                i.ToDisplayString().StartsWith("System.Collections.Generic.IEnumerable") ||
                i.ToDisplayString().StartsWith("System.Collections.Generic.ICollection") ||
                i.ToDisplayString().StartsWith("System.Collections.Generic.IList"));
        }

        /// <summary>
        ///     Determines whether the specified type is a dictionary.
        /// </summary>
        /// <param name="type">The type symbol to check.</param>
        /// <returns>True if the type is a dictionary; otherwise, false.</returns>
        internal static bool IsDictionary(ITypeSymbol type) => type.ToDisplayString().StartsWith("System.Collections.Generic.Dictionary");

        /// <summary>
        ///     Determines whether the specified type is a complex type (not a primitive).
        /// </summary>
        /// <param name="type">The type symbol to check.</param>
        /// <returns>True if the type is complex; otherwise, false.</returns>
        internal static bool IsComplexType(ITypeSymbol type)
        {
            if (type.SpecialType != SpecialType.None)
            {
                return false;
            }

            if (type.TypeKind == TypeKind.Enum)
            {
                return false;
            }

            string displayName = type.ToDisplayString();
            return !IsSpecialType(displayName);
        }

        /// <summary>
        ///     Determines whether the specified type name represents a special built-in type.
        /// </summary>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>True if the type is a special built-in type; otherwise, false.</returns>
        internal static bool IsSpecialType(string typeName) => typeName is
            "System.DateTime" or
            "System.DateTimeOffset" or
            "System.Guid" or
            "System.TimeSpan" or
            "System.Uri" or
            "System.Version";

        /// <summary>
        ///     Determines whether the specified type is an array type.
        /// </summary>
        /// <param name="type">The type symbol to check.</param>
        /// <param name="rank">The rank of the array (1 for single-dimensional, 2 for two-dimensional, etc.).</param>
        /// <returns>True if the type is an array of the specified rank; otherwise, false.</returns>
        internal static bool IsArrayType(ITypeSymbol type, int rank = 1) => type is IArrayTypeSymbol arrayType && (arrayType.Rank == rank);

        /// <summary>
        ///     Determines whether the specified type is a nullable reference type.
        /// </summary>
        /// <param name="type">The type symbol to check.</param>
        /// <returns>True if the type is a reference type (not a value type); otherwise, false.</returns>
        internal static bool IsReferenceType(ITypeSymbol type) => !type.IsValueType;
    }
}