using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The range accessor extensions class
    /// </summary>
    public static class RangeAccessorExtensions
    {
        /// <summary>
        /// Gets the string ascii using the specified string accessor
        /// </summary>
        /// <param name="stringAccessor">The string accessor</param>
        /// <returns>The string</returns>
        public static unsafe string GetStringAscii(this RangeAccessor<byte> stringAccessor)
        {
            return Encoding.ASCII.GetString((byte*)stringAccessor.Data, stringAccessor.Count);
        }
    }
}