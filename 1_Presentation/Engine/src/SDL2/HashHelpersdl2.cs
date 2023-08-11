namespace Veldrid
{
    /// <summary>
    /// The hash helpersdl class
    /// </summary>
    internal static class HashHelpersdl2
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
    }
}
