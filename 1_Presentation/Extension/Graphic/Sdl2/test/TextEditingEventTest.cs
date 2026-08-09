// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextEditingEventTest.cs
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
using System.Reflection;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextEditingEvent struct.
    /// </summary>
    public class TextEditingEventTest
    {

        /// <summary>
        /// Tests that should return null text when ptr is zero
        /// </summary>
        [Fact]
        public void ShouldReturnNullTextWhenPtrIsZero()
        {
            // Arrange -- default struct, textPtr is IntPtr.Zero
            TextEditingEvent evt = new TextEditingEvent();
            // Act
            string text = evt.Text;
            // Assert
            Assert.Null(text);
        }

        // Helper to construct the struct since it's readonly and struct
        /// <summary>
        /// Gets the text editing event using the specified text ptr
        /// </summary>
        /// <param name="textPtr">The text ptr</param>
        /// <returns>The evt</returns>
        private static TextEditingEvent GetTextEditingEvent(IntPtr textPtr)
        {
            TextEditingEvent evt = new TextEditingEvent();
            FieldInfo field = typeof(TextEditingEvent).GetField("textPtr", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValueDirect(__makeref(evt), textPtr);
            return evt;
        }

    }
}
