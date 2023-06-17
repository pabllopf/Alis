using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The create program
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate uint CreateProgram();
}