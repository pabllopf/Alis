// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawChannelRemainingCoverageTests.cs
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

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw channel remaining coverage tests class
    /// </summary>
    public class ImDrawChannelRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default cmd buffer and idx buffer are default
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_CmdBufferAndIdxBufferAreDefault()
        {
            ImDrawChannel channel = default;
            Assert.Equal(0, channel.CmdBuffer.Size);
            Assert.Equal(0, channel.CmdBuffer.Capacity);
            Assert.Equal(IntPtr.Zero, channel.CmdBuffer.Data);
            Assert.Equal(0, channel.IdxBuffer.Size);
            Assert.Equal(0, channel.IdxBuffer.Capacity);
            Assert.Equal(IntPtr.Zero, channel.IdxBuffer.Data);
        }

        /// <summary>
        ///     Tests that cmd buffer round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void CmdBuffer_RoundTrip()
        {
            ImDrawChannel channel = default;
            ImVector v = new ImVector(10, 20, new IntPtr(1234));
            channel.CmdBuffer = v;
            Assert.Equal(10, channel.CmdBuffer.Size);
            Assert.Equal(20, channel.CmdBuffer.Capacity);
            Assert.Equal(new IntPtr(1234), channel.CmdBuffer.Data);
        }

        /// <summary>
        ///     Tests that idx buffer round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void IdxBuffer_RoundTrip()
        {
            ImDrawChannel channel = default;
            ImVector v = new ImVector(5, 15, new IntPtr(5678));
            channel.IdxBuffer = v;
            Assert.Equal(5, channel.IdxBuffer.Size);
            Assert.Equal(15, channel.IdxBuffer.Capacity);
            Assert.Equal(new IntPtr(5678), channel.IdxBuffer.Data);
        }

        /// <summary>
        ///     Tests that cmd buffer ptr returns new wrapper
        /// </summary>
         [RequireCImguiSystemFact]
        public void CmdBufferPtr_ReturnsNewWrapper()
        {
            ImDrawChannel channel = default;
            ImVectorG<ImDrawCmd> ptr = channel.CmdBufferPtr;
        }

        /// <summary>
        ///     Tests that idx buffer ptr returns new wrapper
        /// </summary>
         [RequireCImguiSystemFact]
        public void IdxBufferPtr_ReturnsNewWrapper()
        {
            ImDrawChannel channel = default;
            ImVectorG<ushort> ptr = channel.IdxBufferPtr;
        }
    }
}
