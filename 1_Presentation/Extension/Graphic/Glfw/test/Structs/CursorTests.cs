

using System;
using Alis.Extension.Graphic.Glfw.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Tests for Cursor structure
    /// </summary>
    public class CursorTests
    {
        /// <summary>
        ///     Tests that cursor none is default value
        /// </summary>
        [Fact]
        public void Cursor_None_IsDefaultValue()
        {
            Cursor none = Cursor.None;

            Assert.Equal(default(Cursor), none);
        }

        /// <summary>
        ///     Tests that cursor equals with same cursor returns true
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithSameCursor_ReturnsTrue()
        {
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            bool result = cursor1.Equals(cursor2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that cursor equals with object returns correct result
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithObject_ReturnsCorrectResult()
        {
            Cursor cursor = Cursor.None;
            object obj = Cursor.None;

            bool result = cursor.Equals(obj);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that cursor equals with non cursor object returns false
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithNonCursorObject_ReturnsFalse()
        {
            Cursor cursor = Cursor.None;
            object obj = new object();

            bool result = cursor.Equals(obj);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that cursor get hash code returns same for equal cursors
        /// </summary>
        [Fact]
        public void Cursor_GetHashCode_ReturnsSameForEqualCursors()
        {
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            int hash1 = cursor1.GetHashCode();
            int hash2 = cursor2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that cursor equality operator with same cursors returns true
        /// </summary>
        [Fact]
        public void Cursor_EqualityOperator_WithSameCursors_ReturnsTrue()
        {
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            bool result = cursor1 == cursor2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that cursor inequality operator with same cursors returns false
        /// </summary>
        [Fact]
        public void Cursor_InequalityOperator_WithSameCursors_ReturnsFalse()
        {
            Cursor cursor1 = Cursor.None;
            Cursor cursor2 = Cursor.None;

            bool result = cursor1 != cursor2;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that cursor equals with i equatable interface works
        /// </summary>
        [Fact]
        public void Cursor_Equals_WithIEquatableInterface_Works()
        {
            Cursor cursor1 = Cursor.None;
            IEquatable<Cursor> cursor2 = Cursor.None;

            bool result = cursor1.Equals(cursor2);

            Assert.True(result);
        }
    }
}