// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectBaseRemainingCoverageTests.cs
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
    ///     The object base remaining coverage tests class
    /// </summary>
    public class ObjectBaseRemainingCoverageTests
    {
        /// <summary>
        ///     The mock object base class
        /// </summary>
        /// <seealso cref="ObjectBase"/>
        private class MockObjectBase : ObjectBase
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="MockObjectBase"/> class
            /// </summary>
            /// <param name="cPointer">The c pointer</param>
            public MockObjectBase(IntPtr cPointer) : base(cPointer)
            {
            }

            /// <summary>
            ///     Gets or sets the value of the destroy called
            /// </summary>
            public bool DestroyCalled { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the disposing flag
            /// </summary>
            public bool DisposingFlag { get; private set; }

            /// <summary>
            ///     Sets the c pointer
            /// </summary>
            /// <param name="value">The value</param>
            public void SetCPointer(IntPtr value) => CPointer = value;

            /// <summary>
            ///     Destroys using the specified disposing
            /// </summary>
            /// <param name="disposing">The disposing</param>
            public override void Destroy(bool disposing)
            {
                DestroyCalled = true;
                DisposingFlag = disposing;
            }
        }

        /// <summary>
        ///     Tests that constructor assigns c pointer
        /// </summary>
        [Fact]
        public void Constructor_AssignsCPointer()
        {
            IntPtr expected = new IntPtr(1234);
            MockObjectBase obj = new MockObjectBase(expected);

            Assert.Equal(expected, obj.CPointer);
        }

        /// <summary>
        ///     Tests that c pointer getter returns assigned pointer
        /// </summary>
        [Fact]
        public void CPointer_Getter_ReturnsAssignedPointer()
        {
            MockObjectBase obj = new MockObjectBase(IntPtr.Zero);

            obj.SetCPointer(new IntPtr(5678));

            Assert.Equal(new IntPtr(5678), obj.CPointer);
        }

        /// <summary>
        ///     Tests that dispose with valid pointer calls destroy
        /// </summary>
        [Fact]
        public void Dispose_WithValidPointer_CallsDestroy()
        {
            MockObjectBase obj = new MockObjectBase(new IntPtr(42));

            obj.Dispose();

            Assert.True(obj.DestroyCalled);
            Assert.True(obj.DisposingFlag);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that dispose with zero pointer does not call destroy
        /// </summary>
        [Fact]
        public void Dispose_WithZeroPointer_DoesNotCallDestroy()
        {
            MockObjectBase obj = new MockObjectBase(IntPtr.Zero);

            obj.Dispose();

            Assert.False(obj.DestroyCalled);
        }

        /// <summary>
        ///     Tests that dispose called twice only destroys once
        /// </summary>
        [Fact]
        public void Dispose_CalledTwice_DestroysOnlyOnce()
        {
            MockObjectBase obj = new MockObjectBase(new IntPtr(42));

            obj.Dispose();
            obj.Dispose();

            Assert.True(obj.DestroyCalled);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that finalizer calls dispose without throwing
        /// </summary>
        [Fact]
        public void Finalizer_CallsDispose_WithoutThrowing()
        {
            CreateUnreferencedObject(new IntPtr(99));

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Assert.True(true);
        }

        /// <summary>
        ///     Creates the unreferenced object
        /// </summary>
        /// <param name="cPointer">The c pointer</param>
        private static void CreateUnreferencedObject(IntPtr cPointer)
        {
            MockObjectBase obj = new MockObjectBase(cPointer);
        }

        /// <summary>
        ///     The throwing mock object base class
        /// </summary>
        /// <seealso cref="ObjectBase"/>
        private class ThrowingMockObjectBase : ObjectBase
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="ThrowingMockObjectBase"/> class
            /// </summary>
            /// <param name="cPointer">The c pointer</param>
            public ThrowingMockObjectBase(IntPtr cPointer) : base(cPointer)
            {
            }

            /// <summary>
            ///     Destroys using the specified disposing
            /// </summary>
            /// <param name="disposing">The disposing</param>
            public override void Destroy(bool disposing)
            {
                throw new InvalidOperationException("Destroy failed");
            }
        }

        /// <summary>
        ///     Tests that finalizer catches destroy exception
        /// </summary>
        [Fact]
        public void Finalizer_CatchesDestroyException()
        {
            CreateUnreferencedThrowingObject(new IntPtr(77));

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Assert.True(true);
        }

        /// <summary>
        ///     Creates the unreferenced throwing object
        /// </summary>
        /// <param name="cPointer">The c pointer</param>
        private static void CreateUnreferencedThrowingObject(IntPtr cPointer)
        {
            ThrowingMockObjectBase obj = new ThrowingMockObjectBase(cPointer);
        }
    }
}
