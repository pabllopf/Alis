// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlManagedHelpersTests.cs
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
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Exercises the pure managed helpers of the Sdl wrapper class.
    /// </summary>
    public class SdlManagedHelpersTests
    {
        /// <summary>
        ///     Verifies the compiled SDL version constant.
        /// </summary>
        [Fact]
        public void GetGlCompiledVersion_ReturnsExpected()
        {
            Assert.Equal(2018, Sdl.GetGlCompiledVersion());
        }

        /// <summary>
        ///     Verifies the runtime version helper.
        /// </summary>
        [Fact]
        public void GetVersion_ReturnsExpected()
        {
            Version version = Sdl.GetVersion();
            Assert.Equal((byte) 2, version.major);
            Assert.Equal((byte) 0, version.minor);
            Assert.Equal((byte) 18, version.patch);
        }

        /// <summary>
        ///     Verifies the fourcc packer packs bytes in little endian order.
        /// </summary>
        [Fact]
        public void Fourcc_PacksBytes()
        {
            Assert.Equal(0x44434241u, Sdl.Fourcc(0x41, 0x42, 0x43, 0x44));
            Assert.Equal(0u, Sdl.Fourcc(0, 0, 0, 0));
        }

        /// <summary>
        ///     Verifies the undefined window position helpers.
        /// </summary>
        [Fact]
        public void WindowPosUndefined_Helpers()
        {
            int value = Sdl.WindowPosUndefinedDisplay(2);
            Assert.True(Sdl.WindowPosIsUndefined(value));
            Assert.False(Sdl.WindowPosIsUndefined(100));
            Assert.Equal(1, Sdl.WindowPosCenteredDisplay(1));
            Assert.True(Sdl.WindowPosIsCentered(Sdl.WindowPosCenteredDisplay(3)));
            Assert.False(Sdl.WindowPosIsCentered(50));
        }

        /// <summary>
        ///     Verifies that scancodes convert to key codes with the scancode mask applied.
        /// </summary>
        [Fact]
        public void ScanCodeToKeyCode_AppliesMask()
        {
            KeyCodes result = Sdl.ScanCodeToKeyCode(SdlScancode.A);
            Assert.True(((int) result & (1 << 30)) != 0);
            Assert.Equal((int) SdlScancode.A, (int) result & 0x3FFFFFFF);
        }

        /// <summary>
        ///     Verifies the button index to mask helper.
        /// </summary>
        [Fact]
        public void Button_ShiftsMask()
        {
            Assert.Equal(1u, Sdl.Button(1));
            Assert.Equal(4u, Sdl.Button(3));
            Assert.Equal(1u << 31, Sdl.Button(32));
        }

        /// <summary>
        ///     Verifies the pixel fourcc helper delegates to the fourcc packer.
        /// </summary>
        [Fact]
        public void SdlDefinePixelFourcc_PacksBytes()
        {
            Assert.Equal(0x44434241u, Sdl.SdlDefinePixelFourcc(0x41, 0x42, 0x43, 0x44));
        }

        /// <summary>
        ///     Verifies the system audio format constants are reachable and platform consistent.
        /// </summary>
        [Fact]
        public void GlAudioConstants_AreConsistent()
        {
            Assert.True(Sdl.GlAudioS16Sys != 0);
            Assert.True(Sdl.GlAudioS32Sys != 0);
            Assert.True(Sdl.GlAudioF32Sys != 0);
            Assert.True(Sdl.GlButtonRMask != 0);
            Assert.True(Sdl.GlButtonX1Mask != 0);
            Assert.True(Sdl.GlButtonX2Mask != 0);
        }
    }
}
