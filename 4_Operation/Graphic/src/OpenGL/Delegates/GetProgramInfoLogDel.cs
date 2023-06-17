using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The get program info log del
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void GetProgramInfoLogDel(uint program, int maxLength, [Out] int[] length, [Out] StringBuilder infoLog);
}