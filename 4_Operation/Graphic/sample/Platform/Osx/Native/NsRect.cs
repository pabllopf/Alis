#if OSX
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sample.Platform.Osx.Internal
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