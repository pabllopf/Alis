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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class CursorTests
    {
        [Fact]
        public void Cursor_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Cursor)));
        }

        [Fact]
        public void CursorType_IsNestedEnum()
        {
            Assert.True(typeof(Cursor.CursorType).IsEnum);
            Assert.True(typeof(Cursor.CursorType).IsNested);
        }

        [Fact]
        public void Cursor_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Cursor)));
        }

        [Fact]
        public void Constructor_WithSystemType_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Constructor_WithSystemType_Hand_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Hand);
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Constructor_WithSystemType_Text_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Text);
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Constructor_WithSystemType_Wait_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Wait);
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Constructor_WithSystemTypeAllValues_DoesNotThrow()
        {
            foreach (Cursor.CursorType type in Enum.GetValues(typeof(Cursor.CursorType)))
            {
                Cursor cursor = new Cursor(type);
                cursor.Dispose();
            }
        }

        [Fact]
        public void Destroy_SetsCPointerToZero()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Destroy(true);
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Destroy_CalledTwice_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Destroy(true);
            cursor.Destroy(true);
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Destroy_WithDisposingTrue_SetsCPointerToZero()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Destroy(true);
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Destroy_WithDisposingFalse_SetsCPointerToZero()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Destroy(false);
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Dispose_SetsCPointerToZero()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            cursor.Dispose();
            cursor.Dispose();
            Assert.Equal(IntPtr.Zero, cursor.CPointer);
        }

        [Fact]
        public void Cursor_WithSystemType_ConstructorInvokesNativeCall()
        {
            Cursor cursor = new Cursor(Cursor.CursorType.Arrow);
            Assert.NotNull(cursor);
            cursor.Dispose();
        }

        [Fact]
        public void Cursor_HasDestroyMethod()
        {
            Assert.NotNull(typeof(Cursor).GetMethod("Destroy", new[] { typeof(bool) }));
        }

        [Fact]
        public void Cursor_HasCPointerProperty()
        {
            Assert.NotNull(typeof(Cursor).GetProperty("CPointer"));
        }

        [Fact]
        public void Cursor_HasConstructorWithCursorType()
        {
            Assert.NotNull(typeof(Cursor).GetConstructor(new[] { typeof(Cursor.CursorType) }));
        }

        [Fact]
        public void Cursor_HasConstructorWithPixelsSizeAndHotspot()
        {
            Assert.NotNull(typeof(Cursor).GetConstructor(new[]
            {
                typeof(byte[]),
                typeof(Vector2F),
                typeof(Vector2F)
            }));
        }

        [Fact]
        public void Cursor_SystemCursor_CanBeConstructedWithAllTypes()
        {
            foreach (Cursor.CursorType type in Enum.GetValues(typeof(Cursor.CursorType)))
            {
                using Cursor cursor = new Cursor(type);
            }
        }
    }
}
