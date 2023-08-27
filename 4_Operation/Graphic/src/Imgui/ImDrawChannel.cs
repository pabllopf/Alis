using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw channel
    /// </summary>
    public unsafe struct ImDrawChannel
    {
        /// <summary>
        /// The cmd buffer
        /// </summary>
        public ImVector _CmdBuffer;
        /// <summary>
        /// The idx buffer
        /// </summary>
        public ImVector _IdxBuffer;
    }
}
