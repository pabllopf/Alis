// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditStateCoverageTests.cs
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

using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests for the <see cref="StbTexteditState" /> struct.
    /// </summary>
    public class StbTexteditStateCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
        [Fact]
        public void Default_ValuesAreZero()
        {
            StbTexteditState state = default;

            Assert.Equal(0, state.Cursor);
            Assert.Equal(0, state.SelectStart);
            Assert.Equal(0, state.SelectEnd);
            Assert.Equal(0, state.InsertMode);
            Assert.Equal(0, state.RowCountPerPage);
            Assert.Equal(0, state.CursorAtEndOfLine);
            Assert.Equal(0, state.Initialized);
            Assert.Equal(0, state.HasPreferredX);
            Assert.Equal(0, state.SingleLine);
            Assert.Equal(0, state.Padding1);
            Assert.Equal(0, state.Padding2);
            Assert.Equal(0, state.Padding3);
            Assert.Equal(0f, state.PreferredX, 5);
        }

        /// <summary>
        ///     Verifies that integer properties round-trip.
        /// </summary>
        [Fact]
        public void IntProperties_RoundTrip()
        {
            StbTexteditState state = new StbTexteditState();

            state.Cursor = 5;
            state.SelectStart = 2;
            state.SelectEnd = 9;
            state.RowCountPerPage = 25;

            Assert.Equal(5, state.Cursor);
            Assert.Equal(2, state.SelectStart);
            Assert.Equal(9, state.SelectEnd);
            Assert.Equal(25, state.RowCountPerPage);
        }

        /// <summary>
        ///     Verifies that byte properties round-trip.
        /// </summary>
        [Fact]
        public void ByteProperties_RoundTrip()
        {
            StbTexteditState state = new StbTexteditState();

            state.InsertMode = 1;
            state.CursorAtEndOfLine = 1;
            state.Initialized = 1;
            state.HasPreferredX = 1;
            state.SingleLine = 1;
            state.Padding1 = 1;
            state.Padding2 = 2;
            state.Padding3 = 3;

            Assert.Equal(1, state.InsertMode);
            Assert.Equal(1, state.CursorAtEndOfLine);
            Assert.Equal(1, state.Initialized);
            Assert.Equal(1, state.HasPreferredX);
            Assert.Equal(1, state.SingleLine);
            Assert.Equal(1, state.Padding1);
            Assert.Equal(2, state.Padding2);
            Assert.Equal(3, state.Padding3);
        }

        /// <summary>
        ///     Verifies that the preferred x property round-trips.
        /// </summary>
        [Fact]
        public void PreferredX_RoundTrip()
        {
            StbTexteditState state = new StbTexteditState();

            state.PreferredX = 12.5f;

            Assert.Equal(12.5f, state.PreferredX, 5);
        }

        /// <summary>
        ///     Verifies that the undo state property round-trips.
        /// </summary>
        [Fact]
        public void UndoState_RoundTrip()
        {
            StbTexteditState state = new StbTexteditState();
            StbUndoState value = new StbUndoState();

            state.UndoState = value;

            Assert.Equal(value, state.UndoState);
        }
    }
}
