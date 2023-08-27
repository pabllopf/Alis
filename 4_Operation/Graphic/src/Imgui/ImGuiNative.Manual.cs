using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui native class
    /// </summary>
    public static unsafe partial class ImGuiNative
    {
        /// <summary>
        /// Ims the gui platform io set platform get window pos using the specified platform io
        /// </summary>
        /// <param name="platformIo">The platform io</param>
        /// <param name="funcPtr">The func ptr</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPlatformIO_Set_Platform_GetWindowPos(ImGuiPlatformIo* platformIo, IntPtr funcPtr);
        /// <summary>
        /// Ims the gui platform io set platform get window size using the specified platform io
        /// </summary>
        /// <param name="platformIo">The platform io</param>
        /// <param name="funcPtr">The func ptr</param>
        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGuiPlatformIO_Set_Platform_GetWindowSize(ImGuiPlatformIo* platformIo, IntPtr funcPtr);
    }
}
