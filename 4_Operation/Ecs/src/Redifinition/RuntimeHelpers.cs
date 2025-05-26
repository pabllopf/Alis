#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    public static class RuntimeHelpers
    {
        public static bool IsReferenceOrContainsReferences<T>()
        {
            return Cache<T>.Value;
        }

        private static bool IsReferenceOrContainsReferences(Type type)
        {
            if (!type.IsValueType) return true;

            if (type.IsPrimitive || type.IsPointer || type.IsPointer) return false;

            return type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(f => IsReferenceOrContainsReferences(f.FieldType));
        }

        private static class Cache<T>
        {
            public static readonly bool Value = IsReferenceOrContainsReferences(typeof(T));
        }
    }
}

#endif