// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingEnvMixingTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    /// Provides tests for the friction and restitution mixing laws in SettingEnv.
    /// </summary>
    public class SettingEnvMixingTest
    {
        /// <summary>
        /// Tests the MixFriction method returns the geometric mean.
        /// </summary>
        [Fact]
        public void MixFriction_ReturnsGeometricMean()
        {
            float f1 = 0.5f;
            float f2 = 0.8f;
            float expected = (float)Math.Sqrt(f1 * f2);
            float actual = SettingEnv.MixFriction(f1, f2);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests the MixRestitution method returns the maximum value.
        /// </summary>
        [Fact]
        public void MixRestitution_ReturnsMaximum()
        {
            float r1 = 0.3f;
            float r2 = 0.7f;
            float expected = r2;
            float actual = SettingEnv.MixRestitution(r1, r2);
            Assert.Equal(expected, actual);
        }
    }
}
