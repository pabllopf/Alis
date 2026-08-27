// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectBaseTests.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     Tests the <see cref="ObjectBase" /> abstract base class without requiring any native
    ///     CSFML library, since the base class only stores an <see cref="IntPtr" /> and disposes.
    /// </summary>
    public class ObjectBaseTests
    {
        /// <summary>
        ///     Concrete test subclass that exposes the protected members of <see cref="ObjectBase" />.
        /// </summary>
        private class TestObjectBase : ObjectBase
        {
            /// <summary>
            ///     Gets a value indicating whether <see cref="Destroy" /> was invoked.
            /// </summary>
            public bool DestroyCalled { get; private set; }

            /// <summary>
            ///     Gets the value of the <c>disposing</c> argument passed to <see cref="Destroy" />.
            /// </summary>
            public bool DisposingValue { get; private set; }

            /// <summary>
            ///     Gets the number of times <see cref="Destroy" /> was invoked.
            /// </summary>
            public int DestroyCount { get; private set; }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TestObjectBase" /> class.
            /// </summary>
            /// <param name="cPointer">The internal pointer.</param>
            public TestObjectBase(IntPtr cPointer) : base(cPointer)
            {
            }

            /// <summary>
            ///     Sets the <see cref="ObjectBase.CPointer" /> through the protected setter.
            /// </summary>
            /// <param name="value">The pointer value to assign.</param>
            public void SetCPointer(IntPtr value) => CPointer = value;

            /// <summary>
            ///     Exposes the protected <see cref="ObjectBase.Dispose(bool)" /> method.
            /// </summary>
            /// <param name="disposing">Whether to dispose managed resources.</param>
            public new void Dispose(bool disposing) => base.Dispose(disposing);

            /// <summary>
            ///     Records the invocation and forwards the disposing flag.
            /// </summary>
            /// <param name="disposing">Whether the call is from Dispose or the finalizer.</param>
            public override void Destroy(bool disposing)
            {
                DestroyCalled = true;
                DestroyCount++;
                DisposingValue = disposing;
            }
        }

        /// <summary>
        ///     Tests that the constructor assigns the supplied pointer to <see cref="ObjectBase.CPointer" />.
        /// </summary>
        [Fact]
        public void Constructor_AssignsCPointer()
        {
            IntPtr expected = new IntPtr(1234);
            TestObjectBase obj = new TestObjectBase(expected);

            Assert.Equal(expected, obj.CPointer);
        }

        /// <summary>
        ///     Tests that the <see cref="ObjectBase.CPointer" /> getter returns the assigned pointer.
        /// </summary>
        [Fact]
        public void CPointer_Getter_ReturnsAssignedPointer()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(11));

            Assert.Equal(new IntPtr(11), obj.CPointer);
        }

        /// <summary>
        ///     Tests that the protected <see cref="ObjectBase.CPointer" /> setter updates the pointer.
        /// </summary>
        [Fact]
        public void CPointer_Setter_UpdatesPointer()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(11));
            IntPtr updated = new IntPtr(222);

            obj.SetCPointer(updated);

            Assert.Equal(updated, obj.CPointer);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose()" /> invokes <see cref="ObjectBase.Destroy" /> with
        ///     <c>true</c> and zeroes the pointer.
        /// </summary>
        [Fact]
        public void Dispose_WithValidPointer_CallsDestroyAndZeroesPointer()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(42));

            obj.Dispose();

            Assert.True(obj.DestroyCalled);
            Assert.True(obj.DisposingValue);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose()" /> with a zero pointer does not invoke
        ///     <see cref="ObjectBase.Destroy" />.
        /// </summary>
        [Fact]
        public void Dispose_WithZeroPointer_DoesNotCallDestroy()
        {
            TestObjectBase obj = new TestObjectBase(IntPtr.Zero);

            obj.Dispose();

            Assert.False(obj.DestroyCalled);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that calling <see cref="ObjectBase.Dispose()" /> multiple times invokes
        ///     <see cref="ObjectBase.Destroy" /> only once.
        /// </summary>
        [Fact]
        public void Dispose_CalledTwice_DestroysOnlyOnce()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(42));

            obj.Dispose();
            obj.Dispose();
            obj.Dispose();

            Assert.Equal(1, obj.DestroyCount);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose(bool)" /> with <c>false</c> invokes
        ///     <see cref="ObjectBase.Destroy" /> with <c>false</c> and zeroes the pointer.
        /// </summary>
        [Fact]
        public void Dispose_WithFalse_CallsDestroyAndZeroesPointer()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(77));

            obj.Dispose(false);

            Assert.True(obj.DestroyCalled);
            Assert.False(obj.DisposingValue);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose(bool)" /> with <c>true</c> on an already disposed
        ///     object does not invoke <see cref="ObjectBase.Destroy" /> again.
        /// </summary>
        [Fact]
        public void Dispose_AfterExplicitDispose_DoesNotCallDestroyAgain()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(77));

            obj.Dispose();
            obj.Dispose(false);

            Assert.Equal(1, obj.DestroyCount);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose(bool)" /> with a zero pointer does not invoke
        ///     <see cref="ObjectBase.Destroy" />.
        /// </summary>
        [Fact]
        public void Dispose_WithFalseAndZeroPointer_DoesNotCallDestroy()
        {
            TestObjectBase obj = new TestObjectBase(IntPtr.Zero);

            obj.Dispose(false);

            Assert.False(obj.DestroyCalled);
        }
    }
}
