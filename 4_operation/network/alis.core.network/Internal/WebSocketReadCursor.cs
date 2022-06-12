// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WebSocketReadCursor.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Network.Internal
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

        // Number of bytes read in the last read operation
        /// <summary>
        ///     Gets the value of the num bytes read
        /// </summary>
        public int NumBytesRead { get; }

        // Number of bytes remaining to read before we are done reading the entire frame
        /// <summary>
        ///     Gets the value of the num bytes left to read
        /// </summary>
        public int NumBytesLeftToRead { get; }
    }
}