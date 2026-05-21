

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     The web socket read cursor class
    /// </summary>
    internal class WebSocketReadCursor
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WebSocketReadCursor" /> class
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <param name="numBytesRead">The num bytes read</param>
        /// <param name="numBytesLeftToRead">The num bytes left to read</param>
        public WebSocketReadCursor(WebSocketFrame frame, int numBytesRead, int numBytesLeftToRead)
        {
            WebSocketFrame = frame;
            NumBytesRead = numBytesRead;
            NumBytesLeftToRead = numBytesLeftToRead;
        }

        /// <summary>
        ///     Gets the value of the web socket frame
        /// </summary>
        public WebSocketFrame WebSocketFrame { get; }

        /// <summary>
        ///     Gets the value of the num bytes read
        /// </summary>
        public int NumBytesRead { get; }

        /// <summary>
        ///     Gets the value of the num bytes left to read
        /// </summary>
        public int NumBytesLeftToRead { get; }
    }
}