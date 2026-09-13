// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:SdlInputConstCoverageTests.cs
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
    /// <summary>
    ///     Coverage tests for every public constant of <see cref="SdlInputConst" />
    ///     that execute without any native SDL2 dependency.
    /// </summary>
    public class SdlInputConstCoverageTests
    {
        /// <summary>Tests the KScancodeMask constant value.</summary>
        [Fact]
        public void KScancodeMask_IsCorrect()
        {
            Assert.Equal(1 << 30, SdlInputConst.KScancodeMask);
        }

        /// <summary>Tests the ButtonLeft constant value.</summary>
        [Fact]
        public void ButtonLeft_IsCorrect()
        {
            Assert.Equal(1u, SdlInputConst.ButtonLeft);
        }

        /// <summary>Tests the ButtonMiddle constant value.</summary>
        [Fact]
        public void ButtonMiddle_IsCorrect()
        {
            Assert.Equal(2u, SdlInputConst.ButtonMiddle);
        }

        /// <summary>Tests the ButtonRight constant value.</summary>
        [Fact]
        public void ButtonRight_IsCorrect()
        {
            Assert.Equal(3u, SdlInputConst.ButtonRight);
        }

        /// <summary>Tests the TouchMouseId constant value.</summary>
        [Fact]
        public void TouchMouseId_IsCorrect()
        {
            Assert.Equal(uint.MaxValue, SdlInputConst.TouchMouseId);
        }

        /// <summary>Tests the HatCentered constant value.</summary>
        [Fact]
        public void HatCentered_IsCorrect()
        {
            Assert.Equal(0x00, SdlInputConst.HatCentered);
        }

        /// <summary>Tests the HatRightUp constant value.</summary>
        [Fact]
        public void HatRightUp_IsCorrect()
        {
            Assert.Equal(0x03, SdlInputConst.HatRightUp);
        }

        /// <summary>Tests the HatRightDown constant value.</summary>
        [Fact]
        public void HatRightDown_IsCorrect()
        {
            Assert.Equal(0x06, SdlInputConst.HatRightDown);
        }

        /// <summary>Tests the HatLeftUp constant value.</summary>
        [Fact]
        public void HatLeftUp_IsCorrect()
        {
            Assert.Equal(0x09, SdlInputConst.HatLeftUp);
        }

        /// <summary>Tests the HatLeftDown constant value.</summary>
        [Fact]
        public void HatLeftDown_IsCorrect()
        {
            Assert.Equal(0x0C, SdlInputConst.HatLeftDown);
        }

        /// <summary>Tests the IphoneMaxGForce constant value.</summary>
        [Fact]
        public void IphoneMaxGForce_IsCorrect()
        {
            Assert.Equal(5.0f, SdlInputConst.IphoneMaxGForce);
        }

        /// <summary>Tests the HapticConstant constant value.</summary>
        [Fact]
        public void HapticConstant_IsCorrect()
        {
            Assert.Equal(1, SdlInputConst.HapticConstant);
        }

        /// <summary>Tests the HapticSine constant value.</summary>
        [Fact]
        public void HapticSine_IsCorrect()
        {
            Assert.Equal(2, SdlInputConst.HapticSine);
        }

        /// <summary>Tests the HapticLeftRight constant value.</summary>
        [Fact]
        public void HapticLeftRight_IsCorrect()
        {
            Assert.Equal(4, SdlInputConst.HapticLeftRight);
        }

        /// <summary>Tests the HapticTriangle constant value.</summary>
        [Fact]
        public void HapticTriangle_IsCorrect()
        {
            Assert.Equal(8, SdlInputConst.HapticTriangle);
        }

        /// <summary>Tests the HapticSawToothUp constant value.</summary>
        [Fact]
        public void HapticSawToothUp_IsCorrect()
        {
            Assert.Equal(16, SdlInputConst.HapticSawToothUp);
        }

        /// <summary>Tests the HapticSawToothDown constant value.</summary>
        [Fact]
        public void HapticSawToothDown_IsCorrect()
        {
            Assert.Equal(32, SdlInputConst.HapticSawToothDown);
        }

        /// <summary>Tests the HapticSpring constant value.</summary>
        [Fact]
        public void HapticSpring_IsCorrect()
        {
            Assert.Equal(128, SdlInputConst.HapticSpring);
        }

        /// <summary>Tests the HapticDamper constant value.</summary>
        [Fact]
        public void HapticDamper_IsCorrect()
        {
            Assert.Equal(256, SdlInputConst.HapticDamper);
        }

        /// <summary>Tests the HapticInertia constant value.</summary>
        [Fact]
        public void HapticInertia_IsCorrect()
        {
            Assert.Equal(512, SdlInputConst.HapticInertia);
        }

        /// <summary>Tests the HapticFriction constant value.</summary>
        [Fact]
        public void HapticFriction_IsCorrect()
        {
            Assert.Equal(1024, SdlInputConst.HapticFriction);
        }

        /// <summary>Tests the HapticCustom constant value.</summary>
        [Fact]
        public void HapticCustom_IsCorrect()
        {
            Assert.Equal(2048, SdlInputConst.HapticCustom);
        }

        /// <summary>Tests the HapticGain constant value.</summary>
        [Fact]
        public void HapticGain_IsCorrect()
        {
            Assert.Equal(4096, SdlInputConst.HapticGain);
        }

        /// <summary>Tests the HapticAutoCenter constant value.</summary>
        [Fact]
        public void HapticAutoCenter_IsCorrect()
        {
            Assert.Equal(8192, SdlInputConst.HapticAutoCenter);
        }

        /// <summary>Tests the HapticStatus constant value.</summary>
        [Fact]
        public void HapticStatus_IsCorrect()
        {
            Assert.Equal(16384, SdlInputConst.HapticStatus);
        }

        /// <summary>Tests the HapticPauseVar constant value.</summary>
        [Fact]
        public void HapticPauseVar_IsCorrect()
        {
            Assert.Equal(32768, SdlInputConst.HapticPauseVar);
        }

        /// <summary>Tests the HapticPolar constant value.</summary>
        [Fact]
        public void HapticPolar_IsCorrect()
        {
            Assert.Equal(0, SdlInputConst.HapticPolar);
        }

        /// <summary>Tests the HapticCartesian constant value.</summary>
        [Fact]
        public void HapticCartesian_IsCorrect()
        {
            Assert.Equal(1, SdlInputConst.HapticCartesian);
        }

        /// <summary>Tests the HapticSpherical constant value.</summary>
        [Fact]
        public void HapticSpherical_IsCorrect()
        {
            Assert.Equal(2, SdlInputConst.HapticSpherical);
        }

        /// <summary>Tests the HapticSteeringAxis constant value.</summary>
        [Fact]
        public void HapticSteeringAxis_IsCorrect()
        {
            Assert.Equal(3, SdlInputConst.HapticSteeringAxis);
        }
    }
}
