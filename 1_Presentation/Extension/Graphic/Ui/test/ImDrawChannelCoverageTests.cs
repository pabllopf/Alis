// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawChannelCoverageTests.cs
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
    ///     The im draw channel coverage tests class
    /// </summary>
    public class ImDrawChannelCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImDrawChannel_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImDrawChannel channel = default(ImDrawChannel);

            Assert.Equal(0, channel.CmdBuffer.Size);
            Assert.Equal(0, channel.IdxBuffer.Size);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImDrawChannel_SetProperties_StoresValuesCorrectly()
        {
            ImDrawChannel channel = new ImDrawChannel
            {
                CmdBuffer = new ImVector { Size = 1, Capacity = 2, Data = new IntPtr(4) },
                IdxBuffer = new ImVector { Size = 3, Capacity = 4, Data = new IntPtr(8) }
            };

            Assert.Equal(1, channel.CmdBuffer.Size);
            Assert.Equal(2, channel.CmdBuffer.Capacity);
            Assert.Equal(new IntPtr(4), channel.CmdBuffer.Data);
            Assert.Equal(3, channel.IdxBuffer.Size);
            Assert.Equal(4, channel.IdxBuffer.Capacity);
            Assert.Equal(new IntPtr(8), channel.IdxBuffer.Data);
        }

        /// <summary>
        ///     Tests that the computed buffer ptr properties reflect the underlying vectors
        /// </summary>
        [Fact]
        public void ImDrawChannel_GetBufferPtr_ReflectsUnderlyingVectors()
        {
            ImDrawChannel channel = new ImDrawChannel
            {
                CmdBuffer = new ImVector { Size = 2, Capacity = 4, Data = new IntPtr(16) },
                IdxBuffer = new ImVector { Size = 3, Capacity = 6, Data = new IntPtr(32) }
            };

            Assert.Equal(2, channel.CmdBufferPtr.Size);
            Assert.Equal(4, channel.CmdBufferPtr.Capacity);
            Assert.Equal(new IntPtr(16), channel.CmdBufferPtr.Data);
            Assert.Equal(3, channel.IdxBufferPtr.Size);
            Assert.Equal(6, channel.IdxBufferPtr.Capacity);
            Assert.Equal(new IntPtr(32), channel.IdxBufferPtr.Data);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImDrawChannel_IsValueType_CopyIsIndependent()
        {
            ImDrawChannel original = new ImDrawChannel { CmdBuffer = new ImVector { Size = 5 } };
            ImDrawChannel copy = original;

            copy.CmdBuffer = new ImVector { Size = 50 };

            Assert.Equal(5, original.CmdBuffer.Size);
            Assert.Equal(50, copy.CmdBuffer.Size);
        }
    }
}