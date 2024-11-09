using System;

namespace Alis.Extension.Graphic.Sdl2Image
{
    /// <summary>
    /// The img init flags enum
    /// </summary>
    [Flags]
    public enum ImgInitFlags
    {
        /// <summary>
        /// The img init jpg img init flags
        /// </summary>
        ImgInitJpg =	0x00000001,
        /// <summary>
        /// The img init png img init flags
        /// </summary>
        ImgInitPng =	0x00000002,
        /// <summary>
        /// The img init tif img init flags
        /// </summary>
        ImgInitTif =	0x00000004,
        /// <summary>
        /// The img init webp img init flags
        /// </summary>
        ImgInitWebp =	0x00000008
    }
}