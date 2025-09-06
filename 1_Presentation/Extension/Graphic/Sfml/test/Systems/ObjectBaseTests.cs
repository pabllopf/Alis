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
    ///     The object base tests class
    /// </summary>
    public class ObjectBaseTests
    {
        /// <summary>
        ///     Tests that constructor sets c pointer
        /// </summary>
        [Fact]
        public void Constructor_SetsCPointer()
        {
            IntPtr ptr = new IntPtr(1234);
            TestObject obj = new TestObject(ptr);
            Assert.Equal(ptr, obj.CPointer);
        }

        /// <summary>
        ///     The test object class
        /// </summary>
        /// <seealso cref="ObjectBase" />
        private class TestObject : ObjectBase
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestObject" /> class
            /// </summary>
            /// <param name="ptr">The ptr</param>
            public TestObject(IntPtr ptr) : base(ptr)
            {
            }

            /// <summary>
            ///     Gets or sets the value of the destroy called
            /// </summary>
            public bool DestroyCalled { get; private set; }

            /// <summary>
            ///     Destroys the disposing
            /// </summary>
            /// <param name="disposing">The disposing</param>
            public override void Destroy(bool disposing)
            {
                DestroyCalled = true;
            }
        }
    }
}