#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)

using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices
{
    
    /// <summary>
    /// 
    /// </summary>
    public static class RuntimeHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsReferenceOrContainsReferences<T>()
        {
            return Cache<T>.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsReferenceOrContainsReferences(Type type)
        {
            if (!type.IsValueType) return true;
        
            if (type.IsPrimitive || type.IsPointer) return false;
        
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                if (IsReferenceOrContainsReferences(fields[i].FieldType))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private static class Cache<T>
        {
            public static readonly bool Value = IsReferenceOrContainsReferences(typeof(T));
        }
    }
}

#endif