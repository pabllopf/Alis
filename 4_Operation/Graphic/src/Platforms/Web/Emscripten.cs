using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    /// The emscripten class
    /// </summary>
    public static class Emscripten
    {
        /// <summary>
        /// Requests the animation frame loop using the specified f
        /// </summary>
        /// <param name="f">The </param>
        /// <param name="userDataPtr">The user data ptr</param>
        [DllImport("emscripten", EntryPoint = "emscripten_request_animation_frame_loop")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        public static extern void RequestAnimationFrameLoop(IntPtr f, nint userDataPtr);
    }
}
