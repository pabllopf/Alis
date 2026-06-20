// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InputStreamTest.cs
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
    ///     Tests the <see cref="InputStream" /> struct.
    /// </summary>
    public class InputStreamTest
    {
        [Fact]
        public void Default_FieldsAreZero()
        {
            InputStream stream = default;
            Assert.Null(stream.Read);
            Assert.Null(stream.Seek);
            Assert.Null(stream.Tell);
            Assert.Null(stream.GetSize);
        }

        [Fact]
        public void ReadDelegate_CanBeAssigned()
        {
            InputStream stream = default;
            stream.Read = (data, size, userData) => 0;
            Assert.NotNull(stream.Read);
        }

        [Fact]
        public void SeekDelegate_CanBeAssigned()
        {
            InputStream stream = default;
            stream.Seek = (position, userData) => 0;
            Assert.NotNull(stream.Seek);
        }

        [Fact]
        public void TellDelegate_CanBeAssigned()
        {
            InputStream stream = default;
            stream.Tell = userData => 0;
            Assert.NotNull(stream.Tell);
        }

        [Fact]
        public void GetSizeDelegate_CanBeAssigned()
        {
            InputStream stream = default;
            stream.GetSize = userData => 0;
            Assert.NotNull(stream.GetSize);
        }

        [Fact]
        public void ReadDelegate_ReturnsCorrectValue()
        {
            InputStream stream = default;
            stream.Read = (data, size, userData) => 42;
            Assert.Equal(42, stream.Read(IntPtr.Zero, 10, IntPtr.Zero));
        }

        [Fact]
        public void SeekDelegate_ReturnsCorrectValue()
        {
            InputStream stream = default;
            stream.Seek = (position, userData) => 100;
            Assert.Equal(100, stream.Seek(50, IntPtr.Zero));
        }

        [Fact]
        public void AllDelegates_WorkSimultaneously()
        {
            InputStream stream = default;
            stream.Read = (_, _, _) => 1;
            stream.Seek = (_, _) => 2;
            stream.Tell = _ => 3;
            stream.GetSize = _ => 4;

            Assert.Equal(1, stream.Read(IntPtr.Zero, 0, IntPtr.Zero));
            Assert.Equal(2, stream.Seek(0, IntPtr.Zero));
            Assert.Equal(3, stream.Tell(IntPtr.Zero));
            Assert.Equal(4, stream.GetSize(IntPtr.Zero));
        }
    }
}
