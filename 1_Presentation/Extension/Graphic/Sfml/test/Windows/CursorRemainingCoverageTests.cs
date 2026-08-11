// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CursorRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="Cursor"/> class
    /// </summary>
    public class CursorRemainingCoverageTests
    {
        /// <summary>
        /// Tests the system constructor does not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void System_Constructor_DoesNotThrow()
        {
            using Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            Assert.NotNull(cursor);
        }

        /// <summary>
        /// Tests the system constructor with hand type does not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void System_Constructor_Hand_DoesNotThrow()
        {
            using Cursor cursor = new Cursor(Cursor.CursorType.Hand);
            Assert.NotNull(cursor);
        }

        /// <summary>
        /// Tests the system constructor with text type does not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void System_Constructor_Text_DoesNotThrow()
        {
            using Cursor cursor = new Cursor(Cursor.CursorType.Text);
            Assert.NotNull(cursor);
        }

        /// <summary>
        /// Tests the system constructor with cross type does not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void System_Constructor_Cross_DoesNotThrow()
        {
            using Cursor cursor = new Cursor(Cursor.CursorType.Cross);
            Assert.NotNull(cursor);
        }

        /// <summary>
        /// Tests the dispose is safe on a cursor with a zero pointer
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Dispose_IsSafeOnZeroPointer()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.NotAllowed);
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }
    }
}
