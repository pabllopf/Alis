// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StbTexteditStateTests.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The stb textedit state tests class
    /// </summary>
    public class StbTexteditStateTests
    {
        /// <summary>
        ///     Tests that cursor set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Cursor_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            int value = 42;
            state.Cursor = value;
            Assert.Equal(value, state.Cursor);
        }

        /// <summary>
        ///     Tests that select start set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void SelectStart_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            int value = 10;
            state.SelectStart = value;
            Assert.Equal(value, state.SelectStart);
        }

        /// <summary>
        ///     Tests that select end set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void SelectEnd_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            int value = 20;
            state.SelectEnd = value;
            Assert.Equal(value, state.SelectEnd);
        }

        /// <summary>
        ///     Tests that insert mode set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void InsertMode_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 1;
            state.InsertMode = value;
            Assert.Equal(value, state.InsertMode);
        }

        /// <summary>
        ///     Tests that row count per page set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void RowCountPerPage_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            int value = 30;
            state.RowCountPerPage = value;
            Assert.Equal(value, state.RowCountPerPage);
        }

        /// <summary>
        ///     Tests that cursor at end of line set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void CursorAtEndOfLine_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 1;
            state.CursorAtEndOfLine = value;
            Assert.Equal(value, state.CursorAtEndOfLine);
        }

        /// <summary>
        ///     Tests that initialized set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Initialized_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 1;
            state.Initialized = value;
            Assert.Equal(value, state.Initialized);
        }

        /// <summary>
        ///     Tests that has preferred x set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void HasPreferredX_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 1;
            state.HasPreferredX = value;
            Assert.Equal(value, state.HasPreferredX);
        }

        /// <summary>
        ///     Tests that single line set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void SingleLine_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 1;
            state.SingleLine = value;
            Assert.Equal(value, state.SingleLine);
        }

        /// <summary>
        ///     Tests that padding 1 set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Padding1_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 255;
            state.Padding1 = value;
            Assert.Equal(value, state.Padding1);
        }

        /// <summary>
        ///     Tests that padding 2 set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Padding2_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 128;
            state.Padding2 = value;
            Assert.Equal(value, state.Padding2);
        }

        /// <summary>
        ///     Tests that padding 3 set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Padding3_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            byte value = 64;
            state.Padding3 = value;
            Assert.Equal(value, state.Padding3);
        }

        /// <summary>
        ///     Tests that preferred x set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void PreferredX_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            float value = 3.14f;
            state.PreferredX = value;
            Assert.Equal(value, state.PreferredX);
        }

        /// <summary>
        ///     Tests that undo state set and get returns correct value
        /// </summary>
        [RequireCImguiSystemFact]
        public void UndoState_SetAndGet_ReturnsCorrectValue()
        {
            StbTexteditState state = new StbTexteditState();
            StbUndoState value = new StbUndoState();
            state.UndoState = value;
            Assert.Equal(value, state.UndoState);
        }
    }
}
