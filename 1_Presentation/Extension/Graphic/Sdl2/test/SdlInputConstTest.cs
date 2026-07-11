// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlInputConstTest.cs
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

using Alis.Extension.Graphic.Sdl2.Mapping;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class SdlInputConstTest
    {
        [Fact]
        public void KScancodeMask_IsCorrect()
        {
            Assert.Equal(1 << 30, SdlInputConst.KScancodeMask);
        }

        [Fact]
        public void ButtonConstants_AreCorrect()
        {
            Assert.Equal(1u, SdlInputConst.ButtonLeft);
            Assert.Equal(2u, SdlInputConst.ButtonMiddle);
            Assert.Equal(3u, SdlInputConst.ButtonRight);
        }

        [Fact]
        public void TouchMouseId_IsMaxValue()
        {
            Assert.Equal(uint.MaxValue, SdlInputConst.TouchMouseId);
        }

        [Fact]
        public void HatConstants_AreCorrect()
        {
            Assert.Equal(0x00, SdlInputConst.HatCentered);
            Assert.Equal(0x03, SdlInputConst.HatRightUp);
            Assert.Equal(0x06, SdlInputConst.HatRightDown);
            Assert.Equal(0x09, SdlInputConst.HatLeftUp);
            Assert.Equal(0x0C, SdlInputConst.HatLeftDown);
        }

        [Fact]
        public void HapticEffectConstants_AreCorrect()
        {
            Assert.Equal(1u << 0, SdlInputConst.HapticConstant);
            Assert.Equal(1u << 1, SdlInputConst.HapticSine);
            Assert.Equal(1u << 2, SdlInputConst.HapticLeftRight);
            Assert.Equal(1u << 11, SdlInputConst.HapticCustom);
            Assert.Equal(1u << 15, SdlInputConst.HapticPauseVar);
        }

        [Fact]
        public void HapticDirectionConstants_AreCorrect()
        {
            Assert.Equal(0, SdlInputConst.HapticPolar);
            Assert.Equal(1, SdlInputConst.HapticCartesian);
            Assert.Equal(2, SdlInputConst.HapticSpherical);
            Assert.Equal(3, SdlInputConst.HapticSteeringAxis);
        }

        [Fact]
        public void IphoneMaxGForce_IsCorrect()
        {
            Assert.Equal(5.0f, SdlInputConst.IphoneMaxGForce);
        }
    }
}
