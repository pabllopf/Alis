// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputStreamTests.cs
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
    ///     The input stream tests class
    /// </summary>
    public class InputStreamTests
    {
        /// <summary>
        ///     Tests that can assign and invoke callbacks
        /// </summary>
        [Fact]
        public void CanAssignAndInvokeCallbacks()
        {
            InputStream inputStream = new InputStream();
            bool readCalled = false, seekCalled = false, tellCalled = false, getSizeCalled = false;
            inputStream.Read = (data, size, userData) =>
            {
                readCalled = true;
                return 0;
            };
            inputStream.Seek = (position, userData) =>
            {
                seekCalled = true;
                return 0;
            };
            inputStream.Tell = userData =>
            {
                tellCalled = true;
                return 0;
            };
            inputStream.GetSize = userData =>
            {
                getSizeCalled = true;
                return 0;
            };
            inputStream.Read(IntPtr.Zero, 0, IntPtr.Zero);
            inputStream.Seek(0, IntPtr.Zero);
            inputStream.Tell(IntPtr.Zero);
            inputStream.GetSize(IntPtr.Zero);
            Assert.True(readCalled);
            Assert.True(seekCalled);
            Assert.True(tellCalled);
            Assert.True(getSizeCalled);
        }
    }
}