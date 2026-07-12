// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawChannelTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw channel test class
    /// </summary>
    public class ImDrawChannelTest
    {
        /// <summary>
        ///     Tests that cmd buffer should be initialized correctly
        /// </summary>
        [Fact]
        public void CmdBuffer_ShouldBeInitializedCorrectly()
        {
            ImDrawChannel drawChannel = new ImDrawChannel();

            ImVector cmdBuffer = drawChannel.CmdBuffer;

            Assert.Equal(0, cmdBuffer.Size);
        }

        /// <summary>
        ///     Tests that idx buffer should be initialized correctly
        /// </summary>
        [Fact]
        public void IdxBuffer_ShouldBeInitializedCorrectly()
        {
            ImDrawChannel drawChannel = new ImDrawChannel();

            ImVector idxBuffer = drawChannel.IdxBuffer;

            Assert.Equal(0, idxBuffer.Size);
        }

        /// <summary>
        ///     Tests that cmd buffer ptr should return correct value
        /// </summary>
        [Fact]
        public void CmdBufferPtr_ShouldReturnCorrectValue()
        {
            ImDrawChannel drawChannel = new ImDrawChannel
            {
                CmdBuffer = new ImVector()
            };

            ImVectorG<ImDrawCmd> cmdBufferPtr = drawChannel.CmdBufferPtr;

            Assert.Equal(0, cmdBufferPtr.Size);
        }

        /// <summary>
        ///     Tests that idx buffer ptr should return correct value
        /// </summary>
        [Fact]
        public void IdxBufferPtr_ShouldReturnCorrectValue()
        {
            ImDrawChannel drawChannel = new ImDrawChannel
            {
                IdxBuffer = new ImVector()
            };

            ImVectorG<ushort> idxBufferPtr = drawChannel.IdxBufferPtr;

            Assert.Equal(0, idxBufferPtr.Size);
        }
    }
}