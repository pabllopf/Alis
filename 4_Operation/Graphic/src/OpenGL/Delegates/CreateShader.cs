using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL.Delegates
{
    /// <summary>
    ///     The create shader
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate uint CreateShader(ShaderType shaderType);
}