// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontConfigTest.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImFontConfig" /> as a blittable interop struct.
    /// </summary>
    public class ImFontConfigTest
    {
        /// <summary>
        ///     Verifies that the name buffer can be assigned with 40 bytes.
        /// </summary>
        [Fact]
        public void Name_ShouldAcceptFixedBufferSize()
        {
            ImFontConfig config = new ImFontConfig
            {
                Name = new byte[40]
            };

            Assert.Equal(40, config.Name.Length);
        }

        /// <summary>
        ///     Verifies that marshal roundtrip keeps the configured field values.
        /// </summary>
        [Fact]
        public void MarshalRoundtrip_ShouldPreserveValues()
        {
            ImFontConfig expected = new ImFontConfig
            {
                FontData = new IntPtr(11),
                FontDataSize = 22,
                FontDataOwnedByAtlas = 1,
                FontNo = 2,
                SizePixels = 14.5f,
                OversampleH = 3,
                OversampleV = 4,
                SnapH = 1,
                GlyphRanges = new IntPtr(33),
                GlyphMinAdvanceX = 1.25f,
                GlyphMaxAdvanceX = 2.5f,
                MergeMode = 1,
                FontBuilderFlags = 99,
                RasterizerMultiply = 0.75f,
                EllipsisChar = 46,
                Name = new byte[40],
                DstFont = new IntPtr(44)
            };
            expected.Name[0] = (byte) 'A';
            expected.Name[1] = (byte) 'l';
            expected.Name[2] = (byte) 'i';
            expected.Name[3] = (byte) 's';

            IntPtr native = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontConfig>());
            try
            {
                Marshal.StructureToPtr(expected, native, false);
                ImFontConfig actual = Marshal.PtrToStructure<ImFontConfig>(native);

                Assert.Equal(expected.FontData, actual.FontData);
                Assert.Equal(expected.FontDataSize, actual.FontDataSize);
                Assert.Equal(expected.SizePixels, actual.SizePixels);
                Assert.Equal(expected.GlyphMinAdvanceX, actual.GlyphMinAdvanceX);
                Assert.Equal(expected.FontBuilderFlags, actual.FontBuilderFlags);
                Assert.Equal(expected.DstFont, actual.DstFont);
                Assert.Equal(expected.Name[0], actual.Name[0]);
            }
            finally
            {
                Marshal.FreeHGlobal(native);
            }
        }
    }
}