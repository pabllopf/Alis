

using System;
using System.Net.WebSockets;

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     The web socket frame class
    /// </summary>
    internal class WebSocketFrame
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketFrame" /> class
        /// </summary>
        /// <param name="isFinBitSet">The is fin bit set</param>
        /// <param name="webSocketOpCode">The web socket op code</param>
        /// <param name="count">The count</param>
        /// <param name="maskKey">The mask key</param>
        public WebSocketFrame(bool isFinBitSet, WebSocketOpCode webSocketOpCode, int count, ArraySegment<byte> maskKey)
        {
            IsFinBitSet = isFinBitSet;
            OpCode = webSocketOpCode;
            Count = count;
            MaskKey = maskKey;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketFrame" /> class
        /// </summary>
        /// <param name="isFinBitSet">The is fin bit set</param>
        /// <param name="webSocketOpCode">The web socket op code</param>
        /// <param name="count">The count</param>
        /// <param name="closeStatus">The close status</param>
        /// <param name="closeStatusDescription">The close status description</param>
        /// <param name="maskKey">The mask key</param>
        public WebSocketFrame(bool isFinBitSet, WebSocketOpCode webSocketOpCode, int count,
            WebSocketCloseStatus closeStatus, string closeStatusDescription, ArraySegment<byte> maskKey) : this(
            isFinBitSet, webSocketOpCode, count, maskKey)
        {
            CloseStatus = closeStatus;
            CloseStatusDescription = closeStatusDescription;
        }

        /// <summary>
        ///     Gets the value of the is fin bit set
        /// </summary>
        public bool IsFinBitSet { get; }

        /// <summary>
        ///     Gets the value of the op code
        /// </summary>
        public WebSocketOpCode OpCode { get; }

        /// <summary>
        ///     Gets the value of the count
        /// </summary>
        public int Count { get; }

        /// <summary>
        ///     Gets the value of the close status
        /// </summary>
        public WebSocketCloseStatus? CloseStatus { get; }

        /// <summary>
        ///     Gets the value of the close status description
        /// </summary>
        public string CloseStatusDescription { get; }

        /// <summary>
        ///     Gets the value of the mask key
        /// </summary>
        public ArraySegment<byte> MaskKey { get; }
    }
}