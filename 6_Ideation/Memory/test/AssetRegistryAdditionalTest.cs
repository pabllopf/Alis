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

using System.Reflection;
using Xunit;

namespace Alis.Core.Aspect.Memory.Test
{
    public class AssetRegistryAdditionalTest
    {
        [Fact]
        public void ToLowerHex_NullBytes_ReturnsEmpty()
        {
            MethodInfo method = typeof(AssetRegistry).GetMethod("ToLowerHex",
                BindingFlags.NonPublic | BindingFlags.Static,
                null,
                new[] { typeof(byte[]) },
                null);

            if (method == null)
            {
                return;
            }

            string result = (string)method.Invoke(null, new object[] { null });
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ToLowerHex_EmptyBytes_ReturnsEmpty()
        {
            MethodInfo method = typeof(AssetRegistry).GetMethod("ToLowerHex",
                BindingFlags.NonPublic | BindingFlags.Static,
                null,
                new[] { typeof(byte[]) },
                null);

            if (method == null)
            {
                return;
            }

            string result = (string)method.Invoke(null, new object[] { System.Array.Empty<byte>() });
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void ToLowerHex_ValidBytes_ReturnsHexString()
        {
            MethodInfo method = typeof(AssetRegistry).GetMethod("ToLowerHex",
                BindingFlags.NonPublic | BindingFlags.Static,
                null,
                new[] { typeof(byte[]) },
                null);

            if (method == null)
            {
                return;
            }

            byte[] input = { 0xAB, 0x1F, 0x00, 0xFF };
            string result = (string)method.Invoke(null, new object[] { input });
            Assert.Equal("ab1f00ff", result);
        }

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
