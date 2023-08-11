using System.Text;

namespace Veldrid.MetalBindings
{
    /// <summary>
    /// The mtl util class
    /// </summary>
    public static class MTLUtil
    {
        /// <summary>
        /// Gets the utf 8 string using the specified string start
        /// </summary>
        /// <param name="stringStart">The string start</param>
        /// <returns>The string</returns>
        public static unsafe string GetUtf8String(byte* stringStart)
        {
            int characters = 0;
            while (stringStart[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(stringStart, characters);
        }

        /// <summary>
        /// Allocs the init using the specified type name
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="typeName">The type name</param>
        /// <returns>The</returns>
        public static T AllocInit<T>(string typeName) where T : struct
        {
            var cls = new ObjCClass(typeName);
            return cls.AllocInit<T>();
        }
    }
}