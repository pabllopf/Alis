

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw channel
    /// </summary>
    public struct ImDrawChannel
    {
        /// <summary>
        ///     The cmd buffer
        /// </summary>
        public ImVector CmdBuffer { get; set; }

        /// <summary>
        ///     The idx buffer
        /// </summary>
        public ImVector IdxBuffer { get; set; }

        /// <summary>
        ///     Gets the value of the cmd buffer ptr
        /// </summary>
        public ImVectorG<ImDrawCmd> CmdBufferPtr => new ImVectorG<ImDrawCmd>(CmdBuffer);

        /// <summary>
        ///     Gets the value of the idx buffer ptr
        /// </summary>
        public ImVectorG<ushort> IdxBufferPtr => new ImVectorG<ushort>(IdxBuffer);
    }
}