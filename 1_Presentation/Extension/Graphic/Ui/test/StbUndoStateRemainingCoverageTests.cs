// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbUndoStateRemainingCoverageTests.cs
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
//  along with this program.If not, see<http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The stb undo state remaining coverage tests class
    /// </summary>
    public class StbUndoStateRemainingCoverageTests
    {
        /// <summary>
        /// Tests that undo rec 0 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec0_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec0 = record;

            Assert.Equal(record, state.UndoRec0);
            Assert.Equal(10, state.UndoRec0.Where);
            Assert.Equal(20, state.UndoRec0.InsertLength);
            Assert.Equal(30, state.UndoRec0.DeleteLength);
            Assert.Equal(40, state.UndoRec0.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec1_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec1 = record;

            Assert.Equal(record, state.UndoRec1);
            Assert.Equal(10, state.UndoRec1.Where);
            Assert.Equal(20, state.UndoRec1.InsertLength);
            Assert.Equal(30, state.UndoRec1.DeleteLength);
            Assert.Equal(40, state.UndoRec1.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 5 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec5_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec5 = record;

            Assert.Equal(record, state.UndoRec5);
            Assert.Equal(10, state.UndoRec5.Where);
            Assert.Equal(20, state.UndoRec5.InsertLength);
            Assert.Equal(30, state.UndoRec5.DeleteLength);
            Assert.Equal(40, state.UndoRec5.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 12 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec12_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec12 = record;

            Assert.Equal(record, state.UndoRec12);
            Assert.Equal(10, state.UndoRec12.Where);
            Assert.Equal(20, state.UndoRec12.InsertLength);
            Assert.Equal(30, state.UndoRec12.DeleteLength);
            Assert.Equal(40, state.UndoRec12.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 31 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec31_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec31 = record;

            Assert.Equal(record, state.UndoRec31);
            Assert.Equal(10, state.UndoRec31.Where);
            Assert.Equal(20, state.UndoRec31.InsertLength);
            Assert.Equal(30, state.UndoRec31.DeleteLength);
            Assert.Equal(40, state.UndoRec31.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 50 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec50_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec50 = record;

            Assert.Equal(record, state.UndoRec50);
            Assert.Equal(10, state.UndoRec50.Where);
            Assert.Equal(20, state.UndoRec50.InsertLength);
            Assert.Equal(30, state.UndoRec50.DeleteLength);
            Assert.Equal(40, state.UndoRec50.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 75 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec75_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec75 = record;

            Assert.Equal(record, state.UndoRec75);
            Assert.Equal(10, state.UndoRec75.Where);
            Assert.Equal(20, state.UndoRec75.InsertLength);
            Assert.Equal(30, state.UndoRec75.DeleteLength);
            Assert.Equal(40, state.UndoRec75.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 90 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec90_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec90 = record;

            Assert.Equal(record, state.UndoRec90);
            Assert.Equal(10, state.UndoRec90.Where);
            Assert.Equal(20, state.UndoRec90.InsertLength);
            Assert.Equal(30, state.UndoRec90.DeleteLength);
            Assert.Equal(40, state.UndoRec90.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 95 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec95_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec95 = record;

            Assert.Equal(record, state.UndoRec95);
            Assert.Equal(10, state.UndoRec95.Where);
            Assert.Equal(20, state.UndoRec95.InsertLength);
            Assert.Equal(30, state.UndoRec95.DeleteLength);
            Assert.Equal(40, state.UndoRec95.CharStorage);
        }

        /// <summary>
        /// Tests that undo rec 98 set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoRec98_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };

            state.UndoRec98 = record;

            Assert.Equal(record, state.UndoRec98);
            Assert.Equal(10, state.UndoRec98.Where);
            Assert.Equal(20, state.UndoRec98.InsertLength);
            Assert.Equal(30, state.UndoRec98.DeleteLength);
            Assert.Equal(40, state.UndoRec98.CharStorage);
        }

        /// <summary>
        /// Tests that undo char set and get returns correct list
        /// </summary>
        [Fact]
        public void UndoChar_SetAndGet_ReturnsCorrectList()
        {
            StbUndoState state = new StbUndoState();
            List<ushort> chars = new List<ushort> { 1, 2, 3, 4, 5 };

            state.UndoChar = chars;

            Assert.Equal(chars, state.UndoChar);
            Assert.Equal(5, state.UndoChar.Count);
        }

        /// <summary>
        /// Tests that undo point set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();

            state.UndoPoint = 123;

            Assert.Equal(123, state.UndoPoint);
        }

        /// <summary>
        /// Tests that redo point set and get returns correct value
        /// </summary>
        [Fact]
        public void RedoPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();

            state.RedoPoint = -45;

            Assert.Equal(-45, state.RedoPoint);
        }

        /// <summary>
        /// Tests that undo char point set and get returns correct value
        /// </summary>
        [Fact]
        public void UndoCharPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();

            state.UndoCharPoint = 789;

            Assert.Equal(789, state.UndoCharPoint);
        }

        /// <summary>
        /// Tests that redo char point set and get returns correct value
        /// </summary>
        [Fact]
        public void RedoCharPoint_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();

            state.RedoCharPoint = -101112;

            Assert.Equal(-101112, state.RedoCharPoint);
        }

        /// <summary>
        /// Tests that default stb undo state has expected default values
        /// </summary>
        [Fact]
        public void Default_State_HasExpectedDefaultValues()
        {
            StbUndoState state = new StbUndoState();

            Assert.Equal(0, state.UndoPoint);
            Assert.Equal(0, state.RedoPoint);
            Assert.Equal(0, state.UndoCharPoint);
            Assert.Equal(0, state.RedoCharPoint);
            Assert.Null(state.UndoChar);
            Assert.True(state.UndoRec0.Equals(default(StbUndoRecord)));
            Assert.True(state.UndoRec50.Equals(default(StbUndoRecord)));
            Assert.True(state.UndoRec98.Equals(default(StbUndoRecord)));
        }
    }
}