using System.Text;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The utilities class
    /// </summary>
    internal static class Utilities
    {
        /// <summary>
        /// Gets the string using the specified string start
        /// </summary>
        /// <param name="stringStart">The string start</param>
        /// <returns>The string</returns>
        public static unsafe string GetString(byte* stringStart)
        {
            if (stringStart == null) { return null; }

            int characters = 0;
            while (stringStart[characters] != 0)
            {
                characters++;
            }

            return Encoding.UTF8.GetString(stringStart, characters);
        }
    }
}
