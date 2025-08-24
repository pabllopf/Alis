#if OSX
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NsRect
    {
        public double x;
        public double y;
        public double width;
        public double height;
    }
}
#endif