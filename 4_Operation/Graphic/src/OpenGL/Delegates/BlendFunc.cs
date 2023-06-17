using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The blend func
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void BlendFunc(BlendingFactorSrc sfactor, BlendingFactorDest dfactor);
}