#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)

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
        
            if (type.IsPrimitive || type.IsPointer) return false;
        
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                if (IsReferenceOrContainsReferences(fields[i].FieldType))
                    return true;
            }
            return false;
        }

        private static class Cache<T>
        {
            public static readonly bool Value = IsReferenceOrContainsReferences(typeof(T));
        }
    }
}

#endif