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
using System.Runtime.InteropServices;
using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the TextEditingEvent struct.
    /// </summary>
    public class TextEditingEventTest
    {
        [Fact]
        public void ShouldMarshalTextFromPointer()
        {
            // Arrange
            string sample = "hello world!";
            IntPtr ptr = Marshal.StringToHGlobalAnsi(sample);
            try
            {
                var evt = GetTextEditingEvent(ptr);
                // Act
                var text = evt.Text;
                // Assert
                Assert.Equal(sample, text);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        [Fact]
        public void ShouldReturnNullTextWhenPtrIsZero()
        {
            // Arrange -- default struct, textPtr is IntPtr.Zero
            var evt = new TextEditingEvent();
            // Act
            var text = evt.Text;
            // Assert
            Assert.Null(text);
        }

        // Helper to construct the struct since it's readonly and struct
        private static TextEditingEvent GetTextEditingEvent(IntPtr textPtr)
        {
            var evt = new TextEditingEvent();
            var field = typeof(TextEditingEvent).GetField("textPtr", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field.SetValueDirect(__makeref(evt), textPtr);
            return evt;
        }
    }
}
