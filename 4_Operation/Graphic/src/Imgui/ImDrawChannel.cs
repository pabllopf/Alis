using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw channel
    /// </summary>
    public struct ImDrawChannel
    {
        /// <summary>
        /// The cmd buffer
        /// </summary>
        public ImVector CmdBuffer;
        /// <summary>
        /// The idx buffer
        /// </summary>
        public ImVector IdxBuffer;
    }
}
