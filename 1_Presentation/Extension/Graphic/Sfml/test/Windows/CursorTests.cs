// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The cursor tests class
    /// </summary>
    public class CursorTests
    {
        /// <summary>
        ///     Tests that constructor system cursor type does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Cursor without native SFML dependencies.")]
        public void Constructor_SystemCursorType_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            Assert.NotNull(cursor);
        }

        /// <summary>
        ///     Tests that constructor pixels does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Cursor without native SFML dependencies.")]
        public void Constructor_Pixels_DoesNotThrow()
        {
            byte[] pixels = new byte[16 * 16 * 4];
            Vector2F size = new Vector2F(16, 16);
            Vector2F hotspot = new Vector2F(0, 0);
            Cursor cursor = new Cursor(pixels, size, hotspot);
            Assert.NotNull(cursor);
        }

        /// <summary>
        ///     Tests that destroy does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Cursor without native SFML dependencies.")]
        public void Destroy_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Destroy(true);
        }
    }
}