

using System;

namespace Alis.Extension.Graphic.Sdl2.Sdl2Image
{
    /// <summary>
    ///     The img animation
    /// </summary>
    public struct ImgAnimation
    {
        /// <summary>
        ///     Gets or sets the width
        /// </summary>
        public int W { get; set; }

        /// <summary>
        ///     Gets or sets the height
        /// </summary>
        public int H { get; set; }

        /// <summary>
        ///     Gets or sets the frames
        /// </summary>
        public IntPtr Frames { get; set; }

        /// <summary>
        ///     Gets or sets the delays
        /// </summary>
        public IntPtr Delays { get; set; }
    }
}