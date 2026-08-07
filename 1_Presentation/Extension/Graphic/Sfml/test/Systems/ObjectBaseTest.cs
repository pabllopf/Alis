// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectBaseTest.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    ///     Tests the <see cref="ObjectBase" /> class.
    /// </summary>
    public class ObjectBaseTest
    {
        /// <summary>
        ///     Test implementation of <see cref="ObjectBase" /> for testing purposes.
        /// </summary>
        private class TestObjectBase : ObjectBase
        {
            /// <summary>
            ///     Gets or sets a value indicating whether <see cref="Destroy" /> was called.
            /// </summary>
            public bool DestroyCalled { get; set; }

            /// <summary>
            ///     Gets or sets the parameter passed to <see cref="Destroy" />.
            /// </summary>
            public bool DisposingParameter { get; set; }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TestObjectBase" /> class.
            /// </summary>
            /// <param name="cPointer">The internal pointer.</param>
            public TestObjectBase(IntPtr cPointer) : base(cPointer)
            {
            }

            /// <summary>
            ///     Records that destroy was called.
            /// </summary>
            /// <param name="disposing">Whether the call is from Dispose or the finalizer.</param>
            public override void Destroy(bool disposing)
            {
                DestroyCalled = true;
                DisposingParameter = disposing;
            }

            /// <summary>
            ///     Exposes the protected <see cref="ObjectBase.Dispose(bool)" /> method.
            /// </summary>
            /// <param name="disposing">Whether to dispose managed resources.</param>
            public new void Dispose(bool disposing) => base.Dispose(disposing);
        }

        /// <summary>
        ///     Tests that the constructor sets <see cref="ObjectBase.CPointer" />.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_SetsCPointer()
        {
            IntPtr ptr = new IntPtr(123);
            TestObjectBase obj = new TestObjectBase(ptr);
            Assert.Equal(ptr, obj.CPointer);
        }

        /// <summary>
        ///     Tests that the protected setter of <see cref="ObjectBase.CPointer" /> updates the value.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void CPointer_Set_Protected_UpdatesValue()
        {
            IntPtr ptr1 = new IntPtr(123);
            IntPtr ptr2 = new IntPtr(456);
            TestObjectBase obj = new TestObjectBase(ptr1);

            var prop = typeof(ObjectBase).GetProperty("CPointer");
            prop.SetValue(obj, ptr2);

            Assert.Equal(ptr2, obj.CPointer);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose()" /> calls <see cref="ObjectBase.Destroy" /> with <c>true</c>.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_CallsDestroyWithTrue()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(123));
            obj.Dispose();
            Assert.True(obj.DestroyCalled);
            Assert.True(obj.DisposingParameter);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose()" /> sets <see cref="ObjectBase.CPointer" /> to <see cref="IntPtr.Zero" />.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_SetsCPointerToZero()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(123));
            obj.Dispose();
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }

        /// <summary>
        ///     Tests that calling <see cref="ObjectBase.Dispose()" /> multiple times only calls <see cref="ObjectBase.Destroy" /> once.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_CalledMultipleTimes_OnlyDestroysOnce()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(123));
            obj.Dispose();
            obj.DestroyCalled = false;
            obj.Dispose();
            Assert.False(obj.DestroyCalled);
        }

        /// <summary>
        ///     Tests that <see cref="ObjectBase.Dispose(bool)" /> with <c>false</c> does not crash.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_WithFalse_DoesNotCrash()
        {
            TestObjectBase obj = new TestObjectBase(new IntPtr(123));
            obj.Dispose(false);
            Assert.True(obj.DestroyCalled);
            Assert.False(obj.DisposingParameter);
        }

        /// <summary>
        ///     Tests that disposing an object with a zero pointer does not call <see cref="ObjectBase.Destroy" />.
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_WithZeroPointer_DoesNotCallDestroy()
        {
            TestObjectBase obj = new TestObjectBase(IntPtr.Zero);
            obj.Dispose();
            Assert.False(obj.DestroyCalled);
        }
    }
}
