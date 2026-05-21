

using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw cmd header
    /// </summary>
    public struct ImDrawCmdHeader
    {
        /// <summary>
        ///     The clip rect
        /// </summary>
        public Vector4F ClipRect { get; set; }

        /// <summary>
        ///     The texture id
        /// </summary>
        public IntPtr TextureId { get; set; }

        /// <summary>
        ///     The vtx offset
        /// </summary>
        public uint VtxOffset { get; set; }
    }
}