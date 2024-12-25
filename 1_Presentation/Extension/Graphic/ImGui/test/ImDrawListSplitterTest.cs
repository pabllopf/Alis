// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListSplitterTest.cs
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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im draw list splitter test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImDrawListSplitterTest 
    {
        /// <summary>
        ///     Tests that current should set and get correctly
        /// </summary>
        [Fact]
        public void Current_Should_SetAndGetCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            splitter.Current = 1;
            Assert.Equal(1, splitter.Current);
        }

        /// <summary>
        ///     Tests that count should set and get correctly
        /// </summary>
        [Fact]
        public void Count_Should_SetAndGetCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            splitter.Count = 2;
            Assert.Equal(2, splitter.Count);
        }

        /// <summary>
        ///     Tests that channels should set and get correctly
        /// </summary>
        [Fact]
        public void Channels_Should_SetAndGetCorrectly()
        {
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            ImVector channels = new ImVector();
            splitter.Channels = channels;
            Assert.Equal(channels, splitter.Channels);
        }
    }
}