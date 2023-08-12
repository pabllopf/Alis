using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui input text callback
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int ImGuiInputTextCallback(ImGuiInputTextCallbackData* data);
}
