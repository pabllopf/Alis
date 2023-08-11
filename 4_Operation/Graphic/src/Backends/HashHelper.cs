namespace Veldrid
{
    /// <summary>
    /// The hash helper class
    /// </summary>
    internal static class HashHelper
    {
        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2)
        {
            uint rol5 = ((uint)value1 << 5) | ((uint)value1 >> 27);
            return ((int)rol5 + value1) ^ value2;
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3)
        {
            return Combine(value1, Combine(value2, value3));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4)
        {
            return Combine(value1, Combine(value2, Combine(value3, value4)));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4, int value5)
        {
            return Combine(value1, Combine(value2, Combine(value3, Combine(value4, value5))));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4, int value5, int value6)
        {
            return Combine(value1, Combine(value2, Combine(value3, Combine(value4, Combine(value5, value6)))));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <param name="value7">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4, int value5, int value6, int value7)
        {
            return Combine(value1, Combine(value2, Combine(value3, Combine(value4, Combine(value5, Combine(value6, value7))))));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <param name="value7">The value</param>
        /// <param name="value8">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8)
        {
            return Combine(value1, Combine(value2, Combine(value3, Combine(value4, Combine(value5, Combine(value6, Combine(value7, value8)))))));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <param name="value7">The value</param>
        /// <param name="value8">The value</param>
        /// <param name="value9">The value</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9)
        {
            return Combine(value1, Combine(value2, Combine(value3, Combine(value4, Combine(value5, Combine(value6, Combine(value7, Combine(value8, value9))))))));
        }

        /// <summary>
        /// Combines the value 1
        /// </summary>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <param name="value7">The value</param>
        /// <param name="value8">The value</param>
        /// <param name="value9">The value</param>
        /// <param name="value10">The value 10</param>
        /// <returns>The int</returns>
        public static int Combine(int value1, int value2, int value3, int value4, int value5, int value6, int value7, int value8, int value9, int value10)
        {
            return Combine(value1, Combine(value2, Combine(value3, Combine(value4, Combine(value5, Combine(value6, Combine(value7, Combine(value8, Combine(value9, value10)))))))));
        }

        /// <summary>
        /// Arrays the items
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="items">The items</param>
        /// <returns>The hash</returns>
        public static int Array<T>(T[] items)
        {
            if (items == null || items.Length == 0)
            {
                return 0;
            }

            int hash = items[0].GetHashCode();
            for (int i = 1; i < items.Length; i++)
            {
                hash = Combine(hash, items[i]?.GetHashCode() ?? i);
            }

            return hash;
        }
    }
}
