// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawChannel.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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