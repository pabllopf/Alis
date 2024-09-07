// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeConfigurationTest.cs
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

namespace Alis.Core.Aspect.Time.Test
{
    /// <summary>
    ///     The time configuration test class
    /// </summary>
    public class TimeConfigurationTest
    {
        /// <summary>
        ///     Tests that constructor should set properties correctly
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            const float expectedFixedTimeStep = 0.016f;
            const float expectedMaximumAllowedTimeStep = 0.10f;
            const float expectedTimeScale = 1.00f;

            // Act
            TimeConfiguration timeConfig = new TimeConfiguration();

            // Assert
            Assert.Equal(expectedFixedTimeStep, timeConfig.FixedTimeStep);
            Assert.Equal(expectedMaximumAllowedTimeStep, timeConfig.MaximumAllowedTimeStep);
            Assert.Equal(expectedTimeScale, timeConfig.TimeScale);
        }

        /// <summary>
        ///     Tests that constructor should set properties correctly with custom values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectlyWithCustomValues()
        {
            // Arrange
            const float expectedFixedTimeStep = 0.02f;
            const float expectedMaximumAllowedTimeStep = 0.15f;
            const float expectedTimeScale = 0.5f;


            // Act
            TimeConfiguration timeConfig = new TimeConfiguration(expectedFixedTimeStep, expectedMaximumAllowedTimeStep, expectedTimeScale)
            {
                LogOutput = false
            };

            // Assert
            Assert.Equal(expectedFixedTimeStep, timeConfig.FixedTimeStep);
            Assert.Equal(expectedMaximumAllowedTimeStep, timeConfig.MaximumAllowedTimeStep);
            Assert.Equal(expectedTimeScale, timeConfig.TimeScale);
            Assert.False(timeConfig.LogOutput);
        }
    }
}