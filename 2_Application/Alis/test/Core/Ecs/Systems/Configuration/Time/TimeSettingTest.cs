// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeSettingTest.cs
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

namespace Alis.Test.Core.Ecs.Systems.Configuration.Time
{
    /// <summary>
    ///     Tests for the <see cref="TimeSetting" /> struct.
    /// </summary>
    public class TimeSettingTest
    {
        /// <summary>
        ///     Tests that default values should be correct.
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeCorrect()
        {
            TimeSetting setting = new TimeSetting();
            Assert.Equal(0.016f, setting.FixedTimeStep, 5);
            Assert.Equal(0.25f, setting.MaximumAllowedTimeStep, 5);
            Assert.Equal(1.0f, setting.TimeScale, 5);
        }

        /// <summary>
        ///     Tests that custom constructor should store values.
        /// </summary>
        [Fact]
        public void CustomConstructor_ShouldStoreValues()
        {
            TimeSetting setting = new TimeSetting(0.033f, 0.5f, 2.0f);
            Assert.Equal(0.033f, setting.FixedTimeStep, 5);
            Assert.Equal(0.5f, setting.MaximumAllowedTimeStep, 5);
            Assert.Equal(2.0f, setting.TimeScale, 5);
        }

        /// <summary>
        ///     Tests that TimeSetting implements ITimeSetting.
        /// </summary>
        [Fact]
        public void ShouldImplementITimeSetting()
        {
            TimeSetting setting = new TimeSetting();
            Assert.IsAssignableFrom<ITimeSetting>(setting);
        }

        /// <summary>
        /// Tests that time setting fixed time step boundary should store value
        /// </summary>
        /// <param name="fixedTimeStep">The fixed time step</param>
        [Theory]
        [InlineData(0.001f)]
        [InlineData(0.016f)]
        [InlineData(0.033f)]
        [InlineData(0.1f)]
        public void TimeSetting_FixedTimeStepBoundary_ShouldStoreValue(float fixedTimeStep)
        {
            TimeSetting setting = new TimeSetting(fixedTimeStep, 0.25f, 1.0f);

            Assert.Equal(fixedTimeStep, setting.FixedTimeStep);
        }

        /// <summary>
        /// Tests that time setting max allowed time step boundary should store value
        /// </summary>
        /// <param name="maxStep">The max step</param>
        [Theory]
        [InlineData(0.01f)]
        [InlineData(0.25f)]
        [InlineData(0.5f)]
        [InlineData(1.0f)]
        public void TimeSetting_MaxAllowedTimeStepBoundary_ShouldStoreValue(float maxStep)
        {
            TimeSetting setting = new TimeSetting(0.016f, maxStep, 1.0f);

            Assert.Equal(maxStep, setting.MaximumAllowedTimeStep);
        }

        /// <summary>
        /// Tests that time setting time scale boundary should store value
        /// </summary>
        /// <param name="timeScale">The time scale</param>
        [Theory]
        [InlineData(0.0f)]
        [InlineData(0.5f)]
        [InlineData(1.0f)]
        [InlineData(2.0f)]
        public void TimeSetting_TimeScaleBoundary_ShouldStoreValue(float timeScale)
        {
            TimeSetting setting = new TimeSetting(0.016f, 0.25f, timeScale);

            Assert.Equal(timeScale, setting.TimeScale);
        }
    }
}
