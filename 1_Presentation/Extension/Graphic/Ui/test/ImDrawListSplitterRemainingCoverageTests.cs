// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListSplitterRemainingCoverageTests.cs
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
    ///     The im draw list splitter remaining coverage tests class
    /// </summary>
    public class ImDrawListSplitterRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImDrawListSplitter splitter = default;
            Assert.Equal(0, splitter.Current);
            Assert.Equal(0, splitter.Count);
            Assert.Equal(0, splitter.Channels.Size);
            Assert.Equal(0, splitter.Channels.Capacity);
            Assert.Equal(IntPtr.Zero, splitter.Channels.Data);
        }

        /// <summary>
        ///     Tests that current round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Current_RoundTrip()
        {
            ImDrawListSplitter splitter = default;
            splitter.Current = 5;
            Assert.Equal(5, splitter.Current);
        }

        /// <summary>
        ///     Tests that count round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Count_RoundTrip()
        {
            ImDrawListSplitter splitter = default;
            splitter.Count = 10;
            Assert.Equal(10, splitter.Count);
        }

        /// <summary>
        ///     Tests that channels round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Channels_RoundTrip()
        {
            ImDrawListSplitter splitter = default;
            ImVector v = new ImVector(3, 6, new IntPtr(999));
            splitter.Channels = v;
            Assert.Equal(3, splitter.Channels.Size);
            Assert.Equal(6, splitter.Channels.Capacity);
            Assert.Equal(new IntPtr(999), splitter.Channels.Data);
        }
    }
}
