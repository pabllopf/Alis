// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageBaseTest.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Unit tests for <see cref="ComponentStorageBase" /> covering all concrete members:
    ///     constructor, <see cref="ComponentStorageBase.Buffer" /> field,
    ///     <see cref="ComponentStorageBase.GetComponentSize{T}" />, and
    ///     <see cref="ComponentStorageBase.PullComponentFromAndClearTryDevirt" />.
    /// </summary>
    public class ComponentStorageBaseTest
    {
        // ─────────────────────────────────────────────────────────────────────
        // Constructor / Buffer field
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Constructor stores the supplied array in <see cref="ComponentStorageBase.Buffer" />.
        /// </summary>
        [Fact]
        public void Constructor_SetsBuffer()
        {
            Array expected = new int[8];
            TestComponentStorage storage = new TestComponentStorage(expected);

            Assert.Same(expected, storage.Buffer);
        }

        /// <summary>
        ///     Constructor with zero-length array sets <see cref="ComponentStorageBase.Buffer" /> to an empty array.
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyArray_SetsEmptyBuffer()
        {
            Array expected = Array.Empty<int>();
            TestComponentStorage storage = new TestComponentStorage(expected);

            Assert.Equal(0, storage.Buffer.Length);
        }

        /// <summary>
        ///     Buffer field is publicly readable after construction.
        /// </summary>
        [Fact]
        public void Buffer_IsReadable()
        {
            Array expected = new byte[4];
            TestComponentStorage storage = new TestComponentStorage(expected);

            Assert.Equal(4, storage.Buffer.Length);
            Assert.Same(expected, storage.Buffer);
        }

        // ─────────────────────────────────────────────────────────────────────
        // GetComponentSize<T> — valid sizes
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

        /// <summary><c>decimal</c> is 16 bytes → returns 16.</summary>
        [Fact]
        public void GetComponentSize_Decimal_Returns16()
        {
            int result = ComponentStorageBase.GetComponentSize<decimal>();
            Assert.Equal(16, result);
        }

        /// <summary>Custom 2-byte struct → returns 2.</summary>
        [Fact]
        public void GetComponentSize_TwoByteStruct_Returns2()
        {
            int result = ComponentStorageBase.GetComponentSize<TwoByte>();
            Assert.Equal(2, result);
        }

        /// <summary>Custom 4-byte struct → returns 4.</summary>
        [Fact]
        public void GetComponentSize_FourByteStruct_Returns4()
        {
            int result = ComponentStorageBase.GetComponentSize<FourByte>();
            Assert.Equal(4, result);
        }

        /// <summary>Custom 8-byte struct → returns 8.</summary>
        [Fact]
        public void GetComponentSize_EightByteStruct_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<EightByte>();
            Assert.Equal(8, result);
        }

        /// <summary>Custom 16-byte struct → returns 16.</summary>
        [Fact]
        public void GetComponentSize_SixteenByteStruct_Returns16()
        {
            int result = ComponentStorageBase.GetComponentSize<SixteenByte>();
            Assert.Equal(16, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // GetComponentSize<T> — reference types → -1
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

        /// <summary>A struct containing a managed <c>string</c> field → returns -1.</summary>
        [Fact]
        public void GetComponentSize_StructContainingRef_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<StructWithRef>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // GetComponentSize<T> — size < 2 → -1
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
        // GetComponentSize<T> — size > 16 → -1
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>32-byte struct (power of two but > 16) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_StructOver16Bytes_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<Struct32Bytes>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // GetComponentSize<T> — non-power-of-two → -1
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>3-byte struct (not power of two) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_ThreeByteStruct_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<ThreeByte>();
            Assert.Equal(-1, result);
        }

        /// <summary>12-byte struct (not power of two) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_TwelveByteStruct_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<TwelveByte>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // GetComponentSize<T> — idempotency
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>Calling the method twice for the same type returns the same value.</summary>
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
                ComponentStorageBase.GetComponentSize<ThreeByte>(),
                ComponentStorageBase.GetComponentSize<ThreeByte>());
        }

        // ─────────────────────────────────────────────────────────────────────
        // GetComponentSize<T> — additional edge-case types
        // ─────────────────────────────────────────────────────────────────────

        /// <summary><c>nint</c> (<see cref="IntPtr" />) is 8 bytes on 64-bit → returns 8.</summary>
        [Fact]
        public void GetComponentSize_IntPtr_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<nint>();
            Assert.Equal(8, result);
        }

        /// <summary><c>nuint</c> (<see cref="UIntPtr" />) is 8 bytes on 64-bit → returns 8.</summary>
        [Fact]
        public void GetComponentSize_UIntPtr_Returns8()
        {
            int result = ComponentStorageBase.GetComponentSize<nuint>();
            Assert.Equal(8, result);
        }

        /// <summary><c>Guid</c> is 16 bytes → returns 16.</summary>
        [Fact]
        public void GetComponentSize_Guid_Returns16()
        {
            int result = ComponentStorageBase.GetComponentSize<Guid>();
            Assert.Equal(16, result);
        }

        /// <summary><c>Half</c> is 2 bytes → returns 2.</summary>
        [Fact]
        public void GetComponentSize_Half_Returns2()
        {
            int result = ComponentStorageBase.GetComponentSize<Half>();
            Assert.Equal(2, result);
        }

        /// <summary><c>Int128</c> is 16 bytes → returns 16.</summary>
        [Fact]
        public void GetComponentSize_Int128_Returns16()
        {
            int result = ComponentStorageBase.GetComponentSize<Int128>();
            Assert.Equal(16, result);
        }

        /// <summary>A custom class (reference type) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_CustomClass_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<CustomClass>();
            Assert.Equal(-1, result);
        }

        /// <summary>An empty struct has size 1 (less than 2) → returns -1.</summary>
        [Fact]
        public void GetComponentSize_EmptyStruct_ReturnsMinusOne()
        {
            int result = ComponentStorageBase.GetComponentSize<EmptyStruct>();
            Assert.Equal(-1, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // PullComponentFromAndClearTryDevirt
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     <see cref="ComponentStorageBase.PullComponentFromAndClearTryDevirt" /> delegates to
        ///     <see cref="ComponentStorageBase.PullComponentFromAndClear" />.
        /// </summary>
        [Fact]
        public void PullComponentFromAndClearTryDevirt_DelegatesToPullComponentFromAndClear()
        {
            TestComponentStorage storage = new TestComponentStorage(new int[4]);
            TestComponentStorage other = new TestComponentStorage(new int[4]);

            storage.PullComponentFromAndClearTryDevirt(other, 1, 2, 3);

            Assert.True(storage.PullFromAndClearCalled);
        }

        /// <summary>
        ///     <see cref="ComponentStorageBase.PullComponentFromAndClearTryDevirt" /> passes the correct
        ///     arguments to <see cref="ComponentStorageBase.PullComponentFromAndClear" />.
        /// </summary>
        [Fact]
        public void PullComponentFromAndClearTryDevirt_PassesCorrectArguments()
        {
            TestComponentStorage storage = new TestComponentStorage(new int[4]);
            TestComponentStorage other = new TestComponentStorage(new int[8]);

            storage.PullComponentFromAndClearTryDevirt(other, 5, 6, 7);

            Assert.Same(other, storage.PullFromOtherRunner);
            Assert.Equal(5, storage.PullFromMe);
            Assert.Equal(6, storage.PullFromOther);
            Assert.Equal(7, storage.PullFromOtherRemove);
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Helper types
    // ─────────────────────────────────────────────────────────────────────────

    /// <summary>
    ///     Concrete implementation of <see cref="ComponentStorageBase" /> for testing non-abstract members.
    ///     Tracks whether <see cref="PullComponentFromAndClear" /> was called.
    /// </summary>
    internal class TestComponentStorage(Array buffer) : ComponentStorageBase(buffer)
    {
        /// <summary>
        ///     Whether <see cref="PullComponentFromAndClear" /> was invoked.
        /// </summary>
        public bool PullFromAndClearCalled;

        /// <summary>
        ///     The <c>otherRunner</c> argument passed to <see cref="PullComponentFromAndClear" />.
        /// </summary>
        public ComponentStorageBase PullFromOtherRunner;

        /// <summary>
        ///     The <c>me</c> argument passed to <see cref="PullComponentFromAndClear" />.
        /// </summary>
        public int PullFromMe;

        /// <summary>
        ///     The <c>other</c> argument passed to <see cref="PullComponentFromAndClear" />.
        /// </summary>
        public int PullFromOther;

        /// <summary>
        ///     The <c>otherRemove</c> argument passed to <see cref="PullComponentFromAndClear" />.
        /// </summary>
        public int PullFromOtherRemove;

        /// <summary>
        ///     Gets the component id
        /// </summary>
        internal override ComponentId ComponentId => throw new NotSupportedException();

        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The archetype</param>
        internal override void Run(Scene scene, Archetype b)
        {
        }

        /// <summary>
        ///     Runs the scene with range
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The archetype</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Scene scene, Archetype b, int start, int length)
        {
        }

        /// <summary>
        ///     Deletes the delete component data
        /// </summary>
        /// <param name="deleteComponentData">The delete component data</param>
        internal override void Delete(DeleteComponentData deleteComponentData)
        {
        }

        /// <summary>
        ///     Trims the chunk index
        /// </summary>
        /// <param name="chunkIndex">The chunk index</param>
        internal override void Trim(int chunkIndex)
        {
        }

        /// <summary>
        ///     Resizes the buffer
        /// </summary>
        /// <param name="size">The size</param>
        internal override void ResizeBuffer(int size)
        {
        }

        /// <summary>
        ///     Pulls the component from and clear
        /// </summary>
        /// <param name="otherRunner">The other runner</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        /// <param name="otherRemove">The other remove</param>
        internal override void PullComponentFromAndClear(ComponentStorageBase otherRunner, int me, int other,
            int otherRemove)
        {
            PullFromAndClearCalled = true;
            PullFromOtherRunner = otherRunner;
            PullFromMe = me;
            PullFromOther = other;
            PullFromOtherRemove = otherRemove;
        }

        /// <summary>
        ///     Pulls the component from
        /// </summary>
        /// <param name="storage">The storage</param>
        /// <param name="me">The me</param>
        /// <param name="other">The other</param>
        internal override void PullComponentFrom(IdTable storage, int me, int other)
        {
        }

        /// <summary>
        ///     Invokes the generic action with
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="gameObject">The gameObject</param>
        /// <param name="index">The index</param>
        internal override void InvokeGenericActionWith(GenericEvent action, GameObject gameObject, int index)
        {
        }

        /// <summary>
        ///     Invokes the generic action with
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="index">The index</param>
        internal override void InvokeGenericActionWith(IGenericAction action, int index)
        {
        }

        /// <summary>
        ///     Stores the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The component handle</returns>
        internal override ComponentHandle Store(int index) => throw new NotSupportedException();

        /// <summary>
        ///     Sets the at
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="index">The index</param>
        internal override void SetAt(object component, int index)
        {
        }

        /// <summary>
        ///     Gets the at
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object</returns>
        internal override object GetAt(int index) => throw new NotSupportedException();
    }

    /// <summary>2-byte struct for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct TwoByte
    {
        /// <summary>
        ///     The value
        /// </summary>
        public short Value;
    }

    /// <summary>4-byte struct for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct FourByte
    {
        /// <summary>
        ///     The a
        /// </summary>
        public short A;

        /// <summary>
        ///     The b
        /// </summary>
        public short B;
    }

    /// <summary>8-byte struct for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct EightByte
    {
        /// <summary>
        ///     The a
        /// </summary>
        public int A;

        /// <summary>
        ///     The b
        /// </summary>
        public int B;
    }

    /// <summary>16-byte struct for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SixteenByte
    {
        /// <summary>
        ///     The a
        /// </summary>
        public int A;

        /// <summary>
        ///     The b
        /// </summary>
        public int B;

        /// <summary>
        ///     The c
        /// </summary>
        public int C;

        /// <summary>
        ///     The d
        /// </summary>
        public int D;
    }

    /// <summary>Struct containing a managed reference for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct StructWithRef
    {
        /// <summary>
        ///     The text
        /// </summary>
        public string Text;
    }

    /// <summary>32-byte struct (power of two but > 16) for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Struct32Bytes
    {
        /// <summary>
        ///     The a
        /// </summary>
        public decimal A;

        /// <summary>
        ///     The b
        /// </summary>
        public decimal B;
    }

    /// <summary>3-byte struct (not power of two) for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ThreeByte
    {
        /// <summary>
        ///     The a
        /// </summary>
        public byte A;

        /// <summary>
        ///     The b
        /// </summary>
        public byte B;

        /// <summary>
        ///     The c
        /// </summary>
        public byte C;
    }

    /// <summary>12-byte struct (not power of two) for testing GetComponentSize.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct TwelveByte
    {
        /// <summary>
        ///     The a
        /// </summary>
        public int A;

        /// <summary>
        ///     The b
        /// </summary>
        public int B;

        /// <summary>
        ///     The c
        /// </summary>
        public int C;
    }

    /// <summary>Custom class for testing GetComponentSize with a reference type.</summary>
    internal class CustomClass
    {
    }

    /// <summary>Empty struct (size 1) for testing the size &lt; 2 branch.</summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct EmptyStruct
    {
    }
}
