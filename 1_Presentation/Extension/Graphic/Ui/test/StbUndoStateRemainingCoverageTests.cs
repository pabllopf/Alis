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

        [Fact]
        public void UndoRec2_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec2 = record;
            Assert.Equal(record, state.UndoRec2);
            Assert.Equal(10, state.UndoRec2.Where);
            Assert.Equal(20, state.UndoRec2.InsertLength);
            Assert.Equal(30, state.UndoRec2.DeleteLength);
            Assert.Equal(40, state.UndoRec2.CharStorage);
        }

        [Fact]
        public void UndoRec3_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec3 = record;
            Assert.Equal(record, state.UndoRec3);
            Assert.Equal(10, state.UndoRec3.Where);
            Assert.Equal(20, state.UndoRec3.InsertLength);
            Assert.Equal(30, state.UndoRec3.DeleteLength);
            Assert.Equal(40, state.UndoRec3.CharStorage);
        }

        [Fact]
        public void UndoRec4_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec4 = record;
            Assert.Equal(record, state.UndoRec4);
            Assert.Equal(10, state.UndoRec4.Where);
            Assert.Equal(20, state.UndoRec4.InsertLength);
            Assert.Equal(30, state.UndoRec4.DeleteLength);
            Assert.Equal(40, state.UndoRec4.CharStorage);
        }

        [Fact]
        public void UndoRec6_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec6 = record;
            Assert.Equal(record, state.UndoRec6);
            Assert.Equal(10, state.UndoRec6.Where);
            Assert.Equal(20, state.UndoRec6.InsertLength);
            Assert.Equal(30, state.UndoRec6.DeleteLength);
            Assert.Equal(40, state.UndoRec6.CharStorage);
        }

        [Fact]
        public void UndoRec7_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec7 = record;
            Assert.Equal(record, state.UndoRec7);
            Assert.Equal(10, state.UndoRec7.Where);
            Assert.Equal(20, state.UndoRec7.InsertLength);
            Assert.Equal(30, state.UndoRec7.DeleteLength);
            Assert.Equal(40, state.UndoRec7.CharStorage);
        }

        [Fact]
        public void UndoRec8_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec8 = record;
            Assert.Equal(record, state.UndoRec8);
            Assert.Equal(10, state.UndoRec8.Where);
            Assert.Equal(20, state.UndoRec8.InsertLength);
            Assert.Equal(30, state.UndoRec8.DeleteLength);
            Assert.Equal(40, state.UndoRec8.CharStorage);
        }

        [Fact]
        public void UndoRec9_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec9 = record;
            Assert.Equal(record, state.UndoRec9);
            Assert.Equal(10, state.UndoRec9.Where);
            Assert.Equal(20, state.UndoRec9.InsertLength);
            Assert.Equal(30, state.UndoRec9.DeleteLength);
            Assert.Equal(40, state.UndoRec9.CharStorage);
        }

        [Fact]
        public void UndoRec10_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec10 = record;
            Assert.Equal(record, state.UndoRec10);
            Assert.Equal(10, state.UndoRec10.Where);
            Assert.Equal(20, state.UndoRec10.InsertLength);
            Assert.Equal(30, state.UndoRec10.DeleteLength);
            Assert.Equal(40, state.UndoRec10.CharStorage);
        }

        [Fact]
        public void UndoRec11_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec11 = record;
            Assert.Equal(record, state.UndoRec11);
            Assert.Equal(10, state.UndoRec11.Where);
            Assert.Equal(20, state.UndoRec11.InsertLength);
            Assert.Equal(30, state.UndoRec11.DeleteLength);
            Assert.Equal(40, state.UndoRec11.CharStorage);
        }

        [Fact]
        public void UndoRec13_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec13 = record;
            Assert.Equal(record, state.UndoRec13);
            Assert.Equal(10, state.UndoRec13.Where);
            Assert.Equal(20, state.UndoRec13.InsertLength);
            Assert.Equal(30, state.UndoRec13.DeleteLength);
            Assert.Equal(40, state.UndoRec13.CharStorage);
        }

        [Fact]
        public void UndoRec14_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec14 = record;
            Assert.Equal(record, state.UndoRec14);
            Assert.Equal(10, state.UndoRec14.Where);
            Assert.Equal(20, state.UndoRec14.InsertLength);
            Assert.Equal(30, state.UndoRec14.DeleteLength);
            Assert.Equal(40, state.UndoRec14.CharStorage);
        }

        [Fact]
        public void UndoRec15_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec15 = record;
            Assert.Equal(record, state.UndoRec15);
            Assert.Equal(10, state.UndoRec15.Where);
            Assert.Equal(20, state.UndoRec15.InsertLength);
            Assert.Equal(30, state.UndoRec15.DeleteLength);
            Assert.Equal(40, state.UndoRec15.CharStorage);
        }

        [Fact]
        public void UndoRec16_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec16 = record;
            Assert.Equal(record, state.UndoRec16);
            Assert.Equal(10, state.UndoRec16.Where);
            Assert.Equal(20, state.UndoRec16.InsertLength);
            Assert.Equal(30, state.UndoRec16.DeleteLength);
            Assert.Equal(40, state.UndoRec16.CharStorage);
        }

        [Fact]
        public void UndoRec17_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec17 = record;
            Assert.Equal(record, state.UndoRec17);
            Assert.Equal(10, state.UndoRec17.Where);
            Assert.Equal(20, state.UndoRec17.InsertLength);
            Assert.Equal(30, state.UndoRec17.DeleteLength);
            Assert.Equal(40, state.UndoRec17.CharStorage);
        }

        [Fact]
        public void UndoRec18_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec18 = record;
            Assert.Equal(record, state.UndoRec18);
            Assert.Equal(10, state.UndoRec18.Where);
            Assert.Equal(20, state.UndoRec18.InsertLength);
            Assert.Equal(30, state.UndoRec18.DeleteLength);
            Assert.Equal(40, state.UndoRec18.CharStorage);
        }

        [Fact]
        public void UndoRec19_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec19 = record;
            Assert.Equal(record, state.UndoRec19);
            Assert.Equal(10, state.UndoRec19.Where);
            Assert.Equal(20, state.UndoRec19.InsertLength);
            Assert.Equal(30, state.UndoRec19.DeleteLength);
            Assert.Equal(40, state.UndoRec19.CharStorage);
        }

        [Fact]
        public void UndoRec20_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec20 = record;
            Assert.Equal(record, state.UndoRec20);
            Assert.Equal(10, state.UndoRec20.Where);
            Assert.Equal(20, state.UndoRec20.InsertLength);
            Assert.Equal(30, state.UndoRec20.DeleteLength);
            Assert.Equal(40, state.UndoRec20.CharStorage);
        }

        [Fact]
        public void UndoRec21_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec21 = record;
            Assert.Equal(record, state.UndoRec21);
            Assert.Equal(10, state.UndoRec21.Where);
            Assert.Equal(20, state.UndoRec21.InsertLength);
            Assert.Equal(30, state.UndoRec21.DeleteLength);
            Assert.Equal(40, state.UndoRec21.CharStorage);
        }

        [Fact]
        public void UndoRec22_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec22 = record;
            Assert.Equal(record, state.UndoRec22);
            Assert.Equal(10, state.UndoRec22.Where);
            Assert.Equal(20, state.UndoRec22.InsertLength);
            Assert.Equal(30, state.UndoRec22.DeleteLength);
            Assert.Equal(40, state.UndoRec22.CharStorage);
        }

        [Fact]
        public void UndoRec23_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec23 = record;
            Assert.Equal(record, state.UndoRec23);
            Assert.Equal(10, state.UndoRec23.Where);
            Assert.Equal(20, state.UndoRec23.InsertLength);
            Assert.Equal(30, state.UndoRec23.DeleteLength);
            Assert.Equal(40, state.UndoRec23.CharStorage);
        }

        [Fact]
        public void UndoRec24_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec24 = record;
            Assert.Equal(record, state.UndoRec24);
            Assert.Equal(10, state.UndoRec24.Where);
            Assert.Equal(20, state.UndoRec24.InsertLength);
            Assert.Equal(30, state.UndoRec24.DeleteLength);
            Assert.Equal(40, state.UndoRec24.CharStorage);
        }

        [Fact]
        public void UndoRec25_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec25 = record;
            Assert.Equal(record, state.UndoRec25);
            Assert.Equal(10, state.UndoRec25.Where);
            Assert.Equal(20, state.UndoRec25.InsertLength);
            Assert.Equal(30, state.UndoRec25.DeleteLength);
            Assert.Equal(40, state.UndoRec25.CharStorage);
        }

        [Fact]
        public void UndoRec26_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec26 = record;
            Assert.Equal(record, state.UndoRec26);
            Assert.Equal(10, state.UndoRec26.Where);
            Assert.Equal(20, state.UndoRec26.InsertLength);
            Assert.Equal(30, state.UndoRec26.DeleteLength);
            Assert.Equal(40, state.UndoRec26.CharStorage);
        }

        [Fact]
        public void UndoRec27_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec27 = record;
            Assert.Equal(record, state.UndoRec27);
            Assert.Equal(10, state.UndoRec27.Where);
            Assert.Equal(20, state.UndoRec27.InsertLength);
            Assert.Equal(30, state.UndoRec27.DeleteLength);
            Assert.Equal(40, state.UndoRec27.CharStorage);
        }

        [Fact]
        public void UndoRec28_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec28 = record;
            Assert.Equal(record, state.UndoRec28);
            Assert.Equal(10, state.UndoRec28.Where);
            Assert.Equal(20, state.UndoRec28.InsertLength);
            Assert.Equal(30, state.UndoRec28.DeleteLength);
            Assert.Equal(40, state.UndoRec28.CharStorage);
        }

        [Fact]
        public void UndoRec29_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec29 = record;
            Assert.Equal(record, state.UndoRec29);
            Assert.Equal(10, state.UndoRec29.Where);
            Assert.Equal(20, state.UndoRec29.InsertLength);
            Assert.Equal(30, state.UndoRec29.DeleteLength);
            Assert.Equal(40, state.UndoRec29.CharStorage);
        }

        [Fact]
        public void UndoRec30_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec30 = record;
            Assert.Equal(record, state.UndoRec30);
            Assert.Equal(10, state.UndoRec30.Where);
            Assert.Equal(20, state.UndoRec30.InsertLength);
            Assert.Equal(30, state.UndoRec30.DeleteLength);
            Assert.Equal(40, state.UndoRec30.CharStorage);
        }

        [Fact]
        public void UndoRec32_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec32 = record;
            Assert.Equal(record, state.UndoRec32);
            Assert.Equal(10, state.UndoRec32.Where);
            Assert.Equal(20, state.UndoRec32.InsertLength);
            Assert.Equal(30, state.UndoRec32.DeleteLength);
            Assert.Equal(40, state.UndoRec32.CharStorage);
        }

        [Fact]
        public void UndoRec33_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec33 = record;
            Assert.Equal(record, state.UndoRec33);
            Assert.Equal(10, state.UndoRec33.Where);
            Assert.Equal(20, state.UndoRec33.InsertLength);
            Assert.Equal(30, state.UndoRec33.DeleteLength);
            Assert.Equal(40, state.UndoRec33.CharStorage);
        }

        [Fact]
        public void UndoRec34_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec34 = record;
            Assert.Equal(record, state.UndoRec34);
            Assert.Equal(10, state.UndoRec34.Where);
            Assert.Equal(20, state.UndoRec34.InsertLength);
            Assert.Equal(30, state.UndoRec34.DeleteLength);
            Assert.Equal(40, state.UndoRec34.CharStorage);
        }

        [Fact]
        public void UndoRec35_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec35 = record;
            Assert.Equal(record, state.UndoRec35);
            Assert.Equal(10, state.UndoRec35.Where);
            Assert.Equal(20, state.UndoRec35.InsertLength);
            Assert.Equal(30, state.UndoRec35.DeleteLength);
            Assert.Equal(40, state.UndoRec35.CharStorage);
        }

        [Fact]
        public void UndoRec36_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec36 = record;
            Assert.Equal(record, state.UndoRec36);
            Assert.Equal(10, state.UndoRec36.Where);
            Assert.Equal(20, state.UndoRec36.InsertLength);
            Assert.Equal(30, state.UndoRec36.DeleteLength);
            Assert.Equal(40, state.UndoRec36.CharStorage);
        }

        [Fact]
        public void UndoRec37_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec37 = record;
            Assert.Equal(record, state.UndoRec37);
            Assert.Equal(10, state.UndoRec37.Where);
            Assert.Equal(20, state.UndoRec37.InsertLength);
            Assert.Equal(30, state.UndoRec37.DeleteLength);
            Assert.Equal(40, state.UndoRec37.CharStorage);
        }

        [Fact]
        public void UndoRec38_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec38 = record;
            Assert.Equal(record, state.UndoRec38);
            Assert.Equal(10, state.UndoRec38.Where);
            Assert.Equal(20, state.UndoRec38.InsertLength);
            Assert.Equal(30, state.UndoRec38.DeleteLength);
            Assert.Equal(40, state.UndoRec38.CharStorage);
        }

        [Fact]
        public void UndoRec39_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec39 = record;
            Assert.Equal(record, state.UndoRec39);
            Assert.Equal(10, state.UndoRec39.Where);
            Assert.Equal(20, state.UndoRec39.InsertLength);
            Assert.Equal(30, state.UndoRec39.DeleteLength);
            Assert.Equal(40, state.UndoRec39.CharStorage);
        }

        [Fact]
        public void UndoRec40_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec40 = record;
            Assert.Equal(record, state.UndoRec40);
            Assert.Equal(10, state.UndoRec40.Where);
            Assert.Equal(20, state.UndoRec40.InsertLength);
            Assert.Equal(30, state.UndoRec40.DeleteLength);
            Assert.Equal(40, state.UndoRec40.CharStorage);
        }

        [Fact]
        public void UndoRec41_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec41 = record;
            Assert.Equal(record, state.UndoRec41);
            Assert.Equal(10, state.UndoRec41.Where);
            Assert.Equal(20, state.UndoRec41.InsertLength);
            Assert.Equal(30, state.UndoRec41.DeleteLength);
            Assert.Equal(40, state.UndoRec41.CharStorage);
        }

        [Fact]
        public void UndoRec42_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec42 = record;
            Assert.Equal(record, state.UndoRec42);
            Assert.Equal(10, state.UndoRec42.Where);
            Assert.Equal(20, state.UndoRec42.InsertLength);
            Assert.Equal(30, state.UndoRec42.DeleteLength);
            Assert.Equal(40, state.UndoRec42.CharStorage);
        }

        [Fact]
        public void UndoRec43_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec43 = record;
            Assert.Equal(record, state.UndoRec43);
            Assert.Equal(10, state.UndoRec43.Where);
            Assert.Equal(20, state.UndoRec43.InsertLength);
            Assert.Equal(30, state.UndoRec43.DeleteLength);
            Assert.Equal(40, state.UndoRec43.CharStorage);
        }

        [Fact]
        public void UndoRec44_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec44 = record;
            Assert.Equal(record, state.UndoRec44);
            Assert.Equal(10, state.UndoRec44.Where);
            Assert.Equal(20, state.UndoRec44.InsertLength);
            Assert.Equal(30, state.UndoRec44.DeleteLength);
            Assert.Equal(40, state.UndoRec44.CharStorage);
        }

        [Fact]
        public void UndoRec45_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec45 = record;
            Assert.Equal(record, state.UndoRec45);
            Assert.Equal(10, state.UndoRec45.Where);
            Assert.Equal(20, state.UndoRec45.InsertLength);
            Assert.Equal(30, state.UndoRec45.DeleteLength);
            Assert.Equal(40, state.UndoRec45.CharStorage);
        }

        [Fact]
        public void UndoRec46_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec46 = record;
            Assert.Equal(record, state.UndoRec46);
            Assert.Equal(10, state.UndoRec46.Where);
            Assert.Equal(20, state.UndoRec46.InsertLength);
            Assert.Equal(30, state.UndoRec46.DeleteLength);
            Assert.Equal(40, state.UndoRec46.CharStorage);
        }

        [Fact]
        public void UndoRec47_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec47 = record;
            Assert.Equal(record, state.UndoRec47);
            Assert.Equal(10, state.UndoRec47.Where);
            Assert.Equal(20, state.UndoRec47.InsertLength);
            Assert.Equal(30, state.UndoRec47.DeleteLength);
            Assert.Equal(40, state.UndoRec47.CharStorage);
        }

        [Fact]
        public void UndoRec48_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec48 = record;
            Assert.Equal(record, state.UndoRec48);
            Assert.Equal(10, state.UndoRec48.Where);
            Assert.Equal(20, state.UndoRec48.InsertLength);
            Assert.Equal(30, state.UndoRec48.DeleteLength);
            Assert.Equal(40, state.UndoRec48.CharStorage);
        }

        [Fact]
        public void UndoRec49_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec49 = record;
            Assert.Equal(record, state.UndoRec49);
            Assert.Equal(10, state.UndoRec49.Where);
            Assert.Equal(20, state.UndoRec49.InsertLength);
            Assert.Equal(30, state.UndoRec49.DeleteLength);
            Assert.Equal(40, state.UndoRec49.CharStorage);
        }

        [Fact]
        public void UndoRec51_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec51 = record;
            Assert.Equal(record, state.UndoRec51);
            Assert.Equal(10, state.UndoRec51.Where);
            Assert.Equal(20, state.UndoRec51.InsertLength);
            Assert.Equal(30, state.UndoRec51.DeleteLength);
            Assert.Equal(40, state.UndoRec51.CharStorage);
        }

        [Fact]
        public void UndoRec52_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec52 = record;
            Assert.Equal(record, state.UndoRec52);
            Assert.Equal(10, state.UndoRec52.Where);
            Assert.Equal(20, state.UndoRec52.InsertLength);
            Assert.Equal(30, state.UndoRec52.DeleteLength);
            Assert.Equal(40, state.UndoRec52.CharStorage);
        }

        [Fact]
        public void UndoRec53_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec53 = record;
            Assert.Equal(record, state.UndoRec53);
            Assert.Equal(10, state.UndoRec53.Where);
            Assert.Equal(20, state.UndoRec53.InsertLength);
            Assert.Equal(30, state.UndoRec53.DeleteLength);
            Assert.Equal(40, state.UndoRec53.CharStorage);
        }

        [Fact]
        public void UndoRec54_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec54 = record;
            Assert.Equal(record, state.UndoRec54);
            Assert.Equal(10, state.UndoRec54.Where);
            Assert.Equal(20, state.UndoRec54.InsertLength);
            Assert.Equal(30, state.UndoRec54.DeleteLength);
            Assert.Equal(40, state.UndoRec54.CharStorage);
        }

        [Fact]
        public void UndoRec55_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec55 = record;
            Assert.Equal(record, state.UndoRec55);
            Assert.Equal(10, state.UndoRec55.Where);
            Assert.Equal(20, state.UndoRec55.InsertLength);
            Assert.Equal(30, state.UndoRec55.DeleteLength);
            Assert.Equal(40, state.UndoRec55.CharStorage);
        }

        [Fact]
        public void UndoRec56_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec56 = record;
            Assert.Equal(record, state.UndoRec56);
            Assert.Equal(10, state.UndoRec56.Where);
            Assert.Equal(20, state.UndoRec56.InsertLength);
            Assert.Equal(30, state.UndoRec56.DeleteLength);
            Assert.Equal(40, state.UndoRec56.CharStorage);
        }

        [Fact]
        public void UndoRec57_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec57 = record;
            Assert.Equal(record, state.UndoRec57);
            Assert.Equal(10, state.UndoRec57.Where);
            Assert.Equal(20, state.UndoRec57.InsertLength);
            Assert.Equal(30, state.UndoRec57.DeleteLength);
            Assert.Equal(40, state.UndoRec57.CharStorage);
        }

        [Fact]
        public void UndoRec58_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec58 = record;
            Assert.Equal(record, state.UndoRec58);
            Assert.Equal(10, state.UndoRec58.Where);
            Assert.Equal(20, state.UndoRec58.InsertLength);
            Assert.Equal(30, state.UndoRec58.DeleteLength);
            Assert.Equal(40, state.UndoRec58.CharStorage);
        }

        [Fact]
        public void UndoRec59_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec59 = record;
            Assert.Equal(record, state.UndoRec59);
            Assert.Equal(10, state.UndoRec59.Where);
            Assert.Equal(20, state.UndoRec59.InsertLength);
            Assert.Equal(30, state.UndoRec59.DeleteLength);
            Assert.Equal(40, state.UndoRec59.CharStorage);
        }

        [Fact]
        public void UndoRec60_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec60 = record;
            Assert.Equal(record, state.UndoRec60);
            Assert.Equal(10, state.UndoRec60.Where);
            Assert.Equal(20, state.UndoRec60.InsertLength);
            Assert.Equal(30, state.UndoRec60.DeleteLength);
            Assert.Equal(40, state.UndoRec60.CharStorage);
        }

        [Fact]
        public void UndoRec61_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec61 = record;
            Assert.Equal(record, state.UndoRec61);
            Assert.Equal(10, state.UndoRec61.Where);
            Assert.Equal(20, state.UndoRec61.InsertLength);
            Assert.Equal(30, state.UndoRec61.DeleteLength);
            Assert.Equal(40, state.UndoRec61.CharStorage);
        }

        [Fact]
        public void UndoRec62_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec62 = record;
            Assert.Equal(record, state.UndoRec62);
            Assert.Equal(10, state.UndoRec62.Where);
            Assert.Equal(20, state.UndoRec62.InsertLength);
            Assert.Equal(30, state.UndoRec62.DeleteLength);
            Assert.Equal(40, state.UndoRec62.CharStorage);
        }

        [Fact]
        public void UndoRec63_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec63 = record;
            Assert.Equal(record, state.UndoRec63);
            Assert.Equal(10, state.UndoRec63.Where);
            Assert.Equal(20, state.UndoRec63.InsertLength);
            Assert.Equal(30, state.UndoRec63.DeleteLength);
            Assert.Equal(40, state.UndoRec63.CharStorage);
        }

        [Fact]
        public void UndoRec64_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec64 = record;
            Assert.Equal(record, state.UndoRec64);
            Assert.Equal(10, state.UndoRec64.Where);
            Assert.Equal(20, state.UndoRec64.InsertLength);
            Assert.Equal(30, state.UndoRec64.DeleteLength);
            Assert.Equal(40, state.UndoRec64.CharStorage);
        }

        [Fact]
        public void UndoRec65_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec65 = record;
            Assert.Equal(record, state.UndoRec65);
            Assert.Equal(10, state.UndoRec65.Where);
            Assert.Equal(20, state.UndoRec65.InsertLength);
            Assert.Equal(30, state.UndoRec65.DeleteLength);
            Assert.Equal(40, state.UndoRec65.CharStorage);
        }

        [Fact]
        public void UndoRec66_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec66 = record;
            Assert.Equal(record, state.UndoRec66);
            Assert.Equal(10, state.UndoRec66.Where);
            Assert.Equal(20, state.UndoRec66.InsertLength);
            Assert.Equal(30, state.UndoRec66.DeleteLength);
            Assert.Equal(40, state.UndoRec66.CharStorage);
        }

        [Fact]
        public void UndoRec67_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec67 = record;
            Assert.Equal(record, state.UndoRec67);
            Assert.Equal(10, state.UndoRec67.Where);
            Assert.Equal(20, state.UndoRec67.InsertLength);
            Assert.Equal(30, state.UndoRec67.DeleteLength);
            Assert.Equal(40, state.UndoRec67.CharStorage);
        }

        [Fact]
        public void UndoRec68_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec68 = record;
            Assert.Equal(record, state.UndoRec68);
            Assert.Equal(10, state.UndoRec68.Where);
            Assert.Equal(20, state.UndoRec68.InsertLength);
            Assert.Equal(30, state.UndoRec68.DeleteLength);
            Assert.Equal(40, state.UndoRec68.CharStorage);
        }

        [Fact]
        public void UndoRec69_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec69 = record;
            Assert.Equal(record, state.UndoRec69);
            Assert.Equal(10, state.UndoRec69.Where);
            Assert.Equal(20, state.UndoRec69.InsertLength);
            Assert.Equal(30, state.UndoRec69.DeleteLength);
            Assert.Equal(40, state.UndoRec69.CharStorage);
        }

        [Fact]
        public void UndoRec70_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec70 = record;
            Assert.Equal(record, state.UndoRec70);
            Assert.Equal(10, state.UndoRec70.Where);
            Assert.Equal(20, state.UndoRec70.InsertLength);
            Assert.Equal(30, state.UndoRec70.DeleteLength);
            Assert.Equal(40, state.UndoRec70.CharStorage);
        }

        [Fact]
        public void UndoRec71_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec71 = record;
            Assert.Equal(record, state.UndoRec71);
            Assert.Equal(10, state.UndoRec71.Where);
            Assert.Equal(20, state.UndoRec71.InsertLength);
            Assert.Equal(30, state.UndoRec71.DeleteLength);
            Assert.Equal(40, state.UndoRec71.CharStorage);
        }

        [Fact]
        public void UndoRec72_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec72 = record;
            Assert.Equal(record, state.UndoRec72);
            Assert.Equal(10, state.UndoRec72.Where);
            Assert.Equal(20, state.UndoRec72.InsertLength);
            Assert.Equal(30, state.UndoRec72.DeleteLength);
            Assert.Equal(40, state.UndoRec72.CharStorage);
        }

        [Fact]
        public void UndoRec73_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec73 = record;
            Assert.Equal(record, state.UndoRec73);
            Assert.Equal(10, state.UndoRec73.Where);
            Assert.Equal(20, state.UndoRec73.InsertLength);
            Assert.Equal(30, state.UndoRec73.DeleteLength);
            Assert.Equal(40, state.UndoRec73.CharStorage);
        }

        [Fact]
        public void UndoRec74_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec74 = record;
            Assert.Equal(record, state.UndoRec74);
            Assert.Equal(10, state.UndoRec74.Where);
            Assert.Equal(20, state.UndoRec74.InsertLength);
            Assert.Equal(30, state.UndoRec74.DeleteLength);
            Assert.Equal(40, state.UndoRec74.CharStorage);
        }

        [Fact]
        public void UndoRec76_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec76 = record;
            Assert.Equal(record, state.UndoRec76);
            Assert.Equal(10, state.UndoRec76.Where);
            Assert.Equal(20, state.UndoRec76.InsertLength);
            Assert.Equal(30, state.UndoRec76.DeleteLength);
            Assert.Equal(40, state.UndoRec76.CharStorage);
        }

        [Fact]
        public void UndoRec77_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec77 = record;
            Assert.Equal(record, state.UndoRec77);
            Assert.Equal(10, state.UndoRec77.Where);
            Assert.Equal(20, state.UndoRec77.InsertLength);
            Assert.Equal(30, state.UndoRec77.DeleteLength);
            Assert.Equal(40, state.UndoRec77.CharStorage);
        }

        [Fact]
        public void UndoRec78_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec78 = record;
            Assert.Equal(record, state.UndoRec78);
            Assert.Equal(10, state.UndoRec78.Where);
            Assert.Equal(20, state.UndoRec78.InsertLength);
            Assert.Equal(30, state.UndoRec78.DeleteLength);
            Assert.Equal(40, state.UndoRec78.CharStorage);
        }

        [Fact]
        public void UndoRec79_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec79 = record;
            Assert.Equal(record, state.UndoRec79);
            Assert.Equal(10, state.UndoRec79.Where);
            Assert.Equal(20, state.UndoRec79.InsertLength);
            Assert.Equal(30, state.UndoRec79.DeleteLength);
            Assert.Equal(40, state.UndoRec79.CharStorage);
        }

        [Fact]
        public void UndoRec80_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec80 = record;
            Assert.Equal(record, state.UndoRec80);
            Assert.Equal(10, state.UndoRec80.Where);
            Assert.Equal(20, state.UndoRec80.InsertLength);
            Assert.Equal(30, state.UndoRec80.DeleteLength);
            Assert.Equal(40, state.UndoRec80.CharStorage);
        }

        [Fact]
        public void UndoRec81_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec81 = record;
            Assert.Equal(record, state.UndoRec81);
            Assert.Equal(10, state.UndoRec81.Where);
            Assert.Equal(20, state.UndoRec81.InsertLength);
            Assert.Equal(30, state.UndoRec81.DeleteLength);
            Assert.Equal(40, state.UndoRec81.CharStorage);
        }

        [Fact]
        public void UndoRec82_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec82 = record;
            Assert.Equal(record, state.UndoRec82);
            Assert.Equal(10, state.UndoRec82.Where);
            Assert.Equal(20, state.UndoRec82.InsertLength);
            Assert.Equal(30, state.UndoRec82.DeleteLength);
            Assert.Equal(40, state.UndoRec82.CharStorage);
        }

        [Fact]
        public void UndoRec83_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec83 = record;
            Assert.Equal(record, state.UndoRec83);
            Assert.Equal(10, state.UndoRec83.Where);
            Assert.Equal(20, state.UndoRec83.InsertLength);
            Assert.Equal(30, state.UndoRec83.DeleteLength);
            Assert.Equal(40, state.UndoRec83.CharStorage);
        }

        [Fact]
        public void UndoRec84_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec84 = record;
            Assert.Equal(record, state.UndoRec84);
            Assert.Equal(10, state.UndoRec84.Where);
            Assert.Equal(20, state.UndoRec84.InsertLength);
            Assert.Equal(30, state.UndoRec84.DeleteLength);
            Assert.Equal(40, state.UndoRec84.CharStorage);
        }

        [Fact]
        public void UndoRec85_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec85 = record;
            Assert.Equal(record, state.UndoRec85);
            Assert.Equal(10, state.UndoRec85.Where);
            Assert.Equal(20, state.UndoRec85.InsertLength);
            Assert.Equal(30, state.UndoRec85.DeleteLength);
            Assert.Equal(40, state.UndoRec85.CharStorage);
        }

        [Fact]
        public void UndoRec86_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec86 = record;
            Assert.Equal(record, state.UndoRec86);
            Assert.Equal(10, state.UndoRec86.Where);
            Assert.Equal(20, state.UndoRec86.InsertLength);
            Assert.Equal(30, state.UndoRec86.DeleteLength);
            Assert.Equal(40, state.UndoRec86.CharStorage);
        }

        [Fact]
        public void UndoRec87_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec87 = record;
            Assert.Equal(record, state.UndoRec87);
            Assert.Equal(10, state.UndoRec87.Where);
            Assert.Equal(20, state.UndoRec87.InsertLength);
            Assert.Equal(30, state.UndoRec87.DeleteLength);
            Assert.Equal(40, state.UndoRec87.CharStorage);
        }

        [Fact]
        public void UndoRec88_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec88 = record;
            Assert.Equal(record, state.UndoRec88);
            Assert.Equal(10, state.UndoRec88.Where);
            Assert.Equal(20, state.UndoRec88.InsertLength);
            Assert.Equal(30, state.UndoRec88.DeleteLength);
            Assert.Equal(40, state.UndoRec88.CharStorage);
        }

        [Fact]
        public void UndoRec89_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec89 = record;
            Assert.Equal(record, state.UndoRec89);
            Assert.Equal(10, state.UndoRec89.Where);
            Assert.Equal(20, state.UndoRec89.InsertLength);
            Assert.Equal(30, state.UndoRec89.DeleteLength);
            Assert.Equal(40, state.UndoRec89.CharStorage);
        }

        [Fact]
        public void UndoRec91_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec91 = record;
            Assert.Equal(record, state.UndoRec91);
            Assert.Equal(10, state.UndoRec91.Where);
            Assert.Equal(20, state.UndoRec91.InsertLength);
            Assert.Equal(30, state.UndoRec91.DeleteLength);
            Assert.Equal(40, state.UndoRec91.CharStorage);
        }

        [Fact]
        public void UndoRec92_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec92 = record;
            Assert.Equal(record, state.UndoRec92);
            Assert.Equal(10, state.UndoRec92.Where);
            Assert.Equal(20, state.UndoRec92.InsertLength);
            Assert.Equal(30, state.UndoRec92.DeleteLength);
            Assert.Equal(40, state.UndoRec92.CharStorage);
        }

        [Fact]
        public void UndoRec93_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec93 = record;
            Assert.Equal(record, state.UndoRec93);
            Assert.Equal(10, state.UndoRec93.Where);
            Assert.Equal(20, state.UndoRec93.InsertLength);
            Assert.Equal(30, state.UndoRec93.DeleteLength);
            Assert.Equal(40, state.UndoRec93.CharStorage);
        }

        [Fact]
        public void UndoRec94_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec94 = record;
            Assert.Equal(record, state.UndoRec94);
            Assert.Equal(10, state.UndoRec94.Where);
            Assert.Equal(20, state.UndoRec94.InsertLength);
            Assert.Equal(30, state.UndoRec94.DeleteLength);
            Assert.Equal(40, state.UndoRec94.CharStorage);
        }

        [Fact]
        public void UndoRec96_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec96 = record;
            Assert.Equal(record, state.UndoRec96);
            Assert.Equal(10, state.UndoRec96.Where);
            Assert.Equal(20, state.UndoRec96.InsertLength);
            Assert.Equal(30, state.UndoRec96.DeleteLength);
            Assert.Equal(40, state.UndoRec96.CharStorage);
        }

        [Fact]
        public void UndoRec97_SetAndGet_ReturnsCorrectValue()
        {
            StbUndoState state = new StbUndoState();
            StbUndoRecord record = new StbUndoRecord { Where = 10, InsertLength = 20, DeleteLength = 30, CharStorage = 40 };
            state.UndoRec97 = record;
            Assert.Equal(record, state.UndoRec97);
            Assert.Equal(10, state.UndoRec97.Where);
            Assert.Equal(20, state.UndoRec97.InsertLength);
            Assert.Equal(30, state.UndoRec97.DeleteLength);
            Assert.Equal(40, state.UndoRec97.CharStorage);
        }
    }
}