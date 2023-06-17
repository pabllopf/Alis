using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The gen buffers
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void GenBuffers(int n, [Out] uint[] buffers);
}