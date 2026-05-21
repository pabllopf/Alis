

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal kms wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalKmsWmInfo
    {
        /// <summary>
        ///     The dev index
        /// </summary>
        public readonly int dev_index;

        /// <summary>
        ///     The drm fd
        /// </summary>
        public readonly int drm_fd;

        /// <summary>
        ///     Refers to a gbm_device*
        /// </summary>
        public readonly IntPtr gbm_dev;
    }
}