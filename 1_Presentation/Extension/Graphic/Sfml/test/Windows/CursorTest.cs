// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The cursor test class
    /// </summary>
    public class CursorTest
    {
        /// <summary>
        /// Tests that cursor type has expected values
        /// </summary>
        [Fact]
        public void CursorType_HasExpectedValues()
        {
            Assert.Equal(0, (int)Cursor.CursorType.Arrow);
            Assert.Equal(1, (int)Cursor.CursorType.ArrowWait);
            Assert.Equal(2, (int)Cursor.CursorType.Wait);
            Assert.Equal(3, (int)Cursor.CursorType.Text);
            Assert.Equal(4, (int)Cursor.CursorType.Hand);
            Assert.Equal(5, (int)Cursor.CursorType.SizeHorinzontal);
            Assert.Equal(6, (int)Cursor.CursorType.SizeVertical);
            Assert.Equal(7, (int)Cursor.CursorType.SizeTopLeftBottomRight);
            Assert.Equal(8, (int)Cursor.CursorType.SizeBottomLeftTopRight);
            Assert.Equal(9, (int)Cursor.CursorType.SizeAll);
            Assert.Equal(10, (int)Cursor.CursorType.Cross);
            Assert.Equal(11, (int)Cursor.CursorType.Help);
            Assert.Equal(12, (int)Cursor.CursorType.NotAllowed);
        }
    }
}
