using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The get shader info log del
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void GetShaderInfoLogDel(uint shader, int maxLength, [Out] int[] length, [Out] StringBuilder infoLog);
}