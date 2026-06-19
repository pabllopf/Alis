// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeSettingStructTest.cs
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

using Alis.Core.Ecs.Systems.Configuration.Time;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The time setting struct test class
    /// </summary>
    public class TimeSettingStructTest
    {
        /// <summary>
        /// Tests that default values should be correct
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            TimeSetting setting = new TimeSetting();
            Assert.Equal(0.016f, setting.FixedTimeStep);
            Assert.Equal(0.25f, setting.MaximumAllowedTimeStep);
            Assert.Equal(1.0f, setting.TimeScale);
        }

        /// <summary>
        /// Tests that custom constructor should store values
        /// </summary>
        [Fact]
        public void CustomConstructor_ShouldStoreValues()
        {
            TimeSetting setting = new TimeSetting(0.033f, 0.5f, 2.0f);
            Assert.Equal(0.033f, setting.FixedTimeStep);
            Assert.Equal(0.5f, setting.MaximumAllowedTimeStep);
            Assert.Equal(2.0f, setting.TimeScale);
        }

        /// <summary>
        /// Tests that should implement i time setting
        /// </summary>
        [Fact]
        public void ShouldImplementITimeSetting()
        {
            TimeSetting setting = new TimeSetting();
            Assert.IsAssignableFrom<ITimeSetting>(setting);
        }
    }
}
