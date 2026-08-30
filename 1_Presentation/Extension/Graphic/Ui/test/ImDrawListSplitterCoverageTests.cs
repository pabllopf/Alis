// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListSplitterCoverageTests.cs
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
    ///     The im draw list splitter coverage tests class
    /// </summary>
    public class ImDrawListSplitterCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImDrawListSplitter_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImDrawListSplitter splitter = default(ImDrawListSplitter);

            Assert.Equal(0, splitter.Current);
            Assert.Equal(0, splitter.Count);
            Assert.Equal(0, splitter.Channels.Size);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImDrawListSplitter_SetProperties_StoresValuesCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter
            {
                Current = 1,
                Count = 2,
                Channels = new ImVector { Size = 3, Capacity = 4, Data = new IntPtr(5) }
            };

            Assert.Equal(1, splitter.Current);
            Assert.Equal(2, splitter.Count);
            Assert.Equal(3, splitter.Channels.Size);
            Assert.Equal(4, splitter.Channels.Capacity);
            Assert.Equal(new IntPtr(5), splitter.Channels.Data);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImDrawListSplitter_IsValueType_CopyIsIndependent()
        {
            ImDrawListSplitter original = new ImDrawListSplitter { Current = 10 };
            ImDrawListSplitter copy = original;

            copy.Current = 20;

            Assert.Equal(10, original.Current);
            Assert.Equal(20, copy.Current);
        }
    }
}