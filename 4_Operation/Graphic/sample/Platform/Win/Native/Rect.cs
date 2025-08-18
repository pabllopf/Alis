#if WIN

using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sample.Platform.Win.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}

#endif