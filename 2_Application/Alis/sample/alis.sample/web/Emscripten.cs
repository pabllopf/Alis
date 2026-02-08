using System.Runtime.InteropServices;

namespace Alis.Sample.Web
{
    /// <summary>
    /// The emscripten class
    /// </summary>
    internal static class Emscripten
    {
        /// <summary>
        /// Requests the animation frame loop using the specified f
        /// </summary>
        /// <param name="f">The </param>
        /// <param name="userDataPtr">The user data ptr</param>
        [DllImport("emscripten", EntryPoint = "emscripten_request_animation_frame_loop")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        internal static extern unsafe void RequestAnimationFrameLoop(void* f, nint userDataPtr);
    }
}
