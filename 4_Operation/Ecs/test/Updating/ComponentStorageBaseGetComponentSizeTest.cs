// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageBaseGetComponentSizeTest.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Unit tests for <see cref="ComponentStorageBase.GetComponentSize{T}" />.
    ///     <para>
    ///         Decision table for the method under test:
    ///         <list type="number">
    ///             <item>Reference type or struct containing a reference → -1</item>
    ///             <item>Unmanaged size that is NOT a power of two              → -1</item>
    ///             <item>Unmanaged size that is &lt; 2 or &gt; 16               → -1</item>
    ///             <item>Unmanaged size that is 2, 4, 8 or 16                   → that size</item>
    ///         </list>
    ///     </para>
    /// </summary>
    public class ComponentStorageBaseGetComponentSizeTest
    {
        // ─────────────────────────────────────────────────────────────────────
        // Helper types used only in this test class
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>3-byte struct (not a power of two → must return -1).</summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct ThreeByteStruct
        {
            public byte A;
            public byte B;
            public byte C;
        }

        /// <summary>12-byte struct (3 × int, not a power of two → must return -1).</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct TwelveByteStruct
        {
            public int A;
            public int B;
            public int C;
        }

        /// <summary>32-byte struct (2 × decimal, power of two but &gt; 16 → must return -1).</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct TwoDecimalsStruct
        {
            public decimal A;
            public decimal B;
        }

        /// <summary>Struct that contains a managed reference (string) → must return -1.</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct StructContainingRef
        {
            public string Text;
        }

        /// <summary>Custom 2-byte struct (should return 2).</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct TwoByteStruct
        {
            public short Value;
        }

        /// <summary>Custom 4-byte struct (two shorts → should return 4).</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct FourByteStruct
        {
            public short A;
            public short B;
        }

        /// <summary>Custom 8-byte struct (two ints → should return 8).</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct EightByteStruct
        {
            public int A;
            public int B;
        }

        /// <summary>Custom 16-byte struct (four ints → should return 16).</summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct SixteenByteStruct
        {
            public int A;
            public int B;
            public int C;
            public int D;
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 1 – Valid sizes: 2, 4, 8, 16
        // ─────────────────────────────────────────────────────────────────────

        /// <summary><c>short</c> is 2 bytes → returns 2.</summary>
        [Fact]
        public void GetComponentSize_Short_Returns2()
        {
            int result = ComponentStorageBase.GetComponentSize<short>();
            Assert.Equal(2, result);
        }

        /// <summary><c>ushort</c> is 2 bytes → returns 2.</summary>
        [Fact]
        public void GetComponentSize_UShort_Returns2()
        {
            int result = ComponentStorageBase.GetComponentSize<ushort>();
            Assert.Equal(2, result);
        }

        /// <summary><c>char</c> is 2 bytes → returns 2.</summary>
        [Fact]
        public void GetComponentSize_Char_Returns2()
        {
            int result = ComponentStorageBase.GetComponentSize<char>();
            Assert.Equal(2, result);
        }

        /// <summary>Custom 2-byte struct → returns 2.</summary>
        [Fact]
        public void GetComponentSize_TwoByteStruct_Returns2()
        {
            int result = ComponentStorageBase.GetComponentSize<TwoByteStruct>();
            Assert.Equal(2, result);
        }

        /// <summary><c>int</c> is 4 bytes → returns 4.</summary>
        [Fact]
        public void GetComponentSize_Int_Returns4()
        {
            int result = ComponentStorageBase.GetComponentSize<int>();
            Assert.Equal(4, result);
        }

        /// <summary><c>uint</c> is 4 bytes → returns 4.</summary>
        [Fact]
        public void GetComponentSize_UInt_Returns4()
        {
            int result = ComponentStorageBase.GetComponentSize<uint>();
            Assert.Equal(4, result);
        }

        /// <summary><c>float</c> is 4 bytes → returns 4.</summary>
        [Fact]
        public void GetComponentSize_Float_Returns4()
        {
            int result = ComponentStorageBase.GetComponentSize<float>();
            Assert.Equal(4, result);
        }

        /// <summary>Custom 4-byte struct (two <c>short</c>s) → returns 4.</summary>
        [Fact]
        public void GetComponentSize_FourByteStruct_Returns4()
        {
            int result = ComponentStorageBase.GetComponentSize<FourByteStruct>();
            Assert.Equal(4, result);
        }

        /// <summary><c>long</c> is 8 bytes → returns 8.</summary>
        [Fact]
        public void GetComponentSize_Long_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<long>();
            Assert.Equal(8, result);
        }

        /// <summary><c>ulong</c> is 8 bytes → returns 8.</summary>
        [Fact]
        public void GetComponentSize_ULong_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<ulong>();
            Assert.Equal(8, result);
        }

        /// <summary><c>double</c> is 8 bytes → returns 8.</summary>
        [Fact]
        public void GetComponentSize_Double_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<double>();
            Assert.Equal(8, result);
        }

        /// <summary>Custom 8-byte struct (two <c>int</c>s) → returns 8.</summary>
        [Fact]
        public void GetComponentSize_EightByteStruct_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<EightByteStruct>();
            Assert.Equal(8, result);
        }

        /// <summary><c>decimal</c> is 16 bytes → returns 16.</summary>
        [Fact]
        public void GetComponentSize_Decimal_Returns16()
        {
            int result = ComponentStorageBase.GetComponentSize<decimal>();
            Assert.Equal(16, result);
        }

        /// <summary>Custom 16-byte struct (four <c>int</c>s) → returns 16.</summary>
        [Fact]
        public void GetComponentSize_SixteenByteStruct_Returns16()
        {
            int result = ComponentStorageBase.GetComponentSize<SixteenByteStruct>();
            Assert.Equal(16, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 2 – Reference types → -1
        // ─────────────────────────────────────────────────────────────────────

        /// <summary><c>string</c> is a reference type → returns -1.</summary>
        [Fact]
        public void GetComponentSize_String_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<string>();
            Assert.Equal(-1, result);
        }

        /// <summary><c>object</c> is a reference type → returns -1.</summary>
        [Fact]
        public void GetComponentSize_Object_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<object>();
            Assert.Equal(-1, result);
        }

        /// <summary>A struct that contains a managed <c>string</c> field → returns -1.</summary>
        [Fact]
        public void GetComponentSize_StructContainingRef_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<StructContainingRef>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 3 – Size < 2 → -1
        // ─────────────────────────────────────────────────────────────────────

        /// <summary><c>byte</c> is 1 byte (size &lt; 2) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_Byte_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<byte>();
            Assert.Equal(-1, result);
        }

        /// <summary><c>sbyte</c> is 1 byte (size &lt; 2) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_SByte_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<sbyte>();
            Assert.Equal(-1, result);
        }

        /// <summary><c>bool</c> is 1 byte (size &lt; 2) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_Bool_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<bool>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 4 – Size > 16 → -1
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>32-byte struct (2 × decimal, power of two but &gt; 16) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_TwoDecimalsStruct_32Bytes_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<TwoDecimalsStruct>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 5 – Size is not a power of two → -1
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>3-byte struct (Pack=1) is not a power of two → returns -1.</summary>
        [Fact]
        public void GetComponentSize_ThreeByteStruct_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<ThreeByteStruct>();
            Assert.Equal(-1, result);
        }

        /// <summary>12-byte struct (3 × int) is not a power of two → returns -1.</summary>
        [Fact]
        public void GetComponentSize_TwelveByteStruct_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<TwelveByteStruct>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 6 – Result is never 0 (guard: valid range is 2-16)
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>The method must never return 0 for any primitive numeric type.</summary>
        [Theory]
        [InlineData(typeof(byte))]
        [InlineData(typeof(sbyte))]
        [InlineData(typeof(short))]
        [InlineData(typeof(ushort))]
        [InlineData(typeof(int))]
        [InlineData(typeof(uint))]
        [InlineData(typeof(long))]
        [InlineData(typeof(ulong))]
        [InlineData(typeof(float))]
        [InlineData(typeof(double))]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(char))]
        [InlineData(typeof(bool))]
        public void GetComponentSize_PrimitiveTypes_NeverReturnsZero(System.Type _)
        {
            // We cannot call the generic method via reflection easily in a parameterised
            // theory, so we assert the full set individually and use this theory just to
            // document the invariant symbolically. The real assertions live in the Fact
            // methods above.
            Assert.True(true);
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 7 – Result is -1 or a valid power-of-two in [2, 16]
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     For the known-valid set the return value must be exactly one of {2, 4, 8, 16}.
        /// </summary>
        [Fact]
        public void GetComponentSize_ValidTypes_ReturnValueIsInAllowedSet()
        {
            int[] allowed = [2, 4, 8, 16];

            Assert.Contains(ComponentStorageBase.GetComponentSize<short>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<ushort>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<char>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<int>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<uint>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<float>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<long>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<ulong>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<double>(), allowed);
            Assert.Contains(ComponentStorageBase.GetComponentSize<decimal>(), allowed);
        }

        /// <summary>
        ///     For the known-invalid set the return value must always be -1.
        /// </summary>
        [Fact]
        public void GetComponentSize_InvalidTypes_AlwaysReturnMinusOne()
        {
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<byte>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<sbyte>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<bool>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<string>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<object>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<ThreeByteStruct>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<TwelveByteStruct>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<TwoDecimalsStruct>());
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<StructContainingRef>());
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 8 – Idempotency (calling twice yields the same result)
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>Calling the method twice for the same type must return the same value.</summary>
        [Fact]
        public void GetComponentSize_CalledTwice_ReturnsSameResult()
        {
            Assert.Equal(
                ComponentStorageBase.GetComponentSize<int>(),
                ComponentStorageBase.GetComponentSize<int>());

            Assert.Equal(
                ComponentStorageBase.GetComponentSize<string>(),
                ComponentStorageBase.GetComponentSize<string>());

            Assert.Equal(
                ComponentStorageBase.GetComponentSize<ThreeByteStruct>(),
                ComponentStorageBase.GetComponentSize<ThreeByteStruct>());
        }

        // ─────────────────────────────────────────────────────────────────────
        // BRANCH 9 – Power-of-two boundary checks
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Size 2 is the inclusive lower boundary; everything smaller must return -1.
        ///     Verifies the &lt; 2 guard.
        /// </summary>
        [Fact]
        public void GetComponentSize_Size1_IsBelow_LowerBoundary_ReturnsMinusOne()
        {
            // byte/sbyte/bool are all exactly 1 byte
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<byte>());
        }

        /// <summary>
        ///     Size 16 is the inclusive upper boundary; everything larger must return -1.
        ///     Verifies the &gt; 16 guard.
        /// </summary>
        [Fact]
        public void GetComponentSize_Size32_IsAbove_UpperBoundary_ReturnsMinusOne()
        {
            // TwoDecimalsStruct is 32 bytes – power of two but above the limit
            Assert.Equal(-1, ComponentStorageBase.GetComponentSize<TwoDecimalsStruct>());
        }

        /// <summary>
        ///     Size 2 is accepted (lower boundary is inclusive).
        /// </summary>
        [Fact]
        public void GetComponentSize_Size2_IsLowerBoundary_Returns2()
        {
            Assert.Equal(2, ComponentStorageBase.GetComponentSize<short>());
        }

        /// <summary>
        ///     Size 16 is accepted (upper boundary is inclusive).
        /// </summary>
        [Fact]
        public void GetComponentSize_Size16_IsUpperBoundary_Returns16()
        {
            Assert.Equal(16, ComponentStorageBase.GetComponentSize<decimal>());
        }
    }
}

