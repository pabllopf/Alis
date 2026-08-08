// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditStateRemainingCoverageTests.cs
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
    ///     The stb textedit state remaining coverage tests class
    /// </summary>
    public class StbTexteditStateRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default cursor should be zero
        /// </summary>
        [Fact]
        public void DefaultCursor_ShouldBeZero()
        {
            StbTexteditState state = default;
            Assert.Equal(0, state.Cursor);
        }

        /// <summary>
        ///     Tests that default select start should be zero
        /// </summary>
        [Fact]
        public void DefaultSelectStart_ShouldBeZero()
        {
            StbTexteditState state = default;
            Assert.Equal(0, state.SelectStart);
        }

        /// <summary>
        ///     Tests that default select end should be zero
        /// </summary>
        [Fact]
        public void DefaultSelectEnd_ShouldBeZero()
        {
            StbTexteditState state = default;
            Assert.Equal(0, state.SelectEnd);
        }

        /// <summary>
        ///     Tests that default insert mode should be zero
        /// </summary>
        [Fact]
        public void DefaultInsertMode_ShouldBeZero()
        {
            StbTexteditState state = default;
            Assert.Equal((byte)0, state.InsertMode);
        }

        /// <summary>
        ///     Tests that default row count per page should be zero
        /// </summary>
        [Fact]
        public void DefaultRowCountPerPage_ShouldBeZero()
        {
            StbTexteditState state = default;
            Assert.Equal(0, state.RowCountPerPage);
        }

        /// <summary>
        ///     Tests that cursor set and get returns correct value
        /// </summary>
        [Fact]
        public void Cursor_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = default;
            state.Cursor = 5;
            Assert.Equal(5, state.Cursor);
        }

        /// <summary>
        ///     Tests that select start set and get returns correct value
        /// </summary>
        [Fact]
        public void SelectStart_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = default;
            state.SelectStart = 10;
            Assert.Equal(10, state.SelectStart);
        }

        /// <summary>
        ///     Tests that select end set and get returns correct value
        /// </summary>
        [Fact]
        public void SelectEnd_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = default;
            state.SelectEnd = 15;
            Assert.Equal(15, state.SelectEnd);
        }

        /// <summary>
        ///     Tests that insert mode set and get returns correct value
        /// </summary>
        [Fact]
        public void InsertMode_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = default;
            state.InsertMode = 1;
            Assert.Equal((byte)1, state.InsertMode);
        }

        /// <summary>
        ///     Tests that row count per page set and get returns correct value
        /// </summary>
        [Fact]
        public void RowCountPerPage_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = default;
            state.RowCountPerPage = 20;
            Assert.Equal(20, state.RowCountPerPage);
        }

        /// <summary>
        ///     Tests that preferred x set and get returns correct value
        /// </summary>
        [Fact]
        public void PreferredX_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = default;
            state.PreferredX = 1.5f;
            Assert.Equal(1.5f, state.PreferredX, 5);
        }
    }
}
