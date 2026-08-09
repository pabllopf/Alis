// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistryAdditionalTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    /// <summary>
    /// The asset registry additional test class
    /// </summary>
    public class AssetRegistryAdditionalTest
    {

        /// <summary>
        /// Tests that zip cache entry pack bytes read only returns span
        /// </summary>
        [Fact]
        public void ZipCacheEntry_PackBytesReadOnly_ReturnsSpan()
        {
            ZipCacheEntry entry = new ZipCacheEntry();
            byte[] data = { 1, 2, 3 };
            entry.PackBytes = data;

#if !NETSTANDARD2_0 && !NET461
            System.ReadOnlySpan<byte> span = entry.PackBytesReadOnly;
            Assert.Equal(3, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(2, span[1]);
            Assert.Equal(3, span[2]);
#endif
        }

        /// <summary>
        /// Tests that zip cache entry pack bytes read only reflects changes
        /// </summary>
        [Fact]
        public void ZipCacheEntry_PackBytesReadOnly_ReflectsChanges()
        {
            ZipCacheEntry entry = new ZipCacheEntry();
            byte[] data = { 10, 20 };
            entry.PackBytes = data;

#if !NETSTANDARD2_0 && !NET461
            System.ReadOnlySpan<byte> span = entry.PackBytesReadOnly;
            Assert.Equal(10, span[0]);
            data[0] = 99;
            Assert.Equal(99, span[0]);
#endif
        }
    }
}
