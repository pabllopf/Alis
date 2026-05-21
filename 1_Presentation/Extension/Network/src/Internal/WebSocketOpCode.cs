

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     The web socket op code enum
    /// </summary>
    internal enum WebSocketOpCode
    {
        /// <summary>
        ///     The continuation frame web socket op code
        /// </summary>
        ContinuationFrame = 0,

        /// <summary>
        ///     The text frame web socket op code
        /// </summary>
        TextFrame = 1,

        /// <summary>
        ///     The binary frame web socket op code
        /// </summary>
        BinaryFrame = 2,

        /// <summary>
        ///     The connection close web socket op code
        /// </summary>
        ConnectionClose = 8,

        /// <summary>
        ///     The ping web socket op code
        /// </summary>
        Ping = 9,

        /// <summary>
        ///     The pong web socket op code
        /// </summary>
        Pong = 10
    }
}