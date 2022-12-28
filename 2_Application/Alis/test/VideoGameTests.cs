// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoGameTests.cs
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

using Alis.Builder;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     The video game tests class
    /// </summary>
    public class VideoGameTests
    {
        /// <summary>
        ///     Tests that builder should return a video game builder
        /// </summary>
        [Fact]
        public void Builder_Should_Return_A_VideoGameBuilder() => Assert.Equal(typeof(VideoGameBuilder), VideoGame.Builder().GetType());

        /// <summary>
        ///     Tests that builder dont should return a null
        /// </summary>
        [Fact]
        public void Builder_Dont_Should_Return_A_Null() => Assert.NotNull(VideoGame.Builder());

        /// <summary>
        ///     Tests that get of setting dont should return a null value
        /// </summary>
        [Fact]
        public void Get_Of_Setting_Dont_Should_Return_A_Null_Value() => Assert.NotNull(VideoGame.Setting);
    }
}